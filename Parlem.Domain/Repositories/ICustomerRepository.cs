using Parlem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Domain.Repositories
{
    /// <summary>
    /// Contrato del repositorio de la entidad Customer
    /// </summary>
    public interface ICustomerRepository
    { 
        /// <summary>
        /// Registro de un customer
        /// </summary>
        /// <param name="customer"></param>
        void Create(Customer customer);

        /// <summary>
        /// Actualizacion de un rebelde
        /// </summary>
        /// <param name="rebel"></param>
        void Update(Customer customer);

        /// <summary>
        /// Eliminacion de un rebelde
        /// </summary>
        /// <param name="customer"></param>
        void Remove(Customer customer);

        /// <summary>
        /// Busqueda de un customer por id
        /// </summary>
        /// <returns>Customers</returns>
        Customer Find(Guid id);
        /// <summary>
        /// Listado de Customers registrados
        /// </summary>
        /// <returns>List de Customers</returns>
        List<Customer> GetAllCustomers();
    }
}
