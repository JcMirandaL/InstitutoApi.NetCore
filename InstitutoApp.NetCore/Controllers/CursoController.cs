using InstitutoApp.Common.Exceptions;
using InstitutoApp.Common.Interfaces;
using InstitutoApp.DTOs.CursoDTOs;
using Microsoft.AspNetCore.Mvc;

namespace InstitutoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : Controller
    {
        private readonly IGenericService<CursoResponseDTO, CursoCreatedDTO, CursoUpdateDTO> _cursoService;

        public CursoController(IGenericService<CursoResponseDTO, CursoCreatedDTO, CursoUpdateDTO> cursoService)
        {
            _cursoService = cursoService;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _cursoService.GetAllAsync();
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



        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var response = await _cursoService.GetByIdAsync(id);
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
        public async Task<IActionResult> CreateAsync([FromBody] CursoCreatedDTO cursoCreatedDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await _cursoService.CreateAsync(cursoCreatedDTO);
                return Ok(response);
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
        public async Task<IActionResult> UpdateAsync([FromBody] CursoUpdateDTO cursoUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var response = await _cursoService.UpdateAsync(cursoUpdateDTO);
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _cursoService.DeleteAsync(id);
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
