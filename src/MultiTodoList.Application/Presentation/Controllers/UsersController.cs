using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiTodoList.Application.Presentation.Models;
using MultiTodoList.Core.TodoModule.UseCase.Services;

namespace MultiTodoList.Application.Presentation.Controllers
{
    [Route("api/v1/users/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICreateUser _createUser;
        private readonly IGetUser _getUser;
        private readonly IGetUsers _getUsers;
        private readonly IUpdateUser _updateUser;
        private readonly IDeleteUser _deleteUser;

        public UsersController(ICreateUser createUser, IGetUser getUser, IGetUsers getUsers, IUpdateUser updateUser,
            IDeleteUser deleteUser)
        {
            _createUser = createUser;
            _getUser = getUser;
            _getUsers = getUsers;
            _updateUser = updateUser;
            _deleteUser = deleteUser;
        }
        
        [HttpGet]
        public async Task<List<UserReadModel>> Get()
        {
            var users = await _getUsers.Execute();
            return users.Select(UserReadModel.From).ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<UserReadModel> Get(Guid id)
        {
            var user = await _getUser.Execute(id);
            return UserReadModel.From(user);
        }
        
        [HttpPost]
        public async Task<Guid> Post([FromBody] UserCreateModel user)
        {
           return await _createUser.Execute(user.To());
        }
        
        [HttpPut]
        public async Task Put([FromBody] UserUpdateModel user)
        {;
            await _updateUser.Execute(user.To());
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _deleteUser.Execute(id);
        }
    }
}