using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Learn.Chap10
{

    public class Chap1003
    {

        public static void Main()
        {

            Console.WriteLine("Chapter 10 example 3: Templates");

            // step 1: creation of a document-object
            Document document = new Document();

            try
            {
                // step 2:
                // we create a writer that listens to the document
                // and directs a PDF-stream to a file
                PdfWriter writer = PdfWriter.getInstance(document, new FileStream("Chap1003.pdf", FileMode.Create));

                // step 3: we open the document
                document.Open();

                // step 4: we grab the ContentByte and do some stuff with it
                PdfContentByte cb = writer.DirectContent;

                // we create a PdfTemplate
                PdfTemplate template = cb.createTemplate(500, 200);

                // we add some graphics
                template.moveTo(0, 200);
                template.lineTo(500, 0);
                template.stroke();
                template.setRGBColorStrokeF(255f, 0f, 0f);
                template.circle(250f, 100f, 80f);
                template.stroke();

                // we add some text
                template.beginText();
                BaseFont bf = BaseFont.createFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                template.setFontAndSize(bf, 12);
                template.setTextMatrix(100, 100);
                template.showText("Text at the position 100,100 (relative to the template!)");
                template.endText();

                // we add the template on different positions
                cb.addTemplate(template, 0, 0);
                cb.addTemplate(template, 0, 1, -1, 0, 500, 200);
                cb.addTemplate(template, .5f, 0, 0, .5f, 100, 400);

                // we go to a new page
                document.newPage();
                cb.addTemplate(template, 0, 400);
                cb.addTemplate(template, 2, 0, 0, 2, -200, 400);
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

            System.Diagnostics.Process.Start("Chap1003.pdf");
        }

    }
}