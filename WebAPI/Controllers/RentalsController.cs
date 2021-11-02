using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : Controller
    {
        IRentalsService _rentalsService;

        public RentalsController(IRentalsService rentalsService)
        {
            _rentalsService = rentalsService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependency Chain---

            var result = _rentalsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalsService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("getcarrentdetail")]
        public IActionResult GetCarRentDetails()
        {
            var result = _rentalsService.GetCarRentDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalsService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalsService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalsService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
