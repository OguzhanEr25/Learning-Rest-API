using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        // POST isteği çağırıldığında çalışacak metod
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using(var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.hotels.Add(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }
        // DELETE isteği çağırıldığında çalışacak metod
        public async Task DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deletedHotel = await GetHotelByID(id);
                hotelDbContext.hotels.Remove(deletedHotel);
                await hotelDbContext.SaveChangesAsync();
            }
        }
        // GET isteği çağırıldığnda çalışacak metod
        public async Task<List<Hotel>>GetAllHotels()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.hotels.ToListAsync();
            }
        }
        // GET metodunda id belirtilerek bir istekte bulunulduğu zaman çalışacak metod
        public async Task<Hotel> GetHotelByID(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                if(id > 0)
                {
                    return  await hotelDbContext.hotels.FindAsync(id);
                }
                throw new Exception("ID 1 den küçük olamaz");
            }
        }
        // PUT metodu çağırıldığında çalışacak metod
        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.hotels.Update(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }
    }
}
