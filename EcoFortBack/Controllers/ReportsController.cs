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
    public class ReportsController : ControllerBase
    {
        private readonly IReportsInterface _reportsInterface;
        public ReportsController(IReportsInterface reportsInterface)
        {
            _reportsInterface = reportsInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ReportsModel>>>> GetReports()
        {
            return Ok(await _reportsInterface.GetReports());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ReportsModel>>>> CreateReports(ReportsModel novoReport)
        {
            return Ok(await _reportsInterface.CreateReports(novoReport));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ReportsModel>>>> DeleteReports(int id)
        {
            ServiceResponse<List<ReportsModel>> serviceResponse = await _reportsInterface.DeleteReports(id);

            return Ok(serviceResponse);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ReportsModel>>> GetReportsById(int id)
        {
            ServiceResponse<ReportsModel> serviceResponse = await _reportsInterface.GetReportsById(id);

            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ReportsModel>>>> UpdateReports(ReportsModel editadoReport)
        {
            ServiceResponse<List<ReportsModel>> serviceResponse = await _reportsInterface.UpdateReports(editadoReport);
            return Ok(serviceResponse);
        }
    }
}
