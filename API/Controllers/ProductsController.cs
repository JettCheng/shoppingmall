using System.Collections.Generic;
using System.Threading.Tasks;
using API.Errors;
using API.Extensions;
using API.Parameters;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;
        
        public ProductsController(
            IProductRepository productRepository,
            IMapper mapper,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor
        )
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }

        /// <summary>
        /// 取得商品之商品資訊清單
        /// </summary>
        /// <param name="paginationParameters"></param>
        /// <param name="productParameters"></param>
        /// <returns>商品清單</returns>
        [HttpGet("items",Name = "GetProducts")]
        public async Task<IActionResult> GetProducts( 
            [FromQuery] PaginationParameters paginationParameters

        )
        {
            // 取得商品清單
            var productFromRepo = await _productRepository.GetAllProductsAsync(
                paginationParameters.PageSize,
                paginationParameters.PageIndex,
                paginationParameters.Sort
            );

            if(productFromRepo == null || productFromRepo.Data.Count <= 0)
            {
                return NotFound( new ApiResponse(404, "查無商品" ) );
            }
            var productListDto = _mapper.Map<IEnumerable<ProductDto>>(productFromRepo.Data);

            // 產生分頁資訊
            var paginationMetadata = PaginationInfoExtensions.GeneratePaginationInfo<Product>(
                _urlHelper,
                productFromRepo,
                paginationParameters,
                "GetProducts"
            );
            Response.Headers.Add("x-pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            return Ok( new ApiResponseWithData<IEnumerable<ProductDto>>(200, productListDto) );
        }
    }
}