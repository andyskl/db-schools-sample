using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBCourseProject
{
    public class DataOutput : Form
    {
        protected IListingControl listingControl;

        Button addButton;

        Button setButton;

        Button deleteButton;

        protected void InitializeComponent()
        {
            this.addButton.Click += new EventHandler(HandleAddButtonClick);
            this.setButton.Click += new EventHandler(HandleSetButtonClick);
            this.deleteButton.Click += new EventHandler(HandleDeleteButtonClick);
        }

        protected void AssignList(IListingControl listingControl)
        {
            this.listingControl = listingControl;
        }

        protected void AssignAddButton(Button addButton)
        {
            this.addButton = addButton;
        }

        protected void AssignSetButton(Button setButton)
        {
            this.setButton = setButton;
        }

        protected void AssignDeleteButton(Button deleteButton)
        {
            this.deleteButton = deleteButton;
        }

        protected virtual void OutputData() { }

        protected void CheckButtons()
        {
            bool hasElements = listingControl.ElementCount != 0;
            setButton.Enabled = hasElements;
            deleteButton.Enabled = hasElements;            
        }

        protected virtual void HandleAddButtonClick(object sender, EventArgs e) { }

        protected virtual void HandleSetButtonClick(object sender, EventArgs e) { }

        protected virtual void HandleDeleteButtonClick(object sender, EventArgs e) { }

    }
}
