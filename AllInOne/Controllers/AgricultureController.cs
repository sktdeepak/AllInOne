﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.API.Implementation;
using AllInOne.API.Interface;
using AllInOne.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgricultureController : ControllerBase {

        private readonly IAgricultureService _agricultureService;

        public AgricultureController(IAgricultureService agricultureService) {
            _agricultureService = agricultureService;
        }

        [HttpGet]
        [Route("GetFieldWorkList")]
        public async Task<List<FieldWorkModel>> GetFieldWorkList() {
            return await _agricultureService.GetFieldWorkList();
        }

        [HttpPost]
        [Route("SubmitFieldWork")]
        public async Task<int> SubmitFieldWork([FromBody]FieldWorkModel fieldWorkModel) {
            return await _agricultureService.SaveFieldWork(fieldWorkModel);
        }

        [HttpPost]
        [Route("UpdateFieldWork")]
        public async Task<int> UpdateFieldWork([FromBody]FieldWorkModel fieldWorkModel) {
            return await _agricultureService.UpdateFieldWork(fieldWorkModel);
        }

        [HttpDelete]
        [Route("DeleteFieldWork/{id}")]
        public async Task<List<FieldWorkModel>> Delete(int id) {
            return await _agricultureService.DeleteFieldWork(id);
        }

        [HttpGet]
        [Route("GetPriceList")]
        public async Task<List<PriceModel>> GetPriceList() {
            return await _agricultureService.GetPriceList();
        }

        [HttpPost]
        [Route("SubmitPrice")]
        public async Task<int> SubmitPrice([FromBody]PriceModel priceModel) {
            return await _agricultureService.SavePrice(priceModel);
        }

        [HttpPost]
        [Route("UpdatePrice")]
        public async Task<int> UpdatePrice([FromBody]PriceModel priceModel) {
            return await _agricultureService.UpdatePrice(priceModel);
        }

        [HttpDelete]
        [Route("DeletePrice/{id}")]
        public async Task<List<PriceModel>> DeletePrice(int id) {
            return await _agricultureService.DeletePrice(id);
        }
    }
}