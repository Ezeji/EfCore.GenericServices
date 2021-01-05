﻿// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using GenericServices.Configuration;
using Tests.Dtos;
using Tests.EfClasses;

namespace Tests.Configs
{
    public class UniqueConfig : PerDtoConfig<UniqueWithConfigDto, UniqueEntity>
    {
        public override bool? UseSaveChangesWithValidation { get; } = true;
    }
}