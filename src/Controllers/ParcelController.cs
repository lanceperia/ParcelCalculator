using Microsoft.AspNetCore.Mvc;
using ParcelCalculator.DTOs;
using ParcelCalculator.Entities;
using ParcelCalculator.Exceptions;
using ParcelCalculator.Interfaces;

namespace ParcelCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelController : Controller
    {
        private readonly ICostService _costService;

        public ParcelController(ICostService costService)
        {
            _costService = costService;
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

            var parcel = new Parcel()
            {
                Depth = depth,
                Height = height,
                Weight = weight,
                Width = width
            };
            var cost = _costService.GetCost(parcel);

            var response = new GetParcelResponseDto()
            {
                Category = parcel.Category,
                Cost = cost 
            };

            return response;
        }
    }
}
