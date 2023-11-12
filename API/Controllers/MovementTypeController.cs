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
    public class MovementTypeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public MovementTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MovementTypeDto>>> Get()
        {
            var movementsTypes = await _unitOfWork.MovementsTypes.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<MovementTypeDto>>(movementsTypes);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovementType>> Post(MovementTypeDto movementTypeDto)
        {
            var movementType = _mapper.Map<MovementType>(movementTypeDto);
            this._unitOfWork.MovementsTypes.Add(movementType);
            await _unitOfWork.SaveAsync();
            if (movementType == null)
            {
                return BadRequest();
            }
            movementTypeDto.Id = movementType.Id;
            return CreatedAtAction(nameof(Post), new { id = movementTypeDto.Id }, movementTypeDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovementTypeDto>> Get(int id)
        {
            var movementType = await _unitOfWork.MovementsTypes.GetByIdAsync(id);
            if (movementType == null){
                return NotFound();
            }
            return _mapper.Map<MovementTypeDto>(movementType);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovementTypeDto>> Put(int id, [FromBody] MovementTypeDto movementTypeDto)
        {
            if (movementTypeDto == null)
            {
                return NotFound();
            }
            var movementsTypes = _mapper.Map<MovementType>(movementTypeDto);
            _unitOfWork.MovementsTypes.Update(movementsTypes);
            await _unitOfWork.SaveAsync();
            return movementTypeDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var movementType = await _unitOfWork.MovementsTypes.GetByIdAsync(id);
            if (movementType == null)
            {
                return NotFound();
            }
            _unitOfWork.MovementsTypes.Remove(movementType);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
