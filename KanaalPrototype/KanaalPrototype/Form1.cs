using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanaalPrototype
{
    public partial class Form1 : Form
    {
        public List<string> Users;

        public Form1()
        {
            InitializeComponent();
            Users = new List<string>();
            Users.Add("Kees");
            Users.Add("Henk");
            Users.Add("Piet");
            Users.Add("Jan");
            Users.Add("Gertrude");
            Users.Add("fcgvhbnjkmnjbhjvgc");
            foreach (string user in Users)
            {
                cbAllUsers.Items.Add(user);
            }
            tbChannel.Visible = false;
            btnInsert.Visible = false;
            lbChannels.Visible = false;
            btnSave.Visible = false;

        }

        private void btnEditChannel_Click(object sender, EventArgs e)
        {
            lbEditName.Visible = true;
            lbEditDescription.Visible = true;
            tbDescription.Visible = true;
            tbName.Visible = true;
            btnSaveEdit.Visible = true;
            cbAllUsers.Visible = true;
            cbUsersRemove.Visible = true;
            btnAddUser.Visible = true;
            btnRemoveUser.Visible = true;

            tbName.Text = lbName.Text;
            tbDescription.Text = lbDescription.Text;
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbDescription.Text == "")
            {
                MessageBox.Show("Please fill in the boxes!");
            } else
            {
                lbDescription.Text = tbDescription.Text;
                lbName.Text = tbName.Text;
                lbEditName.Visible = false;
                lbEditDescription.Visible = false;
                tbDescription.Visible = false;
                tbName.Visible = false;
                btnSaveEdit.Visible = false;
                cbAllUsers.Visible = false;
                cbUsersRemove.Visible = false;
                btnAddUser.Visible = false;
                btnRemoveUser.Visible = false;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            lbUsers.Items.Add(cbAllUsers.SelectedItem);
            cbUsersRemove.Items.Add(cbAllUsers.SelectedItem);
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            lbUsers.Items.Remove(cbUsersRemove.SelectedItem);
            cbUsersRemove.Items.Remove(cbUsersRemove.SelectedItem);
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            int id = 0;
            string Name = tbChannel.Text;
            Channel channels1 = new Channel(Name, id);
            channels1.MakeChannel(Name);
            lbChannels.DataSource = null;
            lbChannels.Items.Add(channels1.Name);
            tbChannel.Text = string.Empty;
        }

        private void btnAddChannel_Click(object sender, EventArgs e)
        {
            tbChannel.Visible = true;
            btnInsert.Visible = true;
            lbChannels.Visible = true;
            btnSave.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tbChannel.Visible = false;
            btnInsert.Visible = false;
            lbChannels.Visible = false;
            btnSave.Visible = false;
        }
    }
}
