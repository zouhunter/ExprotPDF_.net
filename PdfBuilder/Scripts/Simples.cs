using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;

public class Simples
{
    public string[][] chapKeys;
    public Simples()
    {
        chapKeys = new string[11][];
        chapKeys[0] = new string[] { "1:HelloWorld", "2:Rectangle", "3:Rectangle", "4:Margins", "5:", "6:Meta Information", "7:newPage", "8:Viewerpreferences", "9:encryption", "10:encryption", "11:pause" };
        chapKeys[1] = new string[] { "1:Chunks and fonts", "2:Phrases", "3:Greek Characters", "4:Negative leading", "5:Paragraphs", "6: keeping a paragraph together", "7:font propagation", "8:split character" };
        chapKeys[2] = new string[] { "1:Anchors", "2:Lists", "3:Annotations", "4:absolute positions" };
        chapKeys[3] = new string[] { "1:Headers en Footers", "2:Chapters and Sections", "3:Chapters and Sections", "4:Simple Graphic", "5:page borders and horizontal lines" };
        chapKeys[4] = new string[] { "1:simple table", "2:adding cells at a specific position", "3:rows added automatically", "4:adding columns", "5: colspan, rowspan, padding, spacing, colors", "6: spacing, padding, alignment", "7: borders", "8: table splitting", "9: large tables", "10: large tables with repeating headers", "11: avoid table splitting", "12: avoid cell splitting", "13: large tables with fitspage", "14: nested tables", "15: nested tables", "16: nested tables", "17: table offset", "18: PdfPTable" };
        chapKeys[5] = new string[] { "1: Adding a Wmf, Gif, Jpeg and Png-file using urls", "2: Adding a Wmf, Gif, Jpeg and Png-file using filenames", "3: ", "4: Alignment of images", "5: Alignment of images", "6: Absolute Positioning of an Image", "7: Scaling an Image", "8: Rotating an Image", "9: bytes() / Raw Image", "10: Images using System.Drawing.Bitmap", "11:FrameDimension", "13: masked images", "14: images wrapped in a Chunk", "15: images in tables", "16: images and annotations" };
        chapKeys[6] = new string[] { "2: parsing the result of example 1" };
        chapKeys[7] = new string[] { "1.RtfWriter", "2: Headers in RTF", "3: RTF with the RtfHeaderFooters class", "4: Tables and RTF" };
        chapKeys[8] = new string[] { "1.Font Test" };
        chapKeys[9] = new string[] { "2: Text at absolute positions", "3: Templates", "4: Templates", "5: Simple Columns", "6: Simple Columns", "7: Columns", "8: Irregular columns", "9: a PdfPTable at an absolute position", "10: nested PdfPTables", "11: a PdfPTable in a template", "12: PdfPTables and columns", "13: Spot Color", "14: colored patterns", "15: Tiled Patterns" };
        chapKeys[10] = new string[] { "1: local goto", "2: anchor and remote goto" };
    }

    public void Start(int chapter)
    {
        if (chapter >= chapKeys.Length || chapter <= 0) return;
        string chapterName = "Chap" + string.Format("{0:00}", chapter);
        string keys = string.Join("\n", chapKeys[chapter - 1]);
        Console.WriteLine("可选择列表：\n" + keys);
        //列出信息列表
        string id = Console.ReadLine();
        try
        {
            string className = chapterName + string.Format("{0:00}", int.Parse(id));
            Console.WriteLine("你选择了" + chapterName + "-->" + className);
            LunchClass("Learn." + chapterName, className);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }

    public void LunchClass(string namespaceName, string className)
    {
        Type type = Type.GetType(namespaceName + "." + className);
        type.GetMethod("Main").Invoke(null, null);
    }
}
