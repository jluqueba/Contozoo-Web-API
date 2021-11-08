using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo.Resources.Animals
{
	[ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
	{
        private readonly IMapper _mapper;

        private readonly AnimalsContext _context;

        public AnimalsController(IMapper mapper,
            AnimalsContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(context));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet(Name = "GetAnimals")]
        public async Task<ActionResult<PagedResponse<AnimalDTO>>> GetAnimals(int page, int limit)
        {
            var animals = await _context.Animals
                .ProjectTo<AnimalDTO>(_mapper.ConfigurationProvider)
                .PaginateAsync(page, limit);

            return Ok(GeneratePageLinks(limit, page, animals));
        }

        [HttpGet("{cai}", Name = "GetAnimalByCAI")]
        public async Task<ActionResult<AnimalDTO>> GetAnimalByCAI(long cai)
        {
            var animal = await _context.Animals
				.ProjectTo<AnimalDTO>(_mapper.ConfigurationProvider)
                .Where(a => a.CAI == cai)
                .FirstOrDefaultAsync();

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpPut("{cai}")]
        public async Task<IActionResult> UpdateTodoItem(long cai, AnimalDTO animalDTO)
        {
            if (cai != animalDTO.CAI)
                return BadRequest("Inconsistent CAI");

            var animal = await _context.Animals
                .Where(a => a.CAI == cai)
                .FirstOrDefaultAsync();

            if (animal == null)
                return NotFound();
                    
            _mapper.Map(animalDTO, animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AnimalDTO>> CreateAnimal(AnimalDTO animalDTO)
        {
            var cai = animalDTO.CAI;

            var animalExists = await _context.Animals
                .AnyAsync(a => a.CAI == cai);
            if (animalExists)
                return new BadRequestObjectResult("There is an animal with the same CAI");

            var animal = _mapper.Map<AnimalItem>(animalDTO);

            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnimalByCAI),
                new { cai = animal.CAI },
                animalDTO);
        }

        [HttpDelete("{cai}")]
        public async Task<IActionResult> DeleteAnimal(long cai)
        {
            var animal = await _context.Animals
                .Where(a => a.CAI == cai)
                .FirstOrDefaultAsync();

            if (animal == null)
                return NotFound();

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{cai}")]
        public async Task<IActionResult> UpdateName(long cai, string name)
		{
            var animal = await _context.Animals
                .Where(a => a.CAI == cai)
                .FirstOrDefaultAsync();

            if (animal == null)
                return NotFound();

            animal.Name = name;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private PagedResponse<AnimalDTO> GeneratePageLinks(int limit, int page, PagedResponse<AnimalDTO> response)
        {
            if (response.CurrentPage > 1)
            {
                var prevRoute = Url.RouteUrl(nameof(GetAnimals), new { limit = limit, page = page - 1 });
                response.AddResourceLink(LinkedResourceType.Prev, prevRoute);
            }

            if (response.CurrentPage < response.TotalPages)
            {
                var nextRoute = Url.RouteUrl(nameof(GetAnimals), new { limit = limit, page = page + 1 });
                response.AddResourceLink(LinkedResourceType.Next, nextRoute);
            }

            return response;
        }
    }
}
