using HttpTriggerFun.Model;
using HttpTriggerFun.Repositories;
using HttpTriggerFun.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTriggerFun.Services
{
    public class BookService : Service<Book>, IBookService
    {
        public BookService(IRepository<Book> repository) : base(repository) { }

        public async Task<bool> CheckForConflictingBook(Book book)
        {
            return (await _repository.GetByCondition(x => x.Title == book.Title)).Any();
        }
    }
}
