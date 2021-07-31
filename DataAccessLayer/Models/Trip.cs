using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
   public class Trip : BaseModel
    {
        [JsonProperty(PropertyName = "TripId")]
        public int TripId { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "CityName")]
        public string CityName { get; set; }
        [JsonProperty(PropertyName = "ImageUrl")]
        public string ImageUrl { get; set; }

    }
}
