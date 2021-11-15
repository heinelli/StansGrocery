'Elliot Heiner
'RCET 0265
'Fall 2021
'Stan's Grocery
'

Option Strict On
Option Explicit On
Public Class StansGroceryForm
    Dim groceries As String
    Dim temp(255, 2) As String

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim record As String
        Dim formattedRecord() As String
        Dim result As String
        FileOpen(1, "grocery.txt", OpenMode.Input)
        For i = 0 To 255
            record = LineInput(1)
            formattedRecord = Split(record, ",")
            temp(i, 0) = formattedRecord(0).Replace("""", "")
            temp(i, 1) = formattedRecord(1).Replace("""", "")
            temp(i, 2) = formattedRecord(2).Replace("""", "")
            DisplayListBox.Items.Add(Mid(temp(i, 2), 6))


        Next






        DisplayLabel.Text = formattedRecord(2)



    End Sub
End Class
