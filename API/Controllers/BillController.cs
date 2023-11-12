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
    public class BillController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BillController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BillDto>>> Get()
        {
            var bills = await _unitOfWork.Bills.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<BillDto>>(bills);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bill>> Post(BillDto billDto)
        {
            var bill = _mapper.Map<Bill>(billDto);
            this._unitOfWork.Bills.Add(bill);
            await _unitOfWork.SaveAsync();
            if (bill == null)
            {
                return BadRequest();
            }
            billDto.Id = bill.Id;
            return CreatedAtAction(nameof(Post), new { id = billDto.Id }, billDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BillDto>> Get(int id)
        {
            var bill = await _unitOfWork.Bills.GetByIdAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            return _mapper.Map<BillDto>(bill);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BillDto>> Put(int id, [FromBody] BillDto billDto)
        {
            if (billDto == null)
            {
                return NotFound();
            }
            var bills = _mapper.Map<Bill>(billDto);
            _unitOfWork.Bills.Update(bills);
            await _unitOfWork.SaveAsync();
            return billDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var bill = await _unitOfWork.Bills.GetByIdAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            _unitOfWork.Bills.Remove(bill);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
