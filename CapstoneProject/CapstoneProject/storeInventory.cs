using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject
{
    class StoreInventory
    {
        private string _name;
        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ItemInfo()
        {
            string itemInfo;

            itemInfo = _name;

            return itemInfo;
        }


        public StoreInventory()
        {

        }

    }
}
