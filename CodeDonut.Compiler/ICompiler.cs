using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeDonut.Compiler
{
    public interface ICompiler
    {
        string CompilerPath { get; }
        string CompileArgs { get; set; }
        CompileResult Compile(string sourceFile);
    }
}
