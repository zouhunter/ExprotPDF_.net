using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap04
{
    public class Chap0401
{

    public static void Main()
    {

        Console.WriteLine("Chapter 4 example 1: Headers en Footers");

        // step 1: creation of a document-object
        Document document = new Document();

        try
        {
            // step 2: we create a writer that listens to the document
            PdfWriter.getInstance(document, new FileStream("Chap0401.pdf", FileMode.Create));

            // we Add a Footer that will show up on PAGE 1
            HeaderFooter footer = new HeaderFooter(new Phrase("This is page: "), true);
            footer.Border = Rectangle.NO_BORDER;
            document.Footer = footer;

            // step 3: we open the document
            document.Open();

            // we Add a Header that will show up on PAGE 2
            HeaderFooter header = new HeaderFooter(new Phrase("This is a header"), false);
            document.Header = header;

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

            System.Diagnostics.Process.Start("Chap0401.pdf");
        }
    }
}