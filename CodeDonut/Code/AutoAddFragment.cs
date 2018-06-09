using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastColoredTextBoxNS;

namespace CodeDonut
{
    static class AutoAddFragment
    {
        /*插入碎片的标志，用于inserting与inserted事件中传递消息，
         * 避免在inserting继续插入碎片导致再次触发inserting事件导致无限递归而爆栈
         */
        enum InsertFlag
        {
            No,
            DoubleQuotationMarks,
            InsertingDoubleQuotationMarks,
            Obrace,
            LeftSquareBracket,
            LeftBracket,
            Enter,
            AfterEnter,
            AutoInsertBlank,
            InsertingBlank
        }

        private static FastColoredTextBox _fctb;
        private static InsertFlag _insertingFlag = InsertFlag.No;
        public static void Init(FastColoredTextBox fctb)
        {
            _fctb = fctb;
            _fctb.TextChanged += new EventHandler<TextChangedEventArgs>(OnTextChanged);
            _fctb.TextChanging += new EventHandler<TextChangingEventArgs>(OnTextChanging);
        }
        public static void OnTextChanging(object sender, TextChangingEventArgs e)
        {

            if (e.InsertingText == "\"" && _insertingFlag == InsertFlag.No)
            {
                Range range = _fctb.Selection;
                if (range.Length == 0 && range.CharBeforeStart == '\"' && range.CharAfterStart == '\"')
                {
                    Place place = range.Start;
                    place.iChar++;
                    _fctb.Selection.Start = place;
                    e.Cancel = true;
                }
                else
                {
                    _insertingFlag = InsertFlag.DoubleQuotationMarks;
                }
            }

            else if (e.InsertingText == "{")
            {
                _insertingFlag = InsertFlag.Obrace;
            }

            else if (e.InsertingText == "}")
            {
                Range range = _fctb.Selection;
                if (range.Length == 0)
                {
                    if (range.CharBeforeStart == '{')
                    {
                        if (range.CharAfterStart == '}')
                        {
                            Place place = range.Start;
                            place.iChar++;
                            _fctb.Selection.Start = place;
                            e.Cancel = true;
                        }
                    }
                }
            }

            else if (e.InsertingText == "[")
            {
                _insertingFlag = InsertFlag.LeftSquareBracket;
            }

            else if (e.InsertingText == "]")
            {
                Range range = _fctb.Selection;
                if (range.Length == 0)
                {
                    if (range.CharBeforeStart == '[')
                    {
                        if (range.CharAfterStart == ']')
                        {
                            Place place = range.Start;
                            place.iChar++;
                            _fctb.Selection.Start = place;
                            e.Cancel = true;
                        }
                    }
                }
            }

            else if (e.InsertingText == "(")
            {
                _insertingFlag = InsertFlag.LeftBracket;
            }

            else if (e.InsertingText == ")")
            {
                Range range = _fctb.Selection;
                if (range.Length == 0)
                {
                    if (range.CharBeforeStart == '(')
                    {
                        if (range.CharAfterStart == ')')
                        {
                            Place place = range.Start;
                            place.iChar++;
                            _fctb.Selection.Start = place;
                            e.Cancel = true;
                        }
                    }
                }
            }

            else if (e.InsertingText == "\n")
            {
                if (_insertingFlag == InsertFlag.No)
                {
                    Range range = _fctb.Selection;
                    if (range.CharBeforeStart == '{')
                    {
                        if (range.CharAfterStart == '}')
                        {
                            _insertingFlag = InsertFlag.Enter;

                            Place place = _fctb.Selection.Start;
                            _fctb.InsertText("\n");
                            _fctb.Selection.Start = place;

                            place = _fctb.Selection.Start;

                            _insertingFlag = InsertFlag.AfterEnter;
                        }
                    }
                }
            }
        }

        public static void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_insertingFlag == InsertFlag.No)
            {
                return;
            }
            else if(_insertingFlag == InsertFlag.DoubleQuotationMarks)
            {
                _insertingFlag = InsertFlag.InsertingDoubleQuotationMarks;
                _fctb.InsertText("\"");
                Place place = _fctb.Selection.Start;
                place.iChar--;
                _fctb.Selection.Start = place;
                _insertingFlag = InsertFlag.No;
            }
            else if (_insertingFlag == InsertFlag.Obrace)
            {
                _insertingFlag = InsertFlag.No;
                _fctb.InsertText("}");
                Place place = _fctb.Selection.Start;
                place.iChar--;
                _fctb.Selection.Start = place;
            }
            else if (_insertingFlag == InsertFlag.LeftSquareBracket)
            {
                _insertingFlag = InsertFlag.No;
                _fctb.InsertText("]");
                Place place = _fctb.Selection.Start;
                place.iChar--;
                _fctb.Selection.Start = place;
            }
            else if (_insertingFlag == InsertFlag.LeftBracket)
            {
                _insertingFlag = InsertFlag.No;
                _fctb.InsertText(")");
                Place place = _fctb.Selection.Start;
                place.iChar--;
                _fctb.Selection.Start = place;
            }
            else if (_insertingFlag == InsertFlag.AfterEnter)//等待FCTB插入空格，之后触发下一个事件
            {
                _insertingFlag = InsertFlag.AutoInsertBlank;
            }
            else if (_insertingFlag == InsertFlag.AutoInsertBlank)
            {
                _insertingFlag = InsertFlag.InsertingBlank;

                Place place = _fctb.Selection.Start;
                int blankCnt = Math.Max(0, place.iChar - 4);//判断上一行的空格数

                Place nextPlace = _fctb.Selection.Start;
                nextPlace.iLine++;
                nextPlace.iChar = 0;

                _fctb.Selection.Start = nextPlace;
                _fctb.InsertText(new string(' ', blankCnt));

                _fctb.Selection.Start = place;

                _insertingFlag = InsertFlag.No;
            }
        }
    }
}
