using System;

namespace Models
{
    public class TypeOfWebEquipment
    {
          public int TypeOfWebEquipmentId { get; set; }
          public string Name {get; set;}
        public TypeOfWebEquipment (){}
        public TypeOfWebEquipment (int typeID, string name)
        {
            TypeOfWebEquipmentId = typeID;
            Name=name;
        }
        

        public static explicit operator TypeOfWebEquipment(string t)
        {
            throw new NotImplementedException();
        }
    }
}
