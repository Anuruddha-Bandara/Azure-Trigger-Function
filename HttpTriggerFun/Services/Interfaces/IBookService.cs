using HttpTriggerFun.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTriggerFun.Services.Interfaces
{
    public interface IBookService : IService<Book>
    {
        public Task<bool> CheckForConflictingBook(Book book);
    }
}
