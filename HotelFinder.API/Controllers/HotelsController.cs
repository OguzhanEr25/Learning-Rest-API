using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Entities;

using Microsoft.Extensions.Hosting;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHostedService _hotelService;
        public HotelsController(IHotelService hotel)
        {
            _hotelService = new HotelManager();
        }

    }
}
