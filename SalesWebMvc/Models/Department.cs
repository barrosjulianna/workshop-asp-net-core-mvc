using System.Collections.Generic;
using System;
using System.Linq;
namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //implementa o Departamento com o Seller
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        //construtor vazio obrigatório
        public Department() 
        { 
        }
        //construtor com argumentos n coloca as listas
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        //metodos customizados (um departamento pode ter varios vendedores)
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            //pega a lista de vendedores e soma de cada um no itnervalo de data
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }

    }
}