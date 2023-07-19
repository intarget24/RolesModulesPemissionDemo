using System.Runtime.InteropServices;

namespace RolesModulesPemissionDemo.Enums
{
    [Flags]
    public enum Permissions
    {
        Create = 1,
        Read = 2,
        Update = 4,
        Delete = 8,
        Print = 16,
        Download = 32        
    }
}
