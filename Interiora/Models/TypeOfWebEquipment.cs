using System;

namespace Models
{
    public class TypeOfWebEquipment
    {
        public int TypeOfWebEquipmentId { get; set; }
        public string Name { get; set; }
        public TypeOfWebEquipment(string name)
        {
            Name = name;
        }
        public TypeOfWebEquipment() { }
    }
}
