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
        int countsup=0;
        void Supl(int id) //бланк в разрезе по поставщикам, поэтому функция для фильтрации объектов того или иного поставщика
        {
            SpreadsheetDocument spreadsheetDocument = new SpreadsheetDocument();
                spreadsheetDocument.New();
                Table table = new Table(spreadsheetDocument, "First", "tablefirst");
            for (int j = 0; j < countsup; j++)
            {
                Paragraph parag = ParagraphBuilder.CreateSpreadsheetParagraph(spreadsheetDocument);
                var text = TextBuilder.BuildTextCollection(spreadsheetDocument, " ");
                Cell cell = table.CreateCell();
                //parag.TextContent.Add(new SimpleText(spreadsheetDocument, 'элемент бд, где поставщик ид=ид'));
                cell.Content.Add(parag);
                table.InsertCellAt(0, 0, cell);
                spreadsheetDocument.TableCollection.Add(table);
                 spreadsheetDocument.SaveTo("Matr.ods");
            }
    }
       void CreateBla() //бланк
       {

       }
    }
}
