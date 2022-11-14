using Business.IRepository;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await _authorRepository.GetAll());
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAuthorById(int? authorId)
        {
            if (authorId == null || authorId == 0)
            {
                return BadRequest(new ErrorDto()
                {
                    ErrorMessage = "Invalid ID",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var author = await _authorRepository.GetByIdAsync(authorId.Value);

            if (author == null)
            {
                return BadRequest(new ErrorDto()
                {
                    ErrorMessage = "Author was not found",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(author);
        }
    }
}
