﻿using CRM.Domain.Entities;
using CRM.Domain.Interfaces;
using CRM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    public class OpportunityRepository : IOpportunityRepository
    {
        private readonly ApplicationDbContext _opportunityContext;

        public OpportunityRepository(ApplicationDbContext opportunityContext)
        {
            _opportunityContext = opportunityContext;
        }

        public async Task<Opportunity> GetOpportunityByIdAsync(Guid opportunityId)
        {
            return await _opportunityContext.Set<Opportunity>().FindAsync(opportunityId);
        }

        public async Task<IEnumerable<Opportunity>> GetAllOpportunitiesAsync()
        {
            return await _opportunityContext.Set<Opportunity>().ToListAsync();
        }

        public async Task AddOpportunityAsync(Opportunity opportunityEntity)
        {
            await _opportunityContext.Set<Opportunity>().AddAsync(opportunityEntity);
            await _opportunityContext.SaveChangesAsync();
        }

        public async Task UpdateOpportunityAsync(Opportunity opportunityEntity)
        {
            _opportunityContext.Set<Opportunity>().Update(opportunityEntity);
            await _opportunityContext.SaveChangesAsync();
        }

        public async Task DeleteOpportunityAsync(Guid opportunityId)
        {
            var opportunity = await _opportunityContext.Set<Opportunity>().FindAsync(opportunityId);
            if (opportunity != null)
            {
                _opportunityContext.Set<Opportunity>().Remove(opportunity);
                await _opportunityContext.SaveChangesAsync();
            }
        }
    }
}