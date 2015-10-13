namespace DBCourseProject
{
    partial class SimpleInputForm
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
        new private void InitializeComponent()
        {                      
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(101, 12);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(348, 20);
            this.nameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(155, 38);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(236, 38);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // SimpleInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 74);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SimpleInputForm";
            this.Text = "SimpleInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();            
        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}