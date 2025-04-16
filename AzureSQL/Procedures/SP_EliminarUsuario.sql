CREATE PROCEDURE [dbo].[SP_EliminarUsuario]
    @IdUsuario INT
AS
BEGIN
    DELETE FROM AZ_TB_Usuarios WHERE IdUsuario = @IdUsuario;
END;
