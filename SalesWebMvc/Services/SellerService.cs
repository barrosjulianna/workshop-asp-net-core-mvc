using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById(int id)
        {
            //join das tabelas para buscar o departamento
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
        /*In SellerService, create FindById and Remove operations*/
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
