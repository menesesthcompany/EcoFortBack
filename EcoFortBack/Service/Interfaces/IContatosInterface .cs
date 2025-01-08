using CRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Service.Interfaces
{
    public interface IContatosInterface
    {
        Task<ServiceResponse<List<ContatosModel>>> GetContatos();
        Task<ActionResult<ServiceResponse<List<ContatosModel>>>> CreateContatos([FromBody] ContatosModel novoContato);
        Task<ServiceResponse<ContatosModel>> GetContatosById(int id);
        Task<ServiceResponse<List<ContatosModel>>> DeleteContatos(int id);

        // Alterado para aceitar o ID e o ContatoModel
        Task<ServiceResponse<List<ContatosModel>>> UpdateContatos(int id, ContatosModel editadoContato);

        Task<ServiceResponse<List<ContatosModel>>> InativaContatos(int id);
    }
}
