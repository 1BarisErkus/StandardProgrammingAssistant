using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandardProgrammingAssistant.JoinTable
{
    public partial class JoinTableGenerator : Form
    {
        string connectionStringFirst = "data source=localhost; initial catalog=master; MultipleActiveResultSets=true; Trusted_Connection=true;";
        string connectionStringforSelectedDB = "";

        int totalDbCount = 0;
        int totalTableCountForSelectedDb = 0;
        int totalColumnCount = 0;

        string SelectedDb = "";
        string SelectedTable = "";

        List<string> listDatabases = new List<string>();
        List<string> listTables = new List<string>();
        List<string> listColumn = new List<string>();
        List<string> listDataType = new List<string>();
        List<string> listDataTypeSize = new List<string>();

        string fileText = "";
        string filePath = "";


        int connectionType = -1;

        void getSystemDbsCount()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringFirst))
                {
                    var sql = @"SELECT COUNT(name) FROM sys.databases
                                WHERE name NOT LIKE 'master'
                                AND name NOT LIKE 'tempdb'
                                AND name NOT LIKE 'model'
                                AND name NOT LIKE 'msdb'";

                    totalDbCount = connection.QuerySingle<int>(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
            }
        }
        void getAllDbsName()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringFirst))
                {
                    var sql = @"SELECT name FROM sys.databases
                                WHERE name NOT LIKE 'master' 
                                AND name NOT LIKE 'tempdb'
                                AND name NOT LIKE 'model'
                                AND name NOT LIKE 'msdb'";

                    listDatabases = connection.Query<string>(sql).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to retrieve Db names.");
            }
        }
        void addDbNametoCombobox()
        {
            comboDb.Items.Clear();
            for (int i = 0; i < totalDbCount; i++)
            {
                comboDb.Items.Add(listDatabases[i]);
            }
        }
        void getTableCountforSelectedDb()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringforSelectedDB))
                {
                    var sql = @"SELECT COUNT(*) FROM sys.tables
                                WHERE name NOT LIKE 'sysdiagrams'";

                    totalTableCountForSelectedDb = connection.QuerySingle<int>(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void getTablesforSelectedDb()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringforSelectedDB))
                {
                    var sql = @"SELECT name FROM sys.tables 
                                WHERE name NOT LIKE 'sysdiagrams'";

                    listTables = connection.Query<string>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void addTableNametoCombobox()
        {
            comboTable1.Items.Clear();
            comboTable2.Items.Clear();
            comboTable3.Items.Clear();
            comboTable4.Items.Clear();
            comboTable5.Items.Clear();
            switch (numericNumberofTable.Value)
            {
                case 2:
                    for (int i = 0; i < totalTableCountForSelectedDb; i++)
                    {
                        comboTable1.Items.Add(listTables[i]);
                        comboTable2.Items.Add(listTables[i]);
                    }
                    break;
                case 3:
                    for (int i = 0; i < totalTableCountForSelectedDb; i++)
                    {
                        comboTable1.Items.Add(listTables[i]);
                        comboTable2.Items.Add(listTables[i]);
                        comboTable3.Items.Add(listTables[i]);
                    }
                    break;
                case 4:
                    for (int i = 0; i < totalTableCountForSelectedDb; i++)
                    {
                        comboTable1.Items.Add(listTables[i]);
                        comboTable2.Items.Add(listTables[i]);
                        comboTable3.Items.Add(listTables[i]);
                        comboTable4.Items.Add(listTables[i]);
                    }
                    break;
                case 5:
                    for (int i = 0; i < totalTableCountForSelectedDb; i++)
                    {
                        comboTable1.Items.Add(listTables[i]);
                        comboTable2.Items.Add(listTables[i]);
                        comboTable3.Items.Add(listTables[i]);
                        comboTable4.Items.Add(listTables[i]);
                        comboTable5.Items.Add(listTables[i]);
                    }
                    break;
                default:
                    break;
            }
        }

        public JoinTableGenerator()
        {
            InitializeComponent();
        }

        private void JoinTableGenerator_Load(object sender, EventArgs e)
        {
            getSystemDbsCount();
            getAllDbsName();
            addDbNametoCombobox();
        }

        private void numericNumberofTable_ValueChanged(object sender, EventArgs e)
        {
            switch (numericNumberofTable.Value)
            {
                case 2:
                    label3.Visible = false;
                    comboTable3.Visible = false;
                    comboTable3.Text = "";

                    label4.Visible = false;
                    comboTable4.Visible = false;
                    comboTable4.Text = "";

                    label5.Visible = false;
                    comboTable5.Visible = false;
                    comboTable5.Text = "";
                    break;
                case 3:
                    label3.Visible = true;
                    comboTable3.Visible = true;

                    label4.Visible = false;
                    comboTable4.Visible = false;
                    comboTable4.Text = "";

                    label5.Visible = false;
                    comboTable5.Visible = false;
                    comboTable5.Text = "";
                    break;
                case 4:
                    label3.Visible = true;
                    comboTable3.Visible = true;

                    label4.Visible = true;
                    comboTable4.Visible = true;

                    label5.Visible = false;
                    comboTable5.Visible = false;
                    comboTable5.Text = "";
                    break;
                case 5:
                    label3.Visible = true;
                    comboTable3.Visible = true;

                    label4.Visible = true;
                    comboTable4.Visible = true;

                    label5.Visible = true;
                    comboTable5.Visible = true;
                    break;
                default:
                    break;
            }
            if (comboDb.SelectedIndex > 0)
            {
                getTableCountforSelectedDb();
                getTablesforSelectedDb();
                addTableNametoCombobox();
            }
        }

        private void comboDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDb.SelectedItem != null)
            {
                SelectedDb = comboDb.SelectedItem.ToString();
                connectionStringforSelectedDB = "data source=localhost; initial catalog=" + SelectedDb + "; MultipleActiveResultSets=true; Trusted_Connection=true;";

                getTableCountforSelectedDb();
                getTablesforSelectedDb();
                addTableNametoCombobox();

                pictureDb.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select database.");
            }
        }
    }
}
