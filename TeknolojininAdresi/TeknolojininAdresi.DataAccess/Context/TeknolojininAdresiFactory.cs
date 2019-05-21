using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeknolojininAdresi.DataAccess.Context
{
    public class TeknolojininAdresiFactory : IDesignTimeDbContextFactory<TeknolojininAdresiContext>
    {
        public TeknolojininAdresiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TeknolojininAdresiContext>();
            optionsBuilder.UseSqlServer("Server=.; Database=TeknolojininAdresiDB; Trusted_Connection=True;");

            return new TeknolojininAdresiContext(optionsBuilder.Options);
        }
    }
}
