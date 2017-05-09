namespace SoundStream
{
    partial class frmConnection
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
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.llblSwitch = new System.Windows.Forms.LinkLabel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbxPass = new System.Windows.Forms.TextBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.tbxConfPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(55, 104);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(384, 20);
            this.tbxName.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(88, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(319, 55);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "SoundStream";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(194, 248);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(105, 39);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Connexion";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // llblSwitch
            // 
            this.llblSwitch.AutoSize = true;
            this.llblSwitch.Location = new System.Drawing.Point(220, 228);
            this.llblSwitch.Name = "llblSwitch";
            this.llblSwitch.Size = new System.Drawing.Size(55, 13);
            this.llblSwitch.TabIndex = 3;
            this.llblSwitch.TabStop = true;
            this.llblSwitch.Text = "Inscription";
            this.llblSwitch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSwitch_LinkClicked);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(206, 88);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Nom utilisateur :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(209, 133);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Mot de passe :";
            // 
            // tbxPass
            // 
            this.tbxPass.Location = new System.Drawing.Point(55, 149);
            this.tbxPass.Name = "tbxPass";
            this.tbxPass.PasswordChar = '*';
            this.tbxPass.Size = new System.Drawing.Size(384, 20);
            this.tbxPass.TabIndex = 5;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Location = new System.Drawing.Point(180, 184);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(134, 13);
            this.lblConfirmPass.TabIndex = 8;
            this.lblConfirmPass.Text = "Confirmer le mot de passe :";
            this.lblConfirmPass.Visible = false;
            // 
            // tbxConfPass
            // 
            this.tbxConfPass.Location = new System.Drawing.Point(55, 200);
            this.tbxConfPass.Name = "tbxConfPass";
            this.tbxConfPass.PasswordChar = '*';
            this.tbxConfPass.Size = new System.Drawing.Size(384, 20);
            this.tbxConfPass.TabIndex = 7;
            this.tbxConfPass.Visible = false;
            // 
            // frmConnection
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 304);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.tbxConfPass);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbxPass);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.llblSwitch);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tbxName);
            this.Name = "frmConnection";
            this.Text = "SoundStream";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.LinkLabel llblSwitch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbxPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox tbxConfPass;
    }
}