using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Aufgaben
{
    public class OnOrderChangedEventArgs
    {
        public Point Location { get; private set; }
        public int ID { get; private set; }
        public OnOrderChangedEventArgs(Point location, int id)
        {
            Location = location;
            ID = id;
        }
    }
    public class AufgabenControl : Control
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
        public delegate void OnOrderChangeEventHandler(object sender, OnOrderChangedEventArgs args);
        public event EventHandler OnChange;
        public event OnOrderChangeEventHandler OnOrderChange;
        public Aufgabe Task { get { return aufgabe; } }
        public int ID { get; set; }
        public GroupBox TaskControl { get { return gbAufgabe; } set { gbAufgabe = value; } }
        public AufgabenControl()
            : base()
        {

        }

        public AufgabenControl(string text, int left, int top, int width, int height, Control parent)
            : base(text, left, top, width, height)
        {

            cParent = parent;
            gbAufgabe = new GroupBox();
            gbAufgabe.Text = text;
            gbAufgabe.SetBounds(left, top, width, height);
            gbAufgabe.MouseDown += GbAufgabe_MouseDown;
            gbAufgabe.MouseUp += GbAufgabe_MouseUp;
            gbAufgabe.Click += GbAufgabe_Click;
            gbAufgabe.MouseMove += GbAufgabe_MouseMove;
            lAufgabenText = new Label();
            lAufgabenText.Top = 30;
            lAufgabenText.AutoSize = true;
            lAufgabenText.Left = 9;
            lKontakt = new Label();
            lKontakt.Top = 30;
            lKontakt.Left = 157;
            lKontakt.AutoSize = true;
            lStartDatum = new Label();
            lStartDatum.Top = 59;
            lStartDatum.Left = 157;
            lStartDatum.AutoSize = true;
            lEndDate = new Label();
            lEndDate.Top = 85;
            lEndDate.Left = 157;
            lEndDate.AutoSize = true;
            lTimeLeft = new Label();
            lTimeLeft.Top = 112;
            lTimeLeft.Left = 157;
            lTimeLeft.AutoSize = true;
            lbSubItems = new ListBox();
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
            this.aufgabe = aufgabe;
            lAufgabenText.Text = BreakTextWithLength(aufgabe.Beschreibung, 149);
            lKontakt.Text = aufgabe.Kontakt;
            lStartDatum.Text = aufgabe.AnnahmeDatum.ToShortDateString();
            lEndDate.Text = aufgabe.AbgabeDatum.ToShortDateString();
            lTimeLeft.Text = aufgabe.TimeLeft.Days.ToString() + " Tage";
            foreach (Aufgabe subTask in aufgabe.ChildTasks)
            {
                lbSubItems.Items.Add(subTask.ID.ToString() + ";" + subTask.Name);
            }
            // gbAufgabe.BackColor = aufgabe.StatusFarbe;
            //  bEdit.BackColor = Color.FromKnownColor(KnownColor.Control);
            OnChange?.Invoke(this, new EventArgs());
        }
        private void GbAufgabe_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                int y = e.Y - mouseDownlocation.Y;
                if (y < 0)
                {
                    if (gbAufgabe.Top >= 19)
                    {
                        gbAufgabe.Top += y;
                    }
                }
                else
                {
                    if (gbAufgabe.Top + gbAufgabe.Size.Height <= cParent.Height)
                    {
                        gbAufgabe.Top += y;
                    }
                }

                if (gbAufgabe.Top / Form1.ACHEIGHT == 0 && ((float)gbAufgabe.Top / Form1.ACHEIGHT) < 0.6f && ID != 0)
                {
                    OnOrderChange?.Invoke(this, new OnOrderChangedEventArgs(gbAufgabe.Location, ID));
                    mousePressed = false;
                }
                if (gbAufgabe.Top / Form1.ACHEIGHT != ID && gbAufgabe.Top / Form1.ACHEIGHT > 0)
                {
                    OnOrderChange?.Invoke(this, new OnOrderChangedEventArgs(gbAufgabe.Location, ID));
                    mousePressed = false;
                }



            }
        }

        private void GbAufgabe_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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
            CreateTask editTask = new CreateTask(this);
            editTask.Show();
            //editTask.Dispose();
            //editTask = null;
        }

        private string BreakTextWithLength(string text, int length)
        {
            string value = "";
            Size textlength = TextRenderer.MeasureText(text, SystemFonts.DialogFont);
            string[] splitted = text.Split(' ');

            if (textlength.Width > length)
            {
                for (int i = 0; i < splitted.Length; i++)
                {
                    if (TextRenderer.MeasureText(value + splitted[i].ToString(), SystemFonts.DialogFont).Width < length)
                    {
                        value = value + " " + splitted[i].ToString();
                    }
                    else
                    {
                        value = value + "\n" + splitted[i].ToString();
                    }

                }

            }
            else
            {
                value = text;
            }
            return value;
        }
    }
}
