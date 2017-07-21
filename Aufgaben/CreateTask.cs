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
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name darf nicht leer sein!");
                return;
            }
            string aufnr = tb_aufnr.Text;
            string kontakt = tb_contact.Text;
            DateTime startDatum = dtp_startdatum.Value.Date;
            DateTime endDatum = dtp_enddatum.Value.Date;
            string status = cb_state.SelectedText;
            string parentName = cb_parenttask.SelectedItem.ToString();
            Aufgabe parent = null;
            if (!cb_isParent.Checked)
                parent = manager.GetAufgabeByName(parentName);

            Aufgabe aufgabe = new Aufgabe(name, parent, kontakt, status, startDatum, endDatum, aufnr);
            aufgabe.ID = AufgabenManager.ID;
            manager.SaveNewTasks(aufgabe);
            MessageBox.Show("Aufgabe gespeichert.");
        }

        private void CreateTask_Load(object sender, EventArgs e)
        {
            manager = new AufgabenManager();
            foreach (Aufgabe aufgabe in manager.Aufgaben)
            {
                cb_parenttask.Items.Add(aufgabe.Name);
            }
        }

        private void tb_taskname_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_isParent_CheckedChanged(object sender, EventArgs e)
        {
            cb_parenttask.Enabled = !cb_isParent.Checked;
        }

        private void b_abort_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
