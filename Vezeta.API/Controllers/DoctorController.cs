using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vezeeta.Core.Entities;
using Vezeta.core.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Vezeta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllDoctors")]
        //[Authorize(Roles = "Admin,Patient")]
        public async Task<IActionResult> GetAllDoctors( )
        {
           
            var query = await _unitOfWork.DoctorRepo.GetAllAsync();
            return Ok(query);
        }
        [HttpGet("GetDoctorById")]
        //[Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetById(int id)
        {
            if (id != 0)
            {
                var query = await _unitOfWork.DoctorRepo.GetByIdAsync(id);
                return Ok(query);

            }
            return NotFound();

        }
        [HttpPost("AddDoctor")]
        //[Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddDoctor(Doctor model)
        {
            if (model != null)
            {
                
                await _unitOfWork.DoctorRepo.AddAsync(model);
                await _unitOfWork.Complete();
            }
            return Ok(model);
        }
        [HttpPut("EditDoctor")]
        //[Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _unitOfWork.DoctorRepo.GetByIdAsync(id);
            if (id != 0)
            {
                _unitOfWork.DoctorRepo.Update(doctor);
                await _unitOfWork.Complete();
            }
            return Ok(doctor);

        }
      
        [HttpDelete("DeleteDoctor")]
        //[Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _unitOfWork.DoctorRepo.GetByIdAsync(id);

            if (doctor == null)
                return BadRequest();
             _unitOfWork.DoctorRepo.Delete(doctor);
             int count = await _unitOfWork.Complete();
            return Ok(doctor);
          
             
        }
        [HttpGet("getBookingsDoctor")]
        //[Authorize(Roles = "Patient")]

        public async Task<IActionResult> GetBookings(int doctorId)
        {

            var query = await _unitOfWork.BookingRepo.GetBookingsByDoctorId(doctorId);
            return Ok(query);

        }



    }
}
