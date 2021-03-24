using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private EmpireDbContext _empireDbContext;
        public TroopersController(EmpireDbContext empireDbContext)
        {
            _empireDbContext = empireDbContext;
        }

        [HttpGet]
        public List<Trooper> GetTroopers()
        {
            var troopers = _empireDbContext.Troopers.Include(x => x.TrooperType).ToList();
            return troopers;
        }

        [HttpPost]
        public void AddTrooper([FromBody] AddTrooperRequest request)
        {
            var trooperTypeFromDb = _empireDbContext.TrooperTypes.Find(request.TrooperTypePrimaryKey);

            var trooper = new Trooper
            {
                AcquisitionDate = request.AcquisitionDate,
                Nickname = request.Nickname,
                OperatingNumber = request.OperatingNumber,
                TrooperType = trooperTypeFromDb
            };

            _empireDbContext.Troopers.Add(trooper);
            _empireDbContext.SaveChanges();
        }
    }
}
