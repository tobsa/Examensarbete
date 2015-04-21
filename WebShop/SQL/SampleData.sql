-- Categories
DELETE FROM Category;
INSERT INTO Category([Description], Name) VALUES
('Skjortor i olika utföranden',		'Skjortor');

-- Products
DELETE FROM Product;
INSERT INTO Product(Name, [Description], Price, ImageUrl, ImageThumbnailUrl, CategoryId, IsInStore) VALUES
('Skjorta, rosa',				'Rosa skjorta',									500,	'/Content/Images/Shirts/Tailor Store - Skjorta 1.png', '/Content/Images/Shirts/Tailor Store - Skjorta 1 thumb.png',	1, 1),
('Skjorta, vit/turkos/rosa',	'Skjorta, vit/turkos/rosa',						500,	'/Content/Images/Shirts/Tailor Store - Skjorta 2.png', '/Content/Images/Shirts/Tailor Store - Skjorta 2 thumb.png',	1, 1),
('Skjorta, blå/vit',			'Blåvit rutig skjorta',							500,	'/Content/Images/Shirts/Tailor Store - Skjorta 3.png', '/Content/Images/Shirts/Tailor Store - Skjorta 3 thumb.png',	1, 1),
('Skjorta, vit',				'Vit skjorta',									500,	'/Content/Images/Shirts/Tailor Store - Skjorta 4.png', '/Content/Images/Shirts/Tailor Store - Skjorta 4 thumb.png',	1, 1),
('Siruela, red',				'Rödrutig businesskjorta',						500,	'/Content/Images/Shirts/Tailor Store - Skjorta 5.png', '/Content/Images/Shirts/Tailor Store - Skjorta 5 thumb.png',	1, 0),
('Aviles, black',				'Svart mönstrad businesskjorta',				500,	'/Content/Images/Shirts/Tailor Store - Skjorta 6.png', '/Content/Images/Shirts/Tailor Store - Skjorta 6 thumb.png',	1, 0),
('Batalha, light purple',		'Lila enfärgad businesskjorta',					500,	'/Content/Images/Shirts/Tailor Store - Skjorta 7.png', '/Content/Images/Shirts/Tailor Store - Skjorta 7 thumb.png',	1, 0),
('Carvico, orange',				'Orangerutig businesskjorta i egyptisk bomull',	500,	'/Content/Images/Shirts/Tailor Store - Skjorta 8.png', '/Content/Images/Shirts/Tailor Store - Skjorta 8 thumb.png',	1, 0),
('Ternberg, navy',				'Blårandig businesskjorta',						500,	'/Content/Images/Shirts/Tailor Store - Skjorta 9.png', '/Content/Images/Shirts/Tailor Store - Skjorta 9 thumb.png',	1, 0),
('Telde, dark green',			'Grön enfärgad businesskjorta i chambray',		500,	'/Content/Images/Shirts/Tailor Store - Skjorta 10.png', '/Content/Images/Shirts/Tailor Store - Skjorta 10 thumb.png',	1, 0),
('Milano, navy',				'Blå enfärgad businesskjorta',					500,	'/Content/Images/Shirts/Tailor Store - Skjorta 11.png', '/Content/Images/Shirts/Tailor Store - Skjorta 11 thumb.png',	1, 0),
('Gondomar, gray',				'Grå enfärgad businesskjorta i oxford',			500,	'/Content/Images/Shirts/Tailor Store - Skjorta 12.png', '/Content/Images/Shirts/Tailor Store - Skjorta 12 thumb.png',	1, 0),
('Sarria, navy',				'Blårutig businesskjorta i twill',				500,	'/Content/Images/Shirts/Tailor Store - Skjorta 13.png', '/Content/Images/Shirts/Tailor Store - Skjorta 13 thumb.png',	1, 0),
('Caucel, black',				'Svart enfärgad businesskjorta',				500,	'/Content/Images/Shirts/Tailor Store - Skjorta 14.png', '/Content/Images/Shirts/Tailor Store - Skjorta 14 thumb.png',	1, 0),
('Gmunden, orange',				'Lilarutig businesskjorta i egyptisk bomull',	500,	'/Content/Images/Shirts/Tailor Store - Skjorta 15.png', '/Content/Images/Shirts/Tailor Store - Skjorta 15 thumb.png',	1, 0),
('Telde, orange',				'Orange enfärgad businesskjorta i chambray',	500,	'/Content/Images/Shirts/Tailor Store - Skjorta 16.png', '/Content/Images/Shirts/Tailor Store - Skjorta 16 thumb.png',	1, 0),
('Leonding, orange',			'Blårutig casualskjorta i egyptisk bomull',		500,	'/Content/Images/Shirts/Tailor Store - Skjorta 17.png', '/Content/Images/Shirts/Tailor Store - Skjorta 17 thumb.png',	1, 0),
('Villablino, white',			'Svart mönstrad skjorta',						500,	'/Content/Images/Shirts/Tailor Store - Skjorta 18.png', '/Content/Images/Shirts/Tailor Store - Skjorta 18 thumb.png',	1, 0),
('Milano, dark red',			'Röd enfärgad skjorta',							500,	'/Content/Images/Shirts/Tailor Store - Skjorta 19.png', '/Content/Images/Shirts/Tailor Store - Skjorta 19 thumb.png',	1, 0),
('Telde, green',				'Grön enfärgad businesskjorta i chambray',		500,	'/Content/Images/Shirts/Tailor Store - Skjorta 20.png', '/Content/Images/Shirts/Tailor Store - Skjorta 20 thumb.png',	1, 0),
('Ansfelden, yellow',			'Gulrutig button down-skjorta i egyptisk bomull', 500,	'/Content/Images/Shirts/Tailor Store - Skjorta 21.png', '/Content/Images/Shirts/Tailor Store - Skjorta 21 thumb.png',	1, 0),
('Chur, pink',					'Rosarutig button down-skjorta i egyptisk bomull', 500,	'/Content/Images/Shirts/Tailor Store - Skjorta 22.png', '/Content/Images/Shirts/Tailor Store - Skjorta 22 thumb.png',	1, 0),
('Caucel, blue',				'Blå enfärgad button down-skjorta',				500,	'/Content/Images/Shirts/Tailor Store - Skjorta 23.png', '/Content/Images/Shirts/Tailor Store - Skjorta 23 thumb.png',	1, 0),
('Siruela, green',				'Grönrutig button down-skjorta',				500,	'/Content/Images/Shirts/Tailor Store - Skjorta 24.png', '/Content/Images/Shirts/Tailor Store - Skjorta 24 thumb.png',	1, 0),

('Skjorta, svart mönstrad',						'Svart skjorta med blommönster',	500,	'/Content/Images/Shirts/Eton - Skjorta 1.png', '/Content/Images/Shirts/Eton - Skjorta 1 thumb.png',	1, 1),
('Skjorta, vit',								'Vit skjorta',						500,	'/Content/Images/Shirts/Eton - Skjorta 2.png', '/Content/Images/Shirts/Eton - Skjorta 2 thumb.png',	1, 1),
('Skjorta, ljusblå',							'Ljusblå skjorta',					500,	'/Content/Images/Shirts/Eton - Skjorta 3.png', '/Content/Images/Shirts/Eton - Skjorta 3 thumb.png',	1, 1),
('Skjorta, vit/grön',							'Grönrutig vit skjorta',			500,	'/Content/Images/Shirts/Eton - Skjorta 4.png', '/Content/Images/Shirts/Eton - Skjorta 4 thumb.png',	1, 1),
('Blåvitrandig skjorta - York Twill',			'Den blåvitrandiga skjortan är ett givet inslag i businessgarderoben. Vårt twilltyg York ger extra lyster åt mönstret och skapar en skjorta med skrynkelfria egenskaper. Detaljer som Etons cut away-krage, enkla manschetter och contemporary fit-passform förfinar skjortan ytterligare.',	500,	'/Content/Images/Shirts/Eton - Skjorta 5.png', '/Content/Images/Shirts/Eton - Skjorta 5 thumb.png',	1, 0),
('Mikromönstrad skjorta - York Twill',			'Denna skjorta är vävd med ett smårutigt mönster för en modern och sofistikerad visuell effekt. Detaljer som den klarblåa färgen, vår cut away-krage och enkelknäppta manschetter gör att skjortan passar perfekt till en tidlös marinblå eller grå kostym.',								500,	'/Content/Images/Shirts/Eton - Skjorta 6.png', '/Content/Images/Shirts/Eton - Skjorta 6 thumb.png',	1, 0),
('Ljusblårutig skjorta – Cambridge Twill',		'Med ett sofistikerat ljusblårutigt twilltyg och detaljer och vår contemporary fit-passform är detta den perfekta businesskjortan. Den tidlösa cut away-kragen passar lika bra att bäras med slips och kostym som uppknäppt till en klassisk blazer eller stickad tröja.',					500,	'/Content/Images/Shirts/Eton - Skjorta 7.png', '/Content/Images/Shirts/Eton - Skjorta 7 thumb.png',	1, 0),
('Blårutig skjorta',							'Denna smårutiga skjorta är enkel att matcha till varje outfit. Bär den till en marinblå kavaj och ett par chinos för en modern kontorsstil eller uppknäppt till en finstickad tröja för en mer avslappnad look.',																			500,	'/Content/Images/Shirts/Eton - Skjorta 8.png', '/Content/Images/Shirts/Eton - Skjorta 8 thumb.png',	1, 0),
('Rödrutig skjorta',							'Denna smårutiga skjorta är enkel att matcha till varje outfit. Bär den till en marinblå kavaj och ett par chinos för en modern kontorsstil eller uppknäppt till en finstickad tröja för en mer avslappnad look.',																			500,	'/Content/Images/Shirts/Eton - Skjorta 9.png', '/Content/Images/Shirts/Eton - Skjorta 9 thumb.png',	1, 0),
('Vit mikromönstrad skjorta',					'Denna skjortan är tillverkad av ett exklusivt poplintyg med tryckta mikromönster. Detaljer som vår cut away-krage och enkelknäppta manschetter gör att skjortan passar perfekt till en modern och välskräddad stil. ',																		500,	'/Content/Images/Shirts/Eton - Skjorta 10.png', '/Content/Images/Shirts/Eton - Skjorta 10 thumb.png',	1, 0),
('Blommig skjorta - York twill',				'Stick ut på kontoret med vårens stilsäkraste skjorta. Det eleganta blommönstret är tryckt på ett exklusivt twilltyg som passar perfekt till en välskräddad stil eller ett par chinos för en ledig vårlook. Bland detaljerna syns vår cut away-krage samt enkelknäppta manschetter. ',		500,	'/Content/Images/Shirts/Eton - Skjorta 11.png', '/Content/Images/Shirts/Eton - Skjorta 11 thumb.png',	1, 0),
('Grönrutig skjorta',							'Denna smårutiga skjorta är enkel att matcha till varje outfit. Bär den till en marinblå kavaj och ett par chinos för en modern kontorsstil eller uppknäppt till en finstickad tröja för en mer avslappnad look.',																			500,	'/Content/Images/Shirts/Eton - Skjorta 12.png', '/Content/Images/Shirts/Eton - Skjorta 12 thumb.png',	1, 0),
('Blårutig skjorta - Brighton Poplin',			'Uppdatera businesstilen med denna stilsäkert rutiga skjorta. Med detaljer som vår tidlösa cut away-krage och enkelknäppta manschetter passar denna skjorta lika bra till en välskräddad kostym som ett par ledigare byxor och en finstickad tröja.',										500,	'/Content/Images/Shirts/Eton - Skjorta 13.png', '/Content/Images/Shirts/Eton - Skjorta 13 thumb.png',	1, 0),
('Marinblårutig skjorta – flerfärgade knappar ','Det släta poplintyget har en given plats i den klassiska skjortgarderoben. Vår version av tyget kombinerar skarpa mönster med oklanderliga egenskaper. Bland detaljerna syns vår cut away-krage, enkelknäppta manschetter och flerfärgade knappar.',										500,	'/Content/Images/Shirts/Eton - Skjorta 14.png', '/Content/Images/Shirts/Eton - Skjorta 14 thumb.png',	1, 0),
('Flerfärgad skjorta - York Twill',				'En förfinad version av den klassiska button down-skjortan som passar perfekt i vårdgarderoben. Bär skjortan med dina favoritjeans eller ett par chinos för en sportig look. Bland detaljerna syns vår button down-krage samt enkelknäppta manschetter.',									500,	'/Content/Images/Shirts/Eton - Skjorta 15.png', '/Content/Images/Shirts/Eton - Skjorta 15 thumb.png',	1, 0),
('Blåvitrandig skjorta - vit krage',			'Hämta inspiration från stilikoner som Gordon Gekko och Patrick Bateman i American Psyscho med denna blåvitrandiga skjorta med vit krage. Vi rekommenderar att du kombinerar skjortan med en välskräddad kostym och en stilsäker slips för en stil garanterat inger respekt på kontoret. ',	500,	'/Content/Images/Shirts/Eton - Skjorta 16.png', '/Content/Images/Shirts/Eton - Skjorta 16 thumb.png',	1, 0),
('Hundtandsmönstrad skjorta',					'Denna skjortan är tillverkad av mjukt och luftigt tyg och är perfekt för kunder som vill ha en skjorta som fungerar både för ledigare klädsel och kontoret. Vi föreslår att du bär skjortan med en skräddad kostym eller par lediga bomullsbyxor.',										500,	'/Content/Images/Shirts/Eton - Skjorta 17.png', '/Content/Images/Shirts/Eton - Skjorta 17 thumb.png',	1, 0),
('Hundtandsmönstrad skjorta',					'Denna skjortan är tillverkad av mjukt och luftigt tyg och är perfekt för kunder som vill ha en skjorta som fungerar både för ledigare klädsel och kontoret. Vi föreslår att du bär skjortan med en skräddad kostym eller par lediga bomullsbyxor.',										500,	'/Content/Images/Shirts/Eton - Skjorta 18.png', '/Content/Images/Shirts/Eton - Skjorta 18 thumb.png',	1, 0),
('Rödrutig skjorta - Brighton Poplin',			'Uppdatera businesstilen med denna stilsäkert rutiga skjorta. Med detaljer som vår tidlösa cut away-krage och enkelknäppta manschetter passar denna skjorta lika bra till en välskräddad kostym som ett par ledigare byxor och en finstickad tröja.',										500,	'/Content/Images/Shirts/Eton - Skjorta 19.png', '/Content/Images/Shirts/Eton - Skjorta 19 thumb.png',	1, 0),
('Rutig skjorta - Brighton Poplin',				'Gör dig redo för våren med denna stilfullt blåvitrutiga skjorta. Det släta poplintyget gör liksom den kompromisslösa detaljnivån att denna skjorta passar perfekt till en välskräddad look. Bland detaljerna syns vår cut away-krage samt enkelknäppta manschetter. ',						500,	'/Content/Images/Shirts/Eton - Skjorta 20.png', '/Content/Images/Shirts/Eton - Skjorta 20 thumb.png',	1, 0),
('Lila skjorta - Herringbone Cambridge Twill',	'Den perfekta skjortupplevelsen startar med tyget. Det här fiskbensmönstrade twilltyget kombinerar elegant följsamhet och form med enastående lyster. Tillsammans med vår cut away-krage, enkla manschetter och contemporary fit-passform är detta en skjorta som snabbt kommer att bli en favorit i garderoben. ', 500,	'/Content/Images/Shirts/Eton - Skjorta 21.png', '/Content/Images/Shirts/Eton - Skjorta 21 thumb.png',	1, 0),
('Orange skjorta - Carnaby Satin ',				'Vår Green Ribbon-kollektion förser dig med mångsidiga och stilfulla skjortor för varje tillfälle. Denna orange skjortan är tillverkad av ett exklusivt satängtyg med unik textur och detaljer som vår mjuka extreme cut away-krage. Tyget är tvättat för att skapa ett avslappnat och ledigt uttryck.', 500,	'/Content/Images/Shirts/Eton - Skjorta 22.png', '/Content/Images/Shirts/Eton - Skjorta 22 thumb.png',	1, 0),
('Svart button-down skjorta - Hoxton Linen',	'En mångsidig och slitstart skjorta tillverkad av linne som passar perfekt till alla tillfällen. Bär skjortan till ett par lediga bomullsbyxor och en finstickad kofta för en modern och elegant look. Bland detaljerna syns vår button down-krage samt enkelknäppta manschetter.',						500,	'/Content/Images/Shirts/Eton - Skjorta 23.png', '/Content/Images/Shirts/Eton - Skjorta 23 thumb.png',	1, 0),
('Mikromönstrad skjorta - Brighton Poplin',		'Denna eleganta skjortan är tryckt med ett innovativt mikromönster. Bär den till en klassisk marinblå kostym eller en grå kostym för att göra ett stilsäkert intryck på jobbet. Bland detaljerna syns vår cut away-krage samt enkelknäppta manschetter.',									500,	'/Content/Images/Shirts/Eton - Skjorta 24.png', '/Content/Images/Shirts/Eton - Skjorta 24 thumb.png',	1, 0);

-- Users
DELETE FROM [User];
INSERT INTO [User] VALUES
('wae1q'),('fvujl'),('1x62b'),('vrhl0'),
('swoo9'),('810lw'),('z0897'),('47zak'),
('1ka59'),('ud07y'),('2cll0'),('9k1x9'),
('yq87i'),('8c4ym'),('hkn9a'),('pbav1'),
('8lhru'),('ta2g3'),('x4l9x'),('gdv37'),
('t401b'),('oagkt'),('b08ba'),('4xpa9'),
('r8lz7'),('0d998'),('v8sao'),('ji8ci'),
('m391m'),('jj242'),('rbekj'),('3ybel'),
('dswuc'),('mfwx6'),('503ym'),('277j7'),
('t0oac'),('kwuni'),('oub5u'),('ytvto'),
('l4va6'),('z2pmo'),('m86uy'),('fvcsx'),
('idusq'),('vduny'),('vycgm'),('kwqyj'),
('x74zx'),('j8vju'),('h8ryi'),('fuq96'),
('cdxhu'),('g40vh'),('vaeyg'),('36ds8'),
('71rnd'),('6ij2g'),('p2uhf'),('z53n8'),
('aatdk'),('hvv9z'),('0gi90'),('ek9va'),
('dw0gl'),('me4f1'),('ehxlt'),('z429c'),
('tj9ia'),('diyce'),('e3x1v'),('bs1uo'),
('g99jv'),('3s1iq'),('1qhtj'),('bajjg'),
('pjgm9'),('lcyqi'),('0b4f1'),('68eql'),
('w0uwl'),('4v8w2'),('jfrjd'),('gjjvz'),
('enbnf'),('rieo7'),('u7x03'),('ocry9'),
('ck7lt'),('wx5co'),('b2ou0'),('tjj6s'),
('dqzxi'),('w8a35'),('9ptii'),('c04qk'),
('dwb3x'),('j4ogv'),('ny4yq'),('xlc0s');

DELETE FROM [Order];
INSERT INTO [Order](Username, Total, OrderDate, IsWebOrder, IpAddress, Age, Sex) VALUES
('Tobias1', 2500, '2015-04-10 13:37:00', 1, '193.11.73.8', 25, 0),
('Tobias2', 2500, '2015-04-11 13:37:00', 1, '193.11.73.8', 25, 0),
('Tobias3', 2500, '2015-04-12 13:37:00', 1, '193.11.73.8', 25, 1),
('Tobias4', 2500, '2015-04-13 13:37:00', 1, '193.11.73.8', 25, 1),
('Tobias5', 2500, '2015-04-14 13:37:00', 1, '193.11.73.8', 25, 1);

DELETE FROM [OrderDetail];
INSERT INTO [OrderDetail](OrderId, ProductId, Quantity, UnitPrice) VALUES
(1, 5, 1, 500),
(1, 6, 1, 500),
(1, 7, 1, 500),
(1, 8, 1, 500),
(1, 9, 1, 500),

(2, 5, 1, 500),
(2, 6, 1, 500),
(2, 7, 1, 500),
(2, 8, 1, 500),
(2, 9, 1, 500),

(3, 5, 1, 500),
(3, 6, 1, 500),
(3, 7, 1, 500),
(3, 8, 1, 500),
(3, 10, 1, 500),

(4, 5, 1, 500),
(4, 6, 1, 500),
(4, 7, 1, 500),
(4, 11, 1, 500),
(4, 12, 1, 500),

(5, 11, 1, 500),
(5, 12, 1, 500),
(5, 13, 1, 500),
(5, 14, 1, 500),
(5, 15, 1, 500);

DELETE FROM [RecommendationResult];
INSERT INTO [RecommendationResult](OrderId, RecommendedProductID, SelectedProductID) VALUES
(1, -1, 1),
(2, -1, 2),
(3, -1, 25),
(4, -1, 26),
(5, -1, 27);

DELETE FROM [OrderDetail] WHERE OrderId IN (SELECT OrderId FROM [Order] WHERE Username = 'test');
DELETE FROM [Order] WHERE Username = 'test';
