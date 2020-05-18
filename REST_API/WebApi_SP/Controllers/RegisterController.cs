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
    public class RegisterController : ControllerBase
    {
        [HttpGet]
        public ActionResult<AuthenticationObj<Object>> Get(string email, string password)
        {
            return Ok(new ModelController().Instance().Register(email, password));
        }
    }
}