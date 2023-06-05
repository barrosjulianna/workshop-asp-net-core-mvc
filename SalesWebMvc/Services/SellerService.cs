using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

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
        public void Update(Seller obj)
        {
            //testa no abnco de dados se ja tem algum vendedor x com o id do obj passado
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
         
        }
    }
}
