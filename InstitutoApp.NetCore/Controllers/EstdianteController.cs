using InstitutoApp.Common.Exceptions;
using InstitutoApp.Common.Interfaces;
using InstitutoApp.DTOs.EstudianteDTOs;
using Microsoft.AspNetCore.Mvc;

namespace InstitutoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstdianteController : Controller
    {
        private readonly IEstdianteService<EstudianteResponseDTO, EstudianteCreatedDTO, EstudianteUpdateDTO> _estudianteService;


        public EstdianteController(IEstdianteService<EstudianteResponseDTO, EstudianteCreatedDTO, EstudianteUpdateDTO> estudianteService)
        {
            _estudianteService = estudianteService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _estudianteService.GetAllAsync();
                return Ok(response);
            }
            catch (NotFoundDbException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno en el servidor. Contacte con el administrador.");
            }

        }


        [HttpGet("{cedula}")]
        public async Task<IActionResult> GetByIdAsync(string cedula)
        {
            try
            {
                var response = await _estudianteService.GetByIdAsync(cedula);
                return Ok(response);
            }
            catch (NotFoundDbException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno en el servidor. Contacte con el administrador.");

            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EstudianteCreatedDTO estudianteCreatedDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await _estudianteService.CreateAsync(estudianteCreatedDTO);
                return Created("Ok", response);
            }
            catch (EntityExistDbException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno en el servidor. Contacte con el administrador.");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] EstudianteUpdateDTO estudianteUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await _estudianteService.UpdateAsync(estudianteUpdateDTO);
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
            catch (Exception)
            {
                return StatusCode(500, "Error interno en el servidor. Contacte con el administrador.");
            }
        }


        [HttpDelete("{cedula}")]
        public async Task<IActionResult> DeleteAsync(string cedula)
        {
            try
            {
                var response = await _estudianteService.DeleteAsync(cedula);

                return Ok(response);
            }
            catch (NotFoundDbException ex)
            { 
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno en el servidor. Contacte con el administrador.");
            }
        }


      



    }
}