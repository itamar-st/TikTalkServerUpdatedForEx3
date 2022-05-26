using Domain;

namespace Services;

public interface IService<T>
{
    public List<T> GetAll();

    public T Get();
    public bool Create();

    public bool Edit();
    public bool Delete();

}
