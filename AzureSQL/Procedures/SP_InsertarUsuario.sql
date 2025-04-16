CREATE PROCEDURE [dbo].[SP_InsertarUsuario]
    @Cedula VARCHAR(20),
    @Nombre VARCHAR(1000),
    @Telefono VARCHAR(20),
    @Observaciones VARCHAR(5000)
AS
BEGIN
    INSERT INTO AZ_TB_Usuarios (Cedula, Nombre, Telefono, Observaciones)
    VALUES (@Cedula, @Nombre, @Telefono, @Observaciones);

    SELECT SCOPE_IDENTITY() AS IdUsuario; 
END
