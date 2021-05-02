using FamilyGallery.Application.Features;
using FamilyGallery.Application.Features.Families.Commands;
using FamilyGallery.Application.Features.Families.Commands.CreateFamily;
using FamilyGallery.Application.Features.Families.Commands.DeleteFamily;
using FamilyGallery.Application.Features.Families.Commands.UpdateFamily;
using FamilyGallery.Application.Features.Families.Queries.GetFamilies;
using FamilyGallery.Application.Features.Families.Queries.GetFamiliesWithMembers;
using FamilyGallery.Application.Features.Families.Queries.GetFamily;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyGallery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly IMediator mediator;

        public FamiliesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("all/{userId}", Name ="GetUsersFamilies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateFamilyCommandResponse>> GetMyFamilies(Guid userId)
        {
            var families = await mediator.Send(new GetFamiliesQuery{ UserId = userId});
            return Ok(families);
        }

        [HttpGet("with-members/{userId}", Name = "GetUsersFamiliesWithMembers")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<FamilyVm>>> GetUsersFamiliesWithMembers(Guid userId)
        {
            var families = await mediator.Send(new GetFamiliesWithMembersQuery { UserId = userId });
            return Ok(families);
        }

        [HttpGet("{familyId}/{userId}", Name = "GetFamily")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<FamilyVm>>> GetFamily(Guid userId, Guid familyId)
        {
            var families = await mediator.Send(new GetFamilyQuery{ UserId = userId, FamilyId = familyId });
            return Ok(families);
        }

        [HttpPost(Name ="AddFamily")]
        public async Task<ActionResult<CreateFamilyCommandResponse>> Create([FromBody] CreateFamilyCommand createFamilyCommand)
        {
            var response = await mediator.Send(createFamilyCommand);
            return Ok(response);
        }

        [HttpPut(Name ="UpdateFamily")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateFamilyCommand updateFamilyCommand)
        {
            await mediator.Send(updateFamilyCommand);
            return NoContent();
        }

        [HttpDelete("{familyId}", Name = "DeleteFamily")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateFamilyCommandResponse>> Delete(Guid familyId)
        {
            await mediator.Send(new DeleteFamilyCommand { FamilyId = familyId });
            return NoContent();
        }
    }
}
