using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.Domain.ViewModels;

namespace WindowsForms.Service.Interfaces
{
	public interface IUserService
	{
		Task<(bool IsSuccesful, string Message)> RegistrationAsync(UserViewModel userCreateViewModel);
		Task<(bool IsSuccesful, string Message)> LoginAsync(string login, string password);
	}
}
