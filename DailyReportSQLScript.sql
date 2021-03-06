USE [DailyReport]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 9/25/2017 5:40:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(5,5) NOT NULL,
	[BrandMainID] [int] NULL,
	[BrandSubName] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BrandMain]    Script Date: 9/25/2017 5:40:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrandMain](
	[Id] [int] IDENTITY(111,111) NOT NULL,
	[BrandName] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/25/2017 5:40:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(11,11) NOT NULL,
	[CategoryName] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 9/25/2017 5:40:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Barcode] [nvarchar](200) NULL,
	[Model] [nvarchar](200) NULL,
	[Size] [nvarchar](200) NULL,
	[Color] [nvarchar](200) NULL,
	[Price] [int] NULL,
	[Unit] [nvarchar](200) NULL,
	[GroupType] [nvarchar](200) NULL,
	[ProductName] [nvarchar](200) NULL,
	[Properties] [nvarchar](200) NULL,
	[BrandID] [int] NULL,
	[CategoryID] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [BrandMainID], [BrandSubName]) VALUES (5, 111, N'AMERICAN TOURISTER')
INSERT [dbo].[Brand] ([Id], [BrandMainID], [BrandSubName]) VALUES (10, 222, N'BAOBI')
INSERT [dbo].[Brand] ([Id], [BrandMainID], [BrandSubName]) VALUES (15, 333, N'HIGH SIERRA')
INSERT [dbo].[Brand] ([Id], [BrandMainID], [BrandSubName]) VALUES (20, 444, N'KAMILIANT')
INSERT [dbo].[Brand] ([Id], [BrandMainID], [BrandSubName]) VALUES (25, 555, N'LIPAULT')
INSERT [dbo].[Brand] ([Id], [BrandMainID], [BrandSubName]) VALUES (30, 666, N'SAMSONITE')
INSERT [dbo].[Brand] ([Id], [BrandMainID], [BrandSubName]) VALUES (35, 666, N'SAMSONITE KID')
INSERT [dbo].[Brand] ([Id], [BrandMainID], [BrandSubName]) VALUES (40, 666, N'SAMSONITE RED')
INSERT [dbo].[Brand] ([Id], [BrandMainID], [BrandSubName]) VALUES (45, 666, N'SAMSONITE SBL')
SET IDENTITY_INSERT [dbo].[Brand] OFF
SET IDENTITY_INSERT [dbo].[BrandMain] ON 

INSERT [dbo].[BrandMain] ([Id], [BrandName]) VALUES (111, N'AMERICAN TOURISTER')
INSERT [dbo].[BrandMain] ([Id], [BrandName]) VALUES (222, N'BAOBI')
INSERT [dbo].[BrandMain] ([Id], [BrandName]) VALUES (333, N'HIGH SIERRA')
INSERT [dbo].[BrandMain] ([Id], [BrandName]) VALUES (444, N'KAMILIANT')
INSERT [dbo].[BrandMain] ([Id], [BrandName]) VALUES (555, N'LIPAULT')
INSERT [dbo].[BrandMain] ([Id], [BrandName]) VALUES (666, N'SAMSONITE')
SET IDENTITY_INSERT [dbo].[BrandMain] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (11, N'ACCESSOIRES')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (22, N'AT ACCESSORIES')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (33, N'AT DISNEY')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (44, N'BAOBI')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (55, N'BUSINESS COLLECTION')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (66, N'CASUAL')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (77, N'HARDSIDE')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (88, N'SAMSONITE KID')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (99, N'SAMSONITE RED')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (110, N'SMALL LEATHER GOODS')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (121, N'SOFTSIDE')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (132, N'TRAVEL ACCESSORIES')
SET IDENTITY_INSERT [dbo].[Category] OFF
ALTER TABLE [dbo].[Brand]  WITH CHECK ADD  CONSTRAINT [FK_Brand_BrandMain] FOREIGN KEY([BrandMainID])
REFERENCES [dbo].[BrandMain] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Brand] CHECK CONSTRAINT [FK_Brand_BrandMain]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateProduct]    Script Date: 9/25/2017 5:40:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HoangLC
-- Create date: 25.09.2017
-- Description:	Thêm Sửa Product
-- =============================================
Create PROCEDURE [dbo].[InsertUpdateProduct] 
	@Barcode nvarchar(200)
	,@Model nvarchar(200)
	,@Size nvarchar(200)
	,@Color nvarchar(200)
	,@Price int
	,@Unit nvarchar(200)
	,@GroupType nvarchar(200)
	,@ProductName nvarchar(200)
	,@Properties nvarchar(200)
	,@BrandID int
	,@CategoryID int
AS
BEGIN
	declare @CountID nvarchar(200)
	SELECT @CountID = Count(Barcode) from [dbo].[Product] where Barcode = @Barcode

	if @CountID = 1
	begin
		update [dbo].[Product] 
		set	[Model] = @Model
			,[Size]=@Size
			,[Color]=@Color
			,[Price]=@Price
			,[Unit]=@Unit
			,[GroupType]=@GroupType
			,[ProductName]=@ProductName
			,[Properties]=@Properties
			,[BrandID]=@BrandID
			,[CategoryID]=@CategoryID
		where Barcode = @Barcode
	end
	else if @CountID = 0
	begin
		Insert into [dbo].[Product]([Barcode],[Model],[Size],[Color],[Price],[Unit],[GroupType],[ProductName],[Properties],[BrandID],[CategoryID])
		values(@Barcode,@Model,@Size,@Color,@Price,@Unit,@GroupType,@ProductName,@Properties,@BrandID,@CategoryID)
	end
END

GO
