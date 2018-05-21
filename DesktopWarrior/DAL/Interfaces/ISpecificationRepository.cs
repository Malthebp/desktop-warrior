using DesktopWarrior.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopWarrior.DAL.Interfaces
{
    public interface ISpecificaitonRepository : IDisposable
    {
        List<Specification> GetSpecifications();
        List<Specification> GetSpecificationsByProductId(int productId);
        void DeleteSpecification(int specificationId);
        void InsertSpecification(Specification specification);
        void Save();
    }
}
