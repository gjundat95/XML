namespace ConvertXMLToSQL
{
    partial class ConvertXMLToSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertXMLToSQL));
            this.btnOpen = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCreate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblFileName = new MaterialSkin.Controls.MaterialLabel();
            this.btnConvertSQL = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dgvSQL = new System.Windows.Forms.DataGridView();
            this.cbbServerName = new System.Windows.Forms.ComboBox();
            this.lblServerName = new MaterialSkin.Controls.MaterialLabel();
            this.lblDB = new MaterialSkin.Controls.MaterialLabel();
            this.cbbDB = new System.Windows.Forms.ComboBox();
            this.lblTable = new MaterialSkin.Controls.MaterialLabel();
            this.cbbTable = new System.Windows.Forms.ComboBox();
            this.lblError = new MaterialSkin.Controls.MaterialLabel();
            this.pbError = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSaveXML = new MaterialSkin.Controls.MaterialRaisedButton();
            this.richXML = new FastColoredTextBoxNS.FastColoredTextBox();
            this.richSQLQuery = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnConvertToXML = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richSQLQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Depth = 0;
            this.btnOpen.Location = new System.Drawing.Point(134, 85);
            this.btnOpen.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Primary = true;
            this.btnOpen.Size = new System.Drawing.Size(110, 28);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open File XML";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Depth = 0;
            this.btnCreate.Location = new System.Drawing.Point(12, 85);
            this.btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Primary = true;
            this.btnCreate.Size = new System.Drawing.Size(99, 28);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create File";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Depth = 0;
            this.lblFileName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileName.Location = new System.Drawing.Point(253, 91);
            this.lblFileName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(77, 19);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "File Name";
            // 
            // btnConvertSQL
            // 
            this.btnConvertSQL.Depth = 0;
            this.btnConvertSQL.Location = new System.Drawing.Point(494, 262);
            this.btnConvertSQL.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConvertSQL.Name = "btnConvertSQL";
            this.btnConvertSQL.Primary = true;
            this.btnConvertSQL.Size = new System.Drawing.Size(134, 44);
            this.btnConvertSQL.TabIndex = 5;
            this.btnConvertSQL.Text = "Convert To SQL";
            this.btnConvertSQL.UseVisualStyleBackColor = true;
            this.btnConvertSQL.Click += new System.EventHandler(this.btnConvertSQL_Click);
            // 
            // dgvSQL
            // 
            this.dgvSQL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSQL.BackgroundColor = System.Drawing.Color.White;
            this.dgvSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSQL.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSQL.Location = new System.Drawing.Point(659, 132);
            this.dgvSQL.Name = "dgvSQL";
            this.dgvSQL.Size = new System.Drawing.Size(599, 188);
            this.dgvSQL.TabIndex = 6;
            // 
            // cbbServerName
            // 
            this.cbbServerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbServerName.FormattingEnabled = true;
            this.cbbServerName.Location = new System.Drawing.Point(760, 98);
            this.cbbServerName.Name = "cbbServerName";
            this.cbbServerName.Size = new System.Drawing.Size(78, 21);
            this.cbbServerName.TabIndex = 7;
            this.cbbServerName.SelectedIndexChanged += new System.EventHandler(this.cbbServerName_SelectedIndexChanged);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Depth = 0;
            this.lblServerName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblServerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblServerName.Location = new System.Drawing.Point(658, 99);
            this.lblServerName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(95, 19);
            this.lblServerName.TabIndex = 8;
            this.lblServerName.Text = "Server Name";
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Depth = 0;
            this.lblDB.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDB.Location = new System.Drawing.Point(855, 100);
            this.lblDB.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(72, 19);
            this.lblDB.TabIndex = 9;
            this.lblDB.Text = "Database";
            // 
            // cbbDB
            // 
            this.cbbDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDB.FormattingEnabled = true;
            this.cbbDB.Location = new System.Drawing.Point(935, 99);
            this.cbbDB.Name = "cbbDB";
            this.cbbDB.Size = new System.Drawing.Size(121, 21);
            this.cbbDB.TabIndex = 10;
            this.cbbDB.SelectedIndexChanged += new System.EventHandler(this.cbbDB_SelectedIndexChanged);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Depth = 0;
            this.lblTable.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTable.Location = new System.Drawing.Point(1076, 99);
            this.lblTable.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(46, 19);
            this.lblTable.TabIndex = 11;
            this.lblTable.Text = "Table";
            this.lblTable.Click += new System.EventHandler(this.lblTable_Click);
            // 
            // cbbTable
            // 
            this.cbbTable.FormattingEnabled = true;
            this.cbbTable.Location = new System.Drawing.Point(1137, 97);
            this.cbbTable.Name = "cbbTable";
            this.cbbTable.Size = new System.Drawing.Size(121, 21);
            this.cbbTable.TabIndex = 12;
            this.cbbTable.SelectedIndexChanged += new System.EventHandler(this.cbbTable_SelectedIndexChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Depth = 0;
            this.lblError.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblError.Location = new System.Drawing.Point(49, 459);
            this.lblError.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(42, 19);
            this.lblError.TabIndex = 13;
            this.lblError.Text = "Error";
            // 
            // pbError
            // 
            this.pbError.Image = global::ConvertXMLToSQL.Properties.Resources.sunny;
            this.pbError.Location = new System.Drawing.Point(12, 454);
            this.pbError.Name = "pbError";
            this.pbError.Size = new System.Drawing.Size(30, 30);
            this.pbError.TabIndex = 14;
            this.pbError.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSaveXML
            // 
            this.btnSaveXML.Depth = 0;
            this.btnSaveXML.Location = new System.Drawing.Point(12, 493);
            this.btnSaveXML.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveXML.Name = "btnSaveXML";
            this.btnSaveXML.Primary = true;
            this.btnSaveXML.Size = new System.Drawing.Size(75, 33);
            this.btnSaveXML.TabIndex = 17;
            this.btnSaveXML.Text = "Save XML";
            this.btnSaveXML.UseVisualStyleBackColor = true;
            this.btnSaveXML.Click += new System.EventHandler(this.btnSaveXML_Click);
            // 
            // richXML
            // 
            this.richXML.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.richXML.AutoScrollMinSize = new System.Drawing.Size(115, 14);
            this.richXML.BackBrush = null;
            this.richXML.CharHeight = 14;
            this.richXML.CharWidth = 8;
            this.richXML.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richXML.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.richXML.IsReplaceMode = false;
            this.richXML.Location = new System.Drawing.Point(12, 132);
            this.richXML.Name = "richXML";
            this.richXML.Paddings = new System.Windows.Forms.Padding(0);
            this.richXML.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.richXML.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("richXML.ServiceColors")));
            this.richXML.Size = new System.Drawing.Size(441, 316);
            this.richXML.TabIndex = 19;
            this.richXML.Text = "Content XML";
            this.richXML.Zoom = 100;
            this.richXML.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.richXML_TextChanged);
            this.richXML.Load += new System.EventHandler(this.richXML_Load);
            // 
            // richSQLQuery
            // 
            this.richSQLQuery.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.richSQLQuery.AutoScrollMinSize = new System.Drawing.Size(163, 14);
            this.richSQLQuery.BackBrush = null;
            this.richSQLQuery.CharHeight = 14;
            this.richSQLQuery.CharWidth = 8;
            this.richSQLQuery.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richSQLQuery.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.richSQLQuery.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.richSQLQuery.IsReplaceMode = false;
            this.richSQLQuery.Location = new System.Drawing.Point(659, 327);
            this.richSQLQuery.Name = "richSQLQuery";
            this.richSQLQuery.Paddings = new System.Windows.Forms.Padding(0);
            this.richSQLQuery.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.richSQLQuery.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("richSQLQuery.ServiceColors")));
            this.richSQLQuery.Size = new System.Drawing.Size(599, 195);
            this.richSQLQuery.TabIndex = 20;
            this.richSQLQuery.Text = "Content SQL Query";
            this.richSQLQuery.Zoom = 100;
            // 
            // btnConvertToXML
            // 
            this.btnConvertToXML.Depth = 0;
            this.btnConvertToXML.Location = new System.Drawing.Point(494, 336);
            this.btnConvertToXML.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConvertToXML.Name = "btnConvertToXML";
            this.btnConvertToXML.Primary = true;
            this.btnConvertToXML.Size = new System.Drawing.Size(134, 44);
            this.btnConvertToXML.TabIndex = 21;
            this.btnConvertToXML.Text = "Convert To XML";
            this.btnConvertToXML.UseVisualStyleBackColor = true;
            this.btnConvertToXML.Click += new System.EventHandler(this.btnConvertToXML_Click);
            // 
            // ConvertXMLToSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 534);
            this.Controls.Add(this.btnConvertToXML);
            this.Controls.Add(this.richSQLQuery);
            this.Controls.Add(this.richXML);
            this.Controls.Add(this.btnSaveXML);
            this.Controls.Add(this.pbError);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.cbbTable);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.cbbDB);
            this.Controls.Add(this.lblDB);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.cbbServerName);
            this.Controls.Add(this.dgvSQL);
            this.Controls.Add(this.btnConvertSQL);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConvertXMLToSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convert XML To SQL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConvertXMLToSQL_FormClosing);
            this.Load += new System.EventHandler(this.ConvertXMLToSQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richXML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richSQLQuery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton btnOpen;
        private MaterialSkin.Controls.MaterialRaisedButton btnCreate;
        private MaterialSkin.Controls.MaterialLabel lblFileName;
        private MaterialSkin.Controls.MaterialRaisedButton btnConvertSQL;
        private System.Windows.Forms.DataGridView dgvSQL;
        private System.Windows.Forms.ComboBox cbbServerName;
        private MaterialSkin.Controls.MaterialLabel lblServerName;
        private MaterialSkin.Controls.MaterialLabel lblDB;
        private System.Windows.Forms.ComboBox cbbDB;
        private MaterialSkin.Controls.MaterialLabel lblTable;
        private System.Windows.Forms.ComboBox cbbTable;
        private MaterialSkin.Controls.MaterialLabel lblError;
        private System.Windows.Forms.PictureBox pbError;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialRaisedButton btnSaveXML;
        private FastColoredTextBoxNS.FastColoredTextBox richXML;
        private FastColoredTextBoxNS.FastColoredTextBox richSQLQuery;
        private MaterialSkin.Controls.MaterialRaisedButton btnConvertToXML;
    }
}

