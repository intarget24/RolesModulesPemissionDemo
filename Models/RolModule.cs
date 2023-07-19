using RolesModulesPemissionDemo.Enums;

namespace RolesModulesPemissionDemo.Models
{    

    public class RolModule
    {
        public int RolId { get; set; }
        public int ModuleId { get; set; }
        public Permissions RolModulePermissions { get; set; }
        public bool HasPermission(Permissions permission)
        {
            return RolModulePermissions.HasFlag(permission);
        }
    }
}
