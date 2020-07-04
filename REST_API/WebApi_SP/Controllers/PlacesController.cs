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

        [HttpPost]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> GetOccupiedDates(string ssKey, string ssValue, int placeId, string date)
        {
            return Ok(new ModelController().Instance().ListOfOccupiedDates(ssKey, ssValue, placeId, date));
        }

        [HttpPut]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> RentSpace(string ssKey, string ssValue, int placeId, string dateBegin, string dateEnd)
        {
            return Ok(new ModelController().Instance().RentSpace(ssKey, ssValue, placeId, dateBegin, dateEnd));
        }

        [HttpDelete]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> refundRentSpace(string ssKey, string ssValue, int placeId, string dateBegin, string dateEnd)
        {
            return Ok(new ModelController().Instance().refundRentSpace(ssKey, ssValue, placeId, dateBegin, dateEnd));
        }
    }
}