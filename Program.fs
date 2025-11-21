open System
open Domain
open Domain.Email
open Workflows
open Workflows.OrderValidation
open Workflows.OrderPlacement

[<EntryPoint>]
let main argv =

    let unvalidated: UnvalidatedOrder = {
        OrderId = Guid.NewGuid()
        CustomerEmail = "test@example.com"
        Lines = [ ("W123", 2); ("G456", 1) ]
    }

    match validateOrder unvalidated with
    | Error e ->
        printfn "Order validation failed: %s" e
    | Ok validated ->
        let placed = placeOrder validated
        printfn "Order placed successfully at %A" placed.PlacedAt
        printfn "Email: %s" (validated.CustomerEmail |> value)
        for line in validated.Lines do
            printfn " - %A x%d" line.Product line.Quantity

    0
