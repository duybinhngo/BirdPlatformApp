USE [master]
GO
/****** Object:  Database [BirdPlatform]    Script Date: 10/14/2023 8:30:00 PM ******/
CREATE DATABASE [BirdPlatform]
GO
ALTER DATABASE [BirdPlatform] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BirdPlatform].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BirdPlatform] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BirdPlatform] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BirdPlatform] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BirdPlatform] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BirdPlatform] SET ARITHABORT OFF 
GO
ALTER DATABASE [BirdPlatform] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BirdPlatform] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BirdPlatform] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BirdPlatform] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BirdPlatform] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BirdPlatform] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BirdPlatform] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BirdPlatform] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BirdPlatform] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BirdPlatform] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BirdPlatform] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BirdPlatform] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BirdPlatform] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BirdPlatform] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BirdPlatform] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BirdPlatform] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BirdPlatform] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BirdPlatform] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BirdPlatform] SET  MULTI_USER 
GO
ALTER DATABASE [BirdPlatform] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BirdPlatform] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BirdPlatform] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BirdPlatform] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BirdPlatform] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BirdPlatform] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BirdPlatform] SET QUERY_STORE = OFF
GO
USE [BirdPlatform]
GO
/****** Object:  Table [dbo].[BirdService]    Script Date: 10/14/2023 8:30:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BirdService](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productName] [nvarchar](255) NOT NULL,
	[productPrice] [decimal](18, 0) NOT NULL,
	[description] [nvarchar](255) NULL,
	[isActive] [int] NOT NULL,
	[typeId] [int] NOT NULL,
	[providerId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/14/2023 8:30:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[address] [nvarchar](255) NULL,
	[phoneNumber] [nvarchar](255) NULL,
	[birthday] [datetime] NULL,
	[roleId] [int] NOT NULL,
	[isActive] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/14/2023 8:30:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[totalPrice] [decimal](18, 0) NOT NULL,
	[payment_online] [bit] NULL,
	[status] [int] NOT NULL,
	[description] [nvarchar](255) NOT NULL,
	[orderDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 10/14/2023 8:30:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[providerName] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[address] [nvarchar](255) NULL,
	[phoneNumber] [nvarchar](255) NULL,
	[birthday] [datetime] NULL,
	[roleId] [int] NOT NULL,
	[isActive] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 10/14/2023 8:30:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[birdServiceId] [int] NOT NULL,
	[scheduleDate] [datetime] NOT NULL,
	[availableSlots] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[created_by] [int] NOT NULL,
	[deleted_at] [datetime] NOT NULL,
	[delete_by] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleTicket]    Script Date: 10/14/2023 8:30:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleTicket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[scheduleId] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[totalPrice] [decimal](18, 0) NOT NULL,
	[payment_online] [bit] NULL,
	[status] [int] NOT NULL,
	[description] [nvarchar](255) NOT NULL,
	[orderDate] [datetime] NOT NULL,
	[orderId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ((0)) FOR [payment_online]
GO
ALTER TABLE [dbo].[ScheduleTicket] ADD  DEFAULT ((0)) FOR [payment_online]
GO
ALTER TABLE [dbo].[BirdService]  WITH CHECK ADD FOREIGN KEY([providerId])
REFERENCES [dbo].[Provider] ([id])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([customerId])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([birdServiceId])
REFERENCES [dbo].[BirdService] ([id])
GO
ALTER TABLE [dbo].[ScheduleTicket]  WITH CHECK ADD FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[ScheduleTicket]  WITH CHECK ADD FOREIGN KEY([scheduleId])
REFERENCES [dbo].[Schedule] ([Id])
GO
USE [master]
GO
ALTER DATABASE [BirdPlatform] SET  READ_WRITE 
GO
