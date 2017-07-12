using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
namespace Aufgaben
{
    class AufgabenManager
    {
        List<Aufgabe> aufgaben;
        string pathToXML = @"C:\DTS\Projects\Aufgaben\Aufgaben\Aufgaben.xml";
        XmlDocument document;

        public AufgabenManager()
        {
            aufgaben = new List<Aufgabe>();
            document.Load(pathToXML);
        }
        
        private void Save()
        {
            document.Save(pathToXML);
        }
        private void LoadAufgaben()
        {
            XmlNodeList tasks = document.SelectNodes("aufgaben/aufgabe");

            foreach(XmlNode task in tasks)
            {
                string name = task.Attributes[1].Value;
                int id = Convert.ToInt32(task.Attributes[0].Value);
                
                XmlNodeList values = task.ChildNodes;
                foreach(XmlNode value in values)
                {
                    if(value.Name == "annahme") 
                }
                Aufgabe aufgabe;
            }
        }
    }
}
