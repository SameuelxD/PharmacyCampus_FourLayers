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
    public class DocumentTypeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public DocumentTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DocumentTypeDto>>> Get()
        {
            var documentTypes = await _unitOfWork.DocumentTypes.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<DocumentTypeDto>>(documentTypes);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DocumentType>> Post(DocumentTypeDto documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            this._unitOfWork.DocumentTypes.Add(documentType);
            await _unitOfWork.SaveAsync();
            if (documentType == null)
            {
                return BadRequest();
            }
            documentTypeDto.Id = documentType.Id;
            return CreatedAtAction(nameof(Post), new { id = documentTypeDto.Id }, documentTypeDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DocumentTypeDto>> Get(int id)
        {
            var documentType = await _unitOfWork.DocumentTypes.GetByIdAsync(id);
            if (documentType == null){
                return NotFound();
            }
            return _mapper.Map<DocumentTypeDto>(documentType);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DocumentTypeDto>> Put(int id, [FromBody] DocumentTypeDto documentTypeDto)
        {
            if (documentTypeDto == null)
            {
                return NotFound();
            }
            var documentTypes = _mapper.Map<DocumentType>(documentTypeDto);
            _unitOfWork.DocumentTypes.Update(documentTypes);
            await _unitOfWork.SaveAsync();
            return documentTypeDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var documentType = await _unitOfWork.DocumentTypes.GetByIdAsync(id);
            if (documentType == null)
            {
                return NotFound();
            }
            _unitOfWork.DocumentTypes.Remove(documentType);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}