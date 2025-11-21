namespace Workflows

open System
open Domain

module OrderPlacement =
    let placeOrder (validated : ValidatedOrder) =
        {
            Order = validated
            PlacedAt = DateTime.UtcNow
        }
