using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADRISTORE.Entities
{
    public class Error
    {
        private int _Code;
        private String _Message;

        public int Code { get => _Code; set => _Code = value; }
        public string Message { get => _Message; set => _Message = value; }
    }
}
