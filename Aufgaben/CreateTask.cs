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
    public partial class CreateTask : Form
    {
        public CreateTask()
        {
            InitializeComponent();
        }
        AufgabenManager manager;
        private void b_save_Click(object sender, EventArgs e)
        {
            string name = tb_taskname.Text;
            string aufnr = tb_aufnr.Text;
            string kontakt = tb_contact.Text;
            DateTime startDatum = dtp_startdatum.Value;
            DateTime endDatum = dtp_enddatum.Value;
            string status = cb_state.SelectedText;
            string parentName = cb_parenttask.SelectedText;
           
            Aufgabe parent = manager.GetAufgabeByName(parentName);
            Aufgabe aufgabe = new Aufgabe(name,parent,kontakt,status,startDatum,endDatum,aufnr);

        }

        private void CreateTask_Load(object sender, EventArgs e)
        {
            manager = new AufgabenManager();
        }
    }
}
