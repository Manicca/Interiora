using System.Collections.Generic;
using System.Data.Entity;

namespace Models.Initializers
{
    internal sealed class TestDataDbInitializer : DropCreateDatabaseAlways<AllModelsContext>
    {
        protected override void Seed(AllModelsContext context)
        {
            var suppliers = new List<Supplier>
            {
                new Supplier("РосАкс", "rosaks@mail.ru", "Иванов Петр Ильич"),
                new Supplier("ИКЕЯ", "ikea@mail.com", "Дмитриев Констанстин Николаевич"),
                new Supplier("МебельСити", "mebely@mail.ru", "Кравченко Ольга Вячеславовна"),
                new Supplier("СтройГрад", "strgrad@mail.ru", "Кириленко Евгений Борисович"),
                new Supplier("Сарай", "sarai@mail.ru", "Захарцев Альберт Эдуардович"),
                new Supplier("Ашан", "ashan@mail.ru", "Лебедев Валерий Владимирович"),
                new Supplier("ДеревяшКа", "derevSh@mail.ru", "Носырев Матвей Игоревич"),
                new Supplier("Винтики и Шпунтики", "vinshpun@mail.ru", "Кожухова Амалия Арсеньевна"),
                new Supplier("Человек Паук", "man@mail.ru", "Буйнов Кирилл Михайлович"),
                new Supplier("World Wide Web", "wowiwe@mail.ru", null)
            };

            suppliers.ForEach(s => context.SupplierDb.Add(s));
            context.SaveChanges();

            
            var furnitures = new List<Furniture>
            {
                new Furniture("Table", "163718904", "5000", "250*150", 1),
                new Furniture("Table", "284948193", "4500", "180*100", 1),
                new Furniture("Chair", "035910580", "2000", "50*50", 1),
                new Furniture("Chair", "347891404", "1600", "60*70", 1),
                new Furniture("ForClothes", "241269624", "600", "30*30", 1),
                new Furniture("ForClothes", "149801234", "1350", "25*30", 1),
                new Furniture("CupBoard", "124870198", "4000", "100*80", 1),
                new Furniture("CupBoard", "589012873", "4500", "110*75", 1),
                new Furniture("ARM", "109305295", "20000", "200*100", 1),
                new Furniture("ARM", "098429014", "48600", "180*90", 1),
                new Furniture("Table", "012874775", "3850", "100*100", 2),
                new Furniture("ARM", "234567987", "54500", "180*80", 2),
                new Furniture("ARM", "633757523", "38600", "185*80", 2),
                new Furniture("ARM", "352839123", "60000", "190*100", 2),
                new Furniture("ARM", "247149104", "150000", "220*100", 2),
                new Furniture("Table", "241893489", "3000", "130*100", 2),
                new Furniture("Table", "487091647", "3200", "150*120", 2),
                new Furniture("Table", "309572781", "1800", "160*60", 3),
                new Furniture("Table", "194879874", "2300", "100*100", 3),
                new Furniture("Chair", "292838309", "800", "50*60", 3),
                new Furniture("Chair", "019379487", "1000", "70*70", 3),
                new Furniture("Chair", "083379174", "1500", "60*70", 3),
                new Furniture("Chair", "444902325", "1600", "80*80", 3),
                new Furniture("ForClothes", "232980003", "650", "40*50", 4),
                new Furniture("ForClothes", "204370345", "700", "50*55", 4),
                new Furniture("CupBoard", "863567357", "7000", "120*90", 4),
                new Furniture("CupBoard", "242457889", "5800", "80*60", 4),
                new Furniture("Table", "232489994", "3700", "110*75", 5),
                new Furniture("Chair", "534688423", "1350", "60*65", 5),
                new Furniture("Table", "145670002", "2200", "100*50", 6),
                new Furniture("Chair", "451126889", "1800", "50*55", 6),
                new Furniture("ARM", "124147743", "46700", "140*90", 6),
                new Furniture("Table", "756767321", "2700", "125*70", 6),
                new Furniture("ARM", "137436367", "70300", "130*90", 6),
                new Furniture("ARM", "521358423", "84500", "150*95", 7),
                new Furniture("Table", "147931357", "3600", "150*130", 7),
                new Furniture("ARM", "325893113", "30500", "140*80", 7)
            };

            furnitures.ForEach(f => context.FurnitureDb.Add(f));
            context.SaveChanges();


            var typeofWeb = new List<TypeOfWebEquipment>
            {
                new TypeOfWebEquipment(1,"Хаб"),
                new TypeOfWebEquipment(2,"Комутатор"),
                new TypeOfWebEquipment(3,"Витая пара")
            };
            typeofWeb.ForEach(w => context.TypeOfWebEquipmentDb.Add(w));
            context.SaveChanges();

            var WebEquipment = new List<WebEquipment> 
            {
                new WebEquipment(4, "450", "10*10", 1),
                new WebEquipment(7, "500", "15*10", 1),
                new WebEquipment(8, "600", "20*20", 2),
                new WebEquipment(10,"650", "10*15", 2),
                new WebEquipment(25,"600", "1", 3),
                new WebEquipment(27,"800", "10*20", 1),
                new WebEquipment(28,"750", "15*25", 2),
                new WebEquipment(29,  "750", "1", 3)
            };
            WebEquipment.ForEach(we => context.WebEquipmentDb.Add(we));
            context.SaveChanges();
        }
    }
}