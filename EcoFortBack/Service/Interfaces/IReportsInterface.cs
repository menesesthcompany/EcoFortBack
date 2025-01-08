using CRM.Models;

namespace CRM.Service.Interfaces
{
    public interface IReportsInterface
    {
        Task<ServiceResponse<List<ReportsModel>>> GetReports();
        Task<ServiceResponse<List<ReportsModel>>> CreateReports(ReportsModel novoReport);
        Task<ServiceResponse<ReportsModel>> GetReportsById(int id);
        Task<ServiceResponse<List<ReportsModel>>> DeleteReports(int id);
        Task<ServiceResponse<List<ReportsModel>>> UpdateReports(ReportsModel editadoReport);
    }
}
