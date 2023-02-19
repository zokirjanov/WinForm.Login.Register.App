using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.DataAccess.Interfaces.IRepositories;
using WindowsForms.DataAccess.Repositories;
using WindowsForms.Domain.Models;
using WindowsForms.Domain.ViewModels;
using WindowsForms.Service.Common;
using WindowsForms.Service.Common.Helpers;
using WindowsForms.Service.Interfaces;

namespace WindowsForms.Service.Services
{
	public class UserServise : IUserService
	{
		private readonly IUserRepository _repository;

		public UserServise()
		{
			_repository = new UserRepository();
		}

		public async Task<(bool IsSuccesful, string Message)> LoginAsync(string login, string password)
		{
			var user = await _repository.FindByLoginAsync(login);
			if (user is null) return (IsSuccessful: false, Message: "Invalid Login");
			var hashResult = Hasher.Verify(user.PasswordHash, password, user.Salt);
			if (hashResult)
			{
				IdentitySingelton.BuildInstance(user.Id);
				return (IsSuccessful: true, Message: "");
			}

			else return (IsSuccessful: false, Message: "Invalid Password");
		}

		public async Task<(bool IsSuccesful, string Message)> RegistrationAsync(UserViewModel userCreateViewModel)
		{
			var hashresult = Hasher.Hash(userCreateViewModel.Password);
			User user = new User(userCreateViewModel.Login, hashresult.hash, hashresult.salt);
			var result = await _repository.CreateAsync(user);
			if (result) return (IsSuccessful: true, Message: "Successfull");
			else return (IsSuccesful: false, Message: "This Login already exists");
		}
	}
}
