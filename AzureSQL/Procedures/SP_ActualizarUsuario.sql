CREATE PROCEDURE [dbo].[SP_ActualizarUsuario]
    @IdUsuario INT,
    @Cedula VARCHAR(20),
    @Nombre VARCHAR(1000),
    @Telefono VARCHAR(20),
    @Observaciones VARCHAR(5000)
AS
BEGIN
    UPDATE AZ_TB_Usuarios
    SET Cedula = @Cedula,
        Nombre = @Nombre,
        Telefono = @Telefono,
        Observaciones = @Observaciones
    WHERE IdUsuario = @IdUsuario;
END