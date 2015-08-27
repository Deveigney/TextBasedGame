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
    Dim timer As Timers.Timer



    Public Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        User.Name = NameLabel.Text
        User.HP = 22
        User.MaxHP = 100
        User.DMG = 35
        User.DEF = 20


        Ork.Name = "Ork"
        Ork.HP = 96
        Ork.MaxHP = 96
        Ork.IDP = "Leather"
        Ork.DMG = rnd.Next(0, 36)

        'Basilisk.Name = "Basilisk"
        'Basilisk.HP = 360
        'Basilisk.MaxHP = 360
        'Basilisk.IDP = "Shield"
        'Basilisk.DMG = rnd.Next(12, 66)

        'Orthros.Name = "Orthros"
        'Orthros.HP = 580
        'Orthros.MaxHP = 580
        'Orthros.IDP = "Boots"
        'Orthros.DMG = rnd.Next(33, 89)

        'Fenrir.Name = "Fenrir"
        'Fenrir.HP = 870
        'Fenrir.MaxHP = 870
        'Fenrir.IDP = "HP Boost"
        'Fenrir.DMG = rnd.Next(42, 236)

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

        fileReader = My.Computer.FileSystem.ReadAllText("Resources\1.1 - WelcomeScreen.txt")
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
        Dim Frm As New ItemsWindow

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
        SleepBtn.Visibility = Windows.Visibility.Hidden

        fileReader = My.Computer.FileSystem.ReadAllText("Resources\7.1 - Combat.txt")
        fileReader = fileReader.Replace("#EnemyHP#", Ork.HP)
        fileReader = fileReader.Replace("#MaxHP#", Ork.MaxHP)
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
        SleepBtn.Visibility = Windows.Visibility.Visible
        Btn.Visibility = Windows.Visibility.Hidden

        fileReader = My.Computer.FileSystem.ReadAllText("Resources\7.0 - Arena.txt")
        TextScreen.Text = fileReader
    End Sub

    Sub SleepOver()

        If Dispatcher.CheckAccess = False Then
            Dispatcher.Invoke(AddressOf SleepOver)
        Else
            timer.Stop()

            Dim fileReader As String = My.Computer.FileSystem.ReadAllText("Resources\7.0 - Arena.txt")
            TextScreen.Text = fileReader
        End If


    End Sub

    Private Sub SleepBtn_Click(sender As Object, e As RoutedEventArgs) Handles SleepBtn.Click
        Dim fileReader As String

        If User.HP < User.MaxHP Then
            User.HP += 24
            fileReader = My.Computer.FileSystem.ReadAllText("Resources\0.1 - Sleep.txt")
            TextScreen.Text = fileReader
        Else
            fileReader = My.Computer.FileSystem.ReadAllText("Resources\0.2 - CantSleep.txt")
            TextScreen.Text = fileReader
        End If

        If User.HP > User.MaxHP Then
            User.HP = User.MaxHP
        End If


        

        timer = New Timers.Timer(2000)
        AddHandler timer.Elapsed, AddressOf SleepOver
        timer.Start()

    End Sub

    Private Sub FightBtn_Click(sender As Object, e As RoutedEventArgs) Handles FightBtn.Click

        FightBtn.Visibility = Windows.Visibility.Hidden
        OrkBtn.Visibility = Windows.Visibility.Visible

    End Sub

    Private Sub AttackBtn_Click(sender As Object, e As RoutedEventArgs) Handles AttackBtn.Click

        Dim rand As New Random

        Ork.HP -= rand.Next(0, User.DMG)

    End Sub
End Class
