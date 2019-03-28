Public Class FormCTCCalculator
    Private Sub Btn_Calc_Click(sender As Object, e As EventArgs) Handles Btn_Calc.Click
        Try
            If txt_Current_FixedAnnual.Text = "" Then
                MessageBox.Show("Enter Current Fixed Annual")
                txt_Current_FixedAnnual.Focus()
                Exit Sub
            ElseIf txt_Current_PB.Text = "" Then
                MessageBox.Show("Enter Performance Bonus")
                txt_Current_PB.Focus()
                Exit Sub
            ElseIf txt_Current_TB.Text = "" Then
                MessageBox.Show("Enter Tenure Bonus")
                txt_Current_TB.Focus()
                Exit Sub
            ElseIf RadioButton_Increment.Checked = True And (increment.Text = "" OrElse increment.Text = 0) Then
                MessageBox.Show("Enter Increment Percentage")
                increment.Focus()
                Exit Sub
            ElseIf txt_Multiple.Text = "" Then
                MessageBox.Show("Enter Value for Multiple")
                txt_Multiple.Focus()
                Exit Sub
            ElseIf RadioButton_NewOfferFixedAnnual.Checked = True And (txt_radiobutton_newofferfixedannual.Text = "" OrElse txt_radiobutton_newofferfixedannual.Text = 0) Then
                MessageBox.Show("Enter Fixed Annual")
                txt_radiobutton_newofferfixedannual.Focus()
                Exit Sub
            Else

            End If


            Dim Current_FixedAnnual As Double = txt_Current_FixedAnnual.Text
            Dim Current_FixedMonthly As Double = txt_Current_FixedMonthly.Text
            Dim Current_PB As Double = txt_Current_PB.Text
            Dim Current_TB As Double = txt_Current_TB.Text
            Dim Current_TotalCTC As Double = txt_Current_TotalCTC.Text

            Dim offer_FixedAnnual As Double = txt_offer_FixedAnnual.Text
            Dim offer_FixedMonthly As Double = txt_offer_FixedMonthly.Text
            Dim offer_PB As Double = txt_offer_PB.Text
            Dim offer_TB As Double = txt_offer_TB.Text
            Dim offer_TotalCTC As Double = txt_offer_TotalCTC.Text
            Dim Multiple As Double = txt_Multiple.Text

            If RadioButton_Increment.Checked = True Then
                txt_Current_FixedMonthly.Text = FormatNumber(Current_FixedAnnual / 12, NumDigitsAfterDecimal:=0)
                Current_FixedMonthly = txt_Current_FixedMonthly.Text

                txt_Current_TotalCTC.Text = FormatNumber(Current_FixedAnnual + Current_PB + Current_TB, NumDigitsAfterDecimal:=0)
                Current_TotalCTC = txt_Current_TotalCTC.Text

                txt_offer_FixedAnnual.Text = FormatNumber(Current_FixedAnnual + ((Current_FixedAnnual * increment.Text) / 100), NumDigitsAfterDecimal:=0)
                offer_FixedAnnual = txt_offer_FixedAnnual.Text

                txt_offer_FixedMonthly.Text = FormatNumber(offer_FixedAnnual / 12, NumDigitsAfterDecimal:=0)
                offer_FixedMonthly = txt_offer_FixedMonthly.Text

                txt_offer_PB.Text = FormatNumber(offer_FixedMonthly * Multiple, NumDigitsAfterDecimal:=0)
                offer_PB = txt_offer_PB.Text

                txt_offer_TB.Text = Current_TB
                offer_TB = Current_TB


                txt_offer_TotalCTC.Text = FormatNumber((offer_FixedAnnual + offer_PB + offer_TB), NumDigitsAfterDecimal:=0)
                offer_TotalCTC = txt_offer_TotalCTC.Text

                txt_total_increment.Text = FormatNumber(((offer_TotalCTC - Current_TotalCTC) / Current_TotalCTC) * 100, NumDigitsAfterDecimal:=0)

            Else
                Dim radiobutton_newofferfixedannual As Double = txt_radiobutton_newofferfixedannual.Text
                txt_offer_FixedAnnual.Text = FormatNumber(radiobutton_newofferfixedannual, NumDigitsAfterDecimal:=0)

                txt_Current_FixedMonthly.Text = FormatNumber(radiobutton_newofferfixedannual / 12, NumDigitsAfterDecimal:=0)
                Current_FixedMonthly = txt_Current_FixedMonthly.Text

                txt_Current_TotalCTC.Text = FormatNumber(Current_FixedAnnual + Current_PB + Current_TB, NumDigitsAfterDecimal:=0)
                Current_TotalCTC = txt_Current_TotalCTC.Text

                'txt_offer_FixedAnnual.Text = Current_FixedAnnual + ((Current_FixedAnnual * increment.Value) / 100)
                'offer_FixedAnnual = txt_offer_FixedAnnual.Text

                txt_offer_FixedMonthly.Text = FormatNumber(radiobutton_newofferfixedannual / 12, NumDigitsAfterDecimal:=0)
                offer_FixedMonthly = txt_offer_FixedMonthly.Text

                txt_offer_PB.Text = FormatNumber(offer_FixedMonthly * Multiple, NumDigitsAfterDecimal:=0)
                offer_PB = txt_offer_PB.Text

                txt_offer_TB.Text = Current_TB
                offer_TB = Current_TB

                txt_Current_TB.Text = FormatNumber(txt_Current_TB.Text, NumDigitsAfterDecimal:=0)
                txt_offer_TB.Text = FormatNumber(txt_offer_TB.Text, NumDigitsAfterDecimal:=0)



                txt_offer_TotalCTC.Text = FormatNumber(radiobutton_newofferfixedannual + offer_PB + offer_TB, NumDigitsAfterDecimal:=0)
                offer_TotalCTC = txt_offer_TotalCTC.Text

                increment.Text = FormatNumber(((radiobutton_newofferfixedannual - Current_FixedAnnual) / Current_FixedAnnual) * 100, NumDigitsAfterDecimal:=0)

                txt_total_increment.Text = FormatNumber(((offer_TotalCTC - Current_TotalCTC) / Current_TotalCTC) * 100, NumDigitsAfterDecimal:=0)
            End If

            txt_Current_FixedAnnual.Text = FormatNumber(Current_FixedAnnual, NumDigitsAfterDecimal:=0)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RadioButton_NewOfferFixedAnnual_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_NewOfferFixedAnnual.CheckedChanged
        If RadioButton_NewOfferFixedAnnual.Checked = True Then
            txt_radiobutton_newofferfixedannual.Enabled = True
        Else
            txt_radiobutton_newofferfixedannual.Enabled = False
        End If
    End Sub

    Private Sub txt_Current_FixedAnnual_TextChanged(sender As Object, e As EventArgs) Handles txt_Current_FixedAnnual.TextChanged

    End Sub

    Private Sub txt_Current_FixedAnnual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Current_FixedAnnual.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Back) And (".0123456789").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And Trim(txt_Current_FixedAnnual.Text).ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txt_Current_PB_TextChanged(sender As Object, e As EventArgs) Handles txt_Current_PB.TextChanged

    End Sub

    Private Sub txt_Current_PB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Current_PB.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Back) And (".0123456789").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And Trim(txt_Current_PB.Text).ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_Current_TB_TextChanged(sender As Object, e As EventArgs) Handles txt_Current_TB.TextChanged

    End Sub

    Private Sub txt_Current_TB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Current_TB.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Back) And (".0123456789").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And Trim(txt_Current_TB.Text).ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub increment_TextChanged(sender As Object, e As EventArgs) Handles increment.TextChanged

    End Sub

    Private Sub increment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles increment.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Back) And (".0123456789").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And Trim(increment.Text).ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_radiobutton_newofferfixedannual_TextChanged(sender As Object, e As EventArgs) Handles txt_radiobutton_newofferfixedannual.TextChanged

    End Sub

    Private Sub txt_radiobutton_newofferfixedannual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_radiobutton_newofferfixedannual.KeyPress
        If (Not e.KeyChar = ChrW(Keys.Back) And (".0123456789").IndexOf(e.KeyChar) = -1) Or (e.KeyChar = "." And Trim(RadioButton_NewOfferFixedAnnual.Text).ToCharArray().Count(Function(c) c = ".") > 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.Diagnostics.Process.Start("calc")
    End Sub

    Private Sub FormCTCCalculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_Multiple.Text = 3
    End Sub

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click

        txt_Current_FixedAnnual.Text = ""
        txt_Current_FixedMonthly.Text = 0
        txt_Current_PB.Text = ""
        txt_Current_TB.Text = ""
        txt_Current_TotalCTC.Text = 0
        increment.Text = ""
        txt_Multiple.Text = 3
        txt_offer_FixedAnnual.Text = 0
        txt_offer_FixedMonthly.Text = 0
        txt_offer_PB.Text = 0
        txt_offer_TB.Text = 0
        txt_offer_TotalCTC.Text = 0
        txt_radiobutton_newofferfixedannual.Text = ""
        txt_total_increment.Text = ""

    End Sub
End Class