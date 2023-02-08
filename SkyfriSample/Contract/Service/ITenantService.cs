using SkyfriSample.Dto;
using SkyfriSample.Dto.Request;
using SkyfriSample.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Contract.Service
{
    public interface ITenantService
    {
        Task<Response<bool>> InsertTenant(InsertTenantRequestDto request);
        Task<Response<bool>> RemoveTenant(RemoveTenantRequestDto request);
        Task<Response<List<GetAllTenantDto>>> GetAllTenant();
   

    }
}
