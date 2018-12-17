using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject
{
    class UserInventory
    {
        private string _name;
        private double _value;

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
