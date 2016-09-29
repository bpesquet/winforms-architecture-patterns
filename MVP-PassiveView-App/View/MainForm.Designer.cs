namespace MVP_PassiveView_App.View
{
    partial class MainForm
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
            this.titleTB = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.urlTB = new System.Windows.Forms.TextBox();
            this.urlLbl = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.loginLB = new System.Windows.Forms.ListBox();
            this.editBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleTB
            // 
            this.titleTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTB.Location = new System.Drawing.Point(143, 12);
            this.titleTB.Name = "titleTB";
            this.titleTB.ReadOnly = true;
            this.titleTB.Size = new System.Drawing.Size(296, 26);
            this.titleTB.TabIndex = 0;
            this.titleTB.Text = "Title";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(273, 164);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // urlTB
            // 
            this.urlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTB.Location = new System.Drawing.Point(201, 123);
            this.urlTB.Name = "urlTB";
            this.urlTB.ReadOnly = true;
            this.urlTB.Size = new System.Drawing.Size(238, 20);
            this.urlTB.TabIndex = 3;
            // 
            // urlLbl
            // 
            this.urlLbl.AutoSize = true;
            this.urlLbl.Location = new System.Drawing.Point(140, 126);
            this.urlLbl.Name = "urlLbl";
            this.urlLbl.Size = new System.Drawing.Size(29, 13);
            this.urlLbl.TabIndex = 9;
            this.urlLbl.Text = "URL";
            // 
            // passwordTB
            // 
            this.passwordTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTB.Location = new System.Drawing.Point(201, 87);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.ReadOnly = true;
            this.passwordTB.Size = new System.Drawing.Size(238, 20);
            this.passwordTB.TabIndex = 2;
            // 
            // usernameTB
            // 
            this.usernameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameTB.Location = new System.Drawing.Point(201, 55);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.ReadOnly = true;
            this.usernameTB.Size = new System.Drawing.Size(238, 20);
            this.usernameTB.TabIndex = 1;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(140, 92);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(53, 13);
            this.passwordLbl.TabIndex = 8;
            this.passwordLbl.Text = "Password";
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(140, 58);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(55, 13);
            this.usernameLbl.TabIndex = 7;
            this.usernameLbl.Text = "Username";
            // 
            // loginLB
            // 
            this.loginLB.Dock = System.Windows.Forms.DockStyle.Left;
            this.loginLB.FormattingEnabled = true;
            this.loginLB.Location = new System.Drawing.Point(0, 0);
            this.loginLB.Name = "loginLB";
            this.loginLB.Size = new System.Drawing.Size(120, 199);
            this.loginLB.Sorted = true;
            this.loginLB.TabIndex = 6;
            this.loginLB.SelectedIndexChanged += new System.EventHandler(this.loginLB_SelectedIndexChanged);
            // 
            // editBtn
            // 
            this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editBtn.Location = new System.Drawing.Point(354, 164);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(85, 23);
            this.editBtn.TabIndex = 5;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 199);
            this.Controls.Add(this.titleTB);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.urlTB);
            this.Controls.Add(this.urlLbl);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.loginLB);
            this.Controls.Add(this.editBtn);
            this.Name = "MainForm";
            this.Text = "PassWorld";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox urlTB;
        private System.Windows.Forms.Label urlLbl;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.ListBox loginLB;
        private System.Windows.Forms.Button editBtn;

    }
}

