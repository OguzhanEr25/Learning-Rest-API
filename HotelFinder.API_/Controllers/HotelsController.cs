using HotelFinder.Business_.Abstract;
using HotelFinder.Business_.Concreate;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // validation kontrollerini otomatik yapıyor
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels =  await _hotelService.GetAllHotels();
            return Ok(hotels);  // 200 + data
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetID(int id)
        {
            var hotel =await _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound(); 
        }
        /// <summary>
        /// Add Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody]Hotel hotel)
        {
            
            var createHotel = await _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id =createHotel.ID}, createHotel);
            
        }
        /// <summary>
        /// Update hotel information
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Hotel hotel)
        {
            if(await _hotelService.GetHotelById(hotel.ID) != null)
            {
                return Ok(await _hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }
        /// <summary>
        /// Delete Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }

    }
}
