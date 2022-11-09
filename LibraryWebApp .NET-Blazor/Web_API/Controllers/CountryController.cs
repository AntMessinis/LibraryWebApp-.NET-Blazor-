using AutoMapper;
using Business.IRepository;
using Data;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            return Ok(await _countryRepository.GetAll());
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetCountryById(int? countryId)
        {
            if (countryId == null || countryId == 0)
            {
                return BadRequest(new ErrorDto()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                }) ;
            }
            var country = await _countryRepository.GetByIdAsync(countryId.Value);
            if (country == null)
            {
                return BadRequest(new ErrorDto()
                {
                    ErrorMessage = "Country was not found",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            return Ok(country);
        }
    }
}
