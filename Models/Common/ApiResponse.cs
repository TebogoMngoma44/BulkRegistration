namespace Speccon.Learnership.FrontEnd.Models.Common
{
    public class ApiResponse
    {
        public Guid key { get; set; }
        public int status { get; set; }
        public string message { get; set; } = string.Empty;
    }

    public class SignUpResponse
    {
        public Guid PreUserKey { get; set; }
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class GetUser
    {
        public string Email { get; set; } = string.Empty;
    }

    public class PdfReturnDto
    {
        public string fileName { get; set; } = string.Empty;
        public byte[]? byteReturn { get; set; }
    }

    public class PdfResponseWrapper
    {
        public PdfReturnDto Result { get; set; } = new PdfReturnDto();
    }

    public class ResponseData
    {
        public string Message { get; set; } = "";
        public string? FilePath { get; set; }
    }

    public class PaymentResponse
    {
        public int clientId { get; set; }
    }
}
