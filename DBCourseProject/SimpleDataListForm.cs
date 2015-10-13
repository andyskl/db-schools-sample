using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DBCourseProject
{
    public partial class SimpleDataListForm : DataOutput
    {
        object dataSource;

        public SimpleDataListForm()
        {
            InitializeComponent();
            AssignList(listBox);
            AssignAddButton(addButton);
            AssignSetButton(setButton);
            AssignDeleteButton(deleteButton);
            DataSource = SimpleIOManager.CurrentEntity.Values;
            base.InitializeComponent();
        }

        public SimpleDataListForm(string header)
            : this()
        {
            this.Text = header;
        }

        protected override void OutputData()
        {
            listBox.OutputData(dataSource);
            CheckButtons();
        }

        public object DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                dataSource = value;
                OutputData();
            }
        }

        protected override void HandleAddButtonClick(object sender, EventArgs e)
        {
            SimpleInputForm inputForm = new SimpleInputForm();
            while (true)
            {
                inputForm.ShowDialog();
                try
                {
                    SimpleIOManager.CurrentEntity.Add(inputForm.Value);
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
                catch (EmptyValueException)
                {
                    return;
                }
                catch (LongArgumentException)
                {
                    MessageBox.Show("Слишком длинная строка");
                    continue;
                }
                break;
            }
            SimpleIOManager.CurrentEntity.Apply();
            DataSource = SimpleIOManager.CurrentEntity.Values;
        }

        protected override void HandleSetButtonClick(object sender, EventArgs e)
        {
            string oldvalue = listBox.GetItemText(listBox.SelectedItem);
            SimpleInputForm inputForm = new SimpleInputForm(oldvalue);
            while (true)
            {
                inputForm.ShowDialog();
                try
                {
                    SimpleIOManager.CurrentEntity.Set(oldvalue, inputForm.Value);
                }
                catch (ValueAlreadyExistsException)
                {
                    MessageBox.Show("Такое значение уже есть в базе");
                    continue;
                }
                catch (NoSuchValueException)
                {
                    MessageBox.Show("Невозможно найти элемент с таким значением");
                    return;
                }
                catch (EmptyValueException)
                {
                    return;
                }
                catch (LongArgumentException)
                {
                    MessageBox.Show("Слишком длинная строка");
                    continue;
                }
                break;
            }

            SimpleIOManager.CurrentEntity.Apply();
            DataSource = SimpleIOManager.CurrentEntity.Values;
        }

        protected override void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Все связанные записи также будут удалены. Продолжить?", "Подтвердите удаление", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                string value = listBox.GetItemText(listBox.SelectedItem);
                try
                {
                    SimpleIOManager.CurrentEntity.Delete(value);
                }
                catch (NoSuchValueException)
                {
                    MessageBox.Show("Невозможно найти элемент с таким значением");
                    return;
                }
                catch (EmptyValueException)
                {
                    return;
                }
                SimpleIOManager.CurrentEntity.Apply();
                DataSource = SimpleIOManager.CurrentEntity.Values;
            }
            else
            {
                return;
            }            
        }
    }
}
