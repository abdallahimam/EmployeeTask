using EmployeeTask.Dtos;

namespace EmployeeTask.Helpers
{
    public class Pagination
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public IReadOnlyList<EmployeeDto> EmployeeDtos { get; set; }

        public Pagination(int totalItems, int page, int pageSize)
        {
            int currentPage = page;
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}
