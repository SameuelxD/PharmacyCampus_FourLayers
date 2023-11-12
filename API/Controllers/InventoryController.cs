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
    public class InventoryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public InventoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> Get()
        {
            var inventories = await _unitOfWork.Inventories.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<InventoryDto>>(inventories);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Inventory>> Post(InventoryDto inventoryDto)
        {
            var inventory = _mapper.Map<Inventory>(inventoryDto);
            this._unitOfWork.Inventories.Add(inventory);
            await _unitOfWork.SaveAsync();
            if (inventory == null)
            {
                return BadRequest();
            }
            inventoryDto.Id = inventory.Id;
            return CreatedAtAction(nameof(Post), new { id = inventoryDto.Id }, inventoryDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventoryDto>> Get(int id)
        {
            var inventory = await _unitOfWork.Inventories.GetByIdAsync(id);
            if (inventory == null){
                return NotFound();
            }
            return _mapper.Map<InventoryDto>(inventory);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InventoryDto>> Put(int id, [FromBody] InventoryDto inventoryDto)
        {
            if (inventoryDto == null)
            {
                return NotFound();
            }
            var inventories = _mapper.Map<Inventory>(inventoryDto);
            _unitOfWork.Inventories.Update(inventories);
            await _unitOfWork.SaveAsync();
            return inventoryDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var inventory = await _unitOfWork.Inventories.GetByIdAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            _unitOfWork.Inventories.Remove(inventory);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

