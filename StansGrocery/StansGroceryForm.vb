'Elliot Heiner
'RCET 0265
'Fall 2021
'Stan's Grocery
'https://github.com/heinelli/StansGrocery.git

Option Strict On
Option Explicit On
Public Class StansGroceryForm
    Dim food(255, 3) As String

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim record As String
        Dim formattedRecord() As String
        Dim result As String
        FileOpen(1, "grocery.txt", OpenMode.Input)
        For i = 0 To 255
            record = LineInput(1)
            formattedRecord = Split(record, ",")
            food(i, 0) = Mid(formattedRecord(0).Replace("""", ""), 6)
            food(i, 1) = Mid(formattedRecord(1).Replace("""", ""), 6)
            food(i, 2) = Mid(formattedRecord(2).Replace("""", ""), 6)
            Randomize()
            food(i, 3) = CStr(Int((10 * Rnd()) + 1))
            DisplayListBox.Items.Add(food(i, 0))


        Next


    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        DisplayLabel.Text = food(2, 2)
    End Sub

    Private Sub FilterByCategoryRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles FilterByCategoryRadioButton.CheckedChanged
        DisplayListBox.Items.Clear()
        For i = LBound(food) To UBound(food)
            DisplayListBox.Items.Add(food(i, 2))
        Next
    End Sub

    Private Sub DisplayListBox_Click(sender As Object, e As EventArgs) Handles DisplayListBox.Click
        Dim index As Integer = DisplayListBox.SelectedIndex
        Dim item As String = food(index, 0)
        Dim aisle As String = food(index, 1)
        Dim section As String = food(index, 2)
        Dim quantity As String = food(index, 3)
        DisplayLabel.Text = $"You will find {item} in aisle {aisle} in the {section} section. {quantity} left in stock."


    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
