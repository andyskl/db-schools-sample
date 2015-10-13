namespace DBCourseProject
{
    partial class SimpleDataListForm
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
        private new void InitializeComponent()
        {
            this.listBox = new DBCourseProject.CustomListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(237, 212);
            this.listBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 230);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(93, 230);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 23);
            this.setButton.TabIndex = 2;
            this.setButton.Text = "Изменить";
            this.setButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(174, 230);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // SimpleDataListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 262);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SimpleDataListForm";
            this.Text = "SimpleDataListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomListBox listBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button deleteButton;
    }
}