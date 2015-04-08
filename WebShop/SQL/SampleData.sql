
-- Categories
DELETE FROM Category;
INSERT INTO Category([Description], Name) VALUES
('Various types of furnitures',		'Furniture'),
('Clothing items',					'Clothes'),
('Different kinds of eletronics',	'Eletronics');


-- Products
DELETE FROM Product;
INSERT INTO Product(Name, [Description], Price, ImageUrl, CategoryId) VALUES
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
('Nintendo WII-U',		'A gaming console from Nintendo',	400,	'/Content/Images/placeholder.gif',		3);
