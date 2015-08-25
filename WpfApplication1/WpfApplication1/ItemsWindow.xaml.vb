Public Class ItemsWindow

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Dim Shield As Integer
        Dim HpBoost As Integer
        Dim Leather As Integer

        Shield = 0
        HpBoost = 0
        Leather = 0

        If Shield > 0 Then
            List2.Visibility = Windows.Visibility.Visible

        End If

        If HpBoost > 0 Then
            List1.Visibility = Windows.Visibility.Visible

        End If

        If Leather > 0 Then
            List3.Visibility = Windows.Visibility.Visible

        End If


    End Sub
   

    Private Sub CloseBtnn_Click(sender As Object, e As RoutedEventArgs) Handles CloseBtnn.Click
        Me.Close()
    End Sub

    Private Sub ListBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

    End Sub
End Class
