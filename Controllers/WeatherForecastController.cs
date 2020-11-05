using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

namespace WebApiCursos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICoursesProvider coursesProvider;

        public WeatherForecastController(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var results = await coursesProvider.GetAllasAsync();
            if (results != null)
            {
                return Ok(results);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAync(int id)
        {
            var results = await coursesProvider.GetAsync(id);
            if (results != null)
            {
                return Ok(results);
            }
            return NotFound(id);
        }

        [HttpGet("search/{search}")]
        public async Task<IActionResult> SearchAsync (string search)
        {
            var results = await coursesProvider.SearchAsync(search);
            if (results != null)
            {
                return Ok(results);
            }

            return NotFound(search);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Course course)
        {
            if (course == null)
            {
                return BadRequest();
            }
            var results = await coursesProvider.AddAsync(course);
            if (results.IsSuccess)
            {
                return Ok(results.Id);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Course course)
        {
            var results = await coursesProvider.UpdateAsync(id, course);
            if(results)
            {
                return Ok(results);
            }

            return NotFound();
        }
    }
}
