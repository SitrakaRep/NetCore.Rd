using NetCore.Rd.Business.Services.Interfaces;
using NetCore.Rd.Core.Generic;
using NetCore.Rd.Data.Context;
using NetCore.Rd.Data.Entities;

namespace NetCore.Rd.Business.Services.Implementation
{
    public class OwnerService : GenericService<Owner, ApplicationContext, IOwnerService>, IOwnerService
    {
        private readonly ApplicationContext context;
        public OwnerService(ApplicationContext context) : base(context)
        {
            this.context = context;
        }
    }
}