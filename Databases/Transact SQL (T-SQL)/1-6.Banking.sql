USE [master]
GO
/****** Object:  Database [Banking]    Script Date: 22.8.2014 г. 15:27:44 ******/
CREATE DATABASE [Banking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Banking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Banking.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Banking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Banking_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Banking] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Banking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Banking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Banking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Banking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Banking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Banking] SET ARITHABORT OFF 
GO
ALTER DATABASE [Banking] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Banking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Banking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Banking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Banking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Banking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Banking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Banking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Banking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Banking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Banking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Banking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Banking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Banking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Banking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Banking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Banking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Banking] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Banking] SET  MULTI_USER 
GO
ALTER DATABASE [Banking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Banking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Banking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Banking] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Banking] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Banking]
GO
-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.

/****** Object:  UserDefinedFunction [dbo].[ufnCalculateInterest]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufnCalculateInterest](@sum money, @yearlyInterest money, @months int)
RETURNS money
AS
	BEGIN
		RETURN @sum + (@sum * ((@yearlyInterest / 1200) * @months))
	END

GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[Balance] [money] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[OldSum] [money] NOT NULL,
	[NewSum] [money] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (1, 1, 123.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (2, 2, 214.0000)
INSERT [dbo].[Accounts] ([Id], [PersonId], [Balance]) VALUES (3, 3, 1221.0000)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Id], [AccountId], [OldSum], [NewSum]) VALUES (1, 3, 122.0000, 1221.0000)
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (1, N'Димо', N'Петров', 123123123)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (2, N'Ива', N'Петрова', 122122122)
INSERT [dbo].[Persons] ([Id], [FirstName], [LastName], [SSN]) VALUES (3, N'Георги', N'Ганков', 223223223)
SET IDENTITY_INSERT [dbo].[Persons] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Accounts]

-- 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's 
-- account for one month. It should take the AccountId and the interest rate as parameters.

GO
/****** Object:  StoredProcedure [dbo].[uspCalculateAccountInterestForOneMonth]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspCalculateAccountInterestForOneMonth] (@accountId int, @interestRate money)
AS
BEGIN
	DECLARE @currentBalance money
	SELECT @currentBalance = acc.Balance FROM Accounts acc
	WHERE @accountId = acc.Id 
	DECLARE @newBalance money
	SET @newBalance = [dbo].[ufnCalculateInterest](@currentBalance, @interestRate, 1)
	UPDATE Accounts SET Balance=@newBalance WHERE @accountId = Accounts.Id
END	


GO
/****** Object:  StoredProcedure [dbo].[uspDepositMoney]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDepositMoney] @accountId int, @amount money
AS
BEGIN TRAN
UPDATE Accounts
SET Balance += @amount
WHERE Accounts.Id = @accountId
COMMIT

-- 2. Create a stored procedure that accepts a number as a parameter and returns all 
-- persons who have more money in their accounts than the supplied number.

GO
/****** Object:  StoredProcedure [dbo].[uspPersonsWithAmountGreaterThan]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspPersonsWithAmountGreaterThan] (@amount money)
AS
BEGIN
	SELECT per.FirstName + ' ' + per.LastName AS [Full Name], acc.Balance FROM Persons per
	JOIN Accounts acc 
	ON acc.PersonId = per.Id
	WHERE acc.Balance > @amount
END


-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), 
-- PersonId(FK), Balance). Insert few records for testing. Write a stored procedure that selects the full names of all persons.
GO
/****** Object:  StoredProcedure [dbo].[uspPrintPersonsFullNames]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[uspPrintPersonsFullNames]
AS 
SELECT per.FirstName + ' ' + per.LastName AS [Full Name] FROM Persons per

-- 5. Add two more stored procedures WithdrawMoney(AccountId, money) 
-- and DepositMoney (AccountId, money) that operate in transactions.

GO
/****** Object:  StoredProcedure [dbo].[uspWithdrawMoney]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspWithdrawMoney](@accountId int, @amount money)
AS
BEGIN TRAN
UPDATE Accounts
SET Balance -= @amount
WHERE Accounts.Id = @accountId
COMMIT


-- 6 Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts 
-- table that enters a new entry into the Logs table every time the sum on an account changes.

GO
/****** Object:  Trigger [dbo].[LogTransaction]    Script Date: 22.8.2014 г. 15:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[LogTransaction]
ON [dbo].[Accounts]
AFTER UPDATE
AS
IF EXISTS(SELECT * FROM deleted)
BEGIN

DECLARE @accountId int, @balanceBefore money, @balanceAfter money
SELECT @accountId = del.Id, @balanceBefore = del.Balance FROM deleted del
SELECT @balanceAfter = ins.Balance FROM inserted ins

INSERT INTO Logs
VALUES (@accountId, @balanceBefore, @balanceAfter)
END
GO
USE [master]
GO
ALTER DATABASE [Banking] SET  READ_WRITE 
GO
