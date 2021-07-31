using BookingUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Services.ViewModels;

namespace BookingUI.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base url
        string Baseurl = "https://localhost:44345";
        public async Task<ActionResult> Index()
        {
            List<ReservationModel> ReservationList = new List<ReservationModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("/GetListOfReservation");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ReservationResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ReservationList = JsonConvert.DeserializeObject<List<ReservationModel>>(ReservationResponse);
                }
                //returning the employee list to view
                return View(ReservationList);
            }
        }
    }
}

