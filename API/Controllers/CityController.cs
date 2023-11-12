using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CityController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public CityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CityDto>>> Get()
        {
            var cities = await _unitOfWork.Cities.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<CityDto>>(cities);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<City>> Post(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            this._unitOfWork.Cities.Add(city);
            await _unitOfWork.SaveAsync();
            if (city == null)
            {
                return BadRequest();
            }
            cityDto.Id = city.Id;
            return CreatedAtAction(nameof(Post), new { id = cityDto.Id }, cityDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDto>> Get(int id)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            if (city == null){
                return NotFound();
            }
            return _mapper.Map<CityDto>(city);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityDto>> Put(int id, [FromBody] CityDto cityDto)
        {
            if (cityDto == null)
            {
                return NotFound();
            }
            var cities = _mapper.Map<City>(cityDto);
            _unitOfWork.Cities.Update(cities);
            await _unitOfWork.SaveAsync();
            return cityDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            _unitOfWork.Cities.Remove(city);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
