namespace Petrum
{
    partial class Petrum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Petrum));
            this.Affichage = new System.Windows.Forms.PictureBox();
            this.labTour = new System.Windows.Forms.Label();
            this.labCoup = new System.Windows.Forms.Label();
            this.buttGO = new System.Windows.Forms.Button();
            this.choixMode = new System.Windows.Forms.TrackBar();
            this.labelMode = new System.Windows.Forms.Label();
            this.pbPrises = new System.Windows.Forms.PictureBox();
            this.labScore = new System.Windows.Forms.Label();
            this.labSoreAdv = new System.Windows.Forms.Label();
            this.labStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.Affichage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.choixMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrises)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Affichage
            // 
            this.Affichage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Affichage.Location = new System.Drawing.Point(3, 3);
            this.Affichage.Name = "Affichage";
            this.Affichage.Size = new System.Drawing.Size(623, 525);
            this.Affichage.TabIndex = 0;
            this.Affichage.TabStop = false;
            this.Affichage.Click += new System.EventHandler(this.Affichage_Click);
            // 
            // labTour
            // 
            this.labTour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labTour.AutoSize = true;
            this.labTour.Location = new System.Drawing.Point(54, 10);
            this.labTour.Name = "labTour";
            this.labTour.Size = new System.Drawing.Size(13, 13);
            this.labTour.TabIndex = 1;
            this.labTour.Text = "0";
            // 
            // labCoup
            // 
            this.labCoup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labCoup.AutoSize = true;
            this.labCoup.Location = new System.Drawing.Point(54, 44);
            this.labCoup.Name = "labCoup";
            this.labCoup.Size = new System.Drawing.Size(13, 13);
            this.labCoup.TabIndex = 2;
            this.labCoup.Text = "0";
            // 
            // buttGO
            // 
            this.buttGO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttGO.Location = new System.Drawing.Point(3, 71);
            this.buttGO.Name = "buttGO";
            this.buttGO.Size = new System.Drawing.Size(116, 53);
            this.buttGO.TabIndex = 3;
            this.buttGO.Text = "Go !";
            this.buttGO.UseVisualStyleBackColor = true;
            this.buttGO.Click += new System.EventHandler(this.buttGO_Click);
            // 
            // choixMode
            // 
            this.choixMode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.choixMode.Location = new System.Drawing.Point(3, 130);
            this.choixMode.Maximum = 4;
            this.choixMode.Name = "choixMode";
            this.choixMode.Size = new System.Drawing.Size(116, 34);
            this.choixMode.TabIndex = 4;
            this.choixMode.Scroll += new System.EventHandler(this.choixMode_Scroll);
            // 
            // labelMode
            // 
            this.labelMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMode.AutoSize = true;
            this.labelMode.Location = new System.Drawing.Point(44, 179);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(33, 13);
            this.labelMode.TabIndex = 5;
            this.labelMode.Text = "mode";
            // 
            // pbPrises
            // 
            this.pbPrises.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPrises.Location = new System.Drawing.Point(3, 208);
            this.pbPrises.Name = "pbPrises";
            this.pbPrises.Size = new System.Drawing.Size(116, 369);
            this.pbPrises.TabIndex = 6;
            this.pbPrises.TabStop = false;
            // 
            // labScore
            // 
            this.labScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labScore.AutoSize = true;
            this.labScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labScore.ForeColor = System.Drawing.Color.Blue;
            this.labScore.Location = new System.Drawing.Point(129, 19);
            this.labScore.Name = "labScore";
            this.labScore.Size = new System.Drawing.Size(53, 20);
            this.labScore.TabIndex = 7;
            this.labScore.Text = "label1";
            // 
            // labSoreAdv
            // 
            this.labSoreAdv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labSoreAdv.AutoSize = true;
            this.labSoreAdv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labSoreAdv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labSoreAdv.Location = new System.Drawing.Point(440, 19);
            this.labSoreAdv.Name = "labSoreAdv";
            this.labSoreAdv.Size = new System.Drawing.Size(53, 20);
            this.labSoreAdv.TabIndex = 8;
            this.labSoreAdv.Text = "label2";
            // 
            // labStatus
            // 
            this.labStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labStatus.Location = new System.Drawing.Point(34, 588);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(53, 20);
            this.labStatus.TabIndex = 9;
            this.labStatus.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labTour, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labStatus, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labCoup, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbPrises, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttGO, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.choixMode, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelMode, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(638, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.563634F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.563636F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.696622F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.517402F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.199481F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.89843F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.560791F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(122, 617);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labScore, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labSoreAdv, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 556);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(623, 58);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Affichage, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.20689F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.7931F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(629, 617);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(763, 623);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // Petrum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 623);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Petrum";
            this.Text = "Petrum";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Petrum_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Affichage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.choixMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrises)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Affichage;
        private System.Windows.Forms.Label labTour;
        private System.Windows.Forms.Label labCoup;
        private System.Windows.Forms.Button buttGO;
        private System.Windows.Forms.TrackBar choixMode;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.PictureBox pbPrises;
        private System.Windows.Forms.Label labScore;
        private System.Windows.Forms.Label labSoreAdv;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}