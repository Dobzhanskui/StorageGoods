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
    public partial class AddGoods : Form
    {
        #region Members

        

        #endregion
        public AddGoods()
        {
            InitializeComponent();
        }

        #region Properties
        

        public string NameGood
        {
            get => txtName.Text;
            set { txtName.Text = value; }
        }

        public string Brand
        {
            get => txtBrend.Text;
            set { txtBrend.Text = value; }
        }

        public string Price
        {
            get => txtPrice.Text;
            set { txtPrice.Text = value; }
        }

        #endregion

        private void AddGoods_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
