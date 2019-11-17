using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using BlazorTestApp.Domain.Models;
using Dapper.Contrib.Extensions;

namespace BlazorTestApp.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private string _ConnString;

        public PersonRepository(string ConnString)
        {
            _ConnString = ConnString;
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
