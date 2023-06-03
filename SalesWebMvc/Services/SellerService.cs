﻿using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        //dependencia para o dbcontext
        private readonly SalesWebMvcContext _context;

        //contrutor
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }
        //retornar uma lissta com todos os vendedores do banco (In SellerService, implement FindAll, returning List<Seller>
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList(); 
        }

    }
}