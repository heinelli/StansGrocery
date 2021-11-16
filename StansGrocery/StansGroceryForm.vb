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
            If food(i, 1) = "" Then
                food(i, 1) = "8"
            ElseIf food(i, 1) = "0" Then
                food(i, 1) = "1"
            End If

            food(i, 2) = Mid(formattedRecord(2).Replace("""", ""), 6)
            If food(i, 2) = "" Then
                food(i, 2) = "Various groceries"
            End If
            DisplayListBox.Items.Add(food(i, 0))
        Next

        food(0,3) = "Baby stuff"
        food(1, 3) = "Baked goods"
        food(2, 3) = "Baking"
        food(3, 3) = "Beverages"
        food(4, 3) = "Canned foods"
        food(5, 3) = "Cheese"
        food(6, 3) = "Cleaning products"
        food(7, 3) = "Condiments / Sauces"
        food(8, 3) = "Dairy"
        food(9, 3) = "Fresh Fruit"
        food(10, 3) = "Fresh Vegetables"
        food(11, 3) = "Frozen"
        food(12, 3) = "Kitchen"
        food(13, 3) = "Meat"
        food(14, 3) = "Office supplies"
        food(15, 3) = "Other stuff"
        food(16, 3) = "Personal care"
        food(17, 3) = "Pets"
        food(18, 3) = "Pharmacy"
        food(19, 3) = "Seafood"
        food(20, 3) = "Snacks"
        food(21, 3) = "Spices and herbs"
        food(22, 3) = "Themed meals"
        food(23, 3) = "Various groceries"
        food(24, 3) = "Unknown"




        ShowAllRadioButton.Checked = true

    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click,
                                                                             SearchToolStripMenuItem.Click
        DisplayLabel.Text = food(2, 2)
    End Sub

    Private Sub FilterByCategoryRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles FilterByCategoryRadioButton.CheckedChanged
        FilterComboBox.Items.Clear()
        For i = 0 To 24
            FilterComboBox.Items.Add(food(i, 3))
        Next

    End Sub

    Private Sub DisplayListBox_Click(sender As Object, e As EventArgs) Handles DisplayListBox.Click
        Dim index As Integer = DisplayListBox.SelectedIndex
        Dim item As String = food(index, 0)
        Dim aisle As String = food(index, 1)
        Dim section As String = food(index, 2)
        DisplayLabel.Text = $"You will find {item} in aisle {aisle} in the {section} section."


    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ShowAllRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ShowAllRadioButton.CheckedChanged
        FilterComboBox.Items.Clear()
        For i = 0 To 255
            FilterComboBox.Items.Add(food(i, 0))
        Next

    End Sub
End Class
