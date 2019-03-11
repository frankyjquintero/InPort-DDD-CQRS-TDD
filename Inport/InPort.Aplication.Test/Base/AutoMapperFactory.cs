using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InPort.Aplication.AutoMapper;

namespace InPort.Aplication.Test.Base
{
    public static class AutoMapperFactory
    {
        public static IMapper Create()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
