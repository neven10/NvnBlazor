using Microsoft.EntityFrameworkCore;
using NvnBlazor.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NvnBlazor.App.Services
{
    public class ToDoService
    {

        public async Task<List<ToDo>> GetAllToDo()
        {
            using (var db = new DbNevenBlazorContext())
            {
                return await db.ToDos.ToListAsync();
            }
        }
    }
}
