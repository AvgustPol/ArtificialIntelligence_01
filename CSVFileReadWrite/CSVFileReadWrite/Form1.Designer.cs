namespace CSVFileReadWrite
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxPathToDataFile = new System.Windows.Forms.TextBox();
            this.buttonStartRandom = new System.Windows.Forms.Button();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGA = new System.Windows.Forms.Button();
            this.resultDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPathToDataFile
            // 
            this.textBoxPathToDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPathToDataFile.Location = new System.Drawing.Point(25, 32);
            this.textBoxPathToDataFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPathToDataFile.Name = "textBoxPathToDataFile";
            this.textBoxPathToDataFile.Size = new System.Drawing.Size(777, 26);
            this.textBoxPathToDataFile.TabIndex = 6;
            this.textBoxPathToDataFile.Text = "D:\\Google drive\\обучение\\6 sem\\Szt. Inż\\Lab01 with github\\ArtificialIntelligence_" +
    "01\\Data\\20.txt";
            // 
            // buttonStartRandom
            // 
            this.buttonStartRandom.Location = new System.Drawing.Point(611, 97);
            this.buttonStartRandom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStartRandom.Name = "buttonStartRandom";
            this.buttonStartRandom.Size = new System.Drawing.Size(192, 59);
            this.buttonStartRandom.TabIndex = 7;
            this.buttonStartRandom.Text = "Start random";
            this.buttonStartRandom.UseVisualStyleBackColor = true;
            this.buttonStartRandom.Click += new System.EventHandler(this.buttonStartRandom_Click);
            // 
            // textBoxTotalCost
            // 
            this.textBoxTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTotalCost.Location = new System.Drawing.Point(998, 32);
            this.textBoxTotalCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTotalCost.Name = "textBoxTotalCost";
            this.textBoxTotalCost.Size = new System.Drawing.Size(380, 26);
            this.textBoxTotalCost.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(853, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Czas = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(215, 463);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(884, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "TODO - удалить CostCounter класс и сделать его где-то в другом месте !!!";
            // 
            // buttonGA
            // 
            this.buttonGA.Location = new System.Drawing.Point(610, 255);
            this.buttonGA.Name = "buttonGA";
            this.buttonGA.Size = new System.Drawing.Size(192, 59);
            this.buttonGA.TabIndex = 11;
            this.buttonGA.Text = "Start GA";
            this.buttonGA.UseVisualStyleBackColor = true;
            this.buttonGA.Click += new System.EventHandler(this.buttonGA_Click);
            // 
            // resultDataBindingSource
            // 
            this.resultDataBindingSource.DataSource = typeof(CSVFileReadWrite.ResultData);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(251, 367);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(773, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "TODO - сделать элегантный подсчет средней для 10 \"запусков\" ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(139, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1043, 87);
            this.label4.TabIndex = 10;
            this.label4.Text = "TODO - добавить \"вмешательство с машиной времени\" - лучши экземпляр появляется \r\n" +
    "в какой-то генерации и посмотреть, как это повлияет на эфективность метода\r\n\r\n";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(507, 552);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(414, 22);
            this.textBoxTime.TabIndex = 12;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 648);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.buttonGA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTotalCost);
            this.Controls.Add(this.buttonStartRandom);
            this.Controls.Add(this.textBoxPathToDataFile);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource resultDataBindingSource;
        private System.Windows.Forms.TextBox textBoxPathToDataFile;
        private System.Windows.Forms.Button buttonStartRandom;
        private System.Windows.Forms.TextBox textBoxTotalCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonGA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTime;
    }
}

