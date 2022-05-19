using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteriaMaquinaria.Clase_Control
{
    public class Clase_Conexion
    {
        #region "Declarations"
        private string _servidor;
        private string _base_de_datos;
        private string _usuario;
        private string _password;
        #endregion
        #region "Properties"
        public string servidor
        {
            get { return _servidor; }
            set { _servidor = value; }
        }
        public string base_de_datos
        {
            get { return _base_de_datos; }
            set { _base_de_datos = value; }
        }
        public string usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        #endregion

        #region "Functions/Routines"
        public void asignaDatosConeccionCrystal()
        {

            this.servidor = "10.102.1.237";
            this.base_de_datos = "R2_Maquinaria";
            this.usuario = "sap";
            this.password = "12345678";
            //this.password = "12345";
        }
        #endregion

    }
}