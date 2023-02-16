namespace Orders.Domain.Entities
{
    public enum EnumOrderStatus
    {
        AguardandoPagamento = 1,
        PagamentoAprovado = 2,
        EnviadoParaTransportadora = 3,
        Entregue = 4,
        Cancelada = 5
    }
}
