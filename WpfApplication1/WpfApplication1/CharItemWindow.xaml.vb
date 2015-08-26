Public Class CharItemWindow

    Private Sub ExitBtnn_Click(sender As Object, e As RoutedEventArgs) Handles ExitBtnn.Click
        Me.Close()
    End Sub

    Private Sub ItemsBtn_Click(sender As Object, e As RoutedEventArgs) Handles ItemsBtn.Click
        Dim Frm As New ItemsWindow

        Frm.ShowDialog()
    End Sub
End Class
