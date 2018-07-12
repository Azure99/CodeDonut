using CodeDonut.Judger;
using System.Diagnostics;
using System.IO;

namespace CodeDonut.Controller
{
    class MultipleJudgeController
    {
        public string ProgramPath { get; }
        public string InputPath { get; }
        public string OutPutPath { get; }
        public int TimeLimit { get; }
        public Process CurrentProcess { get; }
        

        private Judger.Judger _judger;
        private string[] _inputFiles;
        private string[] _outputFiles;
        private int _fileIndex;
        public MultipleJudgeController(string programPath, string inputPath, string outputPath, int timeLimit = 2000)
        {
            ProgramPath = programPath;
            InputPath = inputPath;
            OutPutPath = outputPath;
            TimeLimit = timeLimit;
            _fileIndex = 0;

            _judger = new Judger.Judger(programPath, timeLimit);

            _inputFiles = Directory.GetFiles(inputPath);
            _outputFiles = Directory.GetFiles(outputPath);
            _fileIndex = 0;
        }

        public bool HasNextCase()
        {
            return _fileIndex < _inputFiles.Length;
        }

        public JudgeResult JudgeNext()
        {
            if(_fileIndex >= _inputFiles.Length)
            {
                return new JudgeResult {  Result = ResultCode.JudgeFailed };
            }

            string inputPath = _inputFiles[_fileIndex++];
            string outputPath = "";
            string testCaseName = Path.GetFileNameWithoutExtension(inputPath);

            string outputPathProfix = Path.Combine(OutPutPath , testCaseName);
            foreach(string file in _outputFiles)
            {
                if(file.StartsWith(outputPathProfix))
                {
                    outputPath = file;
                    break;
                }
            }

            string input = "";
            string output = "";
            try
            {
                input = File.ReadAllText(inputPath);
                if(!string.IsNullOrEmpty(outputPath))
                {
                    output = File.ReadAllText(outputPath);
                }
            }
            catch
            {
                return new JudgeResult { TestCaseName = testCaseName, Result = ResultCode.JudgeFailed };
            }

            JudgeResult jr = _judger.Judge(input, output, testCaseName);

            if(jr.Result == ResultCode.OutPut)
            {
                File.WriteAllText(outputPathProfix + ".out", jr.OutPut);
            }

            return jr;
        }
    }
}
