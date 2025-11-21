namespace Domain

type Email = private Email of string

module Email =
    let create (s: string) =
        if System.String.IsNullOrWhiteSpace(s) || not (s.Contains("@")) then
            Error "Invalid email"
        else
            Ok (Email s)

    let value (Email e) = e
