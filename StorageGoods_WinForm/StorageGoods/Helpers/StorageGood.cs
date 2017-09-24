using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageGoods.Helpers
{
    public class StorageGood
    {
        public List<Goods> Goods { get; set; }
        public List<Users> Users { get; set; }

        public StorageGood()
        {
            Goods = new List<Goods>();
            Users = new List<Users>();
        }
    }
}
