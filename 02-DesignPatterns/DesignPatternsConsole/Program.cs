using SingletonDemo;
using FactoryDemo;
using StrategyDemo;
using RepositoryDemo;
using UnitOfWorkDemo;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("""
╔══════════════════════════════════════════════════════════════╗
║                     DESIGN PATTERNS DEMO           
╚══════════════════════════════════════════════════════════════╝
""");

// Singleton Demo
Console.WriteLine("\n📌 1. SINGLETON PATTERN");
Console.WriteLine(new string('─', 50));
DemoSingleton();

Console.WriteLine("\n📌 2. FACTORY PATTERN");
Console.WriteLine(new string('─', 50));
DemoFactory();

Console.WriteLine("\n📌 3. STRATEGY PATTERN");
Console.WriteLine(new string('─', 50));
DemoStrategy();

Console.WriteLine("\n📌 4. REPOSITORY PATTERN");
Console.WriteLine(new string('─', 50));
DemoRepository();

Console.WriteLine("\n📌 5. UNIT OF WORK PATTERN");
Console.WriteLine(new string('─', 50));
DemoUnitOfWork();

Console.WriteLine("\n" + new string('═', 60));
Console.WriteLine("✅ All Design Patterns demonstrated successfully!");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

// ===== Demo Methods =====

static void DemoSingleton()
{
    Console.WriteLine("Testing Singleton Pattern...\n");

    var logger1 = Logger.Instance;
    logger1.LogInfo("Application started");
    logger1.LogWarning("This is a warning message");
    logger1.LogError("This is an error message");
    logger1.LogDebug("Debugging information");

    var logger2 = Logger.Instance;
    logger2.LogInfo("Additional log message");

    Console.WriteLine($"\n📊 Singleton Info:");
    Console.WriteLine($"   Same instance? {ReferenceEquals(logger1, logger2)}");
    Console.WriteLine($"   Instance hash: {logger1.GetHashCode():X}");
    Console.WriteLine($"   Log file path: {logger1.LogFilePath}");
    Console.WriteLine("\n✅ Singleton pattern ensures only one instance exists!");
}

static void DemoFactory()
{
    Console.WriteLine("Testing Factory Pattern...\n");

    var types = new[] { "email", "sms", "push", "slack" };

    foreach (var type in types)
    {
        try
        {
            Console.WriteLine($"Creating {type} notification...");
            var notification = NotificationFactory.Create(type);
            notification.Send("user@example.com", $"Hello from {type}!");

            if (NotificationFactory.TryCreate(type, out var notif))
            {
                Console.WriteLine($"   ✅ Created: {notif!.TypeName}");
            }
            Console.WriteLine();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"   ❌ {ex.Message}");
            Console.WriteLine();
        }
    }

    Console.WriteLine("✅ Factory pattern creates appropriate objects based on type!");
}

static void DemoStrategy()
{
    Console.WriteLine("Testing Strategy Pattern...\n");

    var cart = new ShoppingCart();

    cart.AddItem("Laptop", 1299.99m);
    cart.AddItem("Wireless Mouse", 29.99m, 2);
    cart.AddItem("Mechanical Keyboard", 89.99m);
    cart.DisplayCart();

    var total = cart.CalculateTotal();
    Console.WriteLine($"\n💰 Cart Total: ${total:F2}\n");

    var paymentMethods = new IPaymentStrategy[]
    {
        new CreditCardPayment("1234-5678-9012-3456", "John Doe"),
        new PayPalPayment("john.doe@paypal.com"),
        new BitcoinPayment("1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa"),
        new CashPayment()
    };

    foreach (var method in paymentMethods)
    {
        Console.WriteLine($"💳 Testing {method.Name}...");
        cart.SetPaymentStrategy(method);
        cart.Checkout();
        Console.WriteLine();
    }

    Console.WriteLine("✅ Strategy pattern allows switching payment methods easily!");
}

static void DemoRepository()
{
    Console.WriteLine("Testing Repository Pattern...\n");

    var repository = new CustomerRepository();

    Console.WriteLine($"📊 Total customers: {repository.Count}\n");

    Console.WriteLine("📋 All customers:");
    foreach (var customer in repository.GetAll())
    {
        Console.WriteLine($"   {customer}");
    }

    Console.WriteLine("\n🟢 Active customers:");
    foreach (var customer in repository.GetActiveCustomers())
    {
        Console.WriteLine($"   {customer}");
    }

    Console.WriteLine("\n🔍 Searching for 'John':");
    foreach (var customer in repository.SearchCustomers("John"))
    {
        Console.WriteLine($"   {customer}");
    }

    Console.WriteLine("\n📅 Recent customers (last 30 days):");
    foreach (var customer in repository.GetRecentCustomers(30))
    {
        Console.WriteLine($"   {customer}");
    }

    var newCustomer = new Customer
    {
        FirstName = "Sarah",
        LastName = "Wilson",
        Email = "sarah.wilson@email.com",
        Phone = "555-999-8888"
    };
    repository.Add(newCustomer);

    Console.WriteLine($"\n📊 Total customers after add: {repository.Count}");
    Console.WriteLine("\n✅ Repository pattern abstracts data access logic!");
}

static void DemoUnitOfWork()
{
    Console.WriteLine("Testing Unit of Work Pattern...\n");

    using var uow = new UnitOfWork();

    Console.WriteLine("📦 Available products:");
    foreach (var product in uow.Products.GetAll())
    {
        Console.WriteLine($"   {product}");
    }

    Console.WriteLine("\n📦 Products in stock:");
    foreach (var product in uow.Products.GetProductsInStock())
    {
        Console.WriteLine($"   {product}");
    }

    // Create a new order
    var order = new Order
    {
        CustomerId = 1,
        Status = "Pending",
        PaymentMethod = "Credit Card",
        ShippingAddress = "123 Main St, City, Country",
        Items =
        [
            new OrderItem
            {
                ProductId = 1,
                ProductName = "MacBook Pro 16",
                Quantity = 1,
                UnitPrice = 2499.99m
            },
            new OrderItem
            {
                ProductId = 3,
                ProductName = "Logitech MX Master 3S",
                Quantity = 2,
                UnitPrice = 99.99m
            },
            new OrderItem
            {
                ProductId = 6,
                ProductName = "USB-C 7-in-1 Hub",
                Quantity = 1,
                UnitPrice = 49.99m
            }
        ]
    };

    var total = order.Items.Sum(item => item.TotalPrice);
    order = order with { TotalAmount = total };

    Console.WriteLine($"\n📋 Creating order:");
    Console.WriteLine($"   Total: ${total:F2}");
    Console.WriteLine($"   Items: {order.Items.Count}");

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
            Console.WriteLine($"   📦 Updated stock for '{product.Name}': {product.StockQuantity} → {newStock}");
        }
    }

    Console.WriteLine("\n💾 Committing transaction...");
    uow.Complete();

    Console.WriteLine("\n📦 Updated products:");
    foreach (var product in uow.Products.GetAll())
    {
        Console.WriteLine($"   {product}");
    }

    Console.WriteLine("\n📋 All orders:");
    foreach (var ord in uow.Orders.GetAll())
    {
        Console.WriteLine($"   {ord}");
    }

    Console.WriteLine("\n📋 Orders by status 'Pending':");
    foreach (var ord in uow.Orders.GetOrdersByStatus("Pending"))
    {
        Console.WriteLine($"   {ord}");
    }

    Console.WriteLine("\n✅ Unit of Work pattern manages transactions and ensures consistency!");
}