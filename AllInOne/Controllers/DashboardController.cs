using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.API.Interface;
using AllInOne.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IAgricultureService _agricultureService;

        public DashboardController(IAgricultureService agricultureService) {
            _agricultureService = agricultureService;
        }

        [HttpGet]
        [Route("GetDashboardFieldWorkList")]
        public async Task<List<DashboardModel>> GetDashboardFieldWorkList() {
            return await _agricultureService.GetDashboardFieldWorkList();
        }
    }
}