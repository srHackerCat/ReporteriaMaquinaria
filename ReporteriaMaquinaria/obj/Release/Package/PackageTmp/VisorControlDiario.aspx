<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorControlDiario.aspx.cs" Inherits="ReporteriaMaquinaria.VisorControlDiario" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register namespace="CrystalDecisions.Web" tagprefix="Web" %>

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
        <p>
&nbsp;&nbsp;&nbsp;
        </p>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <report filename="Reportes\REPORTE_CONTROL_DIARIO.rpt">
            </report>
        </CR:CrystalReportSource>
    </form>
</body>
</html>
