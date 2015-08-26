Public Class GameWindow

    Class Protaganist
        Public Name As String
        Public HP As Integer
        Public MaxHP As Integer
        Public DMG As Integer
        Public DEF As Integer


    End Class
    Public Class Enemy
        Public Name As String
        Public HP As Integer
        Public MaxHP As Integer
        Public IDP As String
        Public DMG As Integer


    End Class

    Public Class Items
        Public HPBoost As Integer
        Public Shield As String
        Public Boots As String
        Public Leather As String
    End Class

    Dim User As New Protaganist
    Dim Ork As New Enemy
    Dim Basilisk As New Enemy
    Dim Orthros As New Enemy
    Dim Fenrir As New Enemy
    Dim Overlord As New Enemy
    Dim PickupItems As New Items


    Dim rnd As New Random



    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Dim DMG As New Integer
        Dim DEF As New Integer

        If DMG = " " Then
            DMG = 35
        End If
        If DEF = " " Then
            DEF = 20
        End If

        User.Name = NameLabel.Text
        User.HP = 100
        User.MaxHP = 100
        User.DMG = DMG
        User.DEF = DEF

        Ork.Name = "Ork"
        Ork.HP = 96
        Ork.MaxHP = 96
        Ork.IDP = "Leather"
        Ork.DMG = rnd.Next(0, 36)

        Basilisk.Name = "Basilisk"
        Basilisk.HP = 360
        Basilisk.MaxHP = 360
        Basilisk.IDP = "Shield"
        Basilisk.DMG = rnd.Next(12, 66)

        Orthros.Name = "Orthros"
        Orthros.HP = 580
        Orthros.MaxHP = 580
        Orthros.IDP = "Boots"
        Orthros.DMG = rnd.Next(33, 89)

        Fenrir.Name = "Fenrir"
        Fenrir.HP = 870
        Fenrir.MaxHP = 870
        Fenrir.IDP = "HP Boost"
        Fenrir.DMG = rnd.Next(42, 236)

        Overlord.Name = "Overlord"
        Overlord.HP = 2340
        Overlord.MaxHP = 2340
        Overlord.IDP = "Overlords Helmet"
        Overlord.DMG = rnd.Next(259, 677)

        'Items
        PickupItems.HPBoost = 300
        PickupItems.Shield = 400
        PickupItems.Boots = 200
        PickupItems.Leather = 300

        '(x= requirment, L = item required count, PD = increased stat)
        ' x = 15 
        ' if L > x then
        ' PP += 1
        ' L -= x
        ' x +=5


        Dim fileReader As String

        fileReader = My.Computer.FileSystem.ReadAllText("Resources\1.1 - WelcomeScreen")
        TextScreen.Text = fileReader

        fileReader = My.Computer.FileSystem.ReadAllText("Resources\5.1 - LevelUp.txt")
        LevelLabel3.Content = ReplaceText(fileReader)

        fileReader = My.Computer.FileSystem.ReadAllText("Resources\5.2 - HP.txt")
        Label2.Content = ReplaceText(fileReader)

        fileReader = My.Computer.FileSystem.ReadAllText("Resources\5.3 - Mana.txt")
        Label3.Content = ReplaceText(fileReader)

        fileReader = My.Computer.FileSystem.ReadAllText("Resources\5.4 - XP.txt")
        LevelLabel4.Content = ReplaceText(fileReader)







    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        Close()

    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim Frm As New OptionsWindow

        Frm.ShowDialog()

    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        Dim Frm As New LevelUp

        Frm.ShowDialog()
    End Sub

    Private Sub CharacterBtn_Click(sender As Object, e As RoutedEventArgs) Handles CharacterBtn.Click
        Dim Frm As New CharItemWindow

        Frm.ShowDialog()
    End Sub

    Private Sub StartBtn_Click(sender As Object, e As RoutedEventArgs) Handles StartBtn.Click
        Dim fileReader As String

        LoreBtn.Visibility = Windows.Visibility.Hidden
        HiddenBtn.Visibility = Windows.Visibility.Visible
        StartBtn.Visibility = Windows.Visibility.Hidden
        NextBtn.Visibility = Windows.Visibility.Visible



        fileReader = My.Computer.FileSystem.ReadAllText("Resources\2.1 - Intro.txt")
        TextScreen.Text = fileReader
    End Sub

    Private Sub LoreBtn_Click(sender As Object, e As RoutedEventArgs) Handles LoreBtn.Click
        Dim fileReader As String

        LoreBtn.Visibility = Windows.Visibility.Hidden
        HiddenBtn.Visibility = Windows.Visibility.Visible
        StartBtn.Visibility = Windows.Visibility.Hidden
        NextBtn2.Visibility = Windows.Visibility.Visible



        fileReader = My.Computer.FileSystem.ReadAllText("Resources\1.2 - Lore.txt")
        TextScreen.Text = fileReader
    End Sub

    Private Sub OrkBtn_Click(sender As Object, e As RoutedEventArgs) Handles OrkBtn.Click
        Dim fileReader As String

        OrkBtn.Visibility = Windows.Visibility.Hidden
        AttackBtn.Visibility = Windows.Visibility.Visible

        FileReader = My.Computer.FileSystem.ReadAllText("Resources\7.1 - Combat.txt")
        fileReader = fileReader.Replace("#EnemyHP#", Ork.HP)
        fileReader = fileReader.Replace("#MaxHP#", Ork.MaxHP)
        fileReader = fileReader.Replace("#HP#", User.HP)
        fileReader = fileReader.Replace("#HPMax#", User.MaxHP)
        TextScreen.Text = fileReader
    End Sub

    Private Sub NextBtn_Click(sender As Object, e As RoutedEventArgs) Handles NextBtn.Click
        Dim fileReader As String

        NextBtn2.Visibility = Windows.Visibility.Visible
        NextBtn.Visibility = Windows.Visibility.Hidden


        fileReader = My.Computer.FileSystem.ReadAllText("Resources\2.2 - Travel.txt")
        TextScreen.Text = fileReader
    End Sub

    Private Sub NextBtn2_Click(sender As Object, e As RoutedEventArgs) Handles NextBtn2.Click
        Dim fileReader As String

        NextBtn3.Visibility = Windows.Visibility.Visible
        NextBtn2.Visibility = Windows.Visibility.Hidden
        NameLabel.Visibility = Windows.Visibility.Visible

        fileReader = My.Computer.FileSystem.ReadAllText("Resources\2.3 - Arrival.txt")
        TextScreen.Text = fileReader
    End Sub
    Private Sub NextBtn3_Click(sender As Object, e As RoutedEventArgs) Handles NextBtn3.Click
        Dim fileReader As String

        FightBtn.Visibility = Windows.Visibility.Visible
        NextBtn3.Visibility = Windows.Visibility.Hidden
        NextBtn2.Visibility = Windows.Visibility.Hidden
        NameLabel.Visibility = Windows.Visibility.Hidden


        fileReader = My.Computer.FileSystem.ReadAllText("Resources\7.0 - Arena.txt")
        TextScreen.Text = fileReader
    End Sub

    Private Sub FightBtn_Click(sender As Object, e As RoutedEventArgs) Handles FightBtn.Click

        FightBtn.Visibility = Windows.Visibility.Hidden
        OrkBtn.Visibility = Windows.Visibility.Visible

    End Sub

    Private Sub AttackBtn_Click(sender As Object, e As RoutedEventArgs) Handles AttackBtn.Click

        Dim rand As New Random


        Ork.HP -= rand.Next(0, User.DMG)

        User.HP -= rand.Next(0, Ork.DMG)

        If Ork.HP <= 0 Then
            'Give items and exp to user
            NextBtn3(Nothing, Nothing) 'activate sub 
        ElseIf User.HP <= 0 Then
            'Take away a few items(what the enemy drops)
            NextBtn3(Nothing, Nothing) 'activate sub 
        End If
    End Sub
End Class
