Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class editpinjam
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Sub clear()
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox1.Text = ""
        TextBox5.Text = ""

    End Sub

    Sub atur()
        Me.DataGridView1.Columns(0).HeaderText = "KODE BARANG"
        Me.DataGridView1.Columns(1).HeaderText = "TANGGAL PINJAM"
        Me.DataGridView1.Columns(2).HeaderText = "NAMA BARANG"
        Me.DataGridView1.Columns(3).HeaderText = "NAMA PEMINJAM"
        Me.DataGridView1.Columns(4).HeaderText = "JUMLAH BARANG"
        Me.DataGridView1.Columns(5).HeaderText = "TANGGAL KEMBALI"

    End Sub
    Sub opentable()
        koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from pinjaman", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        'atur()
    End Sub

    Sub opendoor()
        koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from inventaris", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView2.DataSource = mydata
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim sisa As String
        sisa = Val(TextBox6.Text) - Val(TextBox4.Text)
        If TextBox3.Text = "" Or TextBox1.Text = "" Or TextBox5.Text = "" Or TextBox4.Text = "" Then
            MsgBox("DATA BELUM LENGKAP")
        Else
            cmd = New MySqlCommand(" UPDATE pinjaman SET kode_pjm = '" & TextBox1.Text & "', tgl_pinjam = ' " & Format(DateTimePicker1.Value, "yyyy-MM-dd") & " ',  tgl_kembali = ' " & Format(DateTimePicker2.Value, "yyyy-MM-dd") & " ', nama_brg = ' " & TextBox3.Text & " ', jml_brg = ' " & sisa & "',  nama_peminjam = ' " & TextBox5.Text & "' where kode_pjm ='" & TextBox1.Text & "'", koneksi)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Disimpan")
            clear()
            Me.Close()
        End If
    End Sub
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        opentable()
        opendoor()
        'atur()
        koneksi()
        TextBox6.Text = Val(TextBox2.Text) + Val(TextBox4.Text)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        DateTimePicker2.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        cmd = New MySqlCommand("select * FROM inventaris where nama_brg= '" & TextBox3.Text & "'", koneksi)
        rd = cmd.ExecuteReader
        If rd.Read Then
            TextBox2.Text = rd.Item(3)
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        TextBox2.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value
    End Sub
End Class