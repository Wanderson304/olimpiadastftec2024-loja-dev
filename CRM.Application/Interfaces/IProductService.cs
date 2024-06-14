﻿using CRM.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllAsync();
    Task<ProductDTO> GetByIdAsync(Guid id);
    Task AddAsync(ProductDTO product);
    Task UpdateAsync(ProductDTO product);
    Task DeleteAsync(Guid id);
}