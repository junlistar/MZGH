using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassLib
{

    public class COMInfo
    {
        public object Instance;
        public Type COMType;
        public COMInfo(Type type, object instance)
        {
            this.Instance = instance;
            this.COMType = type;
        }
    }

}