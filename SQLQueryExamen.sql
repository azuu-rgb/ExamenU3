-- Crear la base de datos
CREATE DATABASE TiendasDB;
GO

-- Usar la base de datos
USE TiendasDB;
GO

-- Crear tablas
CREATE TABLE Tienda (
    id_tienda INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    direccion NVARCHAR(MAX),
    ciudad NVARCHAR(50)
);

CREATE TABLE Empleado (
    id_empleado INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    puesto NVARCHAR(50),
    salario DECIMAL(10, 2),
    id_tienda INT NOT NULL,
    FOREIGN KEY (id_tienda) REFERENCES Tienda(id_tienda)
);
select id_empleado as ID, e.nombre as NOMBRE, puesto as PUESTO, salario as SALARIO,id_tienda as TIENDA 
FROM Empleado e
JOIN TIENDA t on e.id_tienda=t.id_tienda ;

SELECT 
    e.id_empleado AS ID,
    e.nombre AS NOMBRE,
    e.puesto AS PUESTO,
    e.salario AS SALARIO,
    t.nombre AS TIENDA
FROM Empleado e
JOIN Tienda t ON e.id_tienda = t.id_tienda;

CREATE TABLE Categoria (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    descripcion NVARCHAR(MAX)
);

CREATE TABLE Proveedor (
    id_proveedor INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    telefono NVARCHAR(20),
    correo NVARCHAR(100)
);

CREATE TABLE Producto (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    precio DECIMAL(10, 2),
    id_categoria INT NOT NULL,
    id_proveedor INT NOT NULL,
    FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedor(id_proveedor)
);

CREATE TABLE Inventario (
    id_tienda INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL DEFAULT 0,
    PRIMARY KEY (id_tienda, id_producto),
    FOREIGN KEY (id_tienda) REFERENCES Tienda(id_tienda),
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);

CREATE TABLE Cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    correo NVARCHAR(100),
    telefono NVARCHAR(20)
);

CREATE TABLE Venta (
    id_venta INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT NOT NULL,
    id_empleado INT NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado)
);

CREATE TABLE DetalleVenta (
    id_venta INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (id_venta, id_producto),
    FOREIGN KEY (id_venta) REFERENCES Venta(id_venta),
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);

-- Tiendas
INSERT INTO Tienda (nombre, direccion, ciudad) VALUES
('Tienda Central', 'Av. Reforma 123', 'Ciudad de México'),
('Sucursal Norte', 'Calle Hidalgo 45', 'Monterrey'),
('Sucursal Sur', 'Av. Las Torres 678', 'Guadalajara');

-- Empleados
INSERT INTO Empleado (nombre, puesto, salario, id_tienda) VALUES
('Ana Gómez', 'Gerente', 15000.00, 1),
('Luis Pérez', 'Cajero', 8500.00, 1),
('Marta López', 'Vendedor', 9000.00, 2),
('Carlos Ramírez', 'Cajero', 8700.00, 3);

-- Categorías
INSERT INTO Categoria (nombre, descripcion) VALUES
('Papelería', 'Artículos escolares y de oficina'),
('Tecnología', 'Dispositivos electrónicos'),
('Limpieza', 'Productos para aseo personal y hogar');

-- Proveedores
INSERT INTO Proveedor (nombre, telefono, correo) VALUES
('Distribuidora Norte', '555-1234', 'ventas@norte.com'),
('TecnoLog', '555-5678', 'contacto@tecnolog.mx'),
('CleanIt', '555-9012', 'info@cleanit.com');

-- Productos
INSERT INTO Producto (nombre, precio, id_categoria, id_proveedor) VALUES
('Cuaderno Profesional', 45.00, 1, 1),
('Bolígrafo Azul', 10.00, 1, 1),
('Mouse Óptico', 150.00, 2, 2),
('Teclado USB', 250.00, 2, 2),
('Detergente 1L', 30.00, 3, 3),
('Desinfectante Spray', 40.00, 3, 3);

-- Inventario
INSERT INTO Inventario (id_tienda, id_producto, cantidad) VALUES
(1, 1, 100),
(1, 2, 200),
(1, 3, 50),
(2, 4, 40),
(2, 5, 80),
(3, 6, 60);

-- Clientes
INSERT INTO Cliente (nombre, correo, telefono) VALUES
('Laura Méndez', 'laura.m@mail.com', '5511223344'),
('José Torres', 'jose.t@mail.com', '5522334455'),
('María Fernanda', 'mf_fernanda@mail.com', '5533445566');

-- Ventas
INSERT INTO Venta (id_cliente, id_empleado, fecha) VALUES
(1, 2, '2024-05-01 10:30'),
(2, 3, '2024-05-02 13:45'),
(3, 4, '2024-05-03 16:20');

-- DetalleVenta
INSERT INTO DetalleVenta (id_venta, id_producto, cantidad, precio_unitario) VALUES
(1, 1, 2, 45.00),
(1, 2, 3, 10.00),
(2, 4, 1, 250.00),
(2, 5, 2, 30.00),
(3, 6, 1, 40.00);


Insert into Producto values ()