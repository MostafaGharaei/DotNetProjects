using System;

namespace AfterISP
{
    /// <summary>
    /// Human worker that implements all necessary interfaces
    /// This follows ISP - only implements interfaces it needs
    /// </summary>
    public class HumanWorker : IWorkable, IEatable, ISleepable, IMeetingAttendable
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
}