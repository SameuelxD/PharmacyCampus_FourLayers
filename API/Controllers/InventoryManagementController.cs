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
    public class AuditoriaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InventoryManagementDto>>> Get()
        {
            var inventoryManagements = await _unitOfWork.InventoryManagements.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<InventoryManagementDto>>(inventoryManagements);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InventoryManagement>> Post(InventoryManagementDto inventoryManagementDto)
        {
            var inventoryManagement = _mapper.Map<InventoryManagement>(inventoryManagementDto);
            this._unitOfWork.InventoryManagements.Add(inventoryManagement);
            await _unitOfWork.SaveAsync();
            if (inventoryManagement == null)
            {
                return BadRequest();
            }
            inventoryManagementDto.Id = inventoryManagement.Id;
            return CreatedAtAction(nameof(Post), new { id = inventoryManagementDto.Id }, inventoryManagementDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventoryManagementDto>> Get(int id)
        {
            var inventoryManagement = await _unitOfWork.InventoryManagements.GetByIdAsync(id);
            if (inventoryManagement == null){
                return NotFound();
            }
            return _mapper.Map<InventoryManagementDto>(inventoryManagement);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InventoryManagementDto>> Put(int id, [FromBody] InventoryManagementDto inventoryManagementDto)
        {
            if (inventoryManagementDto == null)
            {
                return NotFound();
            }
            var inventoryManagements = _mapper.Map<InventoryManagement>(inventoryManagementDto);
            _unitOfWork.InventoryManagements.Update(inventoryManagements);
            await _unitOfWork.SaveAsync();
            return inventoryManagementDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var inventoryManagement = await _unitOfWork.InventoryManagements.GetByIdAsync(id);
            if (inventoryManagement == null)
            {
                return NotFound();
            }
            _unitOfWork.InventoryManagements.Remove(inventoryManagement);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

