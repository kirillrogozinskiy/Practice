namespace task1
{
    partial class Form1
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(226, 32);
            label1.TabIndex = 0;
            label1.Text = "Учет сотрудников";
            // 
            // button1
            // 
            button1.Location = new Point(221, 409);
            button1.Margin = new Padding(3, 3, 12, 3);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(489, 409);
            button2.Margin = new Padding(12, 3, 3, 3);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Удалить ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(339, 409);
            button3.Margin = new Padding(12, 3, 12, 3);
            button3.Name = "button3";
            button3.Size = new Size(126, 29);
            button3.TabIndex = 4;
            button3.Text = "Редактировать";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 282);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 5;
            label2.Text = "ФИО:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 318);
            label3.Margin = new Padding(3, 16, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 6;
            label3.Text = "Должность:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(104, 315);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(385, 27);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(104, 279);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(385, 27);
            textBox2.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(12, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 229);
            dataGridView1.TabIndex = 9;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "ФИО:";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Должность:";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 300;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(538, 279);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 113);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Фильтр";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 86);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(118, 24);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Разработчик";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 56);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(104, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Менеджер";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(54, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Все";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Учет сотрудников";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}
