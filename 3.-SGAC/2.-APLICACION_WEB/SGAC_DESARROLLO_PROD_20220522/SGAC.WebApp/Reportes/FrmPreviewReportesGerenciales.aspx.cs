﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using SGAC.Accesorios;
using SGAC.WebApp.Accesorios;
using System.IO;
using System.Text;
using System.Drawing;


namespace SGAC.WebApp.Reportes
{
    public partial class FrmPreviewReportesGerenciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            if (Session["vistaPrevia_MRE"] != null)
            {
                if (Session["vistaPrevia_MRE"].ToString() == "1")
                {
                    Session["vistaPrevia_MRE"] = 0;
                    reporte();
                }
            }

            //}
        }


        ReportParameter[] parameters;
        String sNombreOficinaConsular = String.Empty;

        String sNombreDsReporteServices = String.Empty;
        String sNombreDsReporteServices1 = String.Empty;
        String sNombreDsReporteServices2 = String.Empty;
        String sNombreDsReporteServices3 = String.Empty;

        String strRutaBase = String.Empty;

        Int32 iNroDate = 0;
        Int32 iNroDate1 = 0;
        Int32 iNroDate2 = 0;

        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt2 = null;
        DataTable dt3 = null;

        string strFechaActualConsulado = "";
        string strHoraActualConsulado = "";

        private void reporte()
        {
            dt = new DataTable();
            dt1 = new DataTable();
            dt2 = new DataTable();
            dt3 = new DataTable();

            dt = (DataTable)Session["dtDatos"];


            if (Session["IdOficinaConsular_contabilidad"].ToString().Equals("0"))
            {
                sNombreOficinaConsular = "TODOS";
            }
            else
            {
                sNombreOficinaConsular = comun_Part2.ObtenerNombreOficinaPorId(Session, Convert.ToInt32(Session["IdOficinaConsular_contabilidad"]));
                sNombreOficinaConsular = sNombreOficinaConsular.Split('-')[1].ToString().Trim();
            }

            //-----------------------------------------------------
            // Autor: Miguel Márquez Beltrán
            // Fecha: 19/11/2019
            // Objetivo: Consulta de fecha y hora unificada.
            //-----------------------------------------------------


            Comun.ObtenerFechaHoraActualTexto(HttpContext.Current.Session, ref strFechaActualConsulado, ref strHoraActualConsulado);

            strFechaActualConsulado = Comun.FormatearFecha(strFechaActualConsulado).ToString("MMM-dd-yyyy");
            //----------------------------
            //strFechaActualConsulado = Comun.FormatearFecha((Accesorios.Comun.ObtenerFechaActualTexto(HttpContext.Current.Session))).ToString("MMM-dd-yyyy");
            //strHoraActualConsulado = Accesorios.Comun.ObtenerHoraActualTexto(HttpContext.Current.Session);

            //------------------------------------------------------------------------
            // Autor: Miguel Angel Márquez Beltrán
            // Fecha: 02/09/2016
            // Objetivo: Si es consulado mostrar solo la oficina consular
            //------------------------------------------------------------------------
            int intTarifaId = 0;

            if (Session["idtarifa_MRE"] != null)
            {
                intTarifaId = Convert.ToInt32(Session["idtarifa_MRE"].ToString());
                Session["idtarifa_MRE"] = 0;
            }
            //------------------------------------------------------------------------
            string NombreReporte = "";
            NombreReporte = Convert.ToString(Request.QueryString["rep"]);

            string strConCabecera = "";
            strConCabecera = Convert.ToString(Request.QueryString["Head"]);

            if (NombreReporte == null)
            {
                Enumerador.enmReportesGerenciales enmReporte = (Enumerador.enmReportesGerenciales)Session[Constantes.CONST_SESION_REPORTE_TIPO];
                switch (enmReporte)
                {
                    case Enumerador.enmReportesGerenciales.MAYOR_VENTA_Y_DETALLE:
                        #region MayorVentaDetalle
                        VentaDetalle();
                        #endregion
                        break;
                    case Enumerador.enmReportesGerenciales.VENTAS_POR_MES:
                        #region REMESAS
                        VentaMes();
                        #endregion
                        break;
                    case Enumerador.enmReportesGerenciales.TARIFA_CONSULAR_POR_PAIS:
                        #region Estado Bancario
                        TarifaConsularPais();
                        #endregion
                        break;
                    case Enumerador.enmReportesGerenciales.RECORD_DE_ACTUACIONES:
                        #region Estado Bancario
                        recordactuaciones();
                        #endregion
                        break;
                    case Enumerador.enmReportesGerenciales.TOP_14_MAYOR_VENTA_POR_PAIS:
                        #region Estado Bancario
                        MayorVentaPais();
                        #endregion
                        break;
                    case Enumerador.enmReportesGerenciales.RGE_POR_CONTIENENTE:
                        #region Estado Bancario
                        MayorVentaContinente();
                        #endregion
                        break;
                    case Enumerador.enmReportesGerenciales.RGE_POR_CATEGORIA_POR_RECORD_DE_VENTA:
                        #region Estado Bancario
                        CategoriaVenta();
                        #endregion
                        break;

                    case Enumerador.enmReportesGerenciales.RECORD_DE_VENTA:
                        #region Estado Bancario
                        recordVentaUsuario();
                        #endregion
                        break;
                    case Enumerador.enmReportesGerenciales.RGE_POR_CATEGORIA:
                        #region Estado Bancario
                        ReGeCategoria();
                        #endregion
                        break;

                    case Enumerador.enmReportesGerenciales.RGE_CONSOLIDADO:
                        #region Estado Bancario
                        ReGeConsolidado();
                        #endregion
                        break;

                    case Enumerador.enmReportesGerenciales.AUTOADHESIVOS_USUARIO_OFICINA_CONSULAR:
                        #region Estado Bancario
                        rptAutoadhesivosxUsuarioOficinaConsular();
                        #endregion
                        break;

                    case Enumerador.enmReportesGerenciales.ACTUACIONES_USUARIO_OFICINA_CONSULAR:
                        #region Estado Bancario
                        if (intTarifaId == 0)
                        {
                            rptActuacionesxUsuarioOficinaConsular();
                        }
                        else
                        {
                            rptActuacionesxTarifaOficinaConsular();
                        }
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 29/12/2016
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte de personas
                    //------------------------------------------------
                    case Enumerador.enmReportesGerenciales.PERSONAS_USUARIO_OFICINA_CONSULAR:
                        #region Reporte Personas
                        rptPersonasxUsuarioOficinaConsular(strConCabecera);
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 02/01/2017
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte de Cantidad de actuaciones
                    //------------------------------------------------
                    case Enumerador.enmReportesGerenciales.CANTIDAD_ACTUACIONES_CONSULADO:
                        #region Reporte Cantidad Actuaciones
                        rptCantidadActuacionesPorConsulados();
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 02/01/2017
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte de Cantidad de tarifas
                    //------------------------------------------------
                    case Enumerador.enmReportesGerenciales.CANTIDAD_TARIFAS_REGISTRADAS:
                        #region Reporte Cantidad Actuaciones
                        rptCantidadTarifas();
                        #endregion
                        break;


                    //-------------------------------------------------------------------
                    //Fecha: 26/06/2017
                    //Autor: Miguel Márquez Beltrán
                    //Objetivo: Obtiene el consolidado de actuaciones por tipo de pago.
                    //-------------------------------------------------------------------
                    case Enumerador.enmReportesGerenciales.CONSOLIDADO_ACTUACIONES_TIPO_PAGO:

                        rptConsolidadoActuacionesPorTipoPago();

                        break;
                }
            }
            else
            {

                switch (NombreReporte)
                {
                    //------------------------------------------------
                    //Fecha: 11/04/2017
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte de RANKING DE RECAUDACIÓN
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_RANKING_RECAUDACION:
                        #region Reporte Cantidad Actuaciones
                        rptReporteRANKING_RECAUDACION();
                        #endregion
                        break;

                    //------------------------------------------------
                    //Fecha: 12/07/2017
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte de RANKING DE RECAUDACIÓN
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_RANKING_CAPTACION:
                        #region Reporte Ranking Captacion
                        rptReporteRANKING_CAPTACION();
                        #endregion
                        break;

                    //------------------------------------------------
                    //Fecha: 12/07/2017
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte de CUADRO DE AUTOADHESIVOS
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_CUADRO_SALDOS_AUTOADHESIVOS:
                        #region Reporte Cuadro de autoadhesivos
                        rptReporteRANKING_CUADRO_AUTOADHESIVOS();
                        #endregion
                        break;

                    //------------------------------------------------
                    //Fecha: 18/08/2017
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte de CUADRO DE AUTOADHESIVOS UTILIZADOS
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_CUADRO_AUTOADHESIVOS_UTILIZADOS:
                        #region Reporte Cuadro de autoadhesivos utilizados
                        rptReporteRANKING_CUADRO_AUTOADHESIVOS_UTILIZADOS();
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 11/10/2017
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte de CONSOLIDADO_ACTUACIONES_USUARIO
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_CONSOLIDADO_ACTUACIONES_USUARIO:
                        #region Reporte Cuadro de autoadhesivos utilizados
                        rptReporteCONSOLIDADO_ACTUACIONES_USUARIO();
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 11/10/2017
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte de REPORTES_RESUMEN_DIA_ACTUACIONES_USUARIO
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_RESUMEN_DIA_ACTUACIONES_USUARIO:
                        #region Reporte Cuadro de autoadhesivos utilizados
                        rptReporteRESUMEN_DIAS_ACTUACIONES_USUARIO();
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 24/10/2017
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte Itinerantes
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_ITINERANTES:
                        #region Reporte Itinerantes
                        rptReporteITINERANTES();
                        #endregion
                        break;

                    case Constantes.CONST_REPORTES_TITULARES:
                        #region Reporte Titulares
                        rptReporteTITULARES(strConCabecera);
                        #endregion
                        break;


                    //------------------------------------------------
                    //Fecha: 09/01/2019
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte correlativos
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_CORRELATIVOS:
                        #region Reporte Correlativos
                        rptReporteCorrelativos();
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 09/01/2019
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte recaudacion por consulado
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_RECAUDACION_MENSUAL:
                        #region Reporte Recaudacion
                        rptReporteRecaudacionMensual();
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 09/01/2019
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte recaudacion por consulado por mes
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_RECAUDACION_DIARIA:
                        #region Reporte Recaudacion
                        rptReporteRecaudacionDiario();
                        #endregion
                        break;

                    //------------------------------------------------
                    //Fecha: 01/02/2019
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte recaudacion por consulado
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_RECAUDACION_TARIFA:
                        #region Reporte Recaudacion
                        rptReporteRecaudacionTarifa();
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 15/08/2019
                    //Autor: Jonatan Silva Cachay
                    //Objetivo: Lanza el reporte correlativos carga inicial
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_CARGA_INICIAL_CORRELATIVO:
                        #region Reporte Carga Inicial
                        rptReporteCargaInicial();
                        #endregion
                        break;
                    //------------------------------------------------
                    //Fecha: 24/11/2020
                    //Autor: Vidal Pipa
                    //Objetivo: Lanza el reporte ACTUACIONES MENSUALES X CONSULADO
                    //------------------------------------------------
                    case Constantes.CONST_REPORTES_ACTUACIONES_MENSUALES_X_CONSULADO:
                        #region Reporte Actuaciones Mensuales
                        rptReporteActuacionesMensuales();
                        #endregion
                        break;
                }
            }

            dsReport.LocalReport.ReportEmbeddedResource = strRutaBase;
            dsReport.LocalReport.ReportPath = strRutaBase;

            dsReport.LocalReport.DataSources.Clear();

            /*
            if (NombreReporte.Equals(Constantes.CONST_REPORTES_ACTUACIONES_MENSUALES_X_CONSULADO))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 3; j < dt.Columns.Count; j++)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            // Write your Custom Code
                            dt.Rows[i][j] = "0";
                        }
                    }
                }
            }*/
            ReportDataSource datasource = new ReportDataSource(sNombreDsReporteServices, dt);
            ReportDataSource datasource1 = null;
            ReportDataSource datasource2 = null;
            ReportDataSource datasource3 = null;

            if (iNroDate == 1)
            {
                dt1 = (DataTable)Session["dtDatos1"];
                datasource1 = new ReportDataSource(sNombreDsReporteServices1, dt1);
            }

            if (iNroDate1 == 2)
            {
                dt2 = (DataTable)Session["dtDatos2"];
                datasource2 = new ReportDataSource(sNombreDsReporteServices2, dt2);
            }
            if (iNroDate2 == 3)
            {
                dt3 = (DataTable)Session["dtDatos3"];
                datasource3 = new ReportDataSource(sNombreDsReporteServices3, dt3);
            }

            dsReport.LocalReport.SetParameters(parameters);
            dsReport.LocalReport.DataSources.Clear();
            dsReport.LocalReport.DataSources.Add(datasource);


            //==#####################################
            //--Fecha:02/12/2020; Autor: VPipa
            //--   Motivo: mostra informacion de actuaciones mensuales por tarifa, las tarifas se muestra en columnas,
            //--   por lo tanto se requiere que las columnas sean dinámicos
            //---Reporte - Columnas Dinámico          
            //==#####################################
            if (NombreReporte != null && NombreReporte.Equals(Constantes.CONST_REPORTES_ACTUACIONES_MENSUALES_X_CONSULADO))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 3; j < dt.Columns.Count; j++)
                    {
                        if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            // en caso null reemplaza con 0
                            dt.Rows[i][j] = "0";
                        }
                    }
                }
                dsReport.Reset();
                string rangoFechas = "" + HttpContext.Current.Session["rangoFechas"];
                string tipoReporte = "" + HttpContext.Current.Session["actuacionTipoReporte"];//cantidad/monto
                parameters[0] = new ReportParameter("TituloReporte", (tipoReporte == "cantidad" ? "ACTUACIONES MENSUALES POR CONSULADO" : "ACTUACIONES MENSUALES POR RECAUDACIÓN" + "\n(NO INCLUYE LOS PAGOS EN LIMA)") + "\n" + rangoFechas);
                parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
                parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
                parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
                parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
                parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

                ReportBuilder reportBuilder = new ReportBuilder();
                reportBuilder.Page = new ReportPage();
                dsReport.LocalReport.DataSources.Add(new ReportDataSource("dtActuacionesMensuales", dt.DataSet.Tables[0]));
                reportBuilder.DataSource = dt.DataSet;
                dsReport.LocalReport.LoadReportDefinition(ReportEngine.GenerateReport(reportBuilder));
                dsReport.LocalReport.SetParameters(parameters);
                //----exportation Propertie
                dsReport.LocalReport.DisplayName = "ActuacionesMensuales";
                string exportOptionPdf = "PDF";
                string exportOptionWord = "Word";
                RenderingExtension extension = dsReport.LocalReport.ListRenderingExtensions().ToList().Find(x => x.Name.Equals(exportOptionPdf, StringComparison.CurrentCultureIgnoreCase));
                if (extension != null)
                {
                    System.Reflection.FieldInfo fieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    fieldInfo.SetValue(extension, false);
                }
                RenderingExtension extensionw = dsReport.LocalReport.ListRenderingExtensions().ToList().Find(x => x.Name.Equals(exportOptionWord, StringComparison.CurrentCultureIgnoreCase));
                if (extensionw != null)
                {
                    System.Reflection.FieldInfo fieldInfo = extensionw.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    fieldInfo.SetValue(extensionw, false);
                }
            }
            dsReport.LocalReport.Refresh();
            if (iNroDate == 1)
            {
                dsReport.LocalReport.DataSources.Add(datasource1);
            }
            if (iNroDate1 == 2)
            {
                dsReport.LocalReport.DataSources.Add(datasource2);
            }
            if (iNroDate2 == 3)
            {
                dsReport.LocalReport.DataSources.Add(datasource3);
            }
            //-------------------------------
            Session.Remove("dtDatos");
            Session.Remove("dtDatos1");
            Session.Remove("dtDatos2");
            Session.Remove("dtDatos3");
        }



        private void rptAutoadhesivosxUsuarioOficinaConsular()
        {
            iNroDate = 0;
            parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("TituloReporte", "AUTOADHESIVOS POR USUARIO");
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);
            sNombreDsReporteServices = "rsAutoadhesivosUsuario";
            strRutaBase = Server.MapPath("~/Contabilidad/rsAutoAdhesivosUsuarioOficinaConsular.rdlc");
        }

        private void rptActuacionesxUsuarioOficinaConsular()
        {
            iNroDate = 0;
            parameters = new ReportParameter[11];
            parameters[0] = new ReportParameter("TituloReporte", "ACTUACIONES - DETALLE POR USUARIO");
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            string Parametro = Session["ParametrosReporte"].ToString();
            string[] parametros;
            parametros = Parametro.Split('|');

            parameters[7] = new ReportParameter("TipoPago", parametros[0].ToString());
            parameters[8] = new ReportParameter("Usuarios", parametros[1].ToString());
            parameters[9] = new ReportParameter("Tarifa", parametros[2].ToString());
            parameters[10] = new ReportParameter("Clasificacion", parametros[3].ToString());

            sNombreDsReporteServices = "rsActuacionesUsuarioOficinaC";
            strRutaBase = Server.MapPath("~/Contabilidad/rsActuacionesUsuarioOficinaConsular.rdlc");
        }

        private void rptActuacionesxTarifaOficinaConsular()
        {
            iNroDate = 0;
            parameters = new ReportParameter[8];
            parameters[0] = new ReportParameter("TituloReporte", "ACTUACIONES POR TARIFA");
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);
            parameters[7] = new ReportParameter("Clasificacion", Session["Clasificacion"].ToString());

            sNombreDsReporteServices = "rsActuacionesUsuarioOficinaC";
            strRutaBase = Server.MapPath("~/Contabilidad/rsActuacionesTarifaOficinaConsular.rdlc");
        }
        //------------------------------------------------
        //Fecha: 29/12/2016
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena parametros y ruta de reporte de personas
        //------------------------------------------------
        private void rptPersonasxUsuarioOficinaConsular(string strConCabecera = "S")
        {
            iNroDate = 0;
            parameters = new ReportParameter[13];
            parameters[0] = new ReportParameter("TituloReporte", "REPORTE POR NACIONALIDAD: PERUANA - EXTRANJERO");
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);


            string Parametro = Session["ParametrosReporte"].ToString();
            string[] parametros;
            parametros = Parametro.Split('|');

            parameters[7] = new ReportParameter("parEstadoCivil", parametros[0].ToString());
            parameters[8] = new ReportParameter("parCodPostal", parametros[1].ToString());
            parameters[9] = new ReportParameter("parProfesion", parametros[2].ToString());
            parameters[10] = new ReportParameter("parGenero", parametros[3].ToString());
            parameters[11] = new ReportParameter("parOcupacion", parametros[4].ToString());
            parameters[12] = new ReportParameter("ParGradoInstruc", parametros[5].ToString());

            sNombreDsReporteServices = "dsPersonas";

            if (strConCabecera == "S")
            {
                strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsPersonasNacionalidad.rdlc");
            }
            else
            {
                strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsPersonasNacionalidad_NOHEAD.rdlc");
            }
        }
        //------------------------------------------------
        //Fecha: 02/01/2017
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena parametros y ruta de reporte de Cantidadde actuaciones
        //------------------------------------------------
        private void rptCantidadActuacionesPorConsulados()
        {
            iNroDate = 0;
            parameters = new ReportParameter[11];
            parameters[0] = new ReportParameter("TituloReporte", "RANKING DE ACTUACIONES POR CONSULADO");
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);


            string Parametro = Session["ParametrosReporte"].ToString();
            string[] parametros;
            parametros = Parametro.Split('|');

            parameters[7] = new ReportParameter("Usuario", parametros[0].ToString());
            parameters[8] = new ReportParameter("TipoPago", parametros[1].ToString());
            parameters[9] = new ReportParameter("Tarifa", parametros[2].ToString());
            parameters[10] = new ReportParameter("Clasificacion", parametros[3].ToString());

            sNombreDsReporteServices = "dsCanActuaciones";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsCanActuacionesConsulares.rdlc");
        }
        //------------------------------------------------
        //Fecha: 10/04/2017
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena parametros y ruta de reporte de Cantidad Ranking de reacudación
        //------------------------------------------------
        private void rptReporteRANKING_RECAUDACION()
        {
            iNroDate = 0;
            parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_RANKING_RECAUDACION);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dsRankingRecaudacion";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsRankingRecaudacionActuacion.rdlc");
        }
        //------------------------------------------------
        //Fecha: 12/07/2017
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena parametros y ruta de reporte de Cantidad Ranking de Captación
        //------------------------------------------------
        private void rptReporteRANKING_CAPTACION()
        {
            iNroDate = 0;
            parameters = new ReportParameter[8];
            //parameters[0] = new ReportParameter("TituloReporte", "RANKING DE CAPTACIÓN CONSULAR SEGÚN RENDICIÓN DE CUENTAS");
            string pagoDesc = "" + Session["PagoLima"];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_RANKING_CAPTACION);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("AnioConsulta", Session["AnioConsulta"].ToString() + " - " + pagoDesc);
            parameters[6] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[7] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtRankingCaptacion";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsRankingCaptacion.rdlc");
        }

        //------------------------------------------------
        //Fecha: 12/07/2017
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena parametros y ruta de reporte de Cuadro de autoadhesivos
        //------------------------------------------------
        private void rptReporteRANKING_CUADRO_AUTOADHESIVOS()
        {
            iNroDate = 0;
            parameters = new ReportParameter[8];
            //parameters[0] = new ReportParameter("TituloReporte", "CUADRO DE SALDOS DE AUTOADHESIVOS SEGÚN RENDICIÓN DE CUENTAS");
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_CUADRO_SALDOS_AUTOADHESIVOS);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("AnioConsulta", Session["AnioConsulta"].ToString());
            parameters[6] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[7] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtCuadroSaldosAutoadhesivos";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsCuadroSaldosAutoahdesivos.rdlc");
        }

        //------------------------------------------------
        //Fecha: 18/08/2017
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena parametros y ruta de reporte de Cuadro de autoadhesivos utilizados
        //------------------------------------------------
        private void rptReporteRANKING_CUADRO_AUTOADHESIVOS_UTILIZADOS()
        {
            iNroDate = 0;
            parameters = new ReportParameter[8];
            //parameters[0] = new ReportParameter("TituloReporte", "CUADRO DE AUTOADHESIVOS UTILIZADOS SEGÚN RENDICIÓN DE CUENTAS");
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_CUADRO_AUTOADHESIVOS_UTILIZADOS);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("AnioConsulta", Session["AnioConsulta"].ToString());
            parameters[6] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[7] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtCuadroSaldosAutoadhesivos";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsCuadroSaldosAutoahdesivosUtilizados.rdlc");
        }
        //------------------------------------------------
        //Fecha: 11/10/2017
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena parametros y ruta de reporte CONSOLIDADO_ACTUACIONES_USUARIO
        //------------------------------------------------
        private void rptReporteCONSOLIDADO_ACTUACIONES_USUARIO()
        {
            iNroDate = 0;
            parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_CONSOLIDADO_ACTUACIONES_USUARIO);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtActuacionesConsolidadoUsuario";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsConsolidadoActuacionesUsuario.rdlc");
        }

        //------------------------------------------------
        //Fecha: 11/10/2017
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena parametros y ruta de reporte RESUMEN_DIAS_ACTUACIONES_USUARIO
        //------------------------------------------------
        private void rptReporteRESUMEN_DIAS_ACTUACIONES_USUARIO()
        {
            iNroDate = 0;
            parameters = new ReportParameter[11];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_RESUMEN_DIA_ACTUACIONES_USUARIO);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            string Parametro = Session["ParametrosReporte"].ToString();
            string[] parametros;
            parametros = Parametro.Split('|');

            parameters[7] = new ReportParameter("TipoPago", parametros[0].ToString());
            parameters[8] = new ReportParameter("Usuarios", parametros[1].ToString());
            parameters[9] = new ReportParameter("Tarifa", parametros[2].ToString());
            parameters[10] = new ReportParameter("Clasificacion", parametros[3].ToString());
            sNombreDsReporteServices = "dtActuacionesPeriodoUsuario";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsActuacionesUsuarioPeriodo.rdlc");
        }
        //------------------------------------------------
        //Fecha: 02/01/2017
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena parametros y ruta de reporte de Cantidad de tarifas
        //------------------------------------------------
        private void rptCantidadTarifas()
        {
            iNroDate = 0;
            parameters = new ReportParameter[11];
            parameters[0] = new ReportParameter("TituloReporte", "RANKING DE ACTUACIONES POR TARIFA");
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);


            string Parametro = Session["ParametrosReporte"].ToString();
            string[] parametros;
            parametros = Parametro.Split('|');

            parameters[7] = new ReportParameter("Usuario", parametros[0].ToString());
            parameters[8] = new ReportParameter("TipoPago", parametros[1].ToString());
            parameters[9] = new ReportParameter("Tarifa", parametros[2].ToString());
            parameters[10] = new ReportParameter("Clasificacion", parametros[3].ToString());
            sNombreDsReporteServices = "dsCanTarifas";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsCanTarifasRegistradas.rdlc");
        }
        //------------------------------------------------
        //Fecha: 24/10/2017
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena los parametros y ruta de reporte rptReporteITINERANTES
        //------------------------------------------------
        private void rptReporteITINERANTES()
        {
            iNroDate = 0;
            parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_ITINERANTES);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", "REALIZADAS DEL : " + Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtRecaudacionItinerante";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsRecaudacionItinerante.rdlc");
        }

        //------------------------------------------------
        //Fecha: 09/01/2018
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena los parametros y ruta de reporte de Correlativos por Tarifa
        //------------------------------------------------
        private void rptReporteCorrelativos()
        {
            iNroDate = 0;
            parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_CORRELATIVOS);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", "AÑO : " + Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtCorrelativoTarifa";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsReporteCorrelativoTarifa.rdlc");
        }
        //------------------------------------------------
        //Fecha: 09/01/2018
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena los parametros y ruta de reporte de Correlativos por Tarifa
        //------------------------------------------------
        private void rptReporteRecaudacionMensual()
        {
            iNroDate = 0;
            parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_RECAUDACION_MENSUAL);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", "AÑO " + Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtRecaudacion";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsReporteRecaudacionMensualizada.rdlc");
        }
        //------------------------------------------------
        //Fecha: 09/01/2018
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena los parametros y ruta de reporte de Correlativos por Tarifa
        //------------------------------------------------
        private void rptReporteRecaudacionDiario()
        {
            iNroDate = 0;
            parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_RECAUDACION_DIARIA);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtRecaudacionDiario";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsReporteRecaudacionDiario.rdlc");
        }
        //------------------------------------------------
        //Fecha: 01/02/2019
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena los parametros 
        //------------------------------------------------
        private void rptReporteCargaInicial()
        {
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_CARGA_INICIAL_CORRELATIVO);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtCargaInicial";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsReporteCargaInicial.rdlc");
        }
        //################################################
        //Fecha: 24/11/2020
        //Autor: Vidal Pipa
        //Objetivo: Se llena los parametros 
        //################################################
        private void rptReporteActuacionesMensuales()
        {
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_ACTUACIONES_MENSUALES_X_CONSULADO);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtActuacionesMensuales";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsReporteActuacionesMensuales.rdlc");
        }
        //------------------------------------------------
        //Fecha: 01/02/2019
        //Autor: Jonatan Silva Cachay
        //Objetivo: Se llena los parametros y ruta de reporte de Racuadación por Tarifas
        //------------------------------------------------
        private void rptReporteRecaudacionTarifa()
        {
            iNroDate = 0;
            parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("TituloReporte", Constantes.CONST_REPORTES_RECAUDACION_TARIFA);
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", "AÑO " + Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dtRecaudacionTarifa";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsReporteRecaudacionTarifa.rdlc");
        }

        //-------------------------------------------------------------------------------
        // Fecha: 26/09/2018
        // Autor: Miguel Márquez Beltrán
        // Objetivo: Se llena los parametros y la ruta del reporte: rptReporteTitulares
        //-------------------------------------------------------------------------------
        private void rptReporteTITULARES(string strConCabecera = "S")
        {
            iNroDate = 0;
            parameters = new ReportParameter[13];
            parameters[0] = new ReportParameter("TituloReporte", "REPORTE DE LOS TITULARES");
            parameters[1] = new ReportParameter("SubTituloReporte", Constantes.CONST_REPORTE_SUB_TITULO);
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaHaber", "PERIODO: " + Session["FechaIntervalo"].ToString());
            parameters[5] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[6] = new ReportParameter("HoraActual", strHoraActualConsulado);

            string Parametro = Session["ParametrosReporte"].ToString();
            string[] parametros;
            parametros = Parametro.Split('|');

            parameters[7] = new ReportParameter("parEstadoCivil", parametros[0].ToString());
            parameters[8] = new ReportParameter("parCodPostal", parametros[1].ToString());
            parameters[9] = new ReportParameter("parProfesion", parametros[2].ToString());
            parameters[10] = new ReportParameter("parGenero", parametros[3].ToString());
            parameters[11] = new ReportParameter("parOcupacion", parametros[4].ToString());
            parameters[12] = new ReportParameter("ParGradoInstruc", parametros[5].ToString());

            sNombreDsReporteServices = "dsPersonas";

            if (strConCabecera == "S")
            {
                strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsTitulares_HEAD.rdlc");
            }
            else
            {
                strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsTitulares_NOHEAD.rdlc");
            }

        }
        private void VentaDetalle()
        {
            iNroDate = 1;
            string strTitulo = Session["TituloReporte"].ToString();
            parameters = new ReportParameter[6];

            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "MayorVentaOfiConsular";
            sNombreDsReporteServices1 = "MayorVentaDetalle";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsMayorVentaDetalle.rdlc");
        }

        private void VentaMes()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "VentaMes";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsVentaxMes.rdlc");
        }

        private void TarifaConsularPais()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "TarifaConsularPais";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsTarifaConsulaPais.rdlc");
        }

        private void recordactuaciones()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dsRecordActuacion";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsRecordActuacion.rdlc");
        }

        private void MayorVentaPais()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dsMayorVentaPais";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsMayorVentaPais.rdlc");
        }

        private void MayorVentaContinente()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dsReGeContinente";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsReGeContinente.rdlc");
        }

        private void CategoriaVenta()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dsCategoriaVenta";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsCategoriaVenta.rdlc");
        }

        private void recordVentaUsuario()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "dsReportVentaUsuario";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsRecordVentaUsuario.rdlc");
        }

        private void ReGeCategoria()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "ReGeCategoria";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsReGeCategorias.rdlc");
        }

        private void ReGeConsolidado()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);

            sNombreDsReporteServices = "ReGeConsolidado";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsConsolidado.rdlc");
        }

        private void rptConsolidadoActuacionesPorTipoPago()
        {
            string strTitulo = Session["TituloReporte"].ToString();
            iNroDate = 0;
            parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("TituloReporte", strTitulo);
            parameters[1] = new ReportParameter("SubTituloReporte", "REPORTE GERENCIALES");
            parameters[2] = new ReportParameter("NombreOficina", sNombreOficinaConsular);
            parameters[3] = new ReportParameter("UsuarioImpresion", Session[Constantes.CONST_SESION_USUARIO].ToString());
            parameters[4] = new ReportParameter("FechaActual", strFechaActualConsulado);
            parameters[5] = new ReportParameter("HoraActual", strHoraActualConsulado);
            parameters[6] = new ReportParameter("Periodo", Session["FechaIntervalo"].ToString());

            sNombreDsReporteServices = "dtConsolidadoActuacionesTipoPago";
            strRutaBase = Server.MapPath("~/Reportes/RSGerenciales/rsConsolidadoActuacionesPorTipoPago.rdlc");

        }
    }
}





public static class ReportEngine
{
    #region Initialize
    public static Stream GenerateReport(ReportBuilder reportBuilder)
    {
        Stream ret = new MemoryStream(Encoding.UTF8.GetBytes(GetReportData(reportBuilder)));
        return ret;
    }
    static ReportBuilder InitAutoGenerateReport(ReportBuilder reportBuilder)
    {
        if (reportBuilder != null && reportBuilder.DataSource != null && reportBuilder.DataSource.Tables.Count > 0)
        {
            DataSet ds = reportBuilder.DataSource;

            int _TablesCount = ds.Tables.Count;
            ReportTable[] reportTables = new ReportTable[_TablesCount];

            if (reportBuilder.AutoGenerateReport)
            {
                for (int j = 0; j < _TablesCount; j++)
                {
                    DataTable dt = ds.Tables[j];
                    ReportColumns[] columns = new ReportColumns[dt.Columns.Count];
                    ReportScale ColumnScale = new ReportScale();
                    ColumnScale.Width = 4;
                    ColumnScale.Height = 1;
                    ReportDimensions ColumnPadding = new ReportDimensions();
                    ColumnPadding.Default = 2;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        columns[i] = new ReportColumns() { ColumnCell = new ReportTextBoxControl() { Name = dt.Columns[i].ColumnName, Size = ColumnScale, Padding = ColumnPadding }, HeaderText = dt.Columns[i].ColumnName, HeaderColumnPadding = ColumnPadding };
                    }

                    reportTables[j] = new ReportTable() { ReportName = dt.TableName, ReportDataColumns = columns };
                }

            }
            reportBuilder.Body = new ReportBody();
            reportBuilder.Body.ReportControlItems = new ReportItems();
            reportBuilder.Body.ReportControlItems.ReportTable = reportTables;
        }
        return reportBuilder;
    }
    static string getFiels(ReportBuilder reportBuilder, ReportTable table)
    {
        ReportColumns[] columns = table.ReportDataColumns;
        ReportTextBoxControl ColumnCell = new ReportTextBoxControl();
        ReportScale colHeight = ColumnCell.Size;
        string strTextBox = "";
        for (int i = 0; i < columns.Length; i++)
        {
            ColumnCell = columns[i].ColumnCell;
            string name = ColumnCell.Name.ToLower();
            name = name.Replace("-", "_");
            strTextBox += @"<Field Name=""" + name + @""">
                    <DataField>" + name + @"</DataField>
                   <rd:TypeName>System.String</rd:TypeName>
                </Field>";
        }
        return strTextBox;
    }
    static string getTablixColumns(ReportBuilder reportBuilder, ReportTable table)
    {

        ReportColumns[] columns = table.ReportDataColumns;
        string width = "";
        string strTextBox = "";
        for (int i = 1; i < columns.Length; i++)
        {
            if (i < 3) width = "1.1"; else width = "0.25";
            strTextBox += @"<TablixColumn>
                      <Width>" + width + @"in</Width>
                    </TablixColumn> ";

        }
        return strTextBox;
    }
    static string getTablixCellsHead(ReportBuilder reportBuilder, ReportTable table)
    {
        ReportColumns[] columns = table.ReportDataColumns;
        ReportTextBoxControl ColumnCell = new ReportTextBoxControl();
        string strTextBox = "";
        for (int i = 1; i < columns.Length; i++)
        {
            ColumnCell = columns[i].ColumnCell;
            string name = ColumnCell.Name.ToLower();
            name = name.Replace("-", "_");
            strTextBox += @"<TablixCell>
                              <CellContents>
                                <Textbox Name=""head_" + name + @""">
                                  <CanGrow>true</CanGrow>
                                  <KeepTogether>true</KeepTogether>
                                  <Paragraphs>
                                    <Paragraph>
                                      <TextRuns>
                                        <TextRun>
                                          <Value>" + name.Replace("c_", "").ToUpper() + @"</Value>
                                          <Style>
                                            <FontSize>8pt</FontSize>
                                            <FontWeight>Bold</FontWeight>
                                          </Style>
                                        </TextRun>
                                      </TextRuns>
                                      <Style>
                                        <TextAlign>Center</TextAlign>
                                      </Style>
                                    </Paragraph>
                                  </Paragraphs>
                                  <rd:DefaultName>head_" + name + @"</rd:DefaultName>
                                  <Style>
                                    <Border>
                                      <Color>LightGrey</Color>
                                      <Style>Solid</Style>
                                    </Border>
                                    <TopBorder>
                                      <Color>Black</Color>
                                      <Style>Solid</Style>
                                      <Width>1pt</Width>
                                    </TopBorder>
                                    <BottomBorder>
                                      <Color>Black</Color>
                                      <Style>Solid</Style>
                                      <Width>1pt</Width>
                                    </BottomBorder>
                                    <LeftBorder>
                                      <Color>Black</Color>
                                      <Style>Solid</Style>
                                      <Width>1pt</Width>
                                    </LeftBorder>
                                    <RightBorder>
                                      <Color>Black</Color>
                                      <Style>Solid</Style>
                                      <Width>1pt</Width>
                                    </RightBorder>
                                    <BackgroundColor>LightGrey</BackgroundColor>
                                    <VerticalAlign>Middle</VerticalAlign>
                                    <PaddingLeft>2pt</PaddingLeft>
                                    <PaddingRight>2pt</PaddingRight>
                                    <PaddingTop>2pt</PaddingTop>
                                    <PaddingBottom>2pt</PaddingBottom>
                                  </Style>
                                </Textbox>
                              </CellContents>
                            </TablixCell>";

        }
        return strTextBox;
    }
    static string getTablixCellsBody(ReportBuilder reportBuilder, ReportTable table)
    {
        ReportColumns[] columns = table.ReportDataColumns;
        ReportTextBoxControl ColumnCell = new ReportTextBoxControl();
        string strTextBox = "";
        string tipoReporte = "" + HttpContext.Current.Session["actuacionTipoReporte"];//cantidad/monto
        string formato = "";
        for (int i = 1; i < columns.Length; i++)
        {
            ColumnCell = columns[i].ColumnCell;
            string name = ColumnCell.Name.ToLower();
            name = name.Replace("-", "_");
            if (i > 2 && tipoReporte == "monto") formato = "<Format>#,0.00;(#,0.00)</Format>";
            strTextBox += @"<TablixCell>
                              <CellContents>
                                <Textbox Name=""" + name + @""">
                                  <CanGrow>true</CanGrow>
                                  <KeepTogether>true</KeepTogether>
                                  <Paragraphs>
                                    <Paragraph>
                                      <TextRuns>
                                        <TextRun>
                                          <Value>=Fields!" + name + @".Value</Value>
                                          <Style>
                                            <FontSize>7pt</FontSize>
                                            " + formato + @"
                                          </Style>
                                        </TextRun>
                                      </TextRuns>
                                      <Style />
                                    </Paragraph>
                                  </Paragraphs>
                                  <rd:DefaultName>" + name + @"</rd:DefaultName>
                                  <Style>
                                    <Border>
                                      <Color>LightGrey</Color>
                                      <Style>Solid</Style>
                                    </Border>
                                    <PaddingLeft>2pt</PaddingLeft>
                                    <PaddingRight>2pt</PaddingRight>
                                    <PaddingTop>2pt</PaddingTop>
                                    <PaddingBottom>2pt</PaddingBottom>
                                  </Style>
                                </Textbox>
                              </CellContents>
                            </TablixCell>";

        }
        return strTextBox;
    }
    static string getTablixCellsSummary(ReportBuilder reportBuilder, ReportTable table)
    {
        ReportColumns[] columns = table.ReportDataColumns;
        ReportTextBoxControl ColumnCell = new ReportTextBoxControl();
        string strTextBox = "";
        string tipoReporte = "" + HttpContext.Current.Session["actuacionTipoReporte"];//cantidad/monto
        string formato = "";
        for (int i = 3; i < columns.Length; i++)
        {
            ColumnCell = columns[i].ColumnCell;
            string name = ColumnCell.Name.ToLower();
            name = name.Replace("-", "_");
            if (tipoReporte == "monto") formato = "<Format>#,0.00;(#,0.00)</Format>";
            strTextBox += @"<TablixCell>
                            <CellContents>
                            <Textbox Name=""summ_" + name + @""">
                                <CanGrow>true</CanGrow>
                                <KeepTogether>true</KeepTogether>
                                <Paragraphs>
                                <Paragraph>
                                    <TextRuns>
                                    <TextRun>
                                        <Value>=Sum(Fields!" + name + @".Value)</Value>
                                        <Style>
                                        <FontSize>8pt</FontSize>
                                        <FontWeight>Bold</FontWeight>
                                        " + formato + @"
                                        </Style>
                                    </TextRun>
                                    </TextRuns>
                                    <Style>
                                    <TextAlign>Center</TextAlign>
                                    </Style>
                                </Paragraph>
                                </Paragraphs>
                                <rd:DefaultName>summ_" + name + @"</rd:DefaultName>
                                <Style>
                                <Border>
                                    <Style>Solid</Style>
                                </Border>
                                <TopBorder>
                                    <Width>1.5pt</Width>
                                </TopBorder>
                                <VerticalAlign>Middle</VerticalAlign>
                                <PaddingLeft>2pt</PaddingLeft>
                                <PaddingRight>2pt</PaddingRight>
                                <PaddingTop>2pt</PaddingTop>
                                <PaddingBottom>2pt</PaddingBottom>
                                </Style>
                            </Textbox>
                            <rd:Selected>true</rd:Selected>
                            </CellContents>
                        </TablixCell> ";

        }
        //System.Diagnostics.Debug.Write("getTablixCellsSummary___"+strTextBox);
        return strTextBox;
    }
    static string getTablixMembers(ReportBuilder reportBuilder, ReportTable table)
    {
        ReportColumns[] columns = table.ReportDataColumns;
        string strTextBox = "";
        for (int i = 1; i < columns.Length; i++)
        {
            strTextBox += " <TablixMember />";

        }
        System.Diagnostics.Debug.Write("getTablixMembers___" + strTextBox);
        return strTextBox;
    }
    //---------------------------------
    static string GetReportData(ReportBuilder reportBuilder)
    {
        reportBuilder = InitAutoGenerateReport(reportBuilder);
        ReportTable table = table = reportBuilder.Body.ReportControlItems.ReportTable[0];
        string rdlcXML = "";
        rdlcXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
            <Report xmlns:rd=""http://schemas.microsoft.com/SQLServer/reporting/reportdesigner"" xmlns=""http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition"">
              <DataSources>
                <DataSource Name=""dsActuacionesMensuales"">
                  <ConnectionProperties>
                    <DataProvider>System.Data.DataSet</DataProvider>
                    <ConnectString>/* Local Connection */</ConnectString>
                  </ConnectionProperties>
                  <rd:DataSourceID>b65e5952-2e99-4d9f-8b54-1aba3355c3c3</rd:DataSourceID>
                </DataSource>
              </DataSources>
              <DataSets>
                <DataSet Name=""dtActuacionesMensuales"">
                    <Fields>
                    " + getFiels(reportBuilder, table) + @"
                    </Fields>
                  <Query>
                    <DataSourceName>dsActuacionesMensuales</DataSourceName>
                    <CommandText>/* Local Query */</CommandText>
                  </Query>
                  <rd:DataSetInfo>
                    <rd:DataSetName>dsActuacioneMensuales</rd:DataSetName>
                    <rd:SchemaPath>D:\FuentesCS\SGAC_DESARROLLO_PROD\SGAC.WebApp\Reportes\dsActuacioneMensuales.xsd</rd:SchemaPath>
                    <rd:TableName>dtActuacionMensual</rd:TableName>
                    <rd:TableAdapterFillMethod />
                    <rd:TableAdapterGetDataMethod />
                    <rd:TableAdapterName />
                  </rd:DataSetInfo>
                </DataSet>
              </DataSets>
              <Body>
                <ReportItems>
                  <Tablix Name=""Tablix1"">
                    <TablixBody>
                      <TablixColumns>
                        " + getTablixColumns(reportBuilder, table) + @"
                      </TablixColumns>
                      <TablixRows>
                        <TablixRow>
                          <Height>0.34039in</Height>
                          <TablixCells>
                            " + getTablixCellsHead(reportBuilder, table) + @"
                          </TablixCells>
                        </TablixRow>
                        <TablixRow>
                          <Height>0.23622in</Height>
                          <TablixCells>
                            " + getTablixCellsBody(reportBuilder, table) + @"
                          </TablixCells>
                        </TablixRow>
                        <TablixRow>
                          <Height>0.24664in</Height>
                          <TablixCells>
                            <TablixCell>
                              <CellContents>
                                <Textbox Name=""Textbox313"">
                                  <CanGrow>true</CanGrow>
                                  <KeepTogether>true</KeepTogether>
                                  <Paragraphs>
                                    <Paragraph>
                                      <TextRuns>
                                        <TextRun>
                                          <Value>TOTAL</Value>
                                          <Style>
                                            <FontSize>7pt</FontSize>
                                            <FontWeight>Bold</FontWeight>
                                          </Style>
                                        </TextRun>
                                      </TextRuns>
                                      <Style>
                                        <TextAlign>Right</TextAlign>
                                      </Style>
                                    </Paragraph>
                                  </Paragraphs>
                                  <rd:DefaultName>Textbox313</rd:DefaultName>
                                  <Style>
                                    <Border>
                                      <Color>LightGrey</Color>
                                      <Style>Solid</Style>
                                    </Border>
                                    <TopBorder>
                                      <Color>Black</Color>
                                      <Style>Solid</Style>
                                      <Width>1.5pt</Width>
                                    </TopBorder>
                                    <BottomBorder>
                                      <Color>Black</Color>
                                      <Style>Solid</Style>
                                      <Width>1pt</Width>
                                    </BottomBorder>
                                    <LeftBorder>
                                      <Color>Black</Color>
                                      <Style>Solid</Style>
                                      <Width>1pt</Width>
                                    </LeftBorder>
                                    <VerticalAlign>Middle</VerticalAlign>
                                    <PaddingLeft>2pt</PaddingLeft>
                                    <PaddingRight>2pt</PaddingRight>
                                    <PaddingTop>2pt</PaddingTop>
                                    <PaddingBottom>2pt</PaddingBottom>
                                  </Style>
                                </Textbox>
                                <ColSpan>2</ColSpan>
                              </CellContents>
                            </TablixCell>
                            <TablixCell />
                            " + getTablixCellsSummary(reportBuilder, table) + @"
                          </TablixCells>
                        </TablixRow>
                      </TablixRows>
                    </TablixBody>
                    <TablixColumnHierarchy>
                      <TablixMembers>
                        " + getTablixMembers(reportBuilder, table) + @"
                      </TablixMembers>
                    </TablixColumnHierarchy>
                    <TablixRowHierarchy>
                      <TablixMembers>
                        <TablixMember>
                          <TablixHeader>
                            <Size>0.98425in</Size>
                            <CellContents>
                              <Textbox Name=""Textbox146"">
                                <CanGrow>true</CanGrow>
                                <KeepTogether>true</KeepTogether>
                                <Paragraphs>
                                  <Paragraph>
                                    <TextRuns>
                                      <TextRun>
                                        <Value>PAÍS</Value>
                                        <Style>
                                          <FontSize>8pt</FontSize>
                                          <FontWeight>Bold</FontWeight>
                                        </Style>
                                      </TextRun>
                                    </TextRuns>
                                    <Style />
                                  </Paragraph>
                                </Paragraphs>
                                <rd:DefaultName>Textbox146</rd:DefaultName>
                                <Style>
                                  <Border>
                                    <Color>LightGrey</Color>
                                    <Style>Solid</Style>
                                  </Border>
                                  <TopBorder>
                                    <Color>Black</Color>
                                    <Style>Solid</Style>
                                    <Width>1pt</Width>
                                  </TopBorder>
                                  <BottomBorder>
                                    <Color>Black</Color>
                                    <Style>Solid</Style>
                                    <Width>1pt</Width>
                                  </BottomBorder>
                                  <LeftBorder>
                                    <Color>Black</Color>
                                    <Style>Solid</Style>
                                    <Width>1pt</Width>
                                  </LeftBorder>
                                  <RightBorder>
                                    <Color>Black</Color>
                                    <Style>Solid</Style>
                                    <Width>1pt</Width>
                                  </RightBorder>
                                  <BackgroundColor>LightGrey</BackgroundColor>
                                  <VerticalAlign>Middle</VerticalAlign>
                                  <PaddingLeft>2pt</PaddingLeft>
                                  <PaddingRight>2pt</PaddingRight>
                                  <PaddingTop>2pt</PaddingTop>
                                  <PaddingBottom>2pt</PaddingBottom>
                                </Style>
                              </Textbox>
                            </CellContents>
                          </TablixHeader>
                          <TablixMembers>
                            <TablixMember />
                          </TablixMembers>
                        </TablixMember>
                        <TablixMember>
                          <Group Name=""Group1"">
                            <GroupExpressions>
                              <GroupExpression>=Fields!vnompais.Value</GroupExpression>
                            </GroupExpressions>
                          </Group>
                          <SortExpressions>
                            <SortExpression>
                              <Value>=Fields!vnompais.Value</Value>
                            </SortExpression>
                          </SortExpressions>
                          <TablixHeader>
                            <Size>0.98425in</Size>
                            <CellContents>
                              <Textbox Name=""Group1"">
                                <CanGrow>true</CanGrow>
                                <KeepTogether>true</KeepTogether>
                                <Paragraphs>
                                  <Paragraph>
                                    <TextRuns>
                                      <TextRun>
                                        <Value>=Fields!vnompais.Value</Value>
                                        <Style>
                                          <FontSize>7pt</FontSize>
                                        </Style>
                                      </TextRun>
                                    </TextRuns>
                                    <Style />
                                  </Paragraph>
                                </Paragraphs>
                                <rd:DefaultName>Group1</rd:DefaultName>
                                <Style>
                                  <Border>
                                    <Color>LightGrey</Color>
                                    <Style>Solid</Style>
                                  </Border>
                                  <PaddingLeft>2pt</PaddingLeft>
                                  <PaddingRight>2pt</PaddingRight>
                                  <PaddingTop>2pt</PaddingTop>
                                  <PaddingBottom>2pt</PaddingBottom>
                                </Style>
                              </Textbox>
                            </CellContents>
                          </TablixHeader>
                          <TablixMembers>
                            <TablixMember>
                              <Group Name=""Details"" />
                            </TablixMember>
                          </TablixMembers>
                        </TablixMember>
                        <TablixMember>
                          <TablixHeader>
                            <Size>0.98425in</Size>
                            <CellContents>
                              <Textbox Name=""Textbox312"">
                                <CanGrow>true</CanGrow>
                                <KeepTogether>true</KeepTogether>
                                <Paragraphs>
                                  <Paragraph>
                                    <TextRuns>
                                      <TextRun>
                                        <Value />
                                        <Style>
                                          <FontSize>7pt</FontSize>
                                          <FontWeight>Bold</FontWeight>
                                        </Style>
                                      </TextRun>
                                    </TextRuns>
                                    <Style />
                                  </Paragraph>
                                </Paragraphs>
                                <rd:DefaultName>Textbox312</rd:DefaultName>
                                <Style>
                                  <Border>
                                    <Color>LightGrey</Color>
                                    <Style>Solid</Style>
                                  </Border>
                                  <TopBorder>
                                    <Color>Black</Color>
                                    <Style>Solid</Style>
                                    <Width>1.5pt</Width>
                                  </TopBorder>
                                  <BottomBorder>
                                    <Color>Black</Color>
                                    <Style>Solid</Style>
                                    <Width>1pt</Width>
                                  </BottomBorder>
                                  <LeftBorder>
                                    <Color>Black</Color>
                                    <Style>Solid</Style>
                                    <Width>1pt</Width>
                                  </LeftBorder>
                                  <PaddingLeft>2pt</PaddingLeft>
                                  <PaddingRight>2pt</PaddingRight>
                                  <PaddingTop>2pt</PaddingTop>
                                  <PaddingBottom>2pt</PaddingBottom>
                                </Style>
                              </Textbox>
                            </CellContents>
                          </TablixHeader>
                          <KeepWithGroup>Before</KeepWithGroup>
                        </TablixMember>
                      </TablixMembers>
                    </TablixRowHierarchy>
                    <DataSetName>dtActuacionesMensuales</DataSetName>
                    <Top>0.85521cm</Top>
                    <Left>0.00568cm</Left>
                    <Height>2.09105cm</Height>
                    <Width>45.84243cm</Width>
                    <Style>
                      <Border>
                        <Style>None</Style>
                      </Border>
                    </Style>
                  </Tablix>
                </ReportItems>
                <Height>1.17036in</Height>
                <Style />
              </Body>
              <ReportParameters> 
                <ReportParameter Name=""TituloReporte"">
                  <DataType>String</DataType>
                  <Prompt>ReportParameter1</Prompt>
                </ReportParameter>
                <ReportParameter Name=""SubTituloReporte"">
                  <DataType>String</DataType>
                  <Prompt>ReportParameter1</Prompt>
                </ReportParameter>
                <ReportParameter Name=""NombreOficina"">
                  <DataType>String</DataType>
                  <Prompt>ReportParameter1</Prompt>
                </ReportParameter>
                <ReportParameter Name=""UsuarioImpresion"">
                  <DataType>String</DataType>
                  <Prompt>ReportParameter1</Prompt>
                </ReportParameter>
                <ReportParameter Name=""FechaActual"">
                  <DataType>String</DataType>
                  <Prompt>ReportParameter1</Prompt>
                </ReportParameter>
                <ReportParameter Name=""HoraActual"">
                  <DataType>String</DataType>
                  <Prompt>ReportParameter1</Prompt>
                </ReportParameter>
              </ReportParameters>
              <Width>19.75857in</Width>
              <Page>
                <PageHeader>
                  <Height>4.32216cm</Height>
                  <PrintOnFirstPage>true</PrintOnFirstPage>
                  <PrintOnLastPage>true</PrintOnLastPage>
                  <ReportItems>
                    <Textbox Name=""SubTituloReporte"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>=Parameters!SubTituloReporte.Value</Value>
                              <Style>
                                <FontSize>8pt</FontSize>
                                <FontWeight>Bold</FontWeight>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style>
                            <TextAlign>Center</TextAlign>
                          </Style>
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>SubTituloReporte</rd:DefaultName>
                      <Top>2.39388cm</Top>
                      <Height>0.43292cm</Height>
                      <Width>15.88523cm</Width>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""TituloReporte"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>=Parameters!TituloReporte.Value</Value>
                              <Style>
                                <FontSize>8pt</FontSize>
                                <FontWeight>Bold</FontWeight>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style>
                            <TextAlign>Center</TextAlign>
                          </Style>
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>TituloReporte</rd:DefaultName>
                      <Top>2.89736cm</Top>
                      <Height>0.52062cm</Height>
                      <Width>15.88523cm</Width>
                      <ZIndex>1</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Image Name=""Image2"">
                      <Source>Embedded</Source>
                      <Value>img_reporte_logo</Value>
                      <Left>0.06007cm</Left>
                      <Height>1.66688cm</Height>
                      <Width>7.64646cm</Width>
                      <ZIndex>2</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                      </Style>
                    </Image>
                    <Textbox Name=""NombreOficina"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>=Parameters!NombreOficina.Value</Value>
                              <Style>
                                <FontSize>7.5pt</FontSize>
                                <FontWeight>Bold</FontWeight>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style>
                            <TextAlign>Left</TextAlign>
                          </Style>
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>NombreOficina</rd:DefaultName>
                      <Top>1.79388cm</Top>
                      <Left>0.05337cm</Left>
                      <Height>0.49417cm</Height>
                      <Width>12.72032cm</Width>
                      <ZIndex>3</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                  </ReportItems>
                  <Style>
                    <Border>
                      <Style>None</Style>
                    </Border>
                  </Style>
                </PageHeader>
                <PageFooter>
                  <Height>1.32292cm</Height>
                  <PrintOnFirstPage>true</PrintOnFirstPage>
                  <PrintOnLastPage>true</PrintOnLastPage>
                  <ReportItems>
                    <Textbox Name=""PageNumber"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>=Globals!PageNumber</Value>
                              <Style>
                                <FontSize>8pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style>
                            <TextAlign>Right</TextAlign>
                          </Style>
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>PageNumber</rd:DefaultName>
                      <Top>0.17638cm</Top>
                      <Left>7.3605cm</Left>
                      <Height>0.38cm</Height>
                      <Width>0.63817cm</Width>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <VerticalAlign>Middle</VerticalAlign>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""Textbox27"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>Usuario de Impresión:</Value>
                              <Style>
                                <FontSize>8pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style />
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>Textbox24</rd:DefaultName>
                      <Top>0.17638cm</Top>
                      <Left>10.03321cm</Left>
                      <Height>0.38cm</Height>
                      <Width>2.91924cm</Width>
                      <ZIndex>1</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""UsuarioImpresion"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>=Parameters!UsuarioImpresion.Value</Value>
                              <Style>
                                <FontSize>8pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style />
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>UsuarioImpresion</rd:DefaultName>
                      <Top>0.17638cm</Top>
                      <Left>12.95244cm</Left>
                      <Height>0.38cm</Height>
                      <Width>2.67061cm</Width>
                      <ZIndex>2</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""Textbox521"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>Página:</Value>
                              <Style>
                                <FontSize>8pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style>
                            <TextAlign>Center</TextAlign>
                          </Style>
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>Textbox521</rd:DefaultName>
                      <Top>0.17638cm</Top>
                      <Left>6.1707cm</Left>
                      <Height>0.38cm</Height>
                      <Width>1.09771cm</Width>
                      <ZIndex>3</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <VerticalAlign>Middle</VerticalAlign>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""Textbox522"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>De :</Value>
                              <Style>
                                <FontSize>8pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style>
                            <TextAlign>Center</TextAlign>
                          </Style>
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>Textbox521</rd:DefaultName>
                      <Top>0.17638cm</Top>
                      <Left>8.06569cm</Left>
                      <Height>0.38cm</Height>
                      <Width>0.62146cm</Width>
                      <ZIndex>4</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <VerticalAlign>Middle</VerticalAlign>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""TotalPages"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>=Globals!TotalPages</Value>
                              <Style>
                                <FontSize>8pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style>
                            <TextAlign>Left</TextAlign>
                          </Style>
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>TotalPages</rd:DefaultName>
                      <Top>0.17638cm</Top>
                      <Left>8.68715cm</Left>
                      <Height>0.38cm</Height>
                      <Width>1.05181cm</Width>
                      <ZIndex>5</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <VerticalAlign>Middle</VerticalAlign>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""Textbox25"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>Fecha de Impresión:</Value>
                              <Style>
                                <FontSize>7pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style />
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>Textbox24</rd:DefaultName>
                      <Top>0.17638cm</Top>
                      <Height>0.38cm</Height>
                      <Width>2.76049cm</Width>
                      <ZIndex>6</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""Textbox28"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>Hora de Impresión:</Value>
                              <Style>
                                <FontSize>7pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style />
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>Textbox24</rd:DefaultName>
                      <Top>0.65213cm</Top>
                      <Height>0.38cm</Height>
                      <Width>2.76049cm</Width>
                      <ZIndex>7</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <PaddingLeft>1pt</PaddingLeft>
                        <PaddingRight>1pt</PaddingRight>
                        <PaddingTop>1pt</PaddingTop>
                        <PaddingBottom>1pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""FechaActual"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>=Parameters!FechaActual.Value</Value>
                              <Style>
                                <FontSize>6pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style>
                            <TextAlign>Right</TextAlign>
                          </Style>
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>FechaActual</rd:DefaultName>
                      <Top>0.18646cm</Top>
                      <Left>2.76049cm</Left>
                      <Height>0.38cm</Height>
                      <Width>1.67979cm</Width>
                      <ZIndex>8</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>2pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                    </Textbox>
                    <Textbox Name=""HoraActual"">
                      <CanGrow>true</CanGrow>
                      <KeepTogether>true</KeepTogether>
                      <Paragraphs>
                        <Paragraph>
                          <TextRuns>
                            <TextRun>
                              <Value>=Parameters!HoraActual.Value</Value>
                              <Style>
                                <FontSize>6pt</FontSize>
                              </Style>
                            </TextRun>
                          </TextRuns>
                          <Style>
                            <TextAlign>Right</TextAlign>
                          </Style>
                        </Paragraph>
                      </Paragraphs>
                      <rd:DefaultName>HoraActual</rd:DefaultName>
                      <Top>0.60173cm</Top>
                      <Left>2.76049cm</Left>
                      <Height>0.38cm</Height>
                      <Width>1.67979cm</Width>
                      <ZIndex>9</ZIndex>
                      <Style>
                        <Border>
                          <Style>None</Style>
                        </Border>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>2pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                    </Textbox>
                  </ReportItems>
                  <Style>
                    <Border>
                      <Style>None</Style>
                    </Border>
                  </Style>
                </PageFooter>
                <PageHeight>29.7cm</PageHeight>
                <PageWidth>21cm</PageWidth>
                <LeftMargin>2cm</LeftMargin>
                <RightMargin>2cm</RightMargin>
                <TopMargin>2cm</TopMargin>
                <BottomMargin>2cm</BottomMargin>
                <ColumnSpacing>0.13cm</ColumnSpacing>
                <Style />
              </Page>
              <EmbeddedImages>
                <EmbeddedImage Name=""img_reporte_logo"">
                  <MIMEType>image/png</MIMEType>
                  <ImageData>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</ImageData>
                </EmbeddedImage>
              </EmbeddedImages>
              <rd:ReportID>41e2cb07-572a-4ab2-94df-e84788d59fda</rd:ReportID>
              <rd:ReportUnitType>Cm</rd:ReportUnitType>
            </Report>

            ";
        System.Diagnostics.Debug.Write("rdlcXML___" + rdlcXML);
        return rdlcXML;
    }
    #endregion


}


public static class ReportGlobalParameters
{
    public static string CurrentPageNumber = "=Globals!PageNumber";
    public static string TotalPages = "=Globals!OverallTotalPages";
}
public class ReportBuilder
{
    public ReportPage Page { get; set; }
    public ReportBody Body { get; set; }
    public DataSet DataSource { get; set; }

    private bool autoGenerateReport = true;
    public bool AutoGenerateReport
    {
        get { return autoGenerateReport; }
        set { autoGenerateReport = value; }
    }

}
public class ReportItems
{
    public ReportTextBoxControl[] TextBoxControls { get; set; }
    public ReportTable[] ReportTable { get; set; }
    public ReportImage[] ReportImages { get; set; }
}
public class ReportTable
{
    public string ReportName { get; set; }
    public ReportColumns[] ReportDataColumns { get; set; }
}
public class ReportColumns
{
    public bool isGroupedColumn { get; set; }
    public string HeaderText { get; set; }
    public ReportSort SortDirection { get; set; }
    public ReportFunctions Aggregate { get; set; }
    public ReportTextBoxControl ColumnCell { get; set; }
    public ReportDimensions HeaderColumnPadding { get; set; }
}
public class ReportTextBoxControl
{
    public string Name { get; set; }
    public string[] ValueOrExpression { get; set; }
    public ReportActions Action { get; set; }
    public ReportDimensions Padding { get; set; }
    public int SpaceAfter { get; set; }
    public int SpaceBefore { get; set; }

    private ReportHorizantalAlign textAlign = ReportHorizantalAlign.Default;
    public ReportHorizantalAlign TextAlign
    {
        get { return textAlign; }
        set { textAlign = value; }
    }

    private ReportHorizantalAlign verticalAlign = ReportHorizantalAlign.Default;
    public ReportHorizantalAlign VerticalAlign
    {
        get { return verticalAlign; }
        set { verticalAlign = value; }
    }
    public ReportStyles BorderStyle { get; set; }
    public ReportColor BorderColor { get; set; }
    public ReportScale BorderWidth { get; set; }
    public Color BackgroundColor { get; set; }
    public ReportImage BackgroundImage { get; set; }
    public Font TextFont { get; set; }
    public double LineHeight { get; set; }
    public bool CanGrow { get; set; }
    public bool CanShrink { get; set; }
    public bool ToolTip { get; set; }
    public ReportDimensions Position { get; set; }
    public ReportScale Size { get; set; }
    public bool Visible { get; set; }
}
public class ReportBody
{
    public ReportSections ReportBodySection { get; set; }
    public ReportItems ReportControlItems { get; set; }
}
public class ReportPage
{
    public bool AutoRefresh { get; set; }
    public Color BackgroundColor { get; set; }
    public ReportImage BackgroundImage { get; set; }
    public ReportColor BorderColor { get; set; }
    public ReportScale BorderWidth { get; set; }
    public ReportColumnSettings Columns { get; set; }
    public ReportScale InteractiveSize { get; set; }
    public ReportDimensions Margins { get; set; }
    public ReportScale PageSize { get; set; }
    public ReportSections ReportHeader { get; set; }
    public ReportSections ReportFooter { get; set; }
}
public class ReportSections
{
    public ReportStyles BorderStyle { get; set; }
    public ReportColor BorderColor { get; set; }
    public ReportScale BorderWidth { get; set; }
    public Color BackgroundColor { get; set; }
    public ReportImage BackgroundImage { get; set; }
    public ReportScale Size { get; set; }

    private bool printOnFirstPage = true;

    public bool PrintOnFirstPage
    {
        get { return printOnFirstPage; }
        set { printOnFirstPage = value; }
    }

    private bool printOnLastpage = true;

    public bool PrintOnLastPage
    {
        get { return printOnLastpage; }
        set { printOnLastpage = value; }
    }

    public ReportItems ReportControlItems { get; set; }
}
public class ReportColumnSettings
{
    public int Columns { get; set; }
    public int ColumnsSpacing { get; set; }
}
public class ReportActions
{
    public ReportActionType ActionType { get; set; }
    public string ValueOrExpression { get; set; }
}
public class ReportDimensions
{
    public double Left { get; set; }
    public double Right { get; set; }
    public double Top { get; set; }
    public double Bottom { get; set; }
    private double _default = 2;

    public double Default
    {
        get { return _default; }
        set { _default = value; }
    }

}
public class ReportIndent
{
    public double HangingIndent { get; set; }
    public double LeftIndent { get; set; }
    public double RightIndent { get; set; }
}
public class ReportScale
{
    public double Height { get; set; }
    public double Width { get; set; }
}
public class ReportImage
{
    public ReportImageSource ImagePath { get; set; }
    public string ValueOrExpression { get; set; }
    public ReportImageMIMEType MIMEType { get; set; }
    public ReportStyles Border { get; set; }
    public ReportColor Color { get; set; }
    public ReportDimensions Position { get; set; }
    public ReportScale Size { get; set; }
    public ReportDimensions Padding { get; set; }

    private ReportImageScaling reportImageScaling = ReportImageScaling.AutoSize;
    public ReportImageScaling ReportImageScaling
    {
        get { return reportImageScaling; }
        set { reportImageScaling = value; }
    }
}
public class ReportColor
{
    public Color Default { get; set; }
    public Color Left { get; set; }
    public Color Right { get; set; }
    public Color Top { get; set; }
    public Color Bottom { get; set; }
}
public class ReportStyles
{
    public ReportStyle Default { get; set; }
    public ReportStyle Left { get; set; }
    public ReportStyle Right { get; set; }
    public ReportStyle Top { get; set; }
    public ReportStyle Bottom { get; set; }
}
public enum ReportActionType
{
    None,
    HyperLink
}
public enum ReportHorizantalAlign
{
    Left,
    Right,
    Center,
    General,
    Default
}
public enum ReportVerticalAlign
{
    Top,
    Middle,
    Bottom,
    Default
}
public enum ReportImageRepeat
{
    Default,
    Repeat,
    RepeatX,
    RepeatY,
    Clip
}
public enum ReportImageScaling
{

    AutoSize,
    Flip,
    FlipProportional,
    Clip
}
public enum ReportImageSource
{
    External,
    Embedded,
    Database
}
public enum ReportImageMIMEType
{
    Bitmap,
    JPEG,
    GIF,
    PNG,
    xPNG
}
public enum ReportStyle
{
    Default, Dashed, Dotted, Double, Solid, None
}
public enum ReportSort
{
    Ascending,
    Descending
}
public enum ReportFunctions
{
    Avg,
    Count,
    Sum,
    Min,
    Max,
    Aggregate


}
