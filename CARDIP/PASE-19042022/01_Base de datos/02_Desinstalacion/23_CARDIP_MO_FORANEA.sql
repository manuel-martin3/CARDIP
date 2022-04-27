USE BD_CARDIP

DECLARE @FK_TABLE VARCHAR(MAX)='FK_ACTA_RECEPCION_DETALLE_CARNE_IDENTIDAD'
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS C 
	WHERE C.CONSTRAINT_NAME = @FK_TABLE
	AND C.TABLE_NAME = 'CD_ACTA_RECEPCION_DETALLE'
	AND C.CONSTRAINT_SCHEMA = 'SC_CARDIP'
	)
BEGIN

	ALTER TABLE [SC_CARDIP].[CD_ACTA_RECEPCION_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_ACTA_RECEPCION_DETALLE_CARNE_IDENTIDAD] FOREIGN KEY([ACRD_SCARNE_IDENTIDAD_ID])
	REFERENCES [SC_CARDIP].[CD_CARNE_IDENTIDAD] ([CAID_ICARNE_IDENTIDADID])
	
	ALTER TABLE [SC_CARDIP].[CD_ACTA_RECEPCION_DETALLE] CHECK CONSTRAINT [FK_ACTA_RECEPCION_DETALLE_CARNE_IDENTIDAD]
			
	PRINT 'CONSTRAINT '+@FK_TABLE+' ��AFECTADO!!'
END

GO