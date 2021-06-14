using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia2.Models.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public int Estado { get; set; }


        public static ClienteDTO DeModeloADTO(Cliente cliente)
        {
            return cliente != null ? new ClienteDTO
            {
                Id = cliente.Id,
                Codigo = cliente.Codigo,
                Nombre = cliente.Nombre,
                FechaNacimiento = cliente.FechaNacimiento,
                EstadoCivil = cliente.EstadoCivil,
                Estado = cliente.Estado
            } : null;
        }

        public static IEnumerable<ClienteDTO> DeModeloADTO(IEnumerable<Cliente> cliente)
        {
            if (cliente == null)
            {
                return new List<ClienteDTO>();
            }
            List<ClienteDTO> clienteData = new List<ClienteDTO>();

            foreach (var item in cliente)
            {
                clienteData.Add(DeModeloADTO(item));
            }

            return clienteData;
        }


        public static Cliente DeDTOAModelo(ClienteDTO clienteDTO)
        {
            return clienteDTO != null ? new Cliente.Builder(clienteDTO.Codigo,clienteDTO.Nombre,clienteDTO.FechaNacimiento,clienteDTO.EstadoCivil).Constuir() : null;
        }
    }
}
