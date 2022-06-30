Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module ModuleUsers
  Sub CreateUsers()
    Dim users = GetUsers()
    DisplayList(users)
    File.WriteAllText("SimpleUsers.json", JsonConvert.SerializeObject(users))
  End Sub

  Sub DisplayList(ByVal userCol As IEnumerable(Of User))
    For Each usr As User In userCol
      Console.WriteLine(" Name: " & usr.Name)
      Console.WriteLine(" Address: " & usr.Address)
      Console.WriteLine(" PostalCode: " & usr.PostalCode)
      Console.WriteLine(" City: " & usr.City)
      Console.WriteLine(" Phone: " & usr.Phone)
      Console.WriteLine()
    Next
  End Sub

  Function GetUsers() As IEnumerable(Of User)
    Dim json As String = File.ReadAllText("Users.json")
    Dim o As JObject = JObject.Parse(json)
    Dim users As New List(Of User)

    For Each token As JToken In o("users")
      users.Add(New User() With {
        .Name = token("firstName").ToString() + " " + token("lastName").ToString(),
        .Address = token("address")("address").ToString(),
        .PostalCode = token("address")("postalCode").ToString(),
        .City = token("address")("city").ToString(),
        .Phone = token("phone").ToString()
      })
    Next

    Return users
  End Function

  ' Each user has naam, adres, postcode, woonplaats and telefoonnummer.
  Public Class User
    Public Property Name As String
    Public Property Address As String
    Public Property PostalCode As String
    Public Property City As String
    Public Property Phone As String

    Public Sub New()

    End Sub
  End Class
End Module
