using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
   public class BaseModel
    {
       
        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty(PropertyName = "ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
