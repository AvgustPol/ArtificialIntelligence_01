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
            this.resultDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxPathToDataFile = new System.Windows.Forms.TextBox();
            this.buttonStartRandom = new System.Windows.Forms.Button();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // resultDataBindingSource
            // 
            this.resultDataBindingSource.DataSource = typeof(CSVFileReadWrite.ResultData);
            // 
            // textBoxPathToDataFile
            // 
            this.textBoxPathToDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPathToDataFile.Location = new System.Drawing.Point(19, 26);
            this.textBoxPathToDataFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPathToDataFile.Name = "textBoxPathToDataFile";
            this.textBoxPathToDataFile.Size = new System.Drawing.Size(584, 23);
            this.textBoxPathToDataFile.TabIndex = 6;
            this.textBoxPathToDataFile.Text = "D:\\Anton\\Обучение\\Szt. Inż\\Szt. Inż\\Lab01\\Data\\20.txt";
            // 
            // buttonStartRandom
            // 
            this.buttonStartRandom.Location = new System.Drawing.Point(458, 79);
            this.buttonStartRandom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStartRandom.Name = "buttonStartRandom";
            this.buttonStartRandom.Size = new System.Drawing.Size(144, 48);
            this.buttonStartRandom.TabIndex = 7;
            this.buttonStartRandom.Text = "Start random";
            this.buttonStartRandom.UseVisualStyleBackColor = true;
            this.buttonStartRandom.Click += new System.EventHandler(this.buttonStartRandom_Click);
            // 
            // textBoxTotalCost
            // 
            this.textBoxTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTotalCost.Location = new System.Drawing.Point(686, 26);
            this.textBoxTotalCost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTotalCost.Name = "textBoxTotalCost";
            this.textBoxTotalCost.Size = new System.Drawing.Size(348, 23);
            this.textBoxTotalCost.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(640, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Best :";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTotalCost);
            this.Controls.Add(this.buttonStartRandom);
            this.Controls.Add(this.textBoxPathToDataFile);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    }
}

