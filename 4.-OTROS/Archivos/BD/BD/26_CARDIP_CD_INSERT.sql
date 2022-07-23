USE BD_CARDIP

GO

IF NOT EXISTS(SELECT CAMI_VNOMBRE FROM SC_MAESTRO.MA_CALIDAD_MIGRATORIA
WHERE CAMI_VNOMBRE = 'PRODUCCI�N ART�STICA' 
AND CAMI_CESTADO='A' AND
CAMI_VNUMERO_ORDEN IS NOT NULL)
BEGIN
	Insert Into SC_MAESTRO.MA_CALIDAD_MIGRATORIA(CAMI_VNUMERO_ORDEN,CAMI_SFLAG_NIVEL_CALIDAD,CAMI_VNOMBRE,
	CAMI_VDEFINICION,CAMI_CESTADO,CAMI_SUSUARIOCREACION,CAMI_VIPCREACION,CAMI_DFECHACREACION)
	Select '10',0,'PRODUCCI�N ART�STICA','Es otorgada por Relaciones Exteriores, Permite el ingreso y permanencia de los extranjeros que realizan trabajo art�stico o t�cnico en actividades vinculadas a la industria cultural o art�stica, incluyendo la producci�n cinematogr�fica y audiovisual extrajeras.','A',1,'1.1.1.1',GETDATE()
END
