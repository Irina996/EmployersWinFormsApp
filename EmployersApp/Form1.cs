using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using EmployersApp.DB;
using EmployersApp.Models;
using System.Linq;

namespace EmployersApp
{
    public partial class Form1 : Form
    {
        private List<Employers> employers = new List<Employers>();
        private List<string> checkedPosts = new List<string>();
        private bool processCheckChange = true;
        private bool firstStart = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (SqlDb.isConnectionStringNull())
            {
                EntryForm entryForm = new EntryForm();
                entryForm.Show();
                this.Hide();
                firstStart = false;
            }
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (SqlDb.isConnectionStringNull())
            {
                if (!firstStart)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                if (!SqlDb.ConfigureConnection())
                {
                    MessageBox.Show("Ошибка соединения с базой данных.");
                    Environment.Exit(0);
                }
                employers = SqlDb.getEmployers();
                LoadFilter();
            }
        }

        private void LoadFilter()
        {
            checkedListBox1.Items.Clear();
            checkedListBox1.Refresh();
            checkedListBox1.Items.Add("Все");
            foreach( Employers employer in employers)
            {
                if (!checkedListBox1.Items.Contains(employer.Post))
                {
                    checkedListBox1.Items.Add(employer.Post);
                }
            }
            processCheckChange = false;
            if (checkedPosts.Count == 0)
            {
                checkedListBox1.SetItemChecked(0, true);
                checkedPosts.Add(checkedListBox1.Items[0].ToString());
            }
            else
            {
                for(int i = 0; i < checkedPosts.Count; i++)
                {
                    int index = checkedListBox1.Items.IndexOf(checkedPosts[i]);
                    if (index == -1)
                    {
                        checkedPosts.Remove(checkedPosts[i]);
                        i--;
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(index, true);
                    }
                }
            }
            processCheckChange = true;
            if (checkedPosts.Contains("Все"))
            {
                LoadTable(employers);
            }
            else
            {
                var tableEmployers = employers.FindAll(item => matchFilter(item.Post, checkedPosts));
                LoadTable(tableEmployers);
            }
        }

        private void LoadTable(List<Employers> data)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (Employers employer in data)
            {
                dataGridView1.Rows.Add(employer.Name, employer.Surname,
                    employer.Post, employer.BirthYear, employer.Salary);
            }
        }

        private void addEmployerBtn_Click(object sender, EventArgs e)
        {
            string name = getTextInfo(nameBox, true);
            string surname = getTextInfo(surnameBox, true);
            string post = getTextInfo(postBox, true);
            int? year = getYear(true);
            float? salary = getSalary(true);
            if (name == null 
                || surname == null 
                || post == null 
                || year == null 
                || salary == null)
            {
                return;
            }

            var result = SqlDb.addEmployer(name, surname, post, (int)year, (int)salary);
            if (result)
            {
                employers.Add(new Employers
                {
                    Name = name,
                    Surname = surname,
                    Post = post,
                    BirthYear = (int)year,
                    Salary = (float)salary
                });
                LoadFilter();
                clearInput();
                MessageBox.Show("Сотрудник успешно добавлен.");
            }
            else
            {
                MessageBox.Show("Сотрудник не был добавлен.");
            }
        }

        private void deleteEmployerBtn_Click(object sender, EventArgs e)
        {
            string name = getTextInfo(nameBox, false);
            string surname = getTextInfo(surnameBox, false);
            string post = getTextInfo(postBox, false);
            int? year = getYear(false);
            float? salary = getSalary(false);
            if (name == null
                && surname == null
                && post == null
                && year == null
                && salary == null)
            {
                MessageBox.Show("Введите данные для удаления");
                return;
            }

            var result = SqlDb.removeEmployer(name, surname, post, year, salary);
            if (result)
            {
                var delEmployers = employers.FindAll(item
                    => (item.Name == name || name == null)
                    && (item.Surname == surname || surname == null)
                    && (item.Post == post || post == null)
                    && (item.BirthYear == year || year == null)
                    && (item.Salary == salary || salary == null));
                foreach (Employers delEmployer in delEmployers)
                {
                    employers.Remove(delEmployer);
                }
                LoadFilter();
                clearInput();
                MessageBox.Show("Данные успешно удалены.");
            }
            else
            {
                MessageBox.Show("Данные не были удалены.");
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (processCheckChange)
            {
                int currentIndex = e.Index;
                int[] indexes = checkedListBox1.CheckedIndices.Cast<int>().ToArray();
                if (indexes.Contains(currentIndex))
                {
                    checkedPosts.Remove(checkedListBox1.Items[currentIndex].ToString());
                }
                else
                {
                    checkedPosts.Add(checkedListBox1.Items[currentIndex].ToString());
                    if (currentIndex != 0)
                    {
                        checkedPosts.Remove(checkedListBox1.Items[0].ToString());
                        processCheckChange = false;
                        checkedListBox1.SetItemChecked(0, false);
                        processCheckChange = true;
                    }
                }
                var tableEmployers = employers.FindAll(item => matchFilter(item.Post, checkedPosts));
                LoadTable(tableEmployers);
            }
        }

        private void getReportBtn_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ex = 
                new Microsoft.Office.Interop.Excel.Application();
            ex.Visible = true;
            ex.SheetsInNewWorkbook = 1;
            Microsoft.Office.Interop.Excel.Workbook workBook = 
                ex.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet sheet = ex.Worksheets.get_Item(1);
            sheet.Cells[1, 1] = "Должность";
            sheet.Cells[1, 2] = "Средняя зарплата";

            Dictionary<string, float> report = new Dictionary<string, float>();
            for (int i = 0; i < employers.Count; i++)
            {
                try
                {
                    report[employers[i].Post] += employers[i].Salary;
                }
                catch (Exception exception)
                {
                    report.Add(employers[i].Post, employers[i].Salary);
                }
            }

            for (int i = 0; i < report.Count; i++)
            {
                string key = report.ElementAt(i).Key;
                int count = employers.FindAll(item 
                    => item.Post == key).Count;
                report[key] /= count;
                sheet.Cells[i + 2, 1] = key;
                sheet.Cells[i + 2, 2] = report[key];
            }
        }

        private bool matchFilter(string item, List<string> filters)
        {
            foreach (var filter in filters)
            {
                if (item == filter || filter == "Все")
                {
                    return true;
                }
            }
            return false;
        }

        private string getTextInfo(TextBox textBox, bool showMessage)
        {
            string text = textBox.Text;
            if (Regex.Match(text, "[a-z]|[а-я]").Length == 0)
            {
                if (showMessage)
                    MessageBox.Show("Заполните " + textBox.Name);
                return null;
            }
            return text;
        }

        private int? getYear(bool showMessage)
        {
            int year;
            try
            {
                year = Convert.ToInt32(birthYearBox.Text);
            }
            catch
            {
                if (showMessage)
                    MessageBox.Show("Год рождения должен быть числом");
                return null;
            }
            if (year < 1900 || year > DateTime.Now.Year)
            {
                if (showMessage)
                    MessageBox.Show("Некорректный год рождения");
                return null;
            }
            return year;
        }

        private float? getSalary(bool showMessage)
        {
            float salary;
            try
            {
                salary = (float)Convert.ToDouble(salaryBox.Text);
            }
            catch
            {
                if (showMessage)
                    MessageBox.Show("Зарплата должна быть числом");
                return null;
            }
            if (salary <= 0)
            {
                if (showMessage)
                    MessageBox.Show("Некорректный ввод зарплаты");
                return null;
            }
            return salary;
        }

        private void clearInput()
        {
            nameBox.Text = "";
            surnameBox.Text = "";
            postBox.Text = "";
            birthYearBox.Text = "";
            salaryBox.Text = "";
        }
    }
}
