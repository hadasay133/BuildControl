namespace BuildControl.Service.Interface
{
    public interface IJsonActions<T>
    {

        void AddValueToDB(T entity);
        void RemoveValueFromDB(int id);
        void UpdateValueInDB(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
