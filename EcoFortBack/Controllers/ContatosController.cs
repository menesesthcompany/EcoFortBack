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
    public class ContatosController : ControllerBase
    {
        private readonly IContatosInterface _contatosInterface;
        public ContatosController(IContatosInterface contatosInterface)
        {
            _contatosInterface = contatosInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ContatosModel>>>> GetContatos()
        {
            return Ok(await _contatosInterface.GetContatos());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ContatosModel>>>> CreateContatos(ContatosModel novoCadastro)
        {
            return Ok(await _contatosInterface.CreateContatos(novoCadastro));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ContatosModel>>>> DeleteContatos(int id)
        {
            ServiceResponse<List<ContatosModel>> serviceResponse = await _contatosInterface.DeleteContatos(id);

            return Ok(serviceResponse);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ContatosModel>>> GetContasById(int id)
        {
            ServiceResponse<ContatosModel> serviceResponse = await _contatosInterface.GetContatosById(id);

            return Ok(serviceResponse);
        }

        [HttpPut("inativaConta")]
        public async Task<ActionResult<ServiceResponse<List<ContatosModel>>>> InativaContatos(int id)
        {
            ServiceResponse<List<ContatosModel>> serviceResponse = await _contatosInterface.InativaContatos(id);

            return Ok(serviceResponse);

        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ContatosModel>>>> UpdateContatos(int id, ContatosModel editadoContato)
        {
            // Chama a interface para atualizar o contato
            var response = await _contatosInterface.UpdateContatos(id, editadoContato);
            return Ok(response);
        }


    }
}
