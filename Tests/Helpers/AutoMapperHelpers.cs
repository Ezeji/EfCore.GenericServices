﻿// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System;
using AutoMapper;
using GenericServices.Configuration;
using GenericServices.PublicButHidden;
using GenericServices.Setup.Internal;

namespace Tests.Helpers
{
    public static class AutoMapperHelpers
    {
        public static MapperConfiguration CreateReadConfig<TEntity, TDto>(Action<IMappingExpression<TEntity, TDto>> alterMapping)
        {
            var readProfile = new MappingProfile(false);
            alterMapping(readProfile.CreateMap<TEntity, TDto>());
            var readConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(readProfile);
            });
            return readConfig;
        }

        public static WrappedAndMapper CreateWrapperMapper<TDto, TEntity>()
        {
            var readProfile = new MappingProfile(false);
            readProfile.CreateMap<TEntity, TDto>();
            var readConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(readProfile);
            });

            var saveProfile = new MappingProfile(true);
            saveProfile.CreateMap<TDto, TEntity>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            var saveConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(saveProfile);
            });
            return new WrappedAndMapper(new GenericServicesConfig(), readConfig, saveConfig);
        }
    }
}