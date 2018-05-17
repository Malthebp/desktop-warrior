USE peterrytter_net_db 

GO

DROP TABLE IF EXISTS dg_CategoriesTypes;
DROP TABLE IF EXISTS dg_ProductsTypes;
DROP TABLE IF EXISTS dg_Types;
DROP TABLE IF EXISTS dg_Specifications;
DROP TABLE IF EXISTS dg_Products;
DROP TABLE IF EXISTS dg_Categories;

CREATE TABLE dg_Categories 
(
	CategoryId INT IDENTITY(1,1),
	Title NVARCHAR(100),
	Description NTEXT,
	Video NVARCHAR(200),
	Icon NTEXT,
	PRIMARY KEY (CategoryId)
);
 
CREATE TABLE dg_Types 
(
	TypeId INT IDENTITY (1,1),
	ParentId INT NULL,
	Title NVARCHAR(100),
	Description NTEXT,
	PRIMARY KEY (TypeId),
	FOREIGN KEY (ParentId) REFERENCES dg_Types(TypeId)
);

CREATE TABLE dg_Products 
(
	ProductId INT IDENTITY(1,1),
	CategoryId INT NULL,
	Title NVARCHAR(100),
	Description NTEXT,
	Video NVARCHAR(200),
	Image NVARCHAR(100),
	Price DECIMAL(10, 2), 
	Stock INT,
	PRIMARY KEY (ProductId),
	FOREIGN KEY (CategoryId) REFERENCES dg_Categories(CategoryId)
);

CREATE TABLE dg_Specifications 
(
	SpecificationId INT IDENTITY (1,1),
	ProductId INT NULL,
	Title NVARCHAR(100),
	Description NTEXT,
	PRIMARY KEY (SpecificationId),
	FOREIGN KEY (ProductId) REFERENCES dg_Products(ProductId)
);

CREATE TABLE dg_ProductsTypes 
(
	ProductId INT,
	TypeId INT,
	PRIMARY KEY (ProductId, TypeId),
	FOREIGN KEY (ProductId) REFERENCES dg_Products(ProductId),
	FOREIGN KEY (TypeId) REFERENCES dg_Types(TypeId),
);

CREATE TABLE dg_CategoriesTypes 
(
	CategoryId INT,
	TypeId INT,
	PRIMARY KEY (CategoryId, TypeId),
	FOREIGN KEY (CategoryId) REFERENCES dg_Categories(CategoryId),
	FOREIGN KEY (TypeId) REFERENCES dg_Types(TypeId),
);

GO

IF (OBJECT_ID('PopulateTables') IS NOT NULL)
  DROP PROCEDURE PopulateTables

GO 

CREATE PROC PopulateTables
AS
BEGIN

	INSERT INTO dg_Categories (Title, Description, Video) VALUES 
		('CPU', 'CPU (pronounced as separate letters) is the abbreviation for central processing unit. Sometimes referred to simply as the central processor, but more commonly called processor, the CPU is the brains of the computer where most calculations take place.', 'https://youtu.be/sHqNMHf2UNI'),
		('CPU Cooler', 'A CPU cooler is device designed to draw heat away from the system CPU and other components in the enclosure. Using a CPU cooler to lower CPU temperatures improves efficiency and stability of the system. Adding a cooling device, however, can increase the overall noise level of the system.', 'https://youtu.be/nQIB5qcl3R8'),
		('Motherboard', 'Motherboard: Definition. A motherboard is one of the most essential parts of a computer system. It holds together many of the crucial components of a computer, including the central processing unit (CPU), memory and connectors for input and output devices.', 'https://youtu.be/0xZc7YryJ0U'),
		('Memory', 'Computer memory is any physical device capable of storing information temporarily or permanently. For example, Random Access Memory (RAM), is a volatile memory that stores information on an integrated circuit used by the operating system, software, and hardware.', 'https://youtu.be/dZcszUj5szA'),
		('Graphics Card', 'A video card connects to the motherboard of a computer system and generates output images to display. Video cards are also referred to as graphics cards. Video cards include a processing unit, memory, a cooling mechanism and connections to a display device.', 'https://youtu.be/c3BKuNXdM5A'),
		('Storage', 'A storage device is any computing hardware that is used for storing, porting and extracting data files and objects. It can hold and store information both temporarily and permanently, and can be internal or external to a computer, server or any similar computing device.', 'https://youtu.be/YQEjGKYXjw8'),
		('Power Supply (PSU)', 'A power supply is a component that supplies power to at least one electric load. Typically, it converts one type of electrical power to another, but it may also convert a a different form of energy – such as solar, mechanical, or chemical - into electrical energy. A power supply provides components with electric power.', 'https://youtu.be/lqThn3C-zg4'),
		('Case (Chassis)', 'A computer case, also known as a computer chassis, tower, system unit, cabinet, or base unit, is the enclosure that contains most of the components of a computer (usually excluding the display, keyboard and mouse).', 'https://youtu.be/aEHDTJMqmpc'),
		('Operating System', 'An operating system (OS) is system software that manages computer hardware and software resources and provides common services for computer programs.', 'https://youtu.be/MR2ntdZW__A');


	INSERT INTO dg_Types(ParentId, Title, Description) VALUES
	/* Socket Size - Needed for CPU, CPU Cooler and Motherboard */
	(null, 'Socket', 'The processor socket (also called a CPU socket) is the connector on the motherboard that houses a CPU and forms the electrical interface and contact with the CPU. Processor sockets use a pin grid array (PGA) where pins on the underside of the processor connect to holes in the processor socket.'),
	(1, 'AM1', null),
	(1, 'AM2', null),
	(1, 'AM2+/AM2', null),
	(1, 'AM3', null),
	(1, 'AM3+', null),
	(1, 'AM3+/AM3', null),
	(1, 'AM3/AM2+', null),
	(1, 'AM3/AM2+/AM2', null),
	(1, 'AM4', null),
	(1, 'FM1', null),
	(1, 'FM2', null),
	(1, 'FM2+', null),
	(1, 'G34 x 2', null),
	(1, 'LGA775', null),
	(1, 'LGA1150', null),
	(1, 'LGA1151', null),
	(1, 'LGA1155', null),

	/* Motherboard size - Needed for Motherboards and Case compatibility */
	(null, 'Motherboard size', 'Motherboard form factors: Determines general layout, size and feature placement on the motherboard. Form factors such as physical size, shape, component placement, power supply connectors etc. Various form factors of motherboards are AT, Baby AT, ATX, Mini-ATX, Micro-ATX, Flex ATX, LPX and Mini LPX and NLX.'),
	(19, 'ATX', null),
	(19, 'EATX', null),
	(19, 'Flex ATX', null),
	(19, 'HPTX', null),
	(19, 'Micro ATX', null),
	(19, 'Mini DTX', null),
	(19, 'Mini ITX', null),
	(19, 'SSI CEB', null),
	(19, 'SSI EEB', null),
	(19, 'Thin Mini ITX', null),
	(19, 'XL ATX', null),

	/* Memory technology - Needed for Motherboard and Memory compatibility */
	(null, 'Memory technology', 'DDR SDRAM is a double data rate synchronous dynamic random-access memory class of memory integrated circuits used in computers. DDR SDRAM, also called DDR1 SDRAM, has been superseded by DDR2 SDRAM, DDR3 SDRAM and DDR4 SDRAM.'),
	(31, 'DDR2', null),
	(31, 'DDR3', null),
	(31, 'DDR4', null)

	INSERT INTO dg_CategoriesTypes VALUES
	(1, 1),
	(2, 1),
	(3, 1),
	(3, 19),
	(8, 19),
	(3, 31),
	(4, 31)

	INSERT INTO dg_Products(CategoryId, Title, Description, Video, Image, Price, Stock) VALUES
	(1, 'Intel Core i7-6700K Skylake Processor', 'Socket-LGA1151, Quad Core 4.0GHz, 8MB, 91W, 14nm, Boxed, u/køler', 'https://youtu.be/fQ63w5_vXbg', 'https://images-na.ssl-images-amazon.com/images/I/812WLoBXlfL._SX425_.jpg', 2499.95, 5),
	(2, 'Cooler Master Hyper 212 Evo', '115x/2011/2011-3/2066, AM2/AM3, 600~1600 RPM, 66 CFM, 9~31 dBA', 'https://youtu.be/BKZ6FmPdY_0', 'https://www.komplett.dk/img/p/800/85f62d98-65d7-4d55-9088-1531ca83223a.jpg', 269, 20),
	(3, 'Gigabyte GA-AX370-Gaming K7', 'Bundkort, ATX, X370, DDR4, 3xPCIe-x16, M.2, Killer E2500, Intel GbLAN, USB 3.1', '', 'https://www.komplett.dk/img/p/800/eda1d55a-b98d-3234-8c76-a6a9c66a8d4a.jpg', 1529, 17),
	(2, 'Cooler Master', 'hdjsahdjkas', 'https://youtu.be/BKZ6FmPdY_0', 'https://www.komplett.dk/img/p/800/85f62d98-65d7-4d55-9088-1531ca83223a.jpg', 225, 10)

	INSERT INTO dg_ProductsTypes VALUES
	(1, 17),
	(2, 4),
	(2, 7),
	(2, 16),
	(2, 17),
	(2, 18),
	(3, 31),
	(3, 20),
	(4, 16)



END
GO

EXEC PopulateTables;
GO


--CREATE PROC dbo.getProducts
--	@CategoryID VARCHAR(10),
--	@ChildIDs VARCHAR(1000)
--AS
--	declare @sql nvarchar(max)
--	set @sql = 'SELECT p.*, pt.* FROM dg_Products p
--	LEFT JOIN dg_ProductsTypes as pt ON pt.ProductId = p.ProductId
--	WHERE p.CategoryId = '+@categoryID+' AND pt.TypeId IN('+@ChildIDs+') OR pt.TypeId IS null'

--	EXEC sp_executesql @sqll

--DROP PROC dbo.getProducts;

--EXEC dbo.getProducts 2, '17,4';