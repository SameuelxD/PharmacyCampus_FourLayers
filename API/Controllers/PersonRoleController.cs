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
    public class PersonRoleController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public PersonRoleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonRoleDto>>> Get()
        {
            var peopleRoles = await _unitOfWork.PeopleRoles.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PersonRoleDto>>(peopleRoles);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonRole>> Post(PersonRoleDto personRoleDto)
        {
            var personRole = _mapper.Map<PersonRole>(personRoleDto);
            this._unitOfWork.PeopleRoles.Add(personRole);
            await _unitOfWork.SaveAsync();
            if (personRole == null)
            {
                return BadRequest();
            }
            personRoleDto.Id = personRole.Id;
            return CreatedAtAction(nameof(Post), new { id = personRoleDto.Id }, personRoleDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonRoleDto>> Get(int id)
        {
            var personRole = await _unitOfWork.PeopleRoles.GetByIdAsync(id);
            if (personRole == null){
                return NotFound();
            }
            return _mapper.Map<PersonRoleDto>(personRole);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonRoleDto>> Put(int id, [FromBody] PersonRoleDto personRoleDto)
        {
            if (personRoleDto == null)
            {
                return NotFound();
            }
            var peopleRoles = _mapper.Map<PersonRole>(personRoleDto);
            _unitOfWork.PeopleRoles.Update(peopleRoles);
            await _unitOfWork.SaveAsync();
            return personRoleDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var personRole = await _unitOfWork.PeopleRoles.GetByIdAsync(id);
            if (personRole == null)
            {
                return NotFound();
            }
            _unitOfWork.PeopleRoles.Remove(personRole);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
