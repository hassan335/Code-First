﻿using AutoMapper;
using Khuari.DTO;
using Khuari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khuari.App_Start
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>().ForMember(dest => dest.C_Id , opt => opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(dest => dest.C_Id, opt => opt.Ignore());
        }
    }
}