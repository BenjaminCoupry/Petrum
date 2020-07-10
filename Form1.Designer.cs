namespace Petrum
{
    partial class Connexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connexion));
            this.buttHeberger = new System.Windows.Forms.Button();
            this.labIP = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.buttJoindre = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.labPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttHeberger
            // 
            this.buttHeberger.Location = new System.Drawing.Point(13, 88);
            this.buttHeberger.Name = "buttHeberger";
            this.buttHeberger.Size = new System.Drawing.Size(339, 23);
            this.buttHeberger.TabIndex = 0;
            this.buttHeberger.Text = "Heberger";
            this.buttHeberger.UseVisualStyleBackColor = true;
            this.buttHeberger.Click += new System.EventHandler(this.buttHeberger_Click);
            // 
            // labIP
            // 
            this.labIP.AutoSize = true;
            this.labIP.Location = new System.Drawing.Point(12, 31);
            this.labIP.Name = "labIP";
            this.labIP.Size = new System.Drawing.Size(23, 13);
            this.labIP.TabIndex = 1;
            this.labIP.Text = "IP :";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(41, 28);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(207, 20);
            this.tbIP.TabIndex = 2;
            this.tbIP.Text = "localhost";
            // 
            // buttJoindre
            // 
            this.buttJoindre.Location = new System.Drawing.Point(277, 26);
            this.buttJoindre.Name = "buttJoindre";
            this.buttJoindre.Size = new System.Drawing.Size(75, 23);
            this.buttJoindre.TabIndex = 3;
            this.buttJoindre.Text = "Joindre";
            this.buttJoindre.UseVisualStyleBackColor = true;
            this.buttJoindre.Click += new System.EventHandler(this.buttJoindre_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(148, 54);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 4;
            this.tbPort.Text = "25565";
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(107, 57);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(32, 13);
            this.labPort.TabIndex = 5;
            this.labPort.Text = "Port :";
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 123);
            this.Controls.Add(this.labPort);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.buttJoindre);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.labIP);
            this.Controls.Add(this.buttHeberger);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Connexion";
            this.Text = "Connexion Petrum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttHeberger;
        private System.Windows.Forms.Label labIP;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button buttJoindre;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label labPort;
    }
}

