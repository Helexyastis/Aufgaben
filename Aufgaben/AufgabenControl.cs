using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Aufgaben
{
    class AufgabenControl : Control
    {
        bool mousePressed = false;
        Aufgabe aufgabe;
        Point mouseDownlocation;
        Label lAufgabenText;
        Label lKontakt;
        Label lStartDatum;
        Label lEndDate;
        Label lTimeLeft;
        ListBox lbSubItems;
        GroupBox gbAufgabe;
        Control cParent;
        Button bEdit;
        public AufgabenControl() 
            : base()
        {

        }

        public AufgabenControl(string text, int left, int top, int width, int height,Control parent,Aufgabe aufgabe) 
            : base(text, left, top, width, height)
        {
            this.aufgabe = aufgabe;
            cParent = parent;
            gbAufgabe = new GroupBox();
            gbAufgabe.Text = text;
            gbAufgabe.SetBounds(left, top, width, height);
            gbAufgabe.MouseDown += GbAufgabe_MouseDown;
            gbAufgabe.MouseUp += GbAufgabe_MouseUp;
            gbAufgabe.Click += GbAufgabe_Click;
            gbAufgabe.MouseMove += GbAufgabe_MouseMove;
            lAufgabenText = new Label();
            lAufgabenText.Text = aufgabe.Beschreibung;
            lAufgabenText.Top = 32;
            lAufgabenText.AutoSize = true;
            lAufgabenText.Left = 18;
            lKontakt = new Label();
            lKontakt.Text = aufgabe.Kontakt;
            lKontakt.Top = 32;
            lKontakt.Left = 157;
            lKontakt.AutoSize = true;
            lStartDatum = new Label();
            lStartDatum.Text = aufgabe.AnnahmeDatum.ToShortDateString();
            lStartDatum.Top = 59;
            lStartDatum.Left = 157;
            lStartDatum.AutoSize = true;
            lEndDate = new Label();
            lEndDate.Text = aufgabe.AbgabeDatum.ToShortDateString();
            lEndDate.Top = 85;
            lEndDate.Left = 157;
            lEndDate.AutoSize = true;
            lTimeLeft = new Label();
            lTimeLeft.Text = "31";
            lTimeLeft.Top = 112;
            lTimeLeft.Left = 157;
            lTimeLeft.AutoSize = true;
            lbSubItems = new ListBox();
            foreach (Aufgabe subTask in aufgabe.ChildTasks)
            {
                lbSubItems.Items.Add(subTask.ID.ToString() +";"+subTask.Name);
            }
            lbSubItems.Top = 18;
            lbSubItems.Left = 223;
            lbSubItems.Size = new Size(120, 121);
            bEdit = new Button();
            bEdit.Text = "Bearbeiten";
            bEdit.Size = new Size(75, 23);
            bEdit.Top = 112;
            bEdit.Left = 369;
            bEdit.Click += BEdit_Click;
            gbAufgabe.Controls.Add(bEdit);
            gbAufgabe.Controls.Add(lAufgabenText);
            gbAufgabe.Controls.Add(lKontakt);
            gbAufgabe.Controls.Add(lStartDatum);
            gbAufgabe.Controls.Add(lEndDate);
            gbAufgabe.Controls.Add(lTimeLeft);
            gbAufgabe.Controls.Add(lbSubItems);
            
            gbAufgabe.CreateControl();
            parent.Controls.Add(gbAufgabe);
        }
        public void SetAufgabe(Aufgabe aufgabe)
        {

        }
        private void GbAufgabe_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                int y = e.Y - mouseDownlocation.Y;
                if (y <0)
                {
                    if (gbAufgabe.Top >= 19)
                    {
                        gbAufgabe.Top +=y;
                    }
                }
                else
                {
                    if (gbAufgabe.Top + gbAufgabe.Size.Height <= cParent.Height)
                    {
                        gbAufgabe.Top += y;
                    }
                }
               
            }
        }

        private void GbAufgabe_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
                mousePressed = false;
        }

        private void GbAufgabe_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePressed = true;
                mouseDownlocation = e.Location;
            }
          
        }

        private void GbAufgabe_Click(object sender, EventArgs e)
        {
            gbAufgabe.DoDragDrop(sender, DragDropEffects.Move);
        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
