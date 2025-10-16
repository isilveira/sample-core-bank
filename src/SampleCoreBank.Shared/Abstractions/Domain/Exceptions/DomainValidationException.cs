namespace SampleCoreBank.Shared.Abstractions.Domain.Exceptions
{
    public class DomainValidationException : CoreBankException
    {
        public DomainValidationException() : base(400, 4003000)
        {
        }
        public DomainValidationException(string message) : base(400, 4003000, message)
        {
        }
        public DomainValidationException(string message, Exception innerException) : base(400, 4003000, message, innerException)
        {
        }
        public DomainValidationException(int exceptionCode, int exceptionInternalCode) : base(exceptionCode, exceptionInternalCode)
        {
        }
        public DomainValidationException(int exceptionCode, int exceptionInternalCode, string message) : base(exceptionCode, exceptionInternalCode, message)
        {
        }
        public DomainValidationException(int exceptionCode, int exceptionInternalCode, string message, Exception innerException) : base(exceptionCode, exceptionInternalCode, message, innerException)
        {
        }
    }
}