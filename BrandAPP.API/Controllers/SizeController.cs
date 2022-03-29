using AutoMapper;
using BrandAPP.API.Models;
using BrandAPP.API.Models.Requests;
using BrandAPP.API.Models.Responses;
using BrandAPP.BLLayer.DTO;
using BrandAPP.BLLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BrandAPP.API.Controllers
{
    [Controller]
    [Route("api/[controller]/")]
    public class SizeController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public SizeController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet("{brandId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBrandSizes(int brandId)
        {
            try
            {
                var sizes = _mapper.Map<ICollection<SizeResponse>>(_brandService.GetBrandSizes(brandId));
                return Ok(sizes);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{brandId}/addSize")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddSizeToBrand(int brandId, SizeCreateRequest size)
        {
            try
            {
                _brandService.AddSize(brandId, _mapper.Map<SizeDTO>(size));
                return Ok(new { Message = "Size was succesfully added" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateSize(int id, SizeUpdateRequest size)
        {
            try
            {
                _brandService.UpdateSize(id, _mapper.Map<SizeDTO>(size));
                return Ok(new { Message = "Size was succesfully updated" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                _brandService.DeleteSize(id);
                return Ok(new { Message = "Size was succesfully deleted" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
