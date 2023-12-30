Create database TiendaVirtual
GO
Use TiendaVirtual
Go

CREATE TABLE Login (
    id INT IDENTITY(1,1) PRIMARY KEY,
    codigo_usuario INT,
    clave VARCHAR(50),
    CONSTRAINT fk_usuarioIDLogin FOREIGN KEY (codigo_usuario) REFERENCES Usuario(codigo_usuario)
);
GO

INSERT INTO Login (codigo_usuario, clave) VALUES (102, '0974');
INSERT INTO Login (codigo_usuario, clave) VALUES (109, '1234');
INSERT INTO Login (codigo_usuario, clave) VALUES (110, '1234');
GO

SELECT * FROM Login;
GO

Create PROCEDURE validarLogin
@CODIGO_USUARIO INT,
@CLAVE VARCHAR (50)
AS
	BEGIN
		SELECT codigo_usuario, clave FROM Login WHERE codigo_usuario = @CODIGO_USUARIO AND clave = @CLAVE;
	END
GO

EXEC validarLogin 102, '0974';
GO


CREATE TABLE Usuario (
    codigo_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
   
    correo_electronico VARCHAR(100)
   
)
Go

CREATE PROCEDURE obtenerusuarioID
@Nombre VARCHAR(20)
AS
	BEGIN
		select codigo_usuario  FROM usuario WHERE nombre = @Nombre
	END
GO
EXEC obtenerusuarioID 'Asheley'
GO



CREATE TABLE Articulo (
    codigo_articulo INT IDENTITY(1,1) PRIMARY KEY,
    descripcion TEXT,
    precio DECIMAL(10, 2),
    categoria VARCHAR(50)
)
GO

CREATE TABLE Factura (
    codigo_factura INT IDENTITY(1,1) PRIMARY KEY,
    codigo_articulo INT,
    fecha_transaccion DATE,
    codigo_usuario INT,
    FOREIGN KEY (codigo_articulo) REFERENCES Articulo(codigo_articulo),
    FOREIGN KEY (codigo_usuario) REFERENCES Usuario(codigo_usuario)
);
GO

CREATE TABLE Rol (
    id INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(50)
);
GO

INSERT INTO Rol (descripcion) VALUES ('Administrador');
INSERT INTO Rol (descripcion) VALUES ('Usuario');
GO

CREATE TABLE UsuarioRol (
    codigo_usuario INT,
    id_rol INT,
    CONSTRAINT fk_codigo_usuario_Rol FOREIGN KEY (codigo_usuario) REFERENCES Usuario(codigo_usuario),
    CONSTRAINT fk_Rol_ID FOREIGN KEY (id_rol) REFERENCES Rol(id)
);
GO

CREATE PROCEDURE obtenerRol
@USUARIOID INT
AS
	BEGIN
		SELECT id_rol FROM usuarioRol WHERE codigo_usuario = @USUARIOID
	END
GO

EXEC obtenerRol '102'
GO
SELECT * FROM usuarioRol
GO




CREATE TABLE Compra (
    id_compra INT IDENTITY(1,1) PRIMARY KEY,
    codigo_usuario INT,
    codigo_articulo INT,
    fecha_compra DATE,
    cantidad INT,
    codigo_factura INT,
    CONSTRAINT fk_codigo_usuario_Compra FOREIGN KEY (codigo_usuario) REFERENCES Usuario(codigo_usuario),
    CONSTRAINT fk_codigo_articulo_Compra FOREIGN KEY (codigo_articulo) REFERENCES Articulo(codigo_articulo),
    CONSTRAINT fk_codigo_factura_Compra FOREIGN KEY (codigo_factura) REFERENCES Factura(codigo_factura)
);
GO
---------------------------Procedimientos almacenados De Compra---------------------
CREATE PROCEDURE agregarCompra
@CODIGO_USUARIO INT,
@CODIGO_ARTICULO INT,
@FECHA_COMPRA DATE,
@CANTIDAD INT,
@CODIGO_FACTURA INT
AS
	BEGIN
		INSERT INTO Compra (codigo_usuario, codigo_articulo, fecha_compra, cantidad, codigo_factura) VALUES (@CODIGO_USUARIO, @CODIGO_ARTICULO, @FECHA_COMPRA, @CANTIDAD, @CODIGO_FACTURA);
	END
GO

CREATE PROCEDURE borrarCompra
@CODIGO INT
AS
	BEGIN
		DELETE Usuario WHERE codigo_usuario = @CODIGO
	END
GO
/*-------Procedimientos almacenados De usuaraio--------*/


CREATE PROCEDURE agregarusuarios
@NOMBRE VARCHAR (100),
@CORREO VARCHAR(100)

AS
	BEGIN
		INSERT INTO Usuario VALUES (@NOMBRE,  @CORREO)
	END
GO

CREATE PROCEDURE borrarUsuario
@CODIGO INT
AS
	BEGIN
		DELETE Usuario WHERE codigo_usuario = @CODIGO
	END
GO

CREATE PROCEDURE calcularTotalFactura
@CODIGO_FACTURA INT
AS
	BEGIN
		SELECT SUM(cantidad * precio) AS total
		FROM Compra
		JOIN Articulo ON Compra.codigo_articulo = Articulo.codigo_articulo
		WHERE codigo_factura = @CODIGO_FACTURA;
	END
GO

CREATE PROCEDURE agregarArticulo
@codigo_articulo INT,
@DEC VARCHAR,
@PRECIO DECIMAL,
@CATEGORIA VARCHAR

AS
	BEGIN
		INSERT INTO Articulo  VALUES (@codigo_articulo,@DEC  , @PRECIO, @CATEGORIA);
	END
GO

CREATE PROCEDURE borrarArticulo
@CODIGO INT
AS
	BEGIN
		DELETE Usuario WHERE codigo_usuario = @CODIGO
	END
GO
 