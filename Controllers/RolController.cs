using Microsoft.AspNetCore.Mvc;
using RolesModulesPemissionDemo.Database;
using RolesModulesPemissionDemo.Models;
using RolesModulesPemissionDemo.Objects;
using SQLitePCL;

namespace RolesModulesPemissionDemo.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class RolController : ControllerBase
    {

        private RolesAdministratorContext _db;

        public RolController(RolesAdministratorContext context)
        {
            _db = context;
        }

        [HttpGet(Name = "GetRols")]
        public IEnumerable<Rol> Get()
        {               
            return _db.Rols.ToList();
        }

        [HttpPost(Name = "AddRol")]
        public Message Post(Rol rol)
        {
            var r = _db.Rols.Add(rol).State;
            _db.SaveChanges();
            bool result = r == Microsoft.EntityFrameworkCore.EntityState.Added? true: false;
            return new Message { Status = result ? 200 : 500, Description = result ? string.Format("Added {0}", rol.Name) : string.Format("Not Added {0}", rol.Name), Result = result };            
        }
    }
}
