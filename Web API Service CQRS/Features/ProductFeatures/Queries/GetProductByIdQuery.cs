using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web_API_Service_CQRS.Context;
using Web_API_Service_CQRS.Models;

namespace Web_API_Service_CQRS.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly ApplicationContext _context;
            public GetProductByIdQueryHandler(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product =  _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
                if (product == null)
                    return null;
                return product;
            }
        }
    }
}
