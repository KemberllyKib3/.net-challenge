﻿ALTER TABLE clientes ADD CPF varchar(14) UNIQUE NOT NULL;
ALTER TABLE beneficiarios ALTER COLUMN CPF VARCHAR(14);

SELECT * FROM clientes;
SELECT * FROM beneficiarios;