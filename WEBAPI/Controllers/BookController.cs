using Application.Services.Book;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add(BookCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }
        [HttpPost(nameof(Get))]
        public async Task<IActionResult> Get(BookQuery request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }
    }
}
