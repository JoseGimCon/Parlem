using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Aplication.Params
{
    public class RequestPaginationParams
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public RequestPaginationParams()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public RequestPaginationParams(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
