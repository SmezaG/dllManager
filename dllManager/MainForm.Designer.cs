namespace dllManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCopiar = new Button();
            rbProd = new RadioButton();
            rbTest = new RadioButton();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            panelDll = new Panel();
            label1 = new Label();
            checkBox9 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox7 = new CheckBox();
            panel1 = new Panel();
            label2 = new Label();
            btnResetSW = new Button();
            panel2 = new Panel();
            lbWeb02 = new Label();
            lbWeb01 = new Label();
            label3 = new Label();
            panelDll.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnCopiar
            // 
            btnCopiar.Location = new Point(14, 289);
            btnCopiar.Name = "btnCopiar";
            btnCopiar.Size = new Size(122, 70);
            btnCopiar.TabIndex = 0;
            btnCopiar.Text = "Copiar Librerías";
            btnCopiar.UseVisualStyleBackColor = true;
            btnCopiar.Click += button1_Click;
            // 
            // rbProd
            // 
            rbProd.AutoSize = true;
            rbProd.Location = new Point(107, 12);
            rbProd.Name = "rbProd";
            rbProd.Size = new Size(101, 19);
            rbProd.TabIndex = 1;
            rbProd.Text = "PRODUCCION";
            rbProd.UseVisualStyleBackColor = true;
            // 
            // rbTest
            // 
            rbTest.AutoSize = true;
            rbTest.Checked = true;
            rbTest.Location = new Point(27, 12);
            rbTest.Name = "rbTest";
            rbTest.Size = new Size(49, 19);
            rbTest.TabIndex = 2;
            rbTest.TabStop = true;
            rbTest.Text = "TEST";
            rbTest.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(14, 42);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(109, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "PJ_SISTEMAS.dll";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(14, 67);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(86, 19);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "PJ_UTILS.dll";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(14, 92);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(154, 19);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "PJ_WEBSERVICE_ICCS.dll";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(14, 117);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(154, 19);
            checkBox4.TabIndex = 7;
            checkBox4.Text = "Tareas_Programadas.exe";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(14, 142);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(171, 19);
            checkBox5.TabIndex = 8;
            checkBox5.Text = "PanamaJack_PluginPack.dll";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(14, 167);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(111, 19);
            checkBox6.TabIndex = 9;
            checkBox6.Text = "GS_PANAMA.dll";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // panelDll
            // 
            panelDll.BorderStyle = BorderStyle.FixedSingle;
            panelDll.Controls.Add(label1);
            panelDll.Controls.Add(checkBox9);
            panelDll.Controls.Add(checkBox8);
            panelDll.Controls.Add(checkBox7);
            panelDll.Controls.Add(btnCopiar);
            panelDll.Controls.Add(checkBox4);
            panelDll.Controls.Add(checkBox6);
            panelDll.Controls.Add(checkBox1);
            panelDll.Controls.Add(checkBox5);
            panelDll.Controls.Add(checkBox2);
            panelDll.Controls.Add(checkBox3);
            panelDll.Location = new Point(21, 12);
            panelDll.Name = "panelDll";
            panelDll.Size = new Size(231, 426);
            panelDll.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 17);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 13;
            label1.Text = "Librerías";
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(14, 243);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(131, 19);
            checkBox9.TabIndex = 12;
            checkBox9.Text = "PJ_Intercompany.dll";
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(14, 218);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(162, 19);
            checkBox8.TabIndex = 11;
            checkBox8.Text = "PJ_Intercompany_SPFY.dll";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(14, 193);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(78, 19);
            checkBox7.TabIndex = 10;
            checkBox7.Text = "PJ_PIM.dll";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(rbProd);
            panel1.Controls.Add(rbTest);
            panel1.Location = new Point(519, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(257, 45);
            panel1.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(519, 10);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 14;
            label2.Text = "Servidor";
            // 
            // btnResetSW
            // 
            btnResetSW.Location = new Point(519, 105);
            btnResetSW.Name = "btnResetSW";
            btnResetSW.Size = new Size(122, 70);
            btnResetSW.TabIndex = 15;
            btnResetSW.Text = "Reiniciar Servicios Web";
            btnResetSW.UseVisualStyleBackColor = true;
            btnResetSW.Click += btnResetSW_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lbWeb02);
            panel2.Controls.Add(lbWeb01);
            panel2.Location = new Point(291, 322);
            panel2.Name = "panel2";
            panel2.Size = new Size(485, 100);
            panel2.TabIndex = 16;
            // 
            // lbWeb02
            // 
            lbWeb02.AutoSize = true;
            lbWeb02.Location = new Point(12, 58);
            lbWeb02.Name = "lbWeb02";
            lbWeb02.Size = new Size(43, 15);
            lbWeb02.TabIndex = 19;
            lbWeb02.Text = "Web02";
            // 
            // lbWeb01
            // 
            lbWeb01.AutoSize = true;
            lbWeb01.Location = new Point(12, 24);
            lbWeb01.Name = "lbWeb01";
            lbWeb01.Size = new Size(43, 15);
            lbWeb01.TabIndex = 18;
            lbWeb01.Text = "Web01";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(291, 302);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 17;
            label3.Text = "Estado de los servicios";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(btnResetSW);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(panelDll);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrador de dlls";
            Load += Form1_Load;
            panelDll.ResumeLayout(false);
            panelDll.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCopiar;
        private RadioButton rbProd;
        private RadioButton rbTest;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private Panel panelDll;
        private Label label1;
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private Panel panel1;
        private Label label2;
        private Button btnResetSW;
        private Panel panel2;
        private Label lbWeb02;
        private Label lbWeb01;
        private Label label3;
    }
}