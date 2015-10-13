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
    public partial class SchoolToolsEditForm : DataInput
    {
        IQueryable<decimal> schoolIds;
        IQueryable<decimal> toolTypeIds;

        bool changing;

        public SchoolToolsEditForm()
        {
            InitializeComponent();
            AssignOkButton(button1);
            AssignCancelButton(button2);
            base.InitializeComponent();
            LoadSchools();
            LoadTools();
            schoolIds =
                (from s in EntitiesHolder.Entities.School
                 select s.idSchool);
            toolTypeIds =
                (from t in EntitiesHolder.Entities.ToolType
                 select t.idToolType);
            this.Text = "Добавление данных о станках";
        }

        public SchoolToolsEditForm(decimal idSchool, decimal idToolType, decimal amount)
            : this()
        {
            int schoolIndex = schoolIds.ToList().IndexOf(idSchool);
            int toolTypeIndex = toolTypeIds.ToList().IndexOf(idToolType);
            comboBox1.SelectedIndex = schoolIndex;
            comboBox2.SelectedIndex = toolTypeIndex;
            numericUpDown1.Value = amount;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            this.Text = "Изменение данных о станках";
        }

        private void LoadSchools()
        {
            var schoolNames =
                (from s in EntitiesHolder.Entities.School
                 select s.nameSchool);
            comboBox1.DataSource = schoolNames;
        }

        private void LoadTools()
        {
            var toolNames =
                (from t in EntitiesHolder.Entities.ToolType
                 select t.nameToolType);
            comboBox2.DataSource = toolNames;
        }

        public decimal SchoolId
        {
            get
            {
                return schoolIds.ToArray()[comboBox1.SelectedIndex];
            }
            set
            {
                comboBox1.SelectedIndex = schoolIds.ToList().IndexOf(value);
            }
        }

        public decimal ToolTypeId
        {
            get
            {
                return toolTypeIds.ToArray()[comboBox2.SelectedIndex];
            }
        }

        public decimal Amount
        {
            get
            {
                return numericUpDown1.Value;
            }
        }

    }
}
