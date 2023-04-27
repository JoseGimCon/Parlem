using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parlem.Aplication.Interfaces;
using Parlem.Domain.Entities;
using Parlem.Infrastructure.Context;
using System.Security.Cryptography.X509Certificates;

namespace Parlem.Infrastructure.Repositories
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>,IRepositoryAsync<T> where T : class
    {
        private readonly ParlemDBContext _dbContext;

        public MyRepositoryAsync(ParlemDBContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }


    }
}
