using SkyfriSample.Dto;
using SkyfriSample.Dto.Request;
using SkyfriSample.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Contract.Service
{
    public interface IPortfoliosService
    {
        Task<Response<bool>> InsertPortfolios(InsertPortfoliosRequestDto request);
        Task<Response<bool>> RemovePortfolios(RemovePortfoliosRequestDto request);
        Task<Response<List<GetAllPortfoliosResponseDto>>> GetAllPortfolios(GetAllPortfoliosRequestDto request);
    }
}
