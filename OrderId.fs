namespace Domain

type OrderId = private OrderId of System.Guid

module OrderId =
    let create() = OrderId(System.Guid.NewGuid())
    let value (OrderId id) = id
