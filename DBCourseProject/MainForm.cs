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

    public partial class MainForm : DataOutput
    {
        public enum EntityType
        {
            Classes,
            Employees,
            Tools,
            Quarters,
            Vehicles,
            Schools
        }

        bool allSchools = true;
        decimal schoolId;
        List<decimal> schoolIds;

        EntityType entityType = EntityType.Schools;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AssignAddButton(addButton);
            AssignSetButton(setButton);
            AssignDeleteButton(deleteButton);
            dataGridView1.DataSource = bindingSource;
            try
            {
                bindingSource.DataSource = EntitiesHolder.Entities.v_schools;
            }
            catch (EntityException)
            {
                MessageBox.Show("Не удалось подключиться к базе данных");
                //this.Close();
                DisableMenu();
                return;
            }
            var schoolNames =
                (from s in EntitiesHolder.Entities.School
                 select s.nameSchool).ToList();
            schoolIds =
                (from s in EntitiesHolder.Entities.School
                 select s.idSchool).ToList();
            List<string> names = new List<string>();
            names.Add("Все школы");
            names.AddRange(schoolNames);
            comboBox1.DataSource = names;
        }

        private void DisableMenu()
        {
            классыToolStripMenuItem.Enabled = false;
            станковыйПаркToolStripMenuItem.Enabled = false;
            помещенияToolStripMenuItem1.Enabled = false;
            помещенияToolStripMenuItem.Enabled = false;
            транспортToolStripMenuItem.Enabled = false;
            транспортToolStripMenuItem1.Enabled = false;
            сотрудникиToolStripMenuItem.Enabled = false;
            школыToolStripMenuItem.Enabled = false;
            справочникиToolStripMenuItem.Enabled = false;
            отчетыToolStripMenuItem.Enabled = false;
            comboBox1.Enabled = false;
            addButton.Enabled = false;
            setButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        private void классыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entityType = EntityType.Classes;
            FillTable();
        }

        private void предметыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleIOManager.CurrentEntityType = SimpleIOManager.SimpleEntities.Subject;
            SimpleDataListForm listForm = new SimpleDataListForm("Предметы");
            listForm.ShowDialog();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entityType = EntityType.Employees;
            FillTable();
        }

        private void помещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleIOManager.CurrentEntityType = SimpleIOManager.SimpleEntities.QuartersType;
            SimpleDataListForm listForm = new SimpleDataListForm("Виды помещений");
            listForm.ShowDialog();
        }

        private void станкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleIOManager.CurrentEntityType = SimpleIOManager.SimpleEntities.ToolType;
            SimpleDataListForm listForm = new SimpleDataListForm("Виды станков");
            listForm.ShowDialog();
        }

        private void собственностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleIOManager.CurrentEntityType = SimpleIOManager.SimpleEntities.PropertyType;
            SimpleDataListForm listForm = new SimpleDataListForm("Виды собственности");
            listForm.ShowDialog();
        }

        private void типыКлассовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleIOManager.CurrentEntityType = SimpleIOManager.SimpleEntities.ClassType;
            SimpleDataListForm listForm = new SimpleDataListForm("Группы классов");
            listForm.ShowDialog();
        }

        private void транспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleIOManager.CurrentEntityType = SimpleIOManager.SimpleEntities.VehicleType;
            SimpleDataListForm listForm = new SimpleDataListForm("Виды транспорта");
            listForm.ShowDialog();
        }

        private void группыРаботниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleIOManager.CurrentEntityType = SimpleIOManager.SimpleEntities.EmployeeType;
            SimpleDataListForm listForm = new SimpleDataListForm("Группы работников");
            listForm.ShowDialog();
        }

        private void школыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entityType = EntityType.Schools;
            FillTable();
        }

        private void станковыйПаркToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entityType = EntityType.Tools;
            FillTable();
        }

        private void помещенияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            entityType = EntityType.Quarters;
            FillTable();
        }

        private void транспортToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            entityType = EntityType.Vehicles;
            FillTable();
        }

        private void FillTable()
        {
            bindingSource.EndEdit();
            bindingSource.DataSource = EntitiesHolder.Entities.v_employeeTypeName;
            switch (entityType)
            {
                case EntityType.Classes:
                    {
                        if (allSchools)
                        {
                            bindingSource.DataSource = EntitiesHolder.Entities.v_classes;
                        }
                        else
                        {
                            bindingSource.DataSource =
                                (from entry in EntitiesHolder.Entities.v_classes
                                 where entry.Школа == (from se in EntitiesHolder.Entities.School
                                                       where se.idSchool == schoolId
                                                       select se.nameSchool).FirstOrDefault()
                                 select entry);

                        }
                        break;
                    }
                case EntityType.Employees:
                    {
                        if (allSchools)
                        {
                            bindingSource.DataSource = EntitiesHolder.Entities.v_employees;
                        }
                        else
                        {
                            bindingSource.DataSource =
                                (from entry in EntitiesHolder.Entities.v_employees
                                 where entry.Место_работы == (from se in EntitiesHolder.Entities.School
                                                              where se.idSchool == schoolId
                                                              select se.nameSchool).FirstOrDefault()
                                 select entry);
                        }
                        break;
                    }
                case EntityType.Quarters:
                    {
                        if (allSchools)
                        {
                            bindingSource.DataSource = EntitiesHolder.Entities.v_schoolQuarters;
                        }
                        else
                        {
                            bindingSource.DataSource =
                                (from entry in EntitiesHolder.Entities.v_schoolQuarters
                                 where entry.Школа == (from se in EntitiesHolder.Entities.School
                                                       where se.idSchool == schoolId
                                                       select se.nameSchool).FirstOrDefault()
                                 select entry);

                        }
                        break;
                    }
                case EntityType.Schools:
                    {
                        if (allSchools)
                        {
                            bindingSource.DataSource = EntitiesHolder.Entities.v_schools;
                        }
                        else
                        {
                            bindingSource.DataSource =
                                (from entry in EntitiesHolder.Entities.v_schools
                                 where entry.Имя_школы == (from se in EntitiesHolder.Entities.School
                                                           where se.idSchool == schoolId
                                                           select se.nameSchool).FirstOrDefault()
                                 select entry);

                        }
                        break;
                    }
                case EntityType.Tools:
                    {
                        if (allSchools)
                        {
                            bindingSource.DataSource = EntitiesHolder.Entities.v_schoolTools;
                        }
                        else
                        {
                            bindingSource.DataSource =
                                (from entry in EntitiesHolder.Entities.v_schoolTools
                                 where entry.Школа == (from se in EntitiesHolder.Entities.School
                                                           where se.idSchool == schoolId
                                                           select se.nameSchool).FirstOrDefault()
                                 select entry);
                        }
                        break;
                    }
                case EntityType.Vehicles:
                    {
                        if (allSchools)
                        {
                            bindingSource.DataSource = EntitiesHolder.Entities.v_schoolVehicles;
                        }
                        else
                        {
                            bindingSource.DataSource =
                                (from entry in EntitiesHolder.Entities.v_schoolVehicles
                                 where entry.Школа == (from se in EntitiesHolder.Entities.School
                                                       where se.idSchool == schoolId
                                                       select se.nameSchool).FirstOrDefault()
                                 select entry);
                        }
                        break;
                    }
            }
            if (dataGridView1.RowCount == 0)
            {
                setButton.Enabled = false;
                deleteButton.Enabled = false;
            }
            else
            {
                setButton.Enabled = true;
                deleteButton.Enabled = true;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            switch (entityType)
            {
                case EntityType.Classes:
                    {
                        ClassEditForm classForm = new ClassEditForm();
                        if (!allSchools)
                        {
                            classForm.SchoolId = schoolId;
                        }
                        while (true)
                        {
                            try
                            {
                                classForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!classForm.Cancel)
                            {
                                try
                                {
                                    SchoolClassCustomEntity sc = new SchoolClassCustomEntity();
                                    sc.AddValue(
                                        classForm.SchoolId,
                                        classForm.ClassTypeId,
                                        classForm.ClassName,
                                        classForm.BoysAmount,
                                        classForm.GirlsAmount);
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Employees:
                    {
                        EmployessEditForm empForm = new EmployessEditForm();
                        if (!allSchools)
                        {
                            empForm.SchoolId = schoolId;
                        }
                        while (true)
                        {
                            try
                            {
                                empForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!empForm.Cancel)
                            {
                                try
                                {
                                    string edu = empForm.Education;
                                    EmployeeCustomEntity emp = new EmployeeCustomEntity();
                                    emp.AddValue(
                                        empForm.SchoolId,
                                        empForm.EmployeeTypeId,
                                        empForm.EmpName,
                                        empForm.Gender,
                                        empForm.Address,
                                        empForm.Education,
                                        empForm.Category,
                                        empForm.SubjectId,
                                        empForm.DistrictId);
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Quarters:
                    {
                        SchoolQuartersEditForm scForm = new SchoolQuartersEditForm();
                        if (!allSchools)
                        {
                            scForm.SchoolId = schoolId;
                        }
                        while (true)
                        {
                            try
                            {
                                scForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!scForm.Cancel)
                            {
                                try
                                {
                                    SchoolQuartersCustomEntity sc = new SchoolQuartersCustomEntity();
                                    sc.AddValue(
                                        scForm.SchoolId,
                                        scForm.QuartersTypeId,
                                        scForm.Area);
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Schools:
                    {
                        SchoolEditForm scForm = new SchoolEditForm();
                        while (true)
                        {
                            try
                            {
                                scForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!scForm.Cancel)
                            {
                                try
                                {
                                    SchoolCustomEntity sc = new SchoolCustomEntity();
                                    sc.AddValue(
                                        scForm.SchoolName,
                                        scForm.IdSPType,
                                        scForm.IdSPBType,
                                        scForm.Amount,
                                        scForm.Address,
                                        scForm.DistrictId);
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Tools:
                    {
                        SchoolToolsEditForm stForm = new SchoolToolsEditForm();
                        if (!allSchools)
                        {
                            stForm.SchoolId = schoolId;
                        }
                        while (true)
                        {
                            try
                            {
                                stForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!stForm.Cancel)
                            {
                                try
                                {
                                    SchoolToolsCustomEntity st = new SchoolToolsCustomEntity();
                                    st.AddValue(
                                        stForm.SchoolId,
                                        stForm.ToolTypeId,
                                        stForm.Amount);
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Vehicles:
                    {
                        SchoolVehiclesEditForm svForm = new SchoolVehiclesEditForm();
                        if (!allSchools)
                        {
                            svForm.idSchool = schoolId;
                        }
                        while (true)
                        {
                            try
                            {
                                svForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!svForm.Cancel)
                            {
                                try
                                {
                                    SchoolVehiclesCustomEntity sv = new SchoolVehiclesCustomEntity();
                                    sv.AddValue(
                                        svForm.idSchool,
                                        svForm.idVehicleType,
                                        svForm.Amount);
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
            }
            FillTable();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            switch (entityType)
            {
                case EntityType.Classes:
                    {
                        SchoolClass schoolClass =
                            (from sc in EntitiesHolder.Entities.SchoolClass
                             select sc).ToArray()[index];
                        ClassEditForm classForm = new ClassEditForm(
                            schoolClass.idSchool,
                            schoolClass.idClassType,
                            schoolClass.nameClass,
                            schoolClass.boysAmount,
                            schoolClass.girlsAmount);
                        while (true)
                        {
                            try
                            {
                                classForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!classForm.Cancel)
                            {
                                try
                                {
                                    SchoolClassCustomEntity sc = new SchoolClassCustomEntity();
                                    sc.SetValue(
                                        schoolClass.idClass,
                                        classForm.SchoolId,
                                        classForm.ClassTypeId,
                                        classForm.ClassName,
                                        classForm.BoysAmount,
                                        classForm.GirlsAmount);
                                }
                                catch (CapacityOverflowException)
                                {
                                    MessageBox.Show("Достигнуто предельное число записей");
                                    return;
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Employees:
                    {
                        Employee emp =
                            (from sc in EntitiesHolder.Entities.Employee
                             select sc).ToArray()[index];
                        EmployessEditForm empForm = new EmployessEditForm(
                            emp.nameEmployee,
                            emp.gender.Value,
                            emp.idSchool.Value,
                            emp.idEmployeeType.Value,
                            emp.address,
                            emp.education,
                            emp.idSubject.Value,
                            emp.rank.Value,
                            emp.idDistrict.Value);
                        while (true)
                        {
                            try
                            {
                                empForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!empForm.Cancel)
                            {
                                try
                                {
                                    EmployeeCustomEntity em = new EmployeeCustomEntity();
                                    em.SetValue(
                                        emp.idEmployee,
                                        empForm.SchoolId,
                                        empForm.EmployeeTypeId,
                                        empForm.EmpName,
                                        empForm.Gender,
                                        empForm.Address,
                                        empForm.Education,
                                        empForm.Category,
                                        empForm.SubjectId,
                                        empForm.DistrictId);
                                }
                                catch (CapacityOverflowException)
                                {
                                    MessageBox.Show("Достигнуто предельное число записей");
                                    return;
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Quarters:
                    {
                        SchoolQuarters sq =
                            (from sc in EntitiesHolder.Entities.SchoolQuarters
                             select sc).ToArray()[index];
                        SchoolQuartersEditForm sqForm = new SchoolQuartersEditForm(
                            sq.idSchool,
                            sq.idQuartersType,
                            sq.area.Value);
                        while (true)
                        {
                            try
                            {
                                sqForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!sqForm.Cancel)
                            {
                                try
                                {
                                    SchoolQuartersCustomEntity sqe = new SchoolQuartersCustomEntity();
                                    sqe.SetValue(
                                        sq.idSchool,
                                        sq.idQuartersType,
                                        sqForm.Area);
                                }
                                catch (CapacityOverflowException)
                                {
                                    MessageBox.Show("Достигнуто предельное число записей");
                                    return;
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Schools:
                    {
                        School s =
                            (from sc in EntitiesHolder.Entities.School
                             select sc).ToArray()[index];
                        SchoolEditForm sForm = new SchoolEditForm(
                            s.nameSchool,
                            s.idSchoolPropertyType.Value,
                            s.idSchoolBuildingPropertyType.Value,
                            s.computersAmount.Value,
                            s.address,
                            s.idDistrict.Value);
                        while (true)
                        {
                            try
                            {
                                sForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!sForm.Cancel)
                            {
                                try
                                {
                                    SchoolCustomEntity se = new SchoolCustomEntity();
                                    se.SetValue(
                                        s.idSchool,
                                        sForm.SchoolName,
                                        sForm.IdSPType,
                                        sForm.IdSPBType,
                                        sForm.Amount,
                                        sForm.Address,
                                        sForm.DistrictId);
                                }
                                catch (CapacityOverflowException)
                                {
                                    MessageBox.Show("Достигнуто предельное число записей");
                                    return;
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Tools:
                    {
                        SchoolTools st =
                            (from sc in EntitiesHolder.Entities.SchoolTools
                             select sc).ToArray()[index];
                        SchoolToolsEditForm stForm = new SchoolToolsEditForm(
                            st.idSchool,
                            st.idToolType,
                            st.amount.Value);
                        while (true)
                        {
                            try
                            {
                                stForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!stForm.Cancel)
                            {
                                try
                                {
                                    SchoolToolsCustomEntity ste = new SchoolToolsCustomEntity();
                                    ste.SetValue(
                                        st.idSchool,
                                        st.idToolType,
                                        stForm.Amount);
                                }
                                catch (CapacityOverflowException)
                                {
                                    MessageBox.Show("Достигнуто предельное число записей");
                                    return;
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                case EntityType.Vehicles:
                    {
                        SchoolVehicles sv =
                            (from sc in EntitiesHolder.Entities.SchoolVehicles
                             select sc).ToArray()[index];
                        SchoolVehiclesEditForm svForm = new SchoolVehiclesEditForm(
                            sv.idSchool,
                            sv.idVehicleType,
                            sv.amount.Value);
                        while (true)
                        {
                            try
                            {
                                svForm.ShowDialog();
                            }
                            catch (EmptyValueException) { }
                            if (!svForm.Cancel)
                            {
                                try
                                {
                                    SchoolVehiclesCustomEntity sve = new SchoolVehiclesCustomEntity();
                                    sve.AddValue(
                                        sv.idSchool,
                                        sv.idVehicleType,
                                        svForm.Amount);
                                }
                                catch (CapacityOverflowException)
                                {
                                    MessageBox.Show("Достигнуто предельное число записей");
                                    return;
                                }
                                catch (ValueAlreadyExistsException)
                                {
                                    MessageBox.Show("Такое значение уже есть в базе");
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
            }
            FillTable();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Все связанные записи также будут удалены. Продолжить?", "Подтвердите удаление", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                switch (entityType)
                {
                    case EntityType.Classes:
                        {
                            SchoolClass schoolClass =
                                (from sc in EntitiesHolder.Entities.SchoolClass
                                 select sc).ToArray()[index];
                            try
                            {
                                SchoolClassCustomEntity sc = new SchoolClassCustomEntity();
                                sc.DeleteValue(schoolClass.idClass);
                            }
                            catch { }
                            break;
                        }
                    case EntityType.Employees:
                        {
                            Employee emp =
                                (from sc in EntitiesHolder.Entities.Employee
                                 select sc).ToArray()[index];
                            try
                            {
                                EmployeeCustomEntity ee = new EmployeeCustomEntity();
                                ee.DeleteValue(emp.idEmployee);
                            }
                            catch { }
                            break;
                        }
                    case EntityType.Quarters:
                        {
                            SchoolQuarters sq =
                                (from sc in EntitiesHolder.Entities.SchoolQuarters
                                 select sc).ToArray()[index];
                            try
                            {
                                SchoolQuartersCustomEntity sqe = new SchoolQuartersCustomEntity();
                                sqe.DeleteValue(sq.idSchool, sq.idQuartersType);
                            }
                            catch { }
                            break;
                        }
                    case EntityType.Schools:
                        {
                            School s =
                                (from sc in EntitiesHolder.Entities.School
                                 select sc).ToArray()[index];
                            try
                            {
                                SchoolCustomEntity se = new SchoolCustomEntity();
                                se.DeleteValue(s.idSchool);
                            }
                            catch { }
                            break;
                        }
                    case EntityType.Tools:
                        {
                            SchoolTools st =
                                (from sc in EntitiesHolder.Entities.SchoolTools
                                 select sc).ToArray()[index];
                            try
                            {
                                SchoolToolsCustomEntity ste = new SchoolToolsCustomEntity();
                                ste.DeleteValue(st.idSchool, st.idToolType);
                            }
                            catch { }
                            break;
                        }
                    case EntityType.Vehicles:
                        {
                            SchoolVehicles sv =
                                (from sc in EntitiesHolder.Entities.SchoolVehicles
                                 select sc).ToArray()[index];
                            try
                            {
                                SchoolVehiclesCustomEntity sve = new SchoolVehiclesCustomEntity();
                                sve.DeleteValue(sv.idSchool, sv.idVehicleType);
                            }
                            catch { }
                            break;
                        }
                }
                FillTable();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                allSchools = true;
            }
            else
            {
                allSchools = false;
                schoolId = schoolIds[comboBox1.SelectedIndex - 1];
            }
            FillTable();
        }

        private void городскиеРайоныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleIOManager.CurrentEntityType = SimpleIOManager.SimpleEntities.District;
            SimpleDataListForm listForm = new SimpleDataListForm("Городские районы");
            listForm.ShowDialog();
        }

        private void данныеОПреподавателяхВУказанномРайонеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new TeachersInDistrictForm()).ShowDialog();
        }

        private void данныеОШколахСКомпьютернымиКлассамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ComputerSchoolsForm()).ShowDialog();
        }

        private void данныеОШколахОбучающихДо9КлассаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new NoHighClassesSchoolsForm()).ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutForm()).ShowDialog();
        }
    }
}
