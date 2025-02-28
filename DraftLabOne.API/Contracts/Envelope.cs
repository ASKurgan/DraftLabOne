using DraftLabOne.Domain.Common;

namespace DraftLabOne.API.Contracts
{
    public class Envelope
    {
        public Envelope(object? result, IEnumerable<ErrorInfo>? errors)
        {
            Result = result;
            ErrorInfo = errors?.ToList();
            TimeGenerated = DateTime.UtcNow;
        }

        public object? Result { get;}
        public List<ErrorInfo>? ErrorInfo { get;}
        public DateTime TimeGenerated { get; set; }

        public static Envelope Ok(object? result = null)
        {
            return new(result,null);
        }

        public static Envelope Error(params ErrorInfo[] errors)
        {
            return new(null,errors);
        }
    }

    public class ErrorInfo
    {
        public ErrorInfo(Error? error, string? invalidField = null)
        {
            ErrorCode = error?.Code;
            ErrorMessage = error?.Message;
            InvalidField = invalidField;
        }

        public string? ErrorCode { get;}
        public string? ErrorMessage  { get;}
        public string? InvalidField { get;}


    }
}
