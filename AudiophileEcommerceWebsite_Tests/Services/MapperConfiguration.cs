using AudiophileEcommerceWebsite.Profiles;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiophileEcommerceWebsite_Tests.Services
{
    public static class ConfigureMapper
    {
        public static Mapper mapper { get; private set; }
        static ConfigureMapper()
        {
            var mapperConfiguration = new MapperConfiguration(
               cfg => cfg.AddProfile<AudiophileProfile>());

            mapper = new Mapper(mapperConfiguration);
        }
    }
}
