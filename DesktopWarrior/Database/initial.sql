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

	INSERT INTO dg_Categories (Title, Description, Video, Icon) VALUES 
		('CPU', 'CPU (pronounced as separate letters) is the abbreviation for central processing unit. Sometimes referred to simply as the central processor, but more commonly called processor, the CPU is the brains of the computer where most calculations take place.', 'https://www.youtube.com/embed/sHqNMHf2UNI', '<?xml version="1.0" encoding="UTF-8"?>
			<!DOCTYPE svg  PUBLIC "-//W3C//DTD SVG 1.1//E"  "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
			<svg enable-background="new 0 0 302.298 302.298" version="1.1" viewBox="0 0 302.298 302.298" xml:space="preserve" xmlns="http://www.w3.org/2000/svg">
			<path d="m287.3 144.15c8.284 0 15-6.716 15-15s-6.716-15-15-15h-36.483v-12h36.483c8.284 0 15-6.716 15-15s-6.716-15-15-15h-39.335c-3.575-6-9.736-9-16.735-9h-1.412v-37.381c0-8.284-6.716-15-15-15s-15 6.716-15 15v37.381h-13v-37.381c0-8.284-6.716-15-15-15s-15 6.716-15 15v37.381h-12v-37.381c0-8.284-6.716-15-15-15s-15 6.716-15 15v37.381h-13v-37.381c0-8.284-6.716-15-15-15s-15 6.716-15 15v37.381h-0.489c-7 0-13.161 3-16.735 9h-39.592c-8.284 0-15 6.716-15 15s6.716 15 15 15h35.815v12h-35.815c-8.284 0-15 6.716-15 15s6.716 15 15 15h35.815v13h-35.815c-8.284 0-15 6.716-15 15s6.716 15 15 15h35.815v13h-35.815c-8.284 0-15 6.716-15 15s6.716 15 15 15h39.59c3.574 5 9.736 9 16.736 9h0.489v37.381c0 8.284 6.716 15 15 15s15-6.716 15-15v-37.381h13v37.381c0 8.284 6.716 15 15 15s15-6.716 15-15v-37.381h12v37.381c0 8.284 6.716 15 15 15s15-6.716 15-15v-37.381h13v37.381c0 8.284 6.716 15 15 15s15-6.716 15-15v-37.381h1.412c7 0 13.161-4 16.736-9h39.335c8.284 0 15-6.716 15-15s-6.716-15-15-15h-36.483v-13h36.483c8.284 0 15-6.716 15-15s-6.716-15-15-15h-36.483v-13h36.483zm-80.483 56h-111v-98h111v98z" fill="#000002"/>
			</svg>
			'),
		
		('CPU Cooler', 'A CPU cooler is device designed to draw heat away from the system CPU and other components in the enclosure. Using a CPU cooler to lower CPU temperatures improves efficiency and stability of the system. Adding a cooling device, however, can increase the overall noise level of the system.', 'https://www.youtube.com/embed/nQIB5qcl3R8', '<?xml version="1.0" encoding="UTF-8"?>
			<!DOCTYPE svg  PUBLIC "-//W3C//DTD SVG 1.1//EN"  "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
			<svg enable-background="new 0 0 284 284" version="1.1" viewBox="0 0 284 284" xml:space="preserve" xmlns="http://www.w3.org/2000/svg">
				<path d="m223.6 149.62l-49.706-15.915 0.129-0.048c24.207-9.129 37.71-19.348 41.28-31.24 1.779-5.928 1.9-15.05-7.623-24.84-5.314-5.462-16.639-13.334-17.113-13.664-1.5-1.042-3.257-1.593-5.08-1.593-2.863 0-5.57 1.388-7.237 3.707l-30.495 42.357c-1.022-21.893-5.287-37.11-12.709-45.301-4.534-5.002-10.338-7.646-16.781-7.646-4.253 0-8.779 1.167-13.453 3.468-5.157 2.541-12.559 7.815-16.517 10.735-1.013 0.75-1.664 1.243-1.765 1.32-2.328 1.77-3.641 4.571-3.512 7.504 0.081 1.759 0.675 3.44 1.718 4.863l30.845 42.069c-11.86-3.262-22.085-4.911-30.488-4.911-11.215 0-19.525 3.03-24.698 9.004-4.681 5.397-6.405 12.624-5.128 21.479 1.093 7.557 5.625 20.564 5.815 21.109 1.247 3.576 4.629 5.98 8.416 5.98 0.956 0 1.9-0.153 2.79-0.449l49.568-16.343c-0.025 0.038-0.05 0.075-0.074 0.113-14.22 21.614-19.139 37.818-15.035 49.538 2.047 5.843 7.313 13.296 20.771 15.617 3.962 0.683 10.002 1.029 17.952 1.029 2.352 0 3.921-0.034 3.918-0.034 4.83-0.102 8.743-4.116 8.724-8.949l-0.224-52.19c15.976 19.998 29.724 29.718 42.028 29.718 5.201 0 14.947-1.94 21.789-14.933 3.581-6.798 7.545-19.943 7.709-20.491 1.398-4.625-1.21-9.589-5.814-11.063z"/>
				<path d="m284 33.5c0-10.493-8.507-19-19-19h-246c-10.493 0-19 8.507-19 19v217c0 10.493 8.507 19 19 19h246c10.493 0 19-8.507 19-19v-217zm-253.06-5.004c7.336 0 13.283 5.947 13.283 13.283s-5.947 13.283-13.283 13.283-13.282-5.947-13.282-13.283c-1e-3 -7.337 5.946-13.283 13.282-13.283zm0 226.01c-7.336 0-13.282-5.947-13.282-13.283s5.947-13.283 13.282-13.283c7.336 0 13.283 5.947 13.283 13.283-1e-3 7.337-5.948 13.283-13.283 13.283zm111.4-6.737c-58.689 0-106.27-47.577-106.27-106.27s47.577-106.27 106.27-106.27 106.27 47.577 106.27 106.27-47.576 106.27-106.27 106.27zm111.4 6.737c-7.336 0-13.283-5.947-13.283-13.283s5.947-13.283 13.283-13.283 13.282 5.947 13.282 13.283c1e-3 7.337-5.946 13.283-13.282 13.283zm0-199.44c-7.336 0-13.283-5.947-13.283-13.283s5.947-13.283 13.283-13.283 13.282 5.947 13.282 13.283c1e-3 7.336-5.946 13.283-13.282 13.283z"/>
			</svg>
			'),
		
		('Motherboard', 'Motherboard: Definition. A motherboard is one of the most essential parts of a computer system. It holds together many of the crucial components of a computer, including the central processing unit (CPU), memory and connectors for input and output devices.', 'https://www.youtube.com/embed/0xZc7YryJ0U', '<?xml version="1.0" encoding="UTF-8"?>
			<svg enable-background="new 0 0 512 512" version="1.1" viewBox="0 0 512 512" xml:space="preserve" xmlns="http://www.w3.org/2000/svg">
					<rect x="168.49" y="360.03" width="33.487" height="56.974"/>
					<rect x="320.03" y="145" width="56.974" height="56.974"/>
					<rect x="105" y="360.03" width="33.487" height="56.974"/>
					<path d="m497 0h-482c-8.284 0-15 6.716-15 15v482c0 8.284 6.716 15 15 15h482c8.284 0 15-6.716 15-15v-482c0-8.284-6.716-15-15-15zm-358.51 80c0-8.284 6.716-15 15-15s15 6.716 15 15v191c0 8.284-6.716 15-15 15s-15-6.716-15-15v-191zm-63.487 0c0-8.284 6.716-15 15-15s15 6.716 15 15v191c0 8.284-6.716 15-15 15s-15-6.716-15-15v-191zm156.97 352c0 8.284-6.716 15-15 15h-126.97c-8.284 0-15-6.716-15-15v-86.974c0-8.284 6.716-15 15-15h126.97c8.284 0 15 6.716 15 15v86.974zm160.03-8.487h-86.974c-8.284 0-15-6.716-15-15s6.716-15 15-15h86.974c8.284 0 15 6.716 15 15s-6.716 15-15 15zm0-63.487h-86.974c-8.284 0-15-6.716-15-15s6.716-15 15-15h86.974c8.284 0 15 6.716 15 15s-6.716 15-15 15zm50-178.05c8.284 0 15 6.716 15 15s-6.716 15-15 15h-35v5c0 8.284-6.716 15-15 15h-5v35c0 8.284-6.716 15-15 15s-15-6.716-15-15v-35h-16.974v35c0 8.284-6.716 15-15 15s-15-6.716-15-15v-35h-5c-8.284 0-15-6.716-15-15v-5h-35c-8.284 0-15-6.716-15-15s6.716-15 15-15h35v-16.974h-35c-8.284 0-15-6.716-15-15s6.716-15 15-15h35v-5c0-8.284 6.716-15 15-15h5v-35c0-8.284 6.716-15 15-15s15 6.716 15 15v35h16.974v-35c0-8.284 6.716-15 15-15s15 6.716 15 15v35h5c8.284 0 15 6.716 15 15v5h35c8.284 0 15 6.716 15 15s-6.716 15-15 15h-35v16.974h35z"/>
			</svg>
		'),

		('Memory', 'Computer memory is any physical device capable of storing information temporarily or permanently. For example, Random Access Memory (RAM), is a volatile memory that stores information on an integrated circuit used by the operating system, software, and hardware.', 'https://www.youtube.com/embed/dZcszUj5szA', '<?xml version="1.0" encoding="UTF-8"?>
			<!DOCTYPE svg  PUBLIC "-//W3C//DTD SVG 1.1//EN"  "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
			<svg enable-background="new 0 0 295.53 295.53" version="1.1" viewBox="0 0 295.53 295.53" xml:space="preserve" xmlns="http://www.w3.org/2000/svg">
			<path d="m279.21 101.3l11.925-11.925c2.813-2.813 4.394-6.628 4.394-10.606s-1.58-7.794-4.394-10.606l-63.77-63.769c-5.857-5.857-15.356-5.857-21.213 0l-201.76 201.76c-2.814 2.812-4.394 6.628-4.394 10.606s1.58 7.794 4.394 10.606l63.77 63.769c2.929 2.929 6.768 4.394 10.606 4.394s7.678-1.465 10.606-4.394l11.924-11.924 10.005 10.005c2.929 2.93 6.768 4.394 10.606 4.394s7.678-1.465 10.606-4.394l156.7-156.7c2.813-2.813 4.394-6.628 4.394-10.606s-1.58-7.794-4.394-10.606l-10.004-10.007zm-210.49 146.76l-31.885-31.884 33.627-33.627 31.884 31.884-33.626 33.627zm72.858-72.858l-31.884-31.884 33.627-33.627 31.884 31.884-33.627 33.627zm72.858-72.858l-31.884-31.884 33.627-33.627 31.884 31.884-33.627 33.627z"/>
			</svg>
			'),
		
		('Graphics Card', 'A video card connects to the motherboard of a computer system and generates output images to display. Video cards are also referred to as graphics cards. Video cards include a processing unit, memory, a cooling mechanism and connections to a display device.', 'https://www.youtube.com/embed/c3BKuNXdM5A', '<?xml version="1.0" encoding="UTF-8"?>
			<!DOCTYPE svg  PUBLIC "-//W3C//DTD SVG 1.1//EN"  "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
			<svg enable-background="new 0 0 289.047 289.047" version="1.1" viewBox="0 0 289.047 289.047" xml:space="preserve" xmlns="http://www.w3.org/2000/svg">
			<path d="m245.64 111.52c2.882 0 5.476-1 7.303-3h21.105c8.284 0 15-6.716 15-15s-6.716-15-15-15h-21.105c-1.827-2-4.421-3-7.303-3h-14.449v-15h14.448c2.882 0 5.476-1 7.303-3h21.105c8.284 0 15-6.716 15-15s-6.716-15-15-15h-21.105c-1.827-2-4.421-3-7.303-3h-14.415c-0.768-10-9.399-19-19.924-19h-133.55c-10.525 0-19.157 9-19.925 19h-14.416c-2.882 0-5.476 1-7.303 3h-21.105c-8.284 0-15 6.716-15 15s6.716 15 15 15h21.105c1.827 2 4.421 3 7.303 3h13.782v15h-13.782c-2.882 0-5.476 1-7.303 3h-21.105c-8.284 0-15 6.716-15 15s6.716 15 15 15h21.105c1.827 2 4.421 3 7.303 3h13.782v15h-13.782c-2.882 0-5.476 1-7.303 3h-21.105c-8.284 0-15 6.716-15 15s6.716 15 15 15h21.105c1.827 2 4.421 3 7.303 3h13.782v15h-13.782c-2.882 0-5.476 1-7.303 3h-21.105c-8.284 0-15 6.716-15 15s6.716 15 15 15h21.105c1.827 2 4.421 3 7.303 3h13.782v15h-13.782c-2.882 0-5.476 1-7.303 3h-21.105c-8.284 0-15 6.716-15 15s6.716 15 15 15h21.105c1.827 2 4.421 3 7.303 3h14.416c0.767 10 9.399 19 19.925 19h133.55c10.525 0 19.157-9 19.924-19h14.415c2.882 0 5.476-1 7.303-3h21.105c8.284 0 15-6.716 15-15s-6.716-15-15-15h-21.105c-1.827-2-4.421-3-7.303-3h-14.448v-15h14.448c2.882 0 5.476-1 7.303-3h21.105c8.284 0 15-6.716 15-15s-6.716-15-15-15h-21.105c-1.827-2-4.421-3-7.303-3h-14.448v-15h14.448c2.882 0 5.476-1 7.303-3h21.105c8.284 0 15-6.716 15-15s-6.716-15-15-15h-21.105c-1.827-2-4.421-3-7.303-3h-14.448v-15h14.449zm-58.449 133h-86v-200h86v200z"/>
			</svg>
			'),
		
		('Storage', 'A storage device is any computing hardware that is used for storing, porting and extracting data files and objects. It can hold and store information both temporarily and permanently, and can be internal or external to a computer, server or any similar computing device.', 'https://www.youtube.com/embed/YQEjGKYXjw8', '<?xml version="1.0" encoding="UTF-8"?>
			<!DOCTYPE svg  PUBLIC "-//W3C//DTD SVG 1.1//EN"  "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
			<svg enable-background="new 0 0 284 284" version="1.1" viewBox="0 0 284 284" xml:space="preserve" xmlns="http://www.w3.org/2000/svg">
				<path d="m283.22 180.26c-0.036-0.692-0.114-1.389-0.27-2.089l-35.186-157.56c-1.466-6.572-7.889-11.619-14.622-11.619h-181.61c-6.732 0-13.155 5.046-14.623 11.619l-35.185 157.61c-0.152 0.68-0.561 1.355-0.599 2.025-0.511 1.902-1.121 3.898-1.121 5.959v65.993c0 12.683 10.983 22.798 23.666 22.798h237.33c12.683 0 23-10.115 23-22.798v-65.993c0-2.056-0.275-4.048-0.783-5.945zm-140.88-146.09c46.755 0 84.656 28.321 84.656 63.257s-37.902 63.257-84.656 63.257-84.656-28.321-84.656-63.257 37.902-63.257 84.656-63.257zm111.67 210.82h-224v-52h224v52z"/>
				<rect x="49" y="207" width="65" height="25"/>
				<path d="m142.33 118.11c14.327 0 25.983-9.277 25.983-20.68 0-11.402-11.656-20.679-25.983-20.679s-25.983 9.276-25.983 20.679 11.656 20.68 25.983 20.68z"/>
			</svg>'),

		('Power Supply (PSU)', 'A power supply is a component that supplies power to at least one electric load. Typically, it converts one type of electrical power to another, but it may also convert a a different form of energy – such as solar, mechanical, or chemical - into electrical energy. A power supply provides components with electric power.', 'https://www.youtube.com/embed/lqThn3C-zg4', '<?xml version="1.0" encoding="UTF-8"?>
			<!DOCTYPE svg  PUBLIC "-//W3C//DTD SVG 1.1//EN"  "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
			<svg enable-background="new 0 0 284 284" version="1.1" viewBox="0 0 284 284" xml:space="preserve" xmlns="http://www.w3.org/2000/svg">
			<path d="M268.423,221c5.247,0,9.167-4.253,9.167-9.5v-9c0-5.247-3.92-9.5-9.167-9.5H234.59v-14c0-3.866-2.801-7-6.667-7h-20  c-3.866,0-7.333,3.134-7.333,7v3h-45.475c-10.477,0-19.525,8.926-19.525,19.402V214H70.345c-18.712,0-33.935-15.076-33.935-33.788  s15.223-33.862,33.927-33.862l136.879,0.107c35.254,0,63.935-28.475,63.935-63.729S242.47,19,207.216,19H156.59v-5.821  C156.59,6.011,151.309,0,144.141,0h-39.135c-4.829,0-9.043,3-11.284,7h-20.88C65.674,7,59.59,12.582,59.59,19.75v26.541  C59.59,53.459,65.674,59,72.842,59h20.88c2.242,4,6.455,7,11.284,7h39.135c7.168,0,12.449-5.97,12.449-13.138V49h50.626  c18.712,0,33.935,15.035,33.935,33.747s-15.223,33.841-33.927,33.841l-136.879-0.117c-35.254,0-63.935,28.511-63.935,63.765  S35.091,244,70.345,244h65.245v9.852c0,10.477,9.048,19.148,19.525,19.148h45.475v4c0,3.866,3.467,7,7.333,7h20  c3.866,0,6.667-3.134,6.667-7v-15h33.833c5.247,0,9.167-4.253,9.167-9.5v-9c0-5.247-3.92-9.5-9.167-9.5H234.59v-13H268.423z"/>
			</svg>
			'),
		
		('Case (Chassis)', 'A computer case, also known as a computer chassis, tower, system unit, cabinet, or base unit, is the enclosure that contains most of the components of a computer (usually excluding the display, keyboard and mouse).', 'https://www.youtube.com/embed/aEHDTJMqmpc', '<?xml version="1.0" encoding="UTF-8"?>
			<!DOCTYPE svg  PUBLIC "-//W3C//DTD SVG 1.1//EN"  "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
			<svg enable-background="new 0 0 294 294" version="1.1" viewBox="0 0 294 294" xml:space="preserve" xmlns="http://www.w3.org/2000/svg">
			<path d="m228 15c0-8.284-6.716-15-15-15h-132c-8.284 0-15 6.716-15 15v264c0 8.284 6.716 15 15 15h132c8.284 0 15-6.716 15-15v-264zm-81.417 253.5c-4.556 0-8.25-3.694-8.25-8.25s3.694-8.25 8.25-8.25 8.25 3.694 8.25 8.25-3.693 8.25-8.25 8.25zm-0.25-36.5c-9.113 0-16.5-7.387-16.5-16.5s7.387-16.5 16.5-16.5 16.5 7.387 16.5 16.5-7.387 16.5-16.5 16.5zm48.667-68h-99v-33h99v33zm0-50h-99v-33h99v33zm0-49h-99v-33h99v33z"/>
			</svg>
			'),
		
		('Operating System', 'An operating system (OS) is system software that manages computer hardware and software resources and provides common services for computer programs.', 'https://www.youtube.com/embed/MR2ntdZW__A', '<?xml version="1.0" encoding="UTF-8"?>
			<!DOCTYPE svg  PUBLIC "-//W3C//DTD SVG 1.1//EN"  "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
			<svg width="475.08px" height="475.08px" enable-background="new 0 0 475.082 475.082" version="1.1" viewBox="0 0 475.082 475.082" xml:space="preserve" xmlns="http://www.w3.org/2000/svg">
					<polygon points="0 409.7 194.72 436.54 194.72 250.68 0 250.68"/>
					<polygon points="0 226.69 194.72 226.69 194.72 38.544 0 65.38"/>
					<polygon points="216.13 439.4 475.08 475.08 475.08 250.68 475.08 250.67 216.13 250.67"/>
					<polygon points="216.13 35.688 216.13 226.69 475.08 226.69 475.08 0"/>
			</svg>
			');


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

IF OBJECT_ID('getProducts', 'P') IS NOT NULL
	DROP PROC getProducts
GO

IF OBJECT_ID('attachTypeProduct', 'P') IS NOT NULL
	DROP PROC attachTypeProduct
GO
CREATE PROC dbo.getProducts
	@CategoryID VARCHAR(10),
	@ChildIDs VARCHAR(1000)
AS
	declare @sql nvarchar(max)
	set @sql = 'SELECT p.*, pt.* FROM dg_Products p
	LEFT JOIN dg_ProductsTypes as pt ON pt.ProductId = p.ProductId
	WHERE p.CategoryId = '+@categoryID+' AND pt.TypeId IN('+@ChildIDs+') AND pt.TypeId IS NOT null'

	EXEC sp_executesql @sql
GO
EXEC dbo.getProducts 2, '17,4';

GO

CREATE PROC attachTypeProduct
	@ProductId INT,
	@TypeId INT
AS
	INSERT INTO dbo.dg_ProductsTypes (ProductId, TypeId) VALUES (@ProductId, @TypeId)
GO


	EXEC attachTypeProduct 2, 2