namespace WinFormCalculator
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
			this.txtOpr1 = new System.Windows.Forms.TextBox();
			this.txtOpr2 = new System.Windows.Forms.TextBox();
			this.cboOpt = new System.Windows.Forms.ComboBox();
			this.lblResult = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtOpr1
			// 
			this.txtOpr1.Location = new System.Drawing.Point(77, 12);
			this.txtOpr1.Name = "txtOpr1";
			this.txtOpr1.Size = new System.Drawing.Size(133, 23);
			this.txtOpr1.TabIndex = 0;
			this.txtOpr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOpr1.TextChanged += new System.EventHandler(this.txtOpr1_TextChanged);
			// 
			// txtOpr2
			// 
			this.txtOpr2.Location = new System.Drawing.Point(77, 41);
			this.txtOpr2.Name = "txtOpr2";
			this.txtOpr2.Size = new System.Drawing.Size(133, 23);
			this.txtOpr2.TabIndex = 1;
			this.txtOpr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOpr2.TextChanged += new System.EventHandler(this.txtOpr2_TextChanged);
			// 
			// cboOpt
			// 
			this.cboOpt.FormattingEnabled = true;
			this.cboOpt.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
			this.cboOpt.Location = new System.Drawing.Point(14, 39);
			this.cboOpt.Name = "cboOpt";
			this.cboOpt.Size = new System.Drawing.Size(57, 25);
			this.cboOpt.TabIndex = 2;
			this.cboOpt.SelectedIndexChanged += new System.EventHandler(this.cboOpt_SelectedIndexChanged);
			this.cboOpt.TextChanged += new System.EventHandler(this.cboOpt_TextChanged);
			// 
			// lblResult
			// 
			this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblResult.Location = new System.Drawing.Point(14, 67);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(196, 23);
			this.lblResult.TabIndex = 3;
			this.lblResult.Text = "result";
			this.lblResult.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(222, 99);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.cboOpt);
			this.Controls.Add(this.txtOpr2);
			this.Controls.Add(this.txtOpr1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Simple Calculator";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextBox txtOpr1;
		private TextBox txtOpr2;
		private ComboBox cboOpt;
		private Label lblResult;
	}
}