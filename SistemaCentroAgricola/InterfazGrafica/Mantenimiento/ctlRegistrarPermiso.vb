﻿Imports LogicaNegocio.ClsGestor
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.CrystalReports.Engine
Public Class ctlRegistrarPermiso
    Dim _gestor As New LogicaNegocio.ClsGestor
    Dim _listaSocio As List(Of Array) = New List(Of Array)() 'declarar una variable tipo lista genérica de Array
    Dim _listaProducto As List(Of Array) = New List(Of Array)() 'declarar una variable tipo lista genérica de Array
    Dim _tempArray As Array 'declarar una variable tipo Array
    Dim _criterio As String
    Dim _resul As Boolean
    Dim _codPermiso As Int32

    Private Sub ctlRegistrarPermiso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCriterio.Focus()
        limpiarForm()
        nombrarColumnas()
        invisible()
        obtenerFechaVence(dtpFechaCrea.Value)
        txtNombre.Text = dgvDatos.SelectedCells(2).Value
        txtDireccionFinca.Text = dgvDatos.SelectedCells(3).Value
    End Sub

    Private Sub txtCriterio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCriterio.TextChanged
        evaluar()
        If txtCriterio.Text = "" Then
            cargarSocios()
            nombrarColumnas()
            invisible()

        Else
            buscarCriterioSocio(txtCriterio.Text)
        End If
    End Sub

    Private Sub limpiarForm()
        Me.dgvDatos.DataSource = ""
        Me.txtCriterio.Text = ""
        ltbProductoAsignado.Items.Clear()
        cargarSocios()
        cargarProductos()
    End Sub

    Private Sub evaluar()

        If txtCriterio.Text.Equals("") Then
            cargarSocios()
            nombrarColumnas()
            invisible()
        Else
            Me.dgvDatos.DataSource = ""
        End If

    End Sub

    ''' <summary>
    ''' Método de clase, encarga de renombrar los encabezados al datagridview
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub nombrarColumnas()
        dgvDatos.Columns(0).HeaderText = "Código"
        dgvDatos.Columns(1).HeaderText = "Identificación"
        dgvDatos.Columns(2).HeaderText = "Nombre"
        dgvDatos.Columns(2).MinimumWidth = 120
    End Sub

    ''' <summary>
    ''' Método de clase, encarga de poner invisible algunas calumnas al datagridview
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub invisible()
        dgvDatos.Columns(3).Visible = False
        dgvDatos.Columns(4).Visible = False
        dgvDatos.Columns(5).Visible = False
        dgvDatos.Columns(6).Visible = False
        dgvDatos.Columns(7).Visible = False
    End Sub

    ''' <summary>
    ''' Método de clase, encargado de cargar los productos existentes en la DB con el nombre suministado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cargarProductos()
        Try
            Dim _listTemp As New List(Of ClsCastCadenaProducto) 'declarar una variable tipo lista genérica tipo clsCastCadena (Wrapper)
            Dim _tempCast() As String 'declarar una variable tipo arreglo de String

            _listaProducto = _gestor.listarProductos() 'asignar el resultado de la búsqueda devuelto por un método del Gestor

            For i As Integer = 0 To _listaProducto.Count - 1 'estructura iterativa tipo matriz para recorrer y envolver por el tipo adecuado

                _tempArray = _listaProducto(i) 'clonar a un Array temporal la FILA (ROW) de la consulta
                ReDim _tempCast(_tempArray.Length() - 1) 'redimensionar el arreglo a un tamaño indicado

                For j As Integer = 0 To _tempArray.Length - 1 'recorrer la parte interna de la matriz, columna (COLUMN)
                    _tempCast(j) = _tempArray.GetValue(j).ToString() 'asignar el valor de cada celda 
                Next

                _listTemp.Add(New ClsCastCadenaProducto(_tempCast(0).ToString(), _tempCast(1).ToString(), _tempCast(2).ToString())) 'agregar a la lista genérica una colección de la clase wrapper

            Next

            'asignar el fuente de dato para un control tipo listbox la lista genérica wrappeada
            Me.ltbProducto.DataSource = _listTemp
            Me.ltbProducto.DisplayMember = "nombreProd"
            Me.ltbProducto.ValueMember = "Codigo"
        Catch ex As Exception
            MsgBox("Error en la operación ... " & ex.Message, MsgBoxStyle.Information, "Registrar Permiso")
        End Try

    End Sub

    ''' <summary>
    ''' Método de clase, encargado de cargar los socios existentes en la DB con el nombre suministado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cargarSocios()
        Try
            Dim _listTemp As New List(Of ClsCastCadenaSocio) 'declarar una variable tipo lista genérica tipo clsCastCadena (Wrapper)
            Dim _tempCast() As String 'declarar una variable tipo arreglo de String

            _listaSocio = _gestor.listarSocios() 'asignar el resultado de la búsqueda devuelto por un método del Gestor

            For i As Integer = 0 To _listaSocio.Count - 1 'estructura iterativa tipo matriz para recorrer y envolver por el tipo adecuado

                _tempArray = _listaSocio(i) 'clonar a un Array temporal la FILA (ROW) de la consulta
                ReDim _tempCast(_tempArray.Length() - 1) 'redimensionar el arreglo a un tamaño indicado

                For j As Integer = 0 To _tempArray.Length - 1 'recorrer la parte interna de la matriz, columna (COLUMN)
                    _tempCast(j) = _tempArray.GetValue(j).ToString() 'asignar el valor de cada celda 
                Next

                _listTemp.Add(New ClsCastCadenaSocio(_tempCast(0).ToString(), _tempCast(1).ToString(), _tempCast(2).ToString(), _tempCast(3).ToString(), _tempCast(4).ToString(), _tempCast(5).ToString(), _tempCast(6).ToString(), _tempCast(7).ToString())) 'agregar a la lista genérica una colección de la clase wrapper

            Next

            Me.dgvDatos.DataSource = _listTemp 'asignar el fuente de dato para un control tipo datagridview la lista genérica wrappeada
            'nombrarColumnas()
            'invisible()
        Catch ex As Exception
            MsgBox("Error en la operación ... " & ex.Message, MsgBoxStyle.Information, "Buscar Socio")
        End Try

    End Sub

    ''' <summary>
    ''' Método de clase, encargado de cargar el socio existente en la DB con el id suministado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub buscarCriterioSocio(ByVal pcriterio As String)
        Try
            Dim _listTemp As New List(Of ClsCastCadenaSocio) 'declarar una variable tipo lista genérica tipo clsCastCadena (Wrapper)
            Dim _tempCast() As String 'declarar una variable tipo arreglo de String

            _listaSocio = _gestor.buscarCriterioSocio(pcriterio) 'asignar el resultado de la búsqueda devuelto por un método del Gestor

            For i As Integer = 0 To _listaSocio.Count - 1 'estructura iterativa tipo matriz para recorrer y envolver por el tipo adecuado

                _tempArray = _listaSocio(i) 'clonar a un Array temporal la FILA (ROW) de la consulta
                ReDim _tempCast(_tempArray.Length() - 1) 'redimensionar el arreglo a un tamaño indicado

                For j As Integer = 0 To _tempArray.Length - 1 'recorrer la parte interna de la matriz, columna (COLUMN)
                    _tempCast(j) = _tempArray.GetValue(j).ToString() 'asignar el valor de cada celda 
                Next
                _listTemp.Add(New ClsCastCadenaSocio(_tempCast(0).ToString(), _tempCast(1).ToString(), _tempCast(2).ToString(), _tempCast(3).ToString(), _tempCast(4).ToString(), _tempCast(5).ToString(), _tempCast(6).ToString(), _tempCast(7).ToString())) 'agregar a la lista genérica una colección de la clase wrapper

            Next
            Me.dgvDatos.DataSource = _listTemp 'asignar el fuente de dato para un control tipo datagridview la lista genérica wrappeada
            nombrarColumnas()
            invisible()
        Catch ex As Exception
            MsgBox("Error en la operación ... " & ex.Message, MsgBoxStyle.Information, "Buscar Socio")
        End Try
    End Sub

    Private Sub pbInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbInsertar.Click
        For Each i In ltbProducto.SelectedIndices
            ltbProductoAsignado.Items.Add(ltbProducto.Items(i))
            ltbProductoAsignado.DisplayMember = "nombreProd"
            ltbProductoAsignado.ValueMember = "Codigo"

            Dim _listTemp As List(Of ClsCastCadenaProducto) = CType(ltbProducto.DataSource, List(Of ClsCastCadenaProducto))
            _listTemp.RemoveAt(i)

            Dim _listTemp2 As New List(Of ClsCastCadenaProducto)
            For x As Integer = 0 To _listTemp.Count - 1
                _listTemp2.Add(_listTemp.Item(x))
            Next

            ltbProducto.DataSource = _listTemp2
            ltbProducto.DisplayMember = "nombreProd"
            ltbProducto.ValueMember = "Codigo"
            ltbProducto.Refresh()

        Next
    End Sub

    Private Sub pbQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbQuitar.Click
        For Each i In ltbProductoAsignado.SelectedIndices

            Dim _listTemp As List(Of ClsCastCadenaProducto) = CType(ltbProducto.DataSource, List(Of ClsCastCadenaProducto))
            _listTemp.Add(ltbProductoAsignado.Items(i))

            Dim _listTemp2 As New List(Of ClsCastCadenaProducto)

            For x As Integer = 0 To _listTemp.Count - 1
                _listTemp2.Add(_listTemp.Item(x))
            Next

            ltbProducto.DataSource = _listTemp2
            ltbProducto.DisplayMember = "nombreProd"
            ltbProducto.ValueMember = "Codigo"

            ltbProductoAsignado.Items.RemoveAt(i)

        Next
    End Sub

    Public Sub obtenerFechaVence(ByVal pfechaCrea As Date)
        Dim _fechaVence As Date

        _fechaVence = pfechaCrea.AddDays(15)
        dtpFechaVence.Value = _fechaVence
    End Sub
    Private Sub limpiar()
        ltbProductoAsignado.Items.Clear()
        dtpFechaCrea.Value = Now
        obtenerFechaVence(dtpFechaCrea.Value)
        cargarProductos()
    End Sub
    ''' <summary>
    ''' Método de clase, encarga de evaluar que no queden espacios en blanco ningún componente
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function evaluarEspacion() As Boolean
        _resul = False
        
        If Me.txtNombre.Text = "" Then
            MsgBox("El nombre del socio es un dato requerido.", MsgBoxStyle.Information, "Registrar Permiso")
            Me.txtNombre.Focus()

        ElseIf Me.txtDireccionFinca.Text = "" Then
            MsgBox("La dirección de la finca del socio es un dato requerido.", MsgBoxStyle.Information, "Registrar Permiso")
            Me.txtDireccionFinca.Focus()

        ElseIf ltbProductoAsignado.Items.Count = 0 Then
            MsgBox("Debe de asignarle un producto al socio", MsgBoxStyle.Information, "Registrar Permiso")

        Else
            _resul = True
        End If

        Return _resul
    End Function
    Private Sub pbLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbLimpiar.Click
        limpiar()
    End Sub

    Private Sub pbRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbRegistrar.Click
        'declarar variables tipo

        Dim _codSocio As String
        Dim _fechaCrea As Date
        Dim _fechaVence As Date
        Dim _codProductos As New ArrayList

        _resul = evaluarEspacion()
        If _resul = True Then
            _codSocio = dgvDatos.SelectedCells(0).Value
            '_codPermiso = 1000
            _codPermiso = _gestor.obtenerMayorIdPermiso() + 1
            _fechaCrea = dtpFechaCrea.Value.Date
            _fechaVence = dtpFechaVence.Value.Date

            For Each producto In ltbProductoAsignado.Items
                _codProductos.Add(CType(producto, ClsCastCadenaProducto).Codigo)
            Next

            Try
                _gestor.registrarPermiso(_codPermiso, _codSocio, _fechaCrea, _fechaVence, _codProductos) 'invocar el método indicado enviando los argumentos requeridos.
                MsgBox("Los datos del permiso se ha registrado correctamente.", MsgBoxStyle.Information, "Registrar Permiso")
                pbImprimir.Enabled = True
            Catch ex As Exception
                MsgBox("Los datos ingresados ya existen en la base de datos." & ex.Message, MsgBoxStyle.Information, "Registrar Permiso")
            End Try
        End If
    End Sub

    Private Sub pbRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbRegresar.Click
        CType(Me.ParentForm, frmCentroAgricola).cargarUserControl(New ctlPrincipal)
    End Sub

    Private Sub dgvDatos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellClick
        txtNombre.Text = dgvDatos.SelectedCells(2).Value
        txtDireccionFinca.Text = dgvDatos.SelectedCells(3).Value
        pbImprimir.Enabled = False
    End Sub

    Public Sub imprimirReporte()
        Try
            Dim report As New PermisoSocioPrueba
            'Dim report As New PermisoSocioPrue
            report.SetParameterValue("codpermiso1", _codPermiso & "")
            report.SetParameterValue("codpermiso2", _codPermiso & "")
            report.PrintToPrinter(1, False, 1, 20)
            report.Refresh()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al tratar de imprimir" & ex.Message)
        End Try
    End Sub

    Private Sub pbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbImprimir.Click
        imprimirReporte()
    End Sub

    Private Sub txtNombreBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreBuscar.TextChanged
        'evaluarProducto()
        If txtNombreBuscar.Text = "" Then
            cargarProductos()
        Else
            buscarProductoPorNombre(Me.txtNombreBuscar.Text)
        End If
    End Sub


    Private Sub evaluarProducto()

        If txtNombreBuscar.Text.Equals("") Then
            cargarProductos()
        Else
            Me.ltbProducto.Items.Clear()
        End If
    End Sub

    ''' <summary>
    ''' Método de clase, encargado de cargar los productos existentes en la DB con el nombre suministado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub buscarProductoPorNombre(ByVal pnombre As String)
        Try
            Dim _listTemp As New List(Of ClsCastCadenaProducto) 'declarar una variable tipo lista genérica tipo clsCastCadena (Wrapper)
            Dim _tempCast() As String 'declarar una variable tipo arreglo de String

            _listaProducto = _gestor.buscarProductoPorNombre(pnombre) 'asignar el resultado de la búsqueda devuelto por un método del Gestor

            For i As Integer = 0 To _listaProducto.Count - 1 'estructura iterativa tipo matriz para recorrer y envolver por el tipo adecuado

                _tempArray = _listaProducto(i) 'clonar a un Array temporal la FILA (ROW) de la consulta
                ReDim _tempCast(_tempArray.Length() - 1) 'redimensionar el arreglo a un tamaño indicado

                For j As Integer = 0 To _tempArray.Length - 1 'recorrer la parte interna de la matriz, columna (COLUMN)
                    _tempCast(j) = _tempArray.GetValue(j).ToString() 'asignar el valor de cada celda 
                Next

                _listTemp.Add(New ClsCastCadenaProducto(_tempCast(0).ToString(), _tempCast(1).ToString(), _tempCast(2).ToString())) 'agregar a la lista genérica una colección de la clase wrapper

            Next

            Me.ltbProducto.DataSource = _listTemp 'asignar el fuente de dato para un control tipo datagridview la lista genérica wrappeada
            Me.ltbProducto.DisplayMember = "nombreProd"
            ltbProducto.ValueMember = "Codigo"
        Catch ex As Exception
            MsgBox("Error en la operación ... " & ex.Message, MsgBoxStyle.Information, "Buscar Producto")
        End Try

    End Sub
End Class
