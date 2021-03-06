IF(NOT EXISTS(SELECT 1 FROM [Sales].[Consultant]))
BEGIN
SET IDENTITY_INSERT [Sales].[Consultant] ON 
INSERT [Sales].[Consultant] ([Id], [Code], [FirstName], [LastName], [PrivateNumber], [GenderId], [BirthDate], [RecommendatorId]) VALUES (1, N'M1', N'Mariam', N'M', N'0102', 2, CAST(N'1991-01-01' AS Date), NULL)
INSERT [Sales].[Consultant] ([Id], [Code], [FirstName], [LastName], [PrivateNumber], [GenderId], [BirthDate], [RecommendatorId]) VALUES (2, N'G1', N'Giorgi', N'G', N'0103', 1, CAST(N'1991-01-02' AS Date), 1)
INSERT [Sales].[Consultant] ([Id], [Code], [FirstName], [LastName], [PrivateNumber], [GenderId], [BirthDate], [RecommendatorId]) VALUES (3, N'N1', N'Nino', N'N', N'0104', 2, CAST(N'1990-01-03' AS Date), 2)
INSERT [Sales].[Consultant] ([Id], [Code], [FirstName], [LastName], [PrivateNumber], [GenderId], [BirthDate], [RecommendatorId]) VALUES (4, N'D1', N'Davit', N'D', N'0105', 1, CAST(N'1992-07-08' AS Date), 3)
INSERT [Sales].[Consultant] ([Id], [Code], [FirstName], [LastName], [PrivateNumber], [GenderId], [BirthDate], [RecommendatorId]) VALUES (5, N'N2', N'Nia', N'N', N'0106', 2, CAST(N'1980-08-08' AS Date), 2)
INSERT [Sales].[Consultant] ([Id], [Code], [FirstName], [LastName], [PrivateNumber], [GenderId], [BirthDate], [RecommendatorId]) VALUES (7, N'Kh1', N'Khatia', N'Kh', N'0909', 2, CAST(N'1997-05-25' AS Date), NULL)
INSERT [Sales].[Consultant] ([Id], [Code], [FirstName], [LastName], [PrivateNumber], [GenderId], [BirthDate], [RecommendatorId]) VALUES (8, N'M2', N'Mate', N'M', N'0108', 1, CAST(N'1992-05-31' AS Date), NULL)
SET IDENTITY_INSERT [Sales].[Consultant] OFF
END
GO

IF(NOT EXISTS(SELECT 1 FROM [Sales].[Product]))
BEGIN
SET IDENTITY_INSERT [Sales].[Product] ON 

INSERT [Sales].[Product] ([Id], [Code], [Name], [Price]) VALUES (1, N'A1', N'Product_A1', 100)
INSERT [Sales].[Product] ([Id], [Code], [Name], [Price]) VALUES (2, N'A2', N'Product_A2', 110)
INSERT [Sales].[Product] ([Id], [Code], [Name], [Price]) VALUES (3, N'A3', N'Product_A3', 50)
INSERT [Sales].[Product] ([Id], [Code], [Name], [Price]) VALUES (5, N'B1', N'Product_B1', 500)
INSERT [Sales].[Product] ([Id], [Code], [Name], [Price]) VALUES (6, N'B2', N'Product_B2', 600)
SET IDENTITY_INSERT [Sales].[Product] OFF
END
GO

IF(NOT EXISTS(SELECT 1 FROM [Sales].[Sale]))
BEGIN
SET IDENTITY_INSERT [Sales].[Sale] ON 

INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (3, N'S1', CAST(N'2020-05-31T12:04:42.680' AS DateTime), 7)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (4, N'S2', CAST(N'2019-08-24T21:05:23.573' AS DateTime), 5)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (5, N'S3', CAST(N'2019-08-24T21:05:23.573' AS DateTime), 5)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (6, N'S4', CAST(N'2019-08-24T21:05:23.573' AS DateTime), 1)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (7, N'S5', CAST(N'2019-08-24T21:05:23.573' AS DateTime), 2)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (8, N'S6', CAST(N'2019-12-24T21:05:23.573' AS DateTime), 3)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (9, N'S7', CAST(N'2020-01-19T21:05:23.573' AS DateTime), 4)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (10, N'S8', CAST(N'2020-05-15T21:05:23.573' AS DateTime), 5)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (11, N'S9', CAST(N'2020-05-15T21:05:23.573' AS DateTime), 1)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (12, N'S10', CAST(N'2020-05-15T21:05:23.573' AS DateTime), 2)
INSERT [Sales].[Sale] ([Id], [Code], [OperationDate], [ConsultantId]) VALUES (13, N'S11', CAST(N'2020-04-01T12:33:47.033' AS DateTime), 5)
SET IDENTITY_INSERT [Sales].[Sale] OFF
END
GO

IF(NOT EXISTS(SELECT 1 FROM [Sales].[ProductSale]))
BEGIN
SET IDENTITY_INSERT [Sales].[ProductSale] ON 

INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (4, 3, 1, 1, 100)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (7, 4, 5, 1, 500)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (8, 4, 2, 2, 110)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (9, 5, 1, 3, 100)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (10, 5, 3, 7, 50)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (11, 6, 2, 8, 110)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (12, 6, 3, 1, 50)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (13, 7, 1, 1, 100)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (14, 7, 5, 1, 500)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (15, 8, 3, 2, 50)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (16, 8, 6, 1, 600)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (17, 8, 1, 10, 100)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (18, 9, 1, 2, 100)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (19, 9, 6, 1, 600)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (20, 9, 2, 5, 110)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (21, 10, 1, 2, 100)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (22, 10, 6, 1, 600)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (23, 10, 2, 20, 110)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (24, 11, 1, 4, 100)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (25, 11, 3, 10, 50)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (26, 11, 2, 3, 110)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (27, 12, 1, 1, 100)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (28, 12, 2, 10, 110)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (29, 12, 3, 4, 50)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (30, 13, 1, 10, 100)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (31, 13, 5, 10, 500)
INSERT [Sales].[ProductSale] ([Id], [SaleId], [ProductId], [ProductUnit], [PricePerUnit]) VALUES (32, 3, 5, 4, 500)
SET IDENTITY_INSERT [Sales].[ProductSale] OFF
END
GO
