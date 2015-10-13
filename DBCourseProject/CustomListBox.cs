using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DBCourseProject
{
    class CustomListBox : ListBox, IListingControl
    {
        int lastIndex;

        public int Index
        {
            get
            {
                if (this.Items.Count <= 0)
                    throw new NoIndexException();
                else
                    return this.SelectedIndex;
            }
        }

        public void OutputData(object dataSource)
        {
            if (this.Items.Count > 0)
                lastIndex = Index;
            this.DataSource = dataSource;
            int dataLength = this.Items.Count;
            if (lastIndex < dataLength)
                this.SelectedIndex = lastIndex;
            else
                this.SelectedIndex = dataLength - 1;
        }

        public int ElementCount
        {
            get
            {
                return this.Items.Count;
            }
        }

        public void Refresh()
        {
            this.Refresh();
        }
    }
}
