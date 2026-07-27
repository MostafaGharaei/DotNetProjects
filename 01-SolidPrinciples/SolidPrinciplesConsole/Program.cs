using System;
using BeforeSRP;
using AfterSRP;
using BeforeOCP;
using AfterOCP;
using BeforeLSP;
using AfterLSP;
using BeforeISP;
using AfterISP;
using BeforeDIP;
using AfterDIP;

namespace SolidPrinciplesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("    SOLID PRINCIPLES DEMO - COMPLETE SET");
            Console.WriteLine("==================================================\n");

            // SRP Demo
            Console.WriteLine("=== 1. SINGLE RESPONSIBILITY PRINCIPLE (SRP) ===\n");
            DemoSRP();

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            // OCP Demo
            Console.WriteLine("=== 2. OPEN/CLOSED PRINCIPLE (OCP) ===\n");
            DemoOCP();

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            // LSP Demo
            Console.WriteLine("=== 3. LISKOV SUBSTITUTION PRINCIPLE (LSP) ===\n");
            DemoLSP();

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            // ISP Demo
            Console.WriteLine("=== 4. INTERFACE SEGREGATION PRINCIPLE (ISP) ===\n");
            DemoISP();

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            // DIP Demo
            Console.WriteLine("=== 5. DEPENDENCY INVERSION PRINCIPLE (DIP) ===\n");
            DemoDIP();

            Console.WriteLine("\n" + new string('=', 50) + "\n");
            Console.WriteLine("All SOLID principles demonstrated successfully!");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DemoSRP()
        {
            Console.WriteLine("BEFORE SRP (Violation):");
            var beforeEmployee = new BeforeSRP.Employee(1, "John Doe", "john.doe@company.com", 5000m);
            beforeEmployee.SaveToDatabase();
            beforeEmployee.SendWelcomeEmail();

            Console.WriteLine("\nAFTER SRP (Correct):");
            var afterEmployee = new AfterSRP.Employee(2, "Jane Smith", "jane.smith@company.com", 6000m);
            var repository = new AfterSRP.EmployeeRepository();
            var emailService = new AfterSRP.EmailService();
            var calculator = new AfterSRP.SalaryCalculator();
            var reportGenerator = new AfterSRP.ReportGenerator(calculator);

            repository.Save(afterEmployee);
            emailService.SendWelcomeEmail(afterEmployee);
            Console.WriteLine($"Annual Salary: {calculator.CalculateAnnualSalary(afterEmployee):C}");
            Console.WriteLine(reportGenerator.GenerateEmployeeReport(afterEmployee));
        }

        static void DemoOCP()
        {
            Console.WriteLine("BEFORE OCP (Violation):");
            var circle = new BeforeOCP.Shape { Type = BeforeOCP.ShapeType.Circle, Radius = 5 };
            var rectangle = new BeforeOCP.Shape { Type = BeforeOCP.ShapeType.Rectangle, Width = 4, Height = 6 };
            var square = new BeforeOCP.Shape { Type = BeforeOCP.ShapeType.Square, Side = 3 };

            Console.WriteLine($"Circle area: {circle.CalculateArea():F2}");
            Console.WriteLine($"Rectangle area: {rectangle.CalculateArea():F2}");
            Console.WriteLine($"Square area: {square.CalculateArea():F2}");
            Console.WriteLine("Adding new shape would require modifying Shape class!");

            Console.WriteLine("\nAFTER OCP (Correct):");
            var afterCircle = new AfterOCP.Circle(5);
            var afterRectangle = new AfterOCP.Rectangle(4, 6);
            var afterSquare = new AfterOCP.Square(3);
            var areaCalculator = new AfterOCP.AreaCalculator();

            var shapes = new AfterOCP.IShape[] { afterCircle, afterRectangle, afterSquare };
            Console.WriteLine($"Circle area: {afterCircle.CalculateArea():F2}");
            Console.WriteLine($"Rectangle area: {afterRectangle.CalculateArea():F2}");
            Console.WriteLine($"Square area: {afterSquare.CalculateArea():F2}");
            Console.WriteLine($"Total area: {areaCalculator.CalculateTotalArea(shapes):F2}");
            Console.WriteLine("Adding new shape only requires implementing IShape!");
        }

        static void DemoLSP()
        {
            Console.WriteLine("BEFORE LSP (Violation):");
            var rectangle = new BeforeLSP.Rectangle { Width = 5, Height = 4 };
            var square = new BeforeLSP.Square { Width = 5 };

            Console.WriteLine($"Rectangle area: {rectangle.CalculateArea()}");
            Console.WriteLine($"Square area: {square.CalculateArea()}");
            Console.WriteLine("But square as rectangle behaves incorrectly:");

            // This should work for Rectangle but fails for Square
            void TestRectangle(BeforeLSP.Rectangle rect)
            {
                rect.Width = 10;
                Console.WriteLine($"Width=10, Height={rect.Height}, Area={rect.CalculateArea()}");
            }

            Console.Write("Testing with Rectangle: ");
            TestRectangle(rectangle);
            Console.Write("Testing with Square: ");
            TestRectangle(square); // Violates LSP!

            Console.WriteLine("\nAFTER LSP (Correct):");
            var afterRect = new AfterLSP.Rectangle(5, 4);
            var afterSquare = new AfterLSP.Square(5);

            Console.WriteLine($"Rectangle area: {afterRect.CalculateArea()}");
            Console.WriteLine($"Square area: {afterSquare.CalculateArea()}");
            Console.WriteLine("Both implement IShape correctly and can be substituted!");
        }

        static void DemoISP()
        {
            Console.WriteLine("BEFORE ISP (Violation):");
            var human = new BeforeISP.HumanWorker();
            var robot = new BeforeISP.RobotWorker();

            Console.WriteLine("Human worker:");
            human.Work();
            human.Eat();
            human.Sleep();

            Console.WriteLine("\nRobot worker:");
            robot.Work();
            try
            {
                robot.Eat(); // Throws exception!
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Robot.Eat() throws exception - violates ISP!");
            }

            Console.WriteLine("\nAFTER ISP (Correct):");
            var afterHuman = new AfterISP.HumanWorker();
            var afterRobot = new AfterISP.RobotWorker();

            Console.WriteLine("Human worker:");
            afterHuman.Work();
            afterHuman.Eat();
            afterHuman.Sleep();

            Console.WriteLine("\nRobot worker:");
            afterRobot.Work();
            afterRobot.AttendMeeting();
            Console.WriteLine("Robot only implements interfaces it needs - follows ISP!");
        }

        static void DemoDIP()
        {
            Console.WriteLine("BEFORE DIP (Violation):");
            var notificationService = new BeforeDIP.NotificationService();
            notificationService.SendNotification("john@email.com", "Hello!", "Email");
            notificationService.SendNotification("+123456789", "Hello!", "SMS");
            Console.WriteLine("NotificationService depends on concrete classes!");

            Console.WriteLine("\nAFTER DIP (Correct):");
            // Using Email
            var emailService = new AfterDIP.EmailService();
            var notificationManager1 = new AfterDIP.NotificationManager(emailService);
            notificationManager1.SendNotification("john@email.com", "Hello via Email!");

            // Using SMS
            var smsService = new AfterDIP.SMSService();
            var notificationManager2 = new AfterDIP.NotificationManager(smsService);
            notificationManager2.SendNotification("+123456789", "Hello via SMS!");

            // Using Push Notification
            var pushService = new AfterDIP.PushNotificationService();
            var notificationManager3 = new AfterDIP.NotificationManager(pushService);
            notificationManager3.SendNotification("device123", "Hello via Push!");

            Console.WriteLine("NotificationManager depends on abstraction - follows DIP!");
        }
    }
}