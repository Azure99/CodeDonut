using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CodeDonut.Judger
{
    public class Test
    {
        public static void Main()
        {
            Judger judger = new Judger(@"D:\Program Files (x86)\CodeDonut_Beta0.05\SourceFile\unnamed8.cpp.exe", 2000);

            JudgeResult res = judger.Judge(
                File.ReadAllText(@"C:\Users\96152\Downloads\Compressed\1235\input\E6ther3.in"), 
                File.ReadAllText(@"C: \Users\96152\Downloads\Compressed\1235\output\E6ther3.out"), 
                "e6ther");

            Console.WriteLine("time:" + res.TimeCost);
            Console.WriteLine("mem:" + res.MemoryCost);

            Console.WriteLine("res:" + res.Result);
            Console.WriteLine("size:" + res.TestCaseSize);

;           Console.ReadKey();
        }
    }
}
