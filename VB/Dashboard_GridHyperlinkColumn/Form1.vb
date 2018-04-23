﻿Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.Excel

Namespace Dashboard_GridHyperlinkColumn
    Partial Public Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        Public Sub New()
            InitializeComponent()
            dashboardDesigner1.CreateRibbon()

            Dim dashboard As New Dashboard()

            Dim excelDataSource As New DashboardExcelDataSource("Excel Data Source")
            excelDataSource.FileName = "..\..\Data\GDPByCountry.xlsx"
            excelDataSource.SourceOptions = New ExcelSourceOptions(New ExcelWorksheetSettings("Sheet1"))
            dashboard.DataSources.Add(excelDataSource)

            Dim grid As New GridDashboardItem()
            grid.DataSource = excelDataSource

            ' Creates two hyperlink columns: the first column takes hyperlinks from the underlying data source while the second 
            ' generates links based on the specified URI pattern and data source country names.
            Dim hyperlinkColumn1 As New GridHyperlinkColumn(New Dimension("Uri"), New Dimension("OfficialName"))
            Dim hyperlinkColumn2 As New GridHyperlinkColumn(New Dimension("Name"), New Dimension("OfficialName"))
            hyperlinkColumn2.UriPattern = "https://en.wikipedia.org/wiki/{0}"

            Dim gdpColumn As New GridMeasureColumn(New Measure("GDP"))
            grid.Columns.AddRange(hyperlinkColumn1, hyperlinkColumn2, gdpColumn)
            dashboard.Items.Add(grid)
            dashboardDesigner1.Dashboard = dashboard
        End Sub
    End Class
End Namespace