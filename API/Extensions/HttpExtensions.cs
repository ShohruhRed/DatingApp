using API.Helpers;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemsPerPage,
            int totalItems, int totalPages)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
          
           // response.Headers.Add("Access-Control-Allow-Headers", "*");
           // response.Headers.Add("Access-Control-Allow-Credentials", "true");
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, jsonOptions));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");   
        }
    }
}
