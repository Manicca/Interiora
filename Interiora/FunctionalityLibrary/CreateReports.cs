
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using iTextSharp;
//using iTextSharp.text;
//using System.IO;
//using iTextSharp.text.pdf;

namespace FunctionalityLibrary
{
    class CreateReports
    {
       void reportPDF()
       {
           //var doc = new Document();
           //PdfWriter.GetInstance(doc, new FileStream(@"Document1.pdf", FileMode.Create));
           //doc.Open();
           //BaseFont baseFont = BaseFont.CreateFont("ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
           //BaseColor bc = BaseColor.BLACK;
           //iTextSharp.text.Phrase j = new Phrase("Отчет ", new iTextSharp.text.Font(baseFont, 12, 0, bc));
           //Paragraph a1 = new Paragraph(j);
           //a1.Alignment = Element.ALIGN_CENTER;
           //a1.SpacingAfter = 5;
           //doc.Add(a1);
           ////здесь будет план
           ////iTextSharp.text.Image k = iTextSharp.text.Image.GetInstance(@"Plan.jpg");
           ////k.Alignment = Element.ALIGN_CENTER;
           ////doc.Add(k);

           ////таблица данных
           //PdfPTable table = new PdfPTable(6);//№пп //тип // поставщик //артикул //стоимость за 1 //кол-во //сумма

           //PdfPCell cell0 = new PdfPCell(new Phrase("№ п/п", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell0);

           //PdfPCell cell = new PdfPCell(new Phrase("Объект", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell);

           //PdfPCell cell1 = new PdfPCell(new Phrase(" Поставщик", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell1);

           //PdfPCell cell2 = new PdfPCell(new Phrase("Артикул", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell2);


           //PdfPCell cell3 = new PdfPCell(new Phrase(" Стоимость за единицу", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell3);


           //PdfPCell cell4 = new PdfPCell(new Phrase("Количество", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell4);

           //PdfPCell cell5 = new PdfPCell(new Phrase("Сумма", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell5);
           ////
           //doc.Add(table);



           //doc.Close();
           //MessageBox.Show("Готово!");

       }
       void blankPDF(string inn, string adress, string bankinfo, string direct, string buch, string number, string mail)
       {
           //var doc = new Document();
           //PdfWriter.GetInstance(doc, new FileStream(@"Document2.pdf", FileMode.Create));
           //doc.Open();
           //BaseFont baseFont = BaseFont.CreateFont("ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
           //BaseColor bc = BaseColor.BLACK;
           //iTextSharp.text.Phrase j = new Phrase("Бланк заказов продукции ", new iTextSharp.text.Font(baseFont, 12, 0, bc));
           //Paragraph a1 = new Paragraph(j);
           //a1.Alignment = Element.ALIGN_RIGHT;
           //a1.SpacingAfter = 5;
           //doc.Add(a1);

           //iTextSharp.text.Phrase dannie = new Phrase(" Заказ № ", new iTextSharp.text.Font(baseFont, 12, 0, bc));
           //Paragraph a2 = new Paragraph(dannie);
           //a2.Alignment = Element.ALIGN_LEFT;
           //doc.Add(a2);


           //PdfPTable table = new PdfPTable(6);//№пп //тип // поставщик //артикул //стоимость за 1 //кол-во //сумма

           //PdfPCell cell0 = new PdfPCell(new Phrase("№ п/п", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell0);

           //PdfPCell cell = new PdfPCell(new Phrase("Объект", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell);

           //PdfPCell cell1 = new PdfPCell(new Phrase(" Поставщик", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell1);

           //PdfPCell cell2 = new PdfPCell(new Phrase("Артикул", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell2);


           //PdfPCell cell3 = new PdfPCell(new Phrase(" Стоимость за единицу", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell3);


           //PdfPCell cell4 = new PdfPCell(new Phrase("Количество", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell4);

           //PdfPCell cell5 = new PdfPCell(new Phrase("Сумма", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table.AddCell(cell5);

           //doc.Add(table);

           ////о покупателе
           //iTextSharp.text.Phrase about = new Phrase(" Реквизиты покупателя ", new iTextSharp.text.Font(baseFont, 12, 0, bc));
           //Paragraph a3 = new Paragraph(about);
           //a3.Alignment = Element.ALIGN_CENTER;
           //a3.SpacingAfter = 5;
           //doc.Add(a3);

           ////таблица реквизитор
           //PdfPTable table2 = new PdfPTable(2);//параметр // данные

           //PdfPCell cel0 = new PdfPCell(new Phrase("ИНН/КПП", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table2.AddCell(cel0);

           //PdfPCell cel = new PdfPCell(new Phrase(inn));
           //table2.AddCell(cel);

           //PdfPCell cel1 = new PdfPCell(new Phrase(" Юридический адрес", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table2.AddCell(cel1);

           //PdfPCell cel2 = new PdfPCell(new Phrase(adress));
           //table2.AddCell(cel2);


           //PdfPCell cel3 = new PdfPCell(new Phrase(" Банковские реквизиты", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table2.AddCell(cel3);


           //PdfPCell cel4 = new PdfPCell(new Phrase(bankinfo));
           //table2.AddCell(cel4);

           //PdfPCell cel5 = new PdfPCell(new Phrase("Директор", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table2.AddCell(cel5);

           //PdfPCell cel6 = new PdfPCell(new Phrase(direct));
           //table2.AddCell(cel6);

           //PdfPCell cel7 = new PdfPCell(new Phrase("Главный бухгалтер", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table2.AddCell(cel7);

           //PdfPCell cel8 = new PdfPCell(new Phrase(buch));
           //table2.AddCell(cel8);

           //PdfPCell cel9 = new PdfPCell(new Phrase("Телефон", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table2.AddCell(cel9);

           //PdfPCell cel10 = new PdfPCell(new Phrase(number));
           //table2.AddCell(cel10);

           //PdfPCell cel11 = new PdfPCell(new Phrase("e-mail", new iTextSharp.text.Font(baseFont, 12, 0, bc)));
           //table2.AddCell(cel11);

           //PdfPCell cel12 = new PdfPCell(new Phrase(mail));
           //table2.AddCell(cel12);

           //doc.Add(table2);

           //iTextSharp.text.Phrase end = new Phrase(" Подпись, печать ", new iTextSharp.text.Font(baseFont, 12, 0, bc));
           //Paragraph a4 = new Paragraph(end);
           //a3.Alignment = Element.ALIGN_CENTER;
           //doc.Add(a4);

           //doc.Close();
           //MessageBox.Show("Готово!");
       }
       void eblancCalc()
       {
           MessageBox.Show(
               "Уважаемая Мария, пожалуйста, если вы подключаете библиотеки, то будьте бобры не ПИХАТЬ ИХ БЛЯТЬ В ПАПКУ BIN");
       }
    }
}
