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
    public partial class ClassEditForm : DataInput
    {
        bool changing = false;
        IQueryable<decimal> schoolIds;
        IQueryable<decimal> classTypeIds;
        public ClassEditForm()
        {
            InitializeComponent();
            AssignOkButton(okButton);
            AssignCancelButton(cancelButton);
            AddTextbox(textBox1, 50);
            base.InitializeComponent();
            LoadSchools();
            LoadClasses();
            schoolIds =
                    (from s in EntitiesHolder.Entities.School
                     select s.idSchool);
            classTypeIds =
                (from ct in EntitiesHolder.Entities.ClassType
                 select ct.idClassType);
            this.Text = "Добавление класса";
        }

        public ClassEditForm(decimal idSchool, decimal idClassType, string nameClass, decimal boysAmount, decimal girlsAmount)
            : this()
        {
            int schoolIndex = schoolIds.ToList().IndexOf(idSchool);
            int classTypeIndex = classTypeIds.ToList().IndexOf(idClassType);
            comboBox1.SelectedIndex = schoolIndex;
            comboBox2.SelectedIndex = classTypeIndex;
            textBox1.Text = nameClass;
            numericUpDown1.Value = boysAmount;
            numericUpDown2.Value = girlsAmount;
            this.Text = "Изменение класса";
        }
        private void ClassEditForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadSchools()
        {
            var schoolNames =
                (from s in EntitiesHolder.Entities.School
                 select s.nameSchool);
            comboBox1.DataSource = schoolNames;
        }

        private void LoadClasses()
        {
            var classNames =
                (from ct in EntitiesHolder.Entities.ClassType
                 select ct.nameClassType);
            comboBox2.DataSource = classNames;
        }

        protected override bool CheckOtherData()
        {
            return true;
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

        public decimal ClassTypeId
        {
            get
            {
                return classTypeIds.ToArray()[comboBox2.SelectedIndex];
            }
        }

        public decimal BoysAmount
        {
            get
            {
                return numericUpDown1.Value;
            }
        }

        public decimal GirlsAmount
        {
            get
            {
                return numericUpDown2.Value;
            }
        }

        public string ClassName
        {
            get
            {
                return GetValueAt(0);
            }
        }
    }
}
