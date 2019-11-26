using BlazorTestApp.Data.Repository;
using BlazorTestApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.Data.Service
{
    public interface IPersonService
    {

        event Action RefreshPerson;
        Task<IEnumerable<Person>> GetPeopleAsync();
        
        Task<Person> GetPersonAsync(int ID);

        Task<int> CreatePersonAsync(Person person);

        Task<bool> UpdatePersonAsync(Person person);

        Task<bool> DeletePersonAsync(Person person);

    }
}
