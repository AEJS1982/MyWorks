using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend
{
    public class ObjectCopier
    {
        public void Copy(object o1, object o2) {
            foreach (var prop in o1.GetType().GetProperties())
            {
                prop.SetValue(o2, prop.GetValue(o1));
            }
        }
    }
}
