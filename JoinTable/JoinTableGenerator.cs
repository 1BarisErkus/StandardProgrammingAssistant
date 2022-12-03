using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        string sqlJoin = "SELECT ";

        int totalDbCount = 0;
        int totalTableCountForSelectedDb = 0;
        int totalColumnCount = 0;

        string SelectedDb = "";
        string SelectedTable = "";
        string SelectedColumn = "";
        string selectedTableSingular = "";

        List<string> listDatabases = new List<string>();
        List<string> listTables = new List<string>();
        List<string> listColumns = new List<string>();
        List<string> listDataType = new List<string>();
        List<string> listDataTypeSize = new List<string>();

        string fileText = "";
        string staticFilePath = "";


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
            for (int i = 0; i < totalTableCountForSelectedDb; i++)
            {
                comboTable1.Items.Add(listTables[i]);
                comboTable2.Items.Add(listTables[i]);
                comboTable3.Items.Add(listTables[i]);
                comboTable4.Items.Add(listTables[i]);
                comboTable5.Items.Add(listTables[i]);
            }
        }
        void addTableNametoComboboxforNewDatabaseSelection()
        {
            comboTable1.Items.Clear();
            comboTable2.Items.Clear();
            comboTable3.Items.Clear();
            comboTable4.Items.Clear();
            comboTable5.Items.Clear();

            addTableNametoCombobox();
        }
        void getColumnsforSelectedTable()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringforSelectedDB))
                {
                    var sql = @"SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('" + SelectedTable + "')";

                    listColumns = connection.Query<string>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void addColumnNametoCombobox(ComboBox comboTableColumn)
        {
            btnWriteonDesktop.Enabled = false;

            comboTableColumn.Items.Clear();
            comboTableColumn.SelectedIndex = -1;
            comboTableColumn.Text = "";
            for (int i = 0; i < listColumns.Count; i++)
            {
                comboTableColumn.Items.Add(listColumns[i]);
            }
        }
        void WritetoTextBoxJoin()
        {
            textBoxJoinQuery.Clear();
            sqlJoin = "SELECT " + Environment.NewLine;

            string table1 = comboTable1.SelectedItem.ToString();
            string table2 = comboTable2.SelectedItem.ToString();
            string table3 = "";
            string table4 = "";
            string table5 = "";

            string singularTable1 = makeSelectedTableSingular(table1);
            string singularTable2 = makeSelectedTableSingular(table2);
            string singularTable3 = "";
            string singularTable4 = "";
            string singularTable5 = "";
            for (int i = 0; i < comboTable1Columns.Items.Count; i++)
            {
                if (i == 0)
                {
                    sqlJoin += table1 + "." + comboTable1Columns.Items[i] + " AS " + singularTable1 + comboTable1Columns.Items[i] + Environment.NewLine;
                }
                else
                {
                    sqlJoin += "," + table1 + "." + comboTable1Columns.Items[i] + " AS " + singularTable1 + comboTable1Columns.Items[i] + Environment.NewLine;
                }
            }

            for (int i = 0; i < comboTable2Columns.Items.Count; i++)
            {
                sqlJoin += "," + table2 + "." + comboTable2Columns.Items[i] + " AS " + singularTable2 + comboTable2Columns.Items[i] + Environment.NewLine;
            }

            switch (numericNumberofTable.Value)
            {
                case 2:
                    sqlJoin += " FROM " + table1 + Environment.NewLine
                    + " JOIN " + table2 + Environment.NewLine
                    + " ON " + table1 + "." + comboTable1Columns.Items[comboTable1Columns.SelectedIndex]
                    + "="
                    + table2 + "." + comboTable2Columns.Items[comboTable2Columns.SelectedIndex];

                    textBoxJoinQuery.AppendText(sqlJoin);
                    break;
                case 3:
                    table3 = comboTable3.SelectedItem.ToString();
                    singularTable3 = makeSelectedTableSingular(table3);

                    for (int i = 0; i < comboTable3Columns.Items.Count; i++)
                    {
                        sqlJoin += "," + table3 + "." + comboTable3Columns.Items[i] + " AS " + singularTable3 + comboTable3Columns.Items[i] + Environment.NewLine;
                    }

                    sqlJoin += " FROM " + table1 + Environment.NewLine
                    + " JOIN " + table2 + Environment.NewLine
                    + " ON " + table1 + "." + comboTable1Columns.Items[comboTable1Columns.SelectedIndex]
                    + "="
                    + table2 + "." + comboTable2Columns.Items[comboTable2Columns.SelectedIndex] + Environment.NewLine
                    + " JOIN " + table3 + Environment.NewLine
                    + " ON " + table2 + "." + comboTable2Columns.Items[comboTable2Columns.SelectedIndex]
                    + "="
                    + table3 + "." + comboTable3Columns.Items[comboTable3Columns.SelectedIndex];

                    textBoxJoinQuery.AppendText(sqlJoin);
                    break;
                case 4:
                    table3 = comboTable3.SelectedItem.ToString();
                    table4 = comboTable4.SelectedItem.ToString();
                    singularTable3 = makeSelectedTableSingular(table3);
                    singularTable4 = makeSelectedTableSingular(table4);

                    for (int i = 0; i < comboTable3Columns.Items.Count; i++)
                    {
                        sqlJoin += "," + table3 + "." + comboTable3Columns.Items[i] + " AS " + singularTable3 + comboTable3Columns.Items[i] + Environment.NewLine;
                    }
                    for (int i = 0; i < comboTable4Columns.Items.Count; i++)
                    {
                        sqlJoin += "," + table4 + "." + comboTable4Columns.Items[i] + " AS " + singularTable4 + comboTable4Columns.Items[i] + Environment.NewLine;
                    }

                    sqlJoin += " FROM " + table1 + Environment.NewLine
                    + " JOIN " + table2 + Environment.NewLine
                    + " ON " + table1 + "." + comboTable1Columns.Items[comboTable1Columns.SelectedIndex]
                    + "="
                    + table2 + "." + comboTable2Columns.Items[comboTable2Columns.SelectedIndex] + Environment.NewLine
                    + " JOIN " + table3 + Environment.NewLine
                    + " ON " + table2 + "." + comboTable2Columns.Items[comboTable2Columns.SelectedIndex]
                    + "="
                    + table3 + "." + comboTable3Columns.Items[comboTable3Columns.SelectedIndex] + Environment.NewLine
                    + " JOIN " + table4 + Environment.NewLine
                    + " ON " + table3 + "." + comboTable3Columns.Items[comboTable3Columns.SelectedIndex]
                    + "="
                    + table4 + "." + comboTable4Columns.Items[comboTable4Columns.SelectedIndex];

                    textBoxJoinQuery.AppendText(sqlJoin);
                    break;
                case 5:
                    table3 = comboTable3.SelectedItem.ToString();
                    table4 = comboTable4.SelectedItem.ToString();
                    table5 = comboTable5.SelectedItem.ToString();
                    singularTable3 = makeSelectedTableSingular(table3);
                    singularTable4 = makeSelectedTableSingular(table4);
                    singularTable5 = makeSelectedTableSingular(table5);

                    for (int i = 0; i < comboTable3Columns.Items.Count; i++)
                    {
                        sqlJoin += "," + table3 + "." + comboTable3Columns.Items[i] + " AS " + singularTable3 + comboTable3Columns.Items[i] + Environment.NewLine;
                    }
                    for (int i = 0; i < comboTable4Columns.Items.Count; i++)
                    {
                        sqlJoin += "," + table4 + "." + comboTable4Columns.Items[i] + " AS " + singularTable4 + comboTable4Columns.Items[i] + Environment.NewLine;
                    }
                    for (int i = 0; i < comboTable5Columns.Items.Count; i++)
                    {
                        sqlJoin += "," + table5 + "." + comboTable5Columns.Items[i] + " AS " + singularTable5 + comboTable5Columns.Items[i] + Environment.NewLine;
                    }

                    sqlJoin += " FROM " + table1 + Environment.NewLine
                    + " JOIN " + table2 + Environment.NewLine
                    + " ON " + table1 + "." + comboTable1Columns.Items[comboTable1Columns.SelectedIndex]
                    + "="
                    + table2 + "." + comboTable2Columns.Items[comboTable2Columns.SelectedIndex] + Environment.NewLine
                    + " JOIN " + table3 + Environment.NewLine
                    + " ON " + table2 + "." + comboTable2Columns.Items[comboTable2Columns.SelectedIndex]
                    + "="
                    + table3 + "." + comboTable3Columns.Items[comboTable3Columns.SelectedIndex] + Environment.NewLine
                    + " JOIN " + table4 + Environment.NewLine
                    + " ON " + table3 + "." + comboTable3Columns.Items[comboTable3Columns.SelectedIndex]
                    + "="
                    + table4 + "." + comboTable4Columns.Items[comboTable4Columns.SelectedIndex] + Environment.NewLine
                    + " JOIN " + table5 + Environment.NewLine
                    + " ON " + table4 + "." + comboTable4Columns.Items[comboTable4Columns.SelectedIndex]
                    + "="
                    + table5 + "." + comboTable5Columns.Items[comboTable5Columns.SelectedIndex];

                    textBoxJoinQuery.AppendText(sqlJoin);
                    break;
                default:
                    break;
            }
        }
        void createFolder(string folderName)
        {
            string path;

            path = "C:\\Users\\" + Environment.MachineName + "\\Desktop\\";
            var folder = Path.Combine(path, folderName);

            Directory.CreateDirectory(folder);
        }
        void writeTheFileJoin()
        {
            try
            {
                fileText = "";
                staticFilePath = "C:\\Users\\" + Environment.MachineName + "\\Desktop\\Joins";
                staticFilePath += "\\" + comboTable1.Text + "JOIN" + comboTable2.Text;
                string dynamicFilePath = staticFilePath;

                if (numericNumberofTable.Value == 3)
                {
                    dynamicFilePath = staticFilePath;
                    dynamicFilePath += "JOIN" + comboTable3.Text;
                }
                else if (numericNumberofTable.Value == 4)
                {
                    dynamicFilePath = staticFilePath;
                    dynamicFilePath += "JOIN" + comboTable3.Text + "JOIN" + comboTable4.Text;
                }
                else if (numericNumberofTable.Value == 5)
                {
                    dynamicFilePath = staticFilePath;
                    dynamicFilePath = "JOIN" + comboTable3.Text + "JOIN" + comboTable4.Text + "JOIN" + comboTable5.Text;
                }

                dynamicFilePath += ".sql";

                fileText += textBoxJoinQuery.Text;

                using (FileStream fs = File.Create(dynamicFilePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(fileText);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string makeSelectedTableSingular(string SelectedTable)
        {
            try
            {
                // Irregular plurals are dangerous ! ! !
                selectedTableSingular = SelectedTable;

                //TODO| First Turkish character control.
                if (selectedTableSingular.ToLower().EndsWith("ler") || selectedTableSingular.ToLower().EndsWith("lar"))
                {
                    selectedTableSingular = selectedTableSingular.Substring(0, selectedTableSingular.Length - 3);
                }

                //TODO| Check English spelling rules -ies  -y
                if (selectedTableSingular.ToLower().EndsWith("ies"))
                {
                    selectedTableSingular = selectedTableSingular.Substring(0, selectedTableSingular.Length - 3) + "y";
                }
                //TODO| Add es to words ending in -ch, -s, -sh, -x, -z:
                if ((selectedTableSingular.ToLower().EndsWith("es") && !(selectedTableSingular.ToLower().EndsWith("ies"))))
                {
                    if (selectedTableSingular.EndsWith("ches") || selectedTableSingular.EndsWith("ses") || selectedTableSingular.EndsWith("shes") || selectedTableSingular.EndsWith("xes") || selectedTableSingular.EndsWith("zes"))
                        selectedTableSingular = selectedTableSingular.Substring(0, selectedTableSingular.Length - 2);
                }
                //TODO| Check English spelling rules -ves  -fe   knives - knife
                if (selectedTableSingular.ToLower().EndsWith("ves"))
                {
                    selectedTableSingular = selectedTableSingular.Substring(0, selectedTableSingular.Length - 3) + "fe";
                }
                if (selectedTableSingular.ToLower().EndsWith("s"))
                {
                    selectedTableSingular = selectedTableSingular.Substring(0, selectedTableSingular.Length - 1);
                }
                return selectedTableSingular;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database tables deduplication error" + ex.Message);
            }
            return "empty";
        }
        void visibilityOpen(PictureBox pictureTable, Label lblKey, ComboBox comboTableColumns)
        {
            pictureTable.Visible = true;
            lblKey.Visible = true;
            comboTableColumns.Visible = true;
        }
        void visibilityClose(PictureBox pictureTable, Label lblKey, ComboBox comboTableColumns)
        {
            pictureTable.Visible = false;
            lblKey.Visible = false;
            comboTableColumns.Visible = false;
        }
        void visibilityCloseAllPictureTable()
        {
            pictureTable1.Visible = false;
            pictureTable2.Visible = false;
            pictureTable3.Visible = false;
            pictureTable4.Visible = false;
            pictureTable5.Visible = false;
        }
        void clearTextComboTable()
        {
            comboTable1.Text = "";
            comboTable2.Text = "";
            comboTable3.Text = "";
            comboTable4.Text = "";
            comboTable5.Text = "";
        }
        void clearTextComboTableColumns()
        {
            comboTable1Columns.Text = "";
            comboTable2Columns.Text = "";
            comboTable3Columns.Text = "";
            comboTable4Columns.Text = "";
            comboTable5Columns.Text = "";
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
            btnWriteonDesktop.Enabled = false;

            switch (numericNumberofTable.Value)
            {
                case 2:
                    visibilityClose(pictureTable3, lblKey3, comboTable3Columns);
                    label3.Visible = false;
                    comboTable3.Visible = false;
                    comboTable3.Text = "";
                    comboTable3Columns.SelectedIndex = -1;

                    visibilityClose(pictureTable4, lblKey4, comboTable4Columns);
                    label4.Visible = false;
                    comboTable4.Visible = false;
                    comboTable4.Text = "";
                    comboTable4Columns.SelectedIndex = -1;

                    visibilityClose(pictureTable5, lblKey5, comboTable5Columns);
                    label5.Visible = false;
                    comboTable5.Visible = false;
                    comboTable5.Text = "";
                    comboTable5Columns.SelectedIndex = -1;
                    break;
                case 3:
                    label3.Visible = true;
                    comboTable3.Visible = true;

                    visibilityClose(pictureTable4, lblKey4, comboTable4Columns);
                    label4.Visible = false;
                    comboTable4.Visible = false;
                    comboTable4.Text = "";
                    comboTable4Columns.SelectedIndex = -1;

                    visibilityClose(pictureTable5, lblKey5, comboTable5Columns);
                    label5.Visible = false;
                    comboTable5.Visible = false;
                    comboTable5.Text = "";
                    comboTable5Columns.SelectedIndex = -1;
                    break;
                case 4:
                    label3.Visible = true;
                    comboTable3.Visible = true;

                    label4.Visible = true;
                    comboTable4.Visible = true;

                    visibilityClose(pictureTable5, lblKey5, comboTable5Columns);
                    label5.Visible = false;
                    comboTable5.Visible = false;
                    comboTable5.Text = "";
                    comboTable5Columns.SelectedIndex = -1;
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
        }

        private void comboDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDb.SelectedItem != null)
            {
                SelectedDb = comboDb.SelectedItem.ToString();
                connectionStringforSelectedDB = "data source=localhost; initial catalog=" + SelectedDb + "; MultipleActiveResultSets=true; Trusted_Connection=true;";

                getTableCountforSelectedDb();
                getTablesforSelectedDb();
                addTableNametoComboboxforNewDatabaseSelection();

                pictureDb.Visible = true;
                visibilityCloseAllPictureTable();
                clearTextComboTable();
                clearTextComboTableColumns();
            }
            else
            {
                MessageBox.Show("Please select database.");
            }
        }

        private void comboTable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTable = comboTable1.SelectedItem.ToString();
            visibilityOpen(pictureTable1, lblKey1, comboTable1Columns);
            getColumnsforSelectedTable();
            addColumnNametoCombobox(comboTable1Columns);
        }

        private void comboTable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTable = comboTable2.SelectedItem.ToString();
            visibilityOpen(pictureTable2, lblKey2, comboTable2Columns);
            getColumnsforSelectedTable();
            addColumnNametoCombobox(comboTable2Columns);
        }

        private void comboTable3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTable = comboTable3.SelectedItem.ToString();
            visibilityOpen(pictureTable3, lblKey3, comboTable3Columns);
            getColumnsforSelectedTable();
            addColumnNametoCombobox(comboTable3Columns);
        }

        private void comboTable4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTable = comboTable4.SelectedItem.ToString();
            visibilityOpen(pictureTable4, lblKey4, comboTable4Columns);
            getColumnsforSelectedTable();
            addColumnNametoCombobox(comboTable4Columns);
        }

        private void comboTable5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTable = comboTable5.SelectedItem.ToString();
            visibilityOpen(pictureTable5, lblKey5, comboTable5Columns);
            getColumnsforSelectedTable();
            addColumnNametoCombobox(comboTable5Columns);
        }

        private void btnCreateJoin_Click(object sender, EventArgs e)
        {
            if (numericNumberofTable.Value == 2)
            {
                if (comboTable1.SelectedIndex != -1 && comboTable2.SelectedIndex != -1 && comboTable1Columns.SelectedIndex != -1
                    && comboTable2Columns.SelectedIndex != -1)
                {
                    WritetoTextBoxJoin();
                    btnWriteonDesktop.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please fill the empty fields");
                }
            }
            else if (numericNumberofTable.Value == 3)
            {
                if (comboTable1.SelectedIndex != -1 && comboTable2.SelectedIndex != -1 && comboTable3.SelectedIndex != -1
                    && comboTable1Columns.SelectedIndex != -1 && comboTable2Columns.SelectedIndex != -1
                    && comboTable3Columns.SelectedIndex != -1)
                {
                    WritetoTextBoxJoin();
                    btnWriteonDesktop.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please fill the empty fields");
                }
            }
            else if (numericNumberofTable.Value == 4)
            {
                if (comboTable1.SelectedIndex != -1 && comboTable2.SelectedIndex != -1 && comboTable3.SelectedIndex != -1
                    && comboTable4.SelectedIndex != -1 && comboTable1Columns.SelectedIndex != -1
                    && comboTable2Columns.SelectedIndex != -1 && comboTable3Columns.SelectedIndex != -1
                    && comboTable4Columns.SelectedIndex != -1)
                {
                    WritetoTextBoxJoin();
                    btnWriteonDesktop.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please fill the empty fields");
                }
            }
            else if (numericNumberofTable.Value == 5)
            {
                if (comboTable1.SelectedIndex != -1 && comboTable2.SelectedIndex != -1 && comboTable3.SelectedIndex != -1
                && comboTable4.SelectedIndex != -1 && comboTable5.SelectedIndex != -1 && comboTable1Columns.SelectedIndex != -1
                && comboTable2Columns.SelectedIndex != -1 && comboTable3Columns.SelectedIndex != -1
                && comboTable4Columns.SelectedIndex != -1 && comboTable5Columns.SelectedIndex != -1)
                {
                    WritetoTextBoxJoin();
                    btnWriteonDesktop.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please fill the empty fields");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxJoinQuery.Text != "")
                {
                    createFolder("Joins");
                    writeTheFileJoin();
                    MessageBox.Show("File saved to desktop");
                }
                else
                {
                    MessageBox.Show("Beklenmedik bir hata oluştu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboTable1Columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWriteonDesktop.Enabled = false;
        }

        private void comboTable2Columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWriteonDesktop.Enabled = false;
        }

        private void comboTable3Columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWriteonDesktop.Enabled = false;
        }

        private void comboTable4Columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWriteonDesktop.Enabled = false;
        }

        private void comboTable5Columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWriteonDesktop.Enabled = false;
        }
    }
}
