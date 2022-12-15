namespace Business.Abstract;

public interface IBaseRepository<Tentity>
{
    void Create(Tentity entity);
    void Update(Tentity entity);
    void Remove(Tentity entity);
}
