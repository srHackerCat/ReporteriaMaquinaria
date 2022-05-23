﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorRendimientos.aspx.cs" Inherits="ReporteriaMaquinaria.VisorRendimientos" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true" />
        <Report FileName="Reportes\ReporteR2Maquinaria\REPORTE_RENDIMIENTO.rpt"></Report>
        <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
        </CR:CrystalReportSource>
    </form>
</body>
</html>
