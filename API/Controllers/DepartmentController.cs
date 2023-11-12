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
    public class DepartmentController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get()
        {
            var departments = await _unitOfWork.Departments.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<DepartmentDto>>(departments);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Department>> Post(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            this._unitOfWork.Departments.Add(department);
            await _unitOfWork.SaveAsync();
            if (department == null)
            {
                return BadRequest();
            }
            departmentDto.Id = department.Id;
            return CreatedAtAction(nameof(Post), new { id = departmentDto.Id }, departmentDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartmentDto>> Get(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null){
                return NotFound();
            }
            return _mapper.Map<DepartmentDto>(department);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartmentDto>> Put(int id, [FromBody] DepartmentDto departmentDto)
        {
            if (departmentDto == null)
            {
                return NotFound();
            }
            var departments = _mapper.Map<Department>(departmentDto);
            _unitOfWork.Departments.Update(departments);
            await _unitOfWork.SaveAsync();
            return departmentDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            _unitOfWork.Departments.Remove(department);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
