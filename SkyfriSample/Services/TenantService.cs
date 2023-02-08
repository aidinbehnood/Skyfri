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
    public class TenantService : ITenantService
    {

        private readonly ITenantRepository tenantRepository;
        public TenantService(ITenantRepository tenantRepository)
        {
            this.tenantRepository = tenantRepository;
        }

        public async Task<Response<List<GetAllTenantDto>>> GetAllTenant()
        {
            var response = new Response<List<GetAllTenantDto>>();
            var MapLst = new List<GetAllTenantDto>();
            try
            {
                var lst = await tenantRepository.GetAllTenant();
                foreach (var item in lst)
                {
                    MapLst.Add(new GetAllTenantDto { Name = item.TenantName });
                }
                response.Result = MapLst;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> InsertTenant(InsertTenantRequestDto request)
        {
            var response = new Response<bool>();
            try
            {
                var tenant = new Tenant
                {
                    TenantName = request.Name
                };
                tenantRepository.Insert(tenant);
                var saveResult = await tenantRepository.SaveChange();
                response.Result = saveResult;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<bool>> RemoveTenant(RemoveTenantRequestDto request)
        {
            var response = new Response<bool>();
            try
            {
                tenantRepository.Delete(request.Name);
                var saveResult =await tenantRepository.SaveChange();
                response.IsSuccess = saveResult;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
