using System;
namespace Notaria23Api.ViewModels
{
    public class TokenRequest
    {
        public string Token { get; set; }
        public int Expired { get; set; }
        public DateTime Date { get; set; }
    }
}
