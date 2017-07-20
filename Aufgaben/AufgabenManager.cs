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
                Aufgabe aufgabe = new Aufgabe(id, name);
                XmlNodeList values = task.ChildNodes;
                foreach(XmlNode value in values)
                {
                    switch (value.Name)
                    {
                        case "annahme":
                            aufgabe.AnnahmeDatum = Convert.ToDateTime(value.Value);
                            break;
                        case "abgabe":
                            break;
                        case "parent":
                            break;
                        case "konakt":
                            break;
                        case "status":
                            break;
                        case "zeitaufwand":
                            break;
                        case "subtasks":
                            break;

                        default:
                            break;
                    }
                    
                }
               
            }
        }

        private void SaveNewTasks(Aufgabe task)
        {
            XmlNode root = document.SelectSingleNode("aufgaben");
            XmlNode nodeToAdd = document.CreateElement("aufgabe");
            nodeToAdd.Attributes.Append(document.CreateAttribute("id"));
            nodeToAdd.Attributes.Append(document.CreateAttribute("name"));
            nodeToAdd.Attributes[0].Value = task.ID.ToString();
            nodeToAdd.Attributes[1].Value = task.Name;
            nodeToAdd.AppendChild(document.CreateElement("annahme"));
            nodeToAdd.AppendChild(document.CreateElement("abgabe"));
            nodeToAdd.AppendChild(document.CreateElement("parent"));
            nodeToAdd.AppendChild(document.CreateElement("kontakt"));
            nodeToAdd.AppendChild(document.CreateElement("status"));
            nodeToAdd.AppendChild(document.CreateElement("zeitaufwand"));
            nodeToAdd.AppendChild(document.CreateElement("subtasks"));
            foreach(Aufgabe subTask in task.ChildTasks)
            {
                XmlNode childTask = document.CreateElement("subtask");
                XmlAttribute attri = document.CreateAttribute("id");
                attri.Value = subTask.ID.ToString();
                childTask.Attributes.Append(attri);
                attri = document.CreateAttribute("name");
                attri.Value = subTask.Name;
                childTask.Attributes.Append(attri);
                nodeToAdd.LastChild.AppendChild(childTask);
                
            }

            root.AppendChild(nodeToAdd);
            document.Save(pathToXML);
        }

        public Aufgabe GetAufgabeByName(string name)
        {
            Aufgabe returnValue = aufgaben.Find(a => a.Name == name);
            if(returnValue is null)
            {
                throw new Exception("Keine Aufgabe mit dem Namen " + name + " gefunden.");
            }
            return returnValue;
        }
        public 
      
    }
}
