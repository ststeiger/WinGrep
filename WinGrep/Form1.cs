
using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;


namespace WinGrep2
{


    public partial class Form1 : Form
    {
        protected System.Threading.Thread m_searchthread = null;
        protected System.Collections.ArrayList m_arrFiles = new System.Collections.ArrayList(); // ArrayList keeping the Files


        public Form1()
        {
            InitializeComponent();

            pSetControlText = SetControlText;
            pSwitchCursor = SwitchCursor;
            //pSetWaitCursor = SetWaitCursor;
            //pUnsetWaitCursor = UnsetWaitCursor;
        } // End Constructor


        protected void SearchThread()
        {
            if (m_searchthread == null)
            {
                //Start Searching Thread
                m_searchthread = new System.Threading.Thread(new System.Threading.ThreadStart(Search));
                m_searchthread.IsBackground = true;
                m_searchthread.Start();
                btnSearch.Text = "Stop";
            }
            else //bSearching != null
            {
                //Stop Thread
                m_searchthread.Abort();
                txtCurFile.Text = "";
                txtResults.Text = "User Requested Search Abortion!";
            }

        } // End Sub SearchThread

        protected void txtFiles_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnSearch.Enabled == true)
            {
                SearchThread();
            }
        } // End Sub txtFiles_KeyDown


        protected void txtDir_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnSearch.Enabled == true)
            {
                SearchThread();
            }
        } // End Sub txtDir_KeyDown


        protected void txtSearchText_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnSearch.Enabled == true)
            {
                SearchThread();
            }
        } // End Sub txtSearchText_KeyDown


        //Build the list of Files
        protected void GetFiles(string strDir, string strExt, bool bRecursive)
        {
            //search pattern can include the wild characters '*' and '?'
            if (strDir.Length > 248)
                return;

            string[] fileList = System.IO.Directory.GetFiles(strDir, strExt);
            for (int i = 0; i < fileList.Length; i++)
            {
                if (System.IO.File.Exists(fileList[i]))
                    m_arrFiles.Add(fileList[i]);
            }

            if (bRecursive == true)
            {
                //Get recursively from subdirectories
                string[] dirList = System.IO.Directory.GetDirectories(strDir);
                for (int i = 0; i < dirList.Length; i++)
                {
                    GetFiles(dirList[i], strExt, true);
                }
            } // End if (bRecursive == true)

        } // End Sub GetFiles


        public delegate void pSetControlText_t(string strTextBoxName, string strText);
        public pSetControlText_t pSetControlText;


        public void SetControlText(string strButtonName, string strText)
        {
            this.Controls[strButtonName].Text= strText;
        } // End Sub SetControlText


        //Search Function
        protected void Search()
        {
            try
            {
                string strDir = txtDir.Text;
                //Check First if the Selected Directory exists
                if (!System.IO.Directory.Exists(strDir))
                    MessageBox.Show("Directory doesn't exist!", "Win Grep Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    //SetWaitCursor();
                    if (this.InvokeRequired)
                        this.Invoke(pSwitchCursor);
                    else
                        pSwitchCursor();

                    if (this.InvokeRequired)
                        this.Invoke(pSetControlText, new object[] { "txtResults", "" });
                    else
                        pSetControlText("txtResults", "");


                    //txtResults.Text = "";
                    //Initialize the Flags
                    bool bRecursive = cbRecursive.Checked;
                    bool bIgnoreCase = cbIgnoreCase.Checked;
                    bool bJustFiles = cbJustFiles.Checked;
                    bool bEscapeRegex = cbEscapeRegex.Checked;

                    bool bLineNumbers;

                    if (bJustFiles == true)
                        bLineNumbers = false;
                    else
                        bLineNumbers = cbLineNumbers.Checked;
                    bool bCountLines;

                    if (bJustFiles == true)
                        bCountLines = false;
                    else
                        bCountLines = cbCountLines.Checked;

                    //File Extension
                    string strExt = txtFiles.Text;
                    //First empty the list
                    m_arrFiles.Clear();

                    //Create recursively a list with all the files complying with the criteria
                    string[] astrExt = strExt.Split(new Char[] { ',' });
                    for (int i = 0; i < astrExt.Length; i++)
                    {
                        //Eliminate white spaces
                        astrExt[i] = astrExt[i].Trim();
                        GetFiles(strDir, astrExt[i], bRecursive);
                    } // Next i

                    //Now all the Files are in the ArrayList, open each one
                    //iteratively and look for the search string
                    string strSearch = txtSearchText.Text;

                    if (bEscapeRegex)
                    {
                        strSearch = strSearch.Replace("-", "\\-");
                        strSearch = strSearch.Replace("+", "\\+");
                        strSearch = System.Text.RegularExpressions.Regex.Escape(strSearch);
                    }
                        

                    string strResults = "";
                    string strLine;
                    int iLine, iCount;
                    bool bEmpty = true;
                    System.Collections.IEnumerator enm = m_arrFiles.GetEnumerator();
                    while (enm.MoveNext())
                    {
                        try
                        {
                            if (this.InvokeRequired)
                                this.Invoke(pSetControlText, new object[] { "txtCurFile", (string)enm.Current });
                            else
                                pSetControlText("txtCurFile", (string)enm.Current);

                            //SetTextBoxText("txtCurFile", (string)enm.Current);
                            //txtCurFile.Text = (string)enm.Current;
                            System.IO.StreamReader sr = System.IO.File.OpenText((string)enm.Current);
                            iLine = 0;
                            iCount = 0;
                            bool bFirst = true;
                            while ((strLine = sr.ReadLine()) != null)
                            {
                                iLine++;
                                //Using Regular Expressions as a real Grep
                                System.Text.RegularExpressions.Match mtch;
                                if (bIgnoreCase == true)
                                    mtch = System.Text.RegularExpressions.Regex.Match(strLine, strSearch, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                                else
                                    mtch = System.Text.RegularExpressions.Regex.Match(strLine, strSearch);

                                if (mtch.Success == true)
                                {
                                    bEmpty = false;
                                    iCount++;
                                    if (bFirst == true)
                                    {
                                        if (bJustFiles == true)
                                        {
                                            strResults += (string)enm.Current + "\r\n";
                                            break;
                                        }
                                        else
                                            strResults += (string)enm.Current + ":\r\n";
                                        bFirst = false;
                                    }
                                    //Add the Line to Results string
                                    if (bLineNumbers == true)
                                        strResults += "  " + iLine + ": " + strLine + "\r\n";
                                    else
                                        strResults += "  " + strLine + "\r\n";
                                } // End if (mtch.Success == true)
                            } // Whend
                            sr.Close();
                            if (bFirst == false)
                            {
                                if (bCountLines == true)
                                    strResults += "  " + iCount + " Lines Matched\r\n";
                                strResults += "\r\n";
                            } // End if (bFirst == false)

                        } // End try
                        catch (System.Security.SecurityException)
                        {
                            strResults += "\r\n" + (string)enm.Current + ": Security Exception\r\n\r\n";
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            strResults += "\r\n" + (string)enm.Current + ": File Not Found Exception\r\n";
                        }

                    } // Whend
                    //txtCurFile.Text = "";

                    if (this.InvokeRequired)
                        this.Invoke(pSetControlText, new object[] { "txtCurFile", "" });
                    else
                        pSetControlText("txtCurFile", "");

                    if (bEmpty == true)
                    {
                        //txtResults.Text = "No matches found!";
                        if (this.InvokeRequired)
                            this.Invoke(pSetControlText, new object[] { "txtResults", "No matches found!" });
                        else
                            pSetControlText("txtResults", "No matches found!");
                    }
                    else
                    {
                        //txtResults.Text = strResults;
                        if (this.InvokeRequired)
                            this.Invoke(pSetControlText, new object[] { "txtResults", strResults });
                        else
                            pSetControlText("txtResults", strResults);
                    }

                } // End else of if (!Directory.Exists(strDir))

            } // End Catch
            finally
            {
                m_searchthread = null;

                if (this.InvokeRequired)
                    this.Invoke(pSwitchCursor);
                else
                    pSwitchCursor();
                //UnsetWaitCursor();

                if (this.InvokeRequired)
                    this.Invoke(pSetControlText, new object[] { "btnSearch", "Start" });
                else
                    pSetControlText("btnSearch", "Start");
                //btnSearch.Text = "Start";

            } // End Finally

        } // End Sub Search


        public delegate void pVoidDelegate_t();

        //public pVoidDelegate_t pSetWaitCursor;
        //public pVoidDelegate_t pUnsetWaitCursor;
        public pVoidDelegate_t pSwitchCursor;


        public void SwitchCursor()
        {
            if (Cursor == Cursors.WaitCursor)
                Cursor = Cursors.Arrow;
            else
                Cursor = Cursors.WaitCursor;
        } // End Sub SwitchCursor


        public void SetWaitCursor()
        {
            Cursor = Cursors.WaitCursor;
        } // End Sub SetWaitCursor


        public void UnsetWaitCursor()
        {
            if (Cursor == Cursors.WaitCursor)
                Cursor = Cursors.Arrow;
        } // End Sub UnsetWaitCursor


        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            SearchThread();
        } // End Sub btnSearch_Click


        protected void VerifySearchBtn()
        {
            if (txtDir.Text != "" && txtSearchText.Text != "")
            {
                btnSearch.Enabled = true;
            }
            else
                btnSearch.Enabled = false;
        } // End Sub VerifySearchBtn


        protected void txtSearchText_TextChanged(object sender, System.EventArgs e)
        {
            VerifySearchBtn();
        } // End Sub txtSearchText_TextChanged


        protected void txtDir_TextChanged(object sender, System.EventArgs e)
        {
            VerifySearchBtn();
        } // End Sub txtDir_TextChanged


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select a file";
            fdlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            fdlg.Filter = "All files (*.*)|*.*";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                string strFile = fdlg.FileName;
                //File Extension
                string strExt;
                //Get the Directory and file extension
                txtDir.Text = System.IO.Path.GetDirectoryName(strFile);
                strExt = System.IO.Path.GetExtension(strFile);
                txtFiles.Text = "*" + strExt;
            }
        } // End Sub btnBrowse_Click


        private void ckJustFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (cbJustFiles.Checked == true)
            {
                cbLineNumbers.Enabled = false;
                cbCountLines.Enabled = false;
            }
            else
            {
                cbLineNumbers.Enabled = true;
                cbCountLines.Enabled = true;
            }
        } // End Sub ckJustFiles_CheckedChanged


    } // End Class Form1 : Form


} // End Namespace WinGrep2
