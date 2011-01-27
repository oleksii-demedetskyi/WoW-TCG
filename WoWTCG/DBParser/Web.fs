namespace Web

open System.Net
open System.IO

module Web = 
    let LoadPage (x:WebRequest) = 
        use resp = x.GetResponse()
        let rs = resp.GetResponseStream()
        let rr = new StreamReader(rs,System.Text.Encoding.UTF8)
        rr.ReadToEnd()
    let LoadPageByURL (x:string) =
        let request = WebRequest.Create(x)
        LoadPage request