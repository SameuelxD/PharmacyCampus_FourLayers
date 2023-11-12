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
    public class ContactPersonController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public ContactPersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactPersonDto>>> Get()
        {
            var contactPeople = await _unitOfWork.ContactPeople.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<ContactPersonDto>>(contactPeople);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactPerson>> Post(ContactPersonDto contactPersonDto)
        {
            var contactPerson = _mapper.Map<ContactPerson>(contactPersonDto);
            this._unitOfWork.ContactPeople.Add(contactPerson);
            await _unitOfWork.SaveAsync();
            if (contactPerson == null)
            {
                return BadRequest();
            }
            contactPersonDto.Id = contactPerson.Id;
            return CreatedAtAction(nameof(Post), new { id = contactPersonDto.Id }, contactPersonDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactPersonDto>> Get(int id)
        {
            var contactPerson = await _unitOfWork.ContactPeople.GetByIdAsync(id);
            if (contactPerson == null){
                return NotFound();
            }
            return _mapper.Map<ContactPersonDto>(contactPerson);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactPersonDto>> Put(int id, [FromBody] ContactPersonDto contactPersonDto)
        {
            if (contactPersonDto == null)
            {
                return NotFound();
            }
            var contactPeople = _mapper.Map<ContactPerson>(contactPersonDto);
            _unitOfWork.ContactPeople.Update(contactPeople);
            await _unitOfWork.SaveAsync();
            return contactPersonDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var contactPerson = await _unitOfWork.ContactPeople.GetByIdAsync(id);
            if (contactPerson == null)
            {
                return NotFound();
            }
            _unitOfWork.ContactPeople.Remove(contactPerson);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}