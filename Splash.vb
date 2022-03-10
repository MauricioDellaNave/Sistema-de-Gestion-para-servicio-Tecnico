Imports CapaNegocio.DigitoVerificador.DV
Imports System.Configuration

Public Class Splash


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Antes de salir del sistema pregunto si el usuario esta seguro en abandonar el sistema

        If (MsgBox("¿Esta seguro que desea Salir del Sistema?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Información del Sistema")) = MsgBoxResult.Yes Then
            Me.Close()
            End

        End If

    End Sub

    Public Sub Splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ProgressBar1.Maximum = 100000
        Dim i As Integer
        For i = 0 To ProgressBar1.Maximum
            ProgressBar1.Value = i
        Next

        'Oculto los botones de integridad violada
        Me.Enabled = False
        Button1.Visible = False
        Button2.Visible = False

    End Sub

End Class