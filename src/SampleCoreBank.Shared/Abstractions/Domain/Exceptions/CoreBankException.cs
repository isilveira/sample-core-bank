namespace SampleCoreBank.Shared.Abstractions.Domain.Exceptions
{
    public class CoreBankException : Exception
    {
        public int ExceptionCode { get; set; }
        public int ExceptionInternalCode { get; set; }
        public CoreBankException(int exceptionCode, int exceptionInternalCode)
        {
            ExceptionCode = exceptionCode;
            ExceptionInternalCode = exceptionInternalCode;
        }
        public CoreBankException(int exceptionCode, int exceptionInternalCode, string message) : base(message)
        {
            ExceptionCode = exceptionCode;
            ExceptionInternalCode = exceptionInternalCode;
        }
        public CoreBankException(int exceptionCode, int exceptionInternalCode, string message, Exception innerException) : base(message, innerException)
        {
            ExceptionCode = exceptionCode;
            ExceptionInternalCode = exceptionInternalCode;
        }
    }
}