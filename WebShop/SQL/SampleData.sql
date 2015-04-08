-- Categories
DELETE FROM Category;
INSERT INTO Category([Description], Name) VALUES
('Various types of furnitures',		'Furniture'),
('Clothing items',					'Clothes'),
('Different kinds of eletronics',	'Eletronics'),

('Skjortor i olika utföranden',		'Skjortor');


-- Products
DELETE FROM Product;
INSERT INTO Product(Name, [Description], Price, ImageUrl, ImageThumbnailUrl, CategoryId) VALUES
('Awesome Chair',		'The best chair in the world!',		5000,	'/Content/Images/placeholder.gif',		1),
('Crappy Chair',		'The worst chair in the world',		10,		'/Content/Images/placeholder.gif',		1),
('Standard Chair',		'Nothing special about this...',	100,	'/Content/Images/placeholder.gif',		1),
('Manly T-Shirt',		'This is a T-Shirt for men!',		200,	'/Content/Images/placeholder.gif',		2),
('Not so T-Shirt',		'This is a T-Shirt',				400,	'/Content/Images/placeholder.gif',		2),
('Pants',				'Standard pants',					210,	'/Content/Images/placeholder.gif',		2),
('Nice Pants',			'Nice regular pants',				250,	'/Content/Images/placeholder.gif',		2),
('TV',					'Standard TV',						700,	'/Content/Images/placeholder.gif',		3),
('Computer',			'A generic computer',				900,	'/Content/Images/placeholder.gif',		3),
('Ipad',				'A decent tablet...',				14000,	'/Content/Images/placeholder.gif',		3),
('Video',				'Awesome video',					700,	'/Content/Images/placeholder.gif',		3),
('XBox One',			'A gaming console from Microsoft',	800,	'/Content/Images/placeholder.gif',		3),
('Playstation 4',		'A gaming console from Sony',		900,	'/Content/Images/placeholder.gif',		3),
('Nintendo WII-U',		'A gaming console from Nintendo',	400,	'/Content/Images/placeholder.gif',		3),

('Skjorta, rosa',				'Rosa skjorta',									500,	'/Content/Images/Shirts/Tailor Store - Skjorta 1.png', '/Content/Images/Shirts/Tailor Store - Skjorta 1 thumb.png',	4),
('Skjorta, vit/turkos/rosa',	'Skjorta, vit/turkos/rosa',						500,	'/Content/Images/Shirts/Tailor Store - Skjorta 2.png', '/Content/Images/Shirts/Tailor Store - Skjorta 2 thumb.png',	4),
('Skjorta, blå/vit',			'Blåvit rutig skjorta',							500,	'/Content/Images/Shirts/Tailor Store - Skjorta 3.png', '/Content/Images/Shirts/Tailor Store - Skjorta 3 thumb.png',	4),
('Skjorta, vit',				'Vit skjorta',									500,	'/Content/Images/Shirts/Tailor Store - Skjorta 4.png', '/Content/Images/Shirts/Tailor Store - Skjorta 4 thumb.png',	4),
('Siruela, red',				'Rödrutig businesskjorta',						500,	'/Content/Images/Shirts/Tailor Store - Skjorta 5.png', '/Content/Images/Shirts/Tailor Store - Skjorta 5 thumb.png',	4),
('Aviles, black',				'Svart mönstrad businesskjorta',				500,	'/Content/Images/Shirts/Tailor Store - Skjorta 6.png', '/Content/Images/Shirts/Tailor Store - Skjorta 6 thumb.png',	4),
('Batalha, light purple',		'Lila enfärgad businesskjorta',					500,	'/Content/Images/Shirts/Tailor Store - Skjorta 7.png', '/Content/Images/Shirts/Tailor Store - Skjorta 7 thumb.png',	4),
('Carvico, orange',				'Orangerutig businesskjorta i egyptisk bomull',	500,	'/Content/Images/Shirts/Tailor Store - Skjorta 8.png', '/Content/Images/Shirts/Tailor Store - Skjorta 8 thumb.png',	4),
('Ternberg, navy',				'Blårandig businesskjorta',						500,	'/Content/Images/Shirts/Tailor Store - Skjorta 9.png', '/Content/Images/Shirts/Tailor Store - Skjorta 9 thumb.png',	4),
('Telde, dark green',			'Grön enfärgad businesskjorta i chambray',		500,	'/Content/Images/Shirts/Tailor Store - Skjorta 10.png', '/Content/Images/Shirts/Tailor Store - Skjorta 10 thumb.png',	4),
('Milano, navy',				'Blå enfärgad businesskjorta',					500,	'/Content/Images/Shirts/Tailor Store - Skjorta 11.png', '/Content/Images/Shirts/Tailor Store - Skjorta 11 thumb.png',	4),
('Gondomar, gray',				'Grå enfärgad businesskjorta i oxford',			500,	'/Content/Images/Shirts/Tailor Store - Skjorta 12.png', '/Content/Images/Shirts/Tailor Store - Skjorta 12 thumb.png',	4),
('Sarria, navy',				'Blårutig businesskjorta i twill',				500,	'/Content/Images/Shirts/Tailor Store - Skjorta 13.png', '/Content/Images/Shirts/Tailor Store - Skjorta 13 thumb.png',	4),
('Caucel, black',				'Svart enfärgad businesskjorta',				500,	'/Content/Images/Shirts/Tailor Store - Skjorta 14.png', '/Content/Images/Shirts/Tailor Store - Skjorta 14 thumb.png',	4);