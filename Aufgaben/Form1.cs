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
        public Form1()
        {
            InitializeComponent();
        }
        AufgabenManager manager;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void b_new_Click(object sender, EventArgs e)
        {
            CreateTask createTask = new CreateTask();
            createTask.Show();
        }
        List<AufgabenControl> acTasks;
        private void Form1_Load(object sender, EventArgs e)
        {
            manager = new AufgabenManager();
            acTasks = new List<AufgabenControl>();
            int i = 0;
            foreach (Aufgabe aufgabe in manager.Aufgaben)
            {
                if (i < 4)
                    if(i>0)
                    acTasks.Add(new AufgabenControl(aufgabe.Name, 6, ((141) * i)+19+5, 450, 141, gb_Tasks, aufgabe));
                else
                        acTasks.Add(new AufgabenControl(aufgabe.Name, 6, 19, 450, 141, gb_Tasks, aufgabe));
                i++;
            }

        }
    }
}
