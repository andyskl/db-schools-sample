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
    public partial class NoHighClassesSchoolsForm : Form
    {
        public NoHighClassesSchoolsForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = EntitiesHolder.Entities.v_q3;

        }
    }
}
