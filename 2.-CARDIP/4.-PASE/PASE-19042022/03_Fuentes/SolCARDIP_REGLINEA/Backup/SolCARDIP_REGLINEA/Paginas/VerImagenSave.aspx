﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerImagenSave.aspx.cs" Inherits="SolCARDIP_REGLINEA.Paginas.VerImagenSave" %>
<%@ Import Namespace="System.IO" %>
<%       
    if (Session["tempImagenSave"] != null)
    {
        string base64String = (string)Session["tempImagenSave"];
        byte[] imgByte = Convert.FromBase64String(base64String);
        Response.Clear();
        Response.Expires = 0;
        Response.Buffer = true;
        Response.ContentType = "image/jpeg;base64";
        Response.BinaryWrite(imgByte);
        Response.End();
    }
    else
    {
        Byte[] imageByte = null;
        imageByte = File.ReadAllBytes(Server.MapPath("../Imagenes/notFound.jpg"));
        string base64String = Convert.ToBase64String(imageByte, 0, imageByte.Length);
        byte[] imgByte = Convert.FromBase64String(base64String);
        Response.Clear();
        Response.Expires = 0;
        Response.Buffer = true;
        Response.ContentType = "image/jpeg;base64";
        Response.BinaryWrite(imgByte);
        Response.End();
    }
 %>
 <html>
    <head>
        <base href="VerImagenSave.aspx" target="_self" />
    </head>
 </html>
