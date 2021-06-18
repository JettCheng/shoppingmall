using API.Parameters;
using Core.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions
{
    public class PaginationInfoExtensions
    {
        public static PaginationMetadata GeneratePaginationInfo<T> (
            IUrlHelper urlHelper,
            IPaginationList<T> paginationList,
            PaginationParameters paginationParameters,
            string linkName
        ) 
        {
            var pageInfo = new 
            {
                PageIndex = paginationParameters.PageIndex - 1,
                PageSize = paginationParameters.PageSize
            };

            var paginationMetadata = new PaginationMetadata()
            {
                PreviousPageLink = paginationList.HasPrevious? urlHelper.Link(linkName,pageInfo) : null,
                NextPageLink = paginationList.HasNext? urlHelper.Link(linkName,pageInfo) : null,
                TotalCount = paginationList.TotalCount,
                PageSize = paginationList.PageSize,
                PageIndex = paginationList.PageIndex,
                TotalPages = paginationList.TotalPages
            };
            return paginationMetadata;
        }
    }
}