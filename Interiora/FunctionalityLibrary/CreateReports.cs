
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace FunctionalityLibrary
{
    public class CreateReports
    {
       //void reportPDF()
       //{
       //     var doc = new Document();
       //     PdfWriter.GetInstance(doc, new FileStream(@"Document1.pdf", FileMode.Create));
       //     doc.Open();
       //     var baseFont = BaseFont.CreateFont("ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
       //     var bc = BaseColor.BLACK;
       //     var j = new Phrase("Отчет ", new Font(baseFont, 12, 0, bc));
       //    var a1 = new Paragraph(j)
       //    {
       //        Alignment = Element.ALIGN_CENTER,
       //        SpacingAfter = 5
       //    };
       //    doc.Add(a1);
       //     //здесь будет план
       //     // Правда? ГДЕ ОН?! Я ЕГО НЕ ВИЖУ!
       //     //iTextSharp.text.Image k = iTextSharp.text.Image.GetInstance(@"Plan.jpg");
       //     //k.Alignment = Element.ALIGN_CENTER;
       //     //doc.Add(k);

       //     //таблица данных
       //     var table = new PdfPTable(6);//№пп //тип // поставщик //артикул //стоимость за 1 //кол-во //сумма

       //     var cell0 = new PdfPCell(new Phrase("№ п/п", new Font(baseFont, 12, 0, bc)));
       //     table.AddCell(cell0);

       //     var cell = new PdfPCell(new Phrase("Объект", new Font(baseFont, 12, 0, bc)));
       //     table.AddCell(cell);

       //     var cell1 = new PdfPCell(new Phrase(" Поставщик", new Font(baseFont, 12, 0, bc)));
       //     table.AddCell(cell1);

       //     var cell2 = new PdfPCell(new Phrase("Артикул", new Font(baseFont, 12, 0, bc)));
       //     table.AddCell(cell2);


       //     var cell3 = new PdfPCell(new Phrase(" Стоимость за единицу", new Font(baseFont, 12, 0, bc)));
       //     table.AddCell(cell3);


       //     var cell4 = new PdfPCell(new Phrase("Количество", new Font(baseFont, 12, 0, bc)));
       //     table.AddCell(cell4);

       //     var cell5 = new PdfPCell(new Phrase("Сумма", new Font(baseFont, 12, 0, bc)));
       //     table.AddCell(cell5);
       //     //
       //     doc.Add(table);



       //     doc.Close();
       //     MessageBox.Show("Готово!");

       // }
      public  void blankPDF(InfoCustoms info)
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(@"Document.pdf", FileMode.Create));
            doc.Open();
            var baseFont = BaseFont.CreateFont("ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var bc = BaseColor.BLACK;
            var j = new Phrase("Бланк заказов продукции ", new Font(baseFont, 12, 0, bc));
            var a1 = new Paragraph(j);
            a1.Alignment = Element.ALIGN_RIGHT;
            a1.SpacingAfter = 5;
            doc.Add(a1);

            var dannie = new Phrase(" Заказ № ", new Font(baseFont, 12, 0, bc));
            var a2 = new Paragraph(dannie);
            a2.Alignment = Element.ALIGN_LEFT;
            doc.Add(a2);


            var table = new PdfPTable(6);//№пп //тип // поставщик //артикул //стоимость за 1 //кол-во //сумма

            var cell0 = new PdfPCell(new Phrase("№ п/п", new Font(baseFont, 12, 0, bc)));
            table.AddCell(cell0);

            var cell = new PdfPCell(new Phrase("Объект", new Font(baseFont, 12, 0, bc)));
            table.AddCell(cell);

            var cell1 = new PdfPCell(new Phrase(" Поставщик", new Font(baseFont, 12, 0, bc)));
            table.AddCell(cell1);

            var cell2 = new PdfPCell(new Phrase("Артикул", new Font(baseFont, 12, 0, bc)));
            table.AddCell(cell2);


            var cell3 = new PdfPCell(new Phrase(" Стоимость за единицу", new Font(baseFont, 12, 0, bc)));
            table.AddCell(cell3);


            var cell4 = new PdfPCell(new Phrase("Количество", new Font(baseFont, 12, 0, bc)));
            table.AddCell(cell4);

            var cell5 = new PdfPCell(new Phrase("Сумма", new Font(baseFont, 12, 0, bc)));
            table.AddCell(cell5);

            doc.Add(table);

            //о покупателе
            var about = new Phrase(" Реквизиты покупателя ", new Font(baseFont, 12, 0, bc));
            var a3 = new Paragraph(about);
            a3.Alignment = Element.ALIGN_CENTER;
            a3.SpacingAfter = 5;
            doc.Add(a3);

            //таблица реквизитор
            var table2 = new PdfPTable(2);//параметр // данные

            var cel0 = new PdfPCell(new Phrase("ИНН/КПП", new Font(baseFont, 12, 0, bc)));
            table2.AddCell(cel0);

            var cel = new PdfPCell(new Phrase(info.inn));
            table2.AddCell(cel);

            var cel1 = new PdfPCell(new Phrase(" Юридический адрес", new Font(baseFont, 12, 0, bc)));
            table2.AddCell(cel1);

            var cel2 = new PdfPCell(new Phrase(info.adress));
            table2.AddCell(cel2);


            var cel3 = new PdfPCell(new Phrase(" Банковские реквизиты", new Font(baseFont, 12, 0, bc)));
            table2.AddCell(cel3);


            var cel4 = new PdfPCell(new Phrase(info.bankinfo));
            table2.AddCell(cel4);

            var cel5 = new PdfPCell(new Phrase("Директор", new Font(baseFont, 12, 0, bc)));
            table2.AddCell(cel5);

            var cel6 = new PdfPCell(new Phrase(info.direct));
            table2.AddCell(cel6);

            var cel7 = new PdfPCell(new Phrase("Главный бухгалтер", new Font(baseFont, 12, 0, bc)));
            table2.AddCell(cel7);

            var cel8 = new PdfPCell(new Phrase(info.buch));
            table2.AddCell(cel8);

            var cel9 = new PdfPCell(new Phrase("Телефон", new Font(baseFont, 12, 0, bc)));
            table2.AddCell(cel9);

            var cel10 = new PdfPCell(new Phrase(info.number));
            table2.AddCell(cel10);

            var cel11 = new PdfPCell(new Phrase("e-mail", new Font(baseFont, 12, 0, bc)));
            table2.AddCell(cel11);

            var cel12 = new PdfPCell(new Phrase(info.mail));
            table2.AddCell(cel12);

            doc.Add(table2);

            Phrase end = new Phrase(" Подпись, печать ", new Font(baseFont, 12, 0, bc));
            Paragraph a4 = new Paragraph(end);
            a3.Alignment = Element.ALIGN_CENTER;
            doc.Add(a4);

            doc.Close();
            MessageBox.Show("Готово!");
        }
       
    }
    
}
