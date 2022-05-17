using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    [Serializable]
    public class ComboxItem
    {
        private string _Name = "";
        private object _Value = null;

        public ComboxItem()
        {

        }

        public ComboxItem(string name, object value)
        {
            _Name = name;
            _Value = value;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }
}
