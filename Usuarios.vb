Public Class Usuarios

    Private Sub Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SETEO DE LA GRILLA
        With Me.GrillaUsuarios

            With .Columns
                .Add("cId", "Id")
                .Add("cNombre", "Nombre")
                .Add("cApellido", "Apellido")
                .Add("cDireccion", "Dirección")

                .Item("cId").Width = 32
                .Item("cNombre").Width = 140
                .Item("cApellido").Width = 140
                .Item("cDireccion").Width = 200
            End With
            .AllowDrop = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
        End With
    End Sub

    Private Sub GrillaUsuarios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaUsuarios.CellContentClick

    End Sub
End Class
