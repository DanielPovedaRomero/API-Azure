CREATE PROCEDURE [dbo].[SP_ObtenerUsuarios]
AS
BEGIN
    SELECT * FROM AZ_TB_Usuarios ORDER BY FechaRegistro DESC;
END;