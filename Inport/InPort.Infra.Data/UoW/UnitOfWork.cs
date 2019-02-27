﻿using InPort.Domain.Core;
using InPort.Infra.Data.Context;

namespace InPort.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InPortDbContext _context;

        public UnitOfWork(InPortDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}