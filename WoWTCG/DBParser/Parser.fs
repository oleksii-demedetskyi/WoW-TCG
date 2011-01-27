namespace Parser

open HtmlAgilityPack

module Parser =    
    let ParseDeck (x:HtmlNode) =
        let hrefs = x.SelectNodes("//a[@href]") |> Seq.toList
        let hero = hrefs.[0]
        hero