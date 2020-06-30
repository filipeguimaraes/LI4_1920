using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_SP.ViewObj;
using Microsoft.AspNetCore.Cors;

namespace WebApi_SP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        [HttpGet]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> GetPlaces(string ssKey, string ssValue)
        {
            return Ok(new ModelController().Instance().getPlacesPage(ssKey, ssValue));
        }

        [HttpPut]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> RentSpace(string ssKey, string ssValue)
        {
            return Ok(new ModelController().Instance().RentSpace(ssKey, ssValue));
        }

        [HttpDelete]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> refundRentSpace(string ssKey, string ssValue)
        {
            return Ok(new ModelController().Instance().refundRentSpace(ssKey, ssValue));
        }
    }
}