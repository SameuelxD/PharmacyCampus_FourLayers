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
    public class PersonTypeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public PersonTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonTypeDto>>> Get()
        {
            var peopleTypes = await _unitOfWork.PeopleTypes.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PersonTypeDto>>(peopleTypes);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonType>> Post(PersonTypeDto personTypeDto)
        {
            var personType = _mapper.Map<PersonType>(personTypeDto);
            this._unitOfWork.PeopleTypes.Add(personType);
            await _unitOfWork.SaveAsync();
            if (personType == null)
            {
                return BadRequest();
            }
            personTypeDto.Id = personType.Id;
            return CreatedAtAction(nameof(Post), new { id = personTypeDto.Id }, personTypeDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonTypeDto>> Get(int id)
        {
            var personType = await _unitOfWork.PeopleTypes.GetByIdAsync(id);
            if (personType == null){
                return NotFound();
            }
            return _mapper.Map<PersonTypeDto>(personType);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonTypeDto>> Put(int id, [FromBody] PersonTypeDto personTypeDto)
        {
            if (personTypeDto == null)
            {
                return NotFound();
            }
            var peopleTypes = _mapper.Map<PersonType>(personTypeDto);
            _unitOfWork.PeopleTypes.Update(peopleTypes);
            await _unitOfWork.SaveAsync();
            return personTypeDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var personType = await _unitOfWork.PeopleTypes.GetByIdAsync(id);
            if (personType == null)
            {
                return NotFound();
            }
            _unitOfWork.PeopleTypes.Remove(personType);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
