using System.Collections.Generic;

namespace Models
{
    public class Workspace
    {
        public int WorkspaceId { get; set; }
        public int Name { get; set; }
        public virtual List<FurnitureLocation> AllFurnitures { get; set; }
    }
}