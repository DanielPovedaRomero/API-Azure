CREATE TABLE [dbo].[AZ_TB_Usuarios] (
    [IdUsuario] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Cedula] VARCHAR(20) NOT NULL,
    [Nombre] VARCHAR(1000) NOT NULL,
    [Telefono] VARCHAR(20) NOT NULL,
    [Observaciones] VARCHAR(5000) NULL,
    [FechaRegistro] DATETIME NULL DEFAULT (GETDATE()),  
) 
