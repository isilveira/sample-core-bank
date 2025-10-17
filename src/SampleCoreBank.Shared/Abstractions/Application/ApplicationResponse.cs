namespace SampleCoreBank.Shared.Abstractions.Application
{
    public class ApplicationResponse
    {
        public int StatusCode { get; set; }
        public int InternalCode { get; set; }
        public long ResultCount { get; set; }
        public string Message { get; set; }
        public object Request { get; set; }
        public object Data { get; set; }
        public Dictionary<string, object> Notifications { get; set; }
        public ApplicationResponse() { }
        public ApplicationResponse(
            int statusCode,
            int internalCode,
            object request,
            object data,
            Dictionary<string, object> notifications = null,
            string message = "Operação realizada com sucesso!",
            long? resultCount = null
        )
        {
            StatusCode = statusCode;
            InternalCode = internalCode;
            Message = message;
            ResultCount = resultCount.HasValue ? resultCount.Value : data is ICollection<object> ? ((ICollection<object>)data).Count : data is null ? 0 : 1;
            Request = request;
            Data = data;
            Notifications = notifications;
        }
    }
}