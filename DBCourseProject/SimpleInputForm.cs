using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBCourseProject
{
    public partial class SimpleInputForm : DataInput
    {
        public SimpleInputForm()
        {
            InitializeComponent();
            AddTextbox(nameBox, SimpleIOManager.CurrentEntity.TextLength);
            AssignOkButton(okButton);
            AssignCancelButton(cancelButton);
            Text = "";
            base.InitializeComponent();
        }

        public SimpleInputForm(string value, string title = "")
            : this()
        {
            Text = title;
            nameBox.Text = value;
        }

        protected override void ApplyData()
        {
            this.value = nameBox.Text;
        }
    }
}
