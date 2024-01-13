using AutoMapper;
using PerfectInstadee.Data.DTOs;
using PerfectInstadee.Models;

namespace PerfectInstadee.Data.Profiles
{
    public class ContactProfile :Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactReadDTO>();
            CreateMap<ContactCreateDTO, Contact>();
        }
    }
}
