-- Crear base de datos
CREATE DATABASE DB_Empresa
-- Usar la base de datos
USE DB_Empresa
-- Crear tabla
CREATE TABLE Empleado(
	id_Emp varchar(15) primary key,
	nombre varchar(30) not null,
	apellido varchar(50) not null,
	telefono varchar(15) null,
	salario float
)
CREATE TABLE Cliente(
	id_Cliente varchar(15) primary key,
	nombre varchar(30) not null,
	apellido varchar(50) not null,
	telefono varchar(15) not null,
	direccion varchar(30) not null,
	email varchar(30) not null
)


-- Insertar resgistros
INSERT INTO Empleado(id_Emp,nombre,apellido,telefono,salario) VALUES
('1094909543','Jessica','Berrio','717171771',4000000)

--------------------------------------
-- Manejo de variables ( se declara con el @)
-- Definicion de variables
DECLARE @NOM VARCHAR(20)
DECLARE @NOM2 VARCHAR(20)
DECLARE @SALARIO FLOAT
-- Asignacion de variables
-- CON SET / SELECT
SET @NOM = 'Pedro'
SET @SALARIO = 900 
SELECT @NOM2=nombre FROM Empleado WHERE id_Emp='1094909543'

--IMPRIMIR EL VALOR DE UNA VARIABLE
--PRINT / SELECT

-- SELECT (CAPTURAR O IMPRIMIR UN VALOR)

PRINT 'NOMBRE:'+@NOM	
PRINT @NOM2
SELECT @NOM AS NOMBRE
PRINT 'SALARIO:' + CONVERT(VARCHAR(10),@SALARIO)
SELECT @SALARIO AS SALARIO

-- CONDICIONAL
IF (@SALARIO>3000000)
	begin
	SELECT 'Mayor a 3000000'
	SELECT @SALARIO AS SALARIO
	end
ELSE
	SELECT 'Menor a 3000000'


-- Procedimiento almacenado
CREATE PROCEDURE USP_IngresarEmp
-- Parametros de entrada
as
begin
	select * from Empleado
end

CREATE PROCEDURE USP_consultar_emp
-- Parametros de entrada
	@id_Emp varchar(15)
as
begin
	select * from Empleado where id_Emp= @id_Emp
end

CREATE PROCEDURE USP_insertar_emp
-- Parametros de entrada
	@id_Emp varchar(15),
	@nombre_Emp varchar(30),
	@apellido_Emp varchar(50),
	@telefono_Emp varchar(15),
	@salario_Emp float
as
begin
	--select * from Empleado where id_Emp= @id_Emp
	insert into Empleado(id_Emp,nombre,apellido,telefono,salario) values(@id_Emp,@nombre_Emp,@apellido_Emp,@telefono_Emp,@salario_Emp)
end

--Procedimiento actulizar
CREATE PROCEDURE USP_actualizar_emp
	@nombre_Emp varchar(30),
	@apellido_Emp varchar(50),
	@telefono_Emp varchar(15),
	@salario_Emp float,
	@id_Emp varchar(15)
as
begin
	UPDATE Empleado
	SET nombre=@nombre_Emp,
		apellido=@apellido_Emp,
		telefono=@telefono_Emp,
		salario= @salario_Emp 
	WHERE id_Emp = @id_Emp	
end

CREATE PROCEDURE USP_eliminar_emp
	@id_Emp varchar(15)
as
begin
	DELETE FROM Empleado
	WHERE id_Emp = @id_Emp	
end


--ejecutar un procedimiento empleado
execute USP_IngresarEmp
execute USP_consultar_emp 1094909543
execute USP_insertar_emp '1','Juan' ,'Sanchez','34567788',1000000
execute USP_actualizar_emp 'Sebastian' ,'Marin','345000000',2000000,'1'
execute USP_eliminar_emp '1'

-- Procedimientos cliente
--ConsulTar cliente
CREATE PROCEDURE USP_consultar_cliente
-- Parametros de entrada
	@id_Cliente varchar(15)
as
begin
	select * from Cliente where id_Cliente= @id_Cliente
end
CREATE PROCEDURE USP_insertar_cliente
-- Parametros de entrada
	@id_Cliente varchar(15),
	@nombre_Cliente varchar(30),
	@apellido_Cliente varchar(50),
	@telefono_Cliente varchar(15),
	@direccion_Cliente varchar(30),
	@email_cliente varchar(30)
as
begin
	--select * from Empleado where id_Emp= @id_Emp
	insert into Cliente(id_Cliente,nombre,apellido,telefono,direccion,email) values(@id_Cliente,@nombre_Cliente,@apellido_Cliente,@telefono_Cliente,@direccion_Cliente,@email_cliente)
end

--Procedimiento actualizar
CREATE PROCEDURE USP_actualizar_Cliente
	@nombre_Cliente varchar(30),
	@apellido_Cliente varchar(50),
	@telefono_Cliente varchar(15),
	@direccion_Cliente varchar(30),
	@email_cliente varchar(30),
	@id_Cliente varchar(15)
as
begin
	UPDATE Cliente
	SET nombre=@nombre_Cliente,
		apellido=@apellido_Cliente,
		telefono=@telefono_Cliente,
		direccion= @direccion_Cliente,
		email=@email_cliente
	WHERE id_Cliente = @id_Cliente	
end

--Eliminar cliente
CREATE PROCEDURE USP_eliminar_cliente
	@id_Cliente varchar(15)
as
begin
	DELETE FROM Cliente
	WHERE id_Cliente = @id_Cliente	
end


--Listar clientes
CREATE PROCEDURE USP_listar_clientes
	
as
begin
	SELECT * FROM Cliente
end

--Listar empleado
CREATE PROCEDURE USP_listar_empleado
	
as
begin
	SELECT * FROM Empleado
end


--ejecutar un procedimiento empleado
execute USP_IngresarEmp
execute USP_consultar_emp 1094909543
execute USP_insertar_emp '1','Juan' ,'Sanchez','34567788',1000000
execute USP_actualizar_emp 'Sebastian' ,'Marin','345000000',2000000,'1'
execute USP_eliminar_emp '1'
execute USP_listar_empleado;


--ejecutar un procedimiento cliente
execute USP_insertar_cliente '3','Juan' ,'Sanchez','34567788','Calla 45-50','Juan@gmiaal.com'
execute USP_consultar_cliente '1'
execute USP_actualizar_cliente 'Daniel' ,'Bedoya','34567788','Calla 45-50','Juan@gmail.com','1'
execute USP_insertar_cliente '2','Brayan' ,'Sanchez','3117345678','Calla 89-99','brayan45@gmail'
execute USP_eliminar_cliente'2'
execute USP_listar_clientes

select * from Empleado;
select * from Cliente;

--Combox: Menú listado normalmente se utiliza en las foraneas
--valor es lo que queda oculto y texto es lo que se muestra (Ej id:valor, nombre: texto)
select '0' as id_Emp, 'Seleccione un nombre' as 'nombre completo'
union --union de dos consultas
select id_Emp, nombre+' '+apellido as 'nombre completo' from Empleado;

--Procedimiento almacenado listar combo empleados
CREATE PROCEDURE USP_ListaComboEmp
	
as
begin
	select '0' as id_Emp, 'Seleccione un nombre' as 'nombre completo'
	union
	select id_Emp, nombre+' '+apellido as 'nombre completo' from Empleado
end

--Ejecutar procedimiento almacenado listar combo empleados
execute USP_ListaComboEmp;