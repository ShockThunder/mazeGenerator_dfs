namespace ConsoleApp4
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.picMaze = new System.Windows.Forms.PictureBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.solveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "height";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(12, 36);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(73, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "10";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(106, 36);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(67, 20);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.Text = "10";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(215, 33);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 3;
            this.createBtn.Text = "create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // picMaze
            // 
            this.picMaze.Location = new System.Drawing.Point(12, 62);
            this.picMaze.MinimumSize = new System.Drawing.Size(420, 260);
            this.picMaze.Name = "picMaze";
            this.picMaze.Size = new System.Drawing.Size(420, 260);
            this.picMaze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMaze.TabIndex = 4;
            this.picMaze.TabStop = false;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(341, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Save picture";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(215, 4);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(75, 23);
            this.solveBtn.TabIndex = 6;
            this.solveBtn.Text = "Solve";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(438, 330);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.picMaze);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "MazeGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.PictureBox picMaze;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button solveBtn;
    }
}