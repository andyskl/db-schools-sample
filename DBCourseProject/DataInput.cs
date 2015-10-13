using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBCourseProject
{
    public class DataInput : Form
    {
        ICollection<TextBox> textBoxesToCheck = new List<TextBox>();
        ICollection<int> textBoxesLengths = new List<int>();

        Button okButton;
        Button cancelButton;

        protected string value;

        bool cancel;

        protected bool CheckData()
        {
            foreach (TextBox tb in textBoxesToCheck)
            {
                string value = FormatString(tb.Text);
                if (value == "") return false;
            }
            return CheckOtherData();
        }

        protected bool CheckLengths()
        {
            for (int i = 0; i < textBoxesToCheck.Count; i++)
            {
                TextBox tb = textBoxesToCheck.ElementAt(i);
                string value = FormatString(tb.Text);
                if (value.Length > textBoxesLengths.ElementAt(i))
                {
                    return false;
                }
            }
            return true;
        }

        protected virtual bool CheckOtherData()
        {
            return true;
        }

        protected string FormatString(string input)
        {
            return input;
        }

        protected void AddTextbox(TextBox tb, int length)
        {
            textBoxesToCheck.Add(tb);
            textBoxesLengths.Add(length);
        }

        protected void AssignOkButton(Button b)
        {
            okButton = b;
        }

        protected void AssignCancelButton(Button b)
        {
            cancelButton = b;
        }

        protected virtual void ApplyData()
        {
        }

        private void ShowEmptyFieldsError()
        {
            MessageBox.Show("Обязательные поля не заполнены");
        }

        private void ShowOversizeError()
        {
            MessageBox.Show("Слишком длинная строка");
        }

        private void HandleClosingEvent(object sender, FormClosingEventArgs e)
        {
            if (!cancel)
            {
                bool ready = CheckData();

                if (ready)
                {
                    ApplyData();
                }
                else
                {
                    e.Cancel = true;
                    ShowEmptyFieldsError();

                }
            }
        }

        private void HandleOkButtonClick(object sender, EventArgs e)
        {
            bool oversize = !CheckLengths();
            if (oversize)
            {
                ShowOversizeError();
                return;
            }
            this.Close();
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }

        protected void InitializeComponent()
        {
            cancel = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(HandleClosingEvent);
            this.okButton.Click += new EventHandler(HandleOkButtonClick);
            this.cancelButton.Click += new EventHandler(HandleCancelButtonClick);
        }

        public string Value
        {
            get
            {
                if (cancel)
                    throw new EmptyValueException();
                return value;
            }
        }

        public bool Cancel
        {
            get
            {
                return cancel;
            }
        }

        protected string GetValueAt(int index)
        {
            return FormatString(textBoxesToCheck.ElementAt(index).Text);
        }
    }
}
