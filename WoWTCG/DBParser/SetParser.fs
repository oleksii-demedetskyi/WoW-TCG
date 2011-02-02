namespace Parser

open System.Xml

module SetParser = 
    let ParseCard (card:XmlNode) =
        let name = card.Attributes.["name"].Value
        (name,card)

    let ParseSet (xml:string) = 
        let doc = new XmlDocument()
        doc.LoadXml(xml)
        let root = doc.DocumentElement
        let cards = 
            root.SelectNodes("//cards/card")
            |> Seq.cast<XmlNode>
            //|> Seq.map (fun card-> ParseCard card)
            |> Seq.toList
        cards

