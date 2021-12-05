using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF.ProjectService.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CF.ProjectService.Application.Features.UserFeatures.Commands;
using CF.ProjectService.Application.Features.UserFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Features.ProjectFeatures.Queries;
using CF.ProjectService.Application.Features.ProjectFeatures.Commands;
using Microsoft.Extensions.Configuration;

namespace Conceptor.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseApiController
    {
        private readonly IConfiguration _config;
        public ProjectController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet()]
        [Route("GetFilteredProject")]
        public async Task<IActionResult> GetFilteredProject([FromQuery] GetFilteredProjectsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet()]
        [Route("GetProjectAuditLog")]
        public async Task<IActionResult> GetProjectAuditLog([FromQuery] GetProjectAuditLogQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("CopyProject")]
        public async Task<IActionResult> CopyProject(CopyProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteProjectByIdCommand { Id = id }));
        }

        [HttpGet("GetProjectInfo")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProjectInfo([FromQuery] GetProjectByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("SaveProject")]
        public async Task<IActionResult> SaveProjectInfo(SaveProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("SaveWellCost")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveWellCost(SaveWellCostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("SubmitProject")]
        public async Task<IActionResult> SubmitProject(SubmitProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("ReturnProject")]
        public async Task<IActionResult> ReturnProject(ReturnProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("GetNotifications")]
        public async Task<IActionResult> GetNotifications([FromQuery] GetNotificationsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("ReadingNotification")]
        public async Task<IActionResult> ReadingNotification(ReadingNotificationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("SaveProjectAsNewRevision")]
        public async Task<IActionResult> SaveProjectAsNewRevision(SaveProjectAsNewRevisionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("UploadExcel")]

        public async Task<IActionResult> UploadExcelFile([FromForm] UploadExcelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("ParsingE&PExcel")]
        public async Task<IActionResult> ParsingEPExcelFile([FromForm] ParsingEPExcelFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }



        [HttpPost("CreateProject")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProject(CreateProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }






        [HttpPost("ApproveProject")]
        [AllowAnonymous]
        public async Task<IActionResult> ApproveProject(ApproveProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("AssignTeam")]
        [AllowAnonymous]
        public async Task<IActionResult> AssignTeam(AssignTeamCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("RejectProject")]
        public async Task<IActionResult> RejectProject(RejectProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }




        [HttpPost("UpdateProject")]
        public async Task<IActionResult> SaveProject([FromBody] UpdateProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpGet()]
        [Route("GetListStage")]
        public async Task<IActionResult> GetListDataStage()
        {
            return Ok(await Mediator.Send(new GetListStage()));
        }

        [HttpGet()]
        [Route("GetProjectById")]
        public async Task<IActionResult> GetProjectById([FromQuery] GetProjectByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        [HttpPost("SaveTeam")]
        public async Task<IActionResult> SaveTeam(SaveTeamMemberCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet()]
        [Route("GetProjectExcelDataById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProjectExcelDataById([FromQuery] GetProjectExcelDataById query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet()]
        [Route("DeleteFileByRevisionId")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteFileByRevisionId([FromQuery] DeleteFileByRevisionIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpGet()]
        [Route("GetCraData")]
        public async Task<IActionResult> GetCraData([FromQuery] GetCraDataQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("SaveDeterministicValues")]
        public async Task<IActionResult> SaveDeterministicValues(SaveProjectDeterMinisticValues command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet()]
        [Route("CreateCRAReport")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCRAReport([FromQuery] CreateReportCommand query)
        {
            query.Type = string.IsNullOrEmpty(query.Type) ? "pdf" : query.Type.ToLower();

            var stream = await Mediator.Send(query);

            string fileName = $"CRA Report {DateTime.Now.ToString("MM/dd/yyyy")}.xlsx";
            stream.Position = 0;
            if (query.Type == "pdf")
            {
                fileName = $"CRA Report {DateTime.Now.ToString("MM/dd/yyyy")}.pdf";
                return File(stream, "application/pdf", fileName);
            }
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [HttpPost()]
        [Route("DownloadCoeInputTemplate")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadCoeInputTemplate()
        {


            var stream = await Mediator.Send(new GetCoeInputTemplateQuery());

            string fileName = $"Template-CF++COEInput.xlsm";
            stream.Position = 0;

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

    }


}
