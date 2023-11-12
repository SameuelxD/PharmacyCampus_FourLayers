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
    public class ContactTypeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public ContactTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactTypeDto>>> Get()
        {
            var contactTypes = await _unitOfWork.ContactTypes.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<ContactTypeDto>>(contactTypes);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactType>> Post(ContactTypeDto contactTypeDto)
        {
            var contactType = _mapper.Map<ContactType>(contactTypeDto);
            this._unitOfWork.ContactTypes.Add(contactType);
            await _unitOfWork.SaveAsync();
            if (contactType == null)
            {
                return BadRequest();
            }
            contactTypeDto.Id = contactType.Id;
            return CreatedAtAction(nameof(Post), new { id = contactTypeDto.Id }, contactTypeDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactTypeDto>> Get(int id)
        {
            var contactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
            if (contactType == null){
                return NotFound();
            }
            return _mapper.Map<ContactTypeDto>(contactType);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactTypeDto>> Put(int id, [FromBody] ContactTypeDto contactTypeDto)
        {
            if (contactTypeDto == null)
            {
                return NotFound();
            }
            var contactTypes = _mapper.Map<ContactType>(contactTypeDto);
            _unitOfWork.ContactTypes.Update(contactTypes);
            await _unitOfWork.SaveAsync();
            return contactTypeDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var contactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
            if (contactType == null)
            {
                return NotFound();
            }
            _unitOfWork.ContactTypes.Remove(contactType);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
