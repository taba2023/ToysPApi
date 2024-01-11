using Microsoft.AspNetCore.Mvc;
using ToysP.Filters;
using ToysP.Filters.ActionFilters;
using ToysP.Filters.ExceptionFilters;
using ToysP.Models;
using ToysP.Models.Repositories;

namespace ToysP.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class ToysController: ControllerBase
    {
        [HttpGet]
       
        public IActionResult GetToys()
        {
            return Ok(ToyRepository.GetToys());
        }

        [HttpGet("{id}")]
        [Toy_ValidateToyIdFilter]
        public IActionResult GetToyById(int id)
        {
            return Ok(ToyRepository.GetToyById(id));
        }

        [HttpPost]
        [Toy_ValidateCreateToyFilter]
        public IActionResult CreateToy([FromBody]Toy toy)
        {
           

            ToyRepository.AddToy(toy);

            return CreatedAtAction(nameof(GetToyById),
                new { id = toy.ToyId },
                toy);
        } 

        [HttpPut("{id}")]
        [Toy_ValidateToyIdFilter]
        [Toy_ValidateUpdateToyFilter]
        [Toy_HandleUpdateExceptionsFilter]
        public IActionResult UpdateToy(int id, Toy toy)
        {
            
            ToyRepository.UpdateToy(toy);
          
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Toy_ValidateToyIdFilter]

        public IActionResult DeleteToy(int id)
        {
            var toy = ToyRepository.GetToyById(id);
            ToyRepository.DeleteToy(id);

            return Ok("Deleting a toy: {id}");
        }
    }
}
