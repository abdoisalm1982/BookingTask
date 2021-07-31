using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
   public class Reservation : BaseModel
    {
        [JsonProperty(PropertyName = "ReservedId")]
        public int ReservedId { get; set; }
        [JsonProperty(PropertyName = "ReservedBy")]
        public string ReservedBy { get; set; }
        [JsonProperty(PropertyName = "CustomerName")]
        public string CustomerName { get; set; }
        [JsonProperty(PropertyName = "TripId")]
        public int TripId { get; set; }
        [JsonProperty(PropertyName = "ReservationDate")]
        public DateTime ReservationDate { get; set; }
        [JsonProperty(PropertyName = "Notes")]
        public string Notes { get; set; }

    }
}
