using EtourBackFinal.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EtourBackFinal.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class SearchController : ControllerBase
        {
            private readonly ETourContext _context;

            public SearchController(ETourContext context)
            {
                _context = context;
            }

            [HttpPost]
            public async Task<SearchResponse> Search(SearchResult request)
            {
                var query =from date in _context.DateMaster
                            join cost in _context.CostMaster on date.MasterId
                            equals cost.MasterId
                            join category in _context.CategoryMaster on cost.MasterId
                            equals category.MasterId
                            where request.DepartureDate <= date.DepartureDate &&
                            request.EndDate >= date.EndDate && request.EndDate >= date.EndDate &&
                            request.NoOfDays >= date.NoOfDays && request.SinglePersonCost >= cost.SinglePersonCost && category.ToNewTab == true
                            select new
                            {
                                category,
                                date.DepartureDate,
                                date.EndDate,
                                cost.SinglePersonCost,
                                date.NoOfDays

                            };
                var queryresult = await query.ToListAsync();
                if (queryresult == null)
                {
                    return new SearchResponse { Success = false };
                }
                else
                {
                    var searchResults = await query.Select(q => new SearchResult

                    {
                        MasterId=q.category.MasterId,
                        CategoryName = q.category.CategoryName,
                        DepartureDate = q.DepartureDate,
                        EndDate = q.EndDate,
                        NoOfDays = q.NoOfDays,
                        SinglePersonCost = q.SinglePersonCost
                    }).ToListAsync();
                    return new SearchResponse { Results = searchResults,Success = true};
                }
            }

            public class SearchResponse
            {
                public bool Success { get; set; }
                public List<SearchResult> Results { get; set; }
            }
            public class SearchResult
            {
                public int MasterId { get; set; }
                public string? CategoryName { get; set; }
                public DateTime? DepartureDate { get; set; }
                public DateTime? EndDate { get; set; }
                public double? SinglePersonCost { set; get; }
                public int NoOfDays { get; set; }
            }
        }
    }
