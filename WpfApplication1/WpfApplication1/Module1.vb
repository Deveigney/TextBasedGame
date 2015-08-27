Module Module1

    Class Protaganist
        Public Name As String
        Public HP As Integer
        Public MaxHP As Integer
        Public DMG As Integer
        Public DEF As Integer
        Public Lvl As Integer
        Public Exp As Integer
        Public TotalExp As Integer
        Public TotalMana As Integer
        Public Mana As Integer



    End Class
    Public Class Enemy
        Public Name As String
        Public HP As Integer
        Public MaxHP As Integer
        Public IDP As String
        Public DMG As Integer


    End Class

    Public Class Items
        Public Sword As Integer = 0
        Public Shield As Integer = 0
        Public Boots As Integer = 0
        Public Leather As Integer = 0
    End Class

    Public User As New Protaganist
    Public Ork As New Enemy
    Public Overlord As New Enemy
    Public PickupItems As New Items


    Public Function ReplaceText(source As String)

        source = source.Replace("#charlevel#", User.Lvl)
        source = source.Replace("#CharMana#", User.Mana)
        source = source.Replace("#CharHealth#", User.HP)
        source = source.Replace("#CharTotalHealth#", User.MaxHP)
        source = source.Replace("#CharTotalExp#", User.TotalExp)
        source = source.Replace("#CharExp#", User.Exp)
        source = source.Replace("#CharTotalMana#", User.TotalMana)


        Return source

    End Function

End Module
