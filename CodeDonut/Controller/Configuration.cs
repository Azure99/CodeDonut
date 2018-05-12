﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeDonut
{
    class Config
    {
        public static string Cpp_Compiler = @"MinGW64\bin\x86_64-w64-mingw32-g++.exe";//C++编译器位置
        public static string Cpp_Args = @"-Wall -o2 -std=c++11 -m32";//C++编译参数

        public static string C_Compiler = @"MinGW64\bin\x86_64-w64-mingw32-gcc.exe";//C编译器位置
        public static string C_Args = @"-Wall -o2 -m32";//C编译参数

        public static string Cpp_AutoComplete = CodeDonut.Properties.Resources.Cpp_AutoComplete;//C++代码补全数据
        public static string Cpp_HighLighting = CodeDonut.Properties.Resources.Cpp_HighLighting;//C++代码高亮数据
        public static string C_AutoComplete = CodeDonut.Properties.Resources.C_AutoComplete;//C代码补全数据
        public static string C_HighLighting = CodeDonut.Properties.Resources.C_HighLighting;//C代码高亮数据

        public static string MainFormWidth = "800";
        public static string MainFormHeight = "600";
        public static string MainFormMax = "0";

        public static string EnableChineseInput = "0";

        public static void LoadConfig()
        {
            Cpp_Compiler = INIOperation.ReadValue("config.ini", "Compile", "Cpp_Compiler", Cpp_Compiler);
            Cpp_Args = INIOperation.ReadValue("config.ini", "Compile", "Cpp_CompileArgs", Cpp_Args);
            C_Compiler = INIOperation.ReadValue("config.ini", "Compile", "C_Compiler", C_Compiler);
            C_Args = INIOperation.ReadValue("config.ini", "Compile", "C_CompileArgs", C_Args);
            MainFormWidth = INIOperation.ReadValue("config.ini", "Status", "Width", MainFormWidth);
            MainFormHeight = INIOperation.ReadValue("config.ini", "Status", "Height", MainFormHeight);
            MainFormMax = INIOperation.ReadValue("config.ini", "Status", "FormMax", MainFormMax);
            EnableChineseInput = INIOperation.ReadValue("config.ini", "Editor", "EnableChineseInput", EnableChineseInput);
            string folder = AppDomain.CurrentDomain.BaseDirectory;

            //补全与高亮
            if (File.Exists(folder + "Cpp_AutoComplete.dat"))
            {
                Cpp_AutoComplete = IOHelper.ReadAllTextWithDfEncode(folder + "Cpp_AutoComplete.dat");
            }
            else
            {
                IOHelper.WriteAllTextWithDfEncode(folder + "Cpp_AutoComplete.dat", Cpp_AutoComplete);
            }

            if (File.Exists(folder + "Cpp_HighLighting.dat"))
            {
                Cpp_HighLighting = IOHelper.ReadAllTextWithDfEncode(folder + "Cpp_HighLighting.dat");
            }
            else
            {
                IOHelper.WriteAllTextWithDfEncode(folder + "Cpp_Highlighting.dat", Cpp_HighLighting);
            }

            if (File.Exists(folder + "C_AutoComplete.dat"))
            {
                C_AutoComplete = IOHelper.ReadAllTextWithDfEncode(folder + "C_AutoComplete.dat");
            }
            else
            {
                IOHelper.WriteAllTextWithDfEncode(folder + "C_AutoComplete.dat", C_AutoComplete);
            }

            if (File.Exists(folder + "C_HighLighting.dat"))
            {
                C_HighLighting = IOHelper.ReadAllTextWithDfEncode(folder + "C_HighLighting.dat");
            }
            else
            {
                IOHelper.WriteAllTextWithDfEncode(folder + "C_Highlighting.dat", C_HighLighting);
            }
        }

        public static void SaveConfig()
        {
            INIOperation.WriteValue("config.ini", "Compile", "Cpp_Compiler", Cpp_Compiler);
            INIOperation.WriteValue("config.ini", "Compile", "Cpp_CompileArgs", Cpp_Args);
            INIOperation.WriteValue("config.ini", "Compile", "C_Compiler", C_Compiler);
            INIOperation.WriteValue("config.ini", "Compile", "C_CompileArgs", C_Args);
            INIOperation.WriteValue("config.ini", "Status", "Width", MainFormWidth);
            INIOperation.WriteValue("config.ini", "Status", "Height", MainFormHeight);
            INIOperation.WriteValue("config.ini", "Status", "FormMax", MainFormMax);
            INIOperation.WriteValue("config.ini", "Editor", "EnableChineseInput", EnableChineseInput);
        }
    }
}