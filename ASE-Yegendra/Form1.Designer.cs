namespace ASE_Yegendra
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
            outputBox = new PictureBox();
            ProgramWindow = new RichTextBox();
            debuggerWindow = new RichTextBox();
            runBtn = new Button();
            AnimationBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)outputBox).BeginInit();
            SuspendLayout();
            // 
            // outputBox
            // 
            outputBox.BackColor = Color.LightGray;
            outputBox.Location = new Point(240, 12);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(386, 300);
            outputBox.TabIndex = 0;
            outputBox.TabStop = false;
            outputBox.Paint += outputBox_Paint;
            // 
            // ProgramWindow
            // 
            ProgramWindow.Location = new Point(0, 12);
            ProgramWindow.Name = "ProgramWindow";
            ProgramWindow.Size = new Size(222, 325);
            ProgramWindow.TabIndex = 1;
            ProgramWindow.Text = "";
            // 
            // debuggerWindow
            // 
            debuggerWindow.BackColor = Color.FromArgb(128, 255, 255);
            debuggerWindow.Location = new Point(240, 339);
            debuggerWindow.Name = "debuggerWindow";
            debuggerWindow.Size = new Size(386, 99);
            debuggerWindow.TabIndex = 2;
            debuggerWindow.Text = "";
            // 
            // runBtn
            // 
            runBtn.BackColor = Color.FromArgb(255, 128, 0);
            runBtn.Location = new Point(24, 365);
            runBtn.Name = "runBtn";
            runBtn.Size = new Size(69, 49);
            runBtn.TabIndex = 3;
            runBtn.Text = "Run";
            runBtn.UseVisualStyleBackColor = false;
            runBtn.Click += runBtn_Click;
            // 
            // AnimationBtn
            // 
            AnimationBtn.BackColor = Color.MediumSpringGreen;
            AnimationBtn.Location = new Point(129, 365);
            AnimationBtn.Name = "AnimationBtn";
            AnimationBtn.Size = new Size(81, 49);
            AnimationBtn.TabIndex = 4;
            AnimationBtn.Text = "StartGame";
            AnimationBtn.UseVisualStyleBackColor = false;
            AnimationBtn.Click += AnimationBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 450);
            Controls.Add(AnimationBtn);
            Controls.Add(runBtn);
            Controls.Add(debuggerWindow);
            Controls.Add(ProgramWindow);
            Controls.Add(outputBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)outputBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox ProgramWindow;
        private RichTextBox debuggerWindow;
        private Button runBtn;
        private PictureBox outputBox;
        private Button AnimationBtn;
    }
}
