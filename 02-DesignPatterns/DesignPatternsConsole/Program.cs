using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecoratorDemo;
using MediatorDemo;
using ObserverDemo;
using AdapterDemo;
using CqrsDemo;
using SingletonDemo;
using FactoryDemo;
using StrategyDemo;
using RepositoryDemo;
using UnitOfWorkDemo;
using Microsoft.Extensions.DependencyInjection;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("""
╔══════════════════════════════════════════════════════════════╗
║                     DESIGN PATTERNS DEMO                      ║
║              (Singleton, Factory, Strategy, Repository,       ║
║               UnitOfWork, Decorator, Mediator, Observer,      ║
║               Adapter, CQRS)                                 ║
╚══════════════════════════════════════════════════════════════╝
""");

// Setup DI for Mediator (if needed)
var services = new ServiceCollection();
services.AddSingleton<IMediator, MediatorDemo.Mediator>();
services.AddTransient<IRequestHandler<SendNotificationCommand, bool>, SendNotificationHandler>();
var serviceProvider = services.BuildServiceProvider();

// 1. Singleton
Console.WriteLine("\n📌 1. SINGLETON PATTERN");
Console.WriteLine(new string('─', 50));
DemoSingleton();

// 2. Factory
Console.WriteLine("\n📌 2. FACTORY PATTERN");
Console.WriteLine(new string('─', 50));
DemoFactory();

// 3. Strategy
Console.WriteLine("\n📌 3. STRATEGY PATTERN");
Console.WriteLine(new string('─', 50));
DemoStrategy();

// 4. Repository
Console.WriteLine("\n📌 4. REPOSITORY PATTERN");
Console.WriteLine(new string('─', 50));
DemoRepository();

// 5. Unit of Work
Console.WriteLine("\n📌 5. UNIT OF WORK PATTERN");
Console.WriteLine(new string('─', 50));
await DemoUnitOfWork();

// 6. Decorator
Console.WriteLine("\n📌 6. DECORATOR PATTERN");
Console.WriteLine(new string('─', 50));
DemoDecorator();

// 7. Mediator
Console.WriteLine("\n📌 7. MEDIATOR PATTERN");
Console.WriteLine(new string('─', 50));
await DemoMediator(serviceProvider);

// 8. Observer
Console.WriteLine("\n📌 8. OBSERVER PATTERN");
Console.WriteLine(new string('─', 50));
DemoObserver();

// 9. Adapter
Console.WriteLine("\n📌 9. ADAPTER PATTERN");
Console.WriteLine(new string('─', 50));
await DemoAdapter();

// 10. CQRS
Console.WriteLine("\n📌 10. CQRS (COMMAND QUERY RESPONSIBILITY SEGREGATION)");
Console.WriteLine(new string('─', 50));
await DemoCqrs();

Console.WriteLine("\n" + new string('═', 60));
Console.WriteLine("✅ All 10 design patterns demonstrated successfully!");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

// ============================================================
// Demo Methods - each one calls the real implementation from the respective project
// ============================================================

static void DemoSingleton()
{
    var logger1 = Logger.Instance;
    logger1.LogInfo("Singleton demo started");
    logger1.LogWarning("This is a warning");
    logger1.LogError("This is an error");

    var logger2 = Logger.Instance;
    Console.WriteLine($"\n✅ Same instance? {ReferenceEquals(logger1, logger2)}");
}

static void DemoFactory()
{
    var email = NotificationFactory.Create("email");
    email.Send("user@test.com", "Hello via Email!");

    var sms = NotificationFactory.Create("sms");
    sms.Send("+123456789", "Hello via SMS!");

    var push = NotificationFactory.Create("push");
    push.Send("device123", "Hello via Push!");
}

static void DemoStrategy()
{
    var cart = new ShoppingCart();
    cart.AddItem("Laptop", 1299.99m);
    cart.AddItem("Mouse", 29.99m, 2);

    cart.SetPaymentStrategy(new CreditCardPayment("1234-5678-9012-3456", "John Doe"));
    cart.Checkout();

    cart.SetPaymentStrategy(new PayPalPayment("john@paypal.com"));
    cart.Checkout();

    cart.SetPaymentStrategy(new BitcoinPayment("1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa"));
    cart.Checkout();
}

static void DemoRepository()
{
    var repo = new CustomerRepository();

    Console.WriteLine("All customers:");
    foreach (var c in repo.GetAll())
        Console.WriteLine($"  {c}");

    Console.WriteLine("\nActive customers:");
    foreach (var c in repo.GetActiveCustomers())
        Console.WriteLine($"  {c}");

    Console.WriteLine("\nSearch for 'John':");
    foreach (var c in repo.SearchCustomers("John"))
        Console.WriteLine($"  {c}");

    var newC = new Customer
    {
        FirstName = "Sarah",
        LastName = "Wilson",
        Email = "sarah@email.com",
        Phone = "555-999-8888"
    };
    repo.Add(newC);
    Console.WriteLine($"\nTotal customers after add: {repo.Count}");
}

static async Task DemoUnitOfWork()
{
    using var uow = new UnitOfWork();

    Console.WriteLine("Products before order:");
    foreach (var p in uow.Products.GetAll())
        Console.WriteLine($"  {p}");

    var order = new Order
    {
        CustomerId = 1,
        Status = "Pending",
        Items = new List<OrderItem>
        {
            new OrderItem { ProductId = 1, ProductName = "Laptop", Quantity = 1, UnitPrice = 1299.99m },
            new OrderItem { ProductId = 2, ProductName = "Mouse", Quantity = 2, UnitPrice = 29.99m }
        }
    };

    var total = order.Items.Sum(i => i.TotalPrice);
    order = order with { TotalAmount = total };

    uow.Orders.Add(order);
    uow.TrackChange(order);

    foreach (var item in order.Items)
    {
        var product = uow.Products.GetById(item.ProductId);
        if (product is not null)
        {
            var newStock = product.StockQuantity - item.Quantity;
            uow.Products.UpdateStock(item.ProductId, newStock);
            uow.TrackChange(product);
        }
    }

    uow.Complete();

    Console.WriteLine("\nProducts after order:");
    foreach (var p in uow.Products.GetAll())
        Console.WriteLine($"  {p}");

    Console.WriteLine("\nAll orders:");
    foreach (var o in uow.Orders.GetAll())
        Console.WriteLine($"  {o}");
}

static void DemoDecorator()
{
    INotificationService email = new EmailNotificationService();
    INotificationService logged = new LoggingNotificationDecorator(email);
    INotificationService resilient = new RetryNotificationDecorator(logged, 3);

    resilient.Send("user@example.com", "Hello from Decorator!");
}

static async Task DemoMediator(IServiceProvider sp)
{
    var mediator = sp.GetRequiredService<IMediator>();
    var result = await mediator.Send<SendNotificationCommand, bool>(
        new SendNotificationCommand("user@test.com", "Hello from Mediator!")
    );
    Console.WriteLine($"✅ Mediator result: {result}");
}

static void DemoObserver()
{
    var sensor = new TemperatureSensor();
    var display1 = new TemperatureDisplay("Display 1");
    var display2 = new TemperatureDisplay("Display 2");
    var alert = new AlertSystem(30.0);

    sensor.Attach(display1);
    sensor.Attach(display2);
    sensor.Attach(alert);

    sensor.SetTemperature(25.0);
    sensor.SetTemperature(28.5);
    sensor.SetTemperature(32.0);
}

static async Task DemoAdapter()
{
    var stripeApi = new StripeApi();
    IPaymentProcessor processor = new StripeAdapter(stripeApi);

    var result = await processor.ProcessPaymentAsync(99.99m, "USD", "cust_123");
    Console.WriteLine($"💳 Payment result: {result}");
}

static async Task DemoCqrs()
{
    var command = new CreateOrderCommand("Laptop", 1, 1299.99m);
    var commandHandler = new CreateOrderCommandHandler();
    var orderId = await commandHandler.Handle(command);

    var query = new GetOrderQuery(orderId);
    var queryHandler = new GetOrderQueryHandler();
    var order = await queryHandler.Handle(query);

    if (order is not null)
    {
        Console.WriteLine($"📖 Order found: {order.ProductName} x {order.Quantity} = ${order.TotalAmount}");
    }
}