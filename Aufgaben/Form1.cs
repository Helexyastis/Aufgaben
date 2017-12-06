using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aufgaben
{

    public partial class Form1 : Form
    {
        public static int ACHEIGHT = 141;
        public static int ACDIFF = 24;
        public Form1()
        {
            InitializeComponent();
        }

        AufgabenManager manager;
        Dictionary<int, AufgabenControl> acTasks;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public void b_new_Click(object sender, EventArgs e)
        {
            CreateTask createTask = new CreateTask();
            createTask.FormClosed += CreateTask_FormClosed;
            createTask.Show();
        }

        private void CreateTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadAufgaben();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAufgaben();

        }
        private void LoadAufgaben()
        {
            manager = new AufgabenManager();
            acTasks = new Dictionary<int, AufgabenControl>();
            gb_Tasks.Controls.Clear();
            int i = 0;
            foreach (Aufgabe aufgabe in manager.Aufgaben)
            {
                if (i < (gb_Tasks.Height / Form1.ACHEIGHT))
                {
                    AufgabenControl ac;
                    if (i > 0)
                    {
                        ac = new AufgabenControl(aufgabe.Name, 6, ((Form1.ACHEIGHT) * i) + Form1.ACDIFF, 450, Form1.ACHEIGHT, gb_Tasks);
                        ac.SetAufgabe(aufgabe);
                        ac.ID = i;
                        acTasks.Add(i, ac);
                    }
                    else
                    {
                        ac = new AufgabenControl(aufgabe.Name, 6, 19, 450, Form1.ACHEIGHT, gb_Tasks);
                        ac.SetAufgabe(aufgabe);
                        ac.ID = i;

                        acTasks.Add(i, ac);
                    }
                }
                i++;
            }
            for (int x = 0; x < acTasks.Count; x++)
            {
                acTasks[x].OnChange += AcTask_OnChange;
                acTasks[x].OnOrderChange += AufgabenControl_OnOrderChange;
            }

        }

        private void AufgabenControl_OnOrderChange(object sender, OnOrderChangedEventArgs args)
        {
            int toChange = args.Location.Y / Form1.ACHEIGHT;
            if (toChange != args.ID && toChange >= 0 && toChange < acTasks.Count)
            {
                AufgabenControl temp = acTasks[args.ID];
                acTasks[args.ID] = acTasks[toChange];
                acTasks[toChange] = temp;

                if (args.ID == 0)
                {
                    Point newPoint = new Point(acTasks[args.ID].Location.X, 19);
                    acTasks[args.ID].Location = newPoint;
                    newPoint = new Point(acTasks[toChange].Location.X, ((Form1.ACHEIGHT) * toChange) + Form1.ACDIFF);
                    acTasks[toChange].Location = newPoint;
                }
                else
                {

                    if (toChange == 0)
                    {
                        Point newPoint = new Point(acTasks[args.ID].Location.X, (Form1.ACHEIGHT * args.ID) + Form1.ACDIFF);
                        acTasks[args.ID].Location = newPoint;
                        newPoint = new Point(acTasks[toChange].Location.X, 19);
                        acTasks[toChange].Location = newPoint;
                    }
                    else
                    {
                        Point newPoint = new Point(acTasks[args.ID].Location.X, (Form1.ACHEIGHT * args.ID) + Form1.ACDIFF);
                        acTasks[args.ID].Location = newPoint;
                        newPoint = new Point(acTasks[toChange].Location.X, (Form1.ACHEIGHT * toChange) + Form1.ACDIFF);
                        acTasks[toChange].Location = newPoint;
                    }
                }
            }
            for(int i = 0; i < acTasks.Count; i++)
            {
                acTasks[i].Update();
            }
        }



        private void AcTask_OnChange(object sender, EventArgs e)
        {
            LoadAufgaben();
        }

        private void gb_Tasks_Validated(object sender, EventArgs e)
        {
            gb_Tasks.Controls.Clear();

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            b_Close.Location = new Point(Width - (b_Close.Width + 28), Height - (b_Close.Height + 50));
            gb_Tasks.Height = Height - (gb_Tasks.Location.X + 50);
            if (gb_Tasks.Height / 145 != acTasks.Count)
                LoadAufgaben();
        }
    }
}
