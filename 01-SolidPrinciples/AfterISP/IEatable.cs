namespace AfterISP
{
    /// <summary>
    /// Interface for eating activities
    /// This follows ISP - only includes eating methods
    /// </summary>
    public interface IEatable
    {
        void Eat();
        void TakeBreak();
    }
}