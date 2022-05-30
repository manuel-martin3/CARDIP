﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlUploadSUNARP.ascx.cs" 
Inherits="SGAC.WebApp.Accesorios.SharedControls.ctrlUploadSUNARP" %>
 
 <%@ Register Src="~/Accesorios/SharedControls/ctrlPageBar.ascx" TagName="ctrlPageBar"
    TagPrefix="uc2" %>
<%-- <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>--%>


<style type="text/css">
    .tMsjeWarnig
    {
        background-color: #F2F1C2;
        border-color: Yellow; /*#6E4E1B;*/
        color: #4B4F5E;
        height: 15px;        
        width: 100%;
    }
     
    .lblMsjeWarnig
    {
        margin-left: 25px;
    }
    
    .tMsjeError
    {
        background-color: #FE2E2E;
        border-color: Red; /*#6E4E1B;*/
        color: #FFFFFF;
        height: 15px;
        width: 100%;
    }
    
    .lblMsjeError
    {
        margin-left: 25px;
    }
    
    .tMsjeSucess
    {
        background-color: #2E9AFE;
        border-color: Blue; /*#6E4E1B;*/
        color: #FFFFFF;
        height: 15px;
        width: 100%;
    }
    
    .lblMsjeSucess
    {
        margin-left: 25px;
    }
    .style1
    {
        width: 706px;
    }
    </style>
    

<asp:UpdatePanel ID="updActuacionAdjuntar" UpdateMode="Conditional" runat="server">
        <Triggers>
              <asp:PostBackTrigger  controlid="BtnGrabActAdj"  />
              <asp:AsyncPostBackTrigger controlid="BtnLimpiaAdj" eventname="Click" />
              <asp:PostBackTrigger controlid="Grd_Archivos"    />
              
         </Triggers> 
      <ContentTemplate>
      

         <table class="mTblSecundaria">
            <tr>
                <td id="pnlAdjuntos" runat="server">
                    <asp:Label ID="lblValidacionAdjunto" runat="server" Text="Falta validar algunos campos."
                                    CssClass="hideControl" ForeColor="Red" Font-Size="14px"></asp:Label>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblTipAdj" runat="server" Text="Tipo de Archivo:"></asp:Label>
                            </td>
                            <td align="left" class="style1">
                                <asp:DropDownList ID="cmb_TipoArchivo" runat="server" Height="20px" 
                                    Width="180px" 
                                    onselectedindexchanged="cmb_TipoArchivo_SelectedIndexChanged" AutoPostBack="True" 
                                        />
                                <asp:Label ID="lblValTipoArchivo" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <br />
                            </td>
                            <td>
                                <asp:HiddenField ID="hifCodVinculado" runat="server" Value="" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr> 
                        <tr>
                        <td>
                            <asp:HiddenField ID="HFAutodhesivo" Value="0" runat="server" />
                            <asp:HiddenField ID="HFGUID" runat="server" />
                            <asp:HiddenField ID="HF_CUO" runat="server"></asp:HiddenField>
                            </td>
                            <td class="style1">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="ckHabilitarDigitalizacion" runat="server" 
                                Text="Digitalización Correcta" AutoPostBack="True" 
                                    oncheckedchanged="ckHabilitarDigitalizacion_CheckedChanged" Visible="False" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                           
                                
                            </td>
                                                            
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDescAdj" runat="server" Text="Descripción :" Width="100px"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txtDescAdj" runat="server" CssClass="txtLetra" Width="600px" Height="40px" MaxLength="180" TextMode="MultiLine" />
                                <asp:Label ID="lblValDescAdj" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label>
                            </td>                                                            
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAdjArchiv" runat="server" Text="Adjuntar Archivo :"></asp:Label>
                            </td>
                            <td class="style1">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:FileUpload ID="FileUploader" runat="server" Width="600px"></asp:FileUpload>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="server" id="msjeWarning" colspan="2">
                                            <table id="tMsjeWarnig" class="tMsjeWarnig" align="center">
                                                <tr>
                                                    <td style="width:30px"><asp:Image ID="Image3" runat="server"  ImageUrl="~/Images/img_16_warning.png"/></td>
                                                    <td>                                                                                    
                                                        <asp:Label ID="lblMsjeWarnig" runat="server" Text="" CssClass="lblMsjeWarnig" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="server" id="msjeError" colspan="2">
                                            <table id="tMsjeError" class="tMsjeError" align="center">
                                                <tr>
                                                    <td style="width:30px"><asp:Image ID="Image2" runat="server"  ImageUrl="~/Images/img_16_error.png"/></td>
                                                    <td>
                                                        <asp:Label ID="lblMsjeError" runat="server" Text="" CssClass="lblMsjeError" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td runat="server" id="msjeSucess" colspan="2">
                                            <table id="tMsjeSucess" class="tMsjeSucess" align="center">
                                                <tr>
                                                    <td style="width:30px"><asp:Image ID="Image1" runat="server"  ImageUrl="~/Images/img_16_success.png"/></td>
                                                    <td>                                                                                    
                                                        <asp:Label ID="lblMsjeSucess" runat="server" Text="" CssClass="lblMsjeSucess" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:HiddenField ID="hd_Extension" runat="server" />
                                            <asp:Label ID="lblNombreArchivo" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                            </table>
 

                                <asp:Label ID="lblLeyendaAdj" runat="server" Font-Bold="True" Text="Solo se permiten guardar archivos de un tamaño Max. de "></asp:Label>
                                <asp:Label ID="lblTamanioMax" runat="server" Font-Bold="True" Text=""></asp:Label>
                                <asp:Label ID="lblUnidad" runat="server" Font-Bold="True" Text=" MB"></asp:Label>
                            </td>
                                                  
                        </tr>
                        <tr>
                            <td></td>
                            <td align="left">
                                <asp:Button ID="BtnGrabActAdj" runat="server" Text="       Guardar Adjunto" CssClass="btnSave" Width="150px"
                                    OnClick="BtnGrabActAdj_Click" />    
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="BtnLimpiaAdj" runat="server" Width="150px" 
                                    Text="          Limpiar Datos" CssClass="btnLimpiar" 
                                    onclick="BtnLimpiaAdj_Click"></asp:Button>

                            <asp:HiddenField ID="hidNomAdjFile" runat="server" />
                            </td>
                                                        
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="Grd_Archivos" runat="server" CssClass="mGrid" AlternatingRowStyle-CssClass="alt"
                        AutoGenerateColumns="False" GridLines="None" OnRowDataBound="Grd_Archivos_RowDataBound"
                        onrowcommand="Grd_Archivos_RowCommand">
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:BoundField DataField="iActuacionAdjuntoId" HeaderText="IActuacionAdjuntoId"
                                HeaderStyle-CssClass="ColumnaOculta" ItemStyle-CssClass="ColumnaOculta" >
                                <HeaderStyle CssClass="ColumnaOculta" />
                                <ItemStyle CssClass="ColumnaOculta" />
                            </asp:BoundField>
                            <asp:BoundField DataField="iActuacionDetalleId" HeaderText="iActuacionDetalleId"
                                HeaderStyle-CssClass="ColumnaOculta" ItemStyle-CssClass="ColumnaOculta" >
                                <HeaderStyle CssClass="ColumnaOculta" />
                                <ItemStyle CssClass="ColumnaOculta" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sAdjuntoTipoId" HeaderText="IAdjuntoTipoId" HeaderStyle-CssClass="ColumnaOculta"
                                ItemStyle-CssClass="ColumnaOculta" >
                                <HeaderStyle CssClass="ColumnaOculta" />
                                <ItemStyle CssClass="ColumnaOculta" />
                            </asp:BoundField>
                            <asp:BoundField DataField="acad_dFechaCreacion" HeaderText="Fecha y Hora" 
                                DataFormatString="{0:MMM-dd-yyyy HH:mm:ss}" >
                                <ItemStyle HorizontalAlign="Center" Width="130px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="vusuario" HeaderText="Usuario">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="vAdjuntoTipo" HeaderText="Tipo de Archivo">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="vNombreArchivo" HeaderText="Nombre del Archivo">
                                <ItemStyle  Width="400px"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="vDescripcion" HeaderText="Descripción">
                                 <HeaderStyle CssClass="ColumnaOculta" />
                                <ItemStyle CssClass="ColumnaOculta" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="Opciones" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnPrint"  CommandName="Descargar"  ToolTip="Descargar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"
                                        runat="server" ImageUrl="~/Images/img_16_download.png" /> 
                                        &nbsp;                                           
                                    <asp:ImageButton ID="btnEliminar" CommandName="Eliminar" ToolTip="Eliminar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"
                                        runat="server" ImageUrl="~/Images/img_16_delete.png" />
                                        &nbsp;
                                    <asp:ImageButton ID="btnFirmar" CommandName="Firmar" ToolTip="Obtener documento" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"
                                         runat="server" ImageUrl="~/Images/img_16_tramite_aprobar.png"/> 
                                    <input id="btnInvoker" type="button"  title="Firmar documento" onclick="initInvoker('W');"  style="background-image:url('../Images/img_16_other.png'); background-repeat:no-repeat; border:0px; cursor:pointer; height:16px; width:16px" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="110px"/>
                            </asp:TemplateField>                                                       

                            <asp:BoundField DataField="bBloqueoAdjunto" HeaderText="bBloqueoAdjunto" HeaderStyle-CssClass="ColumnaOculta" ItemStyle-CssClass="ColumnaOculta">
                                <HeaderStyle CssClass="ColumnaOculta" />
                                <ItemStyle CssClass="ColumnaOculta" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle Font-Names="Arial" Font-Size="11px" />
                        <EmptyDataTemplate>
                              <table id="tbSinDatosDigitalizacion">
                                        <tbody>
                                            <tr>
                                                <td width="10%">
                                                    <asp:Image ID="imgWarning" runat="server" ImageUrl="~/Images/img_16_warning.png" />
                                                </td>
                                                <td width="5%">
                                                </td>
                                                <td width="85%">
                                                    <asp:Label ID="lblSinDatosFunc" runat="server" Text="Sin Datos..."></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                        </EmptyDataTemplate>
                        <SelectedRowStyle CssClass="slt" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <uc2:ctrlPageBar ID="CtrlPageBarAdjunto" runat="server" OnClick="CtrlPageBarActAdjunto_Click"
                            Visible="false" />
                    </div>
                </td>
            </tr>
         </table>
      </ContentTemplate>
  
    

</asp:UpdatePanel>




  <script language="javascript" type="text/javascript">


    function eliminar() {
        var autoadhesivo = $("#<%= HFAutodhesivo.ClientID %>").val();

        if (autoadhesivo != 1) {
            return confirm('Desea Eliminar el registro')
        }
        else {
            return false;
        }

    }
    function validar() {
        var autoadhesivo = $("#<%= HFAutodhesivo.ClientID %>").val();
        if (autoadhesivo == 1) {
            return false;
        }
    }
    function ValidarRegistroAdjunto() {
        var bolValida = true;
        $("#<%= lblValidacionAdjunto.ClientID %>").html("Falta validar algunos campos.");

        var strSeleccionado = $.trim($("#<%= cmb_TipoArchivo.ClientID %>").val());

        var strDescripcion = $.trim($("#<%= txtDescAdj.ClientID %>").val());
        var strNomAdjFile = $.trim($("#<%= hidNomAdjFile.ClientID %>").val());

        var ddlTipoArchivo = document.getElementById('<%= cmb_TipoArchivo.ClientID %>');

        var hidNomAdjFile = document.getElementById('<%= hidNomAdjFile.ClientID %>');

        if (strSeleccionado == "0") {
            ddlTipoArchivo.style.border = "1px solid Red";
            bolValida = false;
        }
        else {
            ddlTipoArchivo.style.border = "1px solid #888888";
        }



        if (strNomAdjFile.length == 0) {
            $("#<%= lblValidacionAdjunto.ClientID %>").html("Falta adjuntar archivo.");
            hidNomAdjFile.style.border = "1px solid Red";
            bolValida = false;
        }
        else {
            hidNomAdjFile.style.border = "1px solid #888888";
        }

        if (bolValida) {
            $("#<%= lblValidacionAdjunto.ClientID %>").hide();
            bolValida = confirm("¿Está seguro de grabar los cambios?");
        }
        else {
            $("#<%= lblValidacionAdjunto.ClientID %>").show();
        }

        return bolValida;
    }

    function MoveTabIndex(iTab) {
        $('#tabs').tabs("option", "active", iTab);
    }
                                        
    function showpopupother(type_msg, title, msg, resize, height, width) {
        showdialog(type_msg, title, msg, resize, height, width);
    }

      
</script>

