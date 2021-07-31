using Services.RepositoryPattern.UserLogin;
using Services.RepositoryPattern.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Services.ViewModels;

namespace MainBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public ReservationController(IReservationService reservationService, IConfiguration configuration, IMediator MediatR)
        {
            _reservationService = reservationService;
            _configuration = configuration;
            _mediator = MediatR;
        }
        [Route("/GetListOfReservation")]
        [HttpGet]
        public async Task<IActionResult> GetListOfReservation()
        {
            //var quary = new Queries.GetAllUserQuery();
            //var result = await _mediator.Send(quary);
            return Ok(await _reservationService.GetListOfResevation());

        }
        [Route("/GetSingleReservation")]
        [HttpPost]
        public async Task<IActionResult> GetSingleReservation(ReservationModel _reservationModel)
        {
            //var quary = new Queries.GetAllUserQuery();
            //var result = await _mediator.Send(quary);
            return Ok(await _reservationService.GetsingleResevation(_reservationModel));

        }
        [Route("/AddNewReservation")]
        [HttpPost]
        public async Task<IActionResult> AddNewReservationv(ReservationModel _reservationModel)
        {
            string Message = await _reservationService.AddNewReservation(_reservationModel);
            return Ok(Message);

        }
        [Route("/UpdateExistingReservation")]
        [HttpPost]
        public async Task<IActionResult> UpdateExistingReservation(ReservationModel _reservationModel)
        {
            string Message = await _reservationService.UpdateExistingReservation(_reservationModel);
            return Ok(Message);

        }
        [Route("/DeleteExistingReservation")]
        [HttpPost]
        public async Task<IActionResult> DeleteExistingReservation(ReservationModel _reservationModel)
        {
            //var quary = new Queries.GetAllUserQuery();
            //var result = await _mediator.Send(quary);
           string Message =  await _reservationService.UpdateExistingReservation(_reservationModel);
            return Ok(Message);

        }
    }
}
