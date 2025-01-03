USE [master]
GO
/****** Object:  Database [FlightDocs]    Script Date: 12/30/2024 5:14:16 PM ******/
CREATE DATABASE [FlightDocs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FlightDocs', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\FlightDocs.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FlightDocs_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\FlightDocs_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FlightDocs] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FlightDocs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FlightDocs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FlightDocs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FlightDocs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FlightDocs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FlightDocs] SET ARITHABORT OFF 
GO
ALTER DATABASE [FlightDocs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FlightDocs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FlightDocs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FlightDocs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FlightDocs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FlightDocs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FlightDocs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FlightDocs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FlightDocs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FlightDocs] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FlightDocs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FlightDocs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FlightDocs] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FlightDocs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FlightDocs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FlightDocs] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FlightDocs] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FlightDocs] SET RECOVERY FULL 
GO
ALTER DATABASE [FlightDocs] SET  MULTI_USER 
GO
ALTER DATABASE [FlightDocs] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FlightDocs] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FlightDocs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FlightDocs] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FlightDocs] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FlightDocs] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FlightDocs', N'ON'
GO
ALTER DATABASE [FlightDocs] SET QUERY_STORE = ON
GO
ALTER DATABASE [FlightDocs] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FlightDocs]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountFlight]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountFlight](
	[AccountId] [uniqueidentifier] NOT NULL,
	[flightNo] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AccountFlight] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC,
	[flightNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[groupId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentDetails]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentDetails](
	[Id] [uniqueidentifier] NOT NULL,
	[DocId] [uniqueidentifier] NOT NULL,
	[updatedBy] [nvarchar](max) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
	[status] [int] NOT NULL,
	[version] [float] NOT NULL,
 CONSTRAINT [PK_DocumentDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TypeId] [uniqueidentifier] NOT NULL,
	[flightNo] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentTypePermission]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentTypePermission](
	[DocumentTypeId] [uniqueidentifier] NOT NULL,
	[PermissionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DocumentTypePermission] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentTypes]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DocumentTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[flightNo] [nvarchar](450) NOT NULL,
	[pointOfLoading] [nvarchar](max) NOT NULL,
	[pointOfUnloading] [nvarchar](max) NOT NULL,
	[departureDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED 
(
	[flightNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupPermission]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPermission](
	[GroupId] [uniqueidentifier] NOT NULL,
	[PermissionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_GroupPermission] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [uniqueidentifier] NOT NULL,
	[nameGroup] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [uniqueidentifier] NOT NULL,
	[GroupId] [uniqueidentifier] NOT NULL,
	[function] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UpdatedVersions]    Script Date: 12/30/2024 5:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpdatedVersions](
	[Id] [uniqueidentifier] NOT NULL,
	[DocumentId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Version] [float] NOT NULL,
	[groupId] [uniqueidentifier] NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UpdatedVersions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AccountFlight_flightNo]    Script Date: 12/30/2024 5:14:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_AccountFlight_flightNo] ON [dbo].[AccountFlight]
(
	[flightNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Accounts_groupId]    Script Date: 12/30/2024 5:14:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accounts_groupId] ON [dbo].[Accounts]
(
	[groupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DocumentDetails_DocId]    Script Date: 12/30/2024 5:14:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DocumentDetails_DocId] ON [dbo].[DocumentDetails]
(
	[DocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Documents_flightNo]    Script Date: 12/30/2024 5:14:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Documents_flightNo] ON [dbo].[Documents]
(
	[flightNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Documents_TypeId]    Script Date: 12/30/2024 5:14:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Documents_TypeId] ON [dbo].[Documents]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DocumentTypePermission_PermissionId]    Script Date: 12/30/2024 5:14:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_DocumentTypePermission_PermissionId] ON [dbo].[DocumentTypePermission]
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupPermission_PermissionId]    Script Date: 12/30/2024 5:14:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_GroupPermission_PermissionId] ON [dbo].[GroupPermission]
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UpdatedVersions_DocumentId]    Script Date: 12/30/2024 5:14:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_UpdatedVersions_DocumentId] ON [dbo].[UpdatedVersions]
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Documents] ADD  DEFAULT (N'') FOR [flightNo]
GO
ALTER TABLE [dbo].[AccountFlight]  WITH CHECK ADD  CONSTRAINT [FK_AccountFlight_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccountFlight] CHECK CONSTRAINT [FK_AccountFlight_Accounts_AccountId]
GO
ALTER TABLE [dbo].[AccountFlight]  WITH CHECK ADD  CONSTRAINT [FK_AccountFlight_Flights_flightNo] FOREIGN KEY([flightNo])
REFERENCES [dbo].[Flights] ([flightNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccountFlight] CHECK CONSTRAINT [FK_AccountFlight_Flights_flightNo]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Groups_groupId] FOREIGN KEY([groupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Groups_groupId]
GO
ALTER TABLE [dbo].[DocumentDetails]  WITH CHECK ADD  CONSTRAINT [FK_DocumentDetails_Documents_DocId] FOREIGN KEY([DocId])
REFERENCES [dbo].[Documents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DocumentDetails] CHECK CONSTRAINT [FK_DocumentDetails_Documents_DocId]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_DocumentTypes_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[DocumentTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_DocumentTypes_TypeId]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_Flights_flightNo] FOREIGN KEY([flightNo])
REFERENCES [dbo].[Flights] ([flightNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_Flights_flightNo]
GO
ALTER TABLE [dbo].[DocumentTypePermission]  WITH CHECK ADD  CONSTRAINT [FK_DocumentTypePermission_DocumentTypes_DocumentTypeId] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[DocumentTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DocumentTypePermission] CHECK CONSTRAINT [FK_DocumentTypePermission_DocumentTypes_DocumentTypeId]
GO
ALTER TABLE [dbo].[DocumentTypePermission]  WITH CHECK ADD  CONSTRAINT [FK_DocumentTypePermission_Permissions_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DocumentTypePermission] CHECK CONSTRAINT [FK_DocumentTypePermission_Permissions_PermissionId]
GO
ALTER TABLE [dbo].[GroupPermission]  WITH CHECK ADD  CONSTRAINT [FK_GroupPermission_Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupPermission] CHECK CONSTRAINT [FK_GroupPermission_Groups_GroupId]
GO
ALTER TABLE [dbo].[GroupPermission]  WITH CHECK ADD  CONSTRAINT [FK_GroupPermission_Permissions_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupPermission] CHECK CONSTRAINT [FK_GroupPermission_Permissions_PermissionId]
GO
ALTER TABLE [dbo].[UpdatedVersions]  WITH CHECK ADD  CONSTRAINT [FK_UpdatedVersions_Documents_DocumentId] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Documents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UpdatedVersions] CHECK CONSTRAINT [FK_UpdatedVersions_Documents_DocumentId]
GO
USE [master]
GO
ALTER DATABASE [FlightDocs] SET  READ_WRITE 
GO
