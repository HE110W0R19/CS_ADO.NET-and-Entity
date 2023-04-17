namespace DBConnect_WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.getProviders_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectionString_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SQLRequest_TextBox = new System.Windows.Forms.TextBox();
            this.ExecRequest_Button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.InputPersName_TB = new System.Windows.Forms.TextBox();
            this.inputPersClass_TB = new System.Windows.Forms.TextBox();
            this.personNameLab = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(268, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // getProviders_Button
            // 
            this.getProviders_Button.Location = new System.Drawing.Point(614, 12);
            this.getProviders_Button.Name = "getProviders_Button";
            this.getProviders_Button.Size = new System.Drawing.Size(174, 23);
            this.getProviders_Button.TabIndex = 1;
            this.getProviders_Button.Text = "Get All Providers";
            this.getProviders_Button.UseVisualStyleBackColor = true;
            this.getProviders_Button.Click += new System.EventHandler(this.getProviders_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connection string";
            // 
            // ConnectionString_TextBox
            // 
            this.ConnectionString_TextBox.Location = new System.Drawing.Point(15, 63);
            this.ConnectionString_TextBox.Name = "ConnectionString_TextBox";
            this.ConnectionString_TextBox.ReadOnly = true;
            this.ConnectionString_TextBox.Size = new System.Drawing.Size(773, 22);
            this.ConnectionString_TextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "SQL request :";
            // 
            // SQLRequest_TextBox
            // 
            this.SQLRequest_TextBox.Location = new System.Drawing.Point(15, 130);
            this.SQLRequest_TextBox.Name = "SQLRequest_TextBox";
            this.SQLRequest_TextBox.Size = new System.Drawing.Size(593, 22);
            this.SQLRequest_TextBox.TabIndex = 5;
            // 
            // ExecRequest_Button
            // 
            this.ExecRequest_Button.Location = new System.Drawing.Point(614, 129);
            this.ExecRequest_Button.Name = "ExecRequest_Button";
            this.ExecRequest_Button.Size = new System.Drawing.Size(174, 23);
            this.ExecRequest_Button.TabIndex = 6;
            this.ExecRequest_Button.Text = "Execute Request";
            this.ExecRequest_Button.UseVisualStyleBackColor = true;
            this.ExecRequest_Button.Click += new System.EventHandler(this.ExecRequest_Button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(773, 279);
            this.dataGridView1.TabIndex = 7;
            // 
            // InputPersName_TB
            // 
            this.InputPersName_TB.Location = new System.Drawing.Point(871, 35);
            this.InputPersName_TB.Name = "InputPersName_TB";
            this.InputPersName_TB.Size = new System.Drawing.Size(166, 22);
            this.InputPersName_TB.TabIndex = 8;
            // 
            // inputPersClass_TB
            // 
            this.inputPersClass_TB.Location = new System.Drawing.Point(871, 63);
            this.inputPersClass_TB.Name = "inputPersClass_TB";
            this.inputPersClass_TB.Size = new System.Drawing.Size(166, 22);
            this.inputPersClass_TB.TabIndex = 9;
            // 
            // personNameLab
            // 
            this.personNameLab.AutoSize = true;
            this.personNameLab.Location = new System.Drawing.Point(818, 38);
            this.personNameLab.Name = "personNameLab";
            this.personNameLab.Size = new System.Drawing.Size(47, 16);
            this.personNameLab.TabIndex = 10;
            this.personNameLab.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(821, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Class:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(904, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Create Person";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(907, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CreatePersonButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.personNameLab);
            this.Controls.Add(this.inputPersClass_TB);
            this.Controls.Add(this.InputPersName_TB);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ExecRequest_Button);
            this.Controls.Add(this.SQLRequest_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConnectionString_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getProviders_Button);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button getProviders_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConnectionString_TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SQLRequest_TextBox;
        private System.Windows.Forms.Button ExecRequest_Button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox InputPersName_TB;
        private System.Windows.Forms.TextBox inputPersClass_TB;
        private System.Windows.Forms.Label personNameLab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

