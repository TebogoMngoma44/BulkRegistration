namespace Speccon.Learnership.FrontEnd.Models.Common
{
    public static class Constants
    {
        public static int ActiveRecordStatusId { get; set; } = 1;
        public static int InactiveRecordStatusId { get; set; } = 2;

        public const string AuthTokenKey = "authToken";
        public const string BearerKey = "Bearer";
        public const string CreateMessage = "Create failed, please try again!";
        public const string DeleteMessage = "Delete failed, please try again!";
        public const string NotValidOtp = "This is not a valid OTP!";
    }
}
