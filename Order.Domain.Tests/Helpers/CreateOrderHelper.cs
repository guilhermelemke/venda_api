using Orders.Domain.Entities;

namespace Orders.Domain.Tests.Helpers
{
    public static class CreateOrderHelper
    {
        private static readonly Seller _seller = new Seller("12344567654", "Name One", "email@email.com", "+55(11)11234-5678");
        private static readonly List<Product> _products = new List<Product>
            {
                new Product("Caneta"),
                new Product("Lápis"),
                new Product("Borracha")
            };
        private static Order _order;

        public static Order ReturnOrderWaitingForPayment()
        {
            var order = new Order(DateTime.Now.Date, _seller, _products);
            return new Order(DateTime.Now.Date, _seller, _products);
        }

        public static Order ReturnOrderPaymentApproved()
        {
            _order = new Order(DateTime.Now.Date, _seller, _products);
            _order.ChangeOrderStatusPayed();
            return _order;
        }

        public static Order ReturnOrderCancelled()
        {
            _order = new Order(DateTime.Now.Date, _seller, _products);
            _order.ChangeOrderStatusCancelled();
            return _order;
        }

        public static Order ReturnOrderShipped()
        {
            _order = new Order(DateTime.Now.Date, _seller, _products);
            _order.ChangeOrderStatusSentToShipment();
            return _order;
        }

        public static Order ReturnOrderDelivered()
        {
            _order = new Order(DateTime.Now.Date, _seller, _products);
            _order.ChangeOrderStatusDelivered();
            return _order;
        }
    }
}
