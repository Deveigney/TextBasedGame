Module Module1

    Public CharLevel As Integer = 0
    Public CharMana As Integer = 0
    Public Char As Integer = 0

    Public Function ReplaceText(source As String)

        source = source.Replace("#charlevel#", CharLevel)
        source = source.Replace("#CharMana#", CharMana)
        source = source.Replace("#CharHealth#", CharMana)

        Return source

    End Function

End Module
