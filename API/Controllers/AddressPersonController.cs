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
    public class AddressPersonController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public AddressPersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AddressPersonDto>>> Get()
        {
            var addressPeople = await _unitOfWork.AddressPeople.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<AddressPersonDto>>(addressPeople);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddressPerson>> Post(AddressPersonDto addressPersonDto)
        {
            var addressPerson = _mapper.Map<AddressPerson>(addressPersonDto);
            this._unitOfWork.AddressPeople.Add(addressPerson);
            await _unitOfWork.SaveAsync();
            if (addressPerson == null)
            {
                return BadRequest();
            }
            addressPersonDto.Id = addressPerson.Id;
            return CreatedAtAction(nameof(Post), new { id = addressPersonDto.Id }, addressPersonDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressPersonDto>> Get(int id)
        {
            var addressPerson = await _unitOfWork.AddressPeople.GetByIdAsync(id);
            if (addressPerson == null){
                return NotFound();
            }
            return _mapper.Map<AddressPersonDto>(addressPerson);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddressPersonDto>> Put(int id, [FromBody] AddressPersonDto addressPersonDto)
        {
            if (addressPersonDto == null)
            {
                return NotFound();
            }
            var addressPeople = _mapper.Map<AddressPerson>(addressPersonDto);
            _unitOfWork.AddressPeople.Update(addressPeople);
            await _unitOfWork.SaveAsync();
            return addressPersonDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var addressPerson = await _unitOfWork.AddressPeople.GetByIdAsync(id);
            if (addressPerson == null)
            {
                return NotFound();
            }
            _unitOfWork.AddressPeople.Remove(addressPerson);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
