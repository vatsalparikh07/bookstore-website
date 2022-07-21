using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Respositary
{
    public class BaseRepository
    {
        protected readonly bookStoreContext _context = new bookStoreContext();
    }
}
