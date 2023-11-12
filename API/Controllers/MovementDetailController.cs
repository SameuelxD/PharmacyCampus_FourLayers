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
    public class MovementDetailController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovementDetailController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MovementDetailDto>>> Get()
        {
            var movementDetails = await _unitOfWork.MovementDetails.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<MovementDetailDto>>(movementDetails);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovementDetail>> Post(MovementDetailDto movementDetailDto)
        {
            var movementDetail = _mapper.Map<MovementDetail>(movementDetailDto);
            this._unitOfWork.MovementDetails.Add(movementDetail);
            await _unitOfWork.SaveAsync();
            if (movementDetail == null)
            {
                return BadRequest();
            }
            movementDetailDto.Id = movementDetail.Id;
            return CreatedAtAction(nameof(Post), new { id = movementDetailDto.Id }, movementDetailDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovementDetailDto>> Get(int id)
        {
            var movementDetail = await _unitOfWork.MovementDetails.GetByIdAsync(id);
            if (movementDetail == null)
            {
                return NotFound();
            }
            return _mapper.Map<MovementDetailDto>(movementDetail);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovementDetailDto>> Put(int id, [FromBody] MovementDetailDto movementDetailDto)
        {
            if (movementDetailDto == null)
            {
                return NotFound();
            }
            var movementDetails = _mapper.Map<MovementDetail>(movementDetailDto);
            _unitOfWork.MovementDetails.Update(movementDetails);
            await _unitOfWork.SaveAsync();
            return movementDetailDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var movementDetail = await _unitOfWork.MovementDetails.GetByIdAsync(id);
            if (movementDetail == null)
            {
                return NotFound();
            }
            _unitOfWork.MovementDetails.Remove(movementDetail);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

