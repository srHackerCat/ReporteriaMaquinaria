using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace ReporteriaMaquinaria

{
    public partial class VisorRendimientos : System.Web.UI.Page
    {
        Clase_Control.Clase_Conexion conexion = new Clase_Control.Clase_Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarInformacion();
        }
        private void cargarInformacion()
        {
            ReportDocument reportDocument = new ReportDocument();

            string rutareporte = Server.MapPath(@"Reportes\ReporteR2Maquinaria\RPT_RENDIMIENTOS.rpt");
            this.CrystalReportViewer2.ParameterFieldInfo.Clear();

            reportDocument.Load(rutareporte);


            ParameterValues pValue = new ParameterValues();
            ParameterDiscreteValue pDiscreteValue = new ParameterDiscreteValue();

            pDiscreteValue.Value = Request.QueryString["psMaquinaID"];
            pValue.Add(pDiscreteValue);
            reportDocument.SetParameterValue("@MAQUINAID", pValue);

            ParameterValues pValue2 = new ParameterValues();
            ParameterDiscreteValue pDiscreteValue2 = new ParameterDiscreteValue();

            pDiscreteValue2.Value = Request.QueryString["psFechaIni"];
            pValue2.Add(pDiscreteValue2);
            reportDocument.SetParameterValue("@FECHA_INICIO", pValue2);

            ParameterValues pValue3 = new ParameterValues();
            ParameterDiscreteValue pDiscreteValue3 = new ParameterDiscreteValue();

            pDiscreteValue3.Value = Request.QueryString["psFechaFin"];
            pValue3.Add(pDiscreteValue3);
            reportDocument.SetParameterValue("@FECHA_FIN", pValue3);


            conexion.asignaDatosConeccionCrystal();

            this.CrystalReportViewer2.ReportSource = reportDocument;
            reportDocument.DataSourceConnections[0].SetConnection(conexion.servidor, conexion.base_de_datos, conexion.usuario, conexion.password);
            string rutaPDF = "";
            rutaPDF = pdfcontroller(reportDocument);
            reportDocument.Close();
        }
        public string pdfcontroller(ReportDocument rpd)
        {
            try
            {
                string filepath = "";
                string fileName = "REPORTE_RENDIMIENTO" + Request.QueryString["psMaquinaID"] + Request.QueryString["psFechaIni"] + Request.QueryString["psFechaFin"];
                Console.Out.WriteLine(fileName);
                Response.Clear();
                filepath = Server.MapPath("~/Archivos_Exportados/" + fileName + ".pdf");
                rpd.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filepath);
                Response.AddHeader("Content-Disposition", "inline;filename=" + fileName + ".pdf");
                Response.ContentType = "application/pdf";
                Response.WriteFile(fileInfo.FullName, true);
                return filepath;
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }
    }
} 