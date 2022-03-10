Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Net.WebRequestMethods

Public Class MenuPrincipal


    Dim Familia As String


    Public Shared Sub CloseAllToolStripMenuItem_Click()
        ' Close all child forms of the parent.
        For Each ChildForm As Form In MenuPrincipal.MdiChildren
            ChildForm.Close()
        Next
    End Sub


    Private Sub MenuPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Esto No permitir abrir el programa mas de una vez 
        If UBound(System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then Application.Exit()


        Try

        Catch ex As Exception
            MsgBox("Se ha producido un error inesperado, cierre la aplicación y vuelva a intentarlo, ya que estos problemas suelen ser temporales.")

        End Try





        'SETEO MI PROPIA CONFIGURACION REGIONAL

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","


        Dim ds As DataSet
        Dim oMoneda As New Moneda
        ds = oMoneda.CotizacionDolar
        Me.txtDolar.Text = ds.Tables(0).Rows(0).Item(0)
        Me.txtFecha.Text = ds.Tables(0).Rows(0).Item(1)

        'Dim m As String = "\\Dhcpsrv\FOTOS REPUESTOS_2011\fondo.jpg"

        Login.Visible = False
        'Verifico la familia del usuario para determinar los menu que se puede acceder
        '--------------------------------------------------------------------------------------------------

        Dim ousuarios As New Usuarios

        'DEPENDIENDO DE LA FAMILIA CONFIGURO LA INTERFAZ DEL PROGRAMA

        Familia = VariablesGlobales.FamiliaUsuarioLogueado

        Select Case Familia

            Case "Tecnico"
                'MENU ADMINISTRAR
                Me.CotizaciónDolarToolStripMenuItem.Enabled = False
                'Formulario Repuestos
                FormRepuestos.btnActualizar.Visible = False
                FormRepuestos.btnEliminar.Visible = False
                FormRepuestos.btnModificar.Visible = False
                FormRepuestos.btnNuevo.Visible = False
                'Formulario Clientes
                FormClientes.btnDescuentos.Visible = False
                Me.ValorManoDeObraToolStripMenuItem.Enabled = False

                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = False
                Me.BackupRestoreToolStripMenuItem.Enabled = False
                Me.FamiliaToolStripMenuItem.Enabled = False
                Me.BitacoraToolStripMenuItem.Enabled = False
                Me.ActualizarStockToolStripMenuItem.Enabled = False
                'Menu Reparaciones
                Me.OrdenesDeIngresoToolStripMenuItem.Enabled = True
                Me.EnProcesoToolStripMenuItem.Enabled = True
                Me.Movimientos.Enabled = False
                Me.AsignarNPIToolStripMenuItem.Enabled = False
                ' Me.EgresosDeReparacionesToolStripMenuItem.Enabled = True
                Me.ConsultarHistorialToolStripMenuItem.Enabled = True
                'Menu Informes
                Me.EstadisticasDeRepracionesToolStripMenuItem.Enabled = False
                Me.EstadisticasDeVentasToolStripMenuItem.Enabled = False

            Case "Supervisor"
                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = False
                Me.BackupRestoreToolStripMenuItem.Enabled = False
                Me.FamiliaToolStripMenuItem.Enabled = False
                Me.BitacoraToolStripMenuItem.Enabled = False
                Me.ActualizarStockToolStripMenuItem.Enabled = False
                'Formulario Clientes
                FormClientes.btnDescuentos.Visible = True
                'Menu Administrar
                Me.CotizaciónDolarToolStripMenuItem.Enabled = True
                Me.ValorManoDeObraToolStripMenuItem.Enabled = True
                'Menu Reparaciones
                Me.OrdenesDeIngresoToolStripMenuItem.Enabled = True
                Me.EnProcesoToolStripMenuItem.Enabled = True
                Me.Movimientos.Enabled = True
                Me.AsignarNPIToolStripMenuItem.Enabled = True
                'Me.EgresosDeReparacionesToolStripMenuItem.Enabled = True
                Me.ConsultarHistorialToolStripMenuItem.Enabled = True
                'Menu Informes
                Me.EstadisticasDeRepracionesToolStripMenuItem.Enabled = False
                Me.EstadisticasDeVentasToolStripMenuItem.Enabled = False



            Case "Asistente"
                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = False
                Me.BackupRestoreToolStripMenuItem.Enabled = False
                Me.FamiliaToolStripMenuItem.Enabled = False
                Me.BitacoraToolStripMenuItem.Enabled = False
                Me.ActualizarStockToolStripMenuItem.Enabled = False
                'Menu Administrar
                Me.CotizaciónDolarToolStripMenuItem.Enabled = True
                Me.RepuestosToolStripMenuItem1.Enabled = False
                Me.ToolBarToolStripMenuItem.Enabled = False
                Me.StatusBarToolStripMenuItem.Enabled = False
                Me.TareasToolStripMenuItem.Enabled = False
                Me.ValorManoDeObraToolStripMenuItem.Enabled = False
                'Menu Reparaciones
                Me.NewWindowToolStripMenuItem.Enabled = False
                Me.EnProcesoToolStripMenuItem.Enabled = True
                Me.Movimientos.Enabled = False
                Me.AsignarNPIToolStripMenuItem.Enabled = True
                'Me.EgresosDeReparacionesToolStripMenuItem.Enabled = False
                'FormReparaciones
                FormReparaciones.btnEliminar.Visible = False
                FormReparaciones.btnModificar.Visible = False
                FormReparaciones.btnNuevo.Visible = False
                FormReparaciones.btnVisto.Visible = False
                ' Me.EgresosDeReparacionesToolStripMenuItem.Enabled = False
                Me.ConsultarHistorialToolStripMenuItem.Enabled = True
                'Menu Impresiones
                Me.ReparacionesToolStripMenuItem.Enabled = False
                Me.PresupuestosToolStripMenuItem.Enabled = False
                Me.OrdenesDeIngresoToolStripMenuItem.Enabled = False
                'Menu Estadisticas
                Me.EstadisticasDeRepracionesToolStripMenuItem.Enabled = False
                Me.EstadisticasDeVentasToolStripMenuItem.Enabled = False
                'Menu Informes
                Me.EstadisticasDeRepracionesToolStripMenuItem.Enabled = False
                Me.EstadisticasDeVentasToolStripMenuItem.Enabled = False
                'FormEgreso
                FormEgreso.Button3.Visible = False
                FormEgreso.Button5.Visible = False
                FormEgreso.Button7.Visible = False
                FormEgreso.Button9.Visible = False

            Case "Deposito"
                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = False
                Me.BackupRestoreToolStripMenuItem.Enabled = False
                Me.FamiliaToolStripMenuItem.Enabled = False
                Me.BitacoraToolStripMenuItem.Enabled = False
                Me.ActualizarStockToolStripMenuItem.Enabled = False
                'Menu Administrar
                Me.CotizaciónDolarToolStripMenuItem.Enabled = False
                Me.RepuestosToolStripMenuItem1.Enabled = False
                Me.ToolBarToolStripMenuItem.Enabled = False
                Me.StatusBarToolStripMenuItem.Enabled = False
                Me.TareasToolStripMenuItem.Enabled = False
                Me.ValorManoDeObraToolStripMenuItem.Enabled = False
                'Menu Reparaciones
                Me.NewWindowToolStripMenuItem.Enabled = False
                Me.EnProcesoToolStripMenuItem.Enabled = True
                Me.AsignarNPIToolStripMenuItem.Enabled = False
                'FormReparaciones
                FormReparaciones.btnEliminar.Visible = False
                FormReparaciones.btnModificar.Visible = False
                FormReparaciones.btnNuevo.Visible = False
                Me.Movimientos.Enabled = False
                'Me.EgresosDeReparacionesToolStripMenuItem.Enabled = True
                Me.ConsultarHistorialToolStripMenuItem.Enabled = False
                Me.EnProcesoToolStripMenuItem.Enabled = False
                'Menu Impresiones
                Me.ReparacionesToolStripMenuItem.Enabled = False
                Me.PresupuestosToolStripMenuItem.Enabled = False
                Me.OrdenesDeIngresoToolStripMenuItem.Enabled = False
                'Menu Estadisticas
                Me.EstadisticasDeRepracionesToolStripMenuItem.Enabled = False
                Me.EstadisticasDeVentasToolStripMenuItem.Enabled = False
                'Menu Informes
                Me.EstadisticasDeRepracionesToolStripMenuItem.Enabled = False
                Me.EstadisticasDeVentasToolStripMenuItem.Enabled = False



            Case "Administrador"
                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = True
                Me.BackupRestoreToolStripMenuItem.Enabled = True
                Me.FamiliaToolStripMenuItem.Enabled = True
                Me.BitacoraToolStripMenuItem.Enabled = True
                Me.ActualizarStockToolStripMenuItem.Enabled = True
                'Menu Administrar
                Me.CotizaciónDolarToolStripMenuItem.Enabled = True
                Me.ValorManoDeObraToolStripMenuItem.Enabled = True
                'Menu Reparaciones
                Me.Movimientos.Enabled = True
                Me.AsignarNPIToolStripMenuItem.Enabled = True
                Me.NewWindowToolStripMenuItem.Enabled = True
                ' Me.CascadeToolStripMenuItem.Enabled = True
                'Menu Informes
                Me.EstadisticasDeRepracionesToolStripMenuItem.Enabled = True
                Me.EstadisticasDeVentasToolStripMenuItem.Enabled = True

            Case Nothing

                Me.MenuStrip.Enabled = False
                MsgBox("El usuario ingresado no posee permisos asignados para utilizar el sistema. Por favor pongase en contacto con el Administrador del Sistema para que le asigne los permisos necesarios para utilizar el sistema.", MsgBoxStyle.Critical, "Información del Sistema")
        End Select



        '--------------------------------------------------------------------------------------------------

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Antes de salir del sistema pregunto si el usuario esta seguro en abandonar el sistema

        If (MsgBox("¿Esta seguro que desea Salir del Sistema?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Información del Sistema")) = MsgBoxResult.Yes Then

            'Al salir del sistema calculo los DV y los guardo en la Base de Datos
            ' Dim oDigitoVerificador As New DigitoVerificador.DV
            ' oDigitoVerificador.nCalcularUsuario()
            'oDigitoVerificador.nGuardarUsuario()
            Me.Close()
            End

        End If

    End Sub

    Private Sub Usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosToolStripMenuItem.Click

        'Cargo el formulario de ABM de Usuarios
        Me.Enabled = False
        ABMPatentes.Show()
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        'Antes de salir del sistema pregunto si el usuario esta seguro en abandonar el sistema

        If (MsgBox("¿Esta seguro que desea Salir del Sistema?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Información del Sistema")) = MsgBoxResult.Yes Then

            'Al salir del sistema calculo los DV y los guardo en la Base de Datos
            ' Dim oDigitoVerificador As New DigitoVerificador.DV
            'oDigitoVerificador.nCalcularUsuario()
            'oDigitoVerificador.nGuardarUsuario()

            'Cargo la accion realizada en Bitacora
            'Dim obitacora As New Bitacora
            'obitacora.Observacion = "Salio del Sistema"
            'obitacora.Fecha = CStr(Date.Now)
            'obitacora.Usuario = UsuarioLogueado
            'obitacora.Guardar()

            Me.Close()
            End

        End If
    End Sub

    Private Sub Familias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FamiliaToolStripMenuItem.Click
        'Cargo el formulario de ABM de Familias-Patentes
        'Me.Enabled = False
        'ABMFamilias.Show()
    End Sub

    Private Sub Sesion_Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sesion_Login.Click

        'Antes de Cerrar la sesion del sistema pregunto si el usuario esta seguro en abandonar el sistema
        If Idioma = "Español" Then
            If (MsgBox("¿Esta seguro que desea Cerrar la Sesión del Sistema?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Información del Sistema")) = MsgBoxResult.Yes Then

                Me.Dispose()

                'Cargo la accion realizada en Bitacora
                'Dim obitacora As New Bitacora
                'obitacora.Observacion = "Cierre de Sesion del Sistema"
                'obitacora.Fecha = CStr(Date.Now)
                'obitacora.Usuario = UsuarioLogueado
                'obitacora.Guardar()


                Login.TxtUsuario.Text = ""
                Login.TxtClave.Text = ""
                Login.Visible = True
                Login.TxtUsuario.Focus()

            End If

        Else

            If (MsgBox("¿This for sure he wants to close the session of the system?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Information of System")) = MsgBoxResult.Yes Then

                Me.Dispose()

                'Cargo la accion realizada en Bitacora
                'Dim obitacora As New Bitacora
                'obitacora.Observacion = "Cierre de Sesion del Sistema"
                'obitacora.Fecha = CStr(Date.Now)
                'obitacora.Usuario = UsuarioLogueado
                'obitacora.Guardar()


                Login.TxtUsuario.Text = ""
                Login.TxtClave.Text = ""
                Login.Visible = True
                Login.TxtUsuario.Focus()

            End If

        End If

    End Sub

    Private Sub BackupRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupRestoreToolStripMenuItem.Click
        'Cargo el formulario de Backup restore de la Base de Datos
        Me.Enabled = False
        BackupRestore.Show()
    End Sub

    Private Sub OrdenIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewWindowToolStripMenuItem.Click
        'Cargo el formulario de Ingreso de equipos a reparacion
        Me.MainMenuStrip.Enabled = False
        IngresarEquipos.Show()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBarToolStripMenuItem.Click
        'Cargo el formulario de ABM Clientes
        Me.MainMenuStrip.Enabled = False
        FormClientes.Show()
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusBarToolStripMenuItem.Click
        'Cargo el formulario de ABM Equipo
        Me.MainMenuStrip.Enabled = False
        EquiposABM.Show()
    End Sub

    Private Sub TareasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TareasToolStripMenuItem.Click
        'Cargo el formulario de ABM Tareas
        Me.MainMenuStrip.Enabled = False
        FormTareas.Show()
    End Sub

    Private Sub RepuestosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepuestosToolStripMenuItem1.Click

        Select Case Familia

            Case "Tecnico"
                'MENU ADMINISTRAR
                Me.CotizaciónDolarToolStripMenuItem.Enabled = False
                'Formulario Repuestos
                FormRepuestos.btnActualizar.Visible = False
                FormRepuestos.btnEliminar.Visible = False
                FormRepuestos.btnModificar.Visible = False
                FormRepuestos.btnNuevo.Visible = False
                'Formulario Clientes
                FormClientes.btnDescuentos.Visible = False

                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = False
                Me.BackupRestoreToolStripMenuItem.Enabled = False
                Me.FamiliaToolStripMenuItem.Enabled = False
                Me.BitacoraToolStripMenuItem.Enabled = False
                Me.ActualizarStockToolStripMenuItem.Enabled = False
                'Menu Reparaciones
                Me.OrdenesDeIngresoToolStripMenuItem.Enabled = True
                Me.EnProcesoToolStripMenuItem.Enabled = True
                'Me.EgresosDeReparacionesToolStripMenuItem.Enabled = True
                Me.ConsultarHistorialToolStripMenuItem.Enabled = True

            Case "Supervisor"
                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = False
                Me.BackupRestoreToolStripMenuItem.Enabled = False
                Me.FamiliaToolStripMenuItem.Enabled = False
                Me.BitacoraToolStripMenuItem.Enabled = False
                Me.ActualizarStockToolStripMenuItem.Enabled = False
                'Formulario Clientes
                FormClientes.btnDescuentos.Visible = True
                'Menu Administrar
                Me.CotizaciónDolarToolStripMenuItem.Enabled = True
                'Menu Reparaciones
                Me.OrdenesDeIngresoToolStripMenuItem.Enabled = True
                Me.EnProcesoToolStripMenuItem.Enabled = True
                ' Me.EgresosDeReparacionesToolStripMenuItem.Enabled = True
                Me.ConsultarHistorialToolStripMenuItem.Enabled = True



            Case "Asistente"
                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = False
                Me.BackupRestoreToolStripMenuItem.Enabled = False
                Me.FamiliaToolStripMenuItem.Enabled = False
                Me.BitacoraToolStripMenuItem.Enabled = False
                Me.ActualizarStockToolStripMenuItem.Enabled = False
                'Menu Administrar
                Me.CotizaciónDolarToolStripMenuItem.Enabled = True
                Me.RepuestosToolStripMenuItem1.Enabled = False
                Me.ToolBarToolStripMenuItem.Enabled = False
                Me.StatusBarToolStripMenuItem.Enabled = False
                Me.TareasToolStripMenuItem.Enabled = False
                'Menu Reparaciones
                Me.NewWindowToolStripMenuItem.Enabled = False
                Me.EnProcesoToolStripMenuItem.Enabled = True
                'FormReparaciones
                FormReparaciones.btnEliminar.Visible = False
                FormReparaciones.btnModificar.Visible = False
                FormReparaciones.btnNuevo.Visible = False
                ' Me.EgresosDeReparacionesToolStripMenuItem.Enabled = True
                Me.ConsultarHistorialToolStripMenuItem.Enabled = False
                'Menu Impresiones
                Me.ReparacionesToolStripMenuItem.Enabled = False
                Me.PresupuestosToolStripMenuItem.Enabled = False
                Me.OrdenesDeIngresoToolStripMenuItem.Enabled = False
                'Menu Estadisticas
                Me.EstadisticasDeRepracionesToolStripMenuItem.Enabled = False
                Me.EstadisticasDeVentasToolStripMenuItem.Enabled = False

            Case "Deposito"
                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = False
                Me.BackupRestoreToolStripMenuItem.Enabled = False
                Me.FamiliaToolStripMenuItem.Enabled = False
                Me.BitacoraToolStripMenuItem.Enabled = False
                Me.ActualizarStockToolStripMenuItem.Enabled = False
                'Menu Administrar
                Me.CotizaciónDolarToolStripMenuItem.Enabled = False
                Me.RepuestosToolStripMenuItem1.Enabled = False
                Me.ToolBarToolStripMenuItem.Enabled = False
                Me.StatusBarToolStripMenuItem.Enabled = False
                Me.TareasToolStripMenuItem.Enabled = False
                'Menu Reparaciones
                Me.NewWindowToolStripMenuItem.Enabled = False
                Me.EnProcesoToolStripMenuItem.Enabled = True
                'FormReparaciones
                FormReparaciones.btnEliminar.Visible = False
                FormReparaciones.btnModificar.Visible = False
                FormReparaciones.btnNuevo.Visible = False
                'Me.EgresosDeReparacionesToolStripMenuItem.Enabled = True
                Me.ConsultarHistorialToolStripMenuItem.Enabled = False
                Me.EnProcesoToolStripMenuItem.Enabled = False
                'Menu Impresiones
                Me.ReparacionesToolStripMenuItem.Enabled = False
                Me.PresupuestosToolStripMenuItem.Enabled = False
                Me.OrdenesDeIngresoToolStripMenuItem.Enabled = False
                'Menu Estadisticas
                Me.EstadisticasDeRepracionesToolStripMenuItem.Enabled = False
                Me.EstadisticasDeVentasToolStripMenuItem.Enabled = False

            Case "Administrador"
                'Menu Seguridad
                Me.UsuariosToolStripMenuItem.Enabled = True
                Me.BackupRestoreToolStripMenuItem.Enabled = True
                Me.FamiliaToolStripMenuItem.Enabled = True
                Me.BitacoraToolStripMenuItem.Enabled = True
                Me.ActualizarStockToolStripMenuItem.Enabled = True
                'Menu Administrar
                Me.CotizaciónDolarToolStripMenuItem.Enabled = True
                'Menu Reparaciones
                Me.NewWindowToolStripMenuItem.Enabled = True
                ' Me.CascadeToolStripMenuItem.Enabled = True

            Case Nothing

                Me.MenuStrip.Enabled = False
                MsgBox("El usuario ingresado no posee permisos asignados para utilizar el sistema. Por favor pongase en contacto con el Administrador del Sistema para que le asigne los permisos necesarios para utilizar el sistema.", MsgBoxStyle.Critical, "Información del Sistema")
        End Select

        'Cargo el formulario de ABM Repuestos
        Me.MainMenuStrip.Enabled = False
        FormRepuestos.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cargo el formulario de ABM Reparaciones
        Me.Enabled = False
        FormReparaciones.Show()
    End Sub

    Private Sub Bitacora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BitacoraToolStripMenuItem.Click
        'Cargo el formulario de Bitacora
        Me.Enabled = False
        FormBitacora.Show()
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cargo el formulario de Servicio
        Me.Enabled = False
        FormServicio.Show()
    End Sub

    Private Sub HistorialClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cargo el formulario de consultas x cliente
        Me.Enabled = False
        FormAEPendientes.Show()
    End Sub

    Private Sub EquipoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        'Cargo el formulario de Ayuda Acerca de SIGT
        Me.Enabled = False
        AcercaDe.Show()
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Help.ShowHelp(Me, CNetHelpProvider.HelpNamespace)
    End Sub

    Private Sub InglesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub EspañolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CotizaciónDolar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CotizaciónDolarToolStripMenuItem.Click
        'Cargo el formulario de ABM Repuestos
        Me.MainMenuStrip.Enabled = False
        FormDolar.Show()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub EnReparacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnProcesoToolStripMenuItem.Click

        Me.MainMenuStrip.Enabled = False
        FormReparaciones.Show()

    End Sub

    Private Sub PortuguesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EgresosDeReparaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ClientesPorVendedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cargo el formulario de Clientes por Vendedor
        Me.Enabled = False
        FormConsultaVendedor.Show()
    End Sub

    Private Sub EquipoPorClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cargo el formulario de Clientes por Vendedor
        Me.Enabled = False
        FormConsultaEquipoVendido.Show()
    End Sub

    Private Sub ActualizarStockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarStockToolStripMenuItem1.Click
        '*****************************************************
        '*****************************************************
        Dim da As OleDb.OleDbDataAdapter
        Dim dt As DataTable
        Dim i, n As Integer
        Dim a, b As Integer
        Dim sel, sel2 As String
        Dim NroParte As String
        Dim stock, compra As Integer
        '********************************************************
        Dim sqlstring As String = "SELECT NroParte FROM Repuestos"
        Dim daa As New SqlClient.SqlDataAdapter(sqlstring, CapaAccesoDatos.ProveedorDeDatos.Conexion.StrConnection)
        Dim mDataTable = New System.Data.DataTable
        daa.Fill(mDataTable)

        b = mDataTable.Rows.Count

        For a = 0 To b - 1

            NroParte = mDataTable.Rows(a).Item(0)

            '////////////////////////////////////////////////////////////////////////////////////////  

            sel = "SELECT ITEMSACUM.STKACTUAL, ITEMSACUM.stkencompra FROM ITEMS, ITEMSACUM WHERE ITEMSACUM.coditm = '" & NroParte & "'"

            ' Crear el DataAdapter
            da = New OleDb.OleDbDataAdapter(sel, CapaAccesoDatos.ProveedorDeDatos.Conexion.ConexionBAS)
            '
            ' Llenar el DataTable
            dt = New DataTable
            da.Fill(dt)

            n = dt.Rows.Count

            If n = 0 Then
                ' No se ha encontrado ningún registro que coincida con la selección

            Else

                For i = 0 To n - 1

                    stock = dt.Rows(i).Item(0).ToString
                    compra = dt.Rows(i).Item(1).ToString

                Next
            End If

            sel2 = "UPDATE Repuestos SET Stock='" & stock & "',Compra='" & compra & "' WHERE NroParte='" & NroParte & "'"

            CapaAccesoDatos.ProveedorDeDatos.Conexion.ExecuteNonQuery(sel2)

            '*****************************************************
            '*****************************************************
            a = a + 1
        Next
        mDataTable.Dispose()


        '********************************************************
    End Sub

    Private Sub ActualizarClientesBASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarClientesBASToolStripMenuItem.Click

        'CARGO LOS CLIENTES DEL BAS
        '*****************************************************
        Dim da As OleDb.OleDbDataAdapter
        Dim dt As DataTable
        Dim i, n As Integer
        Dim a As Integer
        Dim sel2 As String
        Dim sqlstring As String = "SELECT CODCTACTE, NOMBRE, DOMICILIO, LOCALIDAD, TELEFONO, EMAIL, FECHAREG, CODVENCOM, FANTASIA FROM CTACTES"

        ' Crear el DataAdapter
        da = New OleDb.OleDbDataAdapter(sqlstring, CapaAccesoDatos.ProveedorDeDatos.Conexion.ConexionBAS)
        '
        ' Llenar el DataTable
        dt = New DataTable
        da.Fill(dt)

        n = dt.Rows.Count

        For i = 0 To n - 1

            sel2 = "UPDATE CLIENTESBAS SET Nombre='" & dt.Rows(i).Item(1).ToString & "',Domicilio='" & dt.Rows(i).Item(2).ToString & "',Localidad='" & dt.Rows(i).Item(3).ToString & "',Telefono='" & dt.Rows(i).Item(4).ToString & "',Email='" & dt.Rows(i).Item(5).ToString & "',FechaAlta='" & dt.Rows(i).Item(6).ToString & "',IDVendedor='" & dt.Rows(i).Item(7).ToString & "',Fantasia='" & dt.Rows(i).Item(8).ToString & "' WHERE IDCLIENTE='" & dt.Rows(i).Item(0).ToString & "'"
            CapaAccesoDatos.ProveedorDeDatos.Conexion.ExecuteNonQuery(sel2)
            a = a + 1
        Next

        '********************************************************

        'CARGO LOS CONTACTOS DEL BAS

        '*****************************************************
        sqlstring = "SELECT CODCTACTE, NOMBRE, EMAIL, TELEFONO, OBSERVACION FROM CTACTESCONT"

        ' Crear el DataAdapter
        da = New OleDb.OleDbDataAdapter(sqlstring, CapaAccesoDatos.ProveedorDeDatos.Conexion.ConexionBAS)
        '
        ' Llenar el DataTable
        dt = New DataTable
        da.Fill(dt)

        n = dt.Rows.Count

        For i = 0 To n - 1

            sel2 = "UPDATE CONTACTOSBAS SET Nombre='" & dt.Rows(i).Item(1).ToString & "',Email='" & dt.Rows(i).Item(2).ToString & "',Telefono='" & dt.Rows(i).Item(3).ToString & "',Observacion='" & dt.Rows(i).Item(4).ToString & "' WHERE IDCLIENTE='" & dt.Rows(i).Item(0).ToString & "'"
            CapaAccesoDatos.ProveedorDeDatos.Conexion.ExecuteNonQuery(sel2)
            a = a + 1
        Next

        '********************************************************

    End Sub

    Private Sub ConsultarHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarHistorialToolStripMenuItem.Click
        'Cargo el formulario de consultas x numero de serie
        Me.Enabled = False
        FormConsultaEquipo.Show()
    End Sub

    Private Sub ActualizarAEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarAEToolStripMenuItem.Click
        '*****************************************************
        Dim da As OleDb.OleDbDataAdapter
        Dim dt As DataTable
        Dim i, n, a As Integer
        Dim sel2 As String
        Dim sqlstring As String = "SELECT NUMERO FROM TRANSAC WHERE CODCMP='OC' AND USERNAME='dzeitounlian' GROUP BY NUMERO ORDER BY NUMERO ASC"
        ' Crear el DataAdapter
        da = New OleDb.OleDbDataAdapter(sqlstring, CapaAccesoDatos.ProveedorDeDatos.Conexion.ConexionBAS)
        ' Llenar el DataTable
        dt = New DataTable
        da.Fill(dt)

        n = dt.Rows.Count

        For i = 0 To n - 1
            Dim AE As Integer
            AE = dt.Rows(i).Item(0).ToString
            sel2 = "UPDATE AE SET Numero='" & AE & "' WHERE ID='" & i & "'"
            '*******************************************************************************
            '*******************************************************************************
            '*******************************************************************************
            Dim da2 As OleDb.OleDbDataAdapter
            Dim dt2 As DataTable
            Dim i2, n2, a2 As Integer
            Dim sel22 As String
            Dim sqlstring2 As String = "SELECT MS.CODITM, I.DESCRIPCION, MS.CANTIDAD, MS.PRECIO, MS.IMPORTE, MS.FECHAENT FROM MVSITEMS as MS, ITEMS as I, TRANSAC as T, TRANSACCONTROL as TC WHERE I.CODITM=MS.CODITM AND MS.NROTRANS=T.NROTRANS AND T.NROTRANS=TC.NROTRANS  AND T.CODCMP=TC.CODCMP AND TC.CODCMP='OC' AND T.NUMERO='" & AE & "' GROUP BY MS.CODITM, MS.CANTIDAD, MS.PRECIO, MS.IMPORTE, MS.FECHAENT, I.DESCRIPCION ORDER BY MS.FECHAENT ASC"
            ' Crear el DataAdapter
            da2 = New OleDb.OleDbDataAdapter(sqlstring2, CapaAccesoDatos.ProveedorDeDatos.Conexion.ConexionBAS)
            ' Llenar el DataTable
            dt2 = New DataTable
            da2.Fill(dt2)

            n2 = dt2.Rows.Count



            Dim PN, Descripcion, Precio, Importe, fecha As String
            Dim Cantidad As Integer

            'VERIFICO EXISTENCIA DE AE
            Dim oAE As New AE
            oAE.NumAE = AE


            If oAE.ValidarAE() = False Then
                For i2 = 0 To n2 - 1
                    PN = dt2.Rows(i2).Item(0).ToString
                    Descripcion = dt2.Rows(i2).Item(1).ToString
                    Cantidad = dt2.Rows(i2).Item(2).ToString
                    Precio = dt2.Rows(i2).Item(3).ToString
                    Importe = dt2.Rows(i2).Item(4).ToString
                    fecha = dt2.Rows(i2).Item(5).ToString

                    sel22 = "INSERT INTO AE_Descripcion (AE,PN,Descripcion,Cantidad,Precio,Importe,Fecha,Estado) VALUES('" & AE & "','" & PN & "','" & Descripcion & "','" & Cantidad & "','" & Precio & "','" & Importe & "','" & fecha & "','Transito')"
                    CapaAccesoDatos.ProveedorDeDatos.Conexion.ExecuteNonQuery(sel22)
                    a2 = a2 + 1
                Next
            Else
            End If


            '*******************************************************************************
            '*******************************************************************************
            '*******************************************************************************
            CapaAccesoDatos.ProveedorDeDatos.Conexion.ExecuteNonQuery(sel2)
            a = a + 1
        Next


    End Sub

    Private Sub ReparacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReparacionesToolStripMenuItem.Click
        'Cargo el formulario de Impresion de Ordenes de Servicio
        Me.Enabled = False
        FormImpresionServicios.Show()
    End Sub

    Private Sub OrdenesDeIngresoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenesDeIngresoToolStripMenuItem.Click
        'Cargo el formulario de Impresion de Ordenes de Ingreso
        Me.Enabled = False
        FormImpresionIngreso.Show()
    End Sub

    Private Sub PresupuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PresupuestosToolStripMenuItem.Click
        'Cargo el formulario de Impresion de Presupuestos
        Me.Enabled = False
        FormImpresionPresupuestos.Show()
    End Sub

    Private Sub ActualizarStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarStockToolStripMenuItem.Click

    End Sub

    Private Sub AEVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cargo el formulario de AE VENTAS
        Me.Enabled = False
        FormAEVentas.Show()
    End Sub

    Private Sub ActualizarAEVENTASToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarAEVENTASToolStripMenuItem.Click
        '*****************************************************
        Dim da As OleDb.OleDbDataAdapter
        Dim dt As DataTable
        Dim i, n, a As Integer
        Dim sel2 As String
        Dim sqlstring As String = "SELECT NUMERO FROM TRANSAC WHERE CODCMP='OC' AND USERNAME='gcanepa' GROUP BY NUMERO ORDER BY NUMERO ASC"
        ' Crear el DataAdapter
        da = New OleDb.OleDbDataAdapter(sqlstring, CapaAccesoDatos.ProveedorDeDatos.Conexion.ConexionBAS)
        ' Llenar el DataTable
        dt = New DataTable
        da.Fill(dt)

        n = dt.Rows.Count

        For i = 0 To n - 1
            Dim AE As Integer
            AE = dt.Rows(i).Item(0).ToString
            sel2 = "UPDATE AEVentas SET Numero='" & AE & "' WHERE ID='" & i & "'"
            '*******************************************************************************
            '*******************************************************************************
            '*******************************************************************************
            Dim da2 As OleDb.OleDbDataAdapter
            Dim dt2 As DataTable
            Dim i2, n2, a2 As Integer
            Dim sel22 As String
            Dim sqlstring2 As String = "SELECT MS.CODITM, I.DESCRIPCION, MS.CANTIDAD, MS.PRECIO, MS.IMPORTE, MS.FECHAENT FROM MVSITEMS as MS, ITEMS as I, TRANSAC as T, TRANSACCONTROL as TC WHERE I.CODITM=MS.CODITM AND MS.NROTRANS=T.NROTRANS AND T.NROTRANS=TC.NROTRANS  AND T.CODCMP=TC.CODCMP AND TC.CODCMP='OC' AND T.NUMERO='" & AE & "' GROUP BY MS.CODITM, MS.CANTIDAD, MS.PRECIO, MS.IMPORTE, MS.FECHAENT, I.DESCRIPCION ORDER BY MS.FECHAENT ASC"
            ' Crear el DataAdapter
            da2 = New OleDb.OleDbDataAdapter(sqlstring2, CapaAccesoDatos.ProveedorDeDatos.Conexion.ConexionBAS)
            ' Llenar el DataTable
            dt2 = New DataTable
            da2.Fill(dt2)

            n2 = dt2.Rows.Count



            Dim PN, Descripcion, Precio, Importe, fecha As String
            Dim Cantidad As Integer

            'VERIFICO EXISTENCIA DE AE
            Dim oAE As New AE
            oAE.NumAE = AE


            If oAE.ValidarAE() = False Then
                For i2 = 0 To n2 - 1
                    PN = dt2.Rows(i2).Item(0).ToString
                    Descripcion = dt2.Rows(i2).Item(1).ToString
                    Cantidad = dt2.Rows(i2).Item(2).ToString
                    Precio = dt2.Rows(i2).Item(3).ToString
                    Importe = dt2.Rows(i2).Item(4).ToString
                    fecha = dt2.Rows(i2).Item(5).ToString

                    sel22 = "INSERT INTO AEVentas_Descripcion (AE,PN,Descripcion,Cantidad,Precio,Importe,Fecha,Estado) VALUES('" & AE & "','" & PN & "','" & Descripcion & "','" & Cantidad & "','" & Precio & "','" & Importe & "','" & fecha & "','Transito')"
                    CapaAccesoDatos.ProveedorDeDatos.Conexion.ExecuteNonQuery(sel22)
                    a2 = a2 + 1
                Next
            Else
            End If


            '*******************************************************************************
            '*******************************************************************************
            '*******************************************************************************
            CapaAccesoDatos.ProveedorDeDatos.Conexion.ExecuteNonQuery(sel2)
            a = a + 1
        Next
    End Sub

    Private Sub ValorManoDeObraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValorManoDeObraToolStripMenuItem.Click
        Me.MainMenuStrip.Enabled = False
        FrmManoObra.Show()
    End Sub

    Private Sub IntranetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntranetToolStripMenuItem.Click
        FormConsultas.Show()
        FormConsultas.WebBrowser1.Navigate("http://192.168.0.37:8086/Clientes.aspx")
    End Sub

    Private Sub HistoricoPorAñosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoricoPorAñosToolStripMenuItem.Click
        FormConsultas.WebBrowser1.Navigate("http://HP-MSD1:88/historia.aspx")
        FormConsultas.Show()
    End Sub

    Private Sub ConsumoDeRepuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumoDeRepuestosToolStripMenuItem.Click
        FormConsultas.WebBrowser1.Navigate("http://HP-MSD1:88/consumo.aspx")
        FormConsultas.Show()
    End Sub

    Private Sub FacturadoPorEmpresaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturadoPorEmpresaToolStripMenuItem.Click
        FormConsultas.WebBrowser1.Navigate("http://HP-MSD1:88/estadistica.aspx")
        FormConsultas.Show()
    End Sub

    Private Sub CambiarClaveUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarClaveUsuarioToolStripMenuItem.Click
        'Cargo el formulario Modificar Contraseña
        Me.Enabled = False
        FormClaveUsuario.Show()
    End Sub

    Private Sub AsignarNPIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarNPIToolStripMenuItem.Click
        'Cargo el formulario de Asignacion de NPI
        Me.Enabled = False
        FormNPI.Show()
    End Sub

    Private Sub Ingreso_Click(sender As System.Object, e As System.EventArgs)
        'Cargo el formulario de Ingresos de equipos
        Me.Enabled = False
        FormIngresoDepo.Show()
    End Sub

    Private Sub EgresoDeEquiposToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EgresoDeEquiposToolStripMenuItem.Click
        'Cargo el formulario de Egresos de equipos
        Me.Enabled = False
        FormEgreso.Show()
    End Sub

    Private Sub IngresoDeMercaderiaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        'Cargo el formulario de Ingreso de Mercaderia x Contrato
        Me.Enabled = False
        FrmIngresoMercaderia.Show()
    End Sub

    Private Sub EquiposVendidosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EquiposVendidosToolStripMenuItem.Click
        FormConsultas.Show()
        FormConsultas.WebBrowser1.Navigate("http://192.168.0.37:8086/About.aspx")
    End Sub

    Private Sub ContratosYGarantiasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub MovimientosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        'Cargo el formulario de Ingreso de Movimientos de Mercaderia
        Me.Enabled = False
        FrmMovimientos.Show()
    End Sub

    Private Sub StockRepuestosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StockRepuestosToolStripMenuItem.Click
        FormConsultas.Show()
        FormConsultas.WebBrowser1.Navigate("http://sistema3/b_item.htm")
    End Sub

    Private Sub IngresoDeMercaderiaToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles IngresoDeMercaderiaToolStripMenuItem1.Click
        'Cargo el formulario de Ingreso de Mercaderia x Contrato
        Me.Enabled = False
        FrmIngresoMercaderia.Show()
    End Sub

    Private Sub VerMovimientosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerMovimientosToolStripMenuItem.Click
        'Cargo el formulario de Ingreso de Movimientos de Mercaderia
        Me.Enabled = False
        FrmMovimientos.Show()
    End Sub


    Private Sub EgresoDeMercaderiaToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles EgresoDeMercaderiaToolStripMenuItem1.Click
        'Cargo el formulario de Ingreso de Mercaderia x Contrato
        Me.Enabled = False
        FrmEgresoMercaderia.Show()
    End Sub

    Private Sub ReparacionesToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ReparacionesToolStripMenuItem1.Click

    End Sub
End Class
