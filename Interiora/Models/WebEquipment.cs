using System;
namespace Models
{   public class WebEquipment
    {
        public int WebEquipmentId { get; set; }
        public string Cost { get; set; }
        public string Atributes { get; set; }
        public int TypeOfWebEquipmentId { get; set; }
        public virtual TypeOfWebEquipment TypeOfWebEquipment { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public WebEquipment() { }
        public WebEquipment(string coast, string attr, int typeId, int supplierId)
        {
            Cost = coast;
            Atributes = attr;
            TypeOfWebEquipmentId = typeId;
            SupplierId = supplierId;
        }
    }

}
