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
    public partial class EmployessEditForm : DataInput
    {
        IQueryable<decimal> schoolIds;
        IQueryable<decimal> employeeTypeIds;
        IQueryable<decimal> subjectIds;
        IQueryable<decimal> districtIds;
        public EmployessEditForm()
        {
            InitializeComponent();
            AssignOkButton(button1);
            AssignCancelButton(button2);
            AddTextbox(textBox1, 50);
            AddTextbox(textBox2, 200);
            AddTextbox(textBox3, 100);
            base.InitializeComponent();
            comboBox3.SelectedIndex = 0;
            LoadSchools();
            LoadEmployeeTypes();
            LoadSubjectNames();
            LoadDistrictNames();
            schoolIds =
                    (from s in EntitiesHolder.Entities.School
                     select s.idSchool);
            employeeTypeIds =
                (from s in EntitiesHolder.Entities.EmployeeType
                 select s.idEmployeeType);
            subjectIds =
                (from s in EntitiesHolder.Entities.Subj
                 select s.idSubject);
            districtIds =
                (from d in EntitiesHolder.Entities.District
                 select d.idDistrict);
            this.Text = "Добавление сотрудника";
        }

        public EmployessEditForm(string name, decimal gender, decimal idSchool, decimal idEmployeeType, string address, string education, decimal idSubject, decimal cat, decimal idDistrict)
        :this()
        {
            int schoolIndex = schoolIds.ToList().IndexOf(idSchool);
            int empTypeIndex = employeeTypeIds.ToList().IndexOf(idEmployeeType);
            int subjectIndex = subjectIds.ToList().IndexOf(idSubject);
            int districtIndex = districtIds.ToList().IndexOf(idDistrict);
            comboBox1.SelectedIndex = schoolIndex;
            comboBox2.SelectedIndex = empTypeIndex;
            comboBox3.SelectedIndex = (int)gender;
            comboBox4.SelectedIndex = subjectIndex;
            comboBox5.SelectedIndex = districtIndex;
            textBox1.Text = name;
            textBox2.Text = address;
            textBox3.Text = education;
            numericUpDown1.Value = cat;
            this.Text = "Изменение данных о сотруднике";
        }

        private void LoadSchools()
        {
            var schoolNames =
                (from s in EntitiesHolder.Entities.School
                 select s.nameSchool);
            comboBox1.DataSource = schoolNames;
        }

        private void LoadEmployeeTypes()
        {
            var empTypeNames =
                (from s in EntitiesHolder.Entities.EmployeeType
                 select s.nameEmployeeType);
            comboBox2.DataSource = empTypeNames;
        }

        private void LoadSubjectNames()
        {
            var subNames =
                (from s in EntitiesHolder.Entities.Subj
                 select s.nameSubject);
            comboBox4.DataSource = subNames;
        }

        private void LoadDistrictNames()
        {
            var districtNames =
                (from d in EntitiesHolder.Entities.District
                 select d.nameDistrict);
            comboBox5.DataSource = districtNames;
        }

        public string EmpName
        {
            get
            {
                return GetValueAt(0);
            }
        }

        public decimal Gender
        {
            get
            {
                return comboBox3.SelectedIndex;
            }
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

        public decimal EmployeeTypeId
        {
            get
            {
                return employeeTypeIds.ToArray()[comboBox2.SelectedIndex];
            }
        }

        public string Address
        {
            get
            {
                return GetValueAt(1);
            }
        }

        public string Education
        {
            get
            {
                return GetValueAt(2);
            }
        }

        public decimal SubjectId
        {
            get
            {
                return subjectIds.ToArray()[comboBox4.SelectedIndex];
            }
        }

        public decimal DistrictId
        {
            get
            {
                return districtIds.ToArray()[comboBox5.SelectedIndex];
            }
        }

        public decimal Category
        {
            get
            {
                return numericUpDown1.Value;
            }
        }
    }
}
