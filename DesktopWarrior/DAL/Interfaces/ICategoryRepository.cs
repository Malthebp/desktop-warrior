using DesktopWarrior.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWarrior.DAL.Interfaces
{
    public interface ICategoryRepository : IDisposable
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
    }
}
