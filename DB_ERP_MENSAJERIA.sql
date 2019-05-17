USE master
DROP DATABASE ERP_Mensajeria
GO
CREATE DATABASE ERP_Mensajeria
GO
USE ERP_Mensajeria
GO

CREATE TABLE Edificio (
	ID_Edificio INT IDENTITY (1, 1) NOT NULL,
	Nombre VARCHAR (255) NOT NULL,
	Detalle TEXT,
	Ubicacion VARCHAR (100) DEFAULT 'Oficina',
	Estado VARCHAR (20) DEFAULT 'Activo',
	CONSTRAINT PK_Edificio PRIMARY KEY (ID_Edificio)
);

CREATE TABLE Nivel (
	ID_Nivel INT IDENTITY (1, 1) NOT NULL,
	ID_Edificio INT NOT NULL,
	Nombre VARCHAR (255) NOT NULL,
	Detalle TEXT, 
	Estado VARCHAR (20) DEFAULT 'ACTIVO',
	CONSTRAINT PK_Nivel PRIMARY KEY (ID_Nivel),
	CONSTRAINT FK_Edificio_Nivel FOREIGN KEY (ID_Edificio) REFERENCES Edificio (ID_Edificio)
);

CREATE TABLE Empresa (
	ID_Empresa INT IDENTITY (1, 1) NOT NULL,
	ID_Nivel INT NOT NULL,
	Nombre VARCHAR (255) NOT NULL,
	TipoEmpresa VARCHAR (200) DEFAULT NULL,
	Detalle TEXT,
	Telefono VARCHAR (20) DEFAULT NULL,
	Correo VARCHAR (100) DEFAULT NULL,
	PBX VARCHAR (100) DEFAULT NULL,
	NIT VARCHAR (100) DEFAULT NULL,
	Encargado VARCHAR (100) DEFAULT NULL,
	CONSTRAINT PK_Empresa PRIMARY KEY (ID_Empresa),
	CONSTRAINT FK_Empresa_Nivel FOREIGN KEY (ID_Nivel) REFERENCES Nivel (ID_Nivel)
);

CREATE TABLE Oficina (
	ID_Oficina INT IDENTITY (1, 1) NOT NULL,
	ID_Empresa INT NOT NULL,
	Nombre VARCHAR (100) NOT NULL,
	Detalle TEXT,
	Estado VARCHAR (20) DEFAULT 'ACTIVO',
	CONSTRAINT PK_Oficina PRIMARY KEY (ID_Oficina),
	CONSTRAINT PK_Empresa_Oficina FOREIGN KEY (ID_Empresa) REFERENCES Empresa (ID_Empresa)
);

CREATE TABLE Proveedor (
	ID_Proveedor INT IDENTITY (1, 1) NOT NULL,
	ID_Empresa INT NOT NULL,
	Nombre VARCHAR (100) NOT NULL,
	Detalle TEXT,
	CONSTRAINT PK_Proveedor PRIMARY KEY (ID_Proveedor),
	CONSTRAINT FK_Empresa_Proveedor FOREIGN KEY (ID_Empresa) REFERENCES Empresa (ID_Empresa)
);

CREATE TABLE SolicitudProveedor (
	ID_SolicitudProveedor INT IDENTITY (1, 1) NOT NULL,
	ID_Proveedor INT NOT NULL,
	Fecha_Ingreso DATE NOT NULL,
	Hora_Ingreso TIME NOT NULL,
	Fecha_Creacion DATETIME DEFAULT GETDATE(),
	Descripcion_Corta VARCHAR (100) DEFAULT NULL,
	Elevador VARCHAR (100) DEFAULT 'NO',
	/** Espera, Entregado, Accesando, Saliendo*/
	Estado_Entrega VARCHAR (100) DEFAULT 'En Espera',
	Entregado VARCHAR (100) DEFAULT 'NO',
	Aprobado VARCHAR (100) DEFAULT 'NO',
	Tipo VARCHAR (100) DEFAULT 'ENTRADA', /**Entrada, Salida*/
	CONSTRAINT PK_SolicitudProveedor PRIMARY KEY (ID_SolicitudProveedor),
	CONSTRAINT FK_Proveedor_SolicitudProveedor FOREIGN KEY (ID_Proveedor) REFERENCES Proveedor (ID_Proveedor)
);

CREATE TABLE Paquete (
	ID_Paquete INT IDENTITY (1, 1) NOT NULL,
	ID_SolicitudProveedor INT NOT NULL,
	Descripcion VARCHAR (255) DEFAULT NULL,
	Detalle TEXT DEFAULT NULL,
	Estado VARCHAR (100) DEFAULT 'Activo',
	Extra TEXT DEFAULT NULL,
	CONSTRAINT PK_Paquete PRIMARY KEY (ID_Paquete),
	CONSTRAINT FK_SolicitudProveedor_Paquete FOREIGN KEY (ID_SolicitudProveedor) REFERENCES SolicitudProveedor (ID_SolicitudProveedor)
);

CREATE TABLE TipoUsuario (
	ID_TipoUsuario INT IDENTITY (1, 1) NOT NULL,
	Nombre VARCHAR (255) NOT NULL,
	Detalle TEXT,
	Estado VARCHAR (100) DEFAULT 'Activo',
	CONSTRAINT PK_TipoUsuario PRIMARY KEY (ID_TipoUsuario)
);

CREATE TABLE Contacto (
	ID_Contacto INT IDENTITY (1, 1) NOT NULL,
	Nombre VARCHAR (255) NOT NULL,
	CUI VARCHAR (100) NOT NULL,
	Correo VARCHAR (100) NOT NULL,
	Gafete VARCHAR (100) DEFAULT NULL,
	CONSTRAINT PK_Contacto PRIMARY KEY (ID_Contacto)
);

CREATE TABLE Usuario (
	ID_Usuario INT IDENTITY (1, 1) NOT NULL,
	ID_TipoUsuario INT NOT NULL,
	Nombre VARCHAR (255) NOT NULL,
	CUI VARCHAR (100) NOT NULL,
	Telefono VARCHAR (20) DEFAULT NULL,
	Correo VARCHAR (100) DEFAULT NULL,
	Estado VARCHAR (100) DEFAULT 'Activo',
	CONSTRAINT PK_Usuario PRIMARY KEY (ID_Usuario),
	CONSTRAINT FK_TipoUsuario_Usuario FOREIGN KEY (ID_TipoUsuario) REFERENCES TipoUsuario (ID_TipoUsuario)
);

CREATE TABLE Entrega (
	ID_Entrega INT IDENTITY (1, 1) NOT NULL,
	ID_Empresa INT NOT NULL,
	ID_Proveedor INT NOT NULL,
	ID_Contacto INT NOT NULL,
	No_Paquetes INT DEFAULT 0,
	Anticipada VARCHAR (100) DEFAULT 'N0'
	CONSTRAINT PK_Entrega PRIMARY KEY (ID_Entrega),
	CONSTRAINT FK_Empresa_Entrega FOREIGN KEY (ID_Empresa) REFERENCES Empresa (ID_Empresa),
	CONSTRAINT FK_Proveedor_Entrega FOREIGN KEY (ID_Proveedor) REFERENCES Proveedor (ID_Proveedor),
	CONSTRAINT FK_Contacto_Entrega FOREIGN KEY (ID_Contacto) REFERENCES Contacto (ID_Contacto)
);

CREATE TABLE Recepcion (
	ID_Recepcion INT IDENTITY (1, 1) NOT NULL,
	ID_Contacto INT NOT NULL,
	ID_Proveedor INT NOT NULL,
	Tipo VARCHAR (100) DEFAULT 'ENTRADA'
	CONSTRAINT PK_Recepcion PRIMARY KEY (ID_Recepcion),
	CONSTRAINT FK_Contacto_Recepcion FOREIGN KEY (ID_Contacto) REFERENCES Contacto (ID_Contacto),
	CONSTRAINT FK_Proveedor_Recepcion FOREIGN KEY (ID_Proveedor) REFERENCES Proveedor (ID_Proveedor)
);

CREATE TABLE RutaEntrega (
	ID_RutaEntrega INT IDENTITY (1, 1) NOT NULL,
	ID_Empresa INT NOT NULL,
	ID_Proveedor INT NOT NULL,
	ORDEN VARCHAR (100) DEFAULT 'ASCENDENTE',
	CONSTRAINT PK_RutaEntrega PRIMARY KEY (ID_RutaEntrega),
	CONSTRAINT PK_Empresa_RutaEntrega FOREIGN KEY (ID_Empresa) REFERENCES Empresa (ID_Empresa),
	CONSTRAINT PK_Proveedor_RutaEntrega FOREIGN KEY (ID_Proveedor) REFERENCES Proveedor (ID_Proveedor)
);