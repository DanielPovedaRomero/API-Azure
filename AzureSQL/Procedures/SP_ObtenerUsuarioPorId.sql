CREATE PROCEDURE [dbo].[SP_ObtenerUsuarioPorId]
    @IdUsuario INT
AS
BEGIN
    SELECT * FROM AZ_TB_Usuarios WHERE IdUsuario = @IdUsuario;
END
