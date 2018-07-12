namespace CodeDonut.Judger
{
    public struct JudgeResult
    {
        public string TestCaseName { get; set; }
        public int TestCaseSize { get; set; }
        public int TimeCost { get; set; }
        public long MemoryCost { get; set; }

        public ResultCode Result { get; set; }
        public string JudgeDetail { get; set; }

        /// <summary>
        /// 若测试数据无输出，则以本次运行结果作为输出
        /// </summary>
        public string OutPut { get; set; }
    }
}
