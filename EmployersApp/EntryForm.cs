using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using EmployersApp.DB;

namespace EmployersApp
{
    public partial class EntryForm : Form
    {
        public EntryForm()
        {
            InitializeComponent();
        }

        private void EntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form1 = Application.OpenForms[0];
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = getTextInfo(serverBox, true);
            string database = getTextInfo(databaseBox, true);
            string table = getTextInfo(tableBox, false);
            string username = getTextInfo(usernameBox, false);
            string password = getTextInfo(passwordBox, false);
            if (server != null && database != null)
            {
                SqlDb.SetConnectionString(server, database, username, password);
                SqlDb.SetTableName(table);
                this.Close();
            }
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
    }
}
