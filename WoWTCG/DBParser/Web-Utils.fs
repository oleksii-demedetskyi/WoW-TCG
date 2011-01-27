open System.Net;
open System;
module Web_Utils

let LoadPage (x:WepRequest) = 
    use resp = x.GetResponse();
    let rs = resp.GetResponseStream;

