﻿using Ardalis.Specification;

namespace MyKnowledgeManager.SharedKernel.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
