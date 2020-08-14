using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.BE
{
    public class DTODatosTarjeta
    {
        private String _NroTarjeta;
        private String _TipoTarjeta;
        private String _CodigoVerificacion;

        public string NroTarjeta
        {
            get
            {
                return _NroTarjeta;
            }

            set
            {
                _NroTarjeta = value;
            }
        }

        public string TipoTarjeta
        {
            get
            {
                return _TipoTarjeta;
            }

            set
            {
                _TipoTarjeta = value;
            }
        }

        public string CodigoVerificacion
        {
            get
            {
                return _CodigoVerificacion;
            }

            set
            {
                _CodigoVerificacion = value;
            }
        }
    }
}
