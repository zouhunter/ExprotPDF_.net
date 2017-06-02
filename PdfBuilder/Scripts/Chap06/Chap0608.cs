﻿using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap06
{
    public class Chap0608
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 6 example 8: Rotating an Image");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file

                PdfWriter.getInstance(document, new FileStream("Chap0608.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we add content
                Image jpg = Image.getInstance("jpgPic.jpg");
                jpg.Alignment = Image.MIDDLE;

                jpg.setRotation((float)Math.PI / 6);
                document.Add(new Paragraph("rotate 30 degrees"));
                document.Add(jpg);
                document.newPage();

                jpg.setRotation((float)Math.PI / 4);
                document.Add(new Paragraph("rotate 45 degrees"));
                document.Add(jpg);
                document.newPage();

                jpg.setRotation((float)Math.PI / 2);
                document.Add(new Paragraph("rotate pi/2 radians"));
                document.Add(jpg);
                document.newPage();

                jpg.setRotation((float)(Math.PI * 0.75));
                document.Add(new Paragraph("rotate 135 degrees"));
                document.Add(jpg);
                document.newPage();

                jpg.setRotation((float)Math.PI);
                document.Add(new Paragraph("rotate pi radians"));
                document.Add(jpg);
                document.newPage();

                jpg.setRotation((float)(2.0 * Math.PI));
                document.Add(new Paragraph("rotate 2 x pi radians"));
                document.Add(jpg);
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


            System.Diagnostics.Process.Start("Chap0608.pdf");
        }
    }
}