using Microsoft.AspNetCore.Mvc;
using ParcelCalculator.DTOs;
using ParcelCalculator.Enums;
using ParcelCalculator.Exceptions;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelController : Controller
    {
        private readonly ICostService _costService;
        private readonly ICategoryService _categoryService;

        public ParcelController(ICostService costService, ICategoryService categoryService)
        {
            _costService = costService;
            _categoryService = categoryService;
        }

        [HttpPost(Name = "GetParcelDetails")]
        public GetParcelResponseDto GetParcelDetails(GetParcelRequestDto dto)
        {
            var weight = dto.Weight;
            var width = dto.Width;
            var height = dto.Height;
            var depth = dto.Depth;

            if (weight == 0 && width == 0 && height == 0 && depth == 0)
            {
                throw new ParameterValidationException("All values cannot be 0");
            }

            if (weight < 0 || width < 0 || height < 0 || depth < 0)
            {
                throw new ParameterValidationException("Values cannot be negative");
            }

            var volume = dto.Width * dto.Height * dto.Depth;
            var category = _categoryService.GetCategory(dto.Weight, volume);
            var cost = _costService.GetCost(category, weight, volume);

            var categoryString = $"{category} Parcel";
            if (category == Category.Reject)
            {
                categoryString = "Rejected";
            }

            var response = new GetParcelResponseDto()
            {
                Category = categoryString,
                Cost = cost
            };

            return response;
        }
    }
}
