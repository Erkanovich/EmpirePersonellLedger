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
        public List<TrooperType> GetTrooperTypes()
        {
            var trooperTypes = _empireDbContext.TrooperTypes.ToList();
            return trooperTypes;
        }

        [HttpPost]
        public void AddTrooperType([FromBody]TrooperType trooperType)
        {
            _empireDbContext.TrooperTypes.Add(trooperType);
            _empireDbContext.SaveChanges();
        }
    }
}
