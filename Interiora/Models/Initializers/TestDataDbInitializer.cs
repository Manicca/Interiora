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
                new Furniture("Table", "163718904", "5000", "60*110", 1),
                new Furniture("Table", "284948193", "4500", "70*120", 1),
                new Furniture("Chair", "035910580", "2000", "40*40", 1),
                new Furniture("Chair", "347891404", "1600", "30*40", 1),
                new Furniture("ForClothes", "241269624", "600", "30*30", 1),
                new Furniture("ForClothes", "149801234", "1350", "25*25", 1),
                new Furniture("CupBoard", "124870198", "4000", "40*80", 1),
                new Furniture("CupBoard", "589012873", "4500", "70*120", 1),
                new Furniture("ARM", "109305295", "20000", "80*120", 1),
                new Furniture("ARM", "098429014", "48600", "75*110", 1),
                new Furniture("Table", "012874775", "3850", "70*100", 2),
                new Furniture("ARM", "234567987", "54500", "80*120", 2),
                new Furniture("ARM", "633757523", "38600", "75*100", 2),
                new Furniture("ARM", "352839123", "60000", "70*100", 2),
                new Furniture("ARM", "247149104", "150000", "70*90", 2),
                new Furniture("Table", "241893489", "3000", "60*100", 2),
                new Furniture("Table", "487091647", "3200", "70*120", 2),
                new Furniture("Table", "309572781", "1800", "75*105", 3),
                new Furniture("Table", "194879874", "2300", "60*100", 3),
                new Furniture("Chair", "292838309", "800", "40*50", 3),
                new Furniture("Chair", "019379487", "1000", "30*40", 3),
                new Furniture("Chair", "083379174", "1500", "30*30", 3),
                new Furniture("Chair", "444902325", "1600", "35*40", 3),
                new Furniture("ForClothes", "232980003", "650", "20*20", 4),
                new Furniture("ForClothes", "204370345", "700", "25*25", 4),
                new Furniture("CupBoard", "863567357", "7000", "50*110", 4),
                new Furniture("CupBoard", "242457889", "5800", "60*80", 4),
                new Furniture("Table", "232489994", "3700", "75*110", 5),
                new Furniture("Chair", "534688423", "1350", "30*35", 5),
                new Furniture("Table", "145670002", "2200", "50*70", 6),
                new Furniture("Chair", "451126889", "1800", "20*25", 6),
                new Furniture("ARM", "124147743", "46700", "90*140", 6),
                new Furniture("Table", "756767321", "2700", "70*125", 6),
                new Furniture("ARM", "137436367", "70300", "70*90", 6),
                new Furniture("ARM", "521358423", "84500", "80*125", 7),
                new Furniture("Table", "147931357", "3600", "65*100", 7),
                new Furniture("ARM", "325893113", "30500", "75*110", 7)
            };

            furnitures.ForEach(f => context.FurnitureDb.Add(f));
            context.SaveChanges();
        }
    }
}