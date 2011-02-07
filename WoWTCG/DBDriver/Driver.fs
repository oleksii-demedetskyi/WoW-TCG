// Learn more about F# at http://fsharp.net
namespace WoWTCGDBDriver

open System.Runtime.Serialization


open System.IO

module Accessor =     
    let desave<'T> (fileName:string) =
        let xmlSerializer = DataContractSerializer(typeof<'T>); 
        use fs = File.OpenRead(fileName)
        xmlSerializer.ReadObject(fs) :?> 'T

    let loadFromString (xml:string) = 
        let xmlSerializer = DataContractSerializer(typeof<'T>);  
        let reader = System.Xml.XmlReader.Create(new StringReader(xml))
        xmlSerializer.ReadObject(reader) :?> 'T

    let Cards (fileName:string) = 
        let cards:Program.FullCard[] = desave fileName
        cards

    let CardsFromString (xml:string) = 
        let cards:Program.FullCard[] = loadFromString xml
        cards