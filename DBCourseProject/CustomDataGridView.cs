using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBCourseProject
{
    class CustomDataGridView : DataGridView, IListingControl
    {
        int lastIndex;

        public CustomDataGridView()
            : base()
        {
            this.MultiSelect = false;
        }

        public int Index
        {
            get
            {
                if (this.Rows.Count <= 0)
                    throw new NoIndexException();
                else
                    return this.SelectedCells[0].RowIndex;
            }
        }

        public void OutputData(object dataSource)
        {
            this.DataSource = dataSource;
        }

        public void Refresh()
        {
            this.Refresh();
        }

        public int ElementCount
        {
            get
            {
                return this.Rows.Count;
            }
        }
    }
}
