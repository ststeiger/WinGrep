namespace WinGrep2
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbJustFiles = new System.Windows.Forms.CheckBox();
            this.cbIgnoreCase = new System.Windows.Forms.CheckBox();
            this.cbLineNumbers = new System.Windows.Forms.CheckBox();
            this.cbRecursive = new System.Windows.Forms.CheckBox();
            this.lblCurFile = new System.Windows.Forms.Label();
            this.txtCurFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.lblSearchText = new System.Windows.Forms.Label();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.lblFiles = new System.Windows.Forms.Label();
            this.txtFiles = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbCountLines = new System.Windows.Forms.CheckBox();
            this.lblDir = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.cbEscapeRegex = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbJustFiles
            // 
            this.cbJustFiles.Location = new System.Drawing.Point(208, 97);
            this.cbJustFiles.Name = "cbJustFiles";
            this.cbJustFiles.Size = new System.Drawing.Size(84, 18);
            this.cbJustFiles.TabIndex = 33;
            this.cbJustFiles.Text = "Just Files";
            this.cbJustFiles.CheckedChanged += new System.EventHandler(this.ckJustFiles_CheckedChanged);
            // 
            // cbIgnoreCase
            // 
            this.cbIgnoreCase.Location = new System.Drawing.Point(104, 119);
            this.cbIgnoreCase.Name = "cbIgnoreCase";
            this.cbIgnoreCase.Size = new System.Drawing.Size(96, 18);
            this.cbIgnoreCase.TabIndex = 32;
            this.cbIgnoreCase.Text = "Ignore Case";
            // 
            // cbLineNumbers
            // 
            this.cbLineNumbers.Checked = true;
            this.cbLineNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLineNumbers.Location = new System.Drawing.Point(104, 97);
            this.cbLineNumbers.Name = "cbLineNumbers";
            this.cbLineNumbers.Size = new System.Drawing.Size(96, 18);
            this.cbLineNumbers.TabIndex = 31;
            this.cbLineNumbers.Text = "Line Numbers";
            // 
            // cbRecursive
            // 
            this.cbRecursive.Checked = true;
            this.cbRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecursive.Location = new System.Drawing.Point(14, 97);
            this.cbRecursive.Name = "cbRecursive";
            this.cbRecursive.Size = new System.Drawing.Size(84, 18);
            this.cbRecursive.TabIndex = 30;
            this.cbRecursive.Text = "Recursive";
            // 
            // lblCurFile
            // 
            this.lblCurFile.Location = new System.Drawing.Point(12, 149);
            this.lblCurFile.Name = "lblCurFile";
            this.lblCurFile.Size = new System.Drawing.Size(84, 12);
            this.lblCurFile.TabIndex = 28;
            this.lblCurFile.Text = "Current File";
            // 
            // txtCurFile
            // 
            this.txtCurFile.BackColor = System.Drawing.SystemColors.Info;
            this.txtCurFile.Location = new System.Drawing.Point(12, 161);
            this.txtCurFile.Name = "txtCurFile";
            this.txtCurFile.ReadOnly = true;
            this.txtCurFile.Size = new System.Drawing.Size(472, 20);
            this.txtCurFile.TabIndex = 29;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(456, 21);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 20);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Text = "...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblResults
            // 
            this.lblResults.Location = new System.Drawing.Point(12, 189);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(56, 12);
            this.lblResults.TabIndex = 27;
            this.lblResults.Text = "Results";
            // 
            // txtResults
            // 
            this.txtResults.BackColor = System.Drawing.SystemColors.Info;
            this.txtResults.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtResults.Location = new System.Drawing.Point(12, 201);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(472, 216);
            this.txtResults.TabIndex = 26;
            this.txtResults.WordWrap = false;
            // 
            // lblSearchText
            // 
            this.lblSearchText.Location = new System.Drawing.Point(204, 53);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(196, 12);
            this.lblSearchText.TabIndex = 23;
            this.lblSearchText.Text = "Search Pattern (Regular Expression)";
            // 
            // txtSearchText
            // 
            this.txtSearchText.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearchText.Location = new System.Drawing.Point(204, 65);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(280, 20);
            this.txtSearchText.TabIndex = 24;
            this.txtSearchText.TextChanged += new System.EventHandler(this.txtSearchText_TextChanged);
            this.txtSearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchText_KeyDown);
            // 
            // lblFiles
            // 
            this.lblFiles.Location = new System.Drawing.Point(12, 53);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(84, 12);
            this.lblFiles.TabIndex = 21;
            this.lblFiles.Text = "Files";
            // 
            // txtFiles
            // 
            this.txtFiles.BackColor = System.Drawing.SystemColors.Window;
            this.txtFiles.Location = new System.Drawing.Point(12, 65);
            this.txtFiles.Name = "txtFiles";
            this.txtFiles.Size = new System.Drawing.Size(180, 20);
            this.txtFiles.TabIndex = 22;
            this.txtFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiles_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(424, 113);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 24);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbCountLines
            // 
            this.cbCountLines.Checked = true;
            this.cbCountLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCountLines.Location = new System.Drawing.Point(14, 119);
            this.cbCountLines.Name = "cbCountLines";
            this.cbCountLines.Size = new System.Drawing.Size(84, 18);
            this.cbCountLines.TabIndex = 20;
            this.cbCountLines.Text = "Count Lines";
            // 
            // lblDir
            // 
            this.lblDir.Location = new System.Drawing.Point(12, 9);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(60, 12);
            this.lblDir.TabIndex = 17;
            this.lblDir.Text = "Directory";
            // 
            // txtDir
            // 
            this.txtDir.BackColor = System.Drawing.SystemColors.Window;
            this.txtDir.Location = new System.Drawing.Point(12, 21);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(436, 20);
            this.txtDir.TabIndex = 18;
            this.txtDir.TextChanged += new System.EventHandler(this.txtDir_TextChanged);
            this.txtDir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDir_KeyDown);
            // 
            // cbEscapeRegex
            // 
            this.cbEscapeRegex.Checked = true;
            this.cbEscapeRegex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEscapeRegex.Location = new System.Drawing.Point(208, 119);
            this.cbEscapeRegex.Name = "cbEscapeRegex";
            this.cbEscapeRegex.Size = new System.Drawing.Size(96, 18);
            this.cbEscapeRegex.TabIndex = 34;
            this.cbEscapeRegex.Text = "Escape Regex";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 433);
            this.Controls.Add(this.cbEscapeRegex);
            this.Controls.Add(this.cbJustFiles);
            this.Controls.Add(this.cbIgnoreCase);
            this.Controls.Add(this.cbLineNumbers);
            this.Controls.Add(this.cbRecursive);
            this.Controls.Add(this.lblCurFile);
            this.Controls.Add(this.txtCurFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.lblSearchText);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.txtFiles);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbCountLines);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.txtDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WinGrep";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbJustFiles;
        private System.Windows.Forms.CheckBox cbIgnoreCase;
        private System.Windows.Forms.CheckBox cbLineNumbers;
        private System.Windows.Forms.CheckBox cbRecursive;
        private System.Windows.Forms.Label lblCurFile;
        private System.Windows.Forms.TextBox txtCurFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.TextBox txtFiles;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox cbCountLines;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.CheckBox cbEscapeRegex;
    }
}

