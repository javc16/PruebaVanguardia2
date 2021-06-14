using PruebaVanguardia2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia2.Domain
{
    public class ClienteDomainService
    {
        public string ValidarCodigo(int codigo)
        {
            if (codigo==0)
            {
                return Constantes.CampoObligatorio + "codigo";
            }

            return Constantes.ValidacionConExito;
        }

        public string ValidarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return Constantes.CampoObligatorio + "nombre";
            }

            return Constantes.ValidacionConExito;
        }
    }
}
