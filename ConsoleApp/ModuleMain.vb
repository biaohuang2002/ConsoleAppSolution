Imports System.IO

Module ModuleMain

  Sub Main()
    CreateUsers()
    Console.ReadKey()

    Dim htmlString As String = GetDivElements()
    Console.WriteLine(htmlString)

    Dim arguments As String() = Environment.GetCommandLineArgs()

    If arguments.Length = 1 Then
      Console.WriteLine($"Run with an argument to create a file.")
    Else
      Console.WriteLine($"File {arguments(1)} is created.")
      File.WriteAllText(arguments(1), htmlString)
    End If

    Console.ReadKey()
  End Sub

End Module
