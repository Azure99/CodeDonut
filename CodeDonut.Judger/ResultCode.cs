using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeDonut.Judger
{
    public enum ResultCode
    {
        JudgeFailed = -1,
        Accepted = 0,
        WrongAnswer = 1,
        RuntimeError = 2,
        TimeLimitExceeded = 3,
        OutPut = 4,
        //Interrupted = 5
    }
}
