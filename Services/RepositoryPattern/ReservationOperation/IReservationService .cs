using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  Services.ViewModels;

namespace Services.RepositoryPattern.Reservation
{
    public interface IReservationService
    {
        Task<List<ReservationModel>> GetListOfResevation();
        Task<ReservationModel> GetsingleResevation(ReservationModel _Reservation);
        Task<string> AddNewReservation(ReservationModel _Reservation);
        Task<string> UpdateExistingReservation(ReservationModel _Reservation);
        Task<string> DeleteExistingReservation(ReservationModel _Reservation);
        
    } 
}
