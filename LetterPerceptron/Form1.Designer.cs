namespace LetterPerceptron
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
            this.OutputLabel = new System.Windows.Forms.Label();
            this.CharacterInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TrainButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.AutoTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(317, 29);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(45, 15);
            this.OutputLabel.TabIndex = 0;
            this.OutputLabel.Text = "Output";
            // 
            // CharacterInput
            // 
            this.CharacterInput.Location = new System.Drawing.Point(291, 59);
            this.CharacterInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CharacterInput.Name = "CharacterInput";
            this.CharacterInput.Size = new System.Drawing.Size(110, 23);
            this.CharacterInput.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 59);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "Auto Train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AutoTrainButtonClick);
            // 
            // TrainButton
            // 
            this.TrainButton.Location = new System.Drawing.Point(204, 59);
            this.TrainButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TrainButton.Name = "TrainButton";
            this.TrainButton.Size = new System.Drawing.Size(82, 22);
            this.TrainButton.TabIndex = 3;
            this.TrainButton.Text = "Train";
            this.TrainButton.UseVisualStyleBackColor = true;
            this.TrainButton.Click += new System.EventHandler(this.TrainButtonClick);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(406, 58);
            this.TestButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(82, 22);
            this.TestButton.TabIndex = 4;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButtonClick);
            // 
            // AutoTest
            // 
            this.AutoTest.Location = new System.Drawing.Point(494, 58);
            this.AutoTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AutoTest.Name = "AutoTest";
            this.AutoTest.Size = new System.Drawing.Size(82, 22);
            this.AutoTest.TabIndex = 5;
            this.AutoTest.Text = "Auto Test";
            this.AutoTest.UseVisualStyleBackColor = true;
            this.AutoTest.Click += new System.EventHandler(this.AutoTestButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 479);
            this.Controls.Add(this.AutoTest);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.TrainButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CharacterInput);
            this.Controls.Add(this.OutputLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label OutputLabel;
        private TextBox CharacterInput;
        private Button button1;
        private Button TrainButton;
        private Button TestButton;
        private Button AutoTest;
    }
}