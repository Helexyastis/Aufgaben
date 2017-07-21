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
        public List<Aufgabe> Aufgaben { get { return aufgaben; } }
        public static int ID { get; private set; }
        public AufgabenManager()
        {
            document = new XmlDocument();
            if (!System.IO.File.Exists(pathToXML))
            {
                System.IO.StreamWriter writer = System.IO.File.CreateText(pathToXML);
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                writer.WriteLine("<aufgaben>");
                writer.WriteLine("</aufgaben>");
                writer.Close();
            }
            aufgaben = new List<Aufgabe>();
            document.Load(pathToXML);
            LoadAufgaben();
            ID = aufgaben.Count;
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
                            aufgabe.AnnahmeDatum = Convert.ToDateTime(value.InnerText);
                            break;
                        case "abgabe":
                            aufgabe.AbgabeDatum = Convert.ToDateTime(value.InnerText);
                            break;
                        case "parent":
                            aufgabe.Partent = GetAufgabeByName(value.InnerText.Split(';')[1]);
                            break;
                        case "konakt":
                            aufgabe.Kontakt = value.InnerText;
                            break;
                        case "status":
                            aufgabe.Status = value.InnerText;
                            break;
                        case "zeitaufwand":
                            TimeSpan temp;
                            TimeSpan.TryParse(value.InnerText, out temp);
                            aufgabe.ZeitAufwand = temp;
                            break;
                        case "subtasks":
                            
                            break;

                        default:
                            break;
                    }
                    
                }
                aufgaben.Add(aufgabe);
               
            }
        }

        public void SaveNewTasks(Aufgabe task)
        {
            XmlNode root = document.SelectSingleNode("aufgaben");
            XmlNode nodeToAdd = document.CreateElement("aufgabe");
            
            nodeToAdd.Attributes.Append(document.CreateAttribute("id"));
            nodeToAdd.Attributes.Append(document.CreateAttribute("name"));
            nodeToAdd.Attributes[0].Value = task.ID.ToString();
            nodeToAdd.Attributes[1].Value = task.Name;
            nodeToAdd.AppendChild(CreateNodeWithValue("annahme",task.AnnahmeDatum.ToString()));
            nodeToAdd.AppendChild(CreateNodeWithValue("abgabe", task.AbgabeDatum.ToString()));
            if(task.Partent !=null)
                nodeToAdd.AppendChild(CreateNodeWithValue("parent", task.Partent.ID.ToString() + ";" + task.Partent.Name));
            nodeToAdd.AppendChild(CreateNodeWithValue("kontakt", task.Kontakt));
            nodeToAdd.AppendChild(CreateNodeWithValue("status", task.Status));
            nodeToAdd.AppendChild(CreateNodeWithValue("zeitaufwand", task.ZeitAufwand.ToString()));
            nodeToAdd.AppendChild(document.CreateElement("subtasks"));
            foreach(Aufgabe subTask in task.ChildTasks)
            {
                XmlNode childTask = CreateNodeWithValue("subtask", task.Partent.ID.ToString() + ";" + task.Partent.Name);
                nodeToAdd.LastChild.AppendChild(childTask);
                
            }
            root.AppendChild(nodeToAdd);
            if (task.Partent != null)
            {
                XmlNode parentNode = document.SelectNodes("aufgaben/aufgabe").Item(task.Partent.ID);
                XmlNode subNodes = parentNode.LastChild;
                subNodes.AppendChild(CreateNodeWithValue("subtask", task.ID.ToString() + ";" + task.Name));

            }
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
        private XmlNode CreateNodeWithValue(string nodeName,string value)
        {
            XmlNode outPut = document.CreateElement(nodeName);
            outPut.InnerText = value;
            return outPut;

        }
      
    }
}
