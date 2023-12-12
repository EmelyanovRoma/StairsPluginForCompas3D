namespace StairsPlugin.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StairsPlanPictureBox = new System.Windows.Forms.PictureBox();
            this.BuildButton = new System.Windows.Forms.Button();
            this.StairsHeightLabel = new System.Windows.Forms.Label();
            this.StairsHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StairsHeightLimitLabel = new System.Windows.Forms.Label();
            this.StairsWidthLabel = new System.Windows.Forms.Label();
            this.StairsWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StairsWidthLimitLabel = new System.Windows.Forms.Label();
            this.StairsThicknessLabel = new System.Windows.Forms.Label();
            this.StairsThicknessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StairsThicknessLimitLabel = new System.Windows.Forms.Label();
            this.StringerWidthLabel = new System.Windows.Forms.Label();
            this.StringerWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StringerWidthLimitLabel = new System.Windows.Forms.Label();
            this.StepLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StepLengthLabel = new System.Windows.Forms.Label();
            this.StepLengthLimitLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StairsPlanPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StairsHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StairsWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StairsThicknessNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StringerWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepLengthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // StairsPlanPictureBox
            // 
            this.StairsPlanPictureBox.BackgroundImage = global::StairsPlugin.View.Properties.Resources.stairs_plan;
            this.StairsPlanPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StairsPlanPictureBox.Location = new System.Drawing.Point(336, 12);
            this.StairsPlanPictureBox.Name = "StairsPlanPictureBox";
            this.StairsPlanPictureBox.Size = new System.Drawing.Size(247, 272);
            this.StairsPlanPictureBox.TabIndex = 0;
            this.StairsPlanPictureBox.TabStop = false;
            // 
            // BuildButton
            // 
            this.BuildButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuildButton.Location = new System.Drawing.Point(118, 247);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(100, 37);
            this.BuildButton.TabIndex = 1;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // StairsHeightLabel
            // 
            this.StairsHeightLabel.AutoSize = true;
            this.StairsHeightLabel.Location = new System.Drawing.Point(5, 14);
            this.StairsHeightLabel.Name = "StairsHeightLabel";
            this.StairsHeightLabel.Size = new System.Drawing.Size(119, 15);
            this.StairsHeightLabel.TabIndex = 2;
            this.StairsHeightLabel.Text = "Высота лестницы H:";
            // 
            // StairsHeightNumericUpDown
            // 
            this.StairsHeightNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StairsHeightNumericUpDown.Location = new System.Drawing.Point(137, 12);
            this.StairsHeightNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.StairsHeightNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.StairsHeightNumericUpDown.Name = "StairsHeightNumericUpDown";
            this.StairsHeightNumericUpDown.Size = new System.Drawing.Size(71, 23);
            this.StairsHeightNumericUpDown.TabIndex = 3;
            this.StairsHeightNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // StairsHeightLimitLabel
            // 
            this.StairsHeightLimitLabel.AutoSize = true;
            this.StairsHeightLimitLabel.Location = new System.Drawing.Point(214, 14);
            this.StairsHeightLimitLabel.Name = "StairsHeightLimitLabel";
            this.StairsHeightLimitLabel.Size = new System.Drawing.Size(84, 15);
            this.StairsHeightLimitLabel.TabIndex = 4;
            this.StairsHeightLimitLabel.Text = "1000-10000мм";
            // 
            // StairsWidthLabel
            // 
            this.StairsWidthLabel.AutoSize = true;
            this.StairsWidthLabel.Location = new System.Drawing.Point(5, 50);
            this.StairsWidthLabel.Name = "StairsWidthLabel";
            this.StairsWidthLabel.Size = new System.Drawing.Size(126, 15);
            this.StairsWidthLabel.TabIndex = 5;
            this.StairsWidthLabel.Text = "Ширина лестницы W:";
            // 
            // StairsWidthNumericUpDown
            // 
            this.StairsWidthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StairsWidthNumericUpDown.Location = new System.Drawing.Point(137, 48);
            this.StairsWidthNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.StairsWidthNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.StairsWidthNumericUpDown.Minimum = new decimal(new int[] {
            190,
            0,
            0,
            0});
            this.StairsWidthNumericUpDown.Name = "StairsWidthNumericUpDown";
            this.StairsWidthNumericUpDown.Size = new System.Drawing.Size(71, 23);
            this.StairsWidthNumericUpDown.TabIndex = 6;
            this.StairsWidthNumericUpDown.Value = new decimal(new int[] {
            190,
            0,
            0,
            0});
            this.StairsWidthNumericUpDown.ValueChanged += new System.EventHandler(this.StairsWidthNumericUpDown_ValueChanged);
            // 
            // StairsWidthLimitLabel
            // 
            this.StairsWidthLimitLabel.AutoSize = true;
            this.StairsWidthLimitLabel.Location = new System.Drawing.Point(214, 50);
            this.StairsWidthLimitLabel.Name = "StairsWidthLimitLabel";
            this.StairsWidthLimitLabel.Size = new System.Drawing.Size(72, 15);
            this.StairsWidthLimitLabel.TabIndex = 7;
            this.StairsWidthLimitLabel.Text = "190-1000мм";
            // 
            // StairsThicknessLabel
            // 
            this.StairsThicknessLabel.AutoSize = true;
            this.StairsThicknessLabel.Location = new System.Drawing.Point(5, 86);
            this.StairsThicknessLabel.Name = "StairsThicknessLabel";
            this.StairsThicknessLabel.Size = new System.Drawing.Size(127, 15);
            this.StairsThicknessLabel.TabIndex = 8;
            this.StairsThicknessLabel.Text = "Толщина лестницы S:";
            // 
            // StairsThicknessNumericUpDown
            // 
            this.StairsThicknessNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StairsThicknessNumericUpDown.Location = new System.Drawing.Point(137, 84);
            this.StairsThicknessNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.StairsThicknessNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.StairsThicknessNumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.StairsThicknessNumericUpDown.Name = "StairsThicknessNumericUpDown";
            this.StairsThicknessNumericUpDown.Size = new System.Drawing.Size(71, 23);
            this.StairsThicknessNumericUpDown.TabIndex = 9;
            this.StairsThicknessNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // StairsThicknessLimitLabel
            // 
            this.StairsThicknessLimitLabel.AutoSize = true;
            this.StairsThicknessLimitLabel.Location = new System.Drawing.Point(214, 86);
            this.StairsThicknessLimitLabel.Name = "StairsThicknessLimitLabel";
            this.StairsThicknessLimitLabel.Size = new System.Drawing.Size(54, 15);
            this.StairsThicknessLimitLabel.TabIndex = 10;
            this.StairsThicknessLimitLabel.Text = "20-50мм";
            // 
            // StringerWidthLabel
            // 
            this.StringerWidthLabel.AutoSize = true;
            this.StringerWidthLabel.Location = new System.Drawing.Point(5, 122);
            this.StringerWidthLabel.Name = "StringerWidthLabel";
            this.StringerWidthLabel.Size = new System.Drawing.Size(111, 15);
            this.StringerWidthLabel.TabIndex = 11;
            this.StringerWidthLabel.Text = "Ширина балки W1:";
            // 
            // StringerWidthNumericUpDown
            // 
            this.StringerWidthNumericUpDown.BackColor = System.Drawing.Color.White;
            this.StringerWidthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StringerWidthNumericUpDown.Location = new System.Drawing.Point(137, 120);
            this.StringerWidthNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.StringerWidthNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.StringerWidthNumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.StringerWidthNumericUpDown.Name = "StringerWidthNumericUpDown";
            this.StringerWidthNumericUpDown.Size = new System.Drawing.Size(71, 23);
            this.StringerWidthNumericUpDown.TabIndex = 12;
            this.StringerWidthNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.StringerWidthNumericUpDown.ValueChanged += new System.EventHandler(this.StringerWidthNumericUpDown_ValueChanged);
            // 
            // StringerWidthLimitLabel
            // 
            this.StringerWidthLimitLabel.AutoSize = true;
            this.StringerWidthLimitLabel.Location = new System.Drawing.Point(214, 122);
            this.StringerWidthLimitLabel.Name = "StringerWidthLimitLabel";
            this.StringerWidthLimitLabel.Size = new System.Drawing.Size(54, 15);
            this.StringerWidthLimitLabel.TabIndex = 13;
            this.StringerWidthLimitLabel.Text = "20-50мм";
            // 
            // StepLengthNumericUpDown
            // 
            this.StepLengthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StepLengthNumericUpDown.Location = new System.Drawing.Point(137, 156);
            this.StepLengthNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.StepLengthNumericUpDown.Maximum = new decimal(new int[] {
            960,
            0,
            0,
            0});
            this.StepLengthNumericUpDown.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.StepLengthNumericUpDown.Name = "StepLengthNumericUpDown";
            this.StepLengthNumericUpDown.Size = new System.Drawing.Size(71, 23);
            this.StepLengthNumericUpDown.TabIndex = 14;
            this.StepLengthNumericUpDown.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.StepLengthNumericUpDown.ValueChanged += new System.EventHandler(this.StepLengthNumericUpDown_ValueChanged);
            // 
            // StepLengthLabel
            // 
            this.StepLengthLabel.AutoSize = true;
            this.StepLengthLabel.Location = new System.Drawing.Point(5, 158);
            this.StepLengthLabel.Name = "StepLengthLabel";
            this.StepLengthLabel.Size = new System.Drawing.Size(101, 15);
            this.StepLengthLabel.TabIndex = 15;
            this.StepLengthLabel.Text = "Длина ступени L:";
            // 
            // StepLengthLimitLabel
            // 
            this.StepLengthLimitLabel.AutoSize = true;
            this.StepLengthLimitLabel.Location = new System.Drawing.Point(214, 158);
            this.StepLengthLimitLabel.Name = "StepLengthLimitLabel";
            this.StepLengthLimitLabel.Size = new System.Drawing.Size(66, 15);
            this.StepLengthLimitLabel.TabIndex = 16;
            this.StepLengthLimitLabel.Text = "150-960мм";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 296);
            this.Controls.Add(this.StepLengthLimitLabel);
            this.Controls.Add(this.StepLengthLabel);
            this.Controls.Add(this.StepLengthNumericUpDown);
            this.Controls.Add(this.StringerWidthLimitLabel);
            this.Controls.Add(this.StringerWidthNumericUpDown);
            this.Controls.Add(this.StringerWidthLabel);
            this.Controls.Add(this.StairsThicknessLimitLabel);
            this.Controls.Add(this.StairsThicknessNumericUpDown);
            this.Controls.Add(this.StairsThicknessLabel);
            this.Controls.Add(this.StairsWidthLimitLabel);
            this.Controls.Add(this.StairsWidthNumericUpDown);
            this.Controls.Add(this.StairsWidthLabel);
            this.Controls.Add(this.StairsHeightLimitLabel);
            this.Controls.Add(this.StairsHeightNumericUpDown);
            this.Controls.Add(this.StairsHeightLabel);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.StairsPlanPictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StairsPlugin";
            ((System.ComponentModel.ISupportInitialize)(this.StairsPlanPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StairsHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StairsWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StairsThicknessNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StringerWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepLengthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox StairsPlanPictureBox;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label StairsHeightLabel;
        private System.Windows.Forms.NumericUpDown StairsHeightNumericUpDown;
        private System.Windows.Forms.Label StairsHeightLimitLabel;
        private System.Windows.Forms.Label StairsWidthLabel;
        private System.Windows.Forms.NumericUpDown StairsWidthNumericUpDown;
        private System.Windows.Forms.Label StairsWidthLimitLabel;
        private System.Windows.Forms.Label StairsThicknessLabel;
        private System.Windows.Forms.NumericUpDown StairsThicknessNumericUpDown;
        private System.Windows.Forms.Label StairsThicknessLimitLabel;
        private System.Windows.Forms.Label StringerWidthLabel;
        private System.Windows.Forms.NumericUpDown StringerWidthNumericUpDown;
        private System.Windows.Forms.Label StringerWidthLimitLabel;
        private System.Windows.Forms.NumericUpDown StepLengthNumericUpDown;
        private System.Windows.Forms.Label StepLengthLabel;
        private System.Windows.Forms.Label StepLengthLimitLabel;
    }
}

