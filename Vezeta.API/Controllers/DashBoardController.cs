using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Vezeta.core.Repositories;

namespace Vezeta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles= "Admin")]
    public class DashBoardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public DashBoardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("NumOfDoctors")]
        public async Task<IActionResult> NumOfDoctors()
        {

            var count = await _unitOfWork.DoctorRepo.GetCountAsync();
            return Ok(count);
        }
        [HttpGet("NumOfPatients")]
        public async Task<IActionResult> NumOfPatients()
        {

            var count = await _unitOfWork.PatientRepo.GetNumOfPatients();
            return Ok(count);
        }
        [HttpGet("api/specializations/Top5Specializations")]
        public async Task<IActionResult> Top5Specializations()
        {
            var Top5Spec = _unitOfWork.BookingRepo.GetTop5Specializations();

            return Ok(Top5Spec);
        }
        [HttpGet("api/specializations/Top10Doctors")]
        public async Task<IActionResult> Top10Doctors()
        {
            var Top10Doctors = _unitOfWork.BookingRepo.GetTop10Doctors();

            return Ok(Top10Doctors);
        }

    }
}
