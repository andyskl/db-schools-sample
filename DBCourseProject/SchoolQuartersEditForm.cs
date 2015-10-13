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
    public partial class SchoolQuartersEditForm : DataInput
    {
        IQueryable<decimal> schoolIds;
        IQueryable<decimal> schoolQuartersIds;

        public SchoolQuartersEditForm()
        {
            InitializeComponent();
            AssignOkButton(button1);
            AssignCancelButton(button2);
            base.InitializeComponent();
            LoadSchools();
            LoadQuarters();
            schoolIds =
                (from s in EntitiesHolder.Entities.School
                 select s.idSchool);
            schoolQuartersIds =
                (from q in EntitiesHolder.Entities.QuartersType
                 select q.idQuartersType);
            this.Text = "Добавление данных о школьных помещениях";           
        }

        public SchoolQuartersEditForm(decimal idSchool, decimal idQuartersType, decimal area)
            : this()
        {
            int schoolIndex = schoolIds.ToList().IndexOf(idSchool);
            int quartersTypeIndex = schoolQuartersIds.ToList().IndexOf(idQuartersType);
            comboBox1.SelectedIndex = schoolIndex;
            comboBox2.SelectedIndex = quartersTypeIndex;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            numericUpDown1.Value = area;
            this.Text = "Удаление данных о школьных помещениях";  
        }

        private void LoadSchools()
        {
            var schoolNames =
                (from s in EntitiesHolder.Entities.School
                 select s.nameSchool);
            comboBox1.DataSource = schoolNames;
        }

        private void LoadQuarters()
        {
            var quartersNames =
                (from q in EntitiesHolder.Entities.QuartersType
                 select q.nameQuartersType);
            comboBox2.DataSource = quartersNames;
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

        public decimal QuartersTypeId
        {
            get
            {
                return schoolQuartersIds.ToArray()[comboBox2.SelectedIndex];
            }
        }

        public decimal Area
        {
            get
            {
                return numericUpDown1.Value;
            }
        }
    }
}
