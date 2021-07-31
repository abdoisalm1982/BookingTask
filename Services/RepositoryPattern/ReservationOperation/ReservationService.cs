using DataAccessLayer.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Services.ViewModels;

namespace Services.RepositoryPattern.Reservation
{
    public class ReservationService : IReservationService
    {
        private readonly BookingDbContext _BookingDbContext;
        private readonly IMapper _mapper;
   
        public ReservationService(BookingDbContext BookingDbContext, IMapper mapper)
        {
            _BookingDbContext = BookingDbContext;
            _mapper = mapper;
            
        }
 
        public async Task<List<ReservationModel>> GetListOfResevation()
        {
            try
            {
      

             List<ReservationModel> ReservationResult  = await (from m1 in _BookingDbContext.Reservations
                           join m2 in _BookingDbContext.Trips
                            on new { m1.TripId }
                            equals new { m2.TripId }
                       
                           select new ReservationModel
                           {
                               ReservedId = m1.ReservedId,
                               ReservationDate = m1.ReservationDate,
                               ReservedBy = m1.ReservedBy,
                               Notes = m1.Notes,
                               TripId = m1.TripId,
                               TripName =m2.Name
                           }).ToListAsync();



                return ReservationResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ReservationModel> GetsingleResevation(ReservationModel _Reservation)
        {
            try
            {
                var singleResevationResult = await _BookingDbContext.Reservations.Where(c => c.ReservedId.Equals(_Reservation.ReservedId)).FirstOrDefaultAsync();
              
               
                    return _mapper.Map<ReservationModel>(singleResevationResult);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> AddNewReservation(ReservationModel _Reservation)
        {
            try
            {
                var ReservationExists = await _BookingDbContext.Reservations.Where(c => c.ReservedId.Equals(_Reservation.ReservedId)).AnyAsync();
                if (ReservationExists is false)
                {
                    DataAccessLayer.Models.Reservation res = new DataAccessLayer.Models.Reservation
                    {
                        ReservedBy = _Reservation.ReservedBy,
                        ReservationDate = _Reservation.ReservationDate,
                        CustomerName = _Reservation.CustomerName,
                        TripId = _Reservation.TripId,
                        Notes = _Reservation.Notes
                      
                   
                    };
                    await _BookingDbContext.Reservations.AddAsync(res);
                    await _BookingDbContext.SaveChangesAsync();
                    return " Add Success";
                }
                else return "Reservation already exists";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> UpdateExistingReservation(ReservationModel _Reservation)
        {
            try
            {
                DataAccessLayer.Models.Reservation ReservationExists =  _BookingDbContext.Reservations.First(c => c.ReservedId.Equals(_Reservation.ReservedId));
                if (ReservationExists != null)
                {
                    ReservationExists.ReservedBy = _Reservation.ReservedBy;
                    ReservationExists.ReservationDate = _Reservation.ReservationDate;
                    ReservationExists.CustomerName = _Reservation.CustomerName;
                    ReservationExists.TripId = _Reservation.TripId;
                    ReservationExists.Notes = _Reservation.Notes;
                    await _BookingDbContext.SaveChangesAsync();
                    return " Delete Success";

                }
                else
                {
                    return " Not Found Reservation";
                }
                   

            
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> DeleteExistingReservation(ReservationModel _Reservation)
        {
            try
            {
                DataAccessLayer.Models.Reservation ReservationExists = _BookingDbContext.Reservations.First(c => c.ReservedId.Equals(_Reservation.ReservedId));
                if (ReservationExists != null)

                {
                    _BookingDbContext.Reservations.Remove(ReservationExists);
                    await _BookingDbContext.SaveChangesAsync();
                    return " Reservation Deleted";
                }
                else {
                    return " Not Found Reservation";
                }
           



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
