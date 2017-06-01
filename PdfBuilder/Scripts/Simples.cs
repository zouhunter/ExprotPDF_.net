using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;

public class Simples{
    public string[][] chapKeys;
    public Simples()
    {
        chapKeys = new string[5][];
        chapKeys[0] = new string[] { "1.HelloWorld", "2.Rectangle", "3.Rectangle", "4.Margins",  "5.","6.Meta Information", "7.newPage","8.Viewerpreferences","9.encryption","10.encryption","11.pause"};
        chapKeys[1] = new string[] { "1.Chunks and fonts", "2.Phrases", "3.Greek Characters", "4.Negative leading", "5.Paragraphs", "6. keeping a paragraph together", "7.font propagation", "8.split character" };
        chapKeys[2] = new string[] { "1.Anchors", "2.Lists", "3.Annotations", "4.absolute positions" };
        chapKeys[3] = new string[] { "1.Headers en Footers", "2.Chapters and Sections", "3.Chapters and Sections", "4.Simple Graphic", "5.page borders and horizontal lines" };
        chapKeys[4] = new string[] { "1.simple table", "2.adding cells at a specific position" };
    }
    public void Start(int chapter)
    {
        string chapterName = "Chap" + string.Format("{0:00}", chapter + 1);
        string keys = string.Join("\n", chapKeys[chapter]);
        Console.WriteLine("可选择列表：\n" + keys);
        Console.ReadLine();
        //列出信息列表
        string id = Console.ReadLine();
        string className = chapterName + string.Format("{0:00}",int.Parse(id));
        Console.WriteLine("你选择了" + chapterName + "-->" + className);
        LunchClass("Learn." + chapterName, className);
        Console.ReadKey();
    }
    public void LunchClass(string namespaceName,string className)
    {
        Type type =Type.GetType(namespaceName + "." + className);
        type.GetMethod("Main").Invoke(null,null);
    }
}
