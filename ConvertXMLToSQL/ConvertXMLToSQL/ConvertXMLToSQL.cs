using ConvertXMLToSQL.Properties;
using FastColoredTextBoxNS;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ConvertXMLToSQL
{
    public partial class ConvertXMLToSQL : MaterialForm
    {
        string filePath, fileName;
        int elementCount;
        SQLHelper db;
        List<string> listNameElement, listQuery;
        SplashScreen frmSplash;
        bool richTextBox = false;
        List<string> listServerName, listDBName, listTable;
        string serverName, dbName, tableName;


        public ConvertXMLToSQL()
        {
            InitializeComponent();
            listServerName = Library.loadServerName();
            foreach (string item in listServerName) {
                cbbServerName.Items.Add(item);
            }
        }

        public ConvertXMLToSQL(SplashScreen frm)
        {
            this.frmSplash = frm;
            InitializeComponent();
            listServerName = Library.loadServerName();
            foreach (string item in listServerName)
            {
                cbbServerName.Items.Add(item);
            }

            // Initialize MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.PrimaryColor = Color.FromArgb(55, 71, 79);
            materialSkinManager.PrimaryColorDark = Color.FromArgb(38, 50, 56);
            materialSkinManager.AccentColor = Color.FromArgb(64, 196, 255);

        }

        private void configFrom(bool richBox) {
            this.richTextBox = richBox;
            if (!richTextBox)
            {
                richXML.ReadOnly = true;
            }
            else {
                richXML.ReadOnly = false;

            }
        }

        private void loadError(string errorMessage) {
            this.lblError.Text = errorMessage;
            this.lblError.BackColor = Color.Red;
            this.lblError.Font = new Font("Arial", 14);
            this.pbError.Image = Resources.sunny;
        }



        #region Convert XML To SQL
        private void ConvertXMLToSQL_Load(object sender, EventArgs e)
        {
            configFrom(false);
            loadError("");
            this.pbError.Image = null;
            richXMLSystax();
            richSQLQuery1();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            filePath = null;
            configFrom(true);
            richXML.Text = "";
            StreamReader sr = new StreamReader("demo.xml");
            string line = sr.ReadLine();
            while (line != null)
            {
                richXML.Text += line + "\n";
                line = sr.ReadLine();
            }
            sr.Close();

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            richXML.Text = "";

            OpenFileDialog op = Library.openFileDialog();
           
            if (op != null) {

                lblFileName.Text = op.SafeFileName;
                filePath = op.FileName;
                fileName = op.SafeFileName.Split('.')[0];
                try
                {
                    var document = XElement.Load(filePath);
                    richXML.Text = document.ToString();
                   // Library.HighlightRTF(richXML);

                    elementCount = Library.getCountElement(filePath);
                    listNameElement = Library.getElementName(filePath);
                    loadError("Load file xml complete");
                }
                catch (XmlException ex) {
                    loadError("File xml error");
                    timer1.Enabled = true;
                    //throw ex;
                    
                }
                
               
            }
            configFrom(false);

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            delayLabel();
            timer1.Enabled = false;
        }

        private async Task delayLabel()
        {
            string temp = lblError.Text.ToString();
            for (int i = 0; i < 6; i++)
            {
                if (i % 2 == 0)
                {
                    loadError("");
                    this.Refresh();
                }
                else
                {
                    loadError(temp);
                    this.Refresh();
                }
                await Task.Delay(500);
            }
            //loadError(temp);
        }

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "filename.xml";
            save.Filter = "XML File | *.xml";

            // Determine if the user selected a file name from the saveFileDialog.
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               save.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
               richXML.SaveToFile(save.FileName, Encoding.UTF8);
            }

        }

        private void btnConvertSQL_Click(object sender, EventArgs e)
        {
            string querySQL = "";
            timer1.Enabled = true;
            if (filePath != null && filePath != "")
            {
                if (serverName != null && serverName != "") {
                    if (dbName != null && dbName != "")
                    {
                        tableName = this.cbbTable.Text.ToString();
                        if (tableName == null || tableName.Equals("")) {
                            tableName = fileName;
                        }
                        if (tableName != null && tableName != "") {
                            
                            db = new SQLHelper(serverName, dbName);
                            listQuery = Library.getQuerySQLInsert(filePath, listNameElement, tableName);
                            db.deleteTableExists(tableName);
                            db.createTable(listNameElement, tableName);
                            db.insertTable(listQuery);
                            dgvSQL.DataSource = db.getData(tableName);
                            querySQL += db.getQueryCreateTable(listNameElement, tableName);
                            querySQL += db.getQueryInsertTable(listQuery);
                            richSQLQuery.Text = querySQL;
                            //MessageBox.Show("Convert To Sql Success");
                            loadError("Convert to sql success");
                           
                        }
                        else
                        {
                            //MessageBox.Show("Please, choose Table");
                            loadError("Please, choose Table");
                        }

                    }
                    else {
                        //MessageBox.Show("Please, choose DB");
                        loadError("Please, choose database");
                    }
                }
                else
                {
                    //MessageBox.Show("Please, choose Server");
                    loadError("Please, choose server");
                }

            }
            else
            {
                //MessageBox.Show("Please, Choose File .Xml");
                loadError("Please, Choose file .xml");
            }
            

        }

        private void ConvertXMLToSQL_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult da;
            da = MessageBox.Show("Do you want to exit ?", "Exit Application", MessageBoxButtons.YesNo);
            if (da == DialogResult.No)
            {
                e.Cancel = true;
            }
            else {
                frmSplash.Close();
                Application.Exit();
            }
           
        }

        private void cbbServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbDB.Items.Clear();
            serverName = this.cbbServerName.GetItemText(this.cbbServerName.SelectedItem);
            listDBName = Library.loadDB(serverName);
            foreach (string item in listDBName) {
                cbbDB.Items.Add(item);
            }
        }

        private void cbbDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTable.Items.Clear();
            dbName = this.cbbDB.GetItemText(this.cbbDB.SelectedItem);
            listTable = Library.loadTable(serverName,dbName);
            foreach (string item in listTable) {
                cbbTable.Items.Add(item);
            }
        }

        private void cbbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableName = this.cbbTable.GetItemText(this.cbbTable.SelectedItem);
        }


        private void lblTable_Click(object sender, EventArgs e)
        {
            
        }

        #endregion


        #region Convert SQL TO XML
        private void btnConvertToXML_Click(object sender, EventArgs e)
        {
            if (serverName != null && serverName != "") {
                if (dbName != null && dbName != "") {
                    if (tableName != null && tableName != "") {
                        db = new SQLHelper(serverName,dbName);
                        dgvSQL.DataSource = db.getData(tableName);
                        string xml = @"<?xml version='1.0' encoding='utf-8'?>";
                        string temp = db.getXML(tableName).Rows[0][0].ToString().Insert(0, xml);
                        XDocument doc = XDocument.Parse(temp);
                        string indented = doc.ToString();
                        richXML.Text = indented;
                        richSQLQuery.Text = db.getQuerySQLInXML(tableName);
                    }
                }
            }
        }


        #endregion


        #region Systax FastColor TextBox XML

        string lang = "CSharp (custom highlighter)";
        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);


        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private void InitStylesPriority()
        {
            //add this style explicitly for drawing under other styles
            richXML.AddStyle(SameWordsStyle);
        }
        private void richXML_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (lang)
            {
                case "CSharp (custom highlighter)":
                    //For sample, we will highlight the syntax of C# manually, although could use built-in highlighter
                    CSharpSyntaxHighlight(e);//custom highlighting
                    break;
                default:
                    break;//for highlighting of other languages, we using built-in FastColoredTextBox highlighter
            }

            if (richXML.Text.Trim().StartsWith("<?xml"))
            {
                richXML.Language = FastColoredTextBoxNS.Language.XML;

                richXML.ClearStylesBuffer();
                richXML.Range.ClearStyle(StyleIndex.All);
                InitStylesPriority();
                richXML.AutoIndentNeeded -= richXML_AutoIndentNeeded;

                richXML.OnSyntaxHighlight(new TextChangedEventArgs(richXML.Range));
            }
        }

        private void CSharpSyntaxHighlight(TextChangedEventArgs e)
        {
            richXML.LeftBracket = '(';
            richXML.RightBracket = ')';
            richXML.LeftBracket2 = '\x0';
            richXML.RightBracket2 = '\x0';
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle);

            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //attribute highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
            //keyword highlighting
            e.ChangedRange.SetStyle(BlueStyle, @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
        }

        private void richXML_AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            //block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{.*\}[^""']*$"))
                return;
            //start of block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //end of block {}
            if (Regex.IsMatch(args.LineText, @"}[^""']*$"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //label
            if (Regex.IsMatch(args.LineText, @"^\s*\w+\s*:\s*($|//)") &&
                !Regex.IsMatch(args.LineText, @"^\s*default\s*:"))
            {
                args.Shift = -args.TabLength;
                return;
            }
            //some statements: case, default
            if (Regex.IsMatch(args.LineText, @"^\s*(case|default)\b.*:\s*($|//)"))
            {
                args.Shift = -args.TabLength / 2;
                return;
            }
            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)"))//operator is unclosed
                {
                    args.Shift = args.TabLength;
                    return;
                }
        }

        public void richXMLSystax() {

            richXML.ClearStylesBuffer();
            richXML.Range.ClearStyle(StyleIndex.All);
            InitStylesPriority();
            richXML.AutoIndentNeeded -= richXML_AutoIndentNeeded;
            richXML.Language = FastColoredTextBoxNS.Language.XML;
            richXML.OnSyntaxHighlight(new TextChangedEventArgs(richXML.Range));
        }

        #endregion


        #region Systax FastColor TextBox SQL Query

        string lang1 = "CSharp (custom highlighter)";
        TextStyle BlueStyle1 = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle1 = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        TextStyle GrayStyle1 = new TextStyle(Brushes.Gray, null, FontStyle.Regular);


        TextStyle MagentaStyle1 = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle1 = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle BrownStyl1e = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        TextStyle MaroonStyle1 = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);

        private void richXML_Load(object sender, EventArgs e)
        {

        }

        MarkerStyle SameWordsStyle1 = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private void InitStylesPriority1()
        {
            //add this style explicitly for drawing under other styles
            richSQLQuery.AddStyle(SameWordsStyle);
        }
        private void richXML_TextChanged1(object sender, TextChangedEventArgs e)
        {
            switch (lang1)
            {
                case "CSharp (custom highlighter)":
                    //For sample, we will highlight the syntax of C# manually, although could use built-in highlighter
                    CSharpSyntaxHighlight1(e);//custom highlighting
                    break;
                default:
                    break;//for highlighting of other languages, we using built-in FastColoredTextBox highlighter
            }

            if (richSQLQuery.Text.Trim().StartsWith("<?xml"))
            {
                richSQLQuery.Language = FastColoredTextBoxNS.Language.XML;

                richSQLQuery.ClearStylesBuffer();
                richSQLQuery.Range.ClearStyle(StyleIndex.All);
                InitStylesPriority();
                richSQLQuery.AutoIndentNeeded -= richXML_AutoIndentNeeded1;

                richSQLQuery.OnSyntaxHighlight(new TextChangedEventArgs(richSQLQuery.Range));
            }
        }

        private void CSharpSyntaxHighlight1(TextChangedEventArgs e)
        {
            richSQLQuery.LeftBracket = '(';
            richSQLQuery.RightBracket = ')';
            richSQLQuery.LeftBracket2 = '\x0';
            richSQLQuery.RightBracket2 = '\x0';
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle);

            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //attribute highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
            //keyword highlighting
            e.ChangedRange.SetStyle(BlueStyle, @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
        }

        private void richXML_AutoIndentNeeded1(object sender, AutoIndentEventArgs args)
        {
            //block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{.*\}[^""']*$"))
                return;
            //start of block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //end of block {}
            if (Regex.IsMatch(args.LineText, @"}[^""']*$"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //label
            if (Regex.IsMatch(args.LineText, @"^\s*\w+\s*:\s*($|//)") &&
                !Regex.IsMatch(args.LineText, @"^\s*default\s*:"))
            {
                args.Shift = -args.TabLength;
                return;
            }
            //some statements: case, default
            if (Regex.IsMatch(args.LineText, @"^\s*(case|default)\b.*:\s*($|//)"))
            {
                args.Shift = -args.TabLength / 2;
                return;
            }
            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)"))//operator is unclosed
                {
                    args.Shift = args.TabLength;
                    return;
                }
        }

        public void richSQLQuery1()
        {
            richSQLQuery.ClearStylesBuffer();
            richSQLQuery.Range.ClearStyle(StyleIndex.All);
            InitStylesPriority();
            richSQLQuery.AutoIndentNeeded -= richXML_AutoIndentNeeded;
            richSQLQuery.Language = FastColoredTextBoxNS.Language.SQL;
            richSQLQuery.OnSyntaxHighlight(new TextChangedEventArgs(richSQLQuery.Range));
        }

        #endregion

    }
}
