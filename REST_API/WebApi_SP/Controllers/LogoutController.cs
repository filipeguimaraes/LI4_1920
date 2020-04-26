using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using WebApi_SP.ViewObj;

namespace WebApi_SP.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("[Controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {

        [HttpGet]
        public ActionResult<AuthenticationObj<Object>> Get(string ssKey, string ssValue)
        {
            return Ok(new ModelController().Instance().Logout(ssKey, ssValue));
        }
    }
}