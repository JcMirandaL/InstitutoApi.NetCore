using InstitutoApp.Common.Exceptions;
using InstitutoApp.Common.Interfaces;
using InstitutoApp.DTOs.MatriculaDTOs;
using Microsoft.AspNetCore.Mvc;

namespace InstitutoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : Controller
    {
        private readonly IGenericService<MatriculaResponseDTO, MatriculaCreatedDTO, MatriculaUpdateDTO> _matriculaService;

        public MatriculaController(IGenericService<MatriculaResponseDTO, MatriculaCreatedDTO, MatriculaUpdateDTO> matriculaService)
        {
            _matriculaService = matriculaService;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _matriculaService.GetAllAsync();
                return Ok(response);
            }
            catch (NotFoundDbException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error interno en el servidor. Contacte con el administrador.");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var response = await _matriculaService.GetByIdAsync(id);
                return Ok(response);
            }
            catch (NotFoundDbException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error interno en el servidor. Contacte con el administrador.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MatriculaCreatedDTO matriculaCreatedDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await _matriculaService.CreateAsync(matriculaCreatedDTO);
                return Ok(response);
            }
            catch (NotFoundDbException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EntityExistDbException ex)
            {
                return Conflict(ex.Message);
            }
            catch (MaximumCapacityDbException ex)
            { 
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error interno en el servidor. Contacte con el administrador.");
            }
        }






    }
}
