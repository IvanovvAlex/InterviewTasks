﻿using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Interfaces
{
    public interface IProductService
    {
        Task<Product> Create(Product newProduct);

        Task<Product> Update(Product product);

        Task Delete(string id);

        Task<Product> GetById(string id);

        Task<IEnumerable<Product>> GetAll();
    }
}
