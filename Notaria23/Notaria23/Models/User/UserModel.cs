using System;
using Newtonsoft.Json;
using Notaria23.ViewModels.Base;
using SQLite;

namespace Notaria23.Models.User
{
    
    public class UserModel : BindableNotify
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("User")]
        public string User { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [PrimaryKey,JsonProperty("UserId")]
        public Guid UserId { get; set; }

        [JsonProperty("IsEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("UserType")]
        public int UserType { get; set; }

        [JsonProperty("Status")]
        public bool Status { get; set; }

        [JsonProperty("DateModified")]
        public DateTime DateModified { get; set; }

        [JsonProperty("DateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("ImageByte")]
        public byte[] ImageByte { get; set; }
    }
}
