Module Module1

    Public CharLevel As Integer = 0
    Public CharMana As Integer = 100
    Public CharTotalMana As Integer = 100
    Public CharHealth As Integer = 100
    Public CharTotalHealth As Integer = 100
    Public CharTotalExp As Integer = 100
    Public CharExp As Integer = 0

    Public Function ReplaceText(source As String)

        source = source.Replace("#charlevel#", CharLevel)
        source = source.Replace("#CharMana#", CharMana)
        source = source.Replace("#CharHealth#", CharHealth)
        source = source.Replace("#CharTotalHealth#", CharTotalHealth)
        source = source.Replace("#CharTotalExp#", CharTotalExp)
        source = source.Replace("#CharExp#", CharExp)
        source = source.Replace("#CharTotalMana#", CharTotalMana)


        Return source

    End Function

End Module
