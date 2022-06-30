Imports System.IO
Imports System.Web.UI

Module ModuleHtml
  Dim _doctype As String = "<!DOCTYPE html>"

  Public Sub RenderTitleTag(ht As HtmlTextWriter, title As String)
    ht.WriteFullBeginTag("title")
    ht.Write(title)
    ht.WriteEndTag("title")
  End Sub

  Public Sub RenderBeginTagWithAttributes(ht As HtmlTextWriter, tag As String, ByVal attrs As IEnumerable(Of KeyValuePair(Of String, String)))
    ht.WriteBeginTag(tag)
    For Each attr As KeyValuePair(Of String, String) In attrs
      ht.WriteAttribute(attr.Key, attr.Value)
    Next
    ht.Write(HtmlTextWriter.TagRightChar)
  End Sub

  Public Sub RenderHeadTag(ht As HtmlTextWriter, tag As String, ByVal attrs As IEnumerable(Of KeyValuePair(Of String, String)))
    RenderBeginTagWithAttributes(ht, tag, attrs)
    ht.WriteLine()
  End Sub

  Public Sub RenderScriptTag(ht As HtmlTextWriter, ByVal attrs As IEnumerable(Of KeyValuePair(Of String, String)))
    RenderBeginTagWithAttributes(ht, "script", attrs)
    ht.WriteEndTag("script")
  End Sub

  Function GetDivElements() As String
    Using sw As StringWriter = New StringWriter
      Using ht As HtmlTextWriter = New HtmlTextWriter(sw, "  ")

        ht.WriteLine(_doctype)

        ht.AddAttribute("lang", "en")
        ht.RenderBeginTag(HtmlTextWriterTag.Html)

        ht.RenderBeginTag(HtmlTextWriterTag.Head)

        RenderHeadTag(ht, "meta", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("charset", "utf-8")
        })

        RenderHeadTag(ht, "meta", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("name", "viewport"),
          New KeyValuePair(Of String, String)("content", "width=device-width, initial-scale=1")
        })

        RenderHeadTag(ht, "meta", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("name", "description"),
          New KeyValuePair(Of String, String)("content", "")
        })

        RenderHeadTag(ht, "meta", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("name", "author"),
          New KeyValuePair(Of String, String)("content", "Biao Huang")
        })

        'RenderHeadTag(ht, "meta", New List(Of KeyValuePair(Of String, String)) From
        '{
        '  New KeyValuePair(Of String, String)("http-equiv", "Content-Type"),
        '  New KeyValuePair(Of String, String)("content", "text/html; charset=UTF-8")
        '})

        'RenderHeadTag(ht, "meta", New List(Of KeyValuePair(Of String, String)) From
        '{
        '  New KeyValuePair(Of String, String)("http-equiv", "X-UA-Compatible"),
        '  New KeyValuePair(Of String, String)("content", "IE=edge")
        '})

        RenderHeadTag(ht, "link", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("href", "https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"),
          New KeyValuePair(Of String, String)("rel", "stylesheet"),
          New KeyValuePair(Of String, String)("integrity", "sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3"),
          New KeyValuePair(Of String, String)("crossorigin", "crossorigin")
        })

        RenderTitleTag(ht, "Test")
        ' head
        ht.RenderEndTag()
        ht.WriteLine()

        ht.RenderBeginTag(HtmlTextWriterTag.Body)

        RenderBeginTagWithAttributes(ht, "div", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("class", "col-lg-8 mx-auto p-3 py-md-5")
        })
        ht.WriteLine()
        ht.Indent += 1

        RenderBeginTagWithAttributes(ht, "header", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("class", "d-flex align-items-center pb-3 mb-5 border-bottom")
        })
        ht.WriteLine()
        ht.Indent += 1

        RenderBeginTagWithAttributes(ht, "span", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("class", "fs-4")
        })
        ht.Write("Starter template")
        ht.WriteEndTag("span")
        ht.WriteLine()

        ht.Indent -= 1
        ht.WriteEndTag("header")
        ht.WriteLine()

        ht.WriteFullBeginTag("main")
        ht.WriteLine()
        ht.Indent += 1

        ht.WriteFullBeginTag("h1")
        ht.Write("Gebruikerslijst")
        ht.WriteEndTag("h1")
        ht.WriteLine()

        RenderBeginTagWithAttributes(ht, "div", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("class", "user-list container")
        })
        ht.WriteEndTag("div")
        ht.WriteLine()

        ht.Indent -= 1
        ht.WriteEndTag("main")
        ht.WriteLine()

        RenderBeginTagWithAttributes(ht, "footer", New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("class", "pt-5 my-5 text-muted border-top")
        })
        ht.WriteLine()
        ht.Indent += 1
        ht.WriteLine("Created by the Bootstrap team &middot; &copy; 2021")
        ht.Indent -= 1
        ht.WriteEndTag("footer")
        ht.WriteLine()

        ht.Indent -= 1
        ht.WriteEndTag("div")
        ht.WriteLine()

        RenderScriptTag(ht, New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("src", "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js")
        })
        ht.WriteLine()

        RenderScriptTag(ht, New List(Of KeyValuePair(Of String, String)) From
        {
          New KeyValuePair(Of String, String)("src", "https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"),
          New KeyValuePair(Of String, String)("integrity", "sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p"),
          New KeyValuePair(Of String, String)("crossorigin", "crossorigin")
        })
        ht.WriteLine()

        ht.WriteFullBeginTag("script")
        ht.WriteLine()

        ht.Indent += 1
        Dim json As String = File.ReadAllText("SimpleUsers.json")
        ht.WriteLine("json=`" & json & "`;")

        Dim jsCode As String = "o=JSON.parse(json);
      console.log(o);
      $("".user-list.container"").append(`<div class=""row""></div>`);
      $("".user-list.container>.row"").append(`<div class=""col fw-bold"">Naam</div>`);
      $("".user-list.container>.row"").append(`<div class=""col fw-bold"">Adres</div>`);
      $("".user-list.container>.row"").append(`<div class=""col fw-bold"">Postcode</div>`);
      $("".user-list.container>.row"").append(`<div class=""col fw-bold"">Woonplaats</div>`);
      $("".user-list.container>.row"").append(`<div class=""col fw-bold"">Telefoonnummer</div>`);
      for (let step = 0; step < o.length; step++) {
        $("".user-list.container>.row"").append(`<div class=""w-100""></div>`);
        $("".user-list.container>.row"").append(`<div class=""col"">${o[step][""Name""]}</div>`);
        $("".user-list.container>.row"").append(`<div class=""col"">${o[step][""Address""]}</div>`);
        $("".user-list.container>.row"").append(`<div class=""col"">${o[step][""PostalCode""]}</div>`);
        $("".user-list.container>.row"").append(`<div class=""col"">${o[step][""City""]}</div>`);
        $("".user-list.container>.row"").append(`<div class=""col"">${o[step][""Phone""]}</div>`);
      }"
        ht.WriteLine(jsCode)
        ht.Indent -= 1

        ht.WriteEndTag("script")

        ' body
        ht.RenderEndTag()
        ' html
        ht.RenderEndTag()
      End Using
      Return sw.ToString()
    End Using
  End Function

  Sub Main()
    Console.WriteLine(GetDivElements())
  End Sub

End Module
