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
                CustomerId = new Guid(),
                CustomerCode = "KH0000012368",
                FullName = "Huong Doll",
                Gender = 0,
                Address = "Hà Nội",
                DateOfBirth = new DateTime(2021-03-11),
                Email = "manh@yahooh",
                PhoneNumber = "18001234111",
                CustomerGroupId = new Guid(),
                DebitAmount = 0,
                MemberCardCode = "",
                CompanyName = "MISA",
                CompanyTaxCode = "",
                IsStopFollow = false,
                CustomerGroupName = "Khách vãng lai",
                GenderName = "Nữ",
                MISAEntityState = 0
            },
            new Person()
            {
                CustomerId = new Guid(),
                CustomerCode = "KH000001236822",
                FullName = "Huong Doll 2",
                Gender = 0,
                Address = "Hà Nội",
                DateOfBirth = new DateTime(2021-03-11),
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
                CustomerId = new Guid(),
                CustomerCode = "KH0000012368",
                FullName = "Huong Doll 3",
                Gender = 0,
                Address = "Thais Binhf",
                DateOfBirth = new DateTime(2021-03-11),
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
                CustomerId = new Guid(),
                CustomerCode = "KH0000012368",
                FullName = "Huong Doll 4",
                Gender = 0,
                Address = "Thanh Hoas",
                DateOfBirth = new DateTime(2021-03-11),
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
                CustomerId = new Guid(),
                CustomerCode = "KH0000012368",
                FullName = "Huong Doll 5",
                Gender = 0,
                Address = "bachs khoa",
                DateOfBirth = new DateTime(2021-03-11),
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

        [Route("GET")]
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
        [Route("insert")]
        [HttpPost]
        public string InsertPeople(Person person)
        {
            try
            {
                if (person != null)
                {
                    Persons.Add(person);
                }
            }
            catch (Exception)
            {

                return "fail";
            }
            return "success";
        }

        [Route("update/{CustomerId}")]
        [HttpPut]
        public string UpdatePeople([FromRoute] string CustomerId, [FromBody] Person person)
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
