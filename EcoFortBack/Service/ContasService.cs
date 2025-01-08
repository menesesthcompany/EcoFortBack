
using CRM.DataContext;
using CRM.Models;
using CRM.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Service
{
    public class ContasService : IContasInterface
    {
        private readonly ApplicationDbContext _context;

        public ContasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ContasModel>>> GetContas()
        {
            ServiceResponse<List<ContasModel>> serviceResponse = new ServiceResponse<List<ContasModel>>();

            try
            {

                serviceResponse.Dados = _context.Contas.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ContasModel>>> CreateContas(ContasModel novaConta)
        {
            ServiceResponse<List<ContasModel>> serviceResponse = new ServiceResponse<List<ContasModel>>();

            try
            {
                if (novaConta == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                novaConta.DataDeCadastro = DateTime.Now.ToLocalTime();

                _context.Add(novaConta);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Contas.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ContasModel>>> DeleteContas(int id)
        {
            ServiceResponse<List<ContasModel>> serviceResponse = new ServiceResponse<List<ContasModel>>();

            try
            {
                ContasModel colaborador = _context.Contas.FirstOrDefault(x => x.Id == id);

                if (colaborador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Contas.Remove(colaborador);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Contas.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ContasModel>> GetContasById(int id)
        {
            ServiceResponse<ContasModel> serviceResponse = new ServiceResponse<ContasModel>();

            try
            {
                ContasModel contas = _context.Contas.FirstOrDefault(x => x.Id == id);

                if (contas == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = contas;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public  async Task<ServiceResponse<List<ContasModel>>> InativaContas(int id)
        {
            ServiceResponse<List<ContasModel>> serviceResponse = new ServiceResponse<List<ContasModel>>();

            try
            {
                ContasModel contas = _context.Contas.FirstOrDefault(x => x.Id == id);

                if (contas == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Contas.Update(contas);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Contas.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ContasModel>>> UpdateContas(ContasModel editadoContas)
        {
            ServiceResponse<List<ContasModel>> serviceResponse = new ServiceResponse<List<ContasModel>>();

            try
            {
                ContasModel contas = _context.Contas.AsNoTracking().FirstOrDefault(x => x.Id == editadoContas.Id);

                if (contas == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }

                _context.Contas.Update(editadoContas);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Contas.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
