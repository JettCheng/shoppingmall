using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PaginationList<T>: List<T>, IPaginationList<T>
    {
        // 當前頁面 index
        public int PageIndex { get; set; }

        // 每頁幾筆資料
        public int PageSize { get; set; }

        // 資料總筆數
        public int TotalCount { get; private set; }

        // 有前一頁嗎
        public bool HasPrevious => PageIndex > 1;

        // 有下一頁嗎
        public bool HasNext => PageIndex < TotalPages;

        // API 欲回傳的資料
        public List<T> Data { get; set; }

        // 總頁數
        public int TotalPages { get; private set; }

        public PaginationList(int totalCount, int pageIndex, int pageSize, List<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            Data = data;
        }

        public static async Task<PaginationList<T>> CreateAsync(
            int pageIndex, int pageSize, IQueryable<T> result)
        {
            var totalCount = await result.CountAsync();
            // skip
            var skip = (pageIndex - 1) * pageSize;
            result = result.Skip(skip);
            // 以 pagesize 為標準顯示一定數量數據
            result = result.Take(pageSize);

            var data = await result.ToListAsync();

            return new PaginationList<T>(totalCount, pageIndex, pageSize, data);
        }
    }
}
