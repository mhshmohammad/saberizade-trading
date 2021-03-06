﻿using ST.EntityFramework;
using EntityFramework.DynamicFilters;

namespace ST.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly STDbContext _context;

        public InitialHostDbBuilder(STDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
