namespace StandardProgrammingAssistant.StoredProcedureGenerator
{
    partial class StoredProcedureGenerator
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
            this.gboxDbTable = new System.Windows.Forms.GroupBox();
            this.pictureTable = new System.Windows.Forms.PictureBox();
            this.pictureDb = new System.Windows.Forms.PictureBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.comboTable = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.comboDb = new System.Windows.Forms.ComboBox();
            this.gboxWrite = new System.Windows.Forms.GroupBox();
            this.btnAllTable = new System.Windows.Forms.Button();
            this.btnSelectedTable = new System.Windows.Forms.Button();
            this.gboxIfYouHave = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSelectwText = new System.Windows.Forms.TabPage();
            this.textBoxSelectwText = new System.Windows.Forms.TextBox();
            this.tabSelectwId = new System.Windows.Forms.TabPage();
            this.textBoxSelectwId = new System.Windows.Forms.TextBox();
            this.tabDelete = new System.Windows.Forms.TabPage();
            this.textBoxDelete = new System.Windows.Forms.TextBox();
            this.tabUpdate = new System.Windows.Forms.TabPage();
            this.textBoxUpdate = new System.Windows.Forms.TextBox();
            this.tabInsert = new System.Windows.Forms.TabPage();
            this.textBoxInsert = new System.Windows.Forms.TextBox();
            this.tabExecuteSp = new System.Windows.Forms.TabPage();
            this.textBoxExecuteSp = new System.Windows.Forms.TextBox();
            this.gboxDbTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDb)).BeginInit();
            this.gboxWrite.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSelectwText.SuspendLayout();
            this.tabSelectwId.SuspendLayout();
            this.tabDelete.SuspendLayout();
            this.tabUpdate.SuspendLayout();
            this.tabInsert.SuspendLayout();
            this.tabExecuteSp.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxDbTable
            // 
            this.gboxDbTable.Controls.Add(this.pictureTable);
            this.gboxDbTable.Controls.Add(this.pictureDb);
            this.gboxDbTable.Controls.Add(this.lblTable);
            this.gboxDbTable.Controls.Add(this.comboTable);
            this.gboxDbTable.Controls.Add(this.lblDatabase);
            this.gboxDbTable.Controls.Add(this.comboDb);
            this.gboxDbTable.Location = new System.Drawing.Point(12, 12);
            this.gboxDbTable.Name = "gboxDbTable";
            this.gboxDbTable.Size = new System.Drawing.Size(266, 232);
            this.gboxDbTable.TabIndex = 0;
            this.gboxDbTable.TabStop = false;
            this.gboxDbTable.Text = "Database and table selection area";
            // 
            // pictureTable
            // 
            this.pictureTable.Image = global::StandardProgrammingAssistant.Properties.Resources.check;
            this.pictureTable.Location = new System.Drawing.Point(187, 129);
            this.pictureTable.Name = "pictureTable";
            this.pictureTable.Size = new System.Drawing.Size(26, 21);
            this.pictureTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTable.TabIndex = 5;
            this.pictureTable.TabStop = false;
            this.pictureTable.Visible = false;
            // 
            // pictureDb
            // 
            this.pictureDb.Image = global::StandardProgrammingAssistant.Properties.Resources.check;
            this.pictureDb.Location = new System.Drawing.Point(187, 61);
            this.pictureDb.Name = "pictureDb";
            this.pictureDb.Size = new System.Drawing.Size(26, 21);
            this.pictureDb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureDb.TabIndex = 4;
            this.pictureDb.TabStop = false;
            this.pictureDb.Visible = false;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(15, 113);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(34, 13);
            this.lblTable.TabIndex = 3;
            this.lblTable.Text = "Table";
            // 
            // comboTable
            // 
            this.comboTable.FormattingEnabled = true;
            this.comboTable.Location = new System.Drawing.Point(15, 129);
            this.comboTable.Name = "comboTable";
            this.comboTable.Size = new System.Drawing.Size(166, 21);
            this.comboTable.TabIndex = 2;
            this.comboTable.SelectedIndexChanged += new System.EventHandler(this.comboTable_SelectedIndexChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(15, 45);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(53, 13);
            this.lblDatabase.TabIndex = 1;
            this.lblDatabase.Text = "Database";
            // 
            // comboDb
            // 
            this.comboDb.FormattingEnabled = true;
            this.comboDb.Location = new System.Drawing.Point(15, 61);
            this.comboDb.Name = "comboDb";
            this.comboDb.Size = new System.Drawing.Size(166, 21);
            this.comboDb.TabIndex = 0;
            this.comboDb.SelectedIndexChanged += new System.EventHandler(this.comboDb_SelectedIndexChanged);
            // 
            // gboxWrite
            // 
            this.gboxWrite.Controls.Add(this.btnAllTable);
            this.gboxWrite.Controls.Add(this.btnSelectedTable);
            this.gboxWrite.Location = new System.Drawing.Point(301, 12);
            this.gboxWrite.Name = "gboxWrite";
            this.gboxWrite.Size = new System.Drawing.Size(266, 232);
            this.gboxWrite.TabIndex = 1;
            this.gboxWrite.TabStop = false;
            this.gboxWrite.Text = "Write the file on desktop";
            // 
            // btnAllTable
            // 
            this.btnAllTable.Location = new System.Drawing.Point(6, 129);
            this.btnAllTable.Name = "btnAllTable";
            this.btnAllTable.Size = new System.Drawing.Size(245, 63);
            this.btnAllTable.TabIndex = 1;
            this.btnAllTable.Text = "Create All Procedure For Selected Database";
            this.btnAllTable.UseVisualStyleBackColor = true;
            this.btnAllTable.Click += new System.EventHandler(this.btnAllTable_Click);
            // 
            // btnSelectedTable
            // 
            this.btnSelectedTable.Location = new System.Drawing.Point(6, 39);
            this.btnSelectedTable.Name = "btnSelectedTable";
            this.btnSelectedTable.Size = new System.Drawing.Size(245, 63);
            this.btnSelectedTable.TabIndex = 0;
            this.btnSelectedTable.Text = "Create Procedure For Selected Table";
            this.btnSelectedTable.UseVisualStyleBackColor = true;
            this.btnSelectedTable.Click += new System.EventHandler(this.btnSelectedTable_Click);
            // 
            // gboxIfYouHave
            // 
            this.gboxIfYouHave.Location = new System.Drawing.Point(12, 259);
            this.gboxIfYouHave.Name = "gboxIfYouHave";
            this.gboxIfYouHave.Size = new System.Drawing.Size(555, 310);
            this.gboxIfYouHave.TabIndex = 2;
            this.gboxIfYouHave.TabStop = false;
            this.gboxIfYouHave.Text = "If you have created model file use this screen.";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSelectwText);
            this.tabControl1.Controls.Add(this.tabSelectwId);
            this.tabControl1.Controls.Add(this.tabDelete);
            this.tabControl1.Controls.Add(this.tabUpdate);
            this.tabControl1.Controls.Add(this.tabInsert);
            this.tabControl1.Controls.Add(this.tabExecuteSp);
            this.tabControl1.Location = new System.Drawing.Point(18, 278);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 285);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSelectwText
            // 
            this.tabSelectwText.Controls.Add(this.textBoxSelectwText);
            this.tabSelectwText.Location = new System.Drawing.Point(4, 22);
            this.tabSelectwText.Name = "tabSelectwText";
            this.tabSelectwText.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelectwText.Size = new System.Drawing.Size(535, 259);
            this.tabSelectwText.TabIndex = 0;
            this.tabSelectwText.Text = "Select\"";
            this.tabSelectwText.UseVisualStyleBackColor = true;
            // 
            // textBoxSelectwText
            // 
            this.textBoxSelectwText.Location = new System.Drawing.Point(0, 0);
            this.textBoxSelectwText.Multiline = true;
            this.textBoxSelectwText.Name = "textBoxSelectwText";
            this.textBoxSelectwText.Size = new System.Drawing.Size(539, 263);
            this.textBoxSelectwText.TabIndex = 0;
            // 
            // tabSelectwId
            // 
            this.tabSelectwId.Controls.Add(this.textBoxSelectwId);
            this.tabSelectwId.Location = new System.Drawing.Point(4, 22);
            this.tabSelectwId.Name = "tabSelectwId";
            this.tabSelectwId.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelectwId.Size = new System.Drawing.Size(535, 259);
            this.tabSelectwId.TabIndex = 1;
            this.tabSelectwId.Text = "Select_Id";
            this.tabSelectwId.UseVisualStyleBackColor = true;
            // 
            // textBoxSelectwId
            // 
            this.textBoxSelectwId.Location = new System.Drawing.Point(0, 0);
            this.textBoxSelectwId.Multiline = true;
            this.textBoxSelectwId.Name = "textBoxSelectwId";
            this.textBoxSelectwId.Size = new System.Drawing.Size(539, 263);
            this.textBoxSelectwId.TabIndex = 0;
            // 
            // tabDelete
            // 
            this.tabDelete.Controls.Add(this.textBoxDelete);
            this.tabDelete.Location = new System.Drawing.Point(4, 22);
            this.tabDelete.Name = "tabDelete";
            this.tabDelete.Padding = new System.Windows.Forms.Padding(3);
            this.tabDelete.Size = new System.Drawing.Size(535, 259);
            this.tabDelete.TabIndex = 2;
            this.tabDelete.Text = "Delete";
            this.tabDelete.UseVisualStyleBackColor = true;
            // 
            // textBoxDelete
            // 
            this.textBoxDelete.Location = new System.Drawing.Point(3, 0);
            this.textBoxDelete.Multiline = true;
            this.textBoxDelete.Name = "textBoxDelete";
            this.textBoxDelete.Size = new System.Drawing.Size(536, 263);
            this.textBoxDelete.TabIndex = 0;
            // 
            // tabUpdate
            // 
            this.tabUpdate.Controls.Add(this.textBoxUpdate);
            this.tabUpdate.Location = new System.Drawing.Point(4, 22);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdate.Size = new System.Drawing.Size(535, 259);
            this.tabUpdate.TabIndex = 3;
            this.tabUpdate.Text = "Update";
            this.tabUpdate.UseVisualStyleBackColor = true;
            // 
            // textBoxUpdate
            // 
            this.textBoxUpdate.Location = new System.Drawing.Point(0, 0);
            this.textBoxUpdate.Multiline = true;
            this.textBoxUpdate.Name = "textBoxUpdate";
            this.textBoxUpdate.Size = new System.Drawing.Size(539, 263);
            this.textBoxUpdate.TabIndex = 0;
            // 
            // tabInsert
            // 
            this.tabInsert.Controls.Add(this.textBoxInsert);
            this.tabInsert.Location = new System.Drawing.Point(4, 22);
            this.tabInsert.Name = "tabInsert";
            this.tabInsert.Padding = new System.Windows.Forms.Padding(3);
            this.tabInsert.Size = new System.Drawing.Size(535, 259);
            this.tabInsert.TabIndex = 4;
            this.tabInsert.Text = "Insert";
            this.tabInsert.UseVisualStyleBackColor = true;
            // 
            // textBoxInsert
            // 
            this.textBoxInsert.Location = new System.Drawing.Point(0, 0);
            this.textBoxInsert.Multiline = true;
            this.textBoxInsert.Name = "textBoxInsert";
            this.textBoxInsert.Size = new System.Drawing.Size(539, 263);
            this.textBoxInsert.TabIndex = 0;
            // 
            // tabExecuteSp
            // 
            this.tabExecuteSp.Controls.Add(this.textBoxExecuteSp);
            this.tabExecuteSp.Location = new System.Drawing.Point(4, 22);
            this.tabExecuteSp.Name = "tabExecuteSp";
            this.tabExecuteSp.Padding = new System.Windows.Forms.Padding(3);
            this.tabExecuteSp.Size = new System.Drawing.Size(535, 259);
            this.tabExecuteSp.TabIndex = 5;
            this.tabExecuteSp.Text = "Execute Sp";
            this.tabExecuteSp.UseVisualStyleBackColor = true;
            // 
            // textBoxExecuteSp
            // 
            this.textBoxExecuteSp.Location = new System.Drawing.Point(3, 0);
            this.textBoxExecuteSp.Multiline = true;
            this.textBoxExecuteSp.Name = "textBoxExecuteSp";
            this.textBoxExecuteSp.Size = new System.Drawing.Size(536, 263);
            this.textBoxExecuteSp.TabIndex = 0;
            // 
            // StoredProcedureGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 589);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gboxIfYouHave);
            this.Controls.Add(this.gboxWrite);
            this.Controls.Add(this.gboxDbTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StoredProcedureGenerator";
            this.Text = "StoredProcedureGenerator";
            this.Load += new System.EventHandler(this.StoredProcedureGenerator_Load);
            this.gboxDbTable.ResumeLayout(false);
            this.gboxDbTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDb)).EndInit();
            this.gboxWrite.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabSelectwText.ResumeLayout(false);
            this.tabSelectwText.PerformLayout();
            this.tabSelectwId.ResumeLayout(false);
            this.tabSelectwId.PerformLayout();
            this.tabDelete.ResumeLayout(false);
            this.tabDelete.PerformLayout();
            this.tabUpdate.ResumeLayout(false);
            this.tabUpdate.PerformLayout();
            this.tabInsert.ResumeLayout(false);
            this.tabInsert.PerformLayout();
            this.tabExecuteSp.ResumeLayout(false);
            this.tabExecuteSp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxDbTable;
        private System.Windows.Forms.PictureBox pictureTable;
        private System.Windows.Forms.PictureBox pictureDb;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox comboTable;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ComboBox comboDb;
        private System.Windows.Forms.GroupBox gboxWrite;
        private System.Windows.Forms.Button btnAllTable;
        private System.Windows.Forms.Button btnSelectedTable;
        private System.Windows.Forms.GroupBox gboxIfYouHave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSelectwText;
        private System.Windows.Forms.TabPage tabSelectwId;
        private System.Windows.Forms.TabPage tabDelete;
        private System.Windows.Forms.TabPage tabUpdate;
        private System.Windows.Forms.TabPage tabInsert;
        private System.Windows.Forms.TabPage tabExecuteSp;
        private System.Windows.Forms.TextBox textBoxSelectwText;
        private System.Windows.Forms.TextBox textBoxSelectwId;
        private System.Windows.Forms.TextBox textBoxDelete;
        private System.Windows.Forms.TextBox textBoxUpdate;
        private System.Windows.Forms.TextBox textBoxInsert;
        private System.Windows.Forms.TextBox textBoxExecuteSp;
    }
}