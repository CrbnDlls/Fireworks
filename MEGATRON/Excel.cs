using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MSO.Excel
{
    public class Excel : IDisposable
    {
        public const string UID = "Excel.Application";
        object oExcel = null;
        object WorkBooks, WorkBook, WorkSheets, WorkSheet, Range, Interior;

        //КОНСТРУКТОР КЛАССА
        public Excel()
        {
            oExcel = Activator.CreateInstance(Type.GetTypeFromProgID(UID));
        }

        //ВИДИМОСТЬ EXCEL
        public bool Visible
        {
            set
            {
                if (false == value)
                    oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
                        null, oExcel, new object[] { false });

                else
                    oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
                        null, oExcel, new object[] { true });
            }
        }

        //ОТКРЫТЬ ОКУМЕНТ
        public void OpenDocument(string name)
        {
            WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            WorkBook = WorkBooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, WorkBooks, new object[] { name, true });
            WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            // Range = WorkSheet.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,WorkSheet,new object[1] { "A1" });
        }

        //СОЗДАТЬ НОВЫЙ ДОКУМЕНТ
        public void NewDocument()
        {
            WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            WorkBook = WorkBooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, WorkBooks, null);
            WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
        }

        //ЗАКРЫТЬ ДОКУМЕНТ
        public void CloseDocument()
        {
            WorkBook.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, WorkBook, new object[] { true });
        }

        //СОХРАНИТЬ ДОКУМЕНТ
        public void SaveDocument(string name)
        {
            if (File.Exists(name))
                WorkBook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null,
                    WorkBook, null);
            else
                WorkBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null,
                    WorkBook, new object[] { name });
        }

        //УСТАНОВКА ЦВЕТА ФОНА ЯЧЕЙКИ
        public void SetColor(string range, int color)
        {
            //Range.Interior.ColorIndex
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });

            Interior = Range.GetType().InvokeMember("Interior", BindingFlags.GetProperty,
                null, Range, null);

            Range.GetType().InvokeMember("ColorIndex", BindingFlags.SetProperty, null,
                Interior, new object[] { color });
        }

        //ОРИЕНТАЦИИ СТРАНИЦЫ
        public enum XlPageOrientation
        {
            xlPortrait = 1, //Книжный
            xlLandscape = 2 // Альбомный
        }

        //УСТАНОВКА ОРИЕНТАЦИИ СТРАНИЦЫ
        public void SetOrientation(XlPageOrientation Orientation)
        {
            //Range.Interior.ColorIndex
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                null, WorkSheet, null);

            PageSetup.GetType().InvokeMember("Orientation", BindingFlags.SetProperty,
                null, PageSetup, new object[] { 2 });
        }

        //УСТАНОВКА РАЗМЕРОВ ПОЛЕЙ ЛИСТА
        public void SetMargin(double Left, double Right, double Top, double Bottom)
        {
            //Range.PageSetup.LeftMargin - ЛЕВОЕ
            //Range.PageSetup.RightMargin - ПРАВОЕ 
            //Range.PageSetup.TopMargin - ВЕРХНЕЕ
            //Range.PageSetup.BottomMargin - НИЖНЕЕ
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                null, WorkSheet, null);

            PageSetup.GetType().InvokeMember("LeftMargin", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Left });
            PageSetup.GetType().InvokeMember("RightMargin", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Right });
            PageSetup.GetType().InvokeMember("TopMargin", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Top });
            PageSetup.GetType().InvokeMember("BottomMargin", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Bottom });
        }

        //РАЗМЕРЫ ЛИСТА
        public enum xlPaperSize
        {
            xlPaperA4 = 9,
            xlPaperA4Small = 10, 
            xlPaperA5 = 11,
            xlPaperLetter = 1,
            xlPaperLetterSmall = 2,
            xlPaper10x14 = 16,
            xlPaper11x17 = 17,
            xlPaperA3 = 9,
            xlPaperB4 = 12,
            xlPaperB5 = 13,
            xlPaperExecutive = 7,
            xlPaperFolio = 14,
            xlPaperLedger = 4,
            xlPaperLegal = 5,
            xlPaperNote = 18,
            xlPaperQuarto = 15,
            xlPaperStatement = 6,
            xlPaperTabloid = 3
        }

        //УСТАНОВКА РАЗМЕРА ЛИСТА
        public void SetPaperSize(xlPaperSize Size)
        {
            //Range.PageSetup.PaperSize - РАЗМЕР ЛИСТА
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                null, WorkSheet, null);

            PageSetup.GetType().InvokeMember("PaperSize", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Size });
        }

        //УСТАНОВКА МАСШТАБА ПЕЧАТИ
        public void SetZoom(int Percent)
        {
            //Range.PageSetup.Zoom - МАСШТАБ ПЕЧАТИ
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                null, WorkSheet, null);

            PageSetup.GetType().InvokeMember("Zoom", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Percent });
        }

        //ПЕРЕИМЕНОВАТЬ ЛИСТ
        public void ReNamePage(int n, string Name)
        {
            //Range.Interior.ColorIndex
            object Page = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { n });

            Page.GetType().InvokeMember("Name", BindingFlags.SetProperty,
                null, Page, new object[] { Name });
        }

        //ДОБАВЛЕНИЕ ЛИСТА
        public void AddNewPage(string Name)
        {
            //Worksheet.Add.Item
            //Name - Название страницы
            WorkSheet = WorkSheets.GetType().InvokeMember("Add", BindingFlags.GetProperty, null, WorkSheets, null);

            object Page = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            Page.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, Page, new object[] { Name });
        }

        //ПРИМЕНЕНИЕ ШРИФТА К ЯЧЕЙКЕ
        public void SetFont(string range, Font font)
        {
            //Range.Font.Name
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });

            object Font = Range.GetType().InvokeMember("Font", BindingFlags.GetProperty,
                null, Range, null);

            Range.GetType().InvokeMember("Name", BindingFlags.SetProperty, null,
                Font, new object[] { font.Name });

            Range.GetType().InvokeMember("Size", BindingFlags.SetProperty, null,
                Font, new object[] { font.Size });
        }

        //ЗАПИСЬ ЗНАЧЕНИЯ В ЯЧЕЙКУ
        public void SetValue(string range, string value)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            Range.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range, new object[] { value });
        }

        //ОБЪЕДИНЕНИЕ ЯЧЕЕК
        public void SetMerge(string range, bool MergeCells)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            Range.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, Range, new object[] { MergeCells });
        }

        //УСТАНОВКА ШИРИНЫ СТОЛБЦОВ
        public void SetColumnWidth(string range, double Width)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Width };
            Range.GetType().InvokeMember("ColumnWidth", BindingFlags.SetProperty, null, Range, args);
        }

        //УСТАНОВКА НАПРАВЛЕНИЯ ТЕКСТА
        public void SetTextOrientation(string range, int Orientation)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Orientation };
            Range.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, null, Range, args);
        }

        //ВЫРАСНИВАНИЕ ТЕКСТА В ЯЧЕЙКЕ ПО ВЕРТИКАЛИ
         public void SetVerticalAlignment(string range, int Alignment)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Alignment };
            Range.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty, null, Range, args);
        }

        //ВЫРАВНИВАНИЕ ТЕКСТА В ЯЧЕЙКЕ ПО ГОРИЗОНТАЛИ
        public void SetHorisontalAlignment(string range, int Alignment)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Alignment };
            Range.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, Range, args);
        }


        //ФОРМАТИРОВАНИЕ УКАЗАННОГО ТЕКСТА В ЯЧЕЙКЕ
        public void SelectText(string range, int Start, int Length, int Color, string FontStyle, int FontSize)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Start, Length };
            object Characters = Range.GetType().InvokeMember("Characters", BindingFlags.GetProperty, null, Range, args);
            object Font = Characters.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, Characters, null );
            Font.GetType().InvokeMember("ColorIndex", BindingFlags.SetProperty, null, Font, new object[] { Color });
            Font.GetType().InvokeMember("FontStyle", BindingFlags.SetProperty, null, Font, new object[] { FontStyle });
            Font.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, Font, new object[] { FontSize });

        }

        //ПЕРЕНОС СЛОВ В ЯЧЕЙКЕ
        public void SetWrapText(string range, bool Value)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Value };
            Range.GetType().InvokeMember("WrapText", BindingFlags.SetProperty, null, Range, args);
        }

        //УСТАНОВКА ВЫСОТЫ СТРОКИ
        public void SetRowHeight(string range, double Height)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Height };
            Range.GetType().InvokeMember("RowHeight", BindingFlags.SetProperty, null, Range, args);
        }

        //УСТАНОВКА ВИДА ГРАНИЦ
        public void SetBorderStyle(string range, int Style)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { 1 };
            object[] args1 = new object[] { 1 };
            object Borders = Range.GetType().InvokeMember("Borders", BindingFlags.GetProperty, null, Range, null);
            Borders = Range.GetType().InvokeMember("LineStyle", BindingFlags.SetProperty, null, Borders, args);
        } 

        //ЧТЕНИЕ ЗНАЧЕНИЯ ИЗ ЯЧЕЙКИ
        public string GetValue(string range)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            try
            {
                return Range.GetType().InvokeMember("Value", BindingFlags.GetProperty,
                null, Range, null).ToString();
            }
            catch
            {
                return null;    
            }
            
        }

        //УНИЧТОЖЕНИЕ ОБЪЕКТА EXCEL
        public void Dispose()
        {
            Marshal.ReleaseComObject(oExcel);
            GC.GetTotalMemory(true);
        }
    }
}
