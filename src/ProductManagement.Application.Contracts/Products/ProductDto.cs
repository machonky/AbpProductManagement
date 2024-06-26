﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProductManagement.Products;

public class ProductDto : AuditedEntityDto<Guid>
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public bool IsFreeCargo { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ProductStockState StockState { get; set; }
}
