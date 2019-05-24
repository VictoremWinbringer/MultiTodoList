using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiTodoList.Application.Presentation.Models;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;
using MultiTodoList.Core.TodoModule.UseCase.Services;

namespace MultiTodoList.Application.Presentation.Controllers
{
    [Route("api/v1/users/{userId}/groups/")]
    [ApiController]
    public class TodoGroupsController : ControllerBase
    {
        private readonly ICreateGroup _createGroup;
        private readonly IChangeGroupColor _changeGroupColor;
        private readonly IRemoveGroup _removeGroup;

        public TodoGroupsController(ICreateGroup createGroup, IChangeGroupColor changeGroupColor,
            IRemoveGroup removeGroup)
        {
            _createGroup = createGroup;
            _changeGroupColor = changeGroupColor;
            _removeGroup = removeGroup;
        }

        [HttpPost]
        public async Task Post(Guid userId, [FromBody] GroupCreateModel group)
        {
            await _createGroup.Execute(userId, new Name(group.Name), new Color(group.Red, group.Green, group.Blue));
        }

        [HttpPut]
        public async Task Put(Guid userId, [FromBody] GroupUpdateModel group)
        {
            await _changeGroupColor.Execute(userId, new Name(group.Name),
                new Color(group.Red, group.Green, group.Blue));
        }

        [HttpDelete("{name}")]
        public async Task Delete(Guid userId, string name)
        {
            await _removeGroup.Execute(userId, new Name(name));
        }
    }
}