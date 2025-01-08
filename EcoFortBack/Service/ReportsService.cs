
using CRM.DataContext;
using CRM.Models;
using CRM.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM.Service
{
    public class ReportsService : IReportsInterface
    {
        private readonly ApplicationDbContext _context;

        public async Task<ServiceResponse<List<ReportsModel>>> GetReports()
        {
            ServiceResponse<List<ReportsModel>> serviceResponse = new ServiceResponse<List<ReportsModel>>();

            try
            {

                serviceResponse.Dados = _context.Reports.ToList();

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

        public async Task<ServiceResponse<List<ReportsModel>>> CreateReports(ReportsModel novoReport)
        {
            ServiceResponse<List<ReportsModel>> serviceResponse = new ServiceResponse<List<ReportsModel>>();

            try
            {
                if (novoReport == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoReport);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Reports.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ReportsModel>>> DeleteReports(int id)
        {
            ServiceResponse<List<ReportsModel>> serviceResponse = new ServiceResponse<List<ReportsModel>>();

            try
            {
                ReportsModel report = _context.Reports.FirstOrDefault(x => x.Id == id);

                if (report == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Reports.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ReportsModel>> GetReportsById(int id)
        {
            ServiceResponse<ReportsModel> serviceResponse = new ServiceResponse<ReportsModel>();

            try
            {
                ReportsModel report = _context.Reports.FirstOrDefault(x => x.Id == id);

                if (report == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = report;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ReportsModel>>> UpdateReports(ReportsModel editadoReport)
        {
            ServiceResponse<List<ReportsModel>> serviceResponse = new ServiceResponse<List<ReportsModel>>();

            try
            {
                ReportsModel report = _context.Reports.AsNoTracking().FirstOrDefault(x => x.Id == editadoReport.Id);

                if (report == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }

                _context.Reports.Update(editadoReport);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Reports.ToList();

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
