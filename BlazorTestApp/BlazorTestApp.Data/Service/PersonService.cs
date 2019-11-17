using BlazorTestApp.Data.Repository;
using BlazorTestApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.Data.Service
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await _personRepository.GetPeopleAsync();
        }

        public async Task<Person> GetPersonAsync(int ID)
        {
            return await _personRepository.GetPersonAsync(ID);
        }

        public async Task<int> CreatePersonAsync(Person person)
        {
            return await _personRepository.CreatePersonAsync(person);
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            return await _personRepository.UpdatePersonAsync(person);
        }

        public async Task<bool> DeletePersonAsync(Person person)
        {
            return await _personRepository.DeletePersonAsync(person);
        }
    }
}
