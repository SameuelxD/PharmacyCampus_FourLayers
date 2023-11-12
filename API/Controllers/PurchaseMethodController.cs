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
    public class PurchaseMethodController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public PurchaseMethodController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PurchaseMethodDto>>> Get()
        {
            var purchaseMethods = await _unitOfWork.PurchaseMethods.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PurchaseMethodDto>>(purchaseMethods);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PurchaseMethod>> Post(PurchaseMethodDto purchaseMethodDto)
        {
            var purchaseMethod = _mapper.Map<PurchaseMethod>(purchaseMethodDto);
            this._unitOfWork.PurchaseMethods.Add(purchaseMethod);
            await _unitOfWork.SaveAsync();
            if (purchaseMethod == null)
            {
                return BadRequest();
            }
            purchaseMethodDto.Id = purchaseMethod.Id;
            return CreatedAtAction(nameof(Post), new { id = purchaseMethodDto.Id }, purchaseMethodDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PurchaseMethodDto>> Get(int id)
        {
            var purchaseMethod = await _unitOfWork.PurchaseMethods.GetByIdAsync(id);
            if (purchaseMethod == null){
                return NotFound();
            }
            return _mapper.Map<PurchaseMethodDto>(purchaseMethod);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PurchaseMethodDto>> Put(int id, [FromBody] PurchaseMethodDto purchaseMethodDto)
        {
            if (purchaseMethodDto == null)
            {
                return NotFound();
            }
            var purchaseMethods = _mapper.Map<PurchaseMethod>(purchaseMethodDto);
            _unitOfWork.PurchaseMethods.Update(purchaseMethods);
            await _unitOfWork.SaveAsync();
            return purchaseMethodDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var purchaseMethod = await _unitOfWork.PurchaseMethods.GetByIdAsync(id);
            if (purchaseMethod == null)
            {
                return NotFound();
            }
            _unitOfWork.PurchaseMethods.Remove(purchaseMethod);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

