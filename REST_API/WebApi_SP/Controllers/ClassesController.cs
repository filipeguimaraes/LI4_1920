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
    public class ClassesController : ControllerBase
    {
        [HttpPut]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> Put(string ssKey, string ssValue, int numTicket, float priceTicket, 
            string dateBegin, string dateEnd, string modality, string instructorEmail, int placeId)
        {
            return Ok(new ModelController().Instance().instructorAddClass(ssKey, ssValue, numTicket, priceTicket, 
                dateBegin, dateEnd, modality, instructorEmail, placeId));
        }

        [HttpDelete]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> Delete(string ssKey, string ssValue, int classId)
        {
            return Ok(new ModelController().Instance().instructorDeleteClass(ssKey, ssValue, classId));
        }
    }
}