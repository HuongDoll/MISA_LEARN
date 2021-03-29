using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Cukcuk.WebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Cukcuk.WebApi.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public static List<Person> Persons = new List<Person>()
        {
            new Person()
            {
                CustomerId = Guid.NewGuid(),
                CustomerCode = "KH11091999",
                FullName = "Huong Doll",
                Gender = 1,
                Address = "Hà Nội",
                DateOfBirth = DateTime.Now,
                Email = "huongdoll@gmail.com",
                PhoneNumber = "0973843806",
                CustomerGroupId = new Guid(),
                DebitAmount = 0,
                MemberCardCode = "",
                CompanyName = "MISA",
                CompanyTaxCode = "",
                IsStopFollow = false,
                CustomerGroupName = "Khách VIP",
                GenderName = "Nữ",
                MISAEntityState = 0
            },
            new Person()
            {
                CustomerId = Guid.NewGuid(),
                CustomerCode = "KH000001236822",
                FullName = "Huong Doll 2",
                Gender = 2,
                Address = "Hà Nội",
                DateOfBirth = DateTime.Parse("2021-03-11"),
                Email = "manh@yahaaooh",
                PhoneNumber = "18001234111",
                CustomerGroupId = new Guid(),
                DebitAmount = 0,
                MemberCardCode = "",
                CompanyName = "MISA",
                CompanyTaxCode = "",
                IsStopFollow = false,
                CustomerGroupName = "Khách vãng lai 2",
                GenderName = "Nữ",
                MISAEntityState = 0
            },
            new Person()
            {
                CustomerId = Guid.NewGuid(),
                CustomerCode = "KH0000012368",
                FullName = "Huong Doll 3",
                Gender = 0,
                Address = "Thais Binhf",
                DateOfBirth = DateTime.Parse("2021-03-11"),
                Email = "manh@yahooh",
                PhoneNumber = "18001234111",
                CustomerGroupId = new Guid(),
                DebitAmount = 0,
                MemberCardCode = "",
                CompanyName = "MISA",
                CompanyTaxCode = "",
                IsStopFollow = false,
                CustomerGroupName = "Khách vãng lai3",
                GenderName = "Nữ",
                MISAEntityState = 0
            },
            new Person()
            {
                CustomerId = Guid.NewGuid(),
                CustomerCode = "KH0000012368",
                FullName = "Huong Doll 4",
                Gender = 0,
                Address = "Thanh Hoas",
                DateOfBirth = DateTime.Parse("2021-03-11"),
                Email = "manh@yahooh",
                PhoneNumber = "18001234111",
                CustomerGroupId = new Guid(),
                DebitAmount = 0,
                MemberCardCode = "",
                CompanyName = "MISA",
                CompanyTaxCode = "",
                IsStopFollow = false,
                CustomerGroupName = "Khách vãng lai 4",
                GenderName = "Nữ",
                MISAEntityState = 0
            },
            new Person()
            {
                CustomerId = Guid.NewGuid(),
                CustomerCode = "KH0000012368",
                FullName = "Huong Doll 5",
                Gender = 0,
                Address = "bachs khoa",
                DateOfBirth = DateTime.Parse("2021-03-11"),
                Email = "manh@yahooh",
                PhoneNumber = "18001234111",
                CustomerGroupId = new Guid(),
                DebitAmount = 0,
                MemberCardCode = "",
                CompanyName = "MISA",
                CompanyTaxCode = "",
                IsStopFollow = false,
                CustomerGroupName = "Khách vãng lai5",
                GenderName = "Nữ",
                MISAEntityState = 0
            },
        };

        public PersonController()
        {

        }

        [HttpGet]

        public List<Person> GetPeople()
        {
            return Persons;
        }
        /// <summary>
        /// thêm mọt người dùng mới 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        /// create by huongdoll 24.03.2021
        /// modified by huongdoll

        [HttpGet("{customerId}")]
        public Person GetPetsonByID([FromRoute] string CustomerId)
        {
            Guid.TryParse(CustomerId, out Guid idPerson);
            if (idPerson == null)
            {
                return null;
            }

            var personFind = Persons.Where(p => p.CustomerId == idPerson).FirstOrDefault();
            if (personFind == null)
            {
                return null;
            }
            return personFind;
        }

        [HttpPost]
        public string InsertPeople(Person person)
        {
            try
            {
                if (person != null)
                {
                    Guid personID = Guid.NewGuid();
                    person.CustomerId = personID;
                    Persons.Add(person);
                }
            }
            catch (Exception)
            {

                return "fail";
            }
            return "success";
        }
        [HttpDelete("{customerId}")]
        public string DeletePeople([FromRoute] string customerId)
        {
            Guid.TryParse(customerId, out Guid idPerson);
            if (idPerson != null && idPerson != Guid.Empty)
            {
                try
                {
                    var personFind = Persons.Where(p => p.CustomerId == idPerson).FirstOrDefault();
                    if(personFind != null)
                    {
                        Persons.Remove(personFind);
                        return "success!";
                    }
                    else
                    {
                        return "not exit!";
                    }
                }
                catch (Exception)
                {

                    throw;
                    return "error!";
                }
            }
            else
            {
                return "id null";
            }
        }

        [HttpPut("{customerId}")]
        public string Put([FromRoute] string CustomerId, [FromBody] Person person)
        {
            try
            {
                if (person != null)
                {
                    Guid.TryParse(CustomerId, out Guid idPerson);
                    if (idPerson == null)
                    {
                        return "fail";
                    }

                    var personFind = Persons.Where(p => p.CustomerId == idPerson).FirstOrDefault();

                    if (personFind != null)
                    {

                        personFind.CustomerCode = person.CustomerCode;
                        personFind.FullName = person.FullName;
                        personFind.Gender = person.Gender;
                        personFind.Address = person.Address;
                        personFind.DateOfBirth = person.DateOfBirth;
                        personFind.Email = person.Email;
                        personFind.PhoneNumber = person.PhoneNumber;
                        personFind.CustomerGroupId = person.CustomerGroupId;
                        personFind.DebitAmount = person.DebitAmount;
                        personFind.MemberCardCode = person.MemberCardCode;
                        personFind.CompanyName = person.CompanyName;
                        personFind.CompanyTaxCode = person.CompanyTaxCode;
                        personFind.IsStopFollow = person.IsStopFollow;
                        personFind.CustomerGroupName = person.CustomerGroupName;
                        personFind.GenderName = person.GenderName;
                        personFind.MISAEntityState = person.MISAEntityState;
                    }
                    else
                    {
                        return "Not exit";
                    }
                }
            }
            catch (Exception)
            {

                return "fail";
            }
            return "success";
        }

    }
}
