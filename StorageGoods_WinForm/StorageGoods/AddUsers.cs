using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageGoods
{
    public partial class AddUsers : Form
    {
        public AddUsers()
        {
            InitializeComponent();
        }

        #region Properties

        public DateTime Time => DateTime.Now;

        public string NameUser
        {
            get => txtName.Text;
            set { txtName.Text = value; }
        }

        public string Surname
        {
            get => txtSurname.Text;
            set { txtSurname.Text = value; }
        }

        public string PhoneNumber
        {
            get => txtPhoneNumber.Text;
            set { txtPhoneNumber.Text = value; }
        }

        public string Goods
        {
            get => txtGoods.Text;
            set { txtGoods.Text = value; }
        }

        public string Status
        {
            get => txtStatus.Text;
            set { txtStatus.Text = value; }
        }

        #endregion

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
