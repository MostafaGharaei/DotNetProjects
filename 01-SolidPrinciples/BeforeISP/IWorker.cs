using System;

namespace BeforeISP
{
    /// <summary>
    /// Interface that violates ISP by having too many methods
    /// Not all workers need all methods
    /// </summary>
    public interface IWorker
    {
        void Work();
        void Eat();
        void Sleep();
        void TakeBreak();
        void AttendMeeting();
        void SubmitReport();
    }

    /// <summary>
    /// Human worker that needs all methods
    /// </summary>
    public class HumanWorker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Human is working...");
        }

        public void Eat()
        {
            Console.WriteLine("Human is eating...");
        }

        public void Sleep()
        {
            Console.WriteLine("Human is sleeping...");
        }

        public void TakeBreak()
        {
            Console.WriteLine("Human is taking a break...");
        }

        public void AttendMeeting()
        {
            Console.WriteLine("Human is attending meeting...");
        }

        public void SubmitReport()
        {
            Console.WriteLine("Human is submitting report...");
        }
    }

    /// <summary>
    /// Robot worker that doesn't need all methods
    /// This violates ISP - robot has to implement methods it doesn't need
    /// </summary>
    public class RobotWorker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Robot is working...");
        }

        public void Eat()
        {
            throw new NotImplementedException("Robot doesn't eat!");
        }

        public void Sleep()
        {
            throw new NotImplementedException("Robot doesn't sleep!");
        }

        public void TakeBreak()
        {
            throw new NotImplementedException("Robot doesn't take breaks!");
        }

        public void AttendMeeting()
        {
            Console.WriteLine("Robot is attending meeting...");
        }

        public void SubmitReport()
        {
            Console.WriteLine("Robot is submitting report...");
        }
    }
}