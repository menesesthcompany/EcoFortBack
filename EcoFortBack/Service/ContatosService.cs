
using CRM.DataContext;
using CRM.Enums;
using CRM.Models;
using CRM.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Service
{
    public class ContatosService : IContatosInterface
    {
        private readonly ApplicationDbContext _context;
        public ContatosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ContatosModel>>> GetContatos()

        {
            ServiceResponse<List<ContatosModel>> serviceResponse = new ServiceResponse<List<ContatosModel>>();

            try
            {

                serviceResponse.Dados = _context.Contatos.ToList();

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

        public async Task<ActionResult<ServiceResponse<List<ContatosModel>>>> CreateContatos([FromBody] ContatosModel novoContato)
        {
            ServiceResponse<List<ContatosModel>> serviceResponse = new ServiceResponse<List<ContatosModel>>();

            try
            {
                if (novoContato == null)
                {
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                // Verifica se os valores de Sexo e Cargo são válidos
                if (!Enum.IsDefined(typeof(Sexo), novoContato.Sexo) || 
                    !Enum.IsDefined(typeof(Cargo), novoContato.Cargo))
                {
                    serviceResponse.Mensagem = "Cargo ou Sexo inválidos!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                novoContato.DataDeCadastro = DateTime.Now.ToLocalTime();

                // Adiciona ao banco
                _context.Add(novoContato);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Contatos.ToList();
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }




        public async Task<ServiceResponse<List<ContatosModel>>> DeleteContatos(int id)
        {
            ServiceResponse<List<ContatosModel>> serviceResponse = new ServiceResponse<List<ContatosModel>>();

            try
            {
                ContatosModel contato = _context.Contatos.FirstOrDefault(x => x.Id == id);

                if (contato == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Contatos.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<ContatosModel>> GetContatosById(int id)
        {
            ServiceResponse<ContatosModel> serviceResponse = new ServiceResponse<ContatosModel>();

            try
            {
                ContatosModel contato = _context.Contatos.FirstOrDefault(x => x.Id == id);

                if (contato == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = contato;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ContatosModel>>> InativaContatos(int id)
        {
            ServiceResponse<List<ContatosModel>> serviceResponse = new ServiceResponse<List<ContatosModel>>();

            try
            {
                ContatosModel contato = _context.Contatos.FirstOrDefault(x => x.Id == id);

                if (contato == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Contatos.Update(contato);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Contatos.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ContatosModel>>> UpdateContatos(int id, ContatosModel editadoContato)
        {
            ServiceResponse<List<ContatosModel>> serviceResponse = new ServiceResponse<List<ContatosModel>>();

            try
            {
                ContatosModel contato = _context.Contatos.AsNoTracking().FirstOrDefault(x => x.Id == editadoContato.Id);

                if (contato == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }

                _context.Contatos.Update(editadoContato);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Contatos.ToList();

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
