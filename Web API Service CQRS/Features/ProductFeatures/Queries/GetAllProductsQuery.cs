using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web_API_Service_CQRS.Context;
using Web_API_Service_CQRS.Models;

namespace Web_API_Service_CQRS.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery:IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery,IEnumerable<Product>>
        {
            private readonly ApplicationContext _context;
            public GetAllProductsQueryHandler(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                    return null;

                return productList;
                
            }
        }
    }
}
