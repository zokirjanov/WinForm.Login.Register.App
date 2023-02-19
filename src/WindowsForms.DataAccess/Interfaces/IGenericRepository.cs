using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.DataAccess.Interfaces
{
	public interface IGenericRepository<T>
	{
		 Task<bool> CreateAsync(T entity);
		 Task<T> GetAsync(int id);
		 Task<List<T>> GetAllAsync();
	}
}
