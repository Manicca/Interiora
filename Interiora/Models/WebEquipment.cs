namespace Models
{
     public class WebEquipment
     {
          public int WebEquipmentId { get; set; }
          public string Cost { get; set; }
          public string Atributes { get; set; }
          public int TypeOfWebEquipmentId { get; set; }
          public virtual TypeOfWebEquipment TypeOfWebEquipment { get; set; }
          public int SupplierId { get; set; }
          public virtual Supplier Supplier { get; set; }
     }
}
