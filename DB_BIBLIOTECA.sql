--CREATE DATABASE DB_BIBLIOTECA;
GO
USE DB_BIBLIOTECA;
GO

CREATE SCHEMA libro;
GO

CREATE SCHEMA maestros;

GO
CREATE SCHEMA comercial;

GO

CREATE SCHEMA prestamo;
GO

GO

CREATE TABLE maestros.Producto (
    nIdProducto INT PRIMARY KEY IDENTITY(1,1),
    sNombre VARCHAR(100) NOT NULL,
    sDescripcion VARCHAR(255),
    nPrecio DECIMAL(10,2) NOT NULL,
    sTipo VARCHAR(30) NOT NULL, -- Ej: 'Libro', 'Revista', 'Accesorio'
    nIdUsuarioCrea INT NOT NULL,
    dFechaCrea DATETIME NOT NULL DEFAULT GETDATE()
);

GO


CREATE TABLE libro.Libro (
    nIdLibro INT PRIMARY KEY IDENTITY(1,1),
    nIdProducto INT NOT NULL,
    sAutor VARCHAR(100) NOT NULL,
    sDocumento VARCHAR(100) NOT NULL,
    sISBN VARCHAR(100) NOT NULL,
    sCategoria VARCHAR(100) NOT NULL,
    sEditorial VARCHAR(100) NOT NULL,
    nIdUsuarioCrea INT NOT NULL
);

GO

CREATE TABLE libro.Estante (
    nIdEstante INT PRIMARY KEY IDENTITY(1,1),
    sSeccion VARCHAR(10) NOT NULL,
    nNumero INT NOT NULL
);

GO

CREATE TABLE libro.CopiaLibro (
    nIdCopia INT PRIMARY KEY IDENTITY(1,1),
    nIdLibro INT NOT NULL,
    sCodigoBarras VARCHAR(100) NOT NULL UNIQUE,
	  nPrecioVenta DECIMAL(10,2) NOT NULL,
	  nPrecioAlquiler DECIMAL(10,2) NOT NULL,
    sEstado VARCHAR(20) NOT NULL,
    nIdEstante INT NOT NULL,

    CONSTRAINT FK_CopiaLibro_Libro FOREIGN KEY (nIdLibro) REFERENCES libro.Libro(nIdLibro),
	CONSTRAINT FK_CopiaLibro_Estante FOREIGN KEY (nIdEstante) REFERENCES libro.Estante(nIdEstante)
);

GO

CREATE TABLE maestros.Persona (
    nIdPersona INT PRIMARY KEY IDENTITY(1,1),
    sNombres VARCHAR(100) NOT NULL,
    sApellidos VARCHAR(100) NOT NULL,
    sDocumentoIdentidad VARCHAR(20) NOT NULL UNIQUE,
    sTelefono VARCHAR(20) NOT NULL,
    sEmail VARCHAR(100) NOT NULL,
    sDireccion VARCHAR(255) NOT NULL,
    sUbigeo VARCHAR(10) NOT NULL
);

GO


CREATE TABLE comercial.Cliente (
    nIdCliente INT PRIMARY KEY IDENTITY(1,1),
    nIdPersona INT NOT NULL,
    nIdUsuarioCrea INT NOT NULL,
    dFechaCrea DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Cliente_Persona FOREIGN KEY (nIdPersona) REFERENCES maestros.Persona(nIdPersona)
);

GO

CREATE TABLE prestamo.Prestamo (
    nIdPrestamo INT PRIMARY KEY IDENTITY(1,1),
    nIdCliente INT NOT NULL,
    dFechaPrestamo DATETIME NOT NULL,
    dFechaDevolucion DATETIME NULL,
    sEstado VARCHAR(20) NOT NULL,
    nIdCopia INT NOT NULL,
    nIdTransaccion INT NULL,
    nIdUsuarioCrea INT NOT NULL,

    CONSTRAINT FK_Prestamo_Cliente FOREIGN KEY (nIdCliente) REFERENCES comercial.Cliente(nIdCliente),
    CONSTRAINT FK_Prestamo_CopiaLibro FOREIGN KEY (nIdCopia) REFERENCES libro.CopiaLibro(nIdCopia)
);


GO

-- INTERT LIBROS TEST
INSERT INTO libro.Libro (nIdProducto, sAutor, sDocumento, sISBN, sCategoria, sEditorial, nIdUsuarioCrea) VALUES 
(101, 'Gabriel García Márquez', 'Cien años de soledad', '1234567890', 'Novela', 'Sudamericana', 1),
(102, 'Mario Vargas Llosa', 'La ciudad y los perros', '2345678901', 'Novela', 'Seix Barral', 1),
(103, 'Isabel Allende', 'La casa de los espíritus', '3456789012', 'Ficción', 'Plaza & Janés', 2),
(104, 'Julio Cortázar', 'Rayuela', '4567890123', 'Literatura', 'Sudamericana', 2),
(105, 'Jorge Luis Borges', 'Ficciones', '5678901234', 'Filosofía', 'Emecé Editores', 3);

GO


INSERT INTO libro.Estante (sSeccion, nNumero) VALUES ('A', 1);
INSERT INTO libro.Estante (sSeccion, nNumero) VALUES ('A', 2);
INSERT INTO libro.Estante (sSeccion, nNumero) VALUES ('B', 1);
INSERT INTO libro.Estante (sSeccion, nNumero) VALUES ('B', 2);
INSERT INTO libro.Estante (sSeccion, nNumero) VALUES ('C', 1);

GO


INSERT INTO libro.CopiaLibro (nIdLibro, sCodigoBarras, nPrecioVenta, nPrecioAlquiler, sEstado, nIdEstante) VALUES (1, 'QR1001', 30, 14 , 'Disponible', 1);
INSERT INTO libro.CopiaLibro (nIdLibro, sCodigoBarras, nPrecioVenta, nPrecioAlquiler, sEstado, nIdEstante) VALUES (2, 'QR1002', 15, 7, 'Disponible', 2);
INSERT INTO libro.CopiaLibro (nIdLibro, sCodigoBarras, nPrecioVenta, nPrecioAlquiler, sEstado, nIdEstante) VALUES (3, 'QR1003', 25, 12, 'Disponible', 3);
INSERT INTO libro.CopiaLibro (nIdLibro, sCodigoBarras, nPrecioVenta, nPrecioAlquiler, sEstado, nIdEstante) VALUES (4, 'QR1004', 50, 24, 'Disponible', 4);
INSERT INTO libro.CopiaLibro (nIdLibro, sCodigoBarras, nPrecioVenta, nPrecioAlquiler, sEstado, nIdEstante) VALUES (5, 'QR1005', 60, 29, 'Disponible', 5);

GO


INSERT INTO maestros.Persona (sNombres, sApellidos, sDocumentoIdentidad, sTelefono, sEmail, sDireccion, sUbigeo) VALUES 
('Juan', 'Pérez', '12345678', '999888777', 'juan@mail.com', 'Calle Falsa 123', '150101');

INSERT INTO maestros.Persona (sNombres, sApellidos, sDocumentoIdentidad, sTelefono, sEmail, sDireccion, sUbigeo) VALUES 
('Lucía', 'Gómez', '23456789', '988877766', 'lucia@mail.com', 'Av. Siempre Viva 742', '150102');

INSERT INTO maestros.Persona (sNombres, sApellidos, sDocumentoIdentidad, sTelefono, sEmail, sDireccion, sUbigeo) VALUES 
('Carlos', 'Ramírez', '34567890', '977766655', 'carlos@mail.com', 'Jr. Los Olivos 456', '150103');

INSERT INTO maestros.Persona (sNombres, sApellidos, sDocumentoIdentidad, sTelefono, sEmail, sDireccion, sUbigeo) VALUES 
('Ana', 'Torres', '45678901', '966655544', 'ana@mail.com', 'Psj. Las Flores 678', '150104');

INSERT INTO maestros.Persona (sNombres, sApellidos, sDocumentoIdentidad, sTelefono, sEmail, sDireccion, sUbigeo) VALUES 
('Pedro', 'López', '56789012', '955544433', 'pedro@mail.com', 'Mz. A Lt. 9', '150105');

GO


INSERT INTO comercial.Cliente (nIdPersona, nIdUsuarioCrea, dFechaCrea) VALUES (1, 1, GETDATE());
INSERT INTO comercial.Cliente (nIdPersona, nIdUsuarioCrea, dFechaCrea) VALUES (2, 1, GETDATE());
INSERT INTO comercial.Cliente (nIdPersona, nIdUsuarioCrea, dFechaCrea) VALUES (3, 2, GETDATE());
INSERT INTO comercial.Cliente (nIdPersona, nIdUsuarioCrea, dFechaCrea) VALUES (4, 2, GETDATE());
INSERT INTO comercial.Cliente (nIdPersona, nIdUsuarioCrea, dFechaCrea) VALUES (5, 3, GETDATE());

GO

CREATE PROCEDURE [prestamo].[pa_prestamo] -- EXEC prestamo.pa_prestamo params...
    @nIdCliente INT,
    @dFechaPrestamo DATETIME,
    @sEstado VARCHAR(20),
    @nIdCopia INT,
    @nIdTransaccion INT = NULL,
    @nIdUsuarioCrea INT
AS
BEGIN
    DECLARE @nCod INT, @sMsj VARCHAR(255)
    DECLARE @bValido BIT = 1
    DECLARE @nCant INT

    -- Validar cliente existe
    IF NOT EXISTS (SELECT 1 FROM comercial.Cliente WHERE nIdCliente = @nIdCliente)
    BEGIN
        SET @bValido = 0
        SET @nCod = 0
        SET @sMsj = 'El cliente no existe.'
    END

    -- Validar copia disponible
    IF @bValido = 1
    BEGIN

        SELECT @nCant = COUNT(*) FROM libro.CopiaLibro WHERE nIdCopia = @nIdCopia AND sEstado = 'Disponible'
        IF @nCant = 0
        BEGIN
            SET @bValido = 0
            SET @nCod = 0
            SET @sMsj = 'La copia del libro no está disponible.'
        END
    END

    -- Validar que el cliente no tenga más de 3 préstamos activos
    IF @bValido = 1
    BEGIN
        SELECT @nCant = COUNT(*) FROM prestamo.Prestamo WHERE nIdCliente = @nIdCliente AND sEstado = 'Prestado'
        IF @nCant >= 3
        BEGIN
            SET @bValido = 0
            SET @nCod = 0
            SET @sMsj = 'El cliente ya tiene 3 préstamos activos.'
        END
    END
	
    IF @bValido = 1
    BEGIN
        BEGIN TRANSACTION InsPrestamo
        BEGIN TRY
            INSERT INTO prestamo.Prestamo (
                nIdCliente,
                dFechaPrestamo,
                sEstado,
                nIdCopia,
                nIdTransaccion,
                nIdUsuarioCrea
            )
            VALUES (
                @nIdCliente,
                @dFechaPrestamo,
                @sEstado,
                @nIdCopia,
                @nIdTransaccion,
                @nIdUsuarioCrea
            )

            SET @nCod = SCOPE_IDENTITY()
            SET @sMsj = 'Préstamo registrado correctamente.'

            -- Marcar copia como prestada
            UPDATE libro.CopiaLibro
            SET
				sEstado = 'Prestado'
            WHERE
				nIdCopia = @nIdCopia

        END TRY
        BEGIN CATCH
            SET @nCod = 0
            SET @sMsj = ERROR_MESSAGE()
            IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION InsPrestamo
        END CATCH

        IF @@TRANCOUNT > 0 COMMIT TRANSACTION InsPrestamo
    END

    SELECT @nCod AS nCod, @sMsj AS sMsj
END


GO

CREATE PROCEDURE [prestamo].[pa_prestamo];2
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.nIdPrestamo,
        p.nIdCliente,
        per.sNombres + ' ' + per.sApellidos AS sClienteNombre,
        p.dFechaPrestamo,
        p.dFechaDevolucion,
        p.sEstado,
        p.nIdCopia,
        c.sCodigoBarras,
        l.sDocumento AS sTituloLibro,
        l.sAutor,
        c.nPrecioVenta,
		c.nPrecioAlquiler,
        p.nIdTransaccion,
        p.nIdUsuarioCrea
    FROM prestamo.Prestamo p
    INNER JOIN comercial.Cliente cli ON cli.nIdCliente = p.nIdCliente
    INNER JOIN maestros.Persona per ON per.nIdPersona = cli.nIdPersona
    INNER JOIN libro.CopiaLibro c ON c.nIdCopia = p.nIdCopia
    INNER JOIN libro.Libro l ON l.nIdLibro = c.nIdLibro
    ORDER BY p.dFechaPrestamo DESC;
END

GO

CREATE PROCEDURE [libro].[pa_libro_disponibles]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        l.nIdLibro AS nCod,
        l.sDocumento AS sDesc
    FROM libro.Libro l
    INNER JOIN libro.CopiaLibro c ON c.nIdLibro = l.nIdLibro
    WHERE c.sEstado = 'Disponible'
    ORDER BY l.sDocumento;
END


GO

CREATE PROCEDURE [libro].[pa_libro_disponibles];2 -- EXEC [libro].[pa_libro_disponibles];2 3
    @nIdLibro INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.nIdCopia AS nCod,
        CONCAT(l.sDocumento, ' | ', c.sCodigoBarras, ' | ', e.sSeccion, ' | ', e.nNumero) AS sDesc
    FROM libro.CopiaLibro c
    INNER JOIN libro.Estante e ON e.nIdEstante = c.nIdEstante
	INNER JOIN libro.Libro l ON c.nIdLibro = l.nIdLibro
    WHERE c.nIdLibro = @nIdLibro
      AND c.sEstado = 'Disponible'
    ORDER BY c.sCodigoBarras;
END
