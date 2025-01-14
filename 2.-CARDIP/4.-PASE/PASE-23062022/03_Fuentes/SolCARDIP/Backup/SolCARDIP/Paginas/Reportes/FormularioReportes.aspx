﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Principales/Principal.Master" AutoEventWireup="true" CodeBehind="FormularioReportes.aspx.cs" Inherits="SolCARDIP.Paginas.Reportes.FormularioReportes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var master = "ContentPlaceHolder1_";

        function validarReporte(FechaInicio, FechaFin) {
            var txt1 = document.getElementById(master + FechaInicio);
            var txt2 = document.getElementById(master + FechaFin);
            var dropDown1 = document.getElementById(master + "ddlCalidadMigratoriaPri");
            var dropDown2 = document.getElementById(master + "ddlEstado");
            var dropDown3 = document.getElementById(master + "ddlMision");

            if (txt1 != null & txt2 != null) {
                if (txt1.value == "") { alert("DEBE INGRESAR UNA FECHA INICIO"); txt1.focus(); return false; }
                if (txt2.value == "") { alert("DEBE INGRESAR UNA FECHA FIN"); txt2.focus(); return false; }
                // VALIDA FECHAS
                var fechaIni = txt1.value;
                var fechaFin = txt2.value;
                if (!validaFechaDDMMAAAA(fechaIni)) { alert("FECHA INICIO NO VALIDA. REVISE."); txt1.focus(); return false; };
                if (!validaFechaDDMMAAAA(fechaFin)) { alert("FECHA FIN NO VALIDA. REVISE."); txt2.focus(); return false; };

                return true;
            }
        }

        

        function tabActual(valor) {
            var hd1 = document.getElementById(master + "hdfldTabActual");
            if (hd1 != null) {
                hd1.value = valor;
                cambiarTabs();
            }
        }

        function cambiarTabs() {
            var hd1 = document.getElementById(master + "hdfldTabActual");
            var contenedor = document.getElementById("tdContenedor");
            var tr1 = document.getElementById("trTabs");
            var tabPest = document.getElementById("tabPest" + hd1.value);
            var tab = document.getElementById("tab" + hd1.value);
            var n = 0;
            if (tab != null) {
                if (contenedor != null) {
                    var cantidad = contenedor.children.length
                    for (n = 1; n <= cantidad; n++) {
                        if (contenedor.children[n - 1].id == tab.id) {
                            tab.style.display = "block";
                            //alert(tab.id);
                        }
                        else {
                            contenedor.children[n - 1].style.display = "none";
                            //alert(contenedor.children[n - 1].id);
                        }
                    }
                    n = 0
                    cantidad = tr1.children.length;
                    for (n = 1; n <= cantidad; n++) {
                        if (tr1.children[n - 1].id == tabPest.id) {
                            tabPest.style.backgroundColor = "White";
                            tabPest.className = "Tabs";
                        }
                        else {
                            tr1.children[n - 1].style.backgroundColor = "#E6E6E6";
                            tr1.children[n - 1].className = "Tabs";
                        }
                    }
                }
            }
        }
    </script>
    <script type="text/javascript">
        function seguridadURLPrevia() {
            if (document.referrer != "") {
                preloader();
            }
            else {
                location.href = '../../mensajes.aspx';
            }
        }

        function mostrarCargando() {
            var master = "ContentPlaceHolder1_";
            document.getElementById(master + "divCargando").style.display = "block";
            document.getElementById(master + "divModal2").style.display = "block";
            document.getElementById(master + "divCargando").focus();
        }

        function preloader() {
            var master = "ContentPlaceHolder1_";
            document.getElementById(master + "divCargando").style.display = "none";
            document.getElementById(master + "divModal2").style.display = "none";
        }

        function verDiv(id) {
            var master = "ContentPlaceHolder1_"
            document.getElementsByName(id).style.display = "block"
        }
        function ocultarDiv(id) {
            var master = "ContentPlaceHolder1_"
            document.getElementById(master + id).style.display = "none"
        }

        function focusControl(controlId) {
            var ctrl = document.getElementById(controlId);
            if (ctrl != null) {
                ctrl.focus();
            }
        }
        window.onload = seguridadURLPrevia;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="updPrincipal">
        <ContentTemplate>
            <table class="AnchoTotal">
                <tr>
                    <td>
                        <div>
                            <div id="divModal2" runat="server" style="position:absolute;z-index:1;display:none" class="modalBackgroundLoad"></div>
                            <div id="divCargando" runat="server" style="position:absolute;z-index:2;top:50%;left:45%" onblur="ContentPlaceHolder1_divCargando.focus();">
                                <img alt="gif" src="../../Imagenes/Gifs/ajax-loader(1).gif" style="width:100px;height:95px" />
                            </div>
                            <div id="divModal" runat="server" style="display:none" class="modalBackgroundLoad"></div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="AnchoTotal">
                            <tr>
                                <td>
                                    <table class="AnchoTotal">
                                        <tr>
                                            <td style="width:100%">
                                                <table style="width:100%">
                                                    <tr id="trTabs">
                                                        <td id="tabPest0" class="Tabs" style="display:block;" onclick="tabActual(0);">Resumen x Calidad Migratoria</td>
                                                        <td id="tabPest1" class="Tabs" style="display:block;" onclick="tabActual(1);">Detalle de Carné de Identidad</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="AnchoTotal">
                                        <tr>
                                            <td id="tdContenedor">
                                                <div id="tab0" style="display:block;">
                                                    <table class="AnchoTotal">
                                                        <tr>
                                                            <td>
                                                                <table style="width:30%;">
                                                                    <tr>
                                                                        <td class="etiqueta" style="width:30%;">Desde</td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="textbox" Width="50%" MaxLength="10" Text=""></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="calendarEmision" runat="server" TargetControlID="txtFechaInicio" PopupButtonID="ibtFechaInicio" Format="dd/MM/yyyy"></cc1:CalendarExtender >
                                                                            <asp:ImageButton ID="ibtFechaInicio" runat="server" ImageUrl="~/Imagenes/Iconos/ico_calendar.gif" ToolTip="Seleccione Fecha de Ocurrencia" BorderWidth="0" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="etiqueta" style="width:30%;">Hasta</td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="txtFechaFin" CssClass="textbox" Width="50%" MaxLength="10" Text=""></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFin" PopupButtonID="ibtFechaFin" Format="dd/MM/yyyy"></cc1:CalendarExtender >
                                                                            <asp:ImageButton ID="ibtFechaFin" runat="server" ImageUrl="~/Imagenes/Iconos/ico_calendar.gif" ToolTip="Seleccione Fecha de Ocurrencia" BorderWidth="0" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table style="width:50%;">
                                                                    <tr><td><hr /></td></tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table style="width:50%;">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Button runat="server" ID="btnResumenxCalidad" Text="Traer Datos" CssClass="ImagenBotonData" OnClientClick="return validarReporte('txtFechaInicio','txtFechaFin');" OnClick="traerDatos" Width="150px" />
                                                                            <asp:Button runat="server" ID="btnVerReporteResumenxCalidad" Text="Ver Reporte" CssClass="ImagenBotonReporte" OnClick="imprimirReporteResumen" Width="150px" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table style="width:50%;">
                                                                    <tr><td><hr /></td></tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table style="width:50%;">
                                                                    <tr>
                                                                        <td class="etiqueta" style="width:12%;">Calidades</td>
                                                                        <td class="etiqueta" style="width:5%;">:</td>
                                                                        <td><asp:Label runat="server" ID="lblCantCalMig" CssClass="labelInfo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="etiqueta">Registrados</td>
                                                                        <td class="etiqueta" style="width:5%;">:</td>
                                                                        <td><asp:Label runat="server" ID="lblCantReg" CssClass="labelInfo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="etiqueta">Emitidos</td>
                                                                        <td class="etiqueta" style="width:5%;">:</td>
                                                                        <td><asp:Label runat="server" ID="lblCantEmi" CssClass="labelInfo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="etiqueta">Vigentes</td>
                                                                        <td class="etiqueta" style="width:5%;">:</td>
                                                                        <td><asp:Label runat="server" ID="lblCantVig" CssClass="labelInfo"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="etiqueta">Vencidos</td>
                                                                        <td class="etiqueta" style="width:5%;">:</td>
                                                                        <td><asp:Label runat="server" ID="lblCantVen" CssClass="labelInfo"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <div style="width:50%;">
                                                                    <table class="AnchoTotal">
                                                                        <tr>
                                                                            <td class="CabeceraGrilla" style="width:25%;height:25px">Calidad Migratoria</td>
                                                                            <td class="CabeceraGrilla" style="width:10%">Registrados</td>
                                                                            <td class="CabeceraGrilla" style="width:10%">Emitidos</td>
                                                                            <td class="CabeceraGrilla" style="width:10%">Vigentes</td>
                                                                            <td class="CabeceraGrilla" style="width:10%">Vencidos</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div ID="divGridView" runat="server" class="Scroll" style="width:51%;">
                                                                    <asp:GridView ID="gvReportexCalidad" runat="server" 
                                                                        AlternatingRowStyle-BackColor="Control" AutoGenerateColumns="false" ShowHeader="False" style="margin-top: 0px" EmptyDataText="No hay datos para mostrar"
                                                                        Width="100%">
                                                                        <RowStyle CssClass="FilaDatos" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="CalidadMigratoria" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25%" />
                                                                            <asp:BoundField DataField="Registrados" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                                            <asp:BoundField DataField="Emitidos" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                                            <asp:BoundField DataField="Vigentes" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                                            <asp:BoundField DataField="Vencidos" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div id="tab1" style="display:none;">
                                                    <table class="AnchoTotal">
                                                        <tr>
                                                            <td>
                                                                <table style="width:30%;">
                                                                    <tr>
                                                                        <td class="etiqueta" style="width:30%;">Desde</td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="txtFechaInicioDet" CssClass="textbox" Width="50%" MaxLength="10" Text=""></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaInicioDet" PopupButtonID="ibtFechaInicioDet" Format="dd/MM/yyyy"></cc1:CalendarExtender >
                                                                            <asp:ImageButton ID="ibtFechaInicioDet" runat="server" ImageUrl="~/Imagenes/Iconos/ico_calendar.gif" ToolTip="Seleccione Fecha de Ocurrencia" BorderWidth="0" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="etiqueta" style="width:30%;">Hasta</td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="txtFechaFinDet" CssClass="textbox" Width="50%" MaxLength="10" Text=""></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFechaFinDet" PopupButtonID="ibtFechaFinDet" Format="dd/MM/yyyy"></cc1:CalendarExtender >
                                                                            <asp:ImageButton ID="ibtFechaFinDet" runat="server" ImageUrl="~/Imagenes/Iconos/ico_calendar.gif" ToolTip="Seleccione Fecha de Ocurrencia" BorderWidth="0" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="etiqueta">Calidad Migratoria</td>
                                                                        <td>
                                                                            <asp:DropDownList runat="server" ID="ddlCalidadMigratoriaPri" CssClass="dropdownlist" AutoPostBack="false" Width="70%"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width:17%" class="etiqueta">Estado</td>
                                                                        <td>
                                                                            <asp:DropDownList runat="server" ID="ddlEstado" CssClass="dropdownlist" Width="100%" Enabled="true"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width:10%;" class="etiqueta">Categoria</td>
                                                                        <td style="color:Red;width:70%">
                                                                            <asp:DropDownList runat="server" ID="ddlCategoriaOfcoEx" CssClass="dropdownlist" AutoPostBack="true" OnSelectedIndexChanged="seleccionarCategoriaOficina" Width="60%"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="etiqueta">Misión</td>
                                                                        <td style="color:Red;">
                                                                            <asp:DropDownList runat="server" ID="ddlMision" CssClass="dropdownlist" AutoPostBack="false" Width="60%" Enabled="false"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table style="width:90%;">
                                                                    <tr><td><hr /></td></tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table style="width:90%;">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Button runat="server" ID="btnTraerDatosDetalle" Text="Traer Datos" CssClass="ImagenBotonData" OnClientClick="return validarReporte('txtFechaInicioDet','txtFechaFinDet')" OnClick="traerDatosDetalle" Width="150px" />
                                                                            <asp:Button runat="server" ID="Button2" Text="Ver Reporte" CssClass="ImagenBotonReporte" OnClick="imprimirReporteDetalle" Width="150px" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table style="width:90%;">
                                                                    <tr><td><hr /></td></tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <div style="width:90%;">
                                                                    <table class="AnchoTotal">
                                                                        <tr>
                                                                            <td class="CabeceraGrilla" style="width:7%;height:25px">Numero Carné</td>
                                                                            <td class="CabeceraGrilla" style="width:8%">Estado</td>
                                                                            <td class="CabeceraGrilla" style="width:10%">Calidad Migratoria</td>
                                                                            <td class="CabeceraGrilla" style="width:7%">Fecha Registro</td>
                                                                            <td class="CabeceraGrilla" style="width:7%">Fecha Emision</td>
                                                                            <td class="CabeceraGrilla" style="width:7%">Fecha Vencimiento</td>
                                                                            <td class="CabeceraGrilla" style="width:14%">Titular</td>
                                                                            <td class="CabeceraGrilla" style="width:8%">Estatus Migratorio</td>
                                                                            <td class="CabeceraGrilla" style="width:10%">Pais (Nacionalidad)</td>
                                                                            <td class="CabeceraGrilla" style="width:12%">Institucion</td>
                                                                            <td class="CabeceraGrilla" style="width:10%">Cargo</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div ID="div1" runat="server" class="Scroll" style="width:91%;">
                                                                    <asp:GridView ID="gvReporteDetalle" runat="server" 
                                                                        AlternatingRowStyle-BackColor="Control" AutoGenerateColumns="false" ShowHeader="False" style="margin-top: 0px" EmptyDataText="No hay datos para mostrar"
                                                                        Width="100%">
                                                                        <RowStyle CssClass="FilaDatos" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="NumeroCarne" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%" />
                                                                            <asp:BoundField DataField="Estado" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" />
                                                                            <asp:BoundField DataField="CalidadMigratoria" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                                            <asp:BoundField DataField="FechaReg" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%" />
                                                                            <asp:BoundField DataField="FechaEmi" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%" />
                                                                            <asp:BoundField DataField="FechaVen" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%" />
                                                                            <asp:BoundField DataField="Titular" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="14%" />
                                                                            <asp:BoundField DataField="TitDep" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" />
                                                                            <asp:BoundField DataField="PaisNac" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                                            <asp:BoundField DataField="OficinaConsularEx" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" />
                                                                            <asp:BoundField DataField="Cargo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table style="width:90%;">
                                                                    <tr>
                                                                        <td class="etiqueta" style="width:15%;">Cantidad de Registros Encontrados</td>
                                                                        <td class="etiqueta" style="width:5%;">:</td>
                                                                        <td>
                                                                            <asp:Label runat="server" ID="lblCantRegDetalle" CssClass="labelInfo"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdfldTabActual" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
