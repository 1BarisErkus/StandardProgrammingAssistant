using Dapper;
using SqlModelGenerator.Models;
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

namespace StandardProgrammingAssistant.ModelGenerator
{
    public partial class SqlServerModelGenerator : Form
    {
        string clientOS_Win_Version = "";
        string namespace_ = "";

        // connectionStringSqlAuth = dataSource + initialCatalog +     userId + userPass   + extra
        // connectionStringWinAuth = dataSource + initialCatalog +        WindowsAuth      + extra
        string connectionString = "";
        string dataSource = "data source=localhost";
        string initialCatalog = ";initial catalog = master";
        string userId = "";
        string userPass = "";
        string windowsAuth = ";MultipleActiveResultSets=true";
        string extra = ";Trusted_Connection= true;";

        string SelectedDb = "";
        string SelectedTable = "";
        string selectedTableSingular = "";
        string fileText = "";
        string filePath = "";
        string tableName = "";

        List<SqlServerUsers> sqlServerUsers = new List<SqlServerUsers>();
        List<string> listDatabases = new List<string>();
        List<string> listTables = new List<string>();
        List<string> listColumn = new List<string>();
        List<string> listDataType = new List<string>();
        List<string> ListStrings = new List<string>();

        int totalDbCount = 0;
        int totalTableCount = 0;
        int totalColumnCount = 0;

        bool authType = false;
        bool showPass = false;


        // Functions
        void createFolder(string folderName)
        {
            string newPath = "";
            string path;

            if (clientOS_Win_Version.Contains("11."))
            {
                path = "C:\\Users\\" + Environment.MachineName + "\\OneDrive\\Desktop\\";
            }
            else
            {
                path = "C:\\Users\\" + Environment.MachineName + "\\Desktop\\";
            }
            var folder = Path.Combine(path, folderName);

            Directory.CreateDirectory(folder);
        }
        void checkSqlAuth()
        {
            try
            {
                determineConnectionString();

                using (var connection = new SqlConnection(connectionString))
                {
                    string sqlC = "SELECT COUNT(*) FROM sys.databases";
                    int tempCount = 0;

                    tempCount = connection.QuerySingle<int>(sqlC);
                    if (tempCount > 0)
                    {
                        textBoxPassword.ForeColor = Color.Green;
                        comboLogin.ForeColor = Color.Green;
                        comboDb.Enabled = true;
                        comboTable.Enabled = true;
                        getAllDbsName();
                        addDbNametoCombobox();
                    }
                }
                lblConnect.Visible = true;
                pictureConnect.Visible = true;
                btnForSelectedTable.Enabled = true;
                btnForSelectedDatabase.Enabled = true;
                comboFilePrefences.Enabled = true;
            }
            catch (Exception)
            {
                textBoxPassword.ForeColor = Color.Red;
                comboLogin.ForeColor = Color.Red;
                comboDb.Enabled = false;
                comboTable.Enabled = false;
            }
        }
        void clearConnectionString()
        {
            connectionString = "";
            dataSource = "";
            initialCatalog = "";
            userId = "";
            userPass = "";
        }
        void clearItems()
        {
            comboDb.Text = "";
            comboTable.Text = "";
            SelectedDb = "";
            SelectedTable = "";
        }
        void determineConnectionString()
        {
            try
            {
                if (authType)
                {
                    connectionString = dataSource + initialCatalog + userId + userPass + extra;
                }
                else
                {
                    connectionString = dataSource + initialCatalog + windowsAuth + extra;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void getSystemDbsCount()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
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
                MessageBox.Show(ex.Message + "We think your windows authentication login is disabled for sql server.");
            }
        }
        void getAllDbsName()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT name FROM sys.databases
                                WHERE name NOT LIKE 'master' 
                                AND name NOT LIKE 'tempdb'
                                AND name NOT LIKE 'model'
                                AND name NOT LIKE 'msdb'";

                    listDatabases = connection.Query<string>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "We think your windows authentication login is disabled for sql server.");
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
        void fillSqlServerAuthUsers()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT sp.name as Login,
                            	CASE WHEN sp.is_disabled = 1 THEN 'Disabled'
                            	ELSE 'Enabled' END AS Status
                            FROM sys.server_principals sp WHERE
                            sp.type_desc = 'SQL_LOGIN' AND sp.name NOT LIKE '%##'";

                    sqlServerUsers = connection.Query<SqlServerUsers>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void addSqlServerUserstoCombobox()
        {
            try
            {
                for (int i = 0; i < sqlServerUsers.Count; i++)
                {
                    comboLogin.Items.Add(sqlServerUsers[i].Login);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void getTableCountforSelectedDb()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT COUNT(*) FROM sys.tables
                                WHERE name NOT LIKE 'sysdiagrams'";

                    totalTableCount = connection.QuerySingle<int>(sql);
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
                using (var connection = new SqlConnection(connectionString))
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
            comboTable.Items.Clear();
            try
            {
                for (int i = 0; i < totalTableCount; i++)
                {
                    comboTable.Items.Add(listTables[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetColumnsCountSelectedTable()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT COUNT(*)
                                    FROM sys.tables AS tab
                                        LEFT JOIN sys.columns AS col
                                            ON tab.object_id = col.object_id
                                    WHERE tab.name = @TABLE_NAME";

                    var prms = new
                    {
                        TABLE_NAME = SelectedTable
                    };
                    totalColumnCount = connection.QuerySingle<int>(sql, prms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetColumnsforSelectedTable()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT col.name AS KolonAdi,
                                            t.name AS VeriTipi
                                    FROM sys.tables AS tab
                                        INNER JOIN sys.columns AS col
                                            ON tab.object_id = col.object_id
                                        LEFT JOIN sys.types AS t
                                            ON col.user_type_id = t.user_type_id
                                            WHERE tab.name = @TABLE_NAME";
                    var prms = new
                    {
                        TABLE_NAME = SelectedTable
                    };
                    listColumn = connection.Query<string>(sql, prms).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetDataTypesforSelectedTable()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT t.name AS VeriTipi
                                    FROM sys.tables AS tab
                                        INNER JOIN sys.columns AS col
                                            ON tab.object_id = col.object_id
                                        LEFT JOIN sys.types AS t
                                            ON col.user_type_id = t.user_type_id
                                            WHERE tab.name = @TABLE_NAME";
                    var prms = new
                    {
                        TABLE_NAME = SelectedTable
                    };
                    listDataType = connection.Query<string>(sql, prms).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EditAndWritetoCSharpTextBox()
        {
            try
            {
                for (int i = 0; i < totalColumnCount; i++)
                {
                    textBoxCsharp.AppendText("\t\tprivate ");

                    if (listDataType[i].Contains("char"))
                    {
                        textBoxCsharp.AppendText("string ");
                        textBoxCsharp.AppendText(listColumn[i]);
                        textBoxCsharp.AppendText(" { get; set; }");
                        textBoxCsharp.AppendText(" = \"\";");

                    }
                    else if (listDataType[i].Contains("int"))
                    {
                        textBoxCsharp.AppendText("int ");
                        textBoxCsharp.AppendText(listColumn[i]);
                        textBoxCsharp.AppendText(" { get; set; }");
                        textBoxCsharp.AppendText(" = -2;");
                    }
                    else if (listDataType[i].Contains("datetime"))
                    {
                        textBoxCsharp.AppendText("DateTime ");
                        textBoxCsharp.AppendText(listColumn[i]);
                        textBoxCsharp.AppendText(" { get; set; }");
                        textBoxCsharp.AppendText(" = new DateTime(2002, 02, 02);");
                    }
                    else if (listDataType[i].Contains("varbinary"))
                    {
                        textBoxCsharp.AppendText("byte[] ");
                        textBoxCsharp.AppendText(listColumn[i]);
                        textBoxCsharp.AppendText(" { get; set; }");
                        textBoxCsharp.AppendText(" = new byte[0];");
                    }
                    else
                    {

                    }
                    textBoxCsharp.AppendText(Environment.NewLine);
                }
                EncapsulationCSharp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EditAndWritetoFlutterTextBox()
        {
            try
            {
                for (int k = 0; k < totalColumnCount; k++)
                {
                    textBoxFlutter.AppendText("\t@JsonKey(name: \"");
                    textBoxFlutter.AppendText(listColumn[k]);
                    textBoxFlutter.AppendText("\"");
                    textBoxFlutter.AppendText(")" + Environment.NewLine);

                    if (listDataType[k].Contains("char"))
                    {
                        textBoxFlutter.AppendText("\tString ");
                        textBoxFlutter.AppendText(listColumn[k]);
                        textBoxFlutter.AppendText(" = \"\";");

                    }
                    else if (listDataType[k].Contains("int"))
                    {
                        textBoxFlutter.AppendText("\tint ");
                        textBoxFlutter.AppendText(listColumn[k]);
                        textBoxFlutter.AppendText(" = -1;");

                    }
                    else if (listDataType[k].Contains("datetime"))
                    {
                        textBoxFlutter.AppendText("\tDateTime ");
                        textBoxFlutter.AppendText(listColumn[k]);
                        textBoxFlutter.AppendText(" = DateTime.utc(2111,01,01);");
                    }
                    else if (listDataType[k].Contains("varbinary"))
                    {
                        textBoxFlutter.AppendText("\tList<int> ");
                        textBoxFlutter.AppendText(listColumn[k]);
                        textBoxFlutter.AppendText(" = [];");
                    }
                    else
                    {

                    }
                    textBoxFlutter.AppendText(Environment.NewLine + Environment.NewLine);
                }
                EncapsulationFlutter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EncapsulationCSharp()
        {
            try
            {
                for (int i = 0; i < totalColumnCount; i++)
                {
                    if (listDataType[i].Contains("char"))
                    {
                        textBoxCsharp.AppendText(Environment.NewLine + "\t\tpublic string get" + listColumn[i] + "()" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t{" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t\t");
                        textBoxCsharp.AppendText("return this." + listColumn[i] + ";");
                        textBoxCsharp.AppendText(Environment.NewLine + "\t\t}");

                        textBoxCsharp.AppendText(Environment.NewLine + "\t\tpublic void set" + listColumn[i] + "(string " + listColumn[i] + ")" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t{" + Environment.NewLine + "\t\t\t");
                        textBoxCsharp.AppendText("this." + listColumn[i] + " = " + listColumn[i] + ";" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t}");
                    }
                    else if (listDataType[i].Contains("int"))
                    {
                        textBoxCsharp.AppendText(Environment.NewLine + "\t\tpublic int get" + listColumn[i] + "()" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t{" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t\t");
                        textBoxCsharp.AppendText("return this." + listColumn[i] + ";");
                        textBoxCsharp.AppendText(Environment.NewLine + "\t\t}");

                        textBoxCsharp.AppendText(Environment.NewLine + "\t\tpublic void set" + listColumn[i] + "(int " + listColumn[i] + ")" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t{" + Environment.NewLine + "\t\t\t");
                        textBoxCsharp.AppendText("this." + listColumn[i] + " = " + listColumn[i] + ";" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t}");
                    }
                    else if (listDataType[i].Contains("datetime"))
                    {
                        textBoxCsharp.AppendText(Environment.NewLine + "\t\tpublic DateTime get" + listColumn[i] + "()" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t{" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t\t");
                        textBoxCsharp.AppendText("return this." + listColumn[i] + ";");
                        textBoxCsharp.AppendText(Environment.NewLine + "\t\t}");

                        textBoxCsharp.AppendText(Environment.NewLine + "\t\tpublic void set" + listColumn[i] + "(DateTime " + listColumn[i] + ")" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t{" + Environment.NewLine + "\t\t\t");
                        textBoxCsharp.AppendText("this." + listColumn[i] + " = " + listColumn[i] + ";" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t}");
                    }
                    else if (listDataType[i].Contains("varbinary"))
                    {
                        textBoxCsharp.AppendText(Environment.NewLine + "\t\tpublic byte[] get" + listColumn[i] + "()" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t{" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t\t");
                        textBoxCsharp.AppendText("return this." + listColumn[i] + ";");
                        textBoxCsharp.AppendText(Environment.NewLine + "\t\t}");

                        textBoxCsharp.AppendText(Environment.NewLine + "\t\tpublic void set" + listColumn[i] + "(byte[] " + listColumn[i] + ")" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t{" + Environment.NewLine + "\t\t\t");
                        textBoxCsharp.AppendText("this." + listColumn[i] + " = " + listColumn[i] + ";" + Environment.NewLine);
                        textBoxCsharp.AppendText("\t\t}");
                    }
                    else
                    {
                    }
                    textBoxCsharp.AppendText(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EncapsulationFlutter()
        {
            try
            {
                for (int i = 0; i < totalColumnCount; i++)
                {
                    if (listDataType[i].Contains("char"))
                    {
                        textBoxFlutter.AppendText("\tString get" + listColumn[i] + "()" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t{" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t\treturn " + listColumn[i] + ";" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t}" + Environment.NewLine);

                        textBoxFlutter.AppendText("\tvoid set" + listColumn[i] + "(String " + listColumn[i].ToLower().Replace("ý", "i") + ")" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t{" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t\t" + listColumn[i] + " = " + listColumn[i].ToLower().Replace("ý", "i") + ";" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t}" + Environment.NewLine);
                    }
                    else if (listDataType[i].Contains("int"))
                    {
                        textBoxFlutter.AppendText("\tint get" + listColumn[i] + "()" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t{" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t\treturn " + listColumn[i] + ";" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t}" + Environment.NewLine);

                        textBoxFlutter.AppendText("\tvoid set" + listColumn[i] + "(int " + listColumn[i].ToLower().Replace("ý", "i") + ")" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t{" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t\t" + listColumn[i] + " = " + listColumn[i].ToLower().Replace("ý", "i") + ";" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t}" + Environment.NewLine);

                    }
                    else if (listDataType[i].Contains("datetime"))
                    {
                        textBoxFlutter.AppendText("\tDateTime get" + listColumn[i] + "()" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t{" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t\treturn " + listColumn[i] + ";" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t}" + Environment.NewLine);

                        textBoxFlutter.AppendText("\tvoid set" + listColumn[i] + "(DateTime " + listColumn[i].ToLower().Replace("ý", "i") + ")" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t{" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t\t" + listColumn[i] + " = " + listColumn[i].ToLower().Replace("ý", "i") + ";" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t}" + Environment.NewLine);
                    }
                    else if (listDataType[i].Contains("varbinary"))
                    {
                        textBoxFlutter.AppendText("\tString get" + listColumn[i] + "()" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t{" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t\treturn " + listColumn[i] + ";" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t}" + Environment.NewLine);

                        textBoxFlutter.AppendText("\tvoid set" + listColumn[i] + "(String " + listColumn[i].ToLower().Replace("ý", "i") + ")" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t{" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t\t" + listColumn[i] + " = " + listColumn[i].ToLower().Replace("ý", "i") + ";" + Environment.NewLine);
                        textBoxFlutter.AppendText("\t}" + Environment.NewLine);
                    }
                    else
                    {

                    }
                    textBoxFlutter.AppendText(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void WritetoFileforCsharp()
        {
            makeSelectedTableSingular(SelectedTable);
            try
            {
                fileText = "";
                filePath = "C:\\Users\\";

                if (clientOS_Win_Version.Contains("11."))
                {
                    filePath += Environment.MachineName + "\\OneDrive\\Desktop";
                }
                else
                {
                    filePath += Environment.MachineName + "\\Desktop\\Csharp";
                }

                filePath += "\\" + selectedTableSingular + ".cs";

                fileText += "using System;" + Environment.NewLine;
                fileText += "using System.Collections.Generic;" + Environment.NewLine;
                fileText += "using System.Linq;" + Environment.NewLine;
                fileText += "using System.Text;" + Environment.NewLine;
                fileText += "using System;" + Environment.NewLine;
                fileText += "using System.Threading.Tasks;" + Environment.NewLine;
                fileText += Environment.NewLine;

                if (namespace_.Length > 1)
                    fileText += "namespace " + namespace_ + Environment.NewLine;
                else
                    fileText += "namespace xxprojectname.xxfoldername" + Environment.NewLine;

                fileText += "{" + Environment.NewLine;

                fileText += "\tpublic class " + selectedTableSingular + Environment.NewLine;
                fileText += "\t{" + Environment.NewLine;
                fileText += textBoxCsharp.Text;
                fileText += "\t}" + Environment.NewLine;
                fileText += "}";

                using (FileStream fs = File.Create(filePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(fileText);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void WritetoFileforFlutter()
        {
            makeSelectedTableSingular(SelectedTable);
            try
            {
                fileText = "";
                filePath = "C:\\Users\\";

                if (clientOS_Win_Version.Contains("11."))
                {
                    filePath += Environment.MachineName + "\\OneDrive\\Desktop";
                }
                else
                {
                    filePath += Environment.MachineName + "\\Desktop\\Flutter";
                }

                filePath += "\\" + selectedTableSingular.ToLower().Replace("ý", "i") + ".dart";

                fileText += "// ignore_for_file: non_constant_identifier_names, depend_on_referenced_packages" + Environment.NewLine + Environment.NewLine;

                fileText += "import 'package:json_annotation/json_annotation.dart';" + Environment.NewLine + Environment.NewLine;
                fileText += "part '" + selectedTableSingular.ToLower().Replace("ý", "i") + ".g.dart';" + Environment.NewLine + Environment.NewLine;
                fileText += "@JsonSerializable()" + Environment.NewLine;
                fileText += "class " + selectedTableSingular + " {" + Environment.NewLine + Environment.NewLine;

                fileText += textBoxFlutter.Text;

                fileText += "\t" + selectedTableSingular + "();" + Environment.NewLine;

                fileText += "\tfactory " + selectedTableSingular + ".fromJson (Map<String, dynamic> json) => _$" + selectedTableSingular + "FromJson(json);" + Environment.NewLine;
                fileText += "\tMap<String, dynamic> toJson() => _$" + selectedTableSingular + "ToJson(this);" + Environment.NewLine;

                fileText += "}";

                using (FileStream fs = File.Create(filePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(fileText);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ShowPassword()
        {
            try
            {
                if (showPass)
                {
                    showPass = false;
                    textBoxPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    showPass = true;
                    textBoxPassword.UseSystemPasswordChar = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ShowSqlServerLoginInterface(bool isActive)
        {
            try
            {
                if (isActive)
                {
                    authType = true;
                    textBoxPassword.Enabled = true;
                    comboLogin.Enabled = true;
                }
                else
                {
                    authType = false;
                    comboLogin.Text = "";
                    textBoxPassword.Text = "";
                    textBoxPassword.Enabled = false;
                    comboLogin.Enabled = false;
                    textBoxPassword.UseSystemPasswordChar = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void makeSelectedTableSingular(string SelectedTable)
        {
            try
            {
                //TODO önce ies bak sonra s bak
                selectedTableSingular = SelectedTable;

                //TODO| First Turkish character control.
                if (selectedTableSingular.EndsWith("ler") || selectedTableSingular.EndsWith("lar") || selectedTableSingular.EndsWith("LER") || selectedTableSingular.EndsWith("LAR"))
                {
                    selectedTableSingular = selectedTableSingular.Substring(0, selectedTableSingular.Length - 3);
                }

                //TODO| Check English spelling rules -ies  -y
                else if (selectedTableSingular.EndsWith("ies") || selectedTableSingular.EndsWith("IES"))
                {
                    selectedTableSingular = selectedTableSingular.Substring(0, selectedTableSingular.Length - 3) + "y";
                }

                //TODO| Check English spelling rules   
                //else if ()
                //{
                //}
                else if (selectedTableSingular.EndsWith("s") || selectedTableSingular.EndsWith("S"))
                {
                    selectedTableSingular = selectedTableSingular.Substring(0, selectedTableSingular.Length - 1);

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database tables deduplication error" + ex.Message);
            }
        }

        public SqlServerModelGenerator()
        {
            InitializeComponent();
        }

        private void checkBoxConnectAnotherServer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxServerIP.Enabled == true)
                {
                    textBoxServerIP.Text = "";
                    textBoxServerIP.Enabled = false;
                    radioButtonWindowsAuth.Enabled = true;
                }
                else
                {
                    //dataSource = "data source=" + Environment.MachineName;    deð
                    textBoxServerIP.Text = "";
                    textBoxServerIP.Enabled = true;
                    radioButtonWindowsAuth.Enabled = false;
                    radioButtonSqlServerAuth.Checked = true;
                    radioButtonSqlServerAuth_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxServerIP_TextChanged(object sender, EventArgs e)
        {
            dataSource = "data source = " + textBoxServerIP.Text;
        }

        private void comboDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBoxNamespace.Text == "Don't_forget_to_fill_me_in_please.")
            {
                textBoxNamespace.ForeColor = Color.Red;
            }
            try
            {
                comboTable.Text = "";
                comboTable.Items.Clear();
                textBoxCsharp.Clear();
                textBoxFlutter.Clear();
                pictureTable.Visible = false;
                if (!(textBoxServerIP.TextLength > 0))
                    extra = ";Trusted_Connection= true;";

                if (comboDb.SelectedItem != null)
                {
                    SelectedDb = comboDb.SelectedItem.ToString();

                    initialCatalog = ";initial catalog=" + SelectedDb.ToString();

                    determineConnectionString();
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
            catch (Exception ex)
            {
                MessageBox.Show("Please select another database. " + ex.Message);
            }
        }

        private void comboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureTable.Visible = false;
                textBoxCsharp.Clear();
                textBoxFlutter.Clear();

                if (comboTable.SelectedItem != null && comboTable.SelectedItem != "")
                {
                    SelectedTable = comboTable.SelectedItem.ToString();
                    determineConnectionString();
                    GetColumnsCountSelectedTable();
                    GetColumnsforSelectedTable();
                    GetDataTypesforSelectedTable();
                    EditAndWritetoCSharpTextBox();
                    EditAndWritetoFlutterTextBox();

                    pictureTable.Visible = true;
                }
                else
                {
                    MessageBox.Show("Please select table.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please select another database.");
            }
        }

        private void btnForSelectedTable_Click(object sender, EventArgs e)
        {
            try
            {
                // 0:both 1:flutter 2:csharp
                if (comboTable.Text != null && comboTable.Text != "")
                {
                    if (comboFilePrefences.SelectedIndex == 0)
                    {
                        createFolder("Csharp");
                        createFolder("Flutter");

                        WritetoFileforCsharp();
                        WritetoFileforFlutter();

                        textBoxFlutter.Clear();
                        textBoxFlutter.AppendText("The Flutter file was created on the desktop : .dart");

                        textBoxCsharp.Clear();
                        textBoxCsharp.AppendText("The C# file was created on the desktop : .cs");

                        MessageBox.Show("Files saved to desktop");
                    }
                    else if (comboFilePrefences.SelectedIndex == 1)
                    {
                        createFolder("Flutter");

                        tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];

                        WritetoFileforFlutter();

                        textBoxFlutter.Clear();
                        textBoxFlutter.AppendText("The Flutter file was created on the desktop : .dart");

                        MessageBox.Show("File saved to desktop");
                    }
                    else if (comboFilePrefences.SelectedIndex == 2)
                    {
                        createFolder("Csharp");
                            tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];

                            WritetoFileforCsharp();

                            textBoxCsharp.Clear();
                            textBoxCsharp.AppendText("The C# file was created on the desktop : .cs");

                        MessageBox.Show("File saved to desktop");
                    }
                    else
                    {
                        MessageBox.Show("Please select Flutter , C# or Both");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a table.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnForSelectedDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                string filePathforUser = "";

                if (SelectedDb.Length > 1)
                {
                    for (int i = 0; i < totalTableCount; i++)
                    {
                        textBoxCsharp.Clear();
                        textBoxFlutter.Clear();
                        initialCatalog = ";initial catalog=" + SelectedDb;

                        //  getTotalColumnCount
                        using (var connection = new SqlConnection(connectionString))
                        {
                            var sql = @"SELECT COUNT(*)
                                    FROM sys.tables AS tab
                                        LEFT JOIN sys.columns AS col
                                            ON tab.object_id = col.object_id
                                    WHERE tab.name = @TABLE_NAME";

                            var prms = new
                            {
                                TABLE_NAME = listTables[i]
                            };

                            totalColumnCount = connection.QuerySingle<int>(sql, prms);
                        }

                        //  getColumnList
                        using (var connection = new SqlConnection(connectionString))
                        {
                            var sql = @"SELECT col.name AS KolonAdi,
                                            t.name AS VeriTipi
                                    FROM sys.tables AS tab
                                        INNER JOIN sys.columns AS col
                                            ON tab.object_id = col.object_id
                                        LEFT JOIN sys.types AS t
                                            ON col.user_type_id = t.user_type_id
                                            WHERE tab.name = @TABLE_NAME";
                            var prms = new
                            {
                                TABLE_NAME = listTables[i]
                            };
                            listColumn = connection.Query<string>(sql, prms).ToList();
                        }

                        //  getColumnDataType
                        using (var connection = new SqlConnection(connectionString))
                        {
                            var sql = @"SELECT t.name AS VeriTipi
                                    FROM sys.tables AS tab
                                        INNER JOIN sys.columns AS col
                                            ON tab.object_id = col.object_id
                                        LEFT JOIN sys.types AS t
                                            ON col.user_type_id = t.user_type_id
                                            WHERE tab.name = @TABLE_NAME";
                            var prms = new
                            {
                                TABLE_NAME = listTables[i]
                            };

                            listDataType = connection.Query<string>(sql, prms).ToList();
                        }

                        void EditAndWritetoCSharpTextBox()
                        {
                            try
                            {
                                for (int m = 0; m < totalColumnCount; m++)
                                {
                                    textBoxCsharp.AppendText("\t\tpublic ");

                                    if (listDataType[m].Contains("char"))
                                    {
                                        textBoxCsharp.AppendText("string ");
                                        textBoxCsharp.AppendText(listColumn[m]);
                                        textBoxCsharp.AppendText(" { get; set; }");
                                        textBoxCsharp.AppendText(" = \"\";");

                                    }
                                    else if (listDataType[m].Contains("int"))
                                    {
                                        textBoxCsharp.AppendText("int ");
                                        textBoxCsharp.AppendText(listColumn[m]);
                                        textBoxCsharp.AppendText(" { get; set; }");
                                        textBoxCsharp.AppendText(" = -2;");
                                    }
                                    else if (listDataType[m].Contains("datetime"))
                                    {
                                        textBoxCsharp.AppendText("DateTime ");
                                        textBoxCsharp.AppendText(listColumn[m]);
                                        textBoxCsharp.AppendText(" { get; set; }");
                                        textBoxCsharp.AppendText(" = new DateTime(2002, 02, 02);");
                                    }
                                    else if (listDataType[m].Contains("varbinary"))
                                    {
                                        textBoxCsharp.AppendText("byte[] ");
                                        textBoxCsharp.AppendText(listColumn[m]);
                                        textBoxCsharp.AppendText(" { get; set; }");
                                        textBoxCsharp.AppendText(" = new byte[0];");
                                    }
                                    else
                                    {

                                    }
                                    textBoxCsharp.AppendText(Environment.NewLine);
                                }
                                EncapsulationCSharp();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }

                        void EditAndWritetoFlutterTextBox()
                        {
                            try
                            {
                                for (int k = 0; k < totalColumnCount; k++)
                                {
                                    textBoxFlutter.AppendText("\t@JsonKey(name: \"");
                                    textBoxFlutter.AppendText(listColumn[k]);
                                    textBoxFlutter.AppendText("\"");
                                    textBoxFlutter.AppendText(")" + Environment.NewLine);


                                    if (listDataType[k].Contains("char"))
                                    {
                                        textBoxFlutter.AppendText("\tString ");
                                        textBoxFlutter.AppendText(listColumn[k]);
                                        textBoxFlutter.AppendText(" = \"\";");

                                    }
                                    else if (listDataType[k].Contains("int"))
                                    {
                                        textBoxFlutter.AppendText("\tint ");
                                        textBoxFlutter.AppendText(listColumn[k]);
                                        textBoxFlutter.AppendText(" = -1;");

                                    }
                                    else if (listDataType[k].Contains("datetime"))
                                    {
                                        textBoxFlutter.AppendText("\tDateTime ");
                                        textBoxFlutter.AppendText(listColumn[k]);
                                        textBoxFlutter.AppendText(" = DateTime.utc(2111,01,01);");
                                    }
                                    else if (listDataType[k].Contains("varbinary"))
                                    {
                                        textBoxFlutter.AppendText("\tList<int> ");
                                        textBoxFlutter.AppendText(listColumn[k]);
                                        textBoxFlutter.AppendText(" = [];");
                                    }
                                    else
                                    {

                                    }
                                    textBoxFlutter.AppendText(Environment.NewLine + Environment.NewLine);
                                }
                                EncapsulationFlutter();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }

                        void WritetoFileCsharpforSelectedDb()
                        {
                            try
                            {
                                makeSelectedTableSingular(listTables[i]);

                                fileText = "";
                                filePath = "C:\\Users\\";
                                filePath += Environment.MachineName + "\\Desktop\\CSharp";
                                filePathforUser = filePath;
                                filePath += "\\" + selectedTableSingular + ".cs";

                                fileText += "using System;" + Environment.NewLine;
                                fileText += "using System.Collections.Generic;" + Environment.NewLine;
                                fileText += "using System.Linq;" + Environment.NewLine;
                                fileText += "using System.Text;" + Environment.NewLine;
                                fileText += "using System;" + Environment.NewLine;
                                fileText += "using System.Threading.Tasks;" + Environment.NewLine;
                                fileText += Environment.NewLine;

                                if (namespace_.Length > 1)
                                    fileText += "namespace " + namespace_ + Environment.NewLine;
                                else
                                    fileText += "namespace xxprojectname.xxfoldername" + Environment.NewLine;

                                fileText += "{" + Environment.NewLine;
                                fileText += "\tpublic class " + selectedTableSingular + Environment.NewLine;
                                fileText += "\t{" + Environment.NewLine;
                                fileText += textBoxCsharp.Text + Environment.NewLine + Environment.NewLine;

                                fileText += "\t}" + Environment.NewLine;
                                fileText += "}";

                                using (FileStream fs = File.Create(filePath))
                                {
                                    byte[] info = new UTF8Encoding(true).GetBytes(fileText);
                                    // Add some information to the file.
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                        void WritetoFileFlutterforSelectedDb()
                        {
                            try
                            {
                                makeSelectedTableSingular(listTables[i]);

                                fileText = "";
                                filePath = "C:\\Users\\";
                                filePath += Environment.MachineName + "\\Desktop\\Flutter";
                                filePath += "\\" + selectedTableSingular.ToLower().Replace("ý", "i") + ".dart";

                                fileText += "// ignore_for_file: non_constant_identifier_names, depend_on_referenced_packages" + Environment.NewLine + Environment.NewLine;

                                fileText += "import 'package:json_annotation/json_annotation.dart';" + Environment.NewLine + Environment.NewLine;
                                fileText += "part '" + selectedTableSingular.ToLower().Replace("ý", "i") + ".g.dart';" + Environment.NewLine + Environment.NewLine;
                                fileText += "@JsonSerializable()" + Environment.NewLine;
                                fileText += "class " + selectedTableSingular + " {" + Environment.NewLine + Environment.NewLine;

                                fileText += textBoxFlutter.Text;

                                fileText += "\t" + selectedTableSingular + "();" + Environment.NewLine;

                                fileText += "\tfactory " + selectedTableSingular + ".fromJson (Map<String, dynamic> json) => _$" + selectedTableSingular + "FromJson(json);" + Environment.NewLine;
                                fileText += "\tMap<String, dynamic> toJson() => _$" + selectedTableSingular + "ToJson(this);" + Environment.NewLine;

                                fileText += "}";

                                using (FileStream fs = File.Create(filePath))
                                {
                                    byte[] info = new UTF8Encoding(true).GetBytes(fileText);
                                    // Add some information to the file.
                                    fs.Write(info, 0, info.Length);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                        void WritetoTextBoxCsharpInfo()
                        {
                            textBoxCsharp.Clear();
                            textBoxCsharp.AppendText("The C# files were created on the desktop : " + filePathforUser + ".cs");
                        }

                        void WritetoTextBoxFlutterInfo()
                        {
                            textBoxFlutter.Clear();
                            textBoxFlutter.AppendText("The Flutter files were created on the desktop : " + filePathforUser + ".dart");
                        }

                        // 0:both 1:flutter 2:csharp
                        if (comboFilePrefences.SelectedIndex == 0)
                        {
                            createFolder("Csharp");
                            createFolder("Flutter");

                            EditAndWritetoCSharpTextBox();
                            EditAndWritetoFlutterTextBox();

                            WritetoFileCsharpforSelectedDb();
                            WritetoFileFlutterforSelectedDb();

                            WritetoTextBoxFlutterInfo();
                            WritetoTextBoxCsharpInfo();
                        }
                        else if (comboFilePrefences.SelectedIndex == 1)
                        {
                            createFolder("Flutter");

                            tabControl1.SelectedTab = tabControl1.TabPages["tabPageFlutter"];

                            EditAndWritetoFlutterTextBox();
                            WritetoFileFlutterforSelectedDb();

                            WritetoTextBoxFlutterInfo();
                        }
                        else if (comboFilePrefences.SelectedIndex == 2)
                        {
                            createFolder("Csharp");

                            tabControl1.SelectedTab = tabControl1.TabPages["tabPageCsharp"];

                            EditAndWritetoCSharpTextBox();
                            WritetoFileCsharpforSelectedDb();

                            WritetoTextBoxCsharpInfo();
                        }
                        else
                        {
                            MessageBox.Show("Please select Flutter , C# or Both");
                        }
                    }
                    MessageBox.Show("Files saved to desktop");
                }
                else
                {
                    MessageBox.Show("Please select a table.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik hata: " + ex.Message);
            }
        }

        private void textBoxNamespace_TextChanged(object sender, EventArgs e)
        {
            namespace_ = textBoxNamespace.Text;
            if (textBoxNamespace.Text == "Don't_forget_to_fill_me_in_please.")
            {
                textBoxNamespace.ForeColor = Color.Red;
            }
            else
            {
                textBoxNamespace.ForeColor = Color.Black;

            }
        }

        private void pictureBoxRelease_Click(object sender, EventArgs e)
        {
            Versions versions = new Versions();
            versions.Show();
            pictureBoxRelease.Enabled = false;
        }

        private void pictureBoxUserGuide_Click(object sender, EventArgs e)
        {
            try
            {
                UserGuide userGuide = new UserGuide();
                userGuide.Show();
                pictureBoxUserGuide.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picturePassword_MouseHover(object sender, EventArgs e)
        {
            ShowPassword();
        }

        private void picturePassword_MouseLeave(object sender, EventArgs e)
        {
            ShowPassword();
        }

        private void SqlServerModelGenerator_Load(object sender, EventArgs e)
        {
            extra = ";Trusted_Connection= true;";
            comboDb.Enabled = true;
            comboTable.Enabled = true;
            ShowSqlServerLoginInterface(false);
            textBoxNamespace.Text = "Don't_forget_to_fill_me_in_please.";
            textBoxNamespace.ForeColor = Color.Red;
            try
            {
                clientOS_Win_Version = Environment.OSVersion.ToString();

                authType = false;
                comboFilePrefences.SelectedIndex = 0;
                textBoxPassword.UseSystemPasswordChar = true;

                determineConnectionString();
                getSystemDbsCount();
                getAllDbsName();
                addDbNametoCombobox();
                fillSqlServerAuthUsers();
                addSqlServerUserstoCombobox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonSqlServerAuth_Click(object sender, EventArgs e)
        {
            comboDb.Enabled = false;
            comboTable.Enabled = false;
            btnConnect.Enabled = true;
            pictureDb.Visible = false;
            pictureTable.Visible = false;
            authType = true;
            btnForSelectedTable.Enabled = false;
            btnForSelectedDatabase.Enabled = false;
            comboFilePrefences.Enabled = false;
            extra = "";
            ShowSqlServerLoginInterface(true);
            clearItems();
        }

        private void radioButtonWindowsAuth_Click(object sender, EventArgs e)
        {
            lblConnect.Visible = false;
            pictureConnect.Visible = false;
            extra = ";Trusted_Connection= true;";
            comboDb.Enabled = true;
            comboTable.Enabled = true;
            btnConnect.Enabled = false;
            btnForSelectedTable.Enabled = true;
            btnForSelectedDatabase.Enabled = true;
            comboFilePrefences.Enabled = true;
            ShowSqlServerLoginInterface(false);
            clearItems();
        }

        private void btnConnect_MouseHover(object sender, EventArgs e)
        {
            btnConnect.BackColor = Color.DarkGreen;
        }

        private void btnConnect_MouseLeave(object sender, EventArgs e)
        {
            btnConnect.BackColor = Color.MediumSeaGreen;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            extra = "";
            userId = ";user id=" + comboLogin.Text;
            userPass = ";password=" + textBoxPassword.Text;
            checkSqlAuth();
        }

    }
}
