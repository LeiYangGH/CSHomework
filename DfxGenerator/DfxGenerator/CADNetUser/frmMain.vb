Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry

Imports Microsoft.Win32
Imports System.Reflection

'Imports Autodesk.AutoCAD.Runtime
'Imports Autodesk.AutoCAD.ApplicationServices
'Imports Autodesk.AutoCAD.DatabaseServices

Public Class frmMain

    Private Sub btnGen_Click(sender As Object, e As EventArgs) Handles btnGen.Click
        Try
            Me.AddLine()

        Catch ex As Exception
            Me.Text = ex.Message
        End Try
        Me.Text = "OK"

    End Sub

    <CommandMethod("AddLine")> _
    Public Sub AddLine()
        '' Get the current document and database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database

        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)

            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite)

            '' Create a line that starts at 5,5 and ends at 12,3
            Using acLine As Line = New Line(New Point3d(5, 5, 0), _
                                            New Point3d(12, 3, 0))

                '' Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(acLine)
                acTrans.AddNewlyCreatedDBObject(acLine, True)
            End Using

            '' Save the new object to the database
            acTrans.Commit()
        End Using
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RegisterMyApp()
    End Sub


    <CommandMethod("ConnectToAcad")> _
    Public Sub ConnectToAcad()
        Dim acAppComObj As AcadApplication
        Dim strProgId As String = "AutoCAD.Application.21"

        On Error Resume Next

        '' Get a running instance of AutoCAD
        acAppComObj = GetObject(, strProgId)

        '' An error occurs if no instance is running
        If Err.Number > 0 Then
            Err.Clear()

            '' Create a new instance of AutoCAD
            acAppComObj = CreateObject(strProgId)

            '' Check to see if an instance of AutoCAD was created
            If Err.Number > 0 Then
                Err.Clear()

                '' If an instance of AutoCAD is not created then message and exit
                MsgBox("Instance of 'AutoCAD.Application' could not be created.")

                Exit Sub
            End If
        End If

        '' Display the application and return the name and version
        acAppComObj.Visible = True
        MsgBox("Now running " & acAppComObj.Name & " version " & acAppComObj.Version)

        '' Get the active document
        Dim acDocComObj As AcadDocument
        acDocComObj = acAppComObj.ActiveDocument

        '' Optionally, load your assembly and start your command or if your assembly
        '' is demandloaded, simply start the command of your in-process assembly.
        acDocComObj.SendCommand("(command " & Chr(34) & "NETLOAD" & Chr(34) & " " & _
                                Chr(34) & "c:/myapps/mycommands.dll" & Chr(34) & ") ")

        acDocComObj.SendCommand("MyCommand ")
    End Sub

    <CommandMethod("RegisterMyApp")> _
    Public Sub RegisterMyApp()
        '' Get the AutoCAD Applications key
        Dim sProdKey As String = HostApplicationServices.Current.RegistryProductRootKey
        Dim sAppName As String = "MyApp"

        Dim regAcadProdKey As RegistryKey = Registry.CurrentUser.OpenSubKey(sProdKey)
        Dim regAcadAppKey As RegistryKey = regAcadProdKey.OpenSubKey("Applications", True)

        '' Check to see if the "MyApp" key exists
        Dim subKeys() As String = regAcadAppKey.GetSubKeyNames()
        For Each sSubKey As String In subKeys
            '' If the application is already registered, exit
            If (sSubKey.Equals(sAppName)) Then
                regAcadAppKey.Close()

                Exit Sub
            End If
        Next

        '' Get the location of this module
        Dim sAssemblyPath As String = Assembly.GetExecutingAssembly().Location

        '' Register the application
        Dim regAppAddInKey As RegistryKey = regAcadAppKey.CreateSubKey(sAppName)
        regAppAddInKey.SetValue("DESCRIPTION", sAppName, RegistryValueKind.String)
        regAppAddInKey.SetValue("LOADCTRLS", 14, RegistryValueKind.DWord)
        regAppAddInKey.SetValue("LOADER", sAssemblyPath, RegistryValueKind.String)
        regAppAddInKey.SetValue("MANAGED", 1, RegistryValueKind.DWord)

        regAcadAppKey.Close()
    End Sub

    <CommandMethod("UnregisterMyApp")> _
    Public Sub UnregisterMyApp()
        '' Get the AutoCAD Applications key
        Dim sProdKey As String = HostApplicationServices.Current.RegistryProductRootKey
        Dim sAppName As String = "MyApp"

        Dim regAcadProdKey As RegistryKey = Registry.CurrentUser.OpenSubKey(sProdKey)
        Dim regAcadAppKey As RegistryKey = regAcadProdKey.OpenSubKey("Applications", True)

        '' Delete the key for the application
        regAcadAppKey.DeleteSubKeyTree(sAppName)
        regAcadAppKey.Close()
    End Sub
End Class
