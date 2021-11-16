'Elliot Heiner
'RCET 0265
'Fall 2021
'Stan's Grocery
'https://github.com/heinelli/StansGrocery.git

Option Strict On
Option Explicit On
Option Compare Text
Public Class StansGroceryForm
    Dim food(255, 4) As String
    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim record As String
        Dim formattedRecord() As String
        FileOpen(1, "grocery.txt", OpenMode.Input)
        For i = 0 To 255
            'Read each line of text file and separate line data according to comma delimiter
            record = LineInput(1)
            formattedRecord = Split(record, ",")

            'If then statement used to skip over line 153 of text file which contains no grocery data
            'All lines of text file are inserted into global multi-dimensional array
            If Mid(formattedRecord(0).Replace("""", ""), 6) <> "" Then
                If i < 153 Then
                    food(i, 0) = Mid(formattedRecord(0).Replace("""", ""), 6)
                    DisplayListBox.Items.Add(food(i, 0))

                    'Assign an aisle number to items with missing aisle number assignment in orginal text file
                    food(i, 1) = Mid(formattedRecord(1).Replace("""", ""), 6)
                    If food(i, 1) = "" Then
                        food(i, 1) = "8"
                    ElseIf food(i, 1) = "0" Then
                        food(i, 1) = "1"
                    End If

                    'Assign a category to items with missing category assignment in orginal text file
                    food(i, 2) = Mid(formattedRecord(2).Replace("""", ""), 6)
                    If food(i, 2) = "" Then
                        food(i, 2) = "Various groceries"
                    End If

                ElseIf i > 153 Then
                    food(i - 1, 0) = Mid(formattedRecord(0).Replace("""", ""), 6)
                    food(i - 1, 1) = Mid(formattedRecord(1).Replace("""", ""), 6)
                    food(i - 1, 2) = Mid(formattedRecord(2).Replace("""", ""), 6)
                    DisplayListBox.Items.Add(food(i - 1, 0))
                End If
            End If
        Next

        'Assign categories to global array
        food(0, 3) = "Baby stuff"
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

        'Assign aisle numbers to global array
        For i = 1 To 17
            food(i, 4) = CStr(i)
        Next
        ShowAllRadioButton.Checked = True
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click,
                                                                             SearchToolStripMenuItem.Click
        Dim textSearch As String = SearchTextBox.Text
        Dim searchReturn As Integer
        DisplayListBox.Items.Clear()

        'Search the array for any text that matches searchbox text
        'End program if zzz is typed in search textbox
        For i = 0 To 254
            If textSearch <> "zzz" Then
                searchReturn = InStr(food(i, 0), textSearch)
                If searchReturn <> 0 Then
                    DisplayListBox.Items.Add(food(i, 0))
                End If
            Else
                Me.Close()
            End If
        Next
    End Sub

    Private Sub DisplayListBox_Click(sender As Object, e As EventArgs) Handles DisplayListBox.Click
        Dim selectedItem As String = CStr(DisplayListBox.SelectedItem)
        Dim iteration As Integer = 0
        Dim item As String
        Dim aisle As String
        Dim section As String

        Do Until food(iteration, 0) = selectedItem
            iteration += 1
        Loop
        item = food(iteration, 0)
        aisle = food(iteration, 1)
        section = food(iteration, 2)

        'Insert appropriate data into displaylabel according to selected item in listbox
        If item <> "" Then
            DisplayLabel.Text = $"You will find {item} in aisle {aisle} in the {section} section."
        Else
            DisplayLabel.Text = ""
        End If
    End Sub

    Private Sub ShowAllRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ShowAllRadioButton.CheckedChanged
        'Clear combobox and listbox. Repopulate combobox with all items from array
        FilterComboBox.Items.Clear()
        DisplayListBox.Items.Clear()
        DisplayLabel.Text = ""
        FilterComboBox.Text = ""
        SearchTextBox.Text = ""
        For i = 0 To 254
            FilterComboBox.Items.Add(food(i, 0))
            DisplayListBox.Items.Add(food(i, 0))
        Next
    End Sub

    Private Sub FilterByCategoryRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles FilterByCategoryRadioButton.CheckedChanged
        'Clear combobox and listbox. Repopulate combobox with categories from array
        DisplayListBox.Items.Clear()
        FilterComboBox.Items.Clear()
        DisplayLabel.Text = ""
        FilterComboBox.Text = ""
        SearchTextBox.Text = ""
        For i = 0 To 24
            FilterComboBox.Items.Add(food(i, 3))
        Next
    End Sub

    Private Sub FilterByAisleRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles FilterByAisleRadioButton.CheckedChanged
        'Clear combobox and listbox. Repopulate combobox with aisle numbers from array
        FilterComboBox.Items.Clear()
        DisplayListBox.Items.Clear()
        DisplayLabel.Text = ""
        FilterComboBox.Text = ""
        SearchTextBox.Text = ""
        For i = 1 To 17
            FilterComboBox.Items.Add(food(i, 4))
        Next
    End Sub

    Private Sub FilterComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterComboBox.SelectedIndexChanged
        Dim filterIndex As String = CStr(FilterComboBox.SelectedItem)
        Dim selectedFilter As Integer
        If FilterByAisleRadioButton.Checked = True Then
            selectedFilter = 1
        ElseIf FilterByCategoryRadioButton.Checked = True Then
            selectedFilter = 2
        End If

        'Clear listbox and repopulate listbox with all items that fall under chosen category or aisle number
        DisplayListBox.Items.Clear()
        For i = 0 To 254
            If food(i, selectedFilter) = filterIndex Then
                DisplayListBox.Items.Add(food(i, 0))
            End If
        Next
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
