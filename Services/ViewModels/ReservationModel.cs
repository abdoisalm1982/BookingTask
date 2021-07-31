using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.ViewModels
{
    public class ReservationModel
    {
        [JsonProperty(PropertyName = "ReservedId")]
        [Required]
        public int ReservedId { get; set; }
        [JsonProperty(PropertyName = "ReservedBy")]
        [Required]
        public string ReservedBy { get; set; }
        [JsonProperty(PropertyName = "CustomerName")]
        [Required]
        public string CustomerName { get; set; }
        [JsonProperty(PropertyName = "TripId")]
        [Required]
        public int TripId { get; set; }
        [JsonProperty(PropertyName = "ReservationDate")]
        [Required]
        public DateTime ReservationDate { get; set; }
        [JsonProperty(PropertyName = "Notes")]
        [Required]
        public string Notes { get; set; }
        public string TripName { get; set; }






    }
}
