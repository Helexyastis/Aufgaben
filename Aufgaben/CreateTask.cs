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
        bool bearbeiten = false;
        AufgabenManager manager;
        Aufgabe aufgabe;
        AufgabenControl aufgabeControl;
        public CreateTask()
        {
            bearbeiten = false;
            InitializeComponent();
            this.Text = "Neue Aufgabe erstellen";
        }
        public CreateTask(AufgabenControl aufgabe)
        {
            this.aufgabe = aufgabe.Task;
            aufgabeControl = aufgabe;
            bearbeiten = true;
            InitializeComponent();
            this.Text = "Aufgabe bearbeiten";
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            if (bearbeiten)
            {
                SaveTask();
            }
            else
            {
                SaveNewTask();
            }
            MessageBox.Show("Aufgabe gespeichert.");
            Close();
            Dispose();
        }

        private void CreateTask_Load(object sender, EventArgs e)
        {
            cb_state.SelectedIndex = 0;
            manager = new AufgabenManager();
            if (aufgabe != null)
            {
                tb_taskname.Text = aufgabe.Name;
                tb_aufnr.Text = aufgabe.Auftragsnummer;
                tb_contact.Text = aufgabe.Kontakt;
                tb_beschreibung.Text = aufgabe.Beschreibung;
                dtp_enddatum.Value = aufgabe.AbgabeDatum;
                dtp_startdatum.Value = aufgabe.AnnahmeDatum;
                if (aufgabe.Parent != null)
                {
                    cb_isParent.Checked = true;
                    cb_parenttask.Text = aufgabe.Parent.Name;
                }
            }

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
        private void SaveNewTask()
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
            string parentName = "";
            if (!cb_isParent.Checked)
                parentName = cb_parenttask.SelectedItem.ToString();
            Aufgabe parent = null;
            if (!cb_isParent.Checked)
                parent = manager.GetAufgabeByName(parentName);

            Aufgabe aufgabe = new Aufgabe(name, parent, kontakt, status, startDatum, endDatum, aufnr, tb_beschreibung.Text);
            aufgabe.ID = AufgabenManager.ID;
            manager.SaveNewTasks(aufgabe);
        }

        private void SaveTask()
        {
            aufgabe.Name = tb_taskname.Text;
            aufgabe.Auftragsnummer = tb_aufnr.Text;
            aufgabe.Beschreibung = tb_beschreibung.Text;
            aufgabe.AnnahmeDatum = dtp_startdatum.Value;
            aufgabe.AbgabeDatum = dtp_enddatum.Value;
            aufgabe.Status = cb_state.SelectedText;
            aufgabeControl.SetAufgabe(aufgabe);
            manager.SaveChangesInTask(aufgabe);
        }
    }
}
