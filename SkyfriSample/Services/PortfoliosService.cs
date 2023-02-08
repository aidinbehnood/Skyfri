using SkyfriSample.Contract.Repository;
using SkyfriSample.Contract.Service;
using SkyfriSample.Data.Entity;
using SkyfriSample.Dto;
using SkyfriSample.Dto.Request;
using SkyfriSample.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Services
{
    public class PortfoliosService : IPortfoliosService
    {
        private readonly IPortfolioRepository portfolioRepository;
        private readonly ITenantRepository tenantRepository;
        public PortfoliosService(IPortfolioRepository portfolioRepository, ITenantRepository tenantRepository)
        {
            this.portfolioRepository = portfolioRepository;
            this.tenantRepository = tenantRepository;
        }
        public async Task<Response<bool>> InsertPortfolios(InsertPortfoliosRequestDto request)
        {
            var response = new Response<bool>();
            try
            {
                var tenant = tenantRepository.GetTenant(request.TenantName).Result;
                if (tenant != null)
                {
                    var portfolio = new Portfolio
                    {
                        TenantId = tenant.TenantId,
                        PortfolioName = request.PortfoliosName
                    };
                    portfolioRepository.Insert(portfolio);
                    response.Result = await tenantRepository.SaveChange();

                }
                else
                {
                    response.Message = "Tenant Not found ";
                    response.Result = false;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> RemovePortfolios(RemovePortfoliosRequestDto request)
        {
            var response = new Response<bool>();
            try
            {
                var tenant = tenantRepository.GetTenant(request.TenantName).Result;
                if (tenant!=null)
                {
                    var ListofPortfolio = portfolioRepository.Get(tenant.TenantId).Result;
                    foreach (var item in ListofPortfolio)
                    {
                        portfolioRepository.Delete(item.PortfolioId);
                    }
                   
                    response.Result = await portfolioRepository.SaveChange(); ;
                }

                else
                {
                    response.Message = "Tenant Not found ";
                    response.Result = false;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<GetAllPortfoliosResponseDto>>> GetAllPortfolios(GetAllPortfoliosRequestDto request)
        {

            var response = new Response<List<GetAllPortfoliosResponseDto>>();
            var MapLst = new List<GetAllPortfoliosResponseDto>();
            try
            {

                var tenant = tenantRepository.GetTenant(request.TenantName).Result;
                if (tenant!=null)
                {
                    var ListofPortfolio = portfolioRepository.Get(tenant.TenantId).Result;
                    foreach (var item in ListofPortfolio)
                    {
                        MapLst.Add(new GetAllPortfoliosResponseDto
                        {
                            Name = item.PortfolioName
                        });
                    }
                    response.Result = MapLst;
                }
                else
                {
                    response.Message = "Tenant Not found ";
                    response.Result = null;
                }
                
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
