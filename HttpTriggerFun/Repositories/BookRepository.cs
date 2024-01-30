using HttpTriggerFun.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTriggerFun.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(CosmosContext dbContext) : base(dbContext) { }
    }
}
