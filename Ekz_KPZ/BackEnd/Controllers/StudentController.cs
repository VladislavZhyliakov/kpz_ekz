using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using DTOs.StudentDTOs;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _studentService.GetAllAsync<DetailedStudentDTO>();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] int id)
        {
            await _studentService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] CreateStudentDTO model)
        {
            var result = await _studentService.CreateAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAsync([FromBody] UpdateStudentDTO model)
        {
            await _studentService.UpdateAsync(model);
            return Ok();
        }
    }
}
