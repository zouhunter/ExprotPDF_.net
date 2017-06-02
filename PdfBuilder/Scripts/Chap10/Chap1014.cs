using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap10
{
    public class Chap1014
    {
        public static void Main()
        {
            Console.WriteLine("Chapter 10 Example 14: colored patterns");

            // step 1: creation of a document-object
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            Document.compress = false;
            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1014.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we add some content
                PdfContentByte cb = writer.DirectContent;
                PdfTemplate tp = cb.createTemplate(400, 300);
                PdfPatternPainter pat = cb.createPattern(15, 15, null);
                pat.rectangle(5, 5, 5, 5);
                pat.fill();
                PdfSpotColor spc_cmyk = new PdfSpotColor("PANTONE 280 CV", 0.25f, new CMYKColor(0.9f, .2f, .3f, .1f));
                SpotColor spot = new SpotColor(spc_cmyk);
                tp.setPatternFill(pat, spot, .9f);
                tp.rectangle(0, 0, 400, 300);
                tp.fill();
                cb.addTemplate(tp, 50, 50);
                PdfPatternPainter pat2 = cb.createPattern(10, 10, null);
                pat2.LineWidth = 2;
                pat2.moveTo(-5, 0);
                pat2.lineTo(10, 15);
                pat2.stroke();
                pat2.moveTo(0, -5);
                pat2.lineTo(15, 10);
                pat2.stroke();
                cb.LineWidth = 1;
                cb.ColorStroke = new Color(System.Drawing.Color.Black);
                cb.setPatternFill(pat2, new Color(System.Drawing.Color.Red));
                cb.rectangle(100, 400, 30, 210);
                cb.fillStroke();
                cb.setPatternFill(pat2, new Color(System.Drawing.Color.LightGreen));
                cb.rectangle(150, 400, 30, 100);
                cb.fillStroke();
                cb.setPatternFill(pat2, new Color(System.Drawing.Color.Blue));
                cb.rectangle(200, 400, 30, 130);
                cb.fillStroke();
                cb.setPatternFill(pat2, new GrayColor(0.5f));
                cb.rectangle(250, 400, 30, 80);
                cb.fillStroke();
                cb.setPatternFill(pat2, new GrayColor(0.7f));
                cb.rectangle(300, 400, 30, 170);
                cb.fillStroke();
                cb.setPatternFill(pat2, new GrayColor(0.9f));
                cb.rectangle(350, 400, 30, 40);
                cb.fillStroke();
            }
            catch (Exception de)
            {
                Console.Error.WriteLine(de.Message);
                Console.Error.WriteLine(de.StackTrace);
            }
            // step 5: we close the document
            document.Close();

            System.Diagnostics.Process.Start("Chap1014.pdf");
        }
    }


}