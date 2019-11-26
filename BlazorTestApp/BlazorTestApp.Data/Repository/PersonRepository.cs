using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using BlazorTestApp.Domain.Models;
using Dapper.Contrib.Extensions;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Delegates;
using TableDependency.SqlClient.Base.EventArgs;

namespace BlazorTestApp.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private string _ConnString;
        
        public event ChangedEventHandler<Person> personChangedEvent;

        private SqlTableDependency<Person> _sqlTableDependency;

        public PersonRepository(string ConnString)
        {
            _ConnString = ConnString;
            _sqlTableDependency = new SqlTableDependency<Person>(_ConnString, "Person");

            SetSqlDependency();
        }

        private void SetSqlDependency()
        {
            _sqlTableDependency.OnChanged += (s, e) => personChangedEvent.Invoke(s, e);
            _sqlTableDependency.Start();
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            using (var conn = new SqlConnection(_ConnString))
            {
                return await conn.GetAllAsync<Person>();
            }
        }

        public async Task<Person> GetPersonAsync(int ID)
        {
            using (var conn = new SqlConnection(_ConnString))
            {
                return await conn.GetAsync<Person>(ID);
            }
        }

        public async Task<int> CreatePersonAsync(Person person)
        {
            using (var conn = new SqlConnection(_ConnString))
            {
                person.DateCreated = DateTime.Now;
                return await conn.InsertAsync<Person>(person);
            }
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            using (var conn = new SqlConnection(_ConnString))
            {
                return await conn.UpdateAsync<Person>(person);
            }
        }

        public async Task<bool> DeletePersonAsync(Person person)
        {
            using (var conn = new SqlConnection(_ConnString))
            {
                return await conn.DeleteAsync<Person>(person);
            }
        }
    }
}
