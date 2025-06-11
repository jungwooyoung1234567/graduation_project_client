namespace Graduation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            label4 = new Label();
            button8 = new Button();
            button9 = new Button();
            label2 = new Label();
            button10 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(435, 772);
            label1.Name = "label1";
            label1.Size = new Size(110, 32);
            label1.TabIndex = 1;
            label1.Text = "방향조종";
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(421, 566);
            button1.Name = "button1";
            button1.Size = new Size(152, 150);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Control;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(421, 867);
            button2.Name = "button2";
            button2.Size = new Size(152, 150);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(566, 715);
            button3.Name = "button3";
            button3.Size = new Size(150, 146);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.ForeColor = SystemColors.ControlText;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(279, 709);
            button4.Name = "button4";
            button4.Size = new Size(150, 159);
            button4.TabIndex = 5;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(751, 836);
            button5.Name = "button5";
            button5.Size = new Size(131, 72);
            button5.TabIndex = 6;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(751, 939);
            button6.Name = "button6";
            button6.Size = new Size(131, 67);
            button6.TabIndex = 7;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.Location = new Point(751, 1038);
            button7.Name = "button7";
            button7.Size = new Size(131, 62);
            button7.TabIndex = 8;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(761, 1121);
            label4.Name = "label4";
            label4.Size = new Size(110, 32);
            label4.TabIndex = 11;
            label4.Text = "속도조정";
            // 
            // button8
            // 
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(62, 923);
            button8.Name = "button8";
            button8.Size = new Size(210, 207);
            button8.TabIndex = 12;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.Location = new Point(751, 574);
            button9.Name = "button9";
            button9.Size = new Size(150, 135);
            button9.TabIndex = 13;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 1133);
            label2.Name = "label2";
            label2.Size = new Size(134, 32);
            label2.TabIndex = 14;
            label2.Text = "방향초기화";
            // 
            // button10
            // 
            button10.Location = new Point(421, 374);
            button10.Name = "button10";
            button10.Size = new Size(150, 46);
            button10.TabIndex = 15;
            button10.Text = "마이크";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1970, 1191);
            Controls.Add(button10);
            Controls.Add(label2);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(label4);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Label label4;
        private Button button8;
        private Button button9;
        private Label label2;
        private Button button10;

    }

}
