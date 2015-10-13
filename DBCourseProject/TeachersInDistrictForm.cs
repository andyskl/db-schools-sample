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
    public partial class TeachersInDistrictForm : Form
    {
        decimal idDistrict;
        List<decimal> districtIds;
        public TeachersInDistrictForm()
        {
            InitializeComponent();
            districtIds = new List<decimal>();
            dataGridView1.DataSource = bindingSource1;
        }

        private void TeachersInDistrictForm_Load(object sender, EventArgs e)
        {
            var districtData =
                (from d in EntitiesHolder.Entities.District
                 select d.nameDistrict);            
            districtIds =
                (from d in EntitiesHolder.Entities.District
                 select d.idDistrict).ToList();
            comboBox1.DataSource = districtData;
            idDistrict = districtIds.ToArray()[0];
            string currentDistrictName =
                (from d in EntitiesHolder.Entities.District
                 where d.idDistrict == idDistrict
                 select d.nameDistrict).FirstOrDefault();
            string query = String.Format(
                "select ФИО, Пол, Адрес, Район, Образование, " +
                "[Номер разряда] as Номер_разряда, [Место работы] as Место_работы, " +
                "[Вид работника] as Вид_работника, " +
                "Предмет from v_employees where [Район] = '{0}' and " +
                "[Номер разряда] <= 11 and [Вид работника] = 'Педагоги'", 
                currentDistrictName);
            var tableData =
                EntitiesHolder.Entities.ExecuteStoreQuery<v_employees>(
                query);               
            bindingSource1.DataSource = tableData;           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idDistrict = districtIds.ToArray()[comboBox1.SelectedIndex];
            string currentDistrictName =
                (from d in EntitiesHolder.Entities.District
                 where d.idDistrict == idDistrict
                 select d.nameDistrict).FirstOrDefault();
            string query = String.Format(
                "select ФИО, Пол, Адрес, Район, Образование, [Номер разряда] as Номер_разряда, [Место работы] as Место_работы, [Вид работника] as Вид_работника, Предмет from v_employees where [Район] = '{0}' and [Номер разряда] <= 11 and [Вид работника] = 'Педагоги'", currentDistrictName);
            var tableData =
                EntitiesHolder.Entities.ExecuteStoreQuery<v_employees>(
                query);            
            bindingSource1.DataSource = tableData;
        }

    }
}
