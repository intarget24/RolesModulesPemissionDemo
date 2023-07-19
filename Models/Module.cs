using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace RolesModulesPemissionDemo.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ComponentNameToRender { get; set; }
        public int? ModuleParentId { get; set; }
        
        [NotMapped]
        public Module? ParentModule { get; set; } = null!;
        public ICollection<Module> Childs { get; set; } = new List<Module>();
        
    }
}
