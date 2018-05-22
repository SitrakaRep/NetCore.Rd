using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCore.Rd.Business.Services.Interfaces;
using NetCore.Rd.Data.Dto;
using NetCore.Rd.Data.Entities;

namespace NetCore.Rd.Web.Controllers.API
{
    public class ApartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApartmentService _apartmentservice;
        public ApartmentController(IMapper mapper, IApartmentService apartmentservice)
        {
            this._apartmentservice = apartmentservice;
            this._mapper = mapper;
        }

        [Route("~/apartments")]
        public async Task<IActionResult> GetAllApartments()
        {
            var query = await _apartmentservice.GetAllApartments();

            List<Apartment> apartmentList = new List<Apartment>();

            foreach (var item in query)
            {
                apartmentList.Add(item);
            }

            // return Ok(apartmentList);

            return Ok(_mapper.Map<List<Apartment>, List<ApartmentDto>>(apartmentList));
        }
    }
}