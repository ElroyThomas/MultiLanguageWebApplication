using System;
using System.IO;
using System.Threading.Tasks;

namespace MultiLanguageWebApplication.Common.Logger
{
    public class Logger
    {
        public static async Task<bool> Error(Exception ex, string message = "")
        {
            string fileName = string.Empty, location = string.Empty;

            try
            {
                string exceptionMessage = string.Format("{0}Custom Message: {1}{0}Error Message: {2}{0}Stack Trace: {3}", Environment.NewLine, ex.Message, ex.Message, ex.StackTrace);
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Error");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                fileName = "log_Error_" + DateTime.Now.ToString("dd-MM-yyyy hh_mm_ss") + ".txt";

                location = Path.Combine(path, fileName);
                File.AppendAllText(location, exceptionMessage);

                return await Task.FromResult(true);
            }
            catch (Exception exp)
            {
                return await Task.FromResult(false);
            }
        }
        public static async Task<bool> LogToTextFile(string message = "")
        {
            string fileName = string.Empty, location = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    return await Task.FromResult(false);
                }

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Logs");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                fileName = "log_" + DateTime.Now.ToString("dd-MM-yyyy hh_mm_ss") + ".txt";

                location = Path.Combine(path, fileName);
                File.AppendAllText(location, message);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}