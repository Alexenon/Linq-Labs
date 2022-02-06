using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp.Lab4
{
    class Lab_4
    {
        public static void mainMethod()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D:/Alex/Programming/C#/ConsoleApp/Lab4/xmlFile.xml");

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {

                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "company")
                    {
                        Console.WriteLine($"Numele companiei: {childnode.InnerText}");
                    }
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine($"Varsta: {childnode.InnerText}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
