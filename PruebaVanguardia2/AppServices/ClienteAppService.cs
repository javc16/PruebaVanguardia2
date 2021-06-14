using Microsoft.EntityFrameworkCore;
using PruebaVanguardia2.Domain;
using PruebaVanguardia2.Helpers;
using PruebaVanguardia2.Models.DTO;
using PruebaVanguardiaDos.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia2.AppServices
{
    public class ClienteAppService
    {
        private readonly CliContext _context;
        private readonly ClienteDomainService _clienteDomainService;

        public ClienteAppService(CliContext context, ClienteDomainService clienteDomainService)
        {
            _context = context;
            _clienteDomainService = clienteDomainService;
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            var clientes = _context.Cliente.Where(x => x.Estado == Constantes.Activo);
            var clientesDTO = ClienteDTO.DeModeloADTO(clientes);
            return clientesDTO;
        }

        public async Task<Response> GetById(long codigo)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(r => r.Codigo == codigo);
            if (cliente == null)
            {
                return new Response { Mensaje = "Este cliente no existe" };
            }
            var data = ClienteDTO.DeModeloADTO(cliente);
            return new Response { Datos = data };
        }

        public async Task<Response> Post(ClienteDTO cliente)
        {
            string mensaje = _clienteDomainService.ValidarCodigo(cliente.Codigo);
            if (!mensaje.Equals(Constantes.ValidacionConExito))
            {
                return new Response { Mensaje = mensaje };
            }

            var SavedUser = await _context.Cliente.FirstOrDefaultAsync(r => r.Codigo == cliente.Codigo);
            if (SavedUser != null)
            {
                return new Response { Mensaje = "Este cliente ya existe en el sistema" };
            }
            var clienteAGuardar=ClienteDTO.DeDTOAModelo(cliente);
            _context.Cliente.Add(clienteAGuardar);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Cliente agregado correctamente" };
        }

        public async Task<Response> Put(ClienteDTO cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Cliente {cliente.Nombre} modificado correctamente" };
        }

        public async Task<Response> Delete(int codigo)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(x=>x.Codigo==codigo);
            if (cliente == null)
            {
                return new Response { Mensaje = $"No tenemos un cliente con codigo {codigo}" }; ;
            }
            cliente.Estado = Constantes.Inactivo;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Cliente {cliente.Nombre} eliminado correctamente" };
        }
    }
}
