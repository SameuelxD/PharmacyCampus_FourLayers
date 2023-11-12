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
    public class ProductBrandController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public ProductBrandController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductBrandDto>>> Get()
        {
            var productBrands = await _unitOfWork.ProductBrands.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<ProductBrandDto>>(productBrands);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductBrand>> Post(ProductBrandDto productBrandDto)
        {
            var productBrand = _mapper.Map<ProductBrand>(productBrandDto);
            this._unitOfWork.ProductBrands.Add(productBrand);
            await _unitOfWork.SaveAsync();
            if (productBrand == null)
            {
                return BadRequest();
            }
            productBrandDto.Id = productBrand.Id;
            return CreatedAtAction(nameof(Post), new { id = productBrandDto.Id }, productBrandDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductBrandDto>> Get(int id)
        {
            var productBrand = await _unitOfWork.ProductBrands.GetByIdAsync(id);
            if (productBrand == null){
                return NotFound();
            }
            return _mapper.Map<ProductBrandDto>(productBrand);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductBrandDto>> Put(int id, [FromBody] ProductBrandDto productBrandDto)
        {
            if (productBrandDto == null)
            {
                return NotFound();
            }
            var productBrands = _mapper.Map<ProductBrand>(productBrandDto);
            _unitOfWork.ProductBrands.Update(productBrands);
            await _unitOfWork.SaveAsync();
            return productBrandDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var productBrand = await _unitOfWork.ProductBrands.GetByIdAsync(id);
            if (productBrand == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductBrands.Remove(productBrand);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

