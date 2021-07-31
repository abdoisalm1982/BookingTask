using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using  Services.ViewModels;

namespace MainBookingAPI.Queries
{
    public class GetAllUserQuery: IRequest<List<LoginModel>>
        {
    }
}
