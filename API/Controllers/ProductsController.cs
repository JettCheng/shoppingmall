using System;
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
        [HttpGet(Name = "GetProduct")]
        public async Task<IActionResult> GetProducts(
            [FromQuery] PaginationParameters paginationParameters,
            [FromQuery] ProductParameters productParameters
        )
        {
            // 取得商品清單
            var productFromRepo = await _productRepository.GetProductsAsync(
                productParameters.Keyword,
                productParameters.ProductTypeId,
                paginationParameters.PageSize,
                paginationParameters.PageIndex,
                paginationParameters.Sort
            );

            if (productFromRepo == null || productFromRepo.Data.Count <= 0)
            {
                return NotFound(new ApiResponse(404, "查無商品"));
            }
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productFromRepo.Data);

            // 產生分頁資訊
            var paginationMetadata = PaginationInfoExtensions.GeneratePaginationInfo<Product>(
                _urlHelper,
                productFromRepo,
                paginationParameters,
                "GetProduct"
            );

            Response.Headers.Add("x-pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));
            return Ok(new ApiResponseWithData<IEnumerable<ProductDto>>(200, productsDto));
        }

        /// <summary>
        /// 取得商品次分類
        /// </summary> 
        /// <returns>商品所有分類清單</returns>   
        [HttpGet("productTypes")]
        public async Task<IActionResult> GetProductTypes()
        {
            var productTypesFromRepo = await _productRepository.GetProductTypesAsync();

            var productTypesToReturn = _mapper.Map<IEnumerable<ProductTypeDto>>(productTypesFromRepo);

            return Ok(new ApiResponseWithData<IEnumerable<ProductTypeDto>>(200, productTypesToReturn));
        }

        /// <summary>
        /// 以商品編號取得該商品之商品資訊清單
        /// </summary>
        /// <param name="productId">商品編號</param>
        /// <returns>商品</returns>   
        [HttpGet("{productId}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById( [FromRoute] Guid productId)
        {
            var productFromRepo = await _productRepository.GetProductByIdAsync(productId);
            if (productFromRepo == null)
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productId) );
            }
            var productDto = _mapper.Map<ProductDto>(productFromRepo);
            return Ok( new ApiResponseWithData<ProductDto>(200, productDto) );
        }
    }
}