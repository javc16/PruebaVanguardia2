using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia2.Models
{
    public class Cliente
    {
        //código, nombre, fecha nacimiento, estado civil, activo
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public int Estado { get; set; }

        public sealed class Builder
        {
            private readonly Cliente _cliente;

            public Builder(int codigo,string nombre, DateTime fechaNacimiento, string estadoCivil)
            {
                _cliente = new Cliente
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    FechaNacimiento = fechaNacimiento,
                    EstadoCivil = estadoCivil,
                    Estado = 1
                };
            }            
            
            public Cliente Constuir()
            {
                return _cliente;
            }
        }
    }
}
