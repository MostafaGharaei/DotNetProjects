using System;

namespace AfterISP
{
    /// <summary>
    /// Robot worker that implements only needed interfaces
    /// This follows ISP - doesn't implement methods it doesn't need
    /// </summary>
    public class RobotWorker : IWorkable, IMeetingAttendable
    {
        public void Work()
        {
            Console.WriteLine("Robot is working...");
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