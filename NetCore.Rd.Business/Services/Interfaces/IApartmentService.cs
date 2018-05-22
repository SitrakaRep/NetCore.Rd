using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Rd.Core.Generic;
using NetCore.Rd.Data.Entities;

namespace NetCore.Rd.Business.Services.Interfaces
{
    public interface IApartmentService : IGenericService<Apartment>
    {
         Task<List<Apartment>> GetAllApartments();
    }
}