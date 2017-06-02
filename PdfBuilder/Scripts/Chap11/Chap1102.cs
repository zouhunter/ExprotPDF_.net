using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap11
{
    public class Chap1102
    {

        public static void Main()
        {
            Console.WriteLine("Chapter 11 example 2: anchor and remote goto");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter writerA = PdfWriter.getInstance(document, new FileStream("Chap1102a.pdf", FileMode.Create));
                PdfWriter writerB = PdfWriter.getInstance(document, new FileStream("Chap1102b.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we add some content

                Paragraph p1 = new Paragraph("We discussed anchors in chapter 3, but you can add an URL to a chunk to to make it an ", FontFactory.getFont(FontFactory.HELVETICA, 12));
                p1.Add(new Chunk("anchor", FontFactory.getFont(FontFactory.HELVETICA, 12, Font.UNDERLINE, new Color(0, 0, 255))).setAnchor(new Uri("http://iTextSharp.sourceforge.net")));
                p1.Add(" you will automatically jump to another location in this document.");
                Paragraph p2 = new Paragraph("blah, blah, blah");
                Paragraph p3a = new Paragraph("This paragraph contains a ");
                p3a.Add(new Chunk("local destination in document A", FontFactory.getFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 255, 0))).setLocalDestination("test"));
                Paragraph p3b = new Paragraph("This paragraph contains a local ");
                p3b.Add(new Chunk("local destination in document B", FontFactory.getFont(FontFactory.HELVETICA, 12, Font.NORMAL, new Color(0, 255, 0))).setLocalDestination("test"));
                Paragraph p4a = new Paragraph(new Chunk("Click this paragraph to go to a certain destination on document B").setRemoteGoto("Chap1102b.pdf", "test"));
                Paragraph p4b = new Paragraph(new Chunk("Click this paragraph to go to a certain destination on document A").setRemoteGoto("Chap1102a.pdf", "test"));
                Paragraph p5a = new Paragraph("you can also jump to a ");
                p5a.Add(new Chunk("specific page on another document", FontFactory.getFont(FontFactory.HELVETICA, 12, Font.ITALIC)).setRemoteGoto("Chap1102b.pdf", 3));
                document.Add(p1);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                writerA.Pause();
                document.Add(p4b);
                writerA.resume();
                writerB.Pause();
                document.Add(p4a);
                document.Add(p5a);
                writerB.resume();
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                document.Add(p2);
                writerA.Pause();
                document.Add(p3b);
                document.Add(p2);
                document.Add(p2);
                document.newPage();
                document.Add(p2);
                document.Add(p2);
                document.newPage();
                writerA.resume();
                writerB.Pause();
                document.Add(p3a);
                writerB.resume();
                document.Add(p2);
                document.Add(p2);
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

            // step 5: we close the document
            document.Close();


            System.Diagnostics.Process.Start("Chap1102a.pdf");
        }
    }


}