using System.IO;
using System.Windows.Forms;
using CodeDonut.Compiler;
using CodeDonut.Controller;

namespace CodeDonut.Code
{
    static class Compile
    {
        public static bool CompileFile(string sourceFile)//编译源文件
        {
            MainForm.FormCompileErrorInfo.Visible = false;//隐藏编译信息窗口

            ICompiler compiler = CreateCompiler(sourceFile);
            CompileResult compileResult = compiler.Compile(sourceFile);

            if (compileResult.ResultCode == CompileResultCode.Successful)
            {
                MessageBox.Show(I18N.GetValue("Compile successful"), "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (compileResult.ResultCode == CompileResultCode.UnknownError)
            {
                MessageBox.Show(I18N.GetValue(compileResult.Message), I18N.GetValue("Compile Failed"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                MainForm.FormCompileErrorInfo.ClearErrorInfo();


                foreach(CompileErrorInfo info in compileResult.CompileErrorInfos)
                {
                    MainForm.FormCompileErrorInfo.AddErrorInfo(info);
                }

                MainForm.FormCompileErrorInfo.Text = I18N.GetValue("Compile Information ") + 
                    compileResult.ErrorCount.ToString() + 
                    I18N.GetValue("-Error ") +
                    compileResult.WarningCount.ToString() + 
                    I18N.GetValue("-Warning ") + 
                    compileResult.NoteCount.ToString() + 
                    I18N.GetValue("-note");

                MainForm.FormCompileErrorInfo.AdjustFormPosition();
                MainForm.FormCompileErrorInfo.Visible = true;
                MainForm.FormCompileErrorInfo.Focus();
            }
            
            return compileResult.ResultCode == CompileResultCode.Successful;
        }

        private static ICompiler CreateCompiler(string sourceFile)
        {
            bool isCppFile = Path.GetExtension(sourceFile) != "c";
            string compiler = Config.C_Compiler;//C
            string args = Config.C_Args;

            if (isCppFile)//C++
            {
                compiler = Config.Cpp_Compiler;
                args = Config.Cpp_Args;
            }

            return new GccCompiler(compiler, args);
        }
    }
}
