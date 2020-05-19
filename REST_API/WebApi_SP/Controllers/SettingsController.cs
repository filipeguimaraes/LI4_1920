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
    [Route("Settings")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Object> Settings(string ssKey, string ssValue, 
            string emailSett, string passSett, string nameSett, string genderSett,
            string addrSett, string contactSett, string daySett, string monthSett,
            string yearSett, string heightSett, string weightSett)
        {

            return Ok(new ModelController().Instance()
                .ChangeSettings(ssKey, ssValue, emailSett, passSett, nameSett, genderSett,
                addrSett, contactSett, daySett, monthSett, yearSett, heightSett, weightSett)
                );
        }
    }
}