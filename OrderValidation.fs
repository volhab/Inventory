namespace Workflows

open Domain
open Domain.Result

module OrderValidation =

    let validateLine (productCodeStr, qty) =
        match ProductCode.create productCodeStr with
        | Error e -> Error e
        | Ok product ->
            if qty <= 0 then Error "Quantity must be greater than 0"
            else Ok { Product = product; Quantity = qty }

    let validateOrder (unvalidated : UnvalidatedOrder) =
        result {
            let! email = Email.create unvalidated.CustomerEmail

            let! lines =
                unvalidated.Lines
                |> List.map validateLine
                |> List.fold (fun acc elem ->
                    match acc, elem with
                    | Error e, _ -> Error e
                    | _, Error e -> Error e
                    | Ok list, Ok line -> Ok (line :: list)
                ) (Ok [])

            return {
                OrderId = OrderId.create()
                CustomerEmail = email
                Lines = List.rev lines
            }
        }
