using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap05
{
    public class Chap0513
    {
        public static void Main()
        {
            Console.WriteLine("Chapter 5 example 13: large tables with fitspage");
            // creation of the document with a certain size and certain margins
            Document document = new Document(PageSize.A4.rotate(), 50, 50, 50, 50);

            try
            {
                // creation of the different writers
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap0513.pdf", FileMode.Create));

                // we add some meta information to the document
                document.addAuthor("Alan Soukup");
                document.addSubject("This is the result of a Test.");

                document.Open();

                Table datatable = getTable();

                for (int i = 1; i < 30; i++)
                {

                    datatable.DefaultHorizontalAlignment = Element.ALIGN_LEFT;

                    datatable.addCell("myUserId");
                    datatable.addCell("Somebody with a very, very, very, very, very, very, very, very, very, very, very, very, very, very, very, very, very long long name");
                    datatable.addCell("No Name Company");
                    datatable.addCell("D" + i);

                    datatable.DefaultHorizontalAlignment = Element.ALIGN_CENTER;
                    datatable.addCell("No");
                    datatable.addCell("Yes");
                    datatable.addCell("No");
                    datatable.addCell("Yes");
                    datatable.addCell("No");
                    datatable.addCell("Yes");

                    if (!writer.fitsPage(datatable))
                    {
                        datatable.deleteLastRow();
                        i--;
                        document.Add(datatable);
                        document.newPage();
                        datatable = getTable();
                    }

                }


                document.Add(datatable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            // we close the document
            document.Close();

            System.Diagnostics.Process.Start("Chap0513.pdf");
        }

        private static Table getTable()
        {
            Table datatable = new Table(10);

            datatable.Padding = 4;
            datatable.Spacing = 0;
            //datatable.setBorder(Rectangle.NO_BORDER);
            float[] headerwidths = { 10, 24, 12, 12, 7, 7, 7, 7, 7, 7 };
            datatable.Widths = headerwidths;
            datatable.WidthPercentage = 100;

            // the first cell spans 10 columns
            Cell cell = new Cell(new Phrase("Administration -System Users Report", FontFactory.getFont(FontFactory.HELVETICA, 24, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Leading = 30;
            cell.Colspan = 10;
            cell.Border = Rectangle.NO_BORDER;
            cell.BackgroundColor = new Color(0xC0, 0xC0, 0xC0);
            datatable.addCell(cell);

            // These cells span 2 rows
            datatable.DefaultCellBorderWidth = 2;
            datatable.DefaultHorizontalAlignment = 1;
            datatable.DefaultRowspan = 2;
            datatable.addCell("User Id");
            datatable.addCell(new Phrase("Name", FontFactory.getFont(FontFactory.HELVETICA, 14, Font.BOLD)));
            datatable.addCell("Company");
            datatable.addCell("Department");

            // This cell spans the remaining 6 columns in 1 row
            datatable.DefaultRowspan = 1;
            datatable.DefaultColspan = 6;
            datatable.addCell("Permissions");

            // These cells span 1 row and 1 column
            datatable.DefaultColspan = 1;
            datatable.addCell("Admin");
            datatable.addCell("Data");
            datatable.addCell("Expl");
            datatable.addCell("Prod");
            datatable.addCell("Proj");
            datatable.addCell("Online");

            datatable.DefaultCellBorderWidth = 1;
            datatable.DefaultRowspan = 1;

            return datatable;
        }
    }


}