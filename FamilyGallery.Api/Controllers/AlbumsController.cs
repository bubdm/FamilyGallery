using FamilyGallery.Application.Features.Albums.Commands.CreateAlbum;
using FamilyGallery.Application.Features.Albums.Commands.DeleteAlbum;
using FamilyGallery.Application.Features.Albums.Commands.ShareAlbum;
using FamilyGallery.Application.Features.Albums.Commands.UnshareAlbum;
using FamilyGallery.Application.Features.Albums.Commands.UpdateAlbum;
using FamilyGallery.Application.Features.Albums.Queries.GetAlbum;
using FamilyGallery.Application.Features.Albums.Queries.GetAlbums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FamilyGallery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly Mediator mediator;

        public AlbumsController(Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("all/{userId}", Name = "GetAlbums")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAlbumsQueryResponse>> GetAlbums(Guid userId)
        {
            var result = await mediator.Send(new GetAlbumsQuery { UserId = userId });
            return Ok(result);
        }

        [HttpGet("all/{albumId}/{userId}", Name = "GetAlbum")]
        public async Task<ActionResult<GetAlbumQueryResponse>> GetAlbum(Guid userId, Guid albumId)
        {
            var result = await mediator.Send(new GetAlbumQuery { UserId = userId, AlbumId = albumId });
            return Ok(result);
        }

        [HttpPost(Name = "AddAlbum")]
        public async Task<ActionResult<CreateAlbumCommandResponse>> Create([FromBody] CreateAlbumCommand createAlbumCommand)
        {
            var response = await mediator.Send(createAlbumCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateAlbum")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreateAlbumCommandResponse>> Update([FromBody] UpdateAlbumCommand updateAlbumCommand)
        {
            var response = await mediator.Send(updateAlbumCommand);
            return NoContent();
        }

        [HttpDelete("{albumId}/{userId}", Name = "DeleteAlbum")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreateAlbumCommandResponse>> Update(Guid albumId, Guid userId)
        {
            var response = await mediator.Send(new DeleteAlbumCommand { AlbumId = albumId, DeleterId = userId });
            return NoContent();
        }

        [HttpPost(Name ="Share")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Share([FromBody] ShareAlbumCommand shareAlbumCommand)
        {
            var response = await mediator.Send(shareAlbumCommand);
            return Ok(response);
        }

        [HttpPost(Name = "ShareWithFamily")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Unshare([FromBody] UnshareAlbumCommand unshareAlbumCommand)
        {
            var response = await mediator.Send(unshareAlbumCommand);
            return Ok(response);
        }
    }
}
