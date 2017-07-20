namespace Aufgaben
{
    partial class CreateTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_taskname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_save = new System.Windows.Forms.Button();
            this.b_abort = new System.Windows.Forms.Button();
            this.dtp_startdatum = new System.Windows.Forms.DateTimePicker();
            this.dtp_enddatum = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_parenttask = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_contact = new System.Windows.Forms.TextBox();
            this.cb_state = new System.Windows.Forms.ComboBox();
            this.tb_aufnr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_taskname
            // 
            this.tb_taskname.Location = new System.Drawing.Point(12, 53);
            this.tb_taskname.Name = "tb_taskname";
            this.tb_taskname.Size = new System.Drawing.Size(244, 20);
            this.tb_taskname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name der Aufgabe";
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(374, 227);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 2;
            this.b_save.Text = "Speichern";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_abort
            // 
            this.b_abort.Location = new System.Drawing.Point(469, 227);
            this.b_abort.Name = "b_abort";
            this.b_abort.Size = new System.Drawing.Size(75, 23);
            this.b_abort.TabIndex = 3;
            this.b_abort.Text = "Abbrechen";
            this.b_abort.UseVisualStyleBackColor = true;
            // 
            // dtp_startdatum
            // 
            this.dtp_startdatum.Location = new System.Drawing.Point(12, 108);
            this.dtp_startdatum.Name = "dtp_startdatum";
            this.dtp_startdatum.Size = new System.Drawing.Size(200, 20);
            this.dtp_startdatum.TabIndex = 4;
            // 
            // dtp_enddatum
            // 
            this.dtp_enddatum.Location = new System.Drawing.Point(12, 167);
            this.dtp_enddatum.Name = "dtp_enddatum";
            this.dtp_enddatum.Size = new System.Drawing.Size(200, 20);
            this.dtp_enddatum.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Startdatum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enddatum";
            // 
            // cb_parenttask
            // 
            this.cb_parenttask.FormattingEnabled = true;
            this.cb_parenttask.Location = new System.Drawing.Point(276, 52);
            this.cb_parenttask.Name = "cb_parenttask";
            this.cb_parenttask.Size = new System.Drawing.Size(268, 21);
            this.cb_parenttask.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Übergeordnete Aufgabe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Kontakt";
            // 
            // tb_contact
            // 
            this.tb_contact.Location = new System.Drawing.Point(276, 108);
            this.tb_contact.Name = "tb_contact";
            this.tb_contact.Size = new System.Drawing.Size(268, 20);
            this.tb_contact.TabIndex = 10;
            // 
            // cb_state
            // 
            this.cb_state.FormattingEnabled = true;
            this.cb_state.Items.AddRange(new object[] {
            "Unbearbeitet",
            "in Bearbeitung",
            "warte auf Kunden",
            "warte auf Chef",
            "Abgeschlossen",
            ""});
            this.cb_state.Location = new System.Drawing.Point(276, 166);
            this.cb_state.Name = "cb_state";
            this.cb_state.Size = new System.Drawing.Size(121, 21);
            this.cb_state.TabIndex = 12;
            // 
            // tb_aufnr
            // 
            this.tb_aufnr.Location = new System.Drawing.Point(430, 167);
            this.tb_aufnr.Name = "tb_aufnr";
            this.tb_aufnr.Size = new System.Drawing.Size(114, 20);
            this.tb_aufnr.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(427, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Auftragsnummer";
            // 
            // CreateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 270);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_aufnr);
            this.Controls.Add(this.cb_state);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_contact);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_parenttask);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_enddatum);
            this.Controls.Add(this.dtp_startdatum);
            this.Controls.Add(this.b_abort);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_taskname);
            this.Name = "CreateTask";
            this.Text = "CreateTask";
            this.Load += new System.EventHandler(this.CreateTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_taskname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_abort;
        private System.Windows.Forms.DateTimePicker dtp_startdatum;
        private System.Windows.Forms.DateTimePicker dtp_enddatum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_parenttask;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_contact;
        private System.Windows.Forms.ComboBox cb_state;
        private System.Windows.Forms.TextBox tb_aufnr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}