CREATE TABLE [dbo].Sucursal(
	sucursal_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	fecha_apertura time NOT NULL,
	fecha_cierre time NOT NULL,
	direccion varchar(50) NOT NULL
)

EXEC sp_rename 'Sucursal.fecha_apertura', 'hora_apertura', 'COLUMN';	--cambio el nombre con un sp de tsql
EXEC sp_rename 'Sucursal.fecha_cierre', 'hora_cierre', 'COLUMN';

CREATE TABLE [dbo].Barbero(
	barbero_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre varchar(50) NOT NULL,
	apellido varchar(50) NOT NULL
)

CREATE TABLE [dbo].Sucursal_Barbero(
	sucursal_barbero_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	sucursal_id int FOREIGN KEY REFERENCES Sucursal(sucursal_id),
	barbero_id int FOREIGN KEY REFERENCES Barbero(barbero_id)
)


CREATE TABLE [dbo].Servicio(
	servicio_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre varchar(50) NOT NULL,
	descripcion varchar(500) NOT NULL,
	duracion int NOT NULL		--en minutos
)

CREATE TABLE [dbo].Sucursal_Servicio(
	sucursal_servicio_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	sucursal_id int FOREIGN KEY REFERENCES Sucursal(sucursal_id),
	servicio_id int FOREIGN KEY REFERENCES Servicio(servicio_id)
)

CREATE TABLE [dbo].Barbero_Servicio(
	barbero_servicio_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	barbero_id int FOREIGN KEY REFERENCES Barbero(barbero_id),
	servicio_id int FOREIGN KEY REFERENCES Servicio(servicio_id)
)

CREATE TABLE [dbo].Turno(
	turno_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre varchar(50) NOT NULL,
	apellido varchar(50) NOT NULL,
	hora_inicio time NOT NULL,	--corregido abajo para guardar el datetime y despues sacar lo que necesite.
	reservado bit NOT NULL default 0,	--0 no reservado, 1 reservado
	sucursal_id int FOREIGN KEY REFERENCES Sucursal(sucursal_id),
	servicio_id int FOREIGN KEY REFERENCES Servicio(servicio_id),
	barbero_id int FOREIGN KEY REFERENCES Barbero(barbero_id)
)

alter table [Turno] drop column [hora_inicio]
alter table [Turno] add fecha datetime NOT NULL default getdate()	

--para agregar un nuevo turno desde android tengo que tomar la fecha que voy a enviar por parametro del calender de android y concatenarle la hora segun la que se elija en el desplegable.