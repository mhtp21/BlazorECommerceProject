﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;

namespace Application.Features.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailViewModel>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
