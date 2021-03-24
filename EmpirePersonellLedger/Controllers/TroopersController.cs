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
        public ActionResult<List<Trooper>> GetTroopers()
        {
            try
            {
                var troopers = _empireDbContext.Troopers.Include(x => x.TrooperType).ToList();
                return Ok(troopers);
            }
            catch (Exception ex)
            {
                // logga att något har gått fel _logger.LogMessage("GetTroopers threw exception {ex.Message}")
                // return different message
                throw;
            }
        }

        [HttpGet("{trooperId:int}")]
        public ActionResult<Trooper> GetTrooper(int trooperId)
        {
            //var troopersInDb = _empireDbContext.Troopers;
            //var troopersInDbWithTrooperTypesIncluded = troopersInDb.Include(x => x.TrooperType);
            //var specificTrooper = troopersInDbWithTrooperTypesIncluded.FirstOrDefault(x => x.TrooperId == trooperId);

            var trooper = _empireDbContext
                .Troopers
                .Include(x => x.TrooperType)
                .FirstOrDefault(x => x.TrooperId == trooperId);

            if (trooper == null)
            {
                return NotFound($"Could not find trooper with id: {trooperId}");
            }

            return Ok(trooper);
        }

        [HttpPost]
        public ActionResult<int> AddTrooper([FromBody] AddTrooperRequest request)
        {
            var trooperTypeFromDb = _empireDbContext.TrooperTypes.Find(request.TrooperTypePrimaryKey);

            if (trooperTypeFromDb == null)
            {
                return BadRequest($"Could not find trooperType with key {request.TrooperTypePrimaryKey}");
            }

            var trooper = new Trooper
            {
                AcquisitionDate = request.AcquisitionDate,
                Nickname = request.Nickname,
                OperatingNumber = request.OperatingNumber,
                TrooperType = trooperTypeFromDb
            };

            _empireDbContext.Troopers.Add(trooper);
            _empireDbContext.SaveChanges();
            return Created("https://localhost:44326/troopers", trooper);
        }

        [HttpDelete("{trooperId:int}")]
        public ActionResult DeleteTrooper(int trooperId)
        {
            var trooperToBeDeleted = _empireDbContext.Troopers.Find(trooperId);
            if (trooperToBeDeleted == null)
            {
                return BadRequest($"Could not find trooper with id {trooperId}");
            }
            _empireDbContext.Troopers.Remove(trooperToBeDeleted);
            _empireDbContext.SaveChanges();
            return NoContent();
        }
    }
}
