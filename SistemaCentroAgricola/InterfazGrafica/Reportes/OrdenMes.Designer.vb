﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrdenMes
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrdenMes))
        Me.txtAnno = New System.Windows.Forms.TextBox
        Me.lblAnno = New System.Windows.Forms.Label
        Me.listadoOrdenesCanceladas = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.pbReporte = New System.Windows.Forms.PictureBox
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.cmbMes = New System.Windows.Forms.ComboBox
        Me.lblMes = New System.Windows.Forms.Label
        Me.help = New System.Windows.Forms.ToolTip(Me.components)
        Me.pbRegresar = New System.Windows.Forms.PictureBox
        CType(Me.pbReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRegresar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAnno
        '
        Me.txtAnno.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnno.Location = New System.Drawing.Point(570, 175)
        Me.txtAnno.Name = "txtAnno"
        Me.txtAnno.Size = New System.Drawing.Size(100, 27)
        Me.txtAnno.TabIndex = 52
        '
        'lblAnno
        '
        Me.lblAnno.AutoSize = True
        Me.lblAnno.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnno.Location = New System.Drawing.Point(526, 180)
        Me.lblAnno.Name = "lblAnno"
        Me.lblAnno.Size = New System.Drawing.Size(38, 19)
        Me.lblAnno.TabIndex = 51
        Me.lblAnno.Text = "Año"
        '
        'listadoOrdenesCanceladas
        '
        Me.listadoOrdenesCanceladas.ActiveViewIndex = -1
        Me.listadoOrdenesCanceladas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listadoOrdenesCanceladas.DisplayGroupTree = False
        Me.listadoOrdenesCanceladas.Location = New System.Drawing.Point(33, 219)
        Me.listadoOrdenesCanceladas.Name = "listadoOrdenesCanceladas"
        Me.listadoOrdenesCanceladas.SelectionFormula = ""
        Me.listadoOrdenesCanceladas.Size = New System.Drawing.Size(975, 448)
        Me.listadoOrdenesCanceladas.TabIndex = 50
        Me.listadoOrdenesCanceladas.ViewTimeSelectionFormula = ""
        '
        'pbReporte
        '
        Me.pbReporte.BackgroundImage = CType(resources.GetObject("pbReporte.BackgroundImage"), System.Drawing.Image)
        Me.pbReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbReporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbReporte.Location = New System.Drawing.Point(686, 169)
        Me.pbReporte.Name = "pbReporte"
        Me.pbReporte.Size = New System.Drawing.Size(30, 30)
        Me.pbReporte.TabIndex = 49
        Me.pbReporte.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(358, 134)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(301, 29)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Listado ordenes mensuales"
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"--SELECCIONAR--", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbMes.Location = New System.Drawing.Point(344, 175)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(163, 27)
        Me.cmbMes.TabIndex = 48
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.Location = New System.Drawing.Point(292, 180)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(36, 19)
        Me.lblMes.TabIndex = 47
        Me.lblMes.Text = "Mes"
        '
        'pbRegresar
        '
        Me.pbRegresar.BackgroundImage = CType(resources.GetObject("pbRegresar.BackgroundImage"), System.Drawing.Image)
        Me.pbRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbRegresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbRegresar.Location = New System.Drawing.Point(978, 133)
        Me.pbRegresar.Name = "pbRegresar"
        Me.pbRegresar.Size = New System.Drawing.Size(30, 30)
        Me.pbRegresar.TabIndex = 53
        Me.pbRegresar.TabStop = False
        Me.help.SetToolTip(Me.pbRegresar, "Regresar")
        '
        'OrdenMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pbRegresar)
        Me.Controls.Add(Me.txtAnno)
        Me.Controls.Add(Me.lblAnno)
        Me.Controls.Add(Me.listadoOrdenesCanceladas)
        Me.Controls.Add(Me.pbReporte)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.lblMes)
        Me.Name = "OrdenMes"
        Me.Size = New System.Drawing.Size(1024, 700)
        CType(Me.pbReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRegresar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAnno As System.Windows.Forms.TextBox
    Friend WithEvents lblAnno As System.Windows.Forms.Label
    Friend WithEvents listadoOrdenesCanceladas As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents pbReporte As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents lblMes As System.Windows.Forms.Label
    Friend WithEvents help As System.Windows.Forms.ToolTip
    Friend WithEvents pbRegresar As System.Windows.Forms.PictureBox

End Class
