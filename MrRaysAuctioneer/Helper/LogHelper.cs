using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Helper
{
    public static class LogHelper
    {
        public static void Error(Exception ex)
        {
            var filePath = FileHelper.GetTempPath("Log.txt");

            File.AppendAllText(filePath, DateTime.Now.ToString() + Environment.NewLine);
            File.AppendAllText(filePath, ex.Message + Environment.NewLine);
            File.AppendAllText(filePath, ex.StackTrace + Environment.NewLine);
        }
        
    }
}
