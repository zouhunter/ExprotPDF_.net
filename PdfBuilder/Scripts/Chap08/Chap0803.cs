using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.rtf;

namespace Learn.Chap08
{

    public class Chap0803
    {
        public static void Main()
        {
            Console.WriteLine("Chapter 8 example 3: RTF with the RtfHeaderFooters class");
            /* Create a new document */
            Document document = new Document(PageSize.A4);
            try
            {
                /* Create a RtfWriter and a PdfWriter for the document */
                RtfWriter rtf = RtfWriter.getInstance(document, new FileStream("Chap0803.rtf", FileMode.Create));
                /* We specify that the RTF file has a Title Page */
                rtf.HasTitlePage = true;
                /* We create headers and footers for the RTF file */
                RtfHeaderFooters header = new RtfHeaderFooters();
                RtfHeaderFooters footer = new RtfHeaderFooters();
                /* We add a header that will only appear on the first page */
                header.Set(RtfHeaderFooters.FIRST_PAGE, new HeaderFooter(new Phrase("This header is only on the first page"), false));
                /* We add a header that will only appear on left-side pages */
                header.Set(RtfHeaderFooters.LEFT_PAGES, new HeaderFooter(new Phrase("This header is only on left pages"), false));
                /* We add a header that will only appear on right-side pages */
                header.Set(RtfHeaderFooters.RIGHT_PAGES, new HeaderFooter(new Phrase("This header is only on right pages. "), false));
                /* We add a footer that will appear on all pages except the first (because of the title page) 
                 * Because the header has different left and right page footers, we have to add the footer 
                 * to both the left and right pages. */
                footer.Set(RtfHeaderFooters.LEFT_PAGES, new HeaderFooter(new Phrase("This footer is on all pages except the first. Page: "), true));
                footer.Set(RtfHeaderFooters.RIGHT_PAGES, new HeaderFooter(new Phrase("This footer is on all pages except the first. Page: "), true));
                /* Open the document */
                document.Open();
                /* We add the header and footer */
                document.Header = header;
                document.Footer = footer;
                /* We add some content */
                Chapter chapter = new Chapter(new Paragraph("Advanced RTF headers and footers", new Font(Font.HELVETICA, 16, Font.BOLD)), 1);
                chapter.Add(new Paragraph("This document demonstrates the use of advanced RTF headers and footers."));
                for (int i = 0;
                    i < 300;
                    i++)
                {
                    chapter.Add(new Paragraph("Line " + i));
                }
                document.Add(chapter);
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            /* Close the document */
            document.Close();


            System.Diagnostics.Process.Start("Chap0803.rtf");
        }
    }

}