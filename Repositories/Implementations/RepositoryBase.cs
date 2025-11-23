using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Data;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implementations;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected AppDbContext _context;

    protected RepositoryBase(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> FindAll(bool trackChanges) {
        return !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
    }
       

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) {
        return !trackChanges ? 
            _context.Set<T>().Where(expression).AsNoTracking() : 
            _context.Set<T>().Where(expression);
    }


    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}
