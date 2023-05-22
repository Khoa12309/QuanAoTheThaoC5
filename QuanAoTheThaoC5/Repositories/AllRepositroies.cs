using Microsoft.EntityFrameworkCore;
using QuanAoTheThaoC5.ContextDataBase;
using QuanAoTheThaoC5.IRepositories;
using QuanAoTheThaoC5.Models;

namespace QuanAoTheThaoC5.Repositories
{
    public class AllRepositroies<T> : IAllRepositories<T> where T : class
    {
        ShoppingDbContext _context;
        DbSet<T> _dbSet;
        public AllRepositroies()
        {
           
        }

        public AllRepositroies(ShoppingDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public bool CreateItem(T item)
        {
            try
            {
                _dbSet.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteItem(T item)
        {
            try
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<T> GetAllItems()
        {
            return _dbSet.ToList();
        }

        public bool UpdateItem(T item)
        {
            try
            {
                _dbSet.Update(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
