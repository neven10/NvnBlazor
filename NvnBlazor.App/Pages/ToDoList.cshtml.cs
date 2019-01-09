using Microsoft.AspNetCore.Blazor.Components;
using NvnBlazor.App.Models;
using NvnBlazor.App.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NvnBlazor.App.Pages
{
    public class ToDoListModel : BlazorComponent
    {
        [Inject]
        ToDoService ToDo { get; set; }

        public List<ToDo> todoList;

        protected async Task GetList()
        {
            todoList = await ToDo.GetAllToDo();
        }

    }
}