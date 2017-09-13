using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using StorageGoods.Helpers;

namespace StorageGoods
{
    public partial class StorageGoods : Form
    {
        private string folder = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData);

        private AddUsers _users;
        private AddGoods _goods;
        private Serializable _serializable = new Serializable();

        public StorageGoods()
        {
            InitializeComponent();
        }

        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _users = new AddUsers();
            if (_users.ShowDialog() == DialogResult.OK)
            {
                dgvUsers.RowCount += 1;
                dgvUsers[colName.Index, dgvUsers.RowCount - 1].Value = _users.NameUser;
                dgvUsers[colSurname.Index, dgvUsers.RowCount - 1].Value = _users.Surname;
                dgvUsers[colPhoneNumber.Index, dgvUsers.RowCount - 1].Value = _users.PhoneNumber;
                dgvUsers[colStatus.Index, dgvUsers.RowCount - 1].Value = _users.Status;
                dgvUsers[colGoods.Index, dgvUsers.RowCount - 1].Value = _users.Goods;
            }
        }

        private void AddGoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _goods = new AddGoods();
            if (_goods.ShowDialog() == DialogResult.OK)
            {
                dgvGoods.RowCount += 1;
                dgvGoods[colNameModel.Index, dgvGoods.RowCount - 1].Value = _goods.NameGood;
                dgvGoods[colBrend.Index, dgvGoods.RowCount - 1].Value = _goods.Brand;
                dgvGoods[colPrice.Index, dgvGoods.RowCount - 1].Value = _goods.Price;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void додатиПокупцяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _users = new AddUsers();
            if (_users.ShowDialog() == DialogResult.OK)
            {
                dgvUsers.RowCount += 1;
                dgvUsers[colName.Index, dgvUsers.RowCount - 1].Value = _users.NameUser;
                dgvUsers[colSurname.Index, dgvUsers.RowCount - 1].Value = _users.Surname;
                dgvUsers[colPhoneNumber.Index, dgvUsers.RowCount - 1].Value = _users.PhoneNumber;
                dgvUsers[colStatus.Index, dgvUsers.RowCount - 1].Value = _users.Status;
                dgvUsers[colGoods.Index, dgvUsers.RowCount - 1].Value = _users.Goods;
            }
        }

        private void редагуватиПокупцяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _users = new AddUsers();
            if (dgvUsers.CurrentRow != null)
            {
                _users.NameUser = dgvUsers[colName.Index, dgvUsers.CurrentRow.Index].Value.ToString();
                _users.PhoneNumber = dgvUsers[colPhoneNumber.Index, dgvUsers.CurrentRow.Index].Value.ToString();
                _users.Surname = dgvUsers[colSurname.Index, dgvUsers.CurrentRow.Index].Value.ToString();
                _users.Status = dgvUsers[colStatus.Index, dgvUsers.CurrentRow.Index].Value.ToString();
                _users.Goods = dgvUsers[colGoods.Index, dgvUsers.CurrentRow.Index].Value.ToString();
            }
            if (_users.ShowDialog() == DialogResult.OK)
            {
                if (dgvUsers.CurrentRow != null)
                {
                    dgvUsers[colName.Index, dgvUsers.CurrentRow.Index].Value = _users.NameUser;
                    dgvUsers[colSurname.Index, dgvUsers.CurrentRow.Index].Value = _users.Surname;
                    dgvUsers[colPhoneNumber.Index, dgvUsers.CurrentRow.Index].Value = _users.PhoneNumber;
                    dgvUsers[colStatus.Index, dgvUsers.CurrentRow.Index].Value = _users.Status;
                    dgvUsers[colGoods.Index, dgvUsers.CurrentRow.Index].Value = _users.Goods;
                }
            }
        }

        private void видалитиПокупцяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
                dgvUsers.Rows.Remove(dgvUsers.CurrentRow);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _goods = new AddGoods();
            if (_goods.ShowDialog() == DialogResult.OK)
            {
                dgvGoods.RowCount += 1;
                dgvGoods[colNameModel.Index, dgvGoods.RowCount - 1].Value = _goods.NameGood;
                dgvGoods[colBrend.Index, dgvGoods.RowCount - 1].Value = _goods.Brand;
                dgvGoods[colPrice.Index, dgvGoods.RowCount - 1].Value = _goods.Price;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _goods = new AddGoods();
            if (dgvGoods.CurrentRow != null)
            {
                _goods.NameGood = dgvGoods[colNameModel.Index, dgvGoods.CurrentRow.Index].Value.ToString();
                _goods.Brand = dgvGoods[colBrend.Index, dgvGoods.CurrentRow.Index].Value.ToString();
                _goods.Price = dgvGoods[colPrice.Index, dgvGoods.CurrentRow.Index].Value.ToString();
            }
            if (_goods.ShowDialog() == DialogResult.OK)
            {
                if (dgvGoods.CurrentRow != null)
                {
                    dgvGoods[colNameModel.Index, dgvGoods.CurrentRow.Index].Value = _goods.Brand;
                    dgvGoods[colBrend.Index, dgvGoods.CurrentRow.Index].Value = _goods.Brand;
                    dgvGoods[colPrice.Index, dgvGoods.CurrentRow.Index].Value = _goods.Price;
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dgvGoods.CurrentRow != null)
                dgvGoods.Rows.Remove(dgvGoods.CurrentRow);
        }

        private void StorageGoods_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(folder);
            //_serializable.DeSerializeObject<AddUsers>(fileName);
            //chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-15,15);
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(-15, 2);
            //chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            //chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //for (int i = 15; i < 2; i++)
            //{
            //    chart1.Series[0].Points.AddXY(i, Math.Pow(2, i) * Math.Sin(Math.Pow(2, i)));
            //    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //}
        }

        private void StorageGoods_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_serializable.SerializeObject<StorageGoods>(this, fileName);
        }
    }
}
