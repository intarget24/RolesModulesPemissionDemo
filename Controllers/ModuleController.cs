using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RolesModulesPemissionDemo.Database;
using RolesModulesPemissionDemo.Models;
using RolesModulesPemissionDemo.Objects;
using System.Xml;

namespace RolesModulesPemissionDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ModuleController : ControllerBase
    {

        private RolesAdministratorContext _db;

        public ModuleController(RolesAdministratorContext context)
        {
            _db = context;
        }


        
        [HttpGet("GetAllModules/")]
        public IEnumerable<Module> GetAllModules()
        {
            return _db.Modules.ToList();
        }

        
        [HttpGet("GetRootModules/")]

        public IEnumerable<Module> GetRootModules()
        {
            return _db.Modules.Where(M => M.ModuleParentId == null).ToList();
        }

        [HttpGet("GetRootModulesWithChilds/")]

        public IEnumerable<Module> GetRootModulesWithChilds()
        {
            return _db.Modules
                .Include("Childs.Childs")
                .Where(M => M.ModuleParentId == null)
                .Select(M => new Module() { Id = M.Id, Description = M.Description, Name = M.Name, ModuleParentId = M.ModuleParentId, Childs = M.Childs });

       }

        [HttpPost(Name = "AddModule")]
        public Message Post(Module module)
        {
            var r = _db.Modules.Add(module).State;
            _db.SaveChanges();
            bool result = r == Microsoft.EntityFrameworkCore.EntityState.Added ? true : false;
            return new Message { Status = result ? 200 : 500, Description = result ? string.Format("Added {0}", module.Name) : string.Format("Not Added {0}", module.Name), Result = result };
        }
    }
}
