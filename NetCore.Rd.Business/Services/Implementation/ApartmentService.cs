using NetCore.Rd.Core.Generic;
using NetCore.Rd.Data.Context;
using NetCore.Rd.Data.Entities;
using NetCore.Rd.Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NetCore.Rd.Business.Services.Implementation
{
    public class ApartmentService : GenericService<Apartment, ApplicationContext, IApartmentService>, IApartmentService
    {
        private readonly ApplicationContext context;
        public ApartmentService(ApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Apartment>> GetAllApartments()
        {
            var query = await context.Apartments.Include(o => o.Owner).ToListAsync();

            return query;
        }
    }
}