USE [BD_CARDIP]
GO

	DECLARE @PARA_VDESCRIPCION VARCHAR(300) = 'EQUIPO DE PRODUCCI�N'

	IF NOT EXISTS (SELECT 1 FROM [PS_SISTEMA].[SI_PARAMETRO]
	WHERE SI_PARAMETRO.PARA_VDESCRIPCION = @PARA_VDESCRIPCION AND 
		SI_PARAMETRO.PARA_VREFERENCIA=358 AND 
		SI_PARAMETRO.PARA_CESTADO = 'A')
	BEGIN
		INSERT INTO[PS_SISTEMA].[SI_PARAMETRO]([PARA_VGRUPO],[PARA_VDESCRIPCION],[PARA_VVALOR],[PARA_VREFERENCIA],[PARA_TORDEN],[PARA_BVISIBLE],[PARA_DVIGENCIAINICIO],[PARA_DVIGENCIAFIN],[PARA_BPRECARGA],[PARA_CESTADO],[PARA_SUSUARIOCREACION],[PARA_VIPCREACION],[PARA_DFECHACREACION],[PARA_SUSUARIOMODIFICACION],[PARA_VIPMODIFICACION],[PARA_DFECHAMODIFICACION])
		VALUES('ACTOMIGRATORIO-VISATIPOTEMPORAL',@PARA_VDESCRIPCION,'ART',358,1,1,'1900-01-01 00:00:00.000','1900-01-01 00:00:00.000',1,'A',1,'192.168.1.246',GETDATE(),NULL,NULL,NULL)
				
		PRINT 'PARAMETRO '+ @PARA_VDESCRIPCION +' SE AGREG� CORRECTAMENTE'

	END

GO
