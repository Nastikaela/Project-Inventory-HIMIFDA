Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class tambahbalik
    Dim cmd, apus, cmd2 As MySqlCommand
    Dim rd, rd2 As MySqlDataReader
    Sub clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox4.Text = ""
        TextBox1.Text = ""
        DateTimePicker1.Value = Date.Now
        DateTimePicker2.Value = Date.Now
    End Sub
    Sub panggil()
        cmd = New MySqlCommand("select distinct nama_peminjam FROM pinjaman ", koneksi)
        rd = cmd.ExecuteReader
        Do While rd.Read
            ComboBox1.Items.Add(rd("nama_peminjam"))
        Loop
    End Sub

    Sub stocklama()
        cmd = New MySqlCommand("select * FROM inventaris where nama_brg = '" & ComboBox2.Text & "'", koneksi)
        rd = cmd.ExecuteReader
        If rd.Read Then
            txtstock.Text = rd.Item("jmlh_brg")
        End If
    End Sub

    Sub opentable()
        koneksi()
        Dim adapter As New MySqlDataAdapter("select * from keuangan", koneksi)
        Dim mydata As New DataTable
        adapter.Fill(mydata)
        cmd = New MySqlCommand("select * from keuangan order by saldo DESC", koneksi)
        rd = cmd.ExecuteReader
        If rd.Read Then
            txtsaldo.Text = rd.Item("saldo")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ganti()
        Dim s As String
        s = TextBox4.Text + txtstock.Text
        Dim ket As String
        ket = "TERSEDIA"
        If TextBox4.Text = "" Or TextBox1.Text = "" Then
            MsgBox("DATA BELUM LENGKAP")
        Else
            Dim Sqltambah As String = "INSERT INTO pengembalian(tgl_pinjam,tgl_balik,nama_brg, jml_brg, atas_nama,denda)values ('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "', '" & ComboBox2.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & TextBox1.Text & "')"
            cmd = New MySqlCommand(Sqltambah, koneksi)
            cmd.ExecuteNonQuery()
            apus = New MySqlCommand("DELETE FROM pinjaman where nama_peminjam= '" & ComboBox1.Text & "'", koneksi)
            apus.ExecuteNonQuery()

            Dim sqlstock As String = "UPDATE inventaris SET jmlh_brg = ' " & s & "' WHERE nama_brg = '" & ComboBox2.Text & "'"
            cmd2 = New MySqlCommand(sqlstock, koneksi)
            cmd2.ExecuteNonQuery()

            Dim sqllaporan As String = "UPDATE laporan SET tgl_blk = ' " & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "' WHERE nama_brg = '" & ComboBox2.Text & "' and atas_nama = '" & ComboBox1.Text & "'"
            cmd2 = New MySqlCommand(sqllaporan, koneksi)
            cmd2.ExecuteNonQuery()

            Dim sqltersedia As String = "UPDATE inventaris SET Tersedia = ' " & ket & "' WHERE nama_brg = '" & ComboBox2.Text & "'"
            cmd = New MySqlCommand(sqltersedia, koneksi)
            cmd.ExecuteNonQuery()


            restock2()
            MsgBox("Data Berhasil Disimpan")
            Me.Close()
            panggil()
            ComboBox2.Items.Clear()


            clear()
        End If


    End Sub

    Sub tambahan()
        txtsaldo.Text = ""
        cmd = New MySqlCommand("select * from keuangan order by no_id DESC", koneksi)
        rd = cmd.ExecuteReader
        If rd.Read Then
            txtsaldo.Text = rd.Item("saldo")
        End If
    End Sub

    Sub restock2()
        TextBox2.Text = Val(TextBox4.Text) + Val(txtstock.Text)
        Dim sqledit As String = "UPDATE inventaris SET " & _
                                   " jmlh_brg = ' " & TextBox2.Text & "' WHERE nama_brg = '" & ComboBox2.Text & "'"
        cmd = New MySqlCommand(sqledit, koneksi)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub tambahbalik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opentable()
        clear()
        ComboBox1.Items.Clear()
        panggil()
        restock2()
        'openclass()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        cmd = New MySqlCommand("select * FROM pinjaman where nama_peminjam = '" & ComboBox1.Text & "' and nama_brg = '" & ComboBox2.Text & "'", koneksi)
        rd = cmd.ExecuteReader
        Do While rd.Read
            DateTimePicker1.Value = rd.Item("tgl_pinjam")
            TextBox4.Text = rd.Item("jml_brg")
        Loop
        ComboBox2.Text = txtstock.Text
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        cmd = New MySqlCommand("select * FROM pinjaman ", koneksi)
        rd = cmd.ExecuteReader
        Do While rd.Read
            ComboBox2.Text = ""
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add(rd.Item(2))
        Loop
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As Date = DateTimePicker1.Value
        Dim b As Date = DateTimePicker2.Value
        Dim c As Long = DateDiff(DateInterval.Day, a, b)
        If c > 3 Then
            TextBox1.Text = " 10000 "
        Else
            TextBox1.Text = "0"
        End If
        stocklama()
        restock2()
    End Sub

    Sub ganti()
        Dim aa, bs, cs As Long
        Dim ket As String
        aa = TextBox1.Text
        bs = txtsaldo.Text
        cs = aa + bs
        If aa > 0 Then
            ket = "DENDA BARANG"
            Dim Sqltambahan As String = "INSERT INTO keuangan(tanggal, debit, credit, saldo, keterangan)values (' " & Format(DateTimePicker1.Value, "yyyy-MM-dd") & " ', ' " & aa & " ',' " & 0 & " ',' " & cs & " ',' " & ket & " ')"
            cmd = New MySqlCommand(Sqltambahan, koneksi)
            cmd.ExecuteNonQuery()
        End If
    End Sub


    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        cmd = New MySqlCommand("select * FROM inventaris where nama_brg='" & ComboBox1.Text & "' and jmlh_brg = '" & TextBox4.Text & "'", koneksi)
        rd = cmd.ExecuteReader
        Do While rd.Read
            txtstock.Text = rd.Item(3)
        Loop
    End Sub
End Class