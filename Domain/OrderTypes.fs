namespace Domain

open System

type OrderLine = {
    Product : ProductCode
    Quantity : int
}

type UnvalidatedOrder = {
    OrderId : Guid
    CustomerEmail : string
    Lines : (string * int) list
}

type ValidatedOrder = {
    OrderId : OrderId
    CustomerEmail : Email
    Lines : OrderLine list
}

type PlacedOrder = {
    Order : ValidatedOrder
    PlacedAt : DateTime
}
