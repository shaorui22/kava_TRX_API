using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API
{
    public class LogHelper
    {
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logErr");
        private static readonly log4net.ILog logmonitor = log4net.LogManager.GetLogger("logmonitor");

        public static void Error(string ErrorMsg, Exception ex = null)
        {
            if (ex != null)
            {
                logerror.Error(ErrorMsg, ex);
            }
            else
            {
                logerror.Error(ErrorMsg);
            }
        }

        public static void Info(string Msg)
        {
            loginfo.Info(Msg);
        }

        public static void Monitor(string Msg)
        {
            logmonitor.Warn(Msg);
        }
    }
}