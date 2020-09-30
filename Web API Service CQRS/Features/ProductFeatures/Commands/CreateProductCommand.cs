using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web_API_Service_CQRS.Context;
using Web_API_Service_CQRS.Models;

namespace Web_API_Service_CQRS.Features.ProductFeatures.Commands
{
    public class CreateProductCommand:IRequest<int>
    {
        public string Name { get; set; }

        public string Barcode { get; set; }
        public bool IsActive { get; set; }

        public decimal Rate { get; set; }

        public decimal BuyingPrice { get; set; }

        public class CreateProductCommandHandler:IRequestHandler<CreateProductCommand,int>
        {
            private readonly IApplicationContext _context;

            public CreateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Name = command.Name;
                product.Barcode = command.Barcode;
                product.IsActive = command.IsActive;
                product.Rate = command.Rate;
                product.BuyingPrice = command.BuyingPrice;

                _context.Products.Add(product);
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}
