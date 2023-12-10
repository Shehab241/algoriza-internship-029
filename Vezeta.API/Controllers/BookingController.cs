using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.Entities;
using Vezeta.core.Repositories;

namespace Vezeta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("GetAllBookings")]
        public IActionResult GetAllBookings(int doctorId, DateTime date, int pageSize = 10, int pageNumber = 1)
        {
            date = date.Date;
            var query = _unitOfWork.BookingRepo.FindAll(b => b.DoctorId == doctorId, pageSize, pageNumber);
            return Ok(query);
        }
    }
}
