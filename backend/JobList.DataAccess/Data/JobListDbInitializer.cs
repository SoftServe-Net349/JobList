using Bogus;
using JobList.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobList.DataAccess.Data
{
    public static class JobListDbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder, int amount = 10)
        {
        }
    }
}
