using EmpirePersonellLedger.Models;
using EmpirePersonellLedger.RequestsAndResponses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpirePersonellLedger.Controllers
{
    [ApiController]
    [Route("troopertypes")]
    public class TrooperTypesController : ControllerBase
    {
        private EmpireDbContext _empireDbContext;
        public TrooperTypesController(EmpireDbContext empireDbContext)
        {
            _empireDbContext = empireDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrooperTypeResponse>> GetTrooperTypes()
        {
            // gets all the troopers from the database and puts it in a List.
            var trooperTypesFromDb = _empireDbContext.TrooperTypes.ToList();
            // creates a new List with TrooperTypeResponses
            var trooperTypeResponses = new List<TrooperTypeResponse>();
            // Iterates through the "trooperTypesFromDb" List
            foreach (var trooperType in trooperTypesFromDb)
            {
                // Creates a new TrooperTypeResponse and sets its properties to match "trooperType"
                var trooperTypeResponse = new TrooperTypeResponse
                {
                    Speciality = trooperType.Speciality,
                    TypeName = trooperType.TypeName,
                    Weapon = trooperType.Weapon
                };
                // Adds the newly created TrooperTypeResponse to the TrooperTypeResponses List
                trooperTypeResponses.Add(trooperTypeResponse);
            }
            //returns the list
            return trooperTypeResponses;

            //return Ok(_empireDbContext.TrooperTypes.Select(x => new TrooperTypeResponse
            //{
            //    Speciality = x.Speciality,
            //    TypeName = x.TypeName,
            //    Weapon = x.Weapon
            //}));
        }

        [HttpPost]
        public ActionResult<TrooperTypeResponse> AddTrooperType([FromBody]AddTrooperTypeRequest trooperTypeRequest)
        {
            // Creates a new TrooperType and sets its properties to match the request
            var trooperType = new TrooperType
            {
                Speciality = trooperTypeRequest.Speciality,
                TypeName = trooperTypeRequest.TypeName,
                Weapon = trooperTypeRequest.Weapon,
                CreatedAt = DateTime.Now
            };
            // Adds the trooperType to the database
            _empireDbContext.TrooperTypes.Add(trooperType);
            // COMMIT in sql
            _empireDbContext.SaveChanges();
            // Creates a new object of type TrooperTypeResponse
            // and sets its properties to match the trooperType in the database
            var response = new TrooperTypeResponse
            {
                Speciality = trooperType.Speciality,
                TypeName = trooperType.TypeName,
                Weapon = trooperType.Weapon
            };
            //Returns HttpStatusCode 200 with the response in the Body
            return Ok(response);
        }
    }
}
