﻿// Copyright (c) 2018 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Linq;
using DataLayer.EfCode;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.HomeServices.Dtos;
using ServiceLayer.HomeServices.QueryObjects;

namespace ServiceLayer.HomeServices.Services
{
    public class ListBooksService : IListBooksService
    {
        private readonly EfCoreContext _context;

        public ListBooksService(EfCoreContext context)
        {
            _context = context;
        }

        public IQueryable<BookListDto> SortFilterPage
            (SortFilterPageOptions options)
        {
            var booksQuery = _context.Books            
                .AsNoTracking()                        
                .MapBookToDto()                        
                .OrderBooksBy(options.OrderByOptions)  
                .FilterBooksBy(options.FilterBy,       
                               options.FilterValue);   

            options.SetupRestOfDto(booksQuery);        

            return booksQuery.Page(options.PageNum-1,  
                                   options.PageSize);  
        }
    }

}