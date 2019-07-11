﻿Option Strict On

''' <summary>
''' Author Name:    Gabriel Nathan Legawa
''' Project Name:   CarInventory
''' Date:           7/10/2019
''' Description     Application to keep a list of cars.
''' </summary>

Public Class frmCarInventory

    Private carList As New SortedList                                        ' collection of all the carList in the list
    Private currentCarIdentificationNumber As String = String.Empty          ' current selected car identification number
    Private editMode As Boolean = False                                      '

    ''' <summary>
    ''' btnEnter_Click - Will validate that the data entered into the controls is appropriate.
    '''                - Once the data is validated a car object will be create using the  
    '''                - parameterized constructor. It will also insert the new car object
    '''                - into the carList collection. It will also check to see if the data in
    '''                - the controls has been selected from the listview by the user. In that case
    '''                - it will need to update the data in the specific car object and the 
    '''                - listview as well.
    ''' </summary>
    ''' <param name="sender">Object</param>
    ''' <param name="e">EventArgs</param>
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        Dim customerCar As car                 ' declare a Customer class
        Dim carItem As ListViewItem            ' declare a ListViewItem class

        ' validate the data in the form
        If IsValidInput() = True Then

            ' set the edit flag to true
            editMode = True

            lblresult.Text = "It Worked!"

            ' if the current car identification number has a no value
            ' then this is not an existing item from the listview
            If currentCarIdentificationNumber.Trim.Length = 0 Then

                ' create a new car object using the parameterized constructor
                customerCar = New car(cmbMake.Text, tbModel.Text, cmbYear.Text, tbPrice.Text, chkNew.Checked)

                ' add the car to the carList collection
                ' using the identification number as the key
                ' which will make the car object easier to
                ' find in the carList collection later
                carList.Add(customerCar.IdentificationNumber.ToString(), customerCar)

            Else
                ' if the current car identification number has a value
                ' then the user has selected something from the list view
                ' so the data in the car object in the carList collection
                ' must be updated

                ' so get the car from the carList collection
                ' using the selected key
                customerCar = CType(carList.Item(currentCarIdentificationNumber), car)

                ' update the data in the specific object
                ' from the controls
                customerCar.Maker = cmbMake.Text
                customerCar.Model = tbModel.Text
                customerCar.Price = CInt(tbPrice.Text)
                customerCar.NewStatus = chkNew.Checked
            End If

            ' clear the items from the listview control
            lvwCar.Items.Clear()

            ' loop through the carList collection
            ' and populate the list view
            For Each customerEntry As DictionaryEntry In carList

                ' instantiate a new ListViewItem
                carItem = New ListViewItem()

                ' get the car from the list
                customerCar = CType(customerEntry.Value, car)

                ' assign the values to the ckecked control
                ' and the subitems
                carItem.Checked = customerCar.NewStatus
                carItem.SubItems.Add(customerCar.IdentificationNumber.ToString())
                carItem.SubItems.Add(customerCar.Maker)
                carItem.SubItems.Add(customerCar.Model)
                carItem.SubItems.Add(customerCar.Year)
                carItem.SubItems.Add((customerCar.Price).ToString("C2"))

                ' add the new instantiated and populated ListViewItem
                ' to the listview control
                lvwCar.Items.Add(carItem)

            Next customerEntry

            ' clear the controls
            Reset()

            lblresult.Text = "It Worked!"

            ' set the edit flag to false
            editMode = False

        End If

    End Sub

    ''' <summary>
    ''' Reset - set the controls back to their default state.
    ''' </summary>
    Private Sub Reset()

        tbModel.Text = String.Empty
        tbPrice.Text = String.Empty
        chkNew.Checked = False
        cmbMake.SelectedIndex = -1
        lblresult.Text = String.Empty
        cmbYear.SelectedIndex = -1

        currentCarIdentificationNumber = String.Empty

    End Sub

    ''' <summary>
    ''' IsValidInput - validates the data in each control to ensure that the user has entered appopriate values
    ''' </summary>
    ''' <returns>Boolean</returns>
    Private Function IsValidInput() As Boolean

        Dim returnValue As Boolean = True
        Dim outputMessage As String = String.Empty

        ' check if the car maker has been selected
        If cmbMake.SelectedIndex = -1 Then

            ' If not set the error message
            outputMessage += "Please select the car's maker." & vbCrLf

            ' And, set the return value to false
            returnValue = False

        End If

        ' check if the car model has been entered
        If tbModel.Text.Trim.Length = 0 Then

            ' If not set the error message
            outputMessage += "Please enter the car's model." & vbCrLf

            ' And, set the return value to false
            returnValue = False

        End If

        ' check if the car manufactured year has been selected
        If cmbYear.Text.Trim.Length = 0 Then

            ' If not set the error message
            outputMessage += "Please enter the car's manufactured year." & vbCrLf

            ' And, set the return value to false
            returnValue = False

        End If

        ' check if the car price has been entered
        If tbPrice.Text.Trim.Length = 0 Then

            ' If not set the error message
            outputMessage += "Please enter the car's price." & vbCrLf

            ' And, set the return value to false
            returnValue = False

            ' check if the car price is Not numeric
        ElseIf IsNumeric(tbPrice.Text) = False Then

            ' If not set the error message
            outputMessage += "Please enter the car's price as a numeric." & vbCrLf

            ' And, set the return value to false
            returnValue = False
            ' check if the care price is above 0
        ElseIf CInt(tbPrice.Text) < 0 Then

            ' If not set the error message
            outputMessage += "The car's price cannot be less than zero(0)" & vbCrLf

            ' And, set the return value to false
            returnValue = False

        End If

        ' check to see if any value
        ' did not validate
        If returnValue = False Then

            ' show the message(s) to the user
            lblresult.Text = "ERROR(S)" & vbCrLf & outputMessage

        End If

        ' return the boolean value
        ' true if it passed validation
        ' false if it did not pass validation
        Return returnValue

    End Function

    ''' <summary>
    ''' Event is declared as private because it is only accessible within the form
    ''' The code in the btnReset_Click EventHandler will clear the form and set
    ''' focus back to the input text box. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        ' call the rest sub routine
        Reset()

    End Sub
    ''' <summary>
    ''' Event is declared as private because it is only accessible within the form
    ''' The code in the btnExit_Click EventHandler will close the application
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' This will close the form
        Me.Close()

    End Sub

    ''' <summary>
    ''' lvwCars_ItemCheck - used to prevent the user from checking the check box in the list view
    '''                   - if it is not in edit mode
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lvwCars_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lvwCar.ItemCheck

        ' if it is not in edit mode
        If editMode = False Then

            ' the new value to the current value
            ' so it cannot be set in the listview by the user
            e.NewValue = e.CurrentValue

        End If

    End Sub

    ''' <summary>
    ''' lvwCars_SelectedIndexChanged - when the user selected a row in the list it will populate the fields for editing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lvwCars_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwCar.SelectedIndexChanged

        ' constant that represents the index of the subitem in the list that
        ' holds the car identification number 
        Const identificationSubItemIndex As Integer = 1

        ' Get the car identification number 
        currentCarIdentificationNumber = lvwCar.Items(lvwCar.FocusedItem.Index).SubItems(identificationSubItemIndex).Text

        ' Use the car identification number to get the car from the collection object
        Dim customerCar As car = CType(carList.Item(currentCarIdentificationNumber), car)

        ' set the controls on the form
        tbModel.Text = customerCar.Model               ' get the first name and set the text box
        tbPrice.Text = (customerCar.Price).ToString                 ' get the last name and set the text box
        cmbMake.Text = customerCar.Maker                     ' get the title and set the combo box
        chkNew.Checked = customerCar.NewStatus ' get the very important person status and set the combo box
        cmbYear.Text = customerCar.Year

        lblresult.Text = "It Worked!"


    End Sub

End Class

