using System.Diagnostics;
using System.Reflection;
using System.ServiceProcess;
using System.Windows.Forms;

namespace dllManager
{
    public partial class MainForm : Form
    {
        private string _ServerProdName = "";
        private string _ServerProdPath = "";
        private string _ServerTestname = "";
        private string _ServerTestPath = "";
        private string _ProdLocalPath = "";
        private string _TestLocalPath = "";
        private string _ServiceName = "";
        private string _srvWeb01 = "";
        private string _srvWeb02 = "";

        public Utils _utils = new Utils();
        public MainForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            _ServiceName = Environment.GetEnvironmentVariable("SERVICE_NAME") ?? "";
            _srvWeb01 = Environment.GetEnvironmentVariable("SRV_WEB_01") ?? "";
            _srvWeb02 = Environment.GetEnvironmentVariable("SRV_WEB_02") ?? "";
            _ServerProdName = Environment.GetEnvironmentVariable("SERVER_PROD_NAME") ?? "";
            _ServerTestname = Environment.GetEnvironmentVariable("SERVER_TEST_NAME") ?? "";
            _ServerProdPath = Environment.GetEnvironmentVariable("SERVER_PROD_PATH") ?? "";
            _ServerTestPath = Environment.GetEnvironmentVariable("SERVER_TEST_PATH") ?? "";
            _ProdLocalPath = Environment.GetEnvironmentVariable("PROD_LOCAL_PATH") ?? "";
            _TestLocalPath = Environment.GetEnvironmentVariable("TEST_LOCAL_PATH") ?? "";

            rbProd.Text = _ServerProdName;
            rbTest.Text = _ServerTestname;

        }


        private void button1_Click(object sender, EventArgs e)
        {

            string originpath = "";
            string newPath = "";
            string selectedServerPath = "";
            string selectedLocalPath = "";
            string selectedServerPathOriginal = "";
            string selectedLocalPathOriginal = "";
            bool webServiceReset = false;

            if (rbProd.Checked)
            {
                selectedServerPath = _ServerProdPath;
                selectedLocalPath = _ProdLocalPath;
                selectedServerPathOriginal = _ServerProdPath;
                selectedLocalPathOriginal = _ProdLocalPath;
            }
            else if (rbTest.Checked)
            {
                selectedServerPath = _ServerTestPath;
                selectedLocalPath = _TestLocalPath;
                selectedServerPathOriginal = _ServerTestPath;
                selectedLocalPathOriginal = _TestLocalPath;

            }

            List<CheckBox> allDlls = _utils.GetAllCheckBoxes(panelDll);

            try
            {
                foreach (CheckBox CheckBox in allDlls)
                {

                    if (CheckBox.Checked)
                    {

                        if (CheckBox.Text.Contains("Intercompany"))
                        {
                            if (CheckBox.Text == "PJ_Intercompany_SPFY.dll")
                            {
                                selectedServerPath = $"{selectedServerPath}\\PJ Intercompany SPFY\\BIN";
                            }
                            else if (CheckBox.Text == "PJ_Intercompany.dll")
                            {
                                selectedServerPath = $"{selectedServerPath}\\PJ Intercompany TRANSNATUR\\BIN";
                            }
                        }
                        else
                        {
                            selectedServerPath = selectedServerPathOriginal;
                        }

                        if (CheckBox.Text == "PJ_WEBSERVICE_ICCS.dll")
                        {
                            webServiceReset = true;
                        }



                        if (File.Exists($"{selectedLocalPath}/{CheckBox.Text}"))
                        {
                            if (File.Exists($"{selectedServerPath}/{CheckBox.Text}"))
                            {

                                originpath = $"{selectedServerPath}/{CheckBox.Text}";
                                newPath = $"{selectedServerPath}/{CheckBox.Text}_old";


                                if (_utils.GetTimeBetweenCreateDateAndNow(originpath) >= 5)
                                {
                                    DialogResult result = MessageBox.Show($"La dll {CheckBox.Text} no ha sido modificada en mas de 5 minutos. �est�s seguro que quieres copiarla al servidor?", "Confirmaci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.No)
                                    {
                                        continue;
                                    }

                                }


                                if (File.Exists(newPath))
                                {
                                    File.Delete(newPath);
                                }

                                File.Move(originpath, newPath);

                                originpath = $"{selectedLocalPath}/{CheckBox.Text}";
                                newPath = $"{selectedServerPath}/{CheckBox.Text}";
                                File.Copy(originpath, newPath);

                            }
                            else
                            {
                                MessageBox.Show($"No existe la ruta {selectedServerPath}/{CheckBox.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"No existe la ruta {selectedLocalPath}/{CheckBox.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                MessageBox.Show($"Proceso completado correctamente", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general {ex.ToString}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnResetSW_Click(object sender, EventArgs e)
        {
            string ret = "";

            if (rbTest.Checked)
            {

            }
            else if (rbProd.Checked)
            {
                ret = _utils.StopService(_ServiceName, _srvWeb01);

                if (!string.IsNullOrEmpty(ret))
                {
                    MessageBox.Show($"Error deteniendo el servicio {ret}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                ret = _utils.StopService(_ServiceName, _srvWeb02);

                if (!string.IsNullOrEmpty(ret))
                {
                    MessageBox.Show($"Error deteniendo el servicio {ret}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }

}