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
    public partial class SchoolEditForm : DataInput
    {
        IQueryable<decimal> schoolPropertyTypeIds;
        IQueryable<decimal> districtIds;

        public SchoolEditForm()
        {
            InitializeComponent();
            AssignOkButton(button1);
            AssignCancelButton(button2);
            AddTextbox(textBox1, 100);
            AddTextbox(textBox2, 100);
            base.InitializeComponent();
            LoadPropertyTypes();
            LoadDistrictNames();
            schoolPropertyTypeIds =
                (from pt in EntitiesHolder.Entities.PropertyType
                 select pt.idPropertyType);
            districtIds =
                (from d in EntitiesHolder.Entities.District
                 select d.idDistrict);
            this.Text = "Добавление школы";
        }

        public SchoolEditForm(string name, decimal spTypeId, decimal spbTypeId, decimal amount, string address, decimal idDistrict)
            : this()
        {
            int spTypeIndex = schoolPropertyTypeIds.ToList().IndexOf(spTypeId);
            int spbTypeIndex = schoolPropertyTypeIds.ToList().IndexOf(spbTypeId);
            int districtIndex = districtIds.ToList().IndexOf(idDistrict);
            comboBox1.SelectedIndex = spTypeIndex;
            comboBox2.SelectedIndex = spbTypeIndex;
            comboBox3.SelectedIndex = districtIndex;
            textBox1.Text = name;
            textBox2.Text = address;
            numericUpDown1.Value = amount;
            this.Text = "Изменение данных о школе";
        }

        private void LoadPropertyTypes()
        {
            var propertyTypeNames =
                (from pt in EntitiesHolder.Entities.PropertyType
                 select pt.namePropertyType);
            comboBox1.DataSource = propertyTypeNames;
            comboBox2.DataSource = propertyTypeNames;
        }

        private void LoadDistrictNames()
        {
            var districtNames =
                (from d in EntitiesHolder.Entities.District
                 select d.nameDistrict);
            comboBox3.DataSource = districtNames;
        }

        public string SchoolName
        {
            get
            {
                return GetValueAt(0);
            }
        }

        public decimal IdSPType
        {
            get
            {
                return schoolPropertyTypeIds.ToArray()[comboBox1.SelectedIndex];
            }
        }

        public decimal IdSPBType
        {
            get
            {
                return schoolPropertyTypeIds.ToArray()[comboBox2.SelectedIndex];
            }
        }

        public decimal Amount
        {
            get
            {
                return numericUpDown1.Value;
            }
        }

        public string Address
        {
            get
            {
                return GetValueAt(1);
            }
        }

        public decimal DistrictId
        {
            get
            {
                return districtIds.ToArray()[comboBox3.SelectedIndex];
            }
        }
    }
}
