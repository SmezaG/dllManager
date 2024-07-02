﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public string StopService(string serviceName, string remoteServer, bool produccion, string exepath)
        {

            string err = "";
            string servicio = "";

            if (string.IsNullOrEmpty(serviceName) || string.IsNullOrEmpty(remoteServer))
            {
                err = "Error: Las variables de entorno SERVICE_NAME o SRV_WEB_0X no están configuradas.";
                return err;
            }

            if (produccion)
            {
                servicio = "dllManager.Scripts.servicestop.bat";
            }
            else
            {
                servicio = "dllManager.Scripts.serviceteststop.bat";
            }

            err = ExecuteEmbeddedBatFile(servicio, serviceName, remoteServer, produccion, exepath);

            return err;
        }

        static string ExecuteEmbeddedBatFile(string resourceName, string serviceName, string remoteServer, bool produccion, string exepath)
        {
            string resourcenameSubstring = resourceName;
            var assembly = Assembly.GetExecutingAssembly();
            string tempBatPath = Path.Combine(Path.GetTempPath(), resourcenameSubstring.Replace("dllManager.Scripts.",""));

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
               
                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardError = true;
                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;
                if (produccion)
                {
                    processInfo.Arguments = $"\"{serviceName}\" \"{remoteServer}\"";
                }
                else
                {
                    processInfo.Arguments = $"\"{serviceName}\" \"{exepath}\" \"{remoteServer}\"";
                }

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

        public void ResetProductionServices(string servicename, string web01, string web02)
        {
            string err = "";

            err = StopService(servicename, web01,true,"");

            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show($"Error deteniendo el servicio {err}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            err = StopService(servicename, web02, true, "");

            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show($"Error deteniendo el servicio {err}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void ResetTestServices(string servicename,string webtest, string exepath)
        {
            string err = "";
            err = StopService(servicename, webtest, false, exepath);
        }


    }
}
