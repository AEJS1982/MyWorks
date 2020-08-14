using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace ADRISTORE
{
    public class BinarySerializer
    {
        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        object ByteArrayToObject(byte[] arr)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(arr);
            var auxObj = bf.Deserialize(ms);
            return auxObj;
        }

    }
}
