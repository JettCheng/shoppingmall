// using System;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.EntityFrameworkCore;

// namespace Core.Entities.OrderAggregate
// {
//     [Keyless]
//     public class ProductItemOrdered
//     {
//         public ProductItemOrdered()
//         {
//         }

//         public ProductItemOrdered(Guid productItemId, string productTitle, string coverImage)
//         {
//             ProductitemId = productItemId;
//             ProductTitle = productTitle;
//             CoverImage = coverImage;
//         }
//         public Guid ProductitemId { get; set; }
//         public string ProductTitle { get; set; }
//         public string CoverImage { get; set; }
//     }
// }