using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CodeDonut.Compiler
{
    public class CompileErrorInfo
    {
        public int Line { get; }
        public string Info { get; }
        public Color InfoColor { get; }
        public CompileErrorInfo(int line, string info, Color infoColor)
        {
            Line = line;
            Info = info;
            InfoColor = infoColor;
        }
    }
}
