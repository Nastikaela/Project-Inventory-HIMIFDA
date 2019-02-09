Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class tambahpinjam
    Dim cmd, cmd2 As MySqlCommand
    Dim rd As MySqlDataReader
    Sub clear()
        TextBox5.Text = ""
        TextBox4.Text = ""
        TextBox1.Text = ""
        ComboBox1.Text = ""
        DateTimePicker1.Value = Date.Now
        DateTimePicker2.Value = Date.Now

    End Sub
    Sub panggil()
        cmd = New MySqlCommand("select * FROM inventaris where jmlh_brg > 0", koneksi)
        rd = cmd.ExecuteReader
        Do While rd.Read
            ComboBox1.Items.Add(rd("nama_brg"))
        Loop
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim sisa As String
        sisa = Val(TextBox1.Text) - Val(TextBox4.Text)
        If TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("DATA BELUM LENGKAP")
            TextBox4.Focus()
        Else
            If Val(TextBox4.Text) > Val(TextBox1.Text) Then
                MsgBox("STOCK TIDAK TERSEDIA")
                TextBox4.Focus()
            ElseIf Val(TextBox4.Text) <= Val(TextBox1.Text) Then
                Dim Sqltambah2 As String = "INSERT INTO laporan(tgl_pinjam,tgl_blk,nama_brg, jml_brg, atas_nama)values ('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
                cmd2 = New MySqlCommand(Sqltambah2, koneksi)
                cmd2.ExecuteNonQuery()

                Dim Sqltambah As String = "INSERT INTO pinjaman(tgl_pinjam,tgl_kembali,nama_brg, jml_brg, nama_peminjam)values ('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
                cmd = New MySqlCommand(Sqltambah, koneksi)
                cmd.ExecuteNonQuery()

                Dim sqledit As String = "UPDATE inventaris SET " & _
                                        " jmlh_brg = ' " & sisa & "' WHERE nama_brg = '" & ComboBox1.Text & "'"
                cmd = New MySqlCommand(sqledit, koneksi)
                cmd.ExecuteNonQuery()

                If sisa = 0 Then
                    Dim ket As String
                    ket = "TIDAK TERSEDIA"
                    Dim sqltersedia As String = "UPDATE inventaris SET Tersedia = ' " & ket & "' WHERE nama_brg = '" & ComboBox1.Text & "'"
                    cmd = New MySqlCommand(sqltersedia, koneksi)
                    cmd.ExecuteNonQuery()
                Else
                    Dim ket As String
                    ket = "TERSEDIA"
                    Dim sqltersedia As String = "UPDATE inventaris SET Tersedia = ' " & ket & "' WHERE nama_brg = '" & ComboBox1.Text & "'"
                    cmd = New MySqlCommand(sqltersedia, koneksi)
                    cmd.ExecuteNonQuery()
                End If
                MsgBox("Data Berhasil Disimpan")
                clear()
                Me.Close()
            End If
        End If
    End Sub


    Private Sub tambahpinjam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clear()
        ComboBox1.Items.Clear()
        'koneksi()
        panggil()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        cmd = New MySqlCommand("select * FROM inventaris where nama_brg='" & ComboBox1.Text & "'", koneksi)
        rd = cmd.ExecuteReader
        Do While rd.Read
            TextBox1.Text = rd.Item(3)
        Loop
    End Sub

End Class