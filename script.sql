USE [master]
GO
/****** Object:  Database [Pitalytics]    Script Date: 8/29/2019 2:23:34 PM ******/
CREATE DATABASE [Pitalytics]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pitalytics', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Pitalytics.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Pitalytics_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Pitalytics_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Pitalytics] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pitalytics].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pitalytics] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pitalytics] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pitalytics] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pitalytics] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pitalytics] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pitalytics] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pitalytics] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Pitalytics] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pitalytics] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pitalytics] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pitalytics] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pitalytics] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pitalytics] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pitalytics] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pitalytics] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pitalytics] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pitalytics] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pitalytics] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pitalytics] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pitalytics] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pitalytics] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pitalytics] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pitalytics] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pitalytics] SET RECOVERY FULL 
GO
ALTER DATABASE [Pitalytics] SET  MULTI_USER 
GO
ALTER DATABASE [Pitalytics] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pitalytics] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pitalytics] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pitalytics] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Pitalytics', N'ON'
GO
USE [Pitalytics]
GO
/****** Object:  Table [dbo].[ActionLog]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ActionLog](
	[ActionLogId] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [varchar](100) NOT NULL,
	[Action] [varchar](50) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[Granted] [bit] NOT NULL,
	[DateStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ActionLog] PRIMARY KEY CLUSTERED 
(
	[ActionLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdminUserTable]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUserTable](
	[AdminUserId] [int] IDENTITY(1,1) NOT NULL,
	[AdminId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AdminUserTable] PRIMARY KEY CLUSTERED 
(
	[AdminUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AgentOfDeductionBranch]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgentOfDeductionBranch](
	[AgentOfDeductionBranchId] [int] IDENTITY(1,1) NOT NULL,
	[AgentOfDeductionId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [bit] NULL,
 CONSTRAINT [PK_AgentOfDeductionBranch] PRIMARY KEY CLUSTERED 
(
	[AgentOfDeductionBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AgentOfDeductionInfo]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AgentOfDeductionInfo](
	[AgentOfDeductionId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](25) NOT NULL,
	[FIRS_TIN] [varchar](25) NOT NULL,
	[BVN] [varchar](25) NOT NULL,
	[CACRegNo] [varchar](25) NOT NULL,
	[IndustryId] [int] NOT NULL,
	[WebsiteAddress] [varchar](200) NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[UserRegistrationId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_AgentOfDeductionInfo] PRIMARY KEY CLUSTERED 
(
	[AgentOfDeductionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AppActivityLog]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AppActivityLog](
	[AppActivityLogId] [int] IDENTITY(1,1) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[UserEmail] [varchar](100) NOT NULL,
	[Activity] [varchar](max) NOT NULL,
	[OrderIdentifer] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AppActivityLog] PRIMARY KEY CLUSTERED 
(
	[AppActivityLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Beneficiary]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Beneficiary](
	[BeneficiaryId] [int] IDENTITY(1,1) NOT NULL,
	[CACRegNo] [int] NOT NULL,
	[BVN] [varchar](25) NOT NULL,
	[JurisdictionId] [int] NOT NULL,
	[BeneficiaryName] [varchar](25) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Beneficiary] PRIMARY KEY CLUSTERED 
(
	[BeneficiaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [varchar](20) NOT NULL,
	[Description] [varchar](40) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BranchJurisdiction]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchJurisdiction](
	[BranchJurisdictionId] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NOT NULL,
	[JurisdictionId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_BranchJurisdiction] PRIMARY KEY CLUSTERED 
(
	[BranchJurisdictionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DigitalFile]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DigitalFile](
	[DigitalFileId] [int] IDENTITY(1,1) NOT NULL,
	[FileContent] [varbinary](max) NOT NULL,
	[DigitalTypeId] [int] NOT NULL,
	[FileExtension] [varchar](10) NULL,
	[DateCreated] [datetime] NULL,
	[IsActive] [bit] NULL,
	[ContentType] [varchar](100) NULL,
	[FileName] [varchar](100) NOT NULL,
	[FileTypeId] [int] NOT NULL,
 CONSTRAINT [PK_DigitalFile] PRIMARY KEY CLUSTERED 
(
	[DigitalFileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FileType]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileType](
	[FileTypeId] [int] IDENTITY(1,1) NOT NULL,
	[FileTypeName] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FileType] PRIMARY KEY CLUSTERED 
(
	[FileTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IncomeType]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IncomeType](
	[IncomeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[IncomeTypeName] [varchar](20) NOT NULL,
	[Description] [varchar](40) NULL,
	[WHT_Rate] [varchar](10) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_IncomeType] PRIMARY KEY CLUSTERED 
(
	[IncomeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Industry]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Industry](
	[IndustryId] [int] IDENTITY(1,1) NOT NULL,
	[IndustryName] [varchar](20) NOT NULL,
	[Description] [varchar](40) NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Industry] PRIMARY KEY CLUSTERED 
(
	[IndustryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InlandRevenue]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InlandRevenue](
	[InlandRevenueId] [int] IDENTITY(1,1) NOT NULL,
	[InlandRevenueName] [varchar](50) NOT NULL,
	[DateCreated] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Revenue] PRIMARY KEY CLUSTERED 
(
	[InlandRevenueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Jurisdiction]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Jurisdiction](
	[JurisdictionId] [int] IDENTITY(1,1) NOT NULL,
	[JurisdictionName] [varchar](20) NOT NULL,
	[Description] [varchar](40) NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Jurisdiction] PRIMARY KEY CLUSTERED 
(
	[JurisdictionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JurisdictionIncomeType]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JurisdictionIncomeType](
	[JurisdictionIncomeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[JurisdictionId] [int] NOT NULL,
	[IncomeTypeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_JurisdictionIncomeType] PRIMARY KEY CLUSTERED 
(
	[JurisdictionIncomeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](25) NOT NULL,
	[Description] [varchar](25) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoleStatus]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminRole] [varchar](20) NOT NULL,
	[UserRole] [varchar](20) NOT NULL,
 CONSTRAINT [PK_AdminRoleUserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxAuthority]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxAuthority](
	[TaxAuthorityId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](40) NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[InlandRevenueId] [int] NOT NULL,
	[JurisdictionId] [int] NOT NULL,
	[UserRegistrationId] [int] NOT NULL,
 CONSTRAINT [PK_TaxAuthority] PRIMARY KEY CLUSTERED 
(
	[TaxAuthorityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxReport]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxReport](
	[TaxReportId] [int] IDENTITY(1,1) NOT NULL,
	[Year] [varchar](7) NOT NULL,
	[IncomeTypeId] [int] NOT NULL,
	[BVN] [varchar](20) NOT NULL,
	[IncomeAmount] [decimal](18, 0) NOT NULL,
	[TaxAmount] [decimal](18, 0) NOT NULL,
	[BeneficiaryTIN] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[TaxReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxReturn]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxReturn](
	[TaxReturnId] [int] IDENTITY(1,1) NOT NULL,
	[BeneficiaryTin] [varchar](25) NOT NULL,
	[BeneficiaryName] [varchar](50) NOT NULL,
	[BVN] [varchar](25) NOT NULL,
	[BeneficiaryAddress] [varchar](50) NOT NULL,
	[InvoiceNo] [varchar](50) NOT NULL,
	[ContractDate] [date] NOT NULL,
	[ContractDescription] [varchar](50) NOT NULL,
	[ContractAmount] [varchar](50) NOT NULL,
	[WHT_Rate] [varchar](25) NOT NULL,
	[WHT_Amount] [varchar](25) NOT NULL,
	[IncomeTypeId] [int] NOT NULL,
	[UserRegistrationId] [int] NOT NULL,
	[AgentOfDeductionId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[JurisdictionId] [int] NOT NULL,
 CONSTRAINT [PK_TaxReturn] PRIMARY KEY CLUSTERED 
(
	[TaxReturnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserActivationCode]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserActivationCode](
	[UserActivationCodeId] [int] IDENTITY(1,1) NOT NULL,
	[UserRegistrationId] [int] NOT NULL,
	[ActivationCode] [varchar](50) NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_UserActivationCode] PRIMARY KEY CLUSTERED 
(
	[UserActivationCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserBranch]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBranch](
	[UserBranchId] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NOT NULL,
	[UserRegistrationId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_UserBranch] PRIMARY KEY CLUSTERED 
(
	[UserBranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRegistration]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRegistration](
	[UserRegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](25) NULL,
	[LastName] [varchar](25) NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](150) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateVerified] [datetime] NOT NULL,
	[IsUserVerified] [bit] NULL,
 CONSTRAINT [PK_UserRegistration] PRIMARY KEY CLUSTERED 
(
	[UserRegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 8/29/2019 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AdminUserTable] ON 

INSERT [dbo].[AdminUserTable] ([AdminUserId], [AdminId], [UserId]) VALUES (21, 1, 31)
INSERT [dbo].[AdminUserTable] ([AdminUserId], [AdminId], [UserId]) VALUES (22, 32, 33)
INSERT [dbo].[AdminUserTable] ([AdminUserId], [AdminId], [UserId]) VALUES (23, 17, 34)
INSERT [dbo].[AdminUserTable] ([AdminUserId], [AdminId], [UserId]) VALUES (24, 36, 37)
INSERT [dbo].[AdminUserTable] ([AdminUserId], [AdminId], [UserId]) VALUES (25, 36, 38)
SET IDENTITY_INSERT [dbo].[AdminUserTable] OFF
SET IDENTITY_INSERT [dbo].[AgentOfDeductionBranch] ON 

INSERT [dbo].[AgentOfDeductionBranch] ([AgentOfDeductionBranchId], [AgentOfDeductionId], [BranchId], [IsActive], [DateCreated]) VALUES (19, 10, 20, 0, NULL)
INSERT [dbo].[AgentOfDeductionBranch] ([AgentOfDeductionBranchId], [AgentOfDeductionId], [BranchId], [IsActive], [DateCreated]) VALUES (20, 10, 21, 0, NULL)
INSERT [dbo].[AgentOfDeductionBranch] ([AgentOfDeductionBranchId], [AgentOfDeductionId], [BranchId], [IsActive], [DateCreated]) VALUES (21, 10, 22, 0, NULL)
INSERT [dbo].[AgentOfDeductionBranch] ([AgentOfDeductionBranchId], [AgentOfDeductionId], [BranchId], [IsActive], [DateCreated]) VALUES (22, 10, 23, 0, NULL)
INSERT [dbo].[AgentOfDeductionBranch] ([AgentOfDeductionBranchId], [AgentOfDeductionId], [BranchId], [IsActive], [DateCreated]) VALUES (23, 10, 24, 0, NULL)
INSERT [dbo].[AgentOfDeductionBranch] ([AgentOfDeductionBranchId], [AgentOfDeductionId], [BranchId], [IsActive], [DateCreated]) VALUES (24, 10, 25, 0, NULL)
INSERT [dbo].[AgentOfDeductionBranch] ([AgentOfDeductionBranchId], [AgentOfDeductionId], [BranchId], [IsActive], [DateCreated]) VALUES (25, 10, 26, 0, NULL)
SET IDENTITY_INSERT [dbo].[AgentOfDeductionBranch] OFF
SET IDENTITY_INSERT [dbo].[AgentOfDeductionInfo] ON 

INSERT [dbo].[AgentOfDeductionInfo] ([AgentOfDeductionId], [CompanyName], [FIRS_TIN], [BVN], [CACRegNo], [IndustryId], [WebsiteAddress], [IsVerified], [UserRegistrationId], [IsActive], [DateCreated]) VALUES (10, N'Automata Associates', N'3445ddd', N'12345', N'Jookoyoski@gmail.com', 1008, N'www.gmail.com', 0, 36, 1, CAST(0x0000AAB500A7D240 AS DateTime))
INSERT [dbo].[AgentOfDeductionInfo] ([AgentOfDeductionId], [CompanyName], [FIRS_TIN], [BVN], [CACRegNo], [IndustryId], [WebsiteAddress], [IsVerified], [UserRegistrationId], [IsActive], [DateCreated]) VALUES (11, N'Odor', N'3445ddd', N'12345', N'11234455', 1008, N'www.gmail.com', 0, 39, 1, CAST(0x0000AAB500C62D34 AS DateTime))
SET IDENTITY_INSERT [dbo].[AgentOfDeductionInfo] OFF
SET IDENTITY_INSERT [dbo].[Branch] ON 

INSERT [dbo].[Branch] ([BranchId], [BranchName], [Description], [IsActive], [DateCreated]) VALUES (24, N'Automata Jakande', N'Automata Jakande', 1, NULL)
INSERT [dbo].[Branch] ([BranchId], [BranchName], [Description], [IsActive], [DateCreated]) VALUES (25, N'Automata  Kuto', N'Automata  Kuto', 1, NULL)
INSERT [dbo].[Branch] ([BranchId], [BranchName], [Description], [IsActive], [DateCreated]) VALUES (26, N'Automata Dugbe', N'Automata Dugbe', 1, NULL)
SET IDENTITY_INSERT [dbo].[Branch] OFF
SET IDENTITY_INSERT [dbo].[BranchJurisdiction] ON 

INSERT [dbo].[BranchJurisdiction] ([BranchJurisdictionId], [BranchId], [JurisdictionId], [IsActive], [DateCreated]) VALUES (19, 20, 15, 0, NULL)
INSERT [dbo].[BranchJurisdiction] ([BranchJurisdictionId], [BranchId], [JurisdictionId], [IsActive], [DateCreated]) VALUES (20, 21, 14, 0, NULL)
INSERT [dbo].[BranchJurisdiction] ([BranchJurisdictionId], [BranchId], [JurisdictionId], [IsActive], [DateCreated]) VALUES (21, 22, 16, 0, NULL)
INSERT [dbo].[BranchJurisdiction] ([BranchJurisdictionId], [BranchId], [JurisdictionId], [IsActive], [DateCreated]) VALUES (22, 23, 15, 0, NULL)
INSERT [dbo].[BranchJurisdiction] ([BranchJurisdictionId], [BranchId], [JurisdictionId], [IsActive], [DateCreated]) VALUES (23, 24, 14, 0, NULL)
INSERT [dbo].[BranchJurisdiction] ([BranchJurisdictionId], [BranchId], [JurisdictionId], [IsActive], [DateCreated]) VALUES (24, 25, 14, 0, NULL)
INSERT [dbo].[BranchJurisdiction] ([BranchJurisdictionId], [BranchId], [JurisdictionId], [IsActive], [DateCreated]) VALUES (25, 26, 15, 0, NULL)
SET IDENTITY_INSERT [dbo].[BranchJurisdiction] OFF
SET IDENTITY_INSERT [dbo].[IncomeType] ON 

INSERT [dbo].[IncomeType] ([IncomeTypeId], [IncomeTypeName], [Description], [WHT_Rate], [IsActive], [DateCreated]) VALUES (24, N'Rent Hire', NULL, N'10', 1, NULL)
INSERT [dbo].[IncomeType] ([IncomeTypeId], [IncomeTypeName], [Description], [WHT_Rate], [IsActive], [DateCreated]) VALUES (25, N'Technical Services', NULL, N'10', 1, NULL)
INSERT [dbo].[IncomeType] ([IncomeTypeId], [IncomeTypeName], [Description], [WHT_Rate], [IsActive], [DateCreated]) VALUES (26, N'Dividend', NULL, N'10', 1, NULL)
INSERT [dbo].[IncomeType] ([IncomeTypeId], [IncomeTypeName], [Description], [WHT_Rate], [IsActive], [DateCreated]) VALUES (27, N'Prof Services', NULL, N'10', 1, NULL)
INSERT [dbo].[IncomeType] ([IncomeTypeId], [IncomeTypeName], [Description], [WHT_Rate], [IsActive], [DateCreated]) VALUES (28, N'Interest', NULL, N'10', 1, NULL)
INSERT [dbo].[IncomeType] ([IncomeTypeId], [IncomeTypeName], [Description], [WHT_Rate], [IsActive], [DateCreated]) VALUES (29, N'Royalty', NULL, N'10', 1, NULL)
INSERT [dbo].[IncomeType] ([IncomeTypeId], [IncomeTypeName], [Description], [WHT_Rate], [IsActive], [DateCreated]) VALUES (30, N'vvvvvv', NULL, N'10', 1, NULL)
SET IDENTITY_INSERT [dbo].[IncomeType] OFF
SET IDENTITY_INSERT [dbo].[Industry] ON 

INSERT [dbo].[Industry] ([IndustryId], [IndustryName], [Description], [IsActive], [DateCreated]) VALUES (1008, N'Commerce', NULL, 1, NULL)
INSERT [dbo].[Industry] ([IndustryId], [IndustryName], [Description], [IsActive], [DateCreated]) VALUES (1009, N'Tourism', NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Industry] OFF
SET IDENTITY_INSERT [dbo].[InlandRevenue] ON 

INSERT [dbo].[InlandRevenue] ([InlandRevenueId], [InlandRevenueName], [DateCreated], [IsActive]) VALUES (4, N'Ogun Inland Revenue', CAST(0x000084D000000000 AS DateTime), 1)
INSERT [dbo].[InlandRevenue] ([InlandRevenueId], [InlandRevenueName], [DateCreated], [IsActive]) VALUES (7, N'Lagos Inland Revenue', CAST(0x0000AAAE00C5D737 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[InlandRevenue] OFF
SET IDENTITY_INSERT [dbo].[Jurisdiction] ON 

INSERT [dbo].[Jurisdiction] ([JurisdictionId], [JurisdictionName], [Description], [IsActive], [DateCreated]) VALUES (14, N'Lagos State', NULL, 1, NULL)
INSERT [dbo].[Jurisdiction] ([JurisdictionId], [JurisdictionName], [Description], [IsActive], [DateCreated]) VALUES (15, N'Oyo State', NULL, 1, NULL)
INSERT [dbo].[Jurisdiction] ([JurisdictionId], [JurisdictionName], [Description], [IsActive], [DateCreated]) VALUES (16, N'Ogun State', NULL, 1, NULL)
INSERT [dbo].[Jurisdiction] ([JurisdictionId], [JurisdictionName], [Description], [IsActive], [DateCreated]) VALUES (17, N' bvbbv', NULL, 1, NULL)
INSERT [dbo].[Jurisdiction] ([JurisdictionId], [JurisdictionName], [Description], [IsActive], [DateCreated]) VALUES (18, N' bvbyyy', NULL, 1, NULL)
INSERT [dbo].[Jurisdiction] ([JurisdictionId], [JurisdictionName], [Description], [IsActive], [DateCreated]) VALUES (19, N'bbbbb', NULL, 1, NULL)
INSERT [dbo].[Jurisdiction] ([JurisdictionId], [JurisdictionName], [Description], [IsActive], [DateCreated]) VALUES (20, N'nnnnnmmm', NULL, 1, NULL)
INSERT [dbo].[Jurisdiction] ([JurisdictionId], [JurisdictionName], [Description], [IsActive], [DateCreated]) VALUES (21, N'nnnnn', NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Jurisdiction] OFF
SET IDENTITY_INSERT [dbo].[JurisdictionIncomeType] ON 

INSERT [dbo].[JurisdictionIncomeType] ([JurisdictionIncomeTypeId], [JurisdictionId], [IncomeTypeId], [IsActive], [DateCreated]) VALUES (11, 14, 26, 0, NULL)
SET IDENTITY_INSERT [dbo].[JurisdictionIncomeType] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description], [IsActive], [DateCreated]) VALUES (14, N'SA', N'This is System Admin role', 1, CAST(0x00009DCD00000000 AS DateTime))
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description], [IsActive], [DateCreated]) VALUES (30, N'SAU', N'This is users', 1, NULL)
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description], [IsActive], [DateCreated]) VALUES (31, N'TA', N'This is tax Authority', 1, NULL)
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description], [IsActive], [DateCreated]) VALUES (49, N'TAU', N'tax', 1, NULL)
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description], [IsActive], [DateCreated]) VALUES (50, N'TAG', N'tax', 1, NULL)
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description], [IsActive], [DateCreated]) VALUES (51, N'TAGU', N'tax', 1, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[RoleStatus] ON 

INSERT [dbo].[RoleStatus] ([Id], [AdminRole], [UserRole]) VALUES (1, N'SA', N'SAU')
INSERT [dbo].[RoleStatus] ([Id], [AdminRole], [UserRole]) VALUES (2, N'TA', N'TAU')
INSERT [dbo].[RoleStatus] ([Id], [AdminRole], [UserRole]) VALUES (3, N'TAG', N'TAGU')
SET IDENTITY_INSERT [dbo].[RoleStatus] OFF
SET IDENTITY_INSERT [dbo].[TaxReport] ON 

INSERT [dbo].[TaxReport] ([TaxReportId], [Year], [IncomeTypeId], [BVN], [IncomeAmount], [TaxAmount], [BeneficiaryTIN]) VALUES (1, N'2010', 26, N'juf34nj32', CAST(2345678 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)), N'1')
INSERT [dbo].[TaxReport] ([TaxReportId], [Year], [IncomeTypeId], [BVN], [IncomeAmount], [TaxAmount], [BeneficiaryTIN]) VALUES (2, N'2010', 28, N'juf34nj32', CAST(2345678 AS Decimal(18, 0)), CAST(85090 AS Decimal(18, 0)), N'2')
INSERT [dbo].[TaxReport] ([TaxReportId], [Year], [IncomeTypeId], [BVN], [IncomeAmount], [TaxAmount], [BeneficiaryTIN]) VALUES (6, N'2010', 26, N'ghs67fv98', CAST(2345678 AS Decimal(18, 0)), CAST(85090 AS Decimal(18, 0)), N'2')
INSERT [dbo].[TaxReport] ([TaxReportId], [Year], [IncomeTypeId], [BVN], [IncomeAmount], [TaxAmount], [BeneficiaryTIN]) VALUES (7, N'2010', 26, N'cfd34kh00', CAST(6547843 AS Decimal(18, 0)), CAST(35540 AS Decimal(18, 0)), N'3')
INSERT [dbo].[TaxReport] ([TaxReportId], [Year], [IncomeTypeId], [BVN], [IncomeAmount], [TaxAmount], [BeneficiaryTIN]) VALUES (8, N'2010', 26, N'ygf76bc34', CAST(6547843 AS Decimal(18, 0)), CAST(1090020 AS Decimal(18, 0)), N'4')
INSERT [dbo].[TaxReport] ([TaxReportId], [Year], [IncomeTypeId], [BVN], [IncomeAmount], [TaxAmount], [BeneficiaryTIN]) VALUES (9, N'2010', 26, N'bgf46xh84', CAST(7623908 AS Decimal(18, 0)), CAST(343090 AS Decimal(18, 0)), N'5')
SET IDENTITY_INSERT [dbo].[TaxReport] OFF
SET IDENTITY_INSERT [dbo].[UserActivationCode] ON 

INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (1, 1, N'e3395bac-c6a5-4d96-b364-25a1fe625ebe', CAST(0x0000AAA4008741E6 AS DateTime), 0, CAST(0x0000AAA3008741E6 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (2, 1, N'6824cb02-c440-4334-a72a-2d305c4fcc98', CAST(0x0000AAA4008EABEB AS DateTime), 0, CAST(0x0000AAA3008EABEB AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (3, 2, N'f9b2a85d-3cd7-4281-ac26-14c188f3b5c5', CAST(0x0000AAA4009C9985 AS DateTime), 0, CAST(0x0000AAA3009C9985 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (4, 3, N'780b441e-566a-4e4d-9186-81fa41ef0a6a', CAST(0x0000AAA4009EF69F AS DateTime), 0, CAST(0x0000AAA3009EF69F AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (5, 4, N'50447951-3795-4117-88f0-9ae792a92854', CAST(0x0000AAA500CF63D0 AS DateTime), 0, CAST(0x0000AAA400CF63D0 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (6, 6, N'1cbda657-4cc6-48f3-9094-746433383b67', CAST(0x0000AAA500D237B2 AS DateTime), 0, CAST(0x0000AAA400D237B2 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (7, 7, N'1be95de6-af27-4e02-9cf1-113435d270c6', CAST(0x0000AAAA00F0C70D AS DateTime), 0, CAST(0x0000AAA900F0C70D AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (8, 11, N'855df7b1-4b6a-408c-8b55-1384d6499734', CAST(0x0000AAAC00CB74D7 AS DateTime), 0, CAST(0x0000AAAB00CB74D7 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (9, 12, N'aacb104f-93b1-4494-a720-f3385af9420f', CAST(0x0000AAAC00D2D79E AS DateTime), 0, CAST(0x0000AAAB00D2D79E AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (10, 13, N'7bacbabc-39b8-45b5-a348-4c05def15fdb', CAST(0x0000AAAC011AAD94 AS DateTime), 0, CAST(0x0000AAAB011AAD94 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (11, 14, N'bb62943b-ee43-4df2-8a78-0f117c9429ba', CAST(0x0000AAAC011D0EF8 AS DateTime), 0, CAST(0x0000AAAB011D0EF8 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (12, 15, N'7c35af31-01e8-409e-a68c-e9ac51c6412f', CAST(0x0000AAAF00976A12 AS DateTime), 0, CAST(0x0000AAAE00976A12 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (13, 17, N'ecc1a870-a7b5-4c15-b238-4ec51d9cad18', CAST(0x0000AAAF00AECA07 AS DateTime), 0, CAST(0x0000AAAE00AECA07 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (14, 18, N'bf3cd72e-05d4-4a9f-a7d4-f1c3475b69cb', CAST(0x0000AAAF00B3AEF4 AS DateTime), 0, CAST(0x0000AAAE00B3AEF4 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (15, 24, N'a287901b-3f67-4f98-85ba-3a1a58b7759d', CAST(0x0000AAB000C481CF AS DateTime), 0, CAST(0x0000AAAF00C481CF AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (16, 29, N'74f4365c-14dd-431a-b73a-62f8fee1fa0a', CAST(0x0000AAB000CAB7F1 AS DateTime), 0, CAST(0x0000AAAF00CAB7F1 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (17, 31, N'8e1664ce-603e-40dc-9990-bcf7f957aa8e', CAST(0x0000AAB000CC2C60 AS DateTime), 0, CAST(0x0000AAAF00CC2C60 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (18, 32, N'708e21fe-518e-4095-9d65-163ae1956d41', CAST(0x0000AAB000DC040E AS DateTime), 0, CAST(0x0000AAAF00DC040E AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (19, 33, N'7af1c83a-c1a7-47fa-81b6-4c50d2104405', CAST(0x0000AAB000DDE345 AS DateTime), 0, CAST(0x0000AAAF00DDE345 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (20, 34, N'6f1a4de3-d596-41e7-8c7f-8dedc035cfe3', CAST(0x0000AAB000E4F3CA AS DateTime), 0, CAST(0x0000AAAF00E4F3CA AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (21, 35, N'02fab11c-b693-4c40-a1d9-9ebcf53cb04d', CAST(0x0000AAB100F2EBCC AS DateTime), 0, CAST(0x0000AAB000F2EBCC AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (22, 36, N'cbddbd99-79b9-4c06-8735-5721ae97359d', CAST(0x0000AAB600A7D276 AS DateTime), 0, CAST(0x0000AAB500A7D276 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (23, 37, N'43c3ab81-43f2-4372-8181-6949b9b70d85', CAST(0x0000AAB600A9CA96 AS DateTime), 0, CAST(0x0000AAB500A9CA96 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (24, 38, N'de57d6b0-f428-4ef2-bc63-630cf543f4a7', CAST(0x0000AAB600AA0D94 AS DateTime), 0, CAST(0x0000AAB500AA0D94 AS DateTime))
INSERT [dbo].[UserActivationCode] ([UserActivationCodeId], [UserRegistrationId], [ActivationCode], [ExpirationDate], [IsUsed], [DateCreated]) VALUES (25, 39, N'9ac3aa84-4fef-4b2d-ae8f-5955252253f5', CAST(0x0000AAB600C62DC1 AS DateTime), 0, CAST(0x0000AAB500C62DC1 AS DateTime))
SET IDENTITY_INSERT [dbo].[UserActivationCode] OFF
SET IDENTITY_INSERT [dbo].[UserBranch] ON 

INSERT [dbo].[UserBranch] ([UserBranchId], [BranchId], [UserRegistrationId], [IsActive], [DateCreated]) VALUES (48, 24, 36, 1, NULL)
INSERT [dbo].[UserBranch] ([UserBranchId], [BranchId], [UserRegistrationId], [IsActive], [DateCreated]) VALUES (49, 25, 36, 1, NULL)
INSERT [dbo].[UserBranch] ([UserBranchId], [BranchId], [UserRegistrationId], [IsActive], [DateCreated]) VALUES (50, 26, 36, 1, NULL)
INSERT [dbo].[UserBranch] ([UserBranchId], [BranchId], [UserRegistrationId], [IsActive], [DateCreated]) VALUES (51, 24, 38, 1, NULL)
SET IDENTITY_INSERT [dbo].[UserBranch] OFF
SET IDENTITY_INSERT [dbo].[UserRegistration] ON 

INSERT [dbo].[UserRegistration] ([UserRegistrationId], [FirstName], [LastName], [Email], [Password], [PhoneNumber], [IsActive], [DateCreated], [DateVerified], [IsUserVerified]) VALUES (1, N'Automata Associates', NULL, N'Jookoyoski@gmail.com', N'SOpfb4erBq2DezU4sEy8U0nuCo4KqyCArWOkrMVG+G09yWFtf8xdcGaMnzIIpvT1', N'07039260209', 1, CAST(0x0000AAA3008EAB8D AS DateTime), CAST(0x0000AAA3008EAB8D AS DateTime), 1)
INSERT [dbo].[UserRegistration] ([UserRegistrationId], [FirstName], [LastName], [Email], [Password], [PhoneNumber], [IsActive], [DateCreated], [DateVerified], [IsUserVerified]) VALUES (36, N'Automata Associates', NULL, N'ta@gmail.com', N'96TGHyYmxS3lC/W1kviclZt/+9L2jT8ELrsIaCjoGaNBh+/QLUp0T/NZ7haBmOca', N'07039260209', 1, CAST(0x0000AAB500A7D233 AS DateTime), CAST(0x0000AAB500A7D233 AS DateTime), 1)
INSERT [dbo].[UserRegistration] ([UserRegistrationId], [FirstName], [LastName], [Email], [Password], [PhoneNumber], [IsActive], [DateCreated], [DateVerified], [IsUserVerified]) VALUES (38, N'Adeola', N'Oladeinde', N'tagu@gmail.com', N'BOGFwiF38CeMnKnoF0W3e6FTVWocs+WFWd1mTvHFH6FLSu1uscuXaxeaeeoNjwYm20YB3vZj31qgWkq+rVF8SQ==', N'Jookoyoski@gmail.com', 1, CAST(0x0000AAB500AA0D69 AS DateTime), CAST(0x0000AAB500AA0D69 AS DateTime), 1)
INSERT [dbo].[UserRegistration] ([UserRegistrationId], [FirstName], [LastName], [Email], [Password], [PhoneNumber], [IsActive], [DateCreated], [DateVerified], [IsUserVerified]) VALUES (39, N'Odor', NULL, N'oladeindeadeola200@gmail.com', N'B8pI1s3DpuubuGSGPTYU+Bnd9rsk6WPWoh5UubdXy0TTftXiQCqYpidlGMD9IEBah8a/xwkx4ApB4hW1kyFXgw==', N'1234556667', 1, CAST(0x0000AAB500C62C3C AS DateTime), CAST(0x0000AAB500C6CA94 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[UserRegistration] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([UserRoleId], [Email], [RoleId], [DateCreated], [IsActive]) VALUES (2, N'Jookoyoski@gmail.com', 14, CAST(0x0000AAA3008EABE6 AS DateTime), 1)
INSERT [dbo].[UserRole] ([UserRoleId], [Email], [RoleId], [DateCreated], [IsActive]) VALUES (25, N'ta@gmail.com', 50, CAST(0x0000AAB500A7D26E AS DateTime), 1)
INSERT [dbo].[UserRole] ([UserRoleId], [Email], [RoleId], [DateCreated], [IsActive]) VALUES (26, N'tagu@gmail.com', 51, CAST(0x0000AAB500A9CA90 AS DateTime), 1)
INSERT [dbo].[UserRole] ([UserRoleId], [Email], [RoleId], [DateCreated], [IsActive]) VALUES (27, N'tagu@gmail.com', 51, CAST(0x0000AAB500AA0D91 AS DateTime), 1)
INSERT [dbo].[UserRole] ([UserRoleId], [Email], [RoleId], [DateCreated], [IsActive]) VALUES (28, N'oladeindeadeola200@gmail.com', 50, CAST(0x0000AAB500C62DA0 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
USE [master]
GO
ALTER DATABASE [Pitalytics] SET  READ_WRITE 
GO
