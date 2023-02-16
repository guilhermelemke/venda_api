namespace Orders.Domain.Entities
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; private set; }
        public EnumOrderStatus Status { get; private set; }
        public Guid SellerId { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Order() { }

        public Order(DateTime orderDate, Seller seller, ICollection<Product> products)
        {
            OrderDate = orderDate;
            Status = EnumOrderStatus.AguardandoPagamento;
            Seller = seller;
            Products = products.ToList();
        }

        public void ChangeOrderStatusDelivered()
        {
            Status = EnumOrderStatus.Entregue;
        }

        public void ChangeOrderStatusPayed()
        {
            Status = EnumOrderStatus.PagamentoAprovado;
        }

        public void ChangeOrderStatusCancelled()
        {
            Status = EnumOrderStatus.Cancelada;
        }

        public void ChangeOrderStatusSentToShipment()
        {
            Status = EnumOrderStatus.EnviadoParaTransportadora;
        }
    }
}
