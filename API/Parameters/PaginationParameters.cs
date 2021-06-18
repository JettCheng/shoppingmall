namespace API.Parameters
{
    public class PaginationParameters
    {
        // 排序條件
        public string Sort { get; set; }

        // 頁碼
        public int PageIndex
        {
            get { return _pageIndex; }
            set { if (value >= 1)  _pageIndex = value; }
        }

        // 每頁幾筆資料
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value >= 1)
                {
                    _pageSize = (value > maxPageSize) ? maxPageSize : value;
                }
            }
        }

        // 頁碼預設值為 1
        private int _pageIndex = 1;
        // 每頁預設10筆資料
        private int _pageSize = 10;
        // 每頁預設最多50筆
        private int maxPageSize = 50;
    }
}
