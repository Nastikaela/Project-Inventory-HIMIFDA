Public Class menus

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Anda yakin ingin keluar?")
        awal.ShowDialog()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        datapinjam.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        datauang.ShowDialog()
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        awal.ShowDialog()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        datainven.ShowDialog()
    End Sub

    Private Sub TAMPILKANDATAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAMPILKANDATAToolStripMenuItem.Click
        datauang.ShowDialog()
    End Sub

    Private Sub TAMBAHDATAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAMBAHDATAToolStripMenuItem.Click
        tambahuang.ShowDialog()
    End Sub

    Private Sub TAMPILKANDATAToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAMPILKANDATAToolStripMenuItem1.Click
        datainven.ShowDialog()
    End Sub

    Private Sub TAMPILKANDATAToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAMPILKANDATAToolStripMenuItem2.Click
        datapinjam.ShowDialog()
    End Sub

    Private Sub TAMBAHDATAToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAMBAHDATAToolStripMenuItem1.Click
        form2.ShowDialog()
    End Sub

    Private Sub EDITDATAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITDATAToolStripMenuItem.Click
        editdata.ShowDialog()
    End Sub

    Private Sub TAMBAHDATAToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAMBAHDATAToolStripMenuItem2.Click
        tambahpinjam.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("Yakin ingin Keluar?", MsgBoxStyle.OkOnly, "Pemberitahuan")
        Me.Hide()
        login.ShowDialog()
    End Sub

    Private Sub TAMPILKANDATAToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAMPILKANDATAToolStripMenuItem3.Click
        databalik.ShowDialog()
    End Sub
    Private Sub TAMBAHDATAToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAMBAHDATAToolStripMenuItem3.Click
        tambahbalik.ShowDialog()
    End Sub

    Private Sub LAPORANPEMINJAMANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAPORANPEMINJAMANToolStripMenuItem.Click
        laporan.ShowDialog()
    End Sub

    Private Sub menus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub JADWALPENGEMBALIANHARIINIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form3.Show()
    End Sub

    Private Sub EDITDATAToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        editpinjam.Show()
    End Sub

    Private Sub EDITDATAToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        edituang.Show()
    End Sub
End Class