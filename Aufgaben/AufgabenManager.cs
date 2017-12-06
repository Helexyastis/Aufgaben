using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
namespace Aufgaben
{
    public class AufgabenManager
    {


        List<Aufgabe> aufgaben;
        string pathToXML = Environment.CurrentDirectory + @"\Aufgaben.xml"; // @"C:\DTS\Projects\Aufgaben\Aufgaben\Aufgaben.xml";
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

            foreach (XmlNode task in tasks)
            {
                string name = task.Attributes[1].Value;
                int id = Convert.ToInt32(task.Attributes[0].Value);
                Aufgabe aufgabe = new Aufgabe(id, name);
                XmlNodeList values = task.ChildNodes;
                foreach (XmlNode value in values)
                {
                    switch (value.Name)
                    {
                        case "beschreibung":
                            aufgabe.Beschreibung = value.InnerText;
                            break;
                        case "annahme":
                            aufgabe.AnnahmeDatum = Convert.ToDateTime(value.InnerText);
                            break;
                        case "abgabe":
                            aufgabe.AbgabeDatum = Convert.ToDateTime(value.InnerText);
                            break;
                        case "parent":
                            aufgabe.Parent = GetAufgabeByName(value.InnerText.Split(';')[1]);
                            break;
                        case "kontakt":
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
                aufgabe.SetZeitStatus();
                aufgaben.Add(aufgabe);

            }
            SortAufgaben("dueDate");
        }

        public void SaveNewTasks(Aufgabe task)
        {
            XmlNode root = document.SelectSingleNode("aufgaben");
            XmlNode nodeToAdd = document.CreateElement("aufgabe");

            nodeToAdd.Attributes.Append(document.CreateAttribute("id"));
            nodeToAdd.Attributes.Append(document.CreateAttribute("name"));
            nodeToAdd.Attributes[0].Value = task.ID.ToString();
            nodeToAdd.Attributes[1].Value = task.Name;
            nodeToAdd.AppendChild(CreateNodeWithValue("beschreibung", task.Beschreibung));
            nodeToAdd.AppendChild(CreateNodeWithValue("annahme", task.AnnahmeDatum.ToString()));
            nodeToAdd.AppendChild(CreateNodeWithValue("abgabe", task.AbgabeDatum.ToString()));
            if (task.Parent != null)
                nodeToAdd.AppendChild(CreateNodeWithValue("parent", task.Parent.ID.ToString() + ";" + task.Parent.Name));
            nodeToAdd.AppendChild(CreateNodeWithValue("kontakt", task.Kontakt));
            nodeToAdd.AppendChild(CreateNodeWithValue("status", task.Status));
            nodeToAdd.AppendChild(CreateNodeWithValue("zeitaufwand", task.ZeitAufwand.ToString()));
            nodeToAdd.AppendChild(document.CreateElement("subtasks"));
            foreach (Aufgabe subTask in task.ChildTasks)
            {
                XmlNode childTask = CreateNodeWithValue("subtask", task.Parent.ID.ToString() + ";" + task.Parent.Name);
                nodeToAdd.LastChild.AppendChild(childTask);

            }
            root.AppendChild(nodeToAdd);
            if (task.Parent != null)
            {
                XmlNode parentNode = document.SelectNodes("aufgaben/aufgabe").Item(task.Parent.ID);
                XmlNode subNodes = parentNode.LastChild;
                subNodes.AppendChild(CreateNodeWithValue("subtask", task.ID.ToString() + ";" + task.Name));

            }
            document.Save(pathToXML);
        }
        public void SaveChangesInTask(Aufgabe aufgabe)
        {
            XmlNode aufgabenNode = GetAufgabenNode(aufgabe.Name, aufgabe.ID);
            foreach (XmlNode subNode in aufgabenNode.ChildNodes)
            {
                switch (subNode.Name)
                {
                    case "beschreibung":
                        subNode.InnerText = aufgabe.Beschreibung;
                        break;
                    case "annahme":
                        subNode.InnerText = aufgabe.AnnahmeDatum.ToShortDateString();
                        break;
                    case "abgabe":
                        subNode.InnerText = aufgabe.AbgabeDatum.ToShortDateString();
                        break;
                    case "parent":
                        subNode.InnerText = aufgabe.Name + ";" + aufgabe.ID.ToString();
                        break;
                    case "kontakt":
                        subNode.InnerText = aufgabe.Kontakt;
                        break;
                    case "status":
                        subNode.InnerText = aufgabe.Status;
                        break;
                    case "zeitaufwand":
                        subNode.InnerText = aufgabe.TimeLeft.ToString();
                        break;
                    case "subtasks":
                        foreach (Aufgabe childtask in aufgabe.ChildTasks)
                        {
                            bool exists = false;
                            foreach (XmlNode subtask in subNode.ChildNodes)
                            {
                                string[] values = subtask.InnerText.Split(';');
                                if (values[1] == childtask.Name)
                                {
                                    subtask.InnerText = childtask.ID.ToString() + ";" + childtask.Name;
                                    exists = true;
                                }
                            }
                            if (!exists)
                            {
                                subNode.AppendChild(CreateNodeWithValue("subtask", childtask.ID.ToString() + ";" + childtask.Name));
                            }
                        }
                        break;

                    default:
                        break;
                }

            }
            document.Save(pathToXML);
        }

        public Aufgabe GetAufgabeByName(string name)
        {
            Aufgabe returnValue = aufgaben.Find(a => a.Name == name);
            if (returnValue is null)
            {
                throw new Exception("Keine Aufgabe mit dem Namen " + name + " gefunden.");
            }
            return returnValue;
        }
        private XmlNode CreateNodeWithValue(string nodeName, string value)
        {
            XmlNode outPut = document.CreateElement(nodeName);
            outPut.InnerText = value;
            return outPut;

        }
        private XmlNode GetAufgabenNode(string name, int id)
        {
            XmlNodeList nodes = document.SelectNodes("aufgaben/aufgabe");
            XmlNode value = null;

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["name"].Value == name && node.Attributes["id"].Value == id.ToString())
                {
                    value = node;
                    break;
                }
            }
            if (value == null)
            {
                throw new Exception("Aufgabe nicht gefunden");
            }
            return value;
        }
        private void SortAufgaben(string type)
        {
            switch (type)
            {
                case "dueDate":
                    Aufgabe temp;
                    for(int i = 0; i < aufgaben.Count; i++)
                    {
                        if (i + 1 < aufgaben.Count) {
                            if (aufgaben[i].TimeLeft > aufgaben[i + 1].TimeLeft)
                            {
                                temp = aufgaben[i];
                                aufgaben[i] = aufgaben[i + 1];
                                aufgaben[i + 1] = temp;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
