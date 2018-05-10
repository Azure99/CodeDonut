using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace CodeDonut
{
    class HighlightingCode
    {
        //高亮风格
        private static readonly Style BlueBoldStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        private static readonly Style BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        private static readonly Style BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        private static readonly Style BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        private static readonly Style GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        private static readonly Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        private static readonly Style MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        private static readonly Style MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        private static readonly Style RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        private static readonly Style BlackStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);

        private static readonly MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(60, Color.Gray)));
        //高亮规则
        private static string className = "";
        private static string keyWords = "";
        private static string functions = "";
        private static string stl = "";
        private static string stlMethods = "";
        private static string preprocessingCommand = "";
        private static string header = "";

        /// <summary>
        /// 初始化代码高亮
        /// </summary>
        /// <param name="highlightingRules">高亮规则</param>
        public static void InitHighlightingCode(string highlightingRules)
        {
            string[] rulesArr = Regex.Split(highlightingRules, "\r\n|\r|\n");
            foreach(string rule in rulesArr)
            {
                if(rule.StartsWith("#") || String.IsNullOrEmpty(rule))
                {
                    continue;
                }

                if (rule.StartsWith("ClassName==="))
                {
                    className = rule.Substring("ClassName===".Length, rule.Length - "ClassName===".Length);
                }
                else if (rule.StartsWith("Keyword==="))
                {
                    keyWords = rule.Substring("Keyword===".Length, rule.Length - "Keyword===".Length);
                }
                else if (rule.StartsWith("Function==="))
                {
                    functions = rule.Substring("Function===".Length, rule.Length - "Function===".Length);
                }
                else if (rule.StartsWith("STL==="))
                {
                    stl = rule.Substring("STL===".Length, rule.Length - "STL===".Length);
                }
                else if (rule.StartsWith("STLmethods==="))
                {
                    stlMethods = rule.Substring("STLmethods===".Length, rule.Length - "STLmethods===".Length);
                }
                else if (rule.StartsWith("PreprocessingCommand==="))
                {
                    preprocessingCommand = rule.Substring("PreprocessingCommand===".Length, rule.Length - "PreprocessingCommand===".Length);
                }
                else if (rule.StartsWith("Header==="))
                {
                    header = rule.Substring("Header===".Length, rule.Length - "Header===".Length);
                }

            }
        }
        /// <summary>
        /// 代码高亮
        /// </summary>
        /// <param name="e">TextChangedEventArgs</param>
        public static void Highlighting(FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle);

            //[] and {}
            e.ChangedRange.SetStyle(RedStyle, @"(\[|\])", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(MagentaStyle, @"({|})", RegexOptions.Singleline);


            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");

            //Class name 
            e.ChangedRange.SetStyle(BoldStyle, className);
            //Keyword 
            e.ChangedRange.SetStyle(BlueStyle, keyWords);
            //Functions
            e.ChangedRange.SetStyle(GreenStyle, functions);
            //STL
            e.ChangedRange.SetStyle(GreenStyle, stl);
            //STL-Methods
            e.ChangedRange.SetStyle(GreenStyle, stlMethods);
            //Preprocessing command 
            e.ChangedRange.SetStyle(MagentaStyle, preprocessingCommand, RegexOptions.Singleline);
            //Header
            e.ChangedRange.SetStyle(GreenStyle, header, RegexOptions.Singleline);
            //Pointer 
            e.ChangedRange.SetStyle(MagentaStyle, @"\*", RegexOptions.Singleline);
            e.ChangedRange.ClearFoldingMarkers();

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block

        }

        public static void HighlightingSameWords(FastColoredTextBox fctb)
        {
            fctb.VisibleRange.ClearStyle(SameWordsStyle);
            if (!fctb.Selection.IsEmpty)
                return;//user selected diapason

            //get fragment around caret
            var fragment = fctb.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            var ranges = fctb.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();
            if (ranges.Length > 1)
                foreach (var r in ranges)
                    r.SetStyle(SameWordsStyle);
        }
    }
}
