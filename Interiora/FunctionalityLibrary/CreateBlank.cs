using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionalityLibrary.Drawing.History;

using AODL.Document.Content.Tables;
using AODL.Document.Content.Text;
using AODL.Document.SpreadsheetDocuments;
using AODL.Document.Styles;
using AODL.Document.TextDocuments;

using OOC = unoidl.com.sun.star;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.uno;
using unoidl.com.sun.star.bridge;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.text;
using unoidl.com.sun.star.beans;
using unoidl.com.sun.star.sheet;
using unoidl.com.sun.star.container;
using unoidl.com.sun.star.table;


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
       public  void blank(InfoCustoms info, HistoryDrawing history)
       {
           OOC.uno.XComponentContext mxContext = uno.util.Bootstrap.bootstrap();
           OOC.lang.XMultiServiceFactory mxMSFactory = (XMultiServiceFactory)mxContext.getServiceManager();
           XComponentLoader aLoader = (XComponentLoader)mxMSFactory.createInstance("com.sun.star.frame.Desktop");
           XComponent xComponent = aLoader.loadComponentFromURL("private:factory/scalc", "_blank", 0, new OOC.beans.PropertyValue[0]);

           OOC.sheet.XSpreadsheets xSheets = ((OOC.sheet.XSpreadsheetDocument)xComponent).getSheets();
           OOC.container.XIndexAccess xSheetsIA = (OOC.container.XIndexAccess)xSheets;
           OOC.sheet.XSpreadsheet xSheet = (OOC.sheet.XSpreadsheet)xSheetsIA.getByIndex(0).Value;//получиил первый лист

           var range = xSheet.getCellRangeByPosition(0, 0, 3, 0);
           ((OOC.util.XMergeable)range).merge(true);
           var xPropSet = (OOC.beans.XPropertySet)range;
           xPropSet.setPropertyValue("CharFontName", new uno.Any((String)"Times New Roman"));
           xPropSet.setPropertyValue("CharHeight", new uno.Any((Int32)14));
           xPropSet.setPropertyValue("CharWeight", new uno.Any((Single)OOC.awt.FontWeight.BOLD));
           xPropSet.setPropertyValue("HoriJustify", new uno.Any((Int32)(2)));//выравнивание по право
           xPropSet.setPropertyValue("VertJustify", new uno.Any((Int32)(2)));

           var xCell = xSheet.getCellByPosition(0, 0);
           var xText = (OOC.text.XText)xCell;
           xText.insertString(xText.createTextCursor(), "Бланк заказов продукции", false);

           #region Рамка для таблицы
           var aLine = new OOC.table.BorderLine();
           aLine.InnerLineWidth = 0;
           aLine.LineDistance = 0;
           aLine.OuterLineWidth = 100;
           var aLineInner = new OOC.table.BorderLine();
           aLineInner.InnerLineWidth = 0;
           aLineInner.LineDistance = 0;
           aLineInner.OuterLineWidth = 50;
           var aBorder = new OOC.table.TableBorder();
           aBorder.TopLine = aBorder.BottomLine = aBorder.LeftLine = aBorder.RightLine = aLine;
           aBorder.HorizontalLine = aBorder.VerticalLine = aLineInner;
           aBorder.IsTopLineValid = aBorder.IsBottomLineValid = true;
           aBorder.IsLeftLineValid = aBorder.IsRightLineValid = true;
           aBorder.IsHorizontalLineValid = aBorder.IsVerticalLineValid = true;
#endregion

           xCell = xSheet.getCellByPosition(0, 2);
           xText = (OOC.text.XText)xCell;
           xText.insertString(xText.createTextCursor(), "№ п/п", false);
           xCell = xSheet.getCellByPosition(1, 2);
           xText = (OOC.text.XText)xCell;
           xText.insertString(xText.createTextCursor(), "Название", false);
           xCell = xSheet.getCellByPosition(2, 2);
           xText = (OOC.text.XText)xCell;
           xText.insertString(xText.createTextCursor(), "Поставщик", false);
           xCell = xSheet.getCellByPosition(3, 2);
           xText = (OOC.text.XText)xCell;
           xText.insertString(xText.createTextCursor(), "Цена", false);

           range = xSheet.getCellRangeByPosition(0, 2, 3, 2);
           xPropSet = (OOC.beans.XPropertySet)range;
           xPropSet.setPropertyValue("CharWeight", new uno.Any((Single)OOC.awt.FontWeight.BOLD));
           xPropSet.setPropertyValue("HoriJustify", new uno.Any((Int32)(2)));//выравнивание по право

           double sum = 0;

           for (int i = 1; i <= history.AllOfficeFiguresRecords().Count; ++i)
           {
               xCell = xSheet.getCellByPosition(0, 2 + i);
               xText = (OOC.text.XText)xCell;
               xText.insertString(xText.createTextCursor(), i.ToString(), false);
               xCell = xSheet.getCellByPosition(1, 2 + i);
               xText = (OOC.text.XText)xCell;
               xText.insertString(xText.createTextCursor(), history.AllOfficeFiguresRecords()[i - 1].getFurniture().Type + " " +
                   history.AllOfficeFiguresRecords()[i - 1].getFurniture().Article, false);
               xCell = xSheet.getCellByPosition(2, 2 + i);
               xText = (OOC.text.XText)xCell;
               xText.insertString(xText.createTextCursor(), history.AllOfficeFiguresRecords()[i - 1].getFurniture().Supplier.Name, false);
               xCell = xSheet.getCellByPosition(3, 2 + i);
               xText = (OOC.text.XText)xCell;
               xText.insertString(xText.createTextCursor(), history.AllOfficeFiguresRecords()[i - 1].getFurniture().Cost, false);
               xPropSet = (OOC.beans.XPropertySet)xCell;
               xPropSet.setPropertyValue("HoriJustify", new uno.Any((Int32)(3)));//выравнивание по право

               sum += Convert.ToDouble(history.AllOfficeFiguresRecords()[i - 1].getFurniture().Cost);
           }


           range = xSheet.getCellRangeByPosition(0, 3 + history.AllOfficeFiguresRecords().Count, 2, 3 + history.AllOfficeFiguresRecords().Count);
           ((OOC.util.XMergeable)range).merge(true);
           xCell = xSheet.getCellByPosition(0, 3 + history.AllOfficeFiguresRecords().Count);
           xText = (OOC.text.XText)xCell;
           xText.insertString(xText.createTextCursor(), "Итого: ", false);
           xCell = xSheet.getCellByPosition(3, 3 + history.AllOfficeFiguresRecords().Count);
           xText = (OOC.text.XText)xCell;
           xText.insertString(xText.createTextCursor(), String.Format("{0:000.00}", sum), false);
           xPropSet = (OOC.beans.XPropertySet)xCell;
           xPropSet.setPropertyValue("HoriJustify", new uno.Any((Int32)(3)));//выравнивание по право

           range = xSheet.getCellRangeByPosition(0, 2, 3, 3 + history.AllOfficeFiguresRecords().Count);
           xPropSet = (OOC.beans.XPropertySet)range;
           xPropSet.setPropertyValue("CharFontName", new uno.Any((String)"Times New Roman"));
           xPropSet.setPropertyValue("CharHeight", new uno.Any((Int32)10));
           xPropSet.setPropertyValue("TableBorder", new uno.Any(typeof(OOC.table.TableBorder), aBorder));

           int ppoint = 3 + history.AllOfficeFiguresRecords().Count;

           //Table table = new Table(rD, "Blank", "table");
           //Paragraph p = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           //var text = TextBuilder.BuildTextCollection(rD, "Name");
           //Cell cell = table.CreateCell();
           //p.TextContent.Add(new SimpleText(rD, "ИНН/КПП "+info.inn));
           //cell.Content.Add(p);
           //table.InsertCellAt(1,0, cell);

           
           //Paragraph p1 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           //var text1 = TextBuilder.BuildTextCollection(rD, "Name");
           //Cell cell1 = table.CreateCell();
           //p1.TextContent.Add(new SimpleText(rD, "Юридический адрес "+info.adress));
           //cell1.Content.Add(p1);
           //table.InsertCellAt(2, 0, cell1);

           //Paragraph p2 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           //var text2 = TextBuilder.BuildTextCollection(rD, "Name");
           //Cell cell2 = table.CreateCell();
           //p2.TextContent.Add(new SimpleText(rD, "Банковские реквизиты "+info.bankinfo));
           //cell2.Content.Add(p2);
           //table.InsertCellAt(3, 0, cell2);

           //Paragraph p3 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           //var text3 = TextBuilder.BuildTextCollection(rD, "Name");
           //Cell cell3 = table.CreateCell();
           //p3.TextContent.Add(new SimpleText(rD, "Директор "+info.direct));
           //cell3.Content.Add(p3);
           //table.InsertCellAt(4, 0, cell);

           //Paragraph p4 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           //var text4 = TextBuilder.BuildTextCollection(rD, "Name");
           //Cell cell4 = table.CreateCell();
           //p4.TextContent.Add(new SimpleText(rD, "Главный бухгалтер "+info.buch));
           //cell4.Content.Add(p4);
           //table.InsertCellAt(5, 0, cell);

           //Paragraph p5 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           //var text5 = TextBuilder.BuildTextCollection(rD, "Name");
           //Cell cell5 = table.CreateCell();
           //p5.TextContent.Add(new SimpleText(rD, "Телефон "+info.number));
           //cell5.Content.Add(p5);
           //table.InsertCellAt(6, 0, cell);

           //Paragraph p6 = ParagraphBuilder.CreateSpreadsheetParagraph(rD);
           //var text6 = TextBuilder.BuildTextCollection(rD, "Name");
           //Cell cell6 = table.CreateCell();
           //p6.TextContent.Add(new SimpleText(rD, "e-mail "+info.mail));
           //cell6.Content.Add(p6);
           //table.InsertCellAt(7, 0, cell);
           //rD.TableCollection.Add(table);
           //rD.SaveTo("blanki.ods");


       }
    }
}
