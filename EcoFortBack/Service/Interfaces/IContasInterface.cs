using CRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Service.Interfaces
{
    public interface IContasInterface
    {
        Task<ServiceResponse<List<ContasModel>>> GetContas();
        Task<ServiceResponse<List<ContasModel>>> CreateContas(ContasModel novaConta);
        Task<ServiceResponse<ContasModel>> GetContasById(int id);
        Task<ServiceResponse<List<ContasModel>>> DeleteContas(int id);
        Task<ServiceResponse<List<ContasModel>>> UpdateContas(ContasModel editadoContas);
        Task<ServiceResponse<List<ContasModel>>> InativaContas(int id);
    }
}
