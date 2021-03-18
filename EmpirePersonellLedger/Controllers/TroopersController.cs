using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpirePersonellLedger.Controllers
{
    [ApiController]
    [Route("troopers")]
    public class TroopersController : ControllerBase
    {
        [HttpGet]
        public string HelloWorld()
        {
            return "Hello world";
        }

        [HttpGet]
        [Route("bye")]
        public string ByeBye()
        {
            return "Bye bye world";
        }
    }
}
