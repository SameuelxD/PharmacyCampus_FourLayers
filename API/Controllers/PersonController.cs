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
    public class PersonController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public PersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
        {
            var auditorias = await _unitOfWork.People.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PersonDto>>(auditorias);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> Post(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            this._unitOfWork.People.Add(person);
            await _unitOfWork.SaveAsync();
            if (person == null)
            {
                return BadRequest();
            }
            personDto.Id = person.Id;
            return CreatedAtAction(nameof(Post), new { id = personDto.Id }, personDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonDto>> Get(int id)
        {
            var person = await _unitOfWork.People.GetByIdAsync(id);
            if (person == null){
                return NotFound();
            }
            return _mapper.Map<PersonDto>(person);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonDto>> Put(int id, [FromBody] PersonDto personDto)
        {
            if (personDto == null)
            {
                return NotFound();
            }
            var people = _mapper.Map<Person>(personDto);
            _unitOfWork.People.Update(people);
            await _unitOfWork.SaveAsync();
            return personDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _unitOfWork.People.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _unitOfWork.People.Remove(person);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

