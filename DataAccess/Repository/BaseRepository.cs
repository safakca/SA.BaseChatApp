using DataAccess.Context;

namespace DataAccess.Repository;

public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : class
{
    private readonly BaseContext _context;

    public BaseRepository(BaseContext context)
    {
        _context = context;
    }

    public void Create(Tentity entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }
    public void Remove(Tentity entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public void Update(Tentity entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
    }
}
