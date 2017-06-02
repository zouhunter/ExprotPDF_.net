﻿using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap05
{
    public class Chap0515
    {

        public static void Main()
        {
            Console.WriteLine("Chapter 5 example 15: nested tables");
            // step 1: creation of a document-object
            Document document = new Document();
            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter.getInstance(document, new FileStream("Chap0515.pdf", FileMode.Create));
                // step 3: we open the document
                document.Open();
                // step 4: we create a table and add it to the document           
                Table secondTable = new Table(2);
                secondTable.addCell("2.0.0");
                secondTable.addCell("2.0.1");
                secondTable.addCell("2.1.0");
                secondTable.addCell("2.1.1");
                Cell tableCell = new Cell(secondTable);

                Table aTable = new Table(3, 3);    // 3 rows, 3 columns
                aTable.addCell("0.0", new Point(0, 0));
                aTable.addCell("0.1", new Point(0, 1));
                aTable.addCell("0.2", new Point(0, 2));
                aTable.addCell("0.0", new Point(1, 0));
                aTable.addCell(tableCell, new Point(1, 1));
                aTable.addCell("2.2", new Point(1, 2));
                aTable.addCell("2.0", new Point(2, 0));
                aTable.addCell("2.1", new Point(2, 1));
                aTable.addCell("2.2", new Point(2, 2));
                document.Add(aTable);
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            // step 5: we close the document
            document.Close();


            System.Diagnostics.Process.Start("Chap0515.pdf");
        }
    }


}