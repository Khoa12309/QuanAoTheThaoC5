namespace QuanAoTheThaoC5.IRepositories
{
    public interface IAllRepositories<T> where T : class
    {
        public bool CreateItem(T item);
        public bool UpdateItem(T item);
        public bool DeleteItem(T item);
        IEnumerable<T> GetAllItems();
    }
}
