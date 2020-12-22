
namespace JkTsGetterTool
{
    partial class FormExecute
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
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLogs.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxLogs.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(533, 352);
            this.textBoxLogs.TabIndex = 0;
            // 
            // FormExecute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 352);
            this.Controls.Add(this.textBoxLogs);
            this.Name = "FormExecute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "処理プロンプト";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExecute_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormExecute_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogs;
    }
}