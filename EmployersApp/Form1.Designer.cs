namespace EmployersApp
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthYearColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalaryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.getReportBtn = new System.Windows.Forms.Button();
            this.deleteEmployerBtn = new System.Windows.Forms.Button();
            this.addEmployerBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.salaryBox = new System.Windows.Forms.TextBox();
            this.birthYearBox = new System.Windows.Forms.TextBox();
            this.postBox = new System.Windows.Forms.TextBox();
            this.surnameBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.SurnameColumn,
            this.PostColumn,
            this.BirthYearColumn,
            this.SalaryColumn});
            this.dataGridView1.Location = new System.Drawing.Point(13, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(904, 316);
            this.dataGridView1.TabIndex = 0;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Имя";
            this.NameColumn.MinimumWidth = 6;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 125;
            // 
            // SurnameColumn
            // 
            this.SurnameColumn.HeaderText = "Фамилия";
            this.SurnameColumn.MinimumWidth = 6;
            this.SurnameColumn.Name = "SurnameColumn";
            this.SurnameColumn.ReadOnly = true;
            this.SurnameColumn.Width = 125;
            // 
            // PostColumn
            // 
            this.PostColumn.HeaderText = "Должность";
            this.PostColumn.MinimumWidth = 6;
            this.PostColumn.Name = "PostColumn";
            this.PostColumn.ReadOnly = true;
            this.PostColumn.Width = 125;
            // 
            // BirthYearColumn
            // 
            this.BirthYearColumn.HeaderText = "Год рождения";
            this.BirthYearColumn.MinimumWidth = 6;
            this.BirthYearColumn.Name = "BirthYearColumn";
            this.BirthYearColumn.ReadOnly = true;
            this.BirthYearColumn.Width = 125;
            // 
            // SalaryColumn
            // 
            this.SalaryColumn.HeaderText = "Зарплата";
            this.SalaryColumn.MinimumWidth = 6;
            this.SalaryColumn.Name = "SalaryColumn";
            this.SalaryColumn.ReadOnly = true;
            this.SalaryColumn.Width = 125;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(13, 13);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(384, 89);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.getReportBtn);
            this.panel1.Controls.Add(this.deleteEmployerBtn);
            this.panel1.Controls.Add(this.addEmployerBtn);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.salaryBox);
            this.panel1.Controls.Add(this.birthYearBox);
            this.panel1.Controls.Add(this.postBox);
            this.panel1.Controls.Add(this.surnameBox);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Location = new System.Drawing.Point(1078, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 214);
            this.panel1.TabIndex = 2;
            // 
            // getReportBtn
            // 
            this.getReportBtn.AutoSize = true;
            this.getReportBtn.Location = new System.Drawing.Point(76, 175);
            this.getReportBtn.Name = "getReportBtn";
            this.getReportBtn.Size = new System.Drawing.Size(89, 26);
            this.getReportBtn.TabIndex = 12;
            this.getReportBtn.Text = "Отчет";
            this.getReportBtn.UseVisualStyleBackColor = true;
            this.getReportBtn.Click += new System.EventHandler(this.getReportBtn_Click);
            // 
            // deleteEmployerBtn
            // 
            this.deleteEmployerBtn.Location = new System.Drawing.Point(133, 143);
            this.deleteEmployerBtn.Name = "deleteEmployerBtn";
            this.deleteEmployerBtn.Size = new System.Drawing.Size(89, 26);
            this.deleteEmployerBtn.TabIndex = 11;
            this.deleteEmployerBtn.Text = "Удалить";
            this.deleteEmployerBtn.UseVisualStyleBackColor = true;
            this.deleteEmployerBtn.Click += new System.EventHandler(this.deleteEmployerBtn_Click);
            // 
            // addEmployerBtn
            // 
            this.addEmployerBtn.AutoSize = true;
            this.addEmployerBtn.Location = new System.Drawing.Point(11, 143);
            this.addEmployerBtn.Name = "addEmployerBtn";
            this.addEmployerBtn.Size = new System.Drawing.Size(89, 26);
            this.addEmployerBtn.TabIndex = 10;
            this.addEmployerBtn.Text = "Добавить";
            this.addEmployerBtn.UseVisualStyleBackColor = true;
            this.addEmployerBtn.Click += new System.EventHandler(this.addEmployerBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Зарплата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Год рождения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Должность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Имя";
            // 
            // salaryBox
            // 
            this.salaryBox.Location = new System.Drawing.Point(106, 115);
            this.salaryBox.Name = "salaryBox";
            this.salaryBox.Size = new System.Drawing.Size(125, 22);
            this.salaryBox.TabIndex = 4;
            // 
            // birthYearBox
            // 
            this.birthYearBox.Location = new System.Drawing.Point(106, 87);
            this.birthYearBox.Name = "birthYearBox";
            this.birthYearBox.Size = new System.Drawing.Size(125, 22);
            this.birthYearBox.TabIndex = 3;
            // 
            // postBox
            // 
            this.postBox.Location = new System.Drawing.Point(106, 59);
            this.postBox.Name = "postBox";
            this.postBox.Size = new System.Drawing.Size(125, 22);
            this.postBox.TabIndex = 2;
            // 
            // surnameBox
            // 
            this.surnameBox.Location = new System.Drawing.Point(106, 31);
            this.surnameBox.Name = "surnameBox";
            this.surnameBox.Size = new System.Drawing.Size(125, 22);
            this.surnameBox.TabIndex = 1;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(106, 3);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(125, 22);
            this.nameBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 585);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Сотрудники";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox birthYearBox;
        private System.Windows.Forms.TextBox postBox;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox salaryBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button getReportBtn;
        private System.Windows.Forms.Button deleteEmployerBtn;
        private System.Windows.Forms.Button addEmployerBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthYearColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalaryColumn;
    }
}

