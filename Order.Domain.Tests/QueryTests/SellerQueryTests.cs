using Orders.Domain.Entities;
using Orders.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Tests.QueryTests
{
    [TestClass]
    [TestCategory("Queries")]
    public class SellerQueryTests
    {
        private List<Seller> _sellers;

        public SellerQueryTests()
        {
            _sellers = new List<Seller>();
            _sellers.Add(new Seller("12345678911", "Seller One", "seller.one@email.com", "+55(11)11234-1111"));
            _sellers.Add(new Seller("12345678922", "Seller Two", "seller.two@email.com", "+55(11)11234-2222"));
            _sellers.Add(new Seller("12345678933", "Seller Three", "seller.three@email.com", "+55(11)11234-3333"));
            _sellers.Add(new Seller("12345678944", "Seller Four", "seller.four@email.com", "+55(11)11234-4444"));
            _sellers.Add(new Seller("12345678955", "Seller Five", "seller.five@email.com", "+55(11)11234-5555"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todos_os_vendedores()
        {
            var results = _sellers.AsQueryable().Where(SellerQueries.GetAll());
            Assert.AreEqual(5, results.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_o_vendedor_por_nome()
        {
            var results = _sellers.AsQueryable().Where(SellerQueries.GetByName("Seller Three"));
            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_o_vendedor_por_id()
        {
            var results = _sellers.AsQueryable().Where(SellerQueries.GetById(_sellers[4].Id));
            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_o_vendedor_por_cpf()
        {
            var results = _sellers.AsQueryable().Where(SellerQueries.GetByCpf("12345678944"));
            Assert.AreEqual(1, results.Count());
        }
    }
}
