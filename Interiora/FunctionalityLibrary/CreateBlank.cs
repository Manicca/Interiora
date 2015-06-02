using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AODL.Document.Content.Tables;
using AODL.Document.Content.Text;
using AODL.Document.SpreadsheetDocuments;
using AODL.Document.Styles;
using AODL.Document.TextDocuments;

namespace FunctionalityLibrary
{
   public class CreateBlank 
    {
    //    int countsup=0;
    //    void Supl(int id) //бланк в разрезе по поставщикам, поэтому функция для фильтрации объектов того или иного поставщика
    //    {
    //        SpreadsheetDocument spreadsheetDocument = new SpreadsheetDocument();
    //            spreadsheetDocument.New();
    //            Table table = new Table(spreadsheetDocument, "First", "tablefirst");
    //        for (int j = 0; j < countsup; j++)
    //        {
    //            Paragraph parag = ParagraphBuilder.CreateSpreadsheetParagraph(spreadsheetDocument);
    //            var text = TextBuilder.BuildTextCollection(spreadsheetDocument, " ");
    //            Cell cell = table.CreateCell();
    //            //parag.TextContent.Add(new SimpleText(spreadsheetDocument, 'элемент бд, где поставщик ид=ид'));
    //            cell.Content.Add(parag);
    //            table.InsertCellAt(0, 0, cell);
    //            spreadsheetDocument.TableCollection.Add(table);
    //             spreadsheetDocument.SaveTo("Matr.ods");
    //        }
    //}
       public  void blank(InfoCustoms info)
        
       {
          
           SpreadsheetDocument rD = new SpreadsheetDocument();
           rD.New();
           Table table = new Table(rD, "Blank", "table");
           Paragraph p = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           var text = TextBuilder.BuildTextCollection(rD, "Name");
           Cell cell = table.CreateCell();
           p.TextContent.Add(new SimpleText(rD, "ИНН/КПП "+info.inn));
           cell.Content.Add(p);
           table.InsertCellAt(1,0, cell);

           
           Paragraph p1 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           var text1 = TextBuilder.BuildTextCollection(rD, "Name");
           Cell cell1 = table.CreateCell();
           p1.TextContent.Add(new SimpleText(rD, "Юридический адрес"+info.adress));
           cell1.Content.Add(p1);
           table.InsertCellAt(2, 0, cell1);

           Paragraph p2 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           var text2 = TextBuilder.BuildTextCollection(rD, "Name");
           Cell cell2 = table.CreateCell();
           p2.TextContent.Add(new SimpleText(rD, "Банковские реквизиты"+info.bankinfo));
           cell2.Content.Add(p2);
           table.InsertCellAt(3, 0, cell2);

           Paragraph p3 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           var text3 = TextBuilder.BuildTextCollection(rD, "Name");
           Cell cell3 = table.CreateCell();
           p3.TextContent.Add(new SimpleText(rD, "Директор"+info.direct));
           cell3.Content.Add(p3);
           table.InsertCellAt(4, 0, cell);

           Paragraph p4 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           var text4 = TextBuilder.BuildTextCollection(rD, "Name");
           Cell cell4 = table.CreateCell();
           p4.TextContent.Add(new SimpleText(rD, "Главный бухгалтер"+info.buch));
           cell4.Content.Add(p4);
           table.InsertCellAt(5, 0, cell);

           Paragraph p5 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           var text5 = TextBuilder.BuildTextCollection(rD, "Name");
           Cell cell5 = table.CreateCell();
           p5.TextContent.Add(new SimpleText(rD, "Телефон"+info.number));
           cell5.Content.Add(p5);
           table.InsertCellAt(6, 0, cell);

           Paragraph p6 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           var text6 = TextBuilder.BuildTextCollection(rD, "Name");
           Cell cell6 = table.CreateCell();
           p6.TextContent.Add(new SimpleText(rD, "e-mail"+info.mail));
           cell6.Content.Add(p6);
           table.InsertCellAt(7, 0, cell);
           rD.TableCollection.Add(table);
           rD.SaveTo("blanki.ods");


       }
    }
}
