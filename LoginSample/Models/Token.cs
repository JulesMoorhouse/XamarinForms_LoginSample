using System;
namespace LoginSample.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ExpireDate { get; set; }

        public Token()
        {
        }
    }
}
