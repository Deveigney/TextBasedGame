Public Class GameWindow

    


    Dim rnd As New Random
    Dim timer As Timers.Timer



    Public Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        User.Name = NameLabel.Text
        User.HP = 100
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
        Overlord.IDP = "Your Freedom"
        Overlord.DMG = rnd.Next(259, 677)


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

        MessageBox.Show("Leveling up" & vbNewLine & "Health: +" & 10 / User.Lvl & vbNewLine & "Damage: +5" & vbNewLine & "Defense: +5")

        User.Lvl += 1
        User.Lvl += 10 / User.Lvl
        User.DMG += 5
        User.DEF += 5

        User.Exp = 0
        User.TotalExp += 125 / User.Lvl

        NextBtn3_Click(Nothing, Nothing)

        Frm.ShowDialog()
    End Sub

    Private Sub CharacterBtn_Click(sender As Object, e As RoutedEventArgs) Handles CharacterBtn.Click
        Dim Frm As New ItemsWindow


        Frm.ItemList.Items.Add("Sword(" & PickupItems.Sword & ")")
        Frm.ItemList.Items.Add("Shield(" & PickupItems.Shield & ")")
        Frm.ItemList.Items.Add("Boots(" & PickupItems.Boots & ")")
        Frm.ItemList.Items.Add("Leather(" & PickupItems.Leather & ")")

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
        SleepBtn.Visibility = Windows.Visibility.Visible
        Btn.Visibility = Windows.Visibility.Hidden

        If User.Exp >= User.TotalExp Then
            Dim frm As New LevelUp

            frm.Show()

            LvlBtn.Visibility = Windows.Visibility.Visible
        End If

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
            User.HP = User.MaxHP
            fileReader = My.Computer.FileSystem.ReadAllText("Resources\0.1 - Sleep.txt")
            TextScreen.Text = fileReader
        Else
            fileReader = My.Computer.FileSystem.ReadAllText("Resources\0.2 - CantSleep.txt")
            TextScreen.Text = fileReader
        End If

        

        timer = New Timers.Timer(2000)
        AddHandler timer.Elapsed, AddressOf SleepOver
        timer.Start()

    End Sub

    Private Sub FightBtn_Click(sender As Object, e As RoutedEventArgs) Handles FightBtn.Click

        FightBtn.Visibility = Windows.Visibility.Hidden
        OrkBtn.Visibility = Windows.Visibility.Visible

    End Sub

    Sub DefeatedOrk()
        Dim rand As New Random
        Dim result As Integer
        Dim XPresult As New Integer

        result = rand.Next(1, 5)
        XPresult = rand.Next(1, 50)
        

        If PickupItems.Leather <= 0 Then
            PickupItems.Leather = 0
            MessageBox.Show("EXP: +" & XPresult & vbNewLine & "ITEMS LOST" & vbNewLine & "-Leather(0)")
            Ork.HP = Ork.MaxHP
        Else
            MessageBox.Show("EXP: +" & XPresult & vbNewLine & "ITEMS LOST" & vbNewLine & "-Leather(" & result & ")")
            Ork.HP = Ork.MaxHP
            PickupItems.Leather -= result
        End If

        NextBtn3_Click(Nothing, Nothing)
    End Sub

    Sub VictoryOrk()
        Dim rand As New Random
        Dim result As Integer
        Dim XPresult As New Integer

        result = rand.Next(1, 5)
        XPresult = rand.Next(1, 50)

        MessageBox.Show("EXP: +" & XPresult & vbNewLine & vbNewLine & "ITEMS GAINED" & vbNewLine & "+Leather(" & result & ")")
        Ork.HP = Ork.MaxHP
        PickupItems.Leather += result
        NextBtn3_Click(Nothing, Nothing)
 
    End Sub
    Private Sub AttackBtn_Click(sender As Object, e As RoutedEventArgs) Handles AttackBtn.Click

        Dim rand As New Random

        Ork.HP -= rand.Next(0, User.DMG + 1)
        User.HP -= rand.Next(0, Ork.DMG + 1)

        OrkBtn_Click(Nothing, Nothing)

        If Ork.HP <= 0 Then
            MessageBox.Show("You Win!")
            VictoryOrk()
        ElseIf User.HP <= 0 Then
            MessageBox.Show("You've been defeated")
            DefeatedOrk()
        End If

    End Sub

End Class
