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

        [HttpGet]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> GetClasses(string ssKey, string ssValue)
        {
            return Ok(new ModelController().Instance().getClassesPage(ssKey, ssValue));
        }

        [HttpPut]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> UserBuyClass(string ssKey, string ssValue, int classId)
        {
            return Ok(new ModelController().Instance().buyClasse(ssKey, ssValue, classId));
        }

        [HttpDelete]
        [EnableCors("MyPolicy")]
        public ActionResult<Object> refundTicketClass(string ssKey, string ssValue, int classId)
        {
            return Ok(new ModelController().Instance().refundTicketClasse(ssKey, ssValue, classId));
        }
    }
}