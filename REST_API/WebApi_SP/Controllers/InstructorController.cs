using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using ViewObj;

namespace WebApi_SP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructorController : ControllerBase
    {

        [HttpGet]
        [EnableCors("MyPolicy")]
        public ActionResult<InstructorPage> Get(bool log)
        {
            InstructorPage a = new InstructorPage();
            a.log = log;
            return Ok(a);
        }
    }
}
