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
            label2 = new Label();
            panelDll.SuspendLayout();
            SuspendLayout();
            // 
            // btnCopiar
            // 
            btnCopiar.Location = new Point(14, 335);
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
            rbProd.Location = new Point(94, 33);
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
            rbTest.Location = new Point(14, 33);
            rbTest.Name = "rbTest";
            rbTest.Size = new Size(51, 19);
            rbTest.TabIndex = 2;
            rbTest.TabStop = true;
            rbTest.Text = "TEST";
            rbTest.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(14, 92);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(110, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "PJ_SISTEMAS.dll";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(14, 117);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(87, 19);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "PJ_UTILS.dll";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(14, 142);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(141, 19);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "PanamaJack_SGILayer";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(14, 167);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(154, 19);
            checkBox4.TabIndex = 7;
            checkBox4.Text = "Tareas_Programadas.exe";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(14, 192);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(171, 19);
            checkBox5.TabIndex = 8;
            checkBox5.Text = "PanamaJack_PluginPack.dll";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(14, 217);
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
            panelDll.Controls.Add(rbProd);
            panelDll.Controls.Add(checkBox9);
            panelDll.Controls.Add(rbTest);
            panelDll.Controls.Add(checkBox8);
            panelDll.Controls.Add(checkBox7);
            panelDll.Controls.Add(label2);
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
            label1.Location = new Point(14, 55);
            label1.Name = "label1";
            label1.Size = new Size(192, 15);
            label1.TabIndex = 19;
            label1.Text = "_____________________________________";
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(14, 293);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(131, 19);
            checkBox9.TabIndex = 12;
            checkBox9.Text = "PJ_Intercompany.dll";
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(14, 268);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(162, 19);
            checkBox8.TabIndex = 11;
            checkBox8.Text = "PJ_Intercompany_SPFY.dll";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(14, 243);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(78, 19);
            checkBox7.TabIndex = 10;
            checkBox7.Text = "PJ_PIM.dll";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 6);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 14;
            label2.Text = "Servidor";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelDll);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrador de dlls";
            Load += Form1_Load;
            panelDll.ResumeLayout(false);
            panelDll.PerformLayout();
            ResumeLayout(false);
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
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private Label label2;
        private Label label1;
    }
}