using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeDonut.Compiler
{

    public enum CompileResultCode
    {
        Successful,
        Failed,
        UnknownError
    }

    public class CompileResult
    {
        public CompileResultCode ResultCode { get; }
        public string Message { get; }
        public int ErrorCount { get; }
        public int WarningCount { get; }
        public int NoteCount { get; }
        public CompileErrorInfo[] CompileErrorInfos { get; }


        public CompileResult(CompileResultCode resultCode, 
            string message = "", 
            int errorCount = 0, int warningCount = 0, int noteCount = 0, 
            CompileErrorInfo[] errorInfo = null)
        {
            ResultCode = resultCode;
            Message = message;
            ErrorCount = errorCount;
            WarningCount = warningCount;
            NoteCount = noteCount;
            CompileErrorInfos = errorInfo ?? new CompileErrorInfo[0];
        }
    }
}
