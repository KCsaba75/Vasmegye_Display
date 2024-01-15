namespace Vasmegye
{
    partial class GrafikusFelulet
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
            this.tbEredmeny = new System.Windows.Forms.TextBox();
            this.betoltesButton = new System.Windows.Forms.Button();
            this.feldolgozasButton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbEredmeny
            // 
            this.tbEredmeny.Location = new System.Drawing.Point(9, 13);
            this.tbEredmeny.Name = "tbEredmeny";
            this.tbEredmeny.Size = new System.Drawing.Size(366, 20);
            this.tbEredmeny.TabIndex = 0;
            // 
            // betoltesButton
            // 
            this.betoltesButton.Location = new System.Drawing.Point(33, 21);
            this.betoltesButton.Name = "betoltesButton";
            this.betoltesButton.Size = new System.Drawing.Size(122, 54);
            this.betoltesButton.TabIndex = 1;
            this.betoltesButton.Text = "button1";
            this.betoltesButton.UseVisualStyleBackColor = true;
            // 
            // feldolgozasButton
            // 
            this.feldolgozasButton.Location = new System.Drawing.Point(240, 21);
            this.feldolgozasButton.Name = "feldolgozasButton";
            this.feldolgozasButton.Size = new System.Drawing.Size(122, 54);
            this.feldolgozasButton.TabIndex = 2;
            this.feldolgozasButton.Text = "button1";
            this.feldolgozasButton.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tbEredmeny);
            this.panel.Location = new System.Drawing.Point(3, 98);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(385, 340);
            this.panel.TabIndex = 3;
            // 
            // GrafikusFelulet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 450);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.feldolgozasButton);
            this.Controls.Add(this.betoltesButton);
            this.Name = "GrafikusFelulet";
            this.Text = "Form1";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbEredmeny;
        private System.Windows.Forms.Button betoltesButton;
        private System.Windows.Forms.Button feldolgozasButton;
        private System.Windows.Forms.Panel panel;
    }
}

