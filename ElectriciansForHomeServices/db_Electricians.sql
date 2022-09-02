Create Database [db_ElectriciansForHome]
USE [db_ElectriciansForHome]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 09/02/2022 1:26:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[UserFID] [int] NULL,
	[ElectricianFID] [int] NULL,
	[BookingDate] [date] NULL,
	[BookingTime] [time](7) NULL,
	[WorkStartDate] [date] NULL,
	[WorkEndDate] [date] NULL,
	[Status] [nvarchar](50) NULL,
	[Details] [nvarchar](250) NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 09/02/2022 1:26:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Details] [nvarchar](50) NULL,
	[Picture] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 09/02/2022 1:26:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[Details] [nvarchar](250) NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Electrician]    Script Date: 09/02/2022 1:26:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Electrician](
	[ElecID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Age] [float] NOT NULL,
	[CNIC] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[ExpYears] [float] NOT NULL,
	[Phone] [nchar](30) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RatePerDay] [float] NOT NULL,
	[CItyFID] [int] NOT NULL,
	[CatFID] [int] NOT NULL,
	[Rating] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[Details] [nvarchar](250) NULL,
 CONSTRAINT [PK_Electrician] PRIMARY KEY CLUSTERED 
(
	[ElecID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/02/2022 1:26:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CNIC] [nvarchar](50) NOT NULL,
	[Details] [nvarchar](250) NULL,
	[Status] [nvarchar](50) NULL,
	[Image] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 
GO
INSERT [dbo].[Bookings] ([BookingID], [UserFID], [ElectricianFID], [BookingDate], [BookingTime], [WorkStartDate], [WorkEndDate], [Status], [Details]) VALUES (3002, 2, 7, CAST(N'2022-08-25' AS Date), CAST(N'16:58:21.0301185' AS Time), CAST(N'2022-08-27' AS Date), CAST(N'2022-08-28' AS Date), N'Rejected', NULL)
GO
INSERT [dbo].[Bookings] ([BookingID], [UserFID], [ElectricianFID], [BookingDate], [BookingTime], [WorkStartDate], [WorkEndDate], [Status], [Details]) VALUES (3003, 2, 7, CAST(N'2022-08-25' AS Date), CAST(N'17:01:53.2503796' AS Time), CAST(N'2022-08-29' AS Date), CAST(N'2022-09-03' AS Date), N'Postponed', NULL)
GO
INSERT [dbo].[Bookings] ([BookingID], [UserFID], [ElectricianFID], [BookingDate], [BookingTime], [WorkStartDate], [WorkEndDate], [Status], [Details]) VALUES (4002, 2, 6, CAST(N'2022-08-30' AS Date), CAST(N'23:20:55.4809226' AS Time), CAST(N'2022-09-01' AS Date), CAST(N'2022-09-02' AS Date), N'Pending', NULL)
GO
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CatID], [Name], [Details], [Picture], [Status]) VALUES (1004, N'Computer Technician ', N'Good', N'14.jpg', N'Active')
GO
INSERT [dbo].[Categories] ([CatID], [Name], [Details], [Picture], [Status]) VALUES (1005, N'Plumber', N'Very Good ', N'13.jpg', N'Available')
GO
INSERT [dbo].[Categories] ([CatID], [Name], [Details], [Picture], [Status]) VALUES (1006, N'Electrician', N'Very Good', N'12.jpg', N'Available')
GO
INSERT [dbo].[Categories] ([CatID], [Name], [Details], [Picture], [Status]) VALUES (1007, N'Electrician', N'Good', N'19.jpg', N'Available')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 
GO
INSERT [dbo].[Cities] ([CityID], [Name], [Picture], [Details]) VALUES (1002, N'Lahore', N'17.jpg', N'Lahore')
GO
INSERT [dbo].[Cities] ([CityID], [Name], [Picture], [Details]) VALUES (1003, N'Gujranwala ', N'download.jpg', N'Gujranwala ')
GO
INSERT [dbo].[Cities] ([CityID], [Name], [Picture], [Details]) VALUES (1004, N'Islamabad', N'18.jpg', N'Islamabad')
GO
INSERT [dbo].[Cities] ([CityID], [Name], [Picture], [Details]) VALUES (1005, N'Karachi', N'16.jpg', N'Karachi')
GO
INSERT [dbo].[Cities] ([CityID], [Name], [Picture], [Details]) VALUES (1006, N'Faisalabad', N'15.jpg', N'Faisalabad')
GO
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Electrician] ON 
GO
INSERT [dbo].[Electrician] ([ElecID], [Name], [Age], [CNIC], [Picture], [ExpYears], [Phone], [Email], [Password], [RatePerDay], [CItyFID], [CatFID], [Rating], [Status], [Details]) VALUES (5, N'Khurram Shahzad', 28, N'3410121087865', N'14.jpg', 4, N'3484086662                    ', N'developer.khurramshahzad@gmail.com', N'124', 2000, 1003, 1004, 5, N'Available', N'Very Good ')
GO
INSERT [dbo].[Electrician] ([ElecID], [Name], [Age], [CNIC], [Picture], [ExpYears], [Phone], [Email], [Password], [RatePerDay], [CItyFID], [CatFID], [Rating], [Status], [Details]) VALUES (6, N'Ali Ahmad', 25, N'3410121087865', N'12.jpg', 5, N'03484086662                   ', N'AliAhmad123@gmail.com', N'124', 3000, 1002, 1006, 5, N'Available', N'Good')
GO
INSERT [dbo].[Electrician] ([ElecID], [Name], [Age], [CNIC], [Picture], [ExpYears], [Phone], [Email], [Password], [RatePerDay], [CItyFID], [CatFID], [Rating], [Status], [Details]) VALUES (7, N'Hamza Ali', 29, N'3410121087865', N'13.jpg', 5, N'03484086472                   ', N'HamzaAli456@gmail.com', N'124', 4000, 1004, 1005, 4, N'Available', N'Good')
GO
INSERT [dbo].[Electrician] ([ElecID], [Name], [Age], [CNIC], [Picture], [ExpYears], [Phone], [Email], [Password], [RatePerDay], [CItyFID], [CatFID], [Rating], [Status], [Details]) VALUES (8, N'Nimra Khan', 22, N'3410125587865', N'19.jpg', 4, N'3484676662                    ', N'NimraKhan456@gmail.com', N'124', 4000, 1005, 1006, 5, N'Active', N'Very Good ')
GO
INSERT [dbo].[Electrician] ([ElecID], [Name], [Age], [CNIC], [Picture], [ExpYears], [Phone], [Email], [Password], [RatePerDay], [CItyFID], [CatFID], [Rating], [Status], [Details]) VALUES (1005, N'Khurram Shahzad', 22, N'3410121087865', N'ab3.jpg', 4, N'03484086662                   ', N'khurramshahzadbilal786@gmail.com', N'124', 2000, 1005, 1006, 1, N'Active', N'Machine Wash Service')
GO
SET IDENTITY_INSERT [dbo].[Electrician] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [Name], [Phone], [Address], [Email], [Password], [CNIC], [Details], [Status], [Image], [Type]) VALUES (1, N'Demo User', N'03000000000', N'', N'user@user.com', N'user', N'3400000000', NULL, NULL, NULL, N'User')
GO
INSERT [dbo].[Users] ([UserID], [Name], [Phone], [Address], [Email], [Password], [CNIC], [Details], [Status], [Image], [Type]) VALUES (2, N'Khurram Shahzad', N'03484086662', N'Gujranwala', N'khurramshahzadbilal786@gmail.com', N'124', N'124', N'Active', NULL, NULL, N'User')
GO
INSERT [dbo].[Users] ([UserID], [Name], [Phone], [Address], [Email], [Password], [CNIC], [Details], [Status], [Image], [Type]) VALUES (4, N'Admin', N'213', N'234', N'admin@admin.com', N'admin', N'1324234', N'Active', NULL, NULL, N'Admin')
GO
INSERT [dbo].[Users] ([UserID], [Name], [Phone], [Address], [Email], [Password], [CNIC], [Details], [Status], [Image], [Type]) VALUES (1003, N'Khurram Shahzad', N'3484086662', N'Gujranwala', N'developer.khurramshahzad@gmail.com', N'123', N'123', N'Active', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Electrician] FOREIGN KEY([ElectricianFID])
REFERENCES [dbo].[Electrician] ([ElecID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Electrician]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Users] FOREIGN KEY([UserFID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Users]
GO
ALTER TABLE [dbo].[Electrician]  WITH CHECK ADD  CONSTRAINT [FK_Electrician_Categories] FOREIGN KEY([CatFID])
REFERENCES [dbo].[Categories] ([CatID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Electrician] CHECK CONSTRAINT [FK_Electrician_Categories]
GO
ALTER TABLE [dbo].[Electrician]  WITH CHECK ADD  CONSTRAINT [FK_Electrician_Cities] FOREIGN KEY([CItyFID])
REFERENCES [dbo].[Cities] ([CityID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Electrician] CHECK CONSTRAINT [FK_Electrician_Cities]
GO
