USE [barberia_bm]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GETHorariosBarbero
	@p_id_barbero int
	,@p_fecha_turno datetime
	,@p_hora_apertura_sucursal time(0)
	,@p_hora_cierre_sucursal time(0)
	,@p_duracion_servicio int

	--,@p_ticketRegistro nvarchar(2000) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @myTableVariable2 TABLE (horario time(0))
	--insert into @myTableVariable2 values('18:00:00'), ('11:00:00'), ('13:30:00')	--esto representa el query con los turnos del barbero (comentado)
			
	select convert(time(0), t.fecha, 108) from Barbero b	--la hora se muestra asi 12:00:00
	inner join Turno t on t.barbero_id = b.barbero_id
	inner join Servicio s on t.servicio_id = s.servicio_id
	where b.barbero_id = @p_id_barbero
	and convert(date, t.fecha) = @p_fecha_turno		--esta fecha es el parametro que viene del calendar de android

	DECLARE @Counter INT,  @Time time(0), @Fraccion int

	set @Fraccion= @p_duracion_servicio	--aca va la duracion del servicio
	SET @Counter= (select (datediff(minute, @p_hora_apertura_sucursal, @p_hora_cierre_sucursal))/@Fraccion)
	set @Time= @p_hora_apertura_sucursal		--aca va la hora inicial

	WHILE ( @Counter <> 0)
	BEGIN

		DECLARE @myTableVariable TABLE (horario time(0))
		if @Fraccion = 60
			begin
				IF NOT EXISTS (SELECT horario FROM @myTableVariable2 where horario = @Time)		--para fracciones de 30
				and NOT EXISTS (SELECT horario FROM @myTableVariable2 where horario = DATEADD(minute,30,@Time))	--para fracciones de 60 y 30
				BEGIN
					insert into @myTableVariable values(@Time)
				END
			end
		else 
			begin
				if @Fraccion = 30
				begin
					IF NOT EXISTS (SELECT horario FROM @myTableVariable2 where horario = @Time)	--para fracciones de 30
					BEGIN
						insert into @myTableVariable values(@Time)
					END	
				end
			end
				
		set @Time = DATEADD(minute,@Fraccion,@Time)
		SET @Counter  = @Counter - 1
				
	END

	select horario from @myTableVariable
END
GO
