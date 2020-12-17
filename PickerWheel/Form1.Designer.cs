namespace PickerWheel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Spin_btn = new System.Windows.Forms.Button();
            this.UserInput_pnl = new System.Windows.Forms.Panel();
            this.Add_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PieInput_txtBox = new System.Windows.Forms.TextBox();
            this.InputContainer_flowLayoutPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.UserInput_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Spin_btn
            // 
            this.Spin_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(191)))), ((int)(((byte)(127)))));
            this.Spin_btn.FlatAppearance.BorderSize = 0;
            this.Spin_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Spin_btn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Spin_btn.ForeColor = System.Drawing.Color.White;
            this.Spin_btn.Location = new System.Drawing.Point(105, 385);
            this.Spin_btn.Name = "Spin_btn";
            this.Spin_btn.Size = new System.Drawing.Size(92, 29);
            this.Spin_btn.TabIndex = 0;
            this.Spin_btn.TabStop = false;
            this.Spin_btn.Text = "Spin";
            this.Spin_btn.UseVisualStyleBackColor = false;
            this.Spin_btn.Click += new System.EventHandler(this.SpinClick_btn);
            // 
            // UserInput_pnl
            // 
            this.UserInput_pnl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UserInput_pnl.Controls.Add(this.Add_btn);
            this.UserInput_pnl.Controls.Add(this.label1);
            this.UserInput_pnl.Controls.Add(this.PieInput_txtBox);
            this.UserInput_pnl.Controls.Add(this.InputContainer_flowLayoutPnl);
            this.UserInput_pnl.Controls.Add(this.Spin_btn);
            this.UserInput_pnl.Location = new System.Drawing.Point(449, 12);
            this.UserInput_pnl.Name = "UserInput_pnl";
            this.UserInput_pnl.Size = new System.Drawing.Size(304, 426);
            this.UserInput_pnl.TabIndex = 1;
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(191)))), ((int)(((byte)(127)))));
            this.Add_btn.FlatAppearance.BorderSize = 0;
            this.Add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_btn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_btn.ForeColor = System.Drawing.Color.White;
            this.Add_btn.Location = new System.Drawing.Point(239, 48);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(49, 28);
            this.Add_btn.TabIndex = 4;
            this.Add_btn.TabStop = false;
            this.Add_btn.Text = "Add";
            this.Add_btn.UseVisualStyleBackColor = false;
            this.Add_btn.Click += new System.EventHandler(this.AddClick_btn);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "INPUTS";
            // 
            // PieInput_txtBox
            // 
            this.PieInput_txtBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PieInput_txtBox.Location = new System.Drawing.Point(20, 48);
            this.PieInput_txtBox.Name = "PieInput_txtBox";
            this.PieInput_txtBox.Size = new System.Drawing.Size(213, 28);
            this.PieInput_txtBox.TabIndex = 2;
            // 
            // InputContainer_flowLayoutPnl
            // 
            this.InputContainer_flowLayoutPnl.AutoScroll = true;
            this.InputContainer_flowLayoutPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InputContainer_flowLayoutPnl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.InputContainer_flowLayoutPnl.Location = new System.Drawing.Point(20, 93);
            this.InputContainer_flowLayoutPnl.Name = "InputContainer_flowLayoutPnl";
            this.InputContainer_flowLayoutPnl.Size = new System.Drawing.Size(268, 286);
            this.InputContainer_flowLayoutPnl.TabIndex = 1;
            this.InputContainer_flowLayoutPnl.WrapContents = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 450);
            this.Controls.Add(this.UserInput_pnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PickerWheel";
            this.UserInput_pnl.ResumeLayout(false);
            this.UserInput_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Spin_btn;
        private System.Windows.Forms.Panel UserInput_pnl;
        private System.Windows.Forms.FlowLayoutPanel InputContainer_flowLayoutPnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PieInput_txtBox;
        private System.Windows.Forms.Button Add_btn;
    }
}

