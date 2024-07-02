using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dllManager
{
    public class Utils
    {

        public List<CheckBox> GetAllCheckBoxes(Control control)
        {
            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (Control c in control.Controls)
            {
                if (c is CheckBox checkBox)
                {
                    checkBoxes.Add(checkBox);
                }
                else if (c.HasChildren)
                {
                    checkBoxes.AddRange(GetAllCheckBoxes(c));
                }
            }
            return checkBoxes;
        }

        public string StopService(string serviceName, string remoteServer)
        {

            string err = "";

            if (string.IsNullOrEmpty(serviceName) || string.IsNullOrEmpty(remoteServer))
            {
                err = "Error: Las variables de entorno SERVICE_NAME o SRV_WEB_0X no están configuradas.";
                return err;
            }

            err = ExecuteEmbeddedBatFile("dllManager.Scripts.servicestop.bat", serviceName, remoteServer);

            return err;
        }

        static string ExecuteEmbeddedBatFile(string resourceName, string serviceName, string remoteServer)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string tempBatPath = Path.Combine(Path.GetTempPath(), "servicestop.bat");

            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        throw new Exception($"Resource {resourceName} not found.");
                    }

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        File.WriteAllText(tempBatPath, reader.ReadToEnd());
                    }
                }

                var processInfo = new ProcessStartInfo();
                processInfo.FileName = tempBatPath;
                processInfo.Arguments = $"\"{serviceName}\" \"{remoteServer}\"";
                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardError = true;
                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;

                using (Process process = Process.Start(processInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(errors) || output.Contains("Error: "))
                    {
                        if (string.IsNullOrEmpty(errors))
                        {
                            return output;
                        }
                        else
                        {
                            return $"Errores: {errors}";
                        }

                    }
                    return "";

                }
               
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                if (File.Exists(tempBatPath))
                {
                    File.Delete(tempBatPath);
                }
            }

        }

        public int GetTimeBetweenCreateDateAndNow(string file)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(file);
            DateTime currentTime = DateTime.Now;
            TimeSpan timeDifference = currentTime - lastWriteTime;
            return (int)timeDifference.TotalMinutes;
        }


    }
}
