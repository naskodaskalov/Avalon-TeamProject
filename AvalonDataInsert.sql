﻿USE AvalonDB
GO

SET IDENTITY_INSERT Countries ON
GO

INSERT INTO Countries (Id,Name,Continent)
VALUES (1,'USA','North America'),
	   (2,'Ireland','Europe'),
	   (3,'Belgium','Europe'),
	   (4,'Bulgaria','Europe'),
	   (5,'Netherlands','Europe'),
	   (6,'Czech Republic','Europe'),
	   (7,'Germany','Europe'),
	   (8,'England','Europe')
		
SET IDENTITY_INSERT Countries OFF
GO

SET IDENTITY_INSERT Towns ON
GO
INSERT INTO Towns(Id,Name,CountryId,ZipCode)
VALUES (1,'Santa Rosa',1,'9541'),
		(2,'Milton',1,'19968'),
		(3,'Kalmazo',1,'49001'),
		(4,'San Francisco',1,'94101'),
		(5,'Dublin',2,'2101'),
		(6,'Tourpes',3,'7904'),
		(7,'Stara Zagora',4,'6000'),
		(8,'Zoeterwoude',5,'2380'),
		(9,'Plovdiv',4,'4000'),
		(10,'Blagoevgrad',4,'2700'),
		(11,'Liberec',6,'46311'),
		(12,'Amsterdam',5,'1011'),
		(13,'London',8,'WC2N'),
		(14,'Berlin',7,'9011')
SET IDENTITY_INSERT Towns OFF
GO

SET IDENTITY_INSERT Styles ON
INSERT INTO Styles (Id,Name,OriginId,ServingTemp)
VALUES (1,'Lager',7,'2-4'),
		(2,'IPA',8,'7-10'),
		(3,'Stout',8,'7-10'),
		(4,'Imperial Stout',8,'13-16'),
		(5,'Blonde',1,'7-10'),
		(6,'Porter',8,'7-10'),
		(7,'Ale',8,'7-10'),
		(8,'American Lager',1,'2-4'),
		(9,'Alcohol Free',4,'3-5'),
		(10,'Bock',7,'10-13'),
		(11,'Weiss',7,'2-4'),
		(12,'Amber',1,'8-12'),
		(13,'BeerMix',4,'3-5')
SET IDENTITY_INSERT Styles OFF
GO

SET IDENTITY_INSERT Breweries ON
INSERT INTO Breweries (Id,Name,TownId)
VALUES (1,'Russian River Brewing Co',1),
		(2,'Dogfish Head Brewery',2),
		(3,'Bells Brewery',3),
		(4,'Dupont Brewery',6),
		(5,'21st Amendment Brewery',4),
		(6,'Founders Brewing Co',5),
		(7,'Zagorka Brewery',7),
		(8,'Heineken Brewery Co',8),
		(9,'Kamenitza Ad',9),
		(10,'Pirinsko Pivo Ad',10),
		(11,'Konrad Brewery',11),
		(12,'Amsterl Brewery',12)
SET IDENTITY_INSERT Breweries OFF
GO

SET IDENTITY_INSERT Distributors ON
INSERT INTO Distributors (Id,Name,Address,TownId,Phone)
VALUES(1,'Bira OOD','Han Asparuh 20',9,'+359 884233432'),
		(2,'Obedinena Kompania AD','Kraipatno shose 20',9,'+359 332332554345'),
		(3,'Import Export Ltd.','Berliner strase 22',7,'+49 43249873298498')
SET IDENTITY_INSERT Distributors OFF
GO


INSERT INTO BreweryDistributors (DistributorId,BreweryId)
VALUES (1,1),(1,2),(1,3),(1,4),(2,5),(2,6),(2,7),(3,8),(3,9),(3,10),(3,11),(3,12)
GO

SET IDENTITY_INSERT Awards ON
INSERT INTO Awards (Id,Name,Year)
VALUES (1,'Best Belgium Beer','2015'),
		(2,'Best Czech Pale','2013')
SET IDENTITY_INSERT Awards OFF
GO

SET IDENTITY_INSERT Beers ON
INSERT INTO Beers (Id,Name,SalePrice,Quantity,Rating,StyleId,BreweryId,DistributorPrice,DistributorId)
VALUES (1,'Pliny the Elder',4.20,28,9,2,1,3.90,1),
		(2,'60 Minute Dogfish',5.30,22,9.5,2,2,5,1),
		(3,'Bell’s Hopslam Ale',5,12,8.5,2,3,4,1),
		(4,'The Abyss',6,13,10,2,5,5.20,2),
		(5,'Guiness Foreign Extra',3.20,30,7,3,6,3,2),
		(6,'Saison Dupont',4.20,10,9,5,4,3.80,1),
		(7,'Cervesia',3.80,10,8,5,4,3.20,1),
		(8,'Redor Pils',3.40,11,9,5,4,2.90,1),
		(9,'Moinette Blonde',3.50,22,9,5,4,2.80,1),
		(10,'Guiness Original',3.40,50,7,1,6,3,2),
		(11,'Guiness Dublin Porter',4.40,66,8,6,6,3.80,2),
		(12,'Guiness Golden Ale',4.60,28,9,7,6,3.90,2),
		(13,'Guiness Nitro',5.30,89,9.9,2,6,4.60,2),
		(14,'Guiness Blonde',4.80,99,9.3,8,6,4.30,2),
		(15,'Zagorka Retro',2,45,5,1,7,1.50,2),
		(16,'Zagorka Maxx',1.90,23,5,9,7,1.60,2),
		(17,'Zagorka Special',2.20,43,6,1,7,1.60,2),
		(18,'Heineken',3.30,47,7,1,8,2.40,3),
		(19,'Kamenitza Svetlo',2,60,6,1,9,1.79,3),
		(20,'Kamenitza Dark',2.80,30,6,1,9,1.99,3),
		(21,'Kamenitza Fresh',1.90,40,6,13,9,1.40,3),
		(22,'Kamenitza Non Alcohol',1.90,30,5,9,9,1.49,3),
		(23,'Kamenitza Old',2.30,30,5,1,9,2.20,3),
		(24,'Pirinsko Svetlo',2,30,5,1,10,2.15,3),
		(25,'Konrad 14',5,30,8,1,11,4.3,3),
		(26,'Konrad 11',4.20,22,8,1,11,4,3),
		(27,'Konrad Eso Polotmavy',4.40,29,9,1,11,4,3),
		(28,'Amstel',3,39,7,1,12,3.20,3),
		(29,'Amstel Bock',3.40,34,8,10,12,2.80,3),
		(30,'Stolichno Bock',3.40,33,8,10,7,3.50,2),
		(31,'Stolichno Weiss',3,23,7,11,7,2.40,2),
		(32,'Stolichno Amber',4,44,8,12,7,3.59,2),
		(33,'Konrad  12',4.40,38,9,1,11,4,3)
SET IDENTITY_INSERT Beers OFF
GO

INSERT INTO BeerAwards(AwardId,BeerId)
	VALUES(1,7),(2,33)
GO

		
