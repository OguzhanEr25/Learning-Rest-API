using HotelFinder.Business_.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business_.Concreate
{
    public class HotelManager : IHotelService
    {

        private IHotelRepository _hotelRepository; 
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(id);
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _hotelRepository.GetAllHotels();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            if(id > 0)
            {
                return await _hotelRepository.GetHotelByID(id);
            }
            throw new Exception("ID 1'den küçük olamaz!");
        }

        public Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return  _hotelRepository.UpdateHotel(hotel);
        }
    }
}
