using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.ViewModels
{

    public class LoginModel
    {

        [JsonProperty(PropertyName = "email")]
        [Required]
        public string UserEmail { get; set; }

        [JsonProperty(PropertyName = "password")]
        [Required]
        public string UserPassword { get; set; }





    }

   
}
