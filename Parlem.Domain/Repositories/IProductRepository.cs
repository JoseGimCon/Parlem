using Parlem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Domain.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Registro de un customer
        /// </summary>
        /// <param name="product"></param>
        void Create(Product product);

        /// <summary>
        /// Actualizacion de un rebelde
        /// </summary>
        /// <param name="rebel"></param>
        void Update(Product product);

        /// <summary>
        /// Eliminacion de un rebelde
        /// </summary>
        /// <param name="customer"></param>
        void Remove(Product product);
        /// <summary>
        /// Listado de Customers registrados
        /// </summary>
        /// <returns>List de Customers</returns>
        List<Customer> GetAllCustomers();
    }
}
