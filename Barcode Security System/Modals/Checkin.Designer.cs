
namespace Barcode_Security_System.Modal
{
    partial class Checkin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checkin));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.card = new Guna.UI2.WinForms.Guna2Panel();
            this.signin = new Guna.UI2.WinForms.Guna2Button();
            this.signout = new Guna.UI2.WinForms.Guna2Button();
            this.user = new System.Windows.Forms.Label();
            this.asset = new System.Windows.Forms.Label();
            this.dp = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button9 = new Guna.UI2.WinForms.Guna2Button();
            this.barcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.signinBg = new System.ComponentModel.BackgroundWorker();
            this.signoutBg = new System.ComponentModel.BackgroundWorker();
            this.card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dp)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan barcode using a barcode scanner or enter barcode number";
            // 
            // card
            // 
            this.card.BorderColor = System.Drawing.Color.White;
            this.card.BorderRadius = 20;
            this.card.Controls.Add(this.signin);
            this.card.Controls.Add(this.signout);
            this.card.Controls.Add(this.user);
            this.card.Controls.Add(this.asset);
            this.card.Controls.Add(this.dp);
            this.card.FillColor = System.Drawing.Color.White;
            this.card.Location = new System.Drawing.Point(163, 143);
            this.card.Name = "card";
            this.card.Size = new System.Drawing.Size(339, 303);
            this.card.TabIndex = 16;
            this.card.Visible = false;
            // 
            // signin
            // 
            this.signin.Animated = true;
            this.signin.AnimatedGIF = true;
            this.signin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(175)))), ((int)(((byte)(75)))));
            this.signin.BorderRadius = 20;
            this.signin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.signin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.signin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.signin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.signin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(175)))), ((int)(((byte)(75)))));
            this.signin.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.signin.ForeColor = System.Drawing.Color.White;
            this.signin.HoverState.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.signin.HoverState.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.signin.HoverState.ForeColor = System.Drawing.Color.White;
            this.signin.HoverState.Image = global::Barcode_Security_System.Properties.Resources.enter_50px;
            this.signin.Image = global::Barcode_Security_System.Properties.Resources.enter_50px;
            this.signin.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.signin.ImageOffset = new System.Drawing.Point(10, 0);
            this.signin.Location = new System.Drawing.Point(98, 243);
            this.signin.Name = "signin";
            this.signin.PressedDepth = 10;
            this.signin.Size = new System.Drawing.Size(146, 45);
            this.signin.TabIndex = 22;
            this.signin.Text = "Sign-in";
            this.signin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.signin.TextOffset = new System.Drawing.Point(25, 0);
            this.signin.Click += new System.EventHandler(this.signin_Click);
            // 
            // signout
            // 
            this.signout.Animated = true;
            this.signout.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.signout.BorderRadius = 20;
            this.signout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.signout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.signout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.signout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.signout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.signout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.signout.ForeColor = System.Drawing.Color.White;
            this.signout.HoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.signout.HoverState.FillColor = System.Drawing.Color.Firebrick;
            this.signout.HoverState.ForeColor = System.Drawing.Color.White;
            this.signout.HoverState.Image = global::Barcode_Security_System.Properties.Resources.logout_50px_w;
            this.signout.Image = global::Barcode_Security_System.Properties.Resources.logout_50px_w;
            this.signout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.signout.ImageOffset = new System.Drawing.Point(10, 0);
            this.signout.Location = new System.Drawing.Point(102, 243);
            this.signout.Name = "signout";
            this.signout.Size = new System.Drawing.Size(139, 45);
            this.signout.TabIndex = 21;
            this.signout.Text = "Sign-out";
            this.signout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.signout.TextOffset = new System.Drawing.Point(25, 0);
            this.signout.Click += new System.EventHandler(this.signout_Click);
            // 
            // user
            // 
            this.user.BackColor = System.Drawing.Color.White;
            this.user.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(0, 165);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(339, 16);
            this.user.TabIndex = 19;
            this.user.Text = "Daniel Doe";
            this.user.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // asset
            // 
            this.asset.BackColor = System.Drawing.Color.White;
            this.asset.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asset.Location = new System.Drawing.Point(3, 191);
            this.asset.Name = "asset";
            this.asset.Size = new System.Drawing.Size(336, 17);
            this.asset.TabIndex = 20;
            this.asset.Text = "Laptop";
            this.asset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dp
            // 
            this.dp.BackColor = System.Drawing.Color.White;
            this.dp.Image = global::Barcode_Security_System.Properties.Resources.administrator_male_50px;
            this.dp.ImageRotate = 0F;
            this.dp.Location = new System.Drawing.Point(106, 12);
            this.dp.Name = "dp";
            this.dp.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.dp.Size = new System.Drawing.Size(130, 130);
            this.dp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dp.TabIndex = 0;
            this.dp.TabStop = false;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(256, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(163, 23);
            this.label18.TabIndex = 18;
            this.label18.Text = "Check-in Station";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.guna2Button2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.guna2Button2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.guna2Button2.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = global::Barcode_Security_System.Properties.Resources.search_50px_w;
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button2.Location = new System.Drawing.Point(444, 84);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(130, 43);
            this.guna2Button2.TabIndex = 19;
            this.guna2Button2.Text = "Search";
            this.guna2Button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.TextOffset = new System.Drawing.Point(25, 0);
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button9
            // 
            this.guna2Button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button9.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button9.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button9.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button9.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.guna2Button9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button9.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button9.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2Button9.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button9.HoverState.Image = global::Barcode_Security_System.Properties.Resources.close_50px_w;
            this.guna2Button9.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button9.Image")));
            this.guna2Button9.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button9.Location = new System.Drawing.Point(641, 0);
            this.guna2Button9.Name = "guna2Button9";
            this.guna2Button9.Size = new System.Drawing.Size(42, 38);
            this.guna2Button9.TabIndex = 17;
            this.guna2Button9.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button9.Click += new System.EventHandler(this.guna2Button9_Click);
            // 
            // barcode
            // 
            this.barcode.Animated = true;
            this.barcode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.barcode.BorderRadius = 15;
            this.barcode.BorderThickness = 2;
            this.barcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.barcode.DefaultText = "";
            this.barcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.barcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.barcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.barcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.barcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.barcode.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.barcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.barcode.IconRight = global::Barcode_Security_System.Properties.Resources.Barcode_Reader_50px;
            this.barcode.IconRightOffset = new System.Drawing.Point(5, 0);
            this.barcode.IconRightSize = new System.Drawing.Size(30, 30);
            this.barcode.Location = new System.Drawing.Point(84, 84);
            this.barcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barcode.Name = "barcode";
            this.barcode.PasswordChar = '\0';
            this.barcode.PlaceholderText = "Search";
            this.barcode.SelectedText = "";
            this.barcode.Size = new System.Drawing.Size(339, 43);
            this.barcode.TabIndex = 15;
            this.barcode.TextChanged += new System.EventHandler(this.barcode_TextChanged);
            this.barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.barcode_KeyDown);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // signinBg
            // 
            this.signinBg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.signinBg_DoWork);
            // 
            // signoutBg
            // 
            this.signoutBg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.signoutBg_DoWork);
            // 
            // Checkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(684, 467);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.guna2Button9);
            this.Controls.Add(this.card);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Checkin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Checkin";
            this.card.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox barcode;
        private Guna.UI2.WinForms.Guna2Panel card;
        private Guna.UI2.WinForms.Guna2CirclePictureBox dp;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label asset;
        private Guna.UI2.WinForms.Guna2Button signout;
        private Guna.UI2.WinForms.Guna2Button guna2Button9;
        private Guna.UI2.WinForms.Guna2Button signin;
        private System.Windows.Forms.Label label18;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker signinBg;
        private System.ComponentModel.BackgroundWorker signoutBg;
    }
}