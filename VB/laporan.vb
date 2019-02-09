Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data

Public Class laporan
    Dim myconn As New MySqlConnection
    Dim mycommand As New MySqlCommand
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim reader As MySqlDataReader
    Dim cmd As MySqlCommand

    Sub opentable()
        'koneksi()
        Dim myadapter As New MySqlDataAdapter("select * from laporan", koneksi)
        Dim mydata As New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
    End Sub

    Sub atur()
        Me.DataGridView1.Columns(0).HeaderText = "NO LAPORAN"
        Me.DataGridView1.Columns(1).HeaderText = "TANGGAL PEMINJAMAN"
        Me.DataGridView1.Columns(2).HeaderText = "NAMA PEMINJAM"
        Me.DataGridView1.Columns(3).HeaderText = "NAMA BARANG"
        Me.DataGridView1.Columns(4).HeaderText = "JUMLAH BARANG"
        Me.DataGridView1.Columns(5).HeaderText = "TANGGAL PENGEMBALIAN"
        Me.DataGridView1.Columns(0).Width = 100
        Me.DataGridView1.Columns(1).Width = 100
        Me.DataGridView1.Columns(2).Width = 100
        Me.DataGridView1.Columns(3).Width = 100
        Me.DataGridView1.Columns(4).Width = 100
        Me.DataGridView1.Columns(5).Width = 100
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        opentable()
        atur()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.ClearSelection()
        mycommand.Connection = koneksi()
        Dim SQL As String
        SQL = ("select * from laporan where tgl_blk = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'")
        mycommand.CommandText = SQL
        myadapter.SelectCommand = mycommand
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
    End Sub
End Class