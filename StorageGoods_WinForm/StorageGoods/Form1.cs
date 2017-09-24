using System;
using System.IO;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using StorageGoods.Helpers;

namespace StorageGoods
{
    public partial class StorageGoods : Form
    {
        private static string _fileName = "AccountsToIB";
        private static readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{_fileName}.txt");
        private static string _contentType = "text/xml";

        private Serializable _serializable = new Serializable();
        private SaveToDrive _saveToDrive = new SaveToDrive();
        private StorageGood _storageGood = new StorageGood(); 

        public StorageGoods()
        {
            InitializeComponent();
        }

        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var users = new AddUsers();
            if (users.ShowDialog() == DialogResult.OK)
            {
                dgvUsers.RowCount += 1;
                dgvUsers[colDate.Index, dgvUsers.RowCount - 1].Value = users.Time;
                dgvUsers[colName.Index, dgvUsers.RowCount - 1].Value = users.NameUser;
                dgvUsers[colSurname.Index, dgvUsers.RowCount - 1].Value = users.Surname;
                dgvUsers[colPhoneNumber.Index, dgvUsers.RowCount - 1].Value = users.PhoneNumber;
                dgvUsers[colStatus.Index, dgvUsers.RowCount - 1].Value = users.Status;
                dgvUsers[colGoods.Index, dgvUsers.RowCount - 1].Value = users.Goods;

                var user = new Users
                {
                    Date = users.Time,
                    Name = users.NameUser,
                    GoodName = users.Goods,
                    NumberPhone = users.PhoneNumber,
                    Status = users.Status,
                    Surname = users.Surname
                };
                _storageGood.Users.Add(user);
            }
        }

        private void AddGoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var goods = new AddGoods();
            if (goods.ShowDialog() == DialogResult.OK)
            {
                dgvGoods.RowCount += 1;
                dgvGoods[colNameModel.Index, dgvGoods.RowCount - 1].Value = goods.NameGood;
                dgvGoods[colBrend.Index, dgvGoods.RowCount - 1].Value = goods.Brand;
                dgvGoods[colPrice.Index, dgvGoods.RowCount - 1].Value = goods.Price;

                var good = new Goods
                {
                    Date = DateTime.Now,
                    Name = goods.NameGood,
                    Brend = goods.Brand,
                    Price = goods.Price
                };
                _storageGood.Goods.Add(good);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void додатиПокупцяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var users = new AddUsers();
            if (users.ShowDialog() == DialogResult.OK)
            {
                dgvUsers.RowCount += 1;
                dgvUsers[colDate.Index, dgvUsers.RowCount - 1].Value = users.Time;
                dgvUsers[colName.Index, dgvUsers.RowCount - 1].Value = users.NameUser;
                dgvUsers[colSurname.Index, dgvUsers.RowCount - 1].Value = users.Surname;
                dgvUsers[colPhoneNumber.Index, dgvUsers.RowCount - 1].Value = users.PhoneNumber;
                dgvUsers[colStatus.Index, dgvUsers.RowCount - 1].Value = users.Status;
                dgvUsers[colGoods.Index, dgvUsers.RowCount - 1].Value = users.Goods;

                var user = new Users
                {
                    Date = users.Time,
                    Name = users.NameUser,
                    GoodName = users.Goods,
                    NumberPhone = users.PhoneNumber,
                    Status = users.Status,
                    Surname = users.Surname
                };
                _storageGood.Users.Add(user);
            }
        }

        private void редагуватиПокупцяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var users = new AddUsers();
            int indexUserInList = -1;
            if (dgvUsers.CurrentRow != null)
            {
                DateTime.TryParse(dgvUsers[colDate.Index, dgvUsers.RowCount - 1].Value.ToString(),out DateTime time);
                users.Time = time;
                users.NameUser = dgvUsers[colName.Index, dgvUsers.CurrentRow.Index].Value.ToString();
                users.PhoneNumber = dgvUsers[colPhoneNumber.Index, dgvUsers.CurrentRow.Index].Value.ToString();
                users.Surname = dgvUsers[colSurname.Index, dgvUsers.CurrentRow.Index].Value.ToString();
                users.Status = dgvUsers[colStatus.Index, dgvUsers.CurrentRow.Index].Value.ToString();
                users.Goods = dgvUsers[colGoods.Index, dgvUsers.CurrentRow.Index].Value.ToString();

                indexUserInList = _storageGood.Users.FindIndex(f=>f.Name == users.NameUser);
            }
            if (users.ShowDialog() == DialogResult.OK)
            {
                if (dgvUsers.CurrentRow != null)
                {
                    dgvUsers[colName.Index, dgvUsers.CurrentRow.Index].Value = users.NameUser;
                    dgvUsers[colSurname.Index, dgvUsers.CurrentRow.Index].Value = users.Surname;
                    dgvUsers[colPhoneNumber.Index, dgvUsers.CurrentRow.Index].Value = users.PhoneNumber;
                    dgvUsers[colStatus.Index, dgvUsers.CurrentRow.Index].Value = users.Status;
                    dgvUsers[colGoods.Index, dgvUsers.CurrentRow.Index].Value = users.Goods;

                    _storageGood.Users[indexUserInList].Name = users.NameUser;
                    _storageGood.Users[indexUserInList].Date = DateTime.Now;
                    _storageGood.Users[indexUserInList].GoodName = users.Goods;
                    _storageGood.Users[indexUserInList].NumberPhone = users.PhoneNumber;
                    _storageGood.Users[indexUserInList].Surname = users.Surname;
                    _storageGood.Users[indexUserInList].Status = users.Status;
                }
            }
        }

        private void видалитиПокупцяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                var name = dgvUsers[colName.Index, dgvUsers.CurrentRow.Index].Value;
                dgvUsers.Rows.Remove(dgvUsers.CurrentRow);
                _storageGood.Users.RemoveAt(_storageGood.Users.FindIndex(f => f.Name == name));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var goods = new AddGoods();
            if (goods.ShowDialog() == DialogResult.OK)
            {
                dgvGoods.RowCount += 1;
                dgvGoods[colNameModel.Index, dgvGoods.RowCount - 1].Value = goods.NameGood;
                dgvGoods[colBrend.Index, dgvGoods.RowCount - 1].Value = goods.Brand;
                dgvGoods[colPrice.Index, dgvGoods.RowCount - 1].Value = goods.Price;

                var good = new Goods
                {
                    Date = DateTime.Now,
                    Name = goods.NameGood,
                    Brend = goods.Brand,
                    Price = goods.Price
                };
                _storageGood.Goods.Add(good);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var goods = new AddGoods();
            int indexGoodInList = -1;
            if (dgvGoods.CurrentRow != null)
            {
                goods.NameGood = dgvGoods[colNameModel.Index, dgvGoods.CurrentRow.Index].Value.ToString();
                goods.Brand = dgvGoods[colBrend.Index, dgvGoods.CurrentRow.Index].Value.ToString();
                goods.Price = dgvGoods[colPrice.Index, dgvGoods.CurrentRow.Index].Value.ToString();

                indexGoodInList = _storageGood.Goods.FindIndex(f => f.Name == goods.NameGood);
            }
            if (goods.ShowDialog() == DialogResult.OK)
            {
                if (dgvGoods.CurrentRow != null)
                {
                    dgvGoods[colNameModel.Index, dgvGoods.CurrentRow.Index].Value = goods.Brand;
                    dgvGoods[colBrend.Index, dgvGoods.CurrentRow.Index].Value = goods.Brand;
                    dgvGoods[colPrice.Index, dgvGoods.CurrentRow.Index].Value = goods.Price;

                    _storageGood.Goods[indexGoodInList].Name = goods.NameGood;
                    _storageGood.Goods[indexGoodInList].Date = DateTime.Now;
                    _storageGood.Goods[indexGoodInList].Brend = goods.Brand;
                    _storageGood.Goods[indexGoodInList].Price = goods.Price;
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dgvGoods.CurrentRow != null)
            {
                var name = dgvGoods[colNameModel.Index, dgvGoods.CurrentRow.Index].Value;
                dgvGoods.Rows.Remove(dgvGoods.CurrentRow);
                _storageGood.Goods.RemoveAt(_storageGood.Goods.FindIndex(f => f.Name == name));
            }
              
        }

        private void StorageGoods_Load(object sender, EventArgs e)
        {
           _storageGood = _serializable.DeSerializeObject<StorageGood>(_filePath);
            if (_storageGood.Goods.Count != 0)
            {
                foreach (var good in _storageGood.Goods)
                {
                    dgvGoods.RowCount += 1;
                    dgvGoods[colNameModel.Index, dgvGoods.RowCount - 1].Value = good.Name;
                    dgvGoods[colBrend.Index, dgvGoods.RowCount - 1].Value = good.Brend;
                    dgvGoods[colPrice.Index, dgvGoods.RowCount - 1].Value = good.Price;
                }
            }
            if (_storageGood.Users.Count != 0)
            {
                foreach (var user in _storageGood.Users)
                {
                    dgvUsers.RowCount += 1;
                    dgvUsers[colDate.Index, dgvUsers.RowCount - 1].Value = user.Date;
                    dgvUsers[colName.Index, dgvUsers.RowCount - 1].Value = user.Name;
                    dgvUsers[colSurname.Index, dgvUsers.RowCount - 1].Value = user.Surname;
                    dgvUsers[colPhoneNumber.Index, dgvUsers.RowCount - 1].Value = user.NumberPhone;
                    dgvUsers[colStatus.Index, dgvUsers.RowCount - 1].Value = user.Status;
                    dgvUsers[colGoods.Index, dgvUsers.RowCount - 1].Value = user.GoodName;
                }
            }
        }

        private void StorageGoods_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serializable.SerializeObject<StorageGood>(_storageGood, _filePath);
            UserCredential credential = _saveToDrive.GetUserCredential();
            DriveService service = _saveToDrive.GetDriveService(credential);
            _saveToDrive.UploadFileToDrive(service, _fileName, _filePath, _contentType);
        }
    }
}
