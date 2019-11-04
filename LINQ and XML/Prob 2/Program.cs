/*
Author: Amina Khan
Date: 10/30/2019
CTEC 135: Microsoft Software Development with C#
Module 6, Programming Assignment 5, Prob 2
  XML using LINQ
1.Create a static method that creates an XML document and saves it. See pages 3 and 10 in Appendix B
2.Create a static method that creates an XML document from an array and saves it. See page 12 in Appendix B
3.Create a static method that loads an XML document and prints it to the screen. You can load the doc created in 2 above. See page  13 in Appendix B. Note that all I am asking for is for you to load the document and print. You can ignore the parsing part of the book's example code.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Linq;

namespace Prob_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. creating XML doc
            CreateXMLDoc();

            // 2. Creating XML doc from an Array
            XmlDocFromArray();

            // 3. Load XML doc, and print it.
            LoadDoc();
        }


        #region 1. Method to create XML doc and save it
        public static void CreateXMLDoc()
        {
            // creating the document using LINQ
            XDocument doc =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("MyCats!"),
                    new XProcessingInstruction("xml-stylesheet",
            "href='MyStyles.css' title='Compact' type='text/css'"),
                    new XElement("AllCats",
                    // adding elements to the doc
                        new XElement("Cat", new XAttribute("ID", "1"),
                            new XElement("Name", "Banjo"),
                            new XElement("Age", "2"),
                            new XElement("Breed", "Tabby"),
                            new XElement("Color", "Brown")
                            ),
                        new XElement("Cat", new XAttribute("ID", "2"),
                            new XElement("Name", "Fefe"),
                            new XElement("Age", "10"),
                            new XElement("Breed", "Siamese"),
                            new XElement("Color", "White")
                            ),
                        new XElement("Cat", new XAttribute("ID", "3"),
                            new XElement("Name", "Franchesca"),
                            new XElement("Age", "5"),
                            new XElement("Breed", "Ragdoll"),
                            new XElement("Color", "Grey")
                            )
                        )
                    );

            // saving
            doc.Save("cats.xml");
        }
        #endregion

        #region 2. Static method, create XML doc from array
        static void XmlDocFromArray()
        {
            // creating an array
            var cats = new[] {
                new {ID = "1", Name = "Banjo", Age = "2", Breed = "Tabby", Color = "Brown"},
                new {ID = "2", Name = "Fefe", Age = "10", Breed = "Siamese", Color = "White"},
                new {ID = "3", Name = "Franchesca", Age = "5", Breed = "Ragdoll", Color = "Grey"}
            };

            // creating XML document using cats array
            XElement catsDoc = new XElement("AllMyCats",
                    from c in cats select new XElement("Cat", new XAttribute("ID", c.ID), new XElement("Name", c.Name), new XElement("Age", c.Age), new XElement("Breed", c.Breed), new XElement("Color", c.Color)));
            
            Console.WriteLine(catsDoc);

            // saving
            catsDoc.Save("cats2.xml");
        }


        #endregion

        #region 3. Load XML doc and print it to screen
        
        public static void LoadDoc()
        {
            // loading document on screen
            XDocument myCats2 = XDocument.Load("cats2.xml");

            // printing doc to screen
            Console.WriteLine(myCats2);
        }

        #endregion



    }
}
