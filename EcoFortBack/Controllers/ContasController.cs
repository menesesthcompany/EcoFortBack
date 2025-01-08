using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using CRM.Service.Interfaces;
using CRM.Models;

namespace ColaboradoresFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContasInterface _contasInterface;
        public ContasController(IContasInterface contasInterface)
        {
            _contasInterface = contasInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ContasModel>>>> GetContas()
        {
            return Ok(await _contasInterface.GetContas());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ContasModel>>>> CreateContas(ContasModel novaConta)
        {
            return Ok(await _contasInterface.CreateContas(novaConta));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ContasModel>>>> DeleteContas(int id)
        {
            ServiceResponse<List<ContasModel>> serviceResponse = await _contasInterface.DeleteContas(id);

            return Ok(serviceResponse);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ContasModel>>> GetContasById(int id)
        {
            ServiceResponse<ContasModel> serviceResponse = await _contasInterface.GetContasById(id);

            return Ok(serviceResponse);
        }

        [HttpPut("inativaConta")]
        public async Task<ActionResult<ServiceResponse<List<ContasModel>>>> InativaContas(int id)
        {
            ServiceResponse<List<ContasModel>> serviceResponse = await _contasInterface.InativaContas(id);

            return Ok(serviceResponse);

        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ContasModel>>>> UpdateContas(ContasModel editadoContas)
        {
            ServiceResponse<List<ContasModel>> serviceResponse = await _contasInterface.UpdateContas(editadoContas);

            return Ok(serviceResponse);
        }
    }
}
