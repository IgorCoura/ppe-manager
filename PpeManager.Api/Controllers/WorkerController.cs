﻿using Microsoft.AspNetCore.Mvc;
using PpeManager.Api.Application.Commands.ClosePpePossessionProcessCommand;
using PpeManager.Api.Application.Commands.CreateWorkerCommand;
using PpeManager.Api.Application.Commands.OpenNewPpePossessionProcessCommand;

namespace PpeManager.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly IMediator _mediator;

        public WorkerController(
            IMediator mediator
            )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult<WorkerDTO>> CreateWorkerAsync([FromBody] CreateWorkerCommand createWorkerCommand, [FromHeader(Name = "x-requestid")] string requestId)
        {
            try
            {
                if(Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
                {
                    var identified = new IdentifiedCommand<CreateWorkerCommand, WorkerDTO>(createWorkerCommand, guid);
                    var result = await _mediator.Send(identified);
                    return Created("", result);
                }
                else
                {
                    return BadRequest("Invalid request Id");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            
        }

        [HttpPost("possession/close")]
        public async Task<ActionResult> closePpePossessionProcess([FromForm]IFormFile file, [FromQuery] int workerId,  [FromHeader(Name = "x-requestid")] string requestId)
        {
            try
            {
                if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
                {
                    var command = new ClosePpePossessionProcessCommand(workerId, file);
                    var identified = new IdentifiedCommand<ClosePpePossessionProcessCommand, bool>(command, guid);
                    var result = await _mediator.Send(identified);
                    return Ok();
                }
                else
                {
                    return BadRequest("Invalid request Id");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("possession/open")]
        public async Task<ActionResult<WorkerDTO>> openNewPpePossessionProcess([FromBody] OpenNewPpePossessionProcessCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            try
            {
                if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
                {
                    var identified = new IdentifiedCommand<OpenNewPpePossessionProcessCommand, WorkerDTO>(command, guid);
                    var result = await _mediator.Send(identified);
                    return Created("", result);
                }
                else
                {
                    return BadRequest("Invalid request Id");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
