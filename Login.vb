Imports CapaNegocio.Usuario
Imports System.Globalization
Imports System.Resources
Imports System.Threading



Public Class Login


#Region "Declaraciones"

    Dim veces As Integer = 0
    Dim NumeroIntentos As Integer
    Dim oUsuario As New Usuario
    Dim oUsuarios As New Usuarios
    Dim oEncriptar As New Encriptar


#End Region


#Region "Metodos"

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        'Cargo el idioma seleccionado
        VariablesGlobales.Idioma = Me.ComboBox1.Text

        'Utilizo Regular Expresion para realizar la validacion de los textbox Usuario y Clave
        'Valida solo caracteres Alfanuméricos
        Dim mregexValidacion As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]+$")
        Dim mcolUsuario As System.Text.RegularExpressions.MatchCollection
        Dim mcolClave As System.Text.RegularExpressions.MatchCollection
        mcolUsuario = mregexValidacion.Matches(TxtUsuario.Text)
        mcolClave = mregexValidacion.Matches(TxtClave.Text)

        If mcolUsuario.Count And mcolClave.Count > 0 Then


            'Instancio a la clase usuario y le cargo el usuario y clave logueado
            'Pero antes encripto la clave para compararla con la guardada
            'oUsuario.Clave = oEncriptar.Encriptar(TxtClave.Text)
            oUsuario.Clave = TxtClave.Text
            oUsuario.Usuario = TxtUsuario.Text
            oUsuarios.Usuario = TxtUsuario.Text

            'Llamo a la funcion para saber cual es la familia del usuario logueado
            'y asi saber que permisos de acceso lo asigno
            'oUsuarios.TraerFamiliasdeUsuarioLogueado()

            'Una ves que traigo la familia desde el objeto Familia la guardo en una variable
            'global para utilizarla desde otros formularios del proyecto
            oUsuarios.CargarFamilia()
            oUsuarios.CargarNombreApellido()
            Dim Familia As String
            Familia = oUsuarios.Familia
            Dim Nombre As String
            Dim Apellido As String
            Nombre = oUsuarios.Nombre
            Apellido = oUsuarios.Apellido
            Dim mReparaciones As New EquiposActivos
            VariablesGlobales.IDUsuario = oUsuarios.IdUsuario
            VariablesGlobales.Tecnico = Nombre & " " & Apellido
            VariablesGlobales.FamiliaUsuarioLogueado = Familia
            VariablesGlobales.UsuarioLogueado = TxtUsuario.Text
            VariablesGlobales.IDU = oUsuarios.IdUsuario

            'Valido que tenga conexion con la base de datos
            oUsuario.ValidarConexion()
            If oUsuario.ValidarConexion = True Then
                'Al presionar Aceptar valida al usuario a travez del metodo ValidarLogin en la capa de negocio
                If oUsuario.ValidarLogin() Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK

                    ''Cargo la accion realizada en Bitacora
                    'Dim obitacora As New Bitacora
                    'obitacora.Observacion = "Ingreso al Sistema"
                    'obitacora.Fecha = CStr(Date.Now)
                    'obitacora.Usuario = UsuarioLogueado
                    'obitacora.Guardar()

                    MenuPrincipal.Show()
                Else
                    'Permito varios intentos de ingreso de clave erronea
                    veces = veces + 1
                    NumeroIntentos = 3
                    If veces < NumeroIntentos Then

                        'Si el usuario es incorrecto muestro un mensaje de contraseña no valida
                        MsgBox("Por favor, si no posee clave de ingreso al Sistema de Gestion Tecnica pongase en contacto con el administrador del Sistema", MsgBoxStyle.Critical, "Validacion de Usuario Incorecta")
                        MensajeError.Visible = True
                        MensajeError.Text = "ATENCION!! Ingreso erroneo quedan " & (NumeroIntentos - veces) & " intentos"

                        'Al ingresar la clave erroneamente limpio los cuadros de texto 
                        TxtUsuario.Text = ""
                        TxtClave.Text = ""

                    Else
                        'Si ingreso 3 veces la clave incorrecta se cierra el sistema
                        Me.Dispose()
                        Me.Close()
                        End

                    End If
                    Me.DialogResult = Windows.Forms.DialogResult.No
                End If
                Me.Visible = False

            Else
                Sin_Conexion.Show(Me)
            End If

        Else

            MsgBox("Por Favor verifique que el nombre de Usuario y la Contraseña ingresada sean solo caracteres Alfanumericos, la seguridad del sistema no permite otro tipo de caracteres", MsgBoxStyle.Critical, "Error de tipo de Datos incorrecto")

        End If




    End Sub

    Private Sub Login_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Una vez cargado el formulario Lodin desactivo el formulario Splash
        Splash.Visible = False
        TxtUsuario.Focus()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
        Splash.Close()

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox1.Text = "Español"
        TxtUsuario.Select()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        'Dependiendo del Idioma seleccionado modifico el Idioma de la Interfaz

        ' If Me.ComboBox1.Text = "Español" Then
        'Core.Localization.CultureManager.ApplicationUICulture = New System.Globalization.CultureInfo("es-AR")
        'Else
        'Core.Localization.CultureManager.ApplicationUICulture = New System.Globalization.CultureInfo("en-US")
        'End If

    End Sub

#End Region

End Class
