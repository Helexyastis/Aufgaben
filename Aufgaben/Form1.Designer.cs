namespace Aufgaben
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_Close = new System.Windows.Forms.Button();
            this.b_new = new System.Windows.Forms.Button();
            this.gb_Tasks = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // b_Close
            // 
            this.b_Close.Location = new System.Drawing.Point(638, 464);
            this.b_Close.Name = "b_Close";
            this.b_Close.Size = new System.Drawing.Size(75, 23);
            this.b_Close.TabIndex = 0;
            this.b_Close.Text = "Beenden";
            this.b_Close.UseVisualStyleBackColor = true;
            this.b_Close.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_new
            // 
            this.b_new.Location = new System.Drawing.Point(504, 48);
            this.b_new.Name = "b_new";
            this.b_new.Size = new System.Drawing.Size(104, 29);
            this.b_new.TabIndex = 1;
            this.b_new.Text = "Aufgabe anlegen";
            this.b_new.UseVisualStyleBackColor = true;
            this.b_new.Click += new System.EventHandler(this.b_new_Click);
            // 
            // gb_Tasks
            // 
            this.gb_Tasks.Location = new System.Drawing.Point(13, 13);
            this.gb_Tasks.Name = "gb_Tasks";
            this.gb_Tasks.Size = new System.Drawing.Size(462, 455);
            this.gb_Tasks.TabIndex = 2;
            this.gb_Tasks.TabStop = false;
            this.gb_Tasks.Text = "Aufgaben";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 499);
            this.Controls.Add(this.gb_Tasks);
            this.Controls.Add(this.b_new);
            this.Controls.Add(this.b_Close);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_Close;
        private System.Windows.Forms.Button b_new;
        private System.Windows.Forms.GroupBox gb_Tasks;
    }
}

