namespace StandardProgrammingAssistant.ModelGenerator
{
    partial class SqlServerModelGenerator
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
            this.gboxServer = new System.Windows.Forms.GroupBox();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxConnectAnotherServer = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.picturePassword = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboLogin = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonSqlServerAuth = new System.Windows.Forms.RadioButton();
            this.radioButtonWindowsAuth = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureTable = new System.Windows.Forms.PictureBox();
            this.pictureDb = new System.Windows.Forms.PictureBox();
            this.comboTable = new System.Windows.Forms.ComboBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.comboDb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnForSelectedDatabase = new System.Windows.Forms.Button();
            this.btnForSelectedTable = new System.Windows.Forms.Button();
            this.comboFilePrefences = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNamespace = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxCsharp = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxFlutter = new System.Windows.Forms.TextBox();
            this.pictureBoxUserGuide = new System.Windows.Forms.PictureBox();
            this.pictureBoxRelease = new System.Windows.Forms.PictureBox();
            this.pictureConnect = new System.Windows.Forms.PictureBox();
            this.lblConnect = new System.Windows.Forms.Label();
            this.gboxServer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassword)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDb)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserGuide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureConnect)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxServer
            // 
            this.gboxServer.Controls.Add(this.textBoxServerIP);
            this.gboxServer.Controls.Add(this.label1);
            this.gboxServer.Controls.Add(this.checkBoxConnectAnotherServer);
            this.gboxServer.Location = new System.Drawing.Point(12, 12);
            this.gboxServer.Name = "gboxServer";
            this.gboxServer.Size = new System.Drawing.Size(229, 137);
            this.gboxServer.TabIndex = 0;
            this.gboxServer.TabStop = false;
            this.gboxServer.Text = "Server";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Enabled = false;
            this.textBoxServerIP.Location = new System.Drawing.Point(9, 72);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(144, 20);
            this.textBoxServerIP.TabIndex = 2;
            this.textBoxServerIP.Text = "127.0.0.1";
            this.textBoxServerIP.TextChanged += new System.EventHandler(this.textBoxServerIP_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server IP";
            // 
            // checkBoxConnectAnotherServer
            // 
            this.checkBoxConnectAnotherServer.AutoSize = true;
            this.checkBoxConnectAnotherServer.Location = new System.Drawing.Point(9, 21);
            this.checkBoxConnectAnotherServer.Name = "checkBoxConnectAnotherServer";
            this.checkBoxConnectAnotherServer.Size = new System.Drawing.Size(203, 17);
            this.checkBoxConnectAnotherServer.TabIndex = 0;
            this.checkBoxConnectAnotherServer.Text = "Connect to another server (!localhost)";
            this.checkBoxConnectAnotherServer.UseVisualStyleBackColor = true;
            this.checkBoxConnectAnotherServer.CheckedChanged += new System.EventHandler(this.checkBoxConnectAnotherServer_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.picturePassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboLogin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioButtonSqlServerAuth);
            this.groupBox1.Controls.Add(this.radioButtonWindowsAuth);
            this.groupBox1.Location = new System.Drawing.Point(263, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 137);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Authentication";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.Enabled = false;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(214, 99);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(87, 32);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            this.btnConnect.MouseLeave += new System.EventHandler(this.btnConnect_MouseLeave);
            this.btnConnect.MouseHover += new System.EventHandler(this.btnConnect_MouseHover);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(165, 73);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(136, 20);
            this.textBoxPassword.TabIndex = 6;
            // 
            // picturePassword
            // 
            this.picturePassword.Image = global::StandardProgrammingAssistant.Properties.Resources.eye;
            this.picturePassword.Location = new System.Drawing.Point(277, 56);
            this.picturePassword.Name = "picturePassword";
            this.picturePassword.Size = new System.Drawing.Size(16, 13);
            this.picturePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePassword.TabIndex = 5;
            this.picturePassword.TabStop = false;
            this.picturePassword.MouseLeave += new System.EventHandler(this.picturePassword_MouseLeave);
            this.picturePassword.MouseHover += new System.EventHandler(this.picturePassword_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // comboLogin
            // 
            this.comboLogin.FormattingEnabled = true;
            this.comboLogin.Location = new System.Drawing.Point(6, 72);
            this.comboLogin.Name = "comboLogin";
            this.comboLogin.Size = new System.Drawing.Size(129, 21);
            this.comboLogin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Login";
            // 
            // radioButtonSqlServerAuth
            // 
            this.radioButtonSqlServerAuth.AutoSize = true;
            this.radioButtonSqlServerAuth.Location = new System.Drawing.Point(165, 20);
            this.radioButtonSqlServerAuth.Name = "radioButtonSqlServerAuth";
            this.radioButtonSqlServerAuth.Size = new System.Drawing.Size(145, 17);
            this.radioButtonSqlServerAuth.TabIndex = 1;
            this.radioButtonSqlServerAuth.Text = "Sql Server Authentication";
            this.radioButtonSqlServerAuth.UseVisualStyleBackColor = true;
            this.radioButtonSqlServerAuth.Click += new System.EventHandler(this.radioButtonSqlServerAuth_Click);
            // 
            // radioButtonWindowsAuth
            // 
            this.radioButtonWindowsAuth.AutoSize = true;
            this.radioButtonWindowsAuth.Checked = true;
            this.radioButtonWindowsAuth.Location = new System.Drawing.Point(7, 20);
            this.radioButtonWindowsAuth.Name = "radioButtonWindowsAuth";
            this.radioButtonWindowsAuth.Size = new System.Drawing.Size(140, 17);
            this.radioButtonWindowsAuth.TabIndex = 0;
            this.radioButtonWindowsAuth.TabStop = true;
            this.radioButtonWindowsAuth.Text = "Windows Authentication";
            this.radioButtonWindowsAuth.UseVisualStyleBackColor = true;
            this.radioButtonWindowsAuth.Click += new System.EventHandler(this.radioButtonWindowsAuth_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureTable);
            this.groupBox2.Controls.Add(this.pictureDb);
            this.groupBox2.Controls.Add(this.comboTable);
            this.groupBox2.Controls.Add(this.lblTable);
            this.groupBox2.Controls.Add(this.comboDb);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database and table selection area";
            // 
            // pictureTable
            // 
            this.pictureTable.Image = global::StandardProgrammingAssistant.Properties.Resources.check;
            this.pictureTable.Location = new System.Drawing.Point(182, 97);
            this.pictureTable.Name = "pictureTable";
            this.pictureTable.Size = new System.Drawing.Size(30, 20);
            this.pictureTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTable.TabIndex = 9;
            this.pictureTable.TabStop = false;
            this.pictureTable.Visible = false;
            // 
            // pictureDb
            // 
            this.pictureDb.Image = global::StandardProgrammingAssistant.Properties.Resources.check;
            this.pictureDb.Location = new System.Drawing.Point(182, 41);
            this.pictureDb.Name = "pictureDb";
            this.pictureDb.Size = new System.Drawing.Size(29, 21);
            this.pictureDb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureDb.TabIndex = 8;
            this.pictureDb.TabStop = false;
            this.pictureDb.Visible = false;
            // 
            // comboTable
            // 
            this.comboTable.FormattingEnabled = true;
            this.comboTable.Location = new System.Drawing.Point(6, 97);
            this.comboTable.Name = "comboTable";
            this.comboTable.Size = new System.Drawing.Size(169, 21);
            this.comboTable.TabIndex = 7;
            this.comboTable.SelectedIndexChanged += new System.EventHandler(this.comboTable_SelectedIndexChanged);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(6, 81);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(34, 13);
            this.lblTable.TabIndex = 6;
            this.lblTable.Text = "Table";
            // 
            // comboDb
            // 
            this.comboDb.FormattingEnabled = true;
            this.comboDb.Location = new System.Drawing.Point(6, 41);
            this.comboDb.Name = "comboDb";
            this.comboDb.Size = new System.Drawing.Size(169, 21);
            this.comboDb.TabIndex = 5;
            this.comboDb.SelectedIndexChanged += new System.EventHandler(this.comboDb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Database";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnForSelectedDatabase);
            this.groupBox3.Controls.Add(this.btnForSelectedTable);
            this.groupBox3.Controls.Add(this.comboFilePrefences);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(286, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 138);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Write the file on desktop";
            // 
            // btnForSelectedDatabase
            // 
            this.btnForSelectedDatabase.Location = new System.Drawing.Point(156, 81);
            this.btnForSelectedDatabase.Name = "btnForSelectedDatabase";
            this.btnForSelectedDatabase.Size = new System.Drawing.Size(122, 36);
            this.btnForSelectedDatabase.TabIndex = 8;
            this.btnForSelectedDatabase.Text = "All table for selected database";
            this.btnForSelectedDatabase.UseVisualStyleBackColor = true;
            this.btnForSelectedDatabase.Click += new System.EventHandler(this.btnForSelectedDatabase_Click);
            // 
            // btnForSelectedTable
            // 
            this.btnForSelectedTable.Location = new System.Drawing.Point(10, 81);
            this.btnForSelectedTable.Name = "btnForSelectedTable";
            this.btnForSelectedTable.Size = new System.Drawing.Size(122, 36);
            this.btnForSelectedTable.TabIndex = 7;
            this.btnForSelectedTable.Text = "Selected Table";
            this.btnForSelectedTable.UseVisualStyleBackColor = true;
            this.btnForSelectedTable.Click += new System.EventHandler(this.btnForSelectedTable_Click);
            // 
            // comboFilePrefences
            // 
            this.comboFilePrefences.FormattingEnabled = true;
            this.comboFilePrefences.Items.AddRange(new object[] {
            "Both",
            "Flutter",
            "C#"});
            this.comboFilePrefences.Location = new System.Drawing.Point(10, 41);
            this.comboFilePrefences.Name = "comboFilePrefences";
            this.comboFilePrefences.Size = new System.Drawing.Size(277, 21);
            this.comboFilePrefences.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Flutter , C# or Both";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBoxNamespace);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(12, 313);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(578, 72);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "( Optional )";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(256, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "projectname.foldername";
            // 
            // textBoxNamespace
            // 
            this.textBoxNamespace.Location = new System.Drawing.Point(73, 22);
            this.textBoxNamespace.Name = "textBoxNamespace";
            this.textBoxNamespace.Size = new System.Drawing.Size(497, 20);
            this.textBoxNamespace.TabIndex = 6;
            this.textBoxNamespace.TextChanged += new System.EventHandler(this.textBoxNamespace_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Namespace";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tabControl1);
            this.groupBox5.Location = new System.Drawing.Point(12, 405);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(578, 297);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "If you have created model file use this screen.";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(566, 272);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxCsharp);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(558, 246);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "C# Model";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxCsharp
            // 
            this.textBoxCsharp.Location = new System.Drawing.Point(-1, 0);
            this.textBoxCsharp.Multiline = true;
            this.textBoxCsharp.Name = "textBoxCsharp";
            this.textBoxCsharp.Size = new System.Drawing.Size(563, 250);
            this.textBoxCsharp.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxFlutter);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(558, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Flutter Model";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxFlutter
            // 
            this.textBoxFlutter.Location = new System.Drawing.Point(-4, 0);
            this.textBoxFlutter.Multiline = true;
            this.textBoxFlutter.Name = "textBoxFlutter";
            this.textBoxFlutter.Size = new System.Drawing.Size(562, 250);
            this.textBoxFlutter.TabIndex = 0;
            // 
            // pictureBoxUserGuide
            // 
            this.pictureBoxUserGuide.Image = global::StandardProgrammingAssistant.Properties.Resources.document;
            this.pictureBoxUserGuide.Location = new System.Drawing.Point(553, 708);
            this.pictureBoxUserGuide.Name = "pictureBoxUserGuide";
            this.pictureBoxUserGuide.Size = new System.Drawing.Size(35, 24);
            this.pictureBoxUserGuide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUserGuide.TabIndex = 10;
            this.pictureBoxUserGuide.TabStop = false;
            this.pictureBoxUserGuide.Click += new System.EventHandler(this.pictureBoxUserGuide_Click);
            // 
            // pictureBoxRelease
            // 
            this.pictureBoxRelease.Image = global::StandardProgrammingAssistant.Properties.Resources.indir;
            this.pictureBoxRelease.Location = new System.Drawing.Point(505, 708);
            this.pictureBoxRelease.Name = "pictureBoxRelease";
            this.pictureBoxRelease.Size = new System.Drawing.Size(33, 24);
            this.pictureBoxRelease.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRelease.TabIndex = 9;
            this.pictureBoxRelease.TabStop = false;
            this.pictureBoxRelease.Click += new System.EventHandler(this.pictureBoxRelease_Click);
            // 
            // pictureConnect
            // 
            this.pictureConnect.Image = global::StandardProgrammingAssistant.Properties.Resources.check;
            this.pictureConnect.Location = new System.Drawing.Point(12, 718);
            this.pictureConnect.Name = "pictureConnect";
            this.pictureConnect.Size = new System.Drawing.Size(17, 14);
            this.pictureConnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureConnect.TabIndex = 11;
            this.pictureConnect.TabStop = false;
            this.pictureConnect.Visible = false;
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Location = new System.Drawing.Point(35, 719);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(59, 13);
            this.lblConnect.TabIndex = 12;
            this.lblConnect.Text = "Connected";
            this.lblConnect.Visible = false;
            // 
            // SqlServerModelGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 744);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.pictureConnect);
            this.Controls.Add(this.pictureBoxUserGuide);
            this.Controls.Add(this.pictureBoxRelease);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SqlServerModelGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SqlServerModelGenerator";
            this.Load += new System.EventHandler(this.SqlServerModelGenerator_Load);
            this.gboxServer.ResumeLayout(false);
            this.gboxServer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassword)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDb)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserGuide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureConnect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxServer;
        private System.Windows.Forms.CheckBox checkBoxConnectAnotherServer;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonSqlServerAuth;
        private System.Windows.Forms.RadioButton radioButtonWindowsAuth;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.PictureBox picturePassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboDb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboTable;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.PictureBox pictureTable;
        private System.Windows.Forms.PictureBox pictureDb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnForSelectedDatabase;
        private System.Windows.Forms.Button btnForSelectedTable;
        private System.Windows.Forms.ComboBox comboFilePrefences;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNamespace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBoxRelease;
        private System.Windows.Forms.PictureBox pictureBoxUserGuide;
        private System.Windows.Forms.TextBox textBoxCsharp;
        private System.Windows.Forms.TextBox textBoxFlutter;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.PictureBox pictureConnect;
        private System.Windows.Forms.Label lblConnect;
    }
}