using Microsoft.AspNetCore.Mvc;
using SkyfriSample.Contract.Service;
using SkyfriSample.Dto;
using SkyfriSample.Dto.Request;
using SkyfriSample.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkyfriController : ControllerBase
    {
        private readonly ITenantService tenantService;
        private readonly IPortfoliosService  portfoliosService;

        public SkyfriController(ITenantService tenantService , IPortfoliosService portfoliosService)
        {
            this.tenantService = tenantService;
            this.portfoliosService = portfoliosService;

        }
        [HttpPost("InsertTenant")]
        public async Task<Response<bool>> InsertTenant(InsertTenantRequestDto request)
        {
            var response = new Response<bool>();
            if (ModelState.IsValid)
            {
                try
                {
                    response = await tenantService.InsertTenant(request);

                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                }
            }
            else
                response.IsSuccess = false;

            return response;

        }

        [HttpPost("GetAllTenant")]
        public async Task<Response<List<GetAllTenantDto>>> GetAllTenant()
        {
            var response = new Response<List<GetAllTenantDto>>();
            if (ModelState.IsValid)
            {
                try
                {
                    response = await tenantService.GetAllTenant();

                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                }
            }
            else
                response.IsSuccess = false;

            return response;

        }

        [HttpPost("DeleteTenant")]
        public async Task<Response<bool>> DeleteTenant(RemoveTenantRequestDto request)
        {
            var response = new Response<bool>();
            if (ModelState.IsValid)
            {
                try
                {
                    response = await tenantService.RemoveTenant(request);

                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                }
            }
            else
                response.IsSuccess = false;

            return response;

        }

        [HttpPost("InsertPortfolios")]
        public async Task<Response<bool>> InsertPortfolios(InsertPortfoliosRequestDto request)
        {
            var response = new Response<bool>();
            if (ModelState.IsValid)
            {
                try
                {
                    response = await portfoliosService.InsertPortfolios(request);

                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                }
            }
            else
                response.IsSuccess = false;

            return response;

        }

        [HttpPost("GetAllPortfolios")]
        public async Task<Response<List<GetAllPortfoliosResponseDto>>> GetAllPortfolios(GetAllPortfoliosRequestDto request)
        {
            var response = new Response<List<GetAllPortfoliosResponseDto>>();
            if (ModelState.IsValid)
            {
                try
                {
                    response = await portfoliosService.GetAllPortfolios(request);

                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                }
            }
            else
                response.IsSuccess = false;

            return response;

        }

        [HttpPost("DeletePortfolios")]
        public async Task<Response<bool>> DeletePortfolios(RemovePortfoliosRequestDto request)
        {
            var response = new Response<bool>();
            if (ModelState.IsValid)
            {
                try
                {
                    response = await portfoliosService.RemovePortfolios(request);

                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                }
            }
            else
                response.IsSuccess = false;

            return response;

        }
    }
}
