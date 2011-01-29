namespace Parser

open HtmlAgilityPack
open System 

type Card =
    { 
        Title: string;
        Type: string;
        Cost: string; //int;
        ATK: string; //int;
        Health: string; //int;
        Faction: string;
        Class: string;
        Race: string;
        Text: string;
    }

module Parser =    
    let ParseCard (page:HtmlNode) =
        let xpath = "/html[1]/body[1]/table[1]/tr[1]/td[1]/table[2]/tr[1]/td[3]/table[1]"
        let cardInfoNode = page.SelectSingleNode(xpath)

        let tagText (x:string) = 
            cardInfoNode.SelectSingleNode(x).InnerText
        let tagAlt (x:string) = 
            cardInfoNode.SelectSingleNode(x).GetAttributeValue("alt","X3")
        let tagSrc (x:string) = 
            let img = cardInfoNode.SelectSingleNode(x).GetAttributeValue("src","")
            "http://wow.tcgplayer.com"+img

        let image = tagSrc "tr/td[2]/img"
        let set = tagText "tr[2]/td[2]/a"
                
        // Returning a datas
        let card: Card = { 
            Title = tagAlt "tr/td[2]/img"; 
            Type = tagText "tr[3]/td[2]/a"; 
            Cost = tagText "tr[5]/td[2]";// |> Int32.Parse; 
            ATK = tagText "tr[6]/td[2]";// |> Int32.Parse; 
            Health = tagText "tr[7]/td[2]";// |> Int32.Parse;
            Faction = tagAlt "tr[8]/td[2]/img";
            Class = tagAlt "tr[9]/td[2]/img";
            Race = tagText "tr[10]/td[2]";
            Text = tagText "tr[12]/td[2]";
            }
        card
    
    let ParseHero (x:HtmlNode) =
        x

    let ParseDeck (x:HtmlNode) =
        //let hero = ParseHero x.SelectSingleNode("//a[@href]")
        let cards = 
            x.SelectNodes("//a[@href and position() > 1]") 
            |> Seq.map (fun x -> x.GetAttributeValue("href",""))
            |> Seq.map (fun x -> Parser.Web.LoadPageByURL x)
            |> Seq.map (fun x -> ParseCard x.DocumentNode)
            |> Seq.toList
        cards

    let GetDeck (x:int) = 
        ParseDeck (Parser.Web.LoadDeck x).DocumentNode
