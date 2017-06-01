﻿using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap01
{
    public class Chap0108
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 1 example 8: Viewerpreferences");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {

                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file

                PdfWriter writerA = PdfWriter.getInstance(document, new FileStream("Chap0108a.pdf", FileMode.Create));
                writerA.setViewerPreferences(PdfWriter.PageLayoutTwoColumnLeft);
                PdfWriter writerB = PdfWriter.getInstance(document, new FileStream("Chap0108b.pdf", FileMode.Create));
                writerB.setViewerPreferences(PdfWriter.HideMenubar | PdfWriter.HideToolbar);
                PdfWriter writerC = PdfWriter.getInstance(document, new FileStream("Chap0108c.pdf", FileMode.Create));
                writerC.setViewerPreferences(PdfWriter.PageLayoutTwoColumnLeft | PdfWriter.PageModeFullScreen | PdfWriter.NonFullScreenPageModeUseThumbs);

                // step 3:

                // we Add a Watermark that will show up on PAGE 1
                try
                {
                    Watermark watermark = new Watermark(Image.getInstance("watermark.jpg"), 200, 420);
                    document.Add(watermark);
                }
                catch
                {
                    Console.Error.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
                }

                // we Add a Header that will show up on PAGE 1
                HeaderFooter header = new HeaderFooter(new Phrase("This is a header"), false);
                document.Header = header;

                // we open the document
                document.Open();

                // we rotate the page, starting from PAGE 2
                document.setPageSize(PageSize.A4.rotate());

                // we need to change the position of the Watermark
                try
                {
                    Watermark watermark = new Watermark(Image.getInstance("watermark.jpg"), 320, 200);
                    document.Add(watermark);
                }
                catch
                {
                    Console.Error.WriteLine("Are you sure you have the file 'watermark.jpg' in the right path?");
                }

                // we Add a Footer that will show up on PAGE 2
                HeaderFooter footer = new HeaderFooter(new Phrase("This is page: "), true);
                document.Footer = footer;

                // step 4: we Add content to the document

                // PAGE 1

                document.Add(new Paragraph("Hello World"));

                // we trigger a page break
                document.newPage();

                // PAGE 2

                // we Add some more content
                document.Add(new Paragraph("Hello Earth"));

                // we remove the header starting from PAGE 3
                document.resetHeader();

                // we trigger a page break
                document.newPage();

                // PAGE 3

                // we Add some more content
                document.Add(new Paragraph("Hello Sun"));
                document.Add(new Paragraph("Remark: the header has vanished!"));

                // we reset the page numbering
                document.resetPageCount();

                // we trigger a page break
                document.newPage();

                // PAGE 4

                // we Add some more content
                document.Add(new Paragraph("Hello Moon"));
                document.Add(new Paragraph("Remark: the pagenumber has been reset!"));

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

            System.Diagnostics.Process.Start("Chap0108.pdf");
        }
    }
}