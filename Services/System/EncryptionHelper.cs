using System.Text;

namespace Speccon.Learnership.FrontEnd.Services.System
{
    public class EncryptionHelper
    {
        protected EncryptionHelper()
        {
        }

        public static async Task<string> Encode(string value)
        {
            return await Task.Run(() =>
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            });
        }

        public static async Task<string> Decode(string encodedValue)
        {
            return await Task.Run(() =>
            {
                byte[] data = Convert.FromBase64String(encodedValue);
                return Encoding.UTF8.GetString(data);
            });
        }
    }
}
