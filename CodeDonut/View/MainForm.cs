using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FastColoredTextBoxNS;

namespace CodeDonut
{
    public partial class MainForm : Form
    {
        private AutocompleteMenu acMenu;//代码补全菜单

        private FindForm _findForm;
        private ReplaceForm _replaceForm;
        private ACMModeForm _acmModeForm;
        private MultipleCasesTestForm _multipleCasesTestForm;
        private ContestsForm _contestsForm;
        public static CompileErrorInfoForm FormCompileErrorInfo { get; set; }
        public static FastColoredTextBox FCTB { get; set; }
        public static MainForm FormMain { get; set; }

        private string[] _args;//启动参数

        private string currentFilePath;//当前编辑的源文件路径


        public MainForm(string[] args)
        {
            InitializeComponent();
            this._args = args;
        }
        private void Form_Main_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Exit())
            {
                e.Cancel = true;
            }
        }


        #region 方法
        /// <summary>
        /// 初始化程序
        /// </summary>
        private void Init()
        {
            FCTB = fastColoredTextBox_Main;
            acMenu = new AutocompleteMenu(fastColoredTextBox_Main);

            FormCompileErrorInfo = new CompileErrorInfoForm();
            FormMain = this;

            #region 配置信息
            Config.LoadConfig();//加载配置信息

            if (Config.MainFormMax == "1")//最大化
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                int height, weigh;
                Int32.TryParse(Config.MainFormWidth, out weigh);
                Int32.TryParse(Config.MainFormHeight, out height);
                this.Width = weigh;
                this.Height = height;
            }

            if (Config.EnableChineseInput == "1")
            {
                fastColoredTextBox_Main.ImeMode = ImeMode.On;
            }
            else
            {
                fastColoredTextBox_Main.ImeMode = ImeMode.NoControl;
            }
            #endregion

            I18N.InitLanguageData();//初始化多语言

            InitText();//初始化本窗口语言

            string path = _args.Length == 0 ? FileManager.GetLastOpenFilePath() : String.Join(" ", _args);//获取源文件路径，长度为0代表直接运行IDE，非0代表打开外部源文件

            InitEditor(!path.ToLower().EndsWith("c"));//初始化编辑框，判断C/C++，默认C++

            LoadData(path);//加载源文件

            new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                ContestsForm.InitContestsInfo();//后台预加载竞赛信息
            })).Start();
        }

        private void InitText()
        {
            I18N.InitMenuStrip(menuStrip_Main);
            I18N.InitToolStrip(toolStrip_Main);
            I18N.InitContextMenuStrip(contextMenuStrip_Main);
            I18N.InitControls(this);
        }
        private void LoadData(string path)
        {
            if (_args.Length == 0 && !File.Exists(path))//创建新文件
            {
                IOHelper.WriteAllText(path, CodeDonut.Properties.Resources.CppDefaultCode);
            }

            fastColoredTextBox_Main.Text = IOHelper.ReadAllText(path);
            this.Text = "CodeDonut - " + path;
            currentFilePath = path;
        }
        private void InitEditor(bool typeIsCpp)//初始化代码高亮补全 false-C, trueC++
        {
            string highLightingRules = typeIsCpp ? Config.Cpp_HighLighting : Config.C_HighLighting;
            string autoCompleteRules = typeIsCpp ? Config.Cpp_AutoComplete : Config.C_AutoComplete;
            HighlightingCode.InitHighlightingCode(highLightingRules);
            AutoComplete.InitAutoComplete(autoCompleteRules, acMenu, fastColoredTextBox_Main, imageList_ACIco);
            AutoAddFragment.Init(fastColoredTextBox_Main);
        }

        private bool Exit()//退出
        {
            if (fastColoredTextBox_Main.Text != IOHelper.ReadAllText(currentFilePath))
            {
                if (MessageBox.Show(I18N.GetValue("Do you want to exit?"), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (MessageBox.Show(I18N.GetValue("Do you want to save changes?"), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!IOHelper.WriteAllText(currentFilePath, fastColoredTextBox_Main.Text))
                        {
                            MessageBox.Show(I18N.GetValue("Can't write source file."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            IOHelper.WriteAllText("LastOpen.dat", currentFilePath);

            Config.MainFormHeight = this.Height.ToString();
            Config.MainFormWidth = this.Width.ToString();
            Config.MainFormMax = this.WindowState == FormWindowState.Maximized ? "1" : "0";
            Config.SaveConfig();

            //Environment.Exit(0);
            if (_findForm != null && !_findForm.IsDisposed)
            {
                _findForm.Close();
            }

            if (_findForm != null && !_findForm.IsDisposed)
            {
                _findForm.Close();
            }

            if (FormCompileErrorInfo != null && !FormCompileErrorInfo.IsDisposed)
            {
                FormCompileErrorInfo.Close();
            }

            return true;
        }
        #endregion

        #region 菜单事件
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.SelectAll();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Undo();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Paste();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Redo();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Cut();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.SelectAll();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.ClearSelected();
        }

        private void deleteCurrentLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.ClearCurrentLine();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.ClearSelected();
        }

        private void deleteCurrentLineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.ClearCurrentLine();
        }

        private void deleteAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.SelectAll();
            fastColoredTextBox_Main.ClearSelected();//防止无法撤销
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.SelectAll();
            fastColoredTextBox_Main.ClearSelected();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_findForm == null || _findForm.IsDisposed)
            {
                _findForm = new FindForm(fastColoredTextBox_Main);
                _findForm.Show();
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_replaceForm == null || _replaceForm.IsDisposed) 
            {
                _replaceForm = new ReplaceForm(fastColoredTextBox_Main);
                _replaceForm.Show();
            }
        }

        private void contestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_contestsForm == null || _contestsForm.IsDisposed)
            {
                _contestsForm = new ContestsForm();
                _contestsForm.Show();
            }
        }

        private void cFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.CreatNewSourceFile(false);
        }

        private void cppFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager.CreatNewSourceFile(true);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = FileManager.OpenSourceFileDialog();
            if (!String.IsNullOrEmpty(path))
            {
                _args = new string[1] { path };
                InitEditor(!_args[0].ToLower().EndsWith("c"));
                LoadData(path);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!IOHelper.WriteAllText(currentFilePath,fastColoredTextBox_Main.Text))
            {
                MessageBox.Show("Can't write source file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = FileManager.SaveSourceFileAsDialog(currentFilePath);
            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            if (!IOHelper.WriteAllText(path, fastColoredTextBox_Main.Text))
            {
                MessageBox.Show("Can't write source file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            currentFilePath = path;
            this.Text = "CodeDonut - " + path;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOHelper.WriteAllText(currentFilePath, fastColoredTextBox_Main.Text);
            Compile.CompileFile(currentFilePath);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessHelper.StartProcessIgnoreException(currentFilePath + ".exe");
        }

        private void buildAndRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOHelper.WriteAllText(currentFilePath, fastColoredTextBox_Main.Text);
            if (Compile.CompileFile(currentFilePath))
            {
                ProcessHelper.StartProcessIgnoreException(currentFilePath + ".exe");
            }
        }
        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Azure99/CodeDonut/issues");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(I18N.GetValue("By Azure99 QQ:961523404"));
        }

        private void checkUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(I18N.GetValue("Latest version"), "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://github.com/Azure99/CodeDonut/releases");
            }
        }

        private void runInACMModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_acmModeForm == null || _acmModeForm.IsDisposed)
            {
                _acmModeForm = new ACMModeForm(currentFilePath + ".exe");
                _acmModeForm.Show();
            }
        }
        private void multipleCasesTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_multipleCasesTestForm == null || _multipleCasesTestForm.IsDisposed)
            {
                _multipleCasesTestForm = new MultipleCasesTestForm(currentFilePath + ".exe");
                _multipleCasesTestForm.Show();
            }
        }

        #endregion

        #region 代码编辑事件
        private void Form_Main_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel_FileShow.Text = IOHelper.GetFileName(this.Text);
        }

        private void fastColoredTextBox_Main_TextChanged(object sender, TextChangedEventArgs e)
        {
            fastColoredTextBox_Main.LeftBracket = '(';
            fastColoredTextBox_Main.RightBracket = ')';
            fastColoredTextBox_Main.LeftBracket2 = '\x0';
            fastColoredTextBox_Main.RightBracket2 = '\x0';

            HighlightingCode.Highlighting(e);
            toolStripStatusLabel_LengthShow.Text = fastColoredTextBox_Main.TextLength.ToString();
        }

        private void fastColoredTextBox_Main_SelectionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel_LineShow.Text = (fastColoredTextBox_Main.Selection.FromLine + 1).ToString();
            toolStripStatusLabel_SelectionShow.Text = fastColoredTextBox_Main.Selection.Length.ToString();
            HighlightingCode.HighlightingSameWords(fastColoredTextBox_Main);
        }


        private void fastColoredTextBox_Main_KeyPressing(object sender, KeyPressEventArgs e)
        {
            //若当前行全为空格，且用户欲删除，直接全选提升删除体验
            if (e.KeyChar == (char)Keys.Back && FCTB.Selection.Length == 0)
            {
                Place place = FCTB.Selection.Start;
                string line = FCTB.Lines[place.iLine];
                
                if (line.Length == 0 || place.iChar == 0 || place.iLine == 0)
                {
                    return;
                }

                string upperLine = FCTB.Lines[place.iLine - 1];

                for (int i = 0; i < place.iChar; i++) //判断此行光标前是否全为空格
                {
                    if(i >= upperLine.Length || !(upperLine[i] == ' ' || upperLine[i] == '\t'))//若此行内容在上一行代码的右方，不自动全选
                    {
                        return;
                    }

                    if (line[i] != ' ' && line[i] != '\t')
                    {
                        return;
                    }
                }

                FCTB.Selection = new Range(FCTB, 0, place.iLine, place.iChar, place.iLine);
                e.Handled = true;
            }
        }

        #endregion

        #region 工具栏事件
        private void toolStripButton_NewCppFile_Click(object sender, EventArgs e)
        {
            cppFileToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton_OpenFile_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton_SaveFile_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton_Undo_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Undo();
        }

        private void toolStripButton_Redo_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Redo();
        }

        private void toolStripButton_Cut_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Cut();
        }

        private void toolStripButton_Copy_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Copy();
        }

        private void toolStripButton_Paste_Click(object sender, EventArgs e)
        {
            fastColoredTextBox_Main.Paste();
        }

        private void toolStripButton_Build_Click(object sender, EventArgs e)
        {
            buildToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton_Run_Click(object sender, EventArgs e)
        {
            runToolStripMenuItem_Click(null, null);
        }

        private void toolStripButton_BuildAndRun_Click(object sender, EventArgs e)
        {
            buildAndRunToolStripMenuItem_Click(null, null);
        }
        #endregion

    }
}
