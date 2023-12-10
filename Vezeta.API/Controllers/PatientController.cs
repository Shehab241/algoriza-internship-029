using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vezeta.core.Repositories;

namespace Vezeta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllPatients")]
        //[Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAllPatients()
        {

            var query = await _unitOfWork.PatientRepo.GetAllAsync();
            return Ok(query);
        }
        [HttpGet("GetPatientById")]
        //[Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetById(int id)
        {
            if (id != 0)
            {
                var query = await _unitOfWork.PatientRepo.GetByIdAsync(id);
                return Ok(query);

            }
            return NotFound();

        }
        [HttpGet("GetBookingsById")]
        //[Authorize(Roles = "Patient")]
        public async Task<IActionResult> GetBookings(int patientId)
        {
            if (patientId != 0)
            {
                var query = await _unitOfWork.BookingRepo.GetBookingsByPatientId(patientId);
                return Ok(query);

            }
            return NotFound();

        }

    }
}
