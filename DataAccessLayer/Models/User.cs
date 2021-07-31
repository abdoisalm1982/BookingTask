using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
   public class User : BaseModel
    {
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }
      
     
    }
}
