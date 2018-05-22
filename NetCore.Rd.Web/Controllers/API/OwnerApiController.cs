using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCore.Rd.Business.Services.Interfaces;
using NetCore.Rd.Data.Dto;
using NetCore.Rd.Data.Entities;

namespace NetCore.Rd.Web.Controllers.API
{
    public class OwnerApiController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOwnerService _ownerservice;
        public OwnerApiController(IMapper mapper, IOwnerService ownerservice)
        {
            this._ownerservice = ownerservice;
            this._mapper = mapper;
        }

        [Route("~/owners")]
        public async Task<IActionResult> GetAllOwners()
        {
            var query = await _ownerservice.GetAllAsyn();

            List<Owner> ownerList = new List<Owner>();

            foreach (var item in query)
            {
                ownerList.Add(item);
            }

            return Ok(_mapper.Map<List<Owner>, List<OwnerDto>>(ownerList));
        }
    }
}