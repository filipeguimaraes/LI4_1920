﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Threading;
using WebApi_SP.ViewObj;

namespace WebApi_SP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        [EnableCors("MyPolicy")]
        public ActionResult<string> Get(string ssKey, string ssValue)
        {
            Thread.Sleep(500);
            return Ok(new ModelController().Instance().Authentication(ssKey,ssValue));
        }
    }
}