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
    public class PresentationTypeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public PresentationTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PresentationTypeDto>>> Get()
        {
            var presentationTypes = await _unitOfWork.PresentationTypes.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PresentationTypeDto>>(presentationTypes);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PresentationType>> Post(PresentationTypeDto presentationTypeDto)
        {
            var presentationType = _mapper.Map<PresentationType>(presentationTypeDto);
            this._unitOfWork.PresentationTypes.Add(presentationType);
            await _unitOfWork.SaveAsync();
            if (presentationType == null)
            {
                return BadRequest();
            }
            presentationTypeDto.Id = presentationType.Id;
            return CreatedAtAction(nameof(Post), new { id = presentationTypeDto.Id }, presentationTypeDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PresentationTypeDto>> Get(int id)
        {
            var presentationType = await _unitOfWork.PresentationTypes.GetByIdAsync(id);
            if (presentationType == null){
                return NotFound();
            }
            return _mapper.Map<PresentationTypeDto>(presentationType);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PresentationTypeDto>> Put(int id, [FromBody] PresentationTypeDto presentationTypeDto)
        {
            if (presentationTypeDto == null)
            {
                return NotFound();
            }
            var presentationTypes = _mapper.Map<PresentationType>(presentationTypeDto);
            _unitOfWork.PresentationTypes.Update(presentationTypes);
            await _unitOfWork.SaveAsync();
            return presentationTypeDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var presentationType = await _unitOfWork.PresentationTypes.GetByIdAsync(id);
            if (presentationType == null)
            {
                return NotFound();
            }
            _unitOfWork.PresentationTypes.Remove(presentationType);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
