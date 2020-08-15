using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.BE
{
    public class DTODatosComprador
    {
        private String _Nombre;
        private String _Apellido;
        private DTODatosTarjeta _DatosTarjeta;
        private DateTime _FechaEntrega;
        private String _LugarEntrega;

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return _Apellido;
            }

            set
            {
                _Apellido = value;
            }
        }

        public DTODatosTarjeta DatosTarjeta
        {
            get
            {
                if (_DatosTarjeta == null)
                    _DatosTarjeta = new DTODatosTarjeta();

                return _DatosTarjeta;
            }

            set
            {
                _DatosTarjeta = value;
            }
        }

        public DateTime FechaEntrega
        {
            get
            {
                return _FechaEntrega;
            }

            set
            {
                _FechaEntrega = value;
            }
        }

        public string LugarEntrega
        {
            get
            {
                return _LugarEntrega;
            }

            set
            {
                _LugarEntrega = value;
            }
        }
    }
}
