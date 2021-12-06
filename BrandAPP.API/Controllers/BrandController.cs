using AutoMapper;
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
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                var brands = _mapper.Map<IEnumerable<BrandResponse>>(_brandService.GetBrands());
                return Ok(brands);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                var brand = _mapper.Map<BrandResponse>(_brandService.GetBrand(id));
                return Ok(brand);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("find")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByName([FromQuery] string name)
        {
            try
            {
                var brand = _mapper.Map<BrandResponse>(_brandService.GetBrandByName(name));
                return Ok(brand);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(BrandCreateRequest brand)
        {
            try
            {
                _brandService.CreateBrand(_mapper.Map<BrandDTO>(brand));
                return Ok(new { Message = "Brand was succesfully created" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
