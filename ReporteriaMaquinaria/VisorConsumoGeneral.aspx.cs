using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReporteriaMaquinaria
{
    public partial class VisorConsumoGeneral : System.Web.UI.Page
    {
        Clase_Control.Clase_Conexion conexion = new Clase_Control.Clase_Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarInformacion();
        }

        private void cargarInformacion()
        {
            ReportDocument reportDocument = new ReportDocument();

            string rutareporte = Server.MapPath(@"Reportes\ReportesR2Servicios\RPT_CONSUMO_DE_ARTICULO.rpt");
            this.CrystalReportViewer1.ParameterFieldInfo.Clear();

            reportDocument.Load(rutareporte);

            ParameterValues pValues1 = new ParameterValues();
            ParameterDiscreteValue pDiscreteValue = new ParameterDiscreteValue();

            pDiscreteValue.Value = Request.QueryString["psIdArticulo"];
            pValues1.Add(pDiscreteValue);
            reportDocument.SetParameterValue("@ID_ARTICULO", pValues1);

            ParameterValues pValues2 = new ParameterValues();
            ParameterDiscreteValue pDiscreteValue2 = new ParameterDiscreteValue();

            pDiscreteValue2.Value = Request.QueryString["psIdCompania"];
            pValues2.Add(pDiscreteValue2);
            reportDocument.SetParameterValue("@ID_COMPANIA", pValues2);

            ParameterValues pValues3 = new ParameterValues();
            ParameterDiscreteValue pDiscreteValue3 = new ParameterDiscreteValue();

            pDiscreteValue3.Value = Request.QueryString["psFechaIni"];
            pValues3.Add(pDiscreteValue3);
            reportDocument.SetParameterValue("@FECHA_INICIO", pValues3);

            ParameterValues pValues4 = new ParameterValues();
            ParameterDiscreteValue pDiscreteValue4 = new ParameterDiscreteValue();

            pDiscreteValue4.Value = Request.QueryString["psFechaFin"];
            pValues4.Add(pDiscreteValue4);
            reportDocument.SetParameterValue("@FECHA_FIN", pValues4);

            conexion.asignaDatosConeccionCrystal();

            this.CrystalReportViewer1.ReportSource = reportDocument;
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
                string fileName = "RPT_CONTROL_DIA" + Request.QueryString["psIdArticulo"] + Request.QueryString["psIdCompania"] + Request.QueryString["psFechaIni"] + Request.QueryString["psFechaFin"];
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