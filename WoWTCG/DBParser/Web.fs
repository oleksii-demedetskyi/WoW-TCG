namespace Parser

open System.Net
open System.IO
open System
open HtmlAgilityPack

module Web = 
    let LoadPageByURL (x:string) =
        let loader = new HtmlWeb()
        loader.Load(x)

    let LoadDeck (x:int) = 
        let url = "http://wow.tcgplayer.com/db/deck_print.asp?ID="+x.ToString()
        LoadPageByURL url

    let LoadCard (name:string) =
        let url = "http://wow.tcgplayer.com/db/world_of_warcraft_tcg_single_card.asp?cn="+Uri.EscapeDataString(name)
        LoadPageByURL(url)
