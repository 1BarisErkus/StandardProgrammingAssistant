using StandardProgrammingAssistant.ModelGenerator;
using StandardProgrammingAssistant.StoredProcedureGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandardProgrammingAssistant
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public void GetTheForm(Form form, Panel panelName)
        {
            form.TopLevel = false;
            panelName.Controls.Add(form);
            form.Show();
            form.Dock = DockStyle.Fill;
            form.BringToFront();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            StoredProcedureGenerator.StoredProcedureGenerator storedProcedureGenerator = new StoredProcedureGenerator.StoredProcedureGenerator();
            ModelGenerator.SqlServerModelGenerator sqlServerModelGenerator = new ModelGenerator.SqlServerModelGenerator();
            JoinTable.JoinTableGenerator joinTableGenerator = new JoinTable.JoinTableGenerator();
            GetTheForm(storedProcedureGenerator, panel1);
            GetTheForm(sqlServerModelGenerator, panel2);
            GetTheForm(joinTableGenerator, panel3);
        }
    }
}
