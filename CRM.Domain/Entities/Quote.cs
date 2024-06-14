﻿using System;
using System.Diagnostics;

namespace CRM.Domain.Entities;

public sealed class Quote : Entity
{
    public Guid QuoteID { get; set; }
    public Nullable<Guid> OpportunityID { get; set; }
    public Nullable<Guid> ProductID { get; set; }
    public Nullable<Guid> PriceLevelID { get; set; }
    public Nullable<Guid> EventID { get; set; }
    public Nullable<int> Quantity { get; set; }
    public Nullable<decimal> Discount { get; set; }
    public Nullable<decimal> TotalPrice { get; set; }


    //Navigation properties
    public Opportunity Opportunity { get; set; }
    public Product Product { get; set; }
    public PriceLevel PriceLevel { get; set; }
    public Event Event { get; set; } // Adicionada a propriedade de navegação para Event
}