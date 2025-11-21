namespace Domain

type ProductCode =
    | Widget of string
    | Gizmo of string

module ProductCode =
    let create (s: string) =
        if s.StartsWith("W") then Ok (Widget s)
        elif s.StartsWith("G") then Ok (Gizmo s)
        else Error "Invalid product code"
