﻿CREATE PROC FI_SP_IncBeneficiario	
	@CPF		VARCHAR(14),
	@NOME		VARCHAR(100),
	@IDCLIENTE	BIGINT
AS

	INSERT INTO BENEFICIARIOS (CPF,NOME,IDCLIENTE)
	VALUES(@CPF,@NOME,@IDCLIENTE);
GO

