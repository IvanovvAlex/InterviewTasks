﻿using Microsoft.AspNetCore.Http;
using OnlineStore.Common.Responses.OrderResponses;
using OnlineStore.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Common.Responses.ProductResponses
{
    public class GetAllProductsResponse
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
