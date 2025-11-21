namespace Domain

module Result =

    type ResultBuilder() =
        member _.Bind(m, f) = Result.bind f m
        member _.Return(v) = Ok v
        member _.ReturnFrom(m) = m

    let result = ResultBuilder()

