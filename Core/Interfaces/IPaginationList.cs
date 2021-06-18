using System.Collections.Generic;
using System.Linq;

namespace Core.Interfaces
{
    public interface IPaginationList<T>: IList<T>
    {
        // 當前頁面 index
        int PageIndex { get; set; }

        // 每頁幾筆資料
        int PageSize { get; set; }

        // 資料總筆數
        int TotalCount { get; }

        // 有前一頁嗎
        bool HasPrevious { get; }

        // 有下一頁嗎
        bool HasNext { get; }

        // API 欲回傳的資料
        List<T> Data { get; set; }

        // 總頁數
        int TotalPages { get; }
    }
}