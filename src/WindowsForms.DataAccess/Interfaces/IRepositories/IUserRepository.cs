using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.Domain.Models;

namespace WindowsForms.DataAccess.Interfaces.IRepositories
{
	public interface IUserRepository : IGenericRepository<User>
	{
		Task<User> FindByLoginAsync(string login);
	}
}
