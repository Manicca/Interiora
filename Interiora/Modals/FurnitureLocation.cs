using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Modals
{
    public class FurnitureLocation
    {
        public int FurnitureLocationId { get; set; }
        public Point LocationPoint { get; set; }
        public int FurnitureId { get; set; }
        public virtual Furniture Furniture { get; set; }
        public int WorkspaceId { get; set; }
        public virtual  Workspace Workspace { get; set; }
    }
}