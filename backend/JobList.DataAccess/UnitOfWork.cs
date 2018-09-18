﻿using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Interfaces;
using JobList.DataAccess.Interfaces.Repositories;
using JobList.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JobList.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JobListDbContext context;
        private readonly IMapper mapper;

        private ISamplesRepository samplesRepository;

        public UnitOfWork(JobListDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public ISamplesRepository SamplesRepository
        {
            get
            {
                if (samplesRepository == null)
                {
                    samplesRepository = new SamplesRepository(context, mapper);
                }

                return samplesRepository;
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                var changes = context.ChangeTracker.Entries().Count(
                    p => p.State == EntityState.Modified || p.State == EntityState.Deleted
                                                         || p.State == EntityState.Added);
                if (changes == 0) return true;

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // DbSet?.Local?.Clear();
                    context?.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AbstractRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
