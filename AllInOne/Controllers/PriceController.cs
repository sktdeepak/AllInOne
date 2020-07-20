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
    public class PriceController : ControllerBase
    {
        public IPriceService _priceService;
        public PriceController(IPriceService priceService) {
            _priceService = priceService;
        }
        // GET: api/Price
        [HttpGet]
        public async Task<List<UserPriceDetailModel>> Get()
        {
          return await _priceService.GetUserPriceDetailList();
        }

        // GET: api/Price/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<UserPriceDetailModel> Get(int id)
        {
            return await _priceService.GetUserPriceDetail(id);
        }

        // POST: api/Price
        [HttpPost]
        public async Task<List<UserPriceDetailModel>> Post([FromBody] UserPriceDetailModel userPriceDetailModel)
        {
            return await _priceService.SaveUserPriceDetail(userPriceDetailModel);
        }

        // PUT: api/Price/5
        [HttpPut("{id}")]
        public async Task<List<UserPriceDetailModel>> Put(int id, [FromBody]  UserPriceDetailModel userPriceDetailModel)
        {
            return await _priceService.UpdateUserPriceDetail(userPriceDetailModel);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<List<UserPriceDetailModel>> Delete(int id)
        {
            return await _priceService.DeleteUserPriceDetail(id);
        }
    }
}
