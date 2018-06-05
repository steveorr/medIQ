using Med_IQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Med_IQ.Controllers
{
    public static class ErrorLog_Helper
    {
        public static void LogError(Exception error)
        {
            Error_LogController errL = new Error_LogController();
            Error_Log err = new Error_Log();

            err.ErrorMsg = error.Message;
            err.ErrorDate = DateTime.Now;
            err.StackTrace = error.StackTrace;

            errL.PostError_Log(err);
        }

        public static void LogError(string msg, string stackTrace)
        {
            Error_LogController errL = new Error_LogController();
            Error_Log err = new Error_Log();

            err.ErrorMsg = msg;
            err.ErrorDate = DateTime.Now;
            err.StackTrace = stackTrace;

            errL.PostError_Log(err);
        }

    }
}