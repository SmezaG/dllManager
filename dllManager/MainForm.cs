using DotNetEnv;

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
        private string _TestServiceName = "";
        private string _TestServicepath = "";
        private string _WebTest = "";
        private CancellationTokenSource cancellationTokenSource;

        public Utils _utils = new Utils();

        public MainForm()
        {
            this.Icon = new Icon("Recursos/sergi.logo.ico");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Cargamos las variables de entorno
            Env.Load();

            _ServiceName = Environment.GetEnvironmentVariable("SERVICE_NAME") ?? "";
            _srvWeb01 = Environment.GetEnvironmentVariable("SRV_WEB_01") ?? "";
            _srvWeb02 = Environment.GetEnvironmentVariable("SRV_WEB_02") ?? "";
            _ServerProdName = Environment.GetEnvironmentVariable("SERVER_PROD_NAME") ?? "";
            _ServerTestname = Environment.GetEnvironmentVariable("SERVER_TEST_NAME") ?? "";
            _ServerProdPath = Environment.GetEnvironmentVariable("SERVER_PROD_PATH") ?? "";
            _ServerTestPath = Environment.GetEnvironmentVariable("SERVER_TEST_PATH") ?? "";
            _ProdLocalPath = Environment.GetEnvironmentVariable("PROD_LOCAL_PATH") ?? "";
            _TestLocalPath = Environment.GetEnvironmentVariable("TEST_LOCAL_PATH") ?? "";
            _TestServiceName = Environment.GetEnvironmentVariable("TEST_SERVICE_NAME") ?? "";
            _TestServicepath = Environment.GetEnvironmentVariable("TEST_SERVICE_PATH") ?? "";
            _WebTest = Environment.GetEnvironmentVariable("WEBTEST") ?? "";

            rbProd.Text = _ServerProdName;
            rbTest.Text = _ServerTestname;

            // Preparamos el proceso asincrono de monitorización de Servicios
            cancellationTokenSource = new CancellationTokenSource();
            _utils.VerificarEstado(_ServiceName, "srvweb01");

            lbWeb01.Text = $"Web01 - {_ServiceName} - Estado: ";
            lbWeb02.Text = $"Web02 - {_ServiceName} - Estado: ";
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

                                if (_utils.GetTimeBetweenCreateDateAndNow($"{selectedLocalPath}/{CheckBox.Text}") >= 5)
                                {
                                    DialogResult result = MessageBox.Show($"La dll {CheckBox.Text} no ha sido modificada en mas de 5 minutos. ¿estás seguro que quieres copiarla al servidor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.No)
                                    {
                                        if (CheckBox.Text == "PJ_WEBSERVICE_ICCS.dll")
                                        {
                                            webServiceReset = false;
                                        }
                                        continue;
                                    }
                                }

                                if (File.Exists(newPath))
                                {
                                    //Intentamos borrar el old (Para poder sobreescribirlo con nuestro old) en el caso de que falle por estar siendo usado
                                    //Se le renobra con GUID
                                    try
                                    {
                                        File.Delete(newPath);
                                    }
                                    catch (UnauthorizedAccessException ex)
                                    {
                                        File.Move(newPath, string.Concat(newPath, Guid.NewGuid()));
                                    }
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

                if (webServiceReset)
                {
                    string question = "";
                    if (rbTest.Checked)
                    {
                        question = "el servicio web de test";
                    }
                    else if (rbProd.Checked)
                    {
                        question = "los srvweb 01 y 02";
                    }

                    DialogResult result = MessageBox.Show($"Se ha copiado la dll PJ_WEBSERVICE_ICCS.dll, ¿Quieres reiniciar {question}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (rbTest.Checked)
                        {
                        }
                        else if (rbProd.Checked)
                        {
                            _utils.ResetProductionServices(_ServerProdName, _srvWeb01, _srvWeb02);
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
            if (rbTest.Checked)
            {
                //_utils.ResetTestServices(_TestServiceName, _WebTest, _TestServicepath, _AutoltScriptPath);
                MessageBox.Show($"Por ahora no tenemos implementada esta función para {_ServerTestname}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rbProd.Checked)
            {
                _utils.ResetProductionServices(_ServiceName, _srvWeb01, _srvWeb02);

                _utils.MonitorStateAsync(cancellationTokenSource.Token);

            }
        }
    }
}