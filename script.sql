USE [master]
GO
/****** Object:  Database [BookOne]    Script Date: 2/5/2019 7:48:27 PM ******/
CREATE DATABASE [BookOne]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TRyOneProject2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BookOne.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TRyOneProject2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BookOne_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BookOne] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookOne].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookOne] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookOne] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookOne] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookOne] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookOne] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookOne] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookOne] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookOne] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookOne] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookOne] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookOne] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookOne] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookOne] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookOne] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookOne] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookOne] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookOne] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookOne] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookOne] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookOne] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookOne] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookOne] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookOne] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookOne] SET  MULTI_USER 
GO
ALTER DATABASE [BookOne] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookOne] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookOne] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookOne] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookOne] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookOne] SET QUERY_STORE = OFF
GO
USE [BookOne]
GO
/****** Object:  User [User1]    Script Date: 2/5/2019 7:48:27 PM ******/
CREATE USER [User1] FOR LOGIN [User1] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [User1]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2/5/2019 7:48:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[DateOfLastMove] [date] NOT NULL,
	[Words] [varchar](250) NOT NULL,
	[OwnerLoginID] [int] NOT NULL,
	[CarrierLoginID] [int] NOT NULL,
	[BookStatus] [int] NOT NULL,
	[Circulation] [int] NOT NULL,
	[Sent] [int] NOT NULL,
	[Receive] [int] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogIn]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogIn](
	[LogInID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[RoleType] [int] NOT NULL,
	[Clap] [int] NOT NULL,
	[Carrier] [int] NOT NULL,
	[TL] [varchar](22) NOT NULL,
 CONSTRAINT [PK_LogIn] PRIMARY KEY CLUSTERED 
(
	[LogInID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pool]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pool](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Owner] [int] NULL,
	[HandTo] [int] NULL,
	[BookID] [int] NOT NULL,
 CONSTRAINT [PK_Pool] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (1, N'Robin Hood', N'R.O                      ', CAST(N'2019-01-27' AS Date), N'Great book!', 1, 1, 1, 28, 1, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (2, N'The Art Of Walt Disney', N'L.E                      ', CAST(N'2019-01-18' AS Date), N'Baby Hollywood', 1, 1, 1, 9, 1, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (3, N'Peter Pan', N'K.R                      ', CAST(N'2019-01-18' AS Date), N'it dissapears after reading', 1, 1, 1, 3, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (5, N'The third eye', N'E.R                      ', CAST(N'2019-01-11' AS Date), N'about a third eye in Thibet', 2, 1, 1, 3, 1, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (7, N'One', N'R.J.Bach', CAST(N'2019-01-19' AS Date), N'Parellel Universe', 2, 2, 1, 10, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (8, N'Once apon a time', N'Unkown', CAST(N'2019-01-11' AS Date), N'Amazing book, everyone should read!!!!!!!!', 2, 2, 1, 0, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (18, N'My papagalo', N'Zor len', CAST(N'2019-01-17' AS Date), N'it was fucking great!', 3, 1, 0, 3, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (58, N'Even the goods', N'Isaac Asimov', CAST(N'2019-01-16' AS Date), N' ', 2, 2, 1, 0, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (63, N'kama sutra', N'ilias skourlas', CAST(N'2019-01-17' AS Date), N'', 3, 3, 0, 0, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (64, N'karma sutra 2', N'anna papadaki', CAST(N'2019-01-17' AS Date), N'', 3, 3, 0, 0, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (68, N'The king''s stillts', N'Dr.Seuss', CAST(N'2019-01-18' AS Date), N'this is my message to your application my friend', 3, 2, 0, 1, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (69, N'Silence', N'John Cage', CAST(N'2019-01-18' AS Date), N' ', 1, 3, 1, 1, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (70, N'Manifest', N'Marx', CAST(N'2019-01-18' AS Date), N' ', 1, 1, 0, 0, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (71, N'Le petit Nicola', N'Rene Goscinny', CAST(N'2019-01-18' AS Date), N'very nice book for kids', 2, 2, 1, 0, 0, 0)
INSERT [dbo].[Book] ([BookID], [Title], [Author], [DateOfLastMove], [Words], [OwnerLoginID], [CarrierLoginID], [BookStatus], [Circulation], [Sent], [Receive]) VALUES (73, N'MY LIFE ', N'MICHELE OBAMA', CAST(N'2019-01-19' AS Date), N'Ax Michele', 1, 1, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[LogIn] ON 

INSERT [dbo].[LogIn] ([LogInID], [UserName], [Password], [RoleType], [Clap], [Carrier], [TL]) VALUES (1, N'Admin', N'Admin', 1, 7, 9, N'6954350603')
INSERT [dbo].[LogIn] ([LogInID], [UserName], [Password], [RoleType], [Clap], [Carrier], [TL]) VALUES (2, N'Two', N'Two', 2, 1, 1, N'6993245576')
INSERT [dbo].[LogIn] ([LogInID], [UserName], [Password], [RoleType], [Clap], [Carrier], [TL]) VALUES (3, N'Three          ', N'Three     ', 3, 2, 4, N'6944452346')
INSERT [dbo].[LogIn] ([LogInID], [UserName], [Password], [RoleType], [Clap], [Carrier], [TL]) VALUES (4, N'Four', N'Four', 4, 0, 1, N'6942269444')
INSERT [dbo].[LogIn] ([LogInID], [UserName], [Password], [RoleType], [Clap], [Carrier], [TL]) VALUES (5, N'Five', N'five', 2, 1, 1, N'6974335924')
SET IDENTITY_INSERT [dbo].[LogIn] OFF
SET IDENTITY_INSERT [dbo].[Pool] ON 

INSERT [dbo].[Pool] ([ID], [Owner], [HandTo], [BookID]) VALUES (26, 1, 2, 2)
INSERT [dbo].[Pool] ([ID], [Owner], [HandTo], [BookID]) VALUES (27, 2, 1, 7)
INSERT [dbo].[Pool] ([ID], [Owner], [HandTo], [BookID]) VALUES (28, 1, 2, 1)
INSERT [dbo].[Pool] ([ID], [Owner], [HandTo], [BookID]) VALUES (1026, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Pool] OFF
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_LogIn] FOREIGN KEY([CarrierLoginID])
REFERENCES [dbo].[LogIn] ([LogInID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_LogIn]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_LogIn1] FOREIGN KEY([OwnerLoginID])
REFERENCES [dbo].[LogIn] ([LogInID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_LogIn1]
GO
ALTER TABLE [dbo].[Pool]  WITH CHECK ADD  CONSTRAINT [FK_Pool_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([BookID])
GO
ALTER TABLE [dbo].[Pool] CHECK CONSTRAINT [FK_Pool_Book]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddCirculation]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_AddCirculation]
@BookID int
As
Begin
Update Book
set Circulation = Circulation+1
Where BookID = @BookID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_AddClap]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_AddClap]
@LoginID int
As
Begin
Update LogIn
set Clap = Clap+1
Where LogInID = @LoginID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_AddOneMoreCarriedBook]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_AddOneMoreCarriedBook]
@LoginID int
As
Begin
Update LogIn
set Carrier = Carrier + 1
Where LogInID = @LoginID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_AllBooks]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_AllBooks]
As
Begin
Select distinct Title from Book 
End
GO
/****** Object:  StoredProcedure [dbo].[sp_AllBooksAvailable]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_AllBooksAvailable]
As
Begin
Select Title from Book where OwnerLoginID=CarrierLoginID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ChaingeCarrier]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ChaingeCarrier]
@CarrierLoginID int,
@DateOfLastMove date,
@BookID int
As 
Begin
Update Book
SET CarrierLoginID = @CarrierLoginID,DateOfLastMove = @DateOfLastMove 
WHERE BookID = @BookID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteFromBookByBookID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_DeleteFromBookByBookID]
@BookID int
as
begin
delete from Book where BookID = @BookID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteFromPoolByBookID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_DeleteFromPoolByBookID]
@BookID int
as
begin
delete from Pool where BookID = @BookID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteInvolvedBooks]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DeleteInvolvedBooks]
@LogInID int
as
begin
delete Book Where OwnerLoginID = @LogInID or CarrierLoginID=  @LogInID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_DeleteUser]
@LogInID int
as
begin
delete from LogIn where LogInID = @LogInID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_EnterBook]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_EnterBook]		
@Title nvarchar(30), 
@Author nvarchar(50), 
@DateOfLastMove date,
@Words varchar(250),
@OwnerLoginID int,
@CarrierLoginID int,
@BookStatus int,
@Circulation int,
@Sent int,
@Receive int
As
Begin
SET NOCOUNT ON
Insert into Book (Title, Author,DateOfLastMove,Words,OwnerLoginID,
CarrierLoginID,BookStatus,Circulation,Sent,Receive)
Values (@Title, @Author,@DateOfLastMove,@Words,@OwnerLoginID,
@CarrierLoginID,@BookStatus,@Circulation,@Sent,@Receive )
End
GO
/****** Object:  StoredProcedure [dbo].[sp_EnterUser]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_EnterUser]		
@UserName nvarchar(15), 
@Password nvarchar(10),
@RoleType int,
@Clap int,
@Carrier int
As
Begin
SET NOCOUNT ON
Insert into LogIn (UserName,Password,RoleType,Clap,Carrier)
Values (@UserName,@Password,@RoleType,@Clap,@Carrier)
End
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBookByTitle]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetBookByTitle]
@Title nvarchar(30)
As
Begin
set nocount on;
select BookID,Title, Author from Book where Title like '%'+@Title+'%'
End
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCarrierLoginIDByBookID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_GetCarrierLoginIDByBookID]
@BookID int,
@CarrierLoginID int output
As
Set nocount on;
Select @CarrierLoginID = CarrierLoginID from Book
WHERE BookID = @BookID 
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_GetHandToByBookID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_GetHandToByBookID]
@BookID int,
@HandTo int output
As
Set nocount on;
Select @HandTo = HandTo from Pool
Where BookID = @BookID 
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_GetInfoAllBooks]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_GetInfoAllBooks]
As
Begin
Select * from Book
End
GO
/****** Object:  StoredProcedure [dbo].[sp_GetInfoAllUsers]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetInfoAllUsers]
As
Begin
Select LogInID, UserName,RoleType , Clap, Carrier,TL  from Login 
End
GO
/****** Object:  StoredProcedure [dbo].[sp_GetInfoAllUsersTWO]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetInfoAllUsersTWO]
As
Begin
Select LogInID, UserName, Clap, RoleType  from Login 
End
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListOfHandByBookID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetListOfHandByBookID]
@BookID int 
As
Begin
Select distinct HandTo from Pool
Where BookID = @BookID 
End
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOwnerByBookID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_GetOwnerByBookID]
@BookID int,
@OwnerLoginID int output
As
Set nocount on;
Select @OwnerLoginID = OwnerLoginID from Book
Where BookID = @BookID 
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOwnerLoginIDByBookID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetOwnerLoginIDByBookID]
@BookID int,
@OwnerLoginID int output
As
Set nocount on;
Select @OwnerLoginID = OwnerLoginID from Book
WHERE BookID = @BookID 
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoleFromLoginID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetRoleFromLoginID]
@loginID int,
@RoleType int output
As
Set nocount on;
select @RoleType = RoleType from LogIn
Where Login.LogInID  = @loginID
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSentNumber]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_GetSentNumber]
@BookID int,
@Sent int output
As
Set nocount on;
Select @Sent= Sent from Book
Where BooKID = @BookID
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSentReceiveNumber]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetSentReceiveNumber]
@BookID int,
@Total int output
As
Set nocount on;
Select @Total=Sum(Sent + Receive) from Book
Where BooKID = @BookID
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_IfUserIDExists]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_IfUserIDExists]
@LoginID int,
@Count int output
As
Set nocount on;
Select @Count=Count(LogInID) from LogIn
Where LogInID = @LoginID 
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_LoginUser]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_LoginUser]
@UserName nchar(15),
@Password nchar(10),
@logInID int output
As
Set nocount on;
select @logInID=LogInID 
from LogIn where UserName= @UserName And @Password=Password
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_PoolOfCarriers]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[sp_PoolOfCarriers]
@Owner int,
@HandTo int,
@BookID int
As
Begin
Set nocount on
Insert into Pool (Owner,HandTo,BookID)
Values (@Owner,@HandTo,@BookID)
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ReceiveBookSignalNo]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ReceiveBookSignalNo]
@BookID int
As
Begin
UPDATE Book
SET Sent = 0,Receive = 0
WHERE BookID = @BookID;
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ReceiveBookSignalYes]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ReceiveBookSignalYes]
@BookID int
As 
Begin
UPDATE Book
SET Receive = 1
WHERE BookID = @BookID;
End
GO
/****** Object:  StoredProcedure [dbo].[sp_SentBookSignalYes]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_SentBookSignalYes]
@BookID int
As
Begin
UPDATE Book
SET Sent = 1
WHERE BookID = @BookID;
End
GO
/****** Object:  StoredProcedure [dbo].[sp_TotalBookID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TotalBookID]
@TotalBookID int output
As
Set nocount on;
select @TotalBookID = count(BookID) from Book
Return
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateRoleTypeByRoleId]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_UpdateRoleTypeByRoleId]
@RoleID int,
@RoleType int
As
Begin
UPDATE Role
SET RoleType = @RoleType
WHERE RoleID = @RoleID;
End
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_UpdateUser]		
@LoginID int, 
@UserName nvarchar(15), 
@Password nvarchar(10),
@RoleType int,
@Clap int,
@Carrier int
As
Begin
Update LogIn
Set  UserName = @UserName,Password = @Password,
RoleType = @RoleType,Clap = @Clap,Carrier = @Carrier
where LogInID = @LoginID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ViewAllRoles]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ViewAllRoles]
As
Begin
select LogIn.UserName,Role.RoleID, Role.RoleType from Login
join Role
on Login.RoleID = Role.RoleID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ViewBooksByCarrierID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ViewBooksByCarrierID]
@CarrierLoginID int
As
Begin
Select * from Book where CarrierLoginID = @CarrierLoginID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ViewBooksTLByCarrierID]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ViewBooksTLByCarrierID]
@OwnerLoginID int
As
Begin
Select BookID,Title,Author,DateOfLastMove,Words,OwnerLoginID,CarrierLoginID,Carrier,BookStatus,
Circulation,Sent,Receive,TL from Book 
join LogIn on book.OwnerLoginID = LogIn.LogInID
where OwnerLoginID = @OwnerLoginID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ViewYourBooks]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_ViewYourBooks]
@OwnerLoginID int
As
Begin
Select * from Book where OwnerLoginID = @OwnerLoginID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_WriteWords]    Script Date: 2/5/2019 7:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_WriteWords]
@NewWords varchar(250),
@BookID int
As
Begin
Update Book
set Words = @NewWords
Where BookID = @BookID
End
GO
USE [master]
GO
ALTER DATABASE [BookOne] SET  READ_WRITE 
GO
