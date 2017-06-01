using System;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Learn.Chap04

{
    public class Chap0402
{

    public static void Main()
    {

        Console.WriteLine("Chapter 4 example 2: Chapters and Sections");

        // step 1: creation of a document-object
        Document document = new Document(PageSize.A4, 50, 50, 50, 50);
        try
        {
            // step 2: we create a writer that listens to the document
            /*PdfWriter writer = */PdfWriter.getInstance(document, new FileStream("Chap0402.pdf", FileMode.Create));
            // step 3: we open the document
            document.Open();
            // step 4: we Add content to the document
            // we define some fonts
            Font chapterFont = FontFactory.getFont(FontFactory.HELVETICA, 24, Font.NORMAL, new Color(255, 0, 0));
            Font sectionFont = FontFactory.getFont(FontFactory.HELVETICA, 20, Font.NORMAL, new Color(0, 0, 255));
            Font subsectionFont = FontFactory.getFont(FontFactory.HELVETICA, 18, Font.BOLD, new Color(0, 64, 64));
            // we create some paragraphs
            Paragraph blahblah = new Paragraph("blah blah blah blah blah blah blaah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah");
            Paragraph blahblahblah = new Paragraph("blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blaah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah");
            // this loop will create 7 chapters
            for (int i = 1; i < 8; i++)
            {
                Paragraph cTitle = new Paragraph("This is chapter " + i, chapterFont);
                Chapter chapter = new Chapter(cTitle, i);

                if (i == 4)
                {
                    blahblahblah.Alignment = Element.ALIGN_JUSTIFIED;
                    blahblah.Alignment = Element.ALIGN_JUSTIFIED;
                    chapter.Add(blahblah);
                }
                if (i == 5)
                {
                    blahblahblah.Alignment = Element.ALIGN_CENTER;
                    blahblah.Alignment = Element.ALIGN_RIGHT;
                    chapter.Add(blahblah);
                }
                // Add a table in the 6th chapter
                if (i == 6)
                {
                    blahblah.Alignment = Element.ALIGN_JUSTIFIED;
                }
                // in every chapter 3 sections will be Added
                for (int j = 1; j < 4; j++)
                {
                    Paragraph sTitle = new Paragraph("This is section " + j + " in chapter " + i, sectionFont);
                    Section section = chapter.addSection(sTitle, 1);
                    // in all chapters except the 1st one, some extra text is Added to section 3
                    if (j == 3 && i > 1)
                    {
                        section.Add(blahblah);
                    }
                    // in every section 3 subsections are Added
                    for (int k = 1; k < 4; k++)
                    {
                        Paragraph subTitle = new Paragraph("This is subsection " + k + " of section " + j, subsectionFont);
                        Section subsection = section.addSection(subTitle, 3);
                        if (k == 1 && j == 3)
                        {
                            subsection.Add(blahblahblah);
                        }
                        subsection.Add(blahblah);
                    }
                    if (j == 2 && i > 2)
                    {
                        section.Add(blahblahblah);
                    }
                }
                document.Add(chapter);
            }
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

            System.Diagnostics.Process.Start("Chap0402.pdf");
        }
    }
}