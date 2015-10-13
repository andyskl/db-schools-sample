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
    public partial class SchoolVehiclesEditForm : DataInput
    {
        IQueryable<decimal> schoolIds;
        IQueryable<decimal> vehicleTypesIds;

        public SchoolVehiclesEditForm()
        {
            InitializeComponent();
            AssignOkButton(button1);
            AssignCancelButton(button2);
            base.InitializeComponent();
            LoadSchools();
            LoadVehicles();
            schoolIds =
                (from s in EntitiesHolder.Entities.School
                 select s.idSchool);
            vehicleTypesIds =
                (from q in EntitiesHolder.Entities.VehicleType
                 select q.idVehicleType);
            this.Text = "Добавление данных о транспорте";
        }

        public SchoolVehiclesEditForm(decimal idSchool, decimal idVehicleType, decimal amount)
            :this()
        {
            int schoolIndex = schoolIds.ToList().IndexOf(idSchool);
            int vehicleTypeIndex = vehicleTypesIds.ToList().IndexOf(idVehicleType);
            comboBox1.SelectedIndex = schoolIndex;
            comboBox2.SelectedIndex = vehicleTypeIndex;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            numericUpDown1.Value = amount;
            this.Text = "Изменение данных о транспорте";
        }

        private void LoadSchools()
        {
            var schoolNames =
                (from s in EntitiesHolder.Entities.School
                 select s.nameSchool);
            comboBox1.DataSource = schoolNames;
        }

        private void LoadVehicles()
        {
            var vehicleNames =
                (from v in EntitiesHolder.Entities.VehicleType
                 select v.nameVehicleType);
            comboBox2.DataSource = vehicleNames;
        }

        public decimal idSchool
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

        public decimal idVehicleType
        {
            get
            {
                return vehicleTypesIds.ToArray()[comboBox2.SelectedIndex];
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
