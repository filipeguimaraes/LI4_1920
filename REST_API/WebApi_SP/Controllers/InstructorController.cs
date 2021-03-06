﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using WebApi_SP.ViewObj;

namespace WebApi_SP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructorController : ControllerBase
    {

        [HttpGet]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> Get(string ssKey, string ssValue)
        {
            return Ok(new ModelController().Instance().getInstructorPage(ssKey,ssValue));
        }

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

        [HttpPost]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> Post(string ssKey, string ssValue, int classId, int numTicket, string priceTicket,
            string dateBegin, string dateEnd, string modality, int placeId)
        {
            return Ok(new ModelController().Instance().instructorUpdateClass(ssKey, ssValue, classId, numTicket,
                priceTicket, dateBegin, dateEnd, modality, placeId));
        }
    }
}
