using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaVanguardia2.AppServices;
using PruebaVanguardia2.Helpers;
using PruebaVanguardia2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteAppService _clienteAppService;

        public ClienteController(ClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> GetAll()
        {
            var result = _clienteAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _clienteAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(ClienteDTO item)
        {
            return Ok(await _clienteAppService.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutCiudadano(ClienteDTO item)
        {
            return Ok(await _clienteAppService.Put(item));
        }

        
        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(int id,ClienteDTO item)
        {
            return Ok(await _clienteAppService.Delete(item.Codigo));
        }
    }
}
