using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RolesModulesPemissionDemo.Database;
using RolesModulesPemissionDemo.Objects;

namespace RolesModulesPemissionDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ZClearAll : ControllerBase
    {

        private RolesAdministratorContext _db;

        public ZClearAll(RolesAdministratorContext context)
        {
            _db = context;
        }

        [HttpDelete(Name = "DeleteAll")]
        public Message DeleteAll(bool confirm)
        {
            _db.Modules.ExecuteDelete();
            _db.Rols.ExecuteDelete();
            _db.SaveChanges();
            
            return new Message { Status = true ? 200 : 500, Description = true ? string.Format("All Deleted") : string.Format("Not Deleted"), Result = true };
        }
    }
}
