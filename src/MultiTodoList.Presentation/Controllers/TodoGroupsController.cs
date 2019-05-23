using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiTodoList.Core.TodoModule.Domain.ValueObjects;
using MultiTodoList.Core.TodoModule.UseCase.Services;

namespace MultiTodoList.Presentation.Controllers
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

        [HttpDelete]
        public async Task Delete(Guid userId, [FromBody] GroupDeleteModel group)
        {
            await _removeGroup.Execute(userId, new Name(group.Name));
        }
    }

    public class GroupDeleteModel
    {
        public string Name { get; set; }
    }

    public class GroupUpdateModel
    {
        public string Name { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }

    public class GroupCreateModel
    {
        public string Name { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }
}