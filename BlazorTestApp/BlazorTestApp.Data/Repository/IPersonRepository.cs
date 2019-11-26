using BlazorTestApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient.Base.Delegates;
using TableDependency.SqlClient.Base.EventArgs;

namespace BlazorTestApp.Data.Repository
{
    public interface IPersonRepository
    {
        event ChangedEventHandler<Person> personChangedEvent;
        Task<IEnumerable<Person>> GetPeopleAsync();

        Task<Person> GetPersonAsync(int ID);

        Task<int> CreatePersonAsync(Person person);

        Task<bool> UpdatePersonAsync(Person person);

        Task<bool> DeletePersonAsync(Person person);
    }
}
