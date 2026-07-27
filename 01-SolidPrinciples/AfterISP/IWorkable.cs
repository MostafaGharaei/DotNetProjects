namespace AfterISP
{
    /// <summary>
    /// Interface for work-related activities
    /// This follows ISP - only includes work methods
    /// </summary>
    public interface IWorkable
    {
        void Work();
        void SubmitReport();
    }
}