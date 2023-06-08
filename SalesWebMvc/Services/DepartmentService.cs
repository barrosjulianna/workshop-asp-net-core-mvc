using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        //dependencia para o dbcontext
        private readonly SalesWebMvcContext _context;

        //contrutor
        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> FindAllAsync()
        {
            //task capsula a operacao assicrona deixando o processo mais facil
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();

        }
    }
}
