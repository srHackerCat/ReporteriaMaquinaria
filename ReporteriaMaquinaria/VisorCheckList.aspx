﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorCheckList.aspx.cs" Inherits="ReporteriaMaquinaria.VisorCheckList" %>

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
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="Reportes\ReporteR2Maquinaria\RPT_CHECK_LIST.rpt"></Report>
            </CR:CrystalReportSource>
        </div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </form>
</body>
</html>
