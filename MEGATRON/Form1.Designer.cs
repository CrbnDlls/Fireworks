namespace MEGATRON
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewMount = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSaveTxt = new System.Windows.Forms.Button();
            this.dataGridViewProgram = new System.Windows.Forms.DataGridView();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.buttonCreateProgram = new System.Windows.Forms.Button();
            this.buttonCountPiro = new System.Windows.Forms.Button();
            this.button100Channel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMount)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProgram)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenFile.Location = new System.Drawing.Point(4, 4);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(142, 47);
            this.buttonOpenFile.TabIndex = 2;
            this.buttonOpenFile.Text = "Открыть эксель файл";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx";
            // 
            // dataGridViewMount
            // 
            this.dataGridViewMount.AllowUserToAddRows = false;
            this.dataGridViewMount.AllowUserToDeleteRows = false;
            this.dataGridViewMount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewMount, 4);
            this.dataGridViewMount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMount.Location = new System.Drawing.Point(4, 114);
            this.dataGridViewMount.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewMount.Name = "dataGridViewMount";
            this.dataGridViewMount.ReadOnly = true;
            this.dataGridViewMount.RowTemplate.Height = 24;
            this.dataGridViewMount.Size = new System.Drawing.Size(712, 292);
            this.dataGridViewMount.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.buttonOpenFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveTxt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewProgram, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewMount, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxInfo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateProgram, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCountPiro, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button100Channel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1223, 410);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // buttonSaveTxt
            // 
            this.buttonSaveTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveTxt.Enabled = false;
            this.buttonSaveTxt.Location = new System.Drawing.Point(3, 58);
            this.buttonSaveTxt.Name = "buttonSaveTxt";
            this.buttonSaveTxt.Size = new System.Drawing.Size(144, 49);
            this.buttonSaveTxt.TabIndex = 8;
            this.buttonSaveTxt.Text = "Сохранить файл";
            this.buttonSaveTxt.UseVisualStyleBackColor = true;
            this.buttonSaveTxt.Click += new System.EventHandler(this.buttonSaveTxt_Click);
            // 
            // dataGridViewProgram
            // 
            this.dataGridViewProgram.AllowUserToAddRows = false;
            this.dataGridViewProgram.AllowUserToDeleteRows = false;
            this.dataGridViewProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProgram.Location = new System.Drawing.Point(723, 113);
            this.dataGridViewProgram.Name = "dataGridViewProgram";
            this.dataGridViewProgram.ReadOnly = true;
            this.dataGridViewProgram.RowTemplate.Height = 24;
            this.dataGridViewProgram.Size = new System.Drawing.Size(497, 294);
            this.dataGridViewProgram.TabIndex = 6;
            // 
            // listBoxInfo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxInfo, 2);
            this.listBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 16;
            this.listBoxInfo.Location = new System.Drawing.Point(453, 3);
            this.listBoxInfo.Name = "listBoxInfo";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxInfo, 2);
            this.listBoxInfo.Size = new System.Drawing.Size(767, 100);
            this.listBoxInfo.TabIndex = 7;
            // 
            // buttonCreateProgram
            // 
            this.buttonCreateProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateProgram.Enabled = false;
            this.buttonCreateProgram.Location = new System.Drawing.Point(153, 3);
            this.buttonCreateProgram.Name = "buttonCreateProgram";
            this.buttonCreateProgram.Size = new System.Drawing.Size(144, 49);
            this.buttonCreateProgram.TabIndex = 9;
            this.buttonCreateProgram.Text = "Расчитать программу";
            this.buttonCreateProgram.UseVisualStyleBackColor = true;
            this.buttonCreateProgram.Click += new System.EventHandler(this.buttonCreateProgram_Click);
            // 
            // buttonCountPiro
            // 
            this.buttonCountPiro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCountPiro.Enabled = false;
            this.buttonCountPiro.Location = new System.Drawing.Point(153, 58);
            this.buttonCountPiro.Name = "buttonCountPiro";
            this.buttonCountPiro.Size = new System.Drawing.Size(144, 49);
            this.buttonCountPiro.TabIndex = 10;
            this.buttonCountPiro.Text = "Подсчитать заряды";
            this.buttonCountPiro.UseVisualStyleBackColor = true;
            this.buttonCountPiro.Click += new System.EventHandler(this.buttonCountPiro_Click);
            // 
            // button100Channel
            // 
            this.button100Channel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button100Channel.Enabled = false;
            this.button100Channel.Location = new System.Drawing.Point(303, 3);
            this.button100Channel.Name = "button100Channel";
            this.button100Channel.Size = new System.Drawing.Size(144, 49);
            this.button100Channel.TabIndex = 11;
            this.button100Channel.Text = "Программа для 100-канального";
            this.button100Channel.UseVisualStyleBackColor = true;
            this.button100Channel.Click += new System.EventHandler(this.button100Channel_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.FileName = "program";
            this.saveFileDialog1.Filter = "Текст|*.txt";
            this.saveFileDialog1.Title = "Сохранить текстовую программу";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 410);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "MEGATRON PROGRAMMER V 0.03";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMount)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProgram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridViewMount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewProgram;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.Button buttonSaveTxt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonCreateProgram;
        private System.Windows.Forms.Button buttonCountPiro;
        private System.Windows.Forms.Button button100Channel;
    }
}

