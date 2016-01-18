select * from Admin
select * from Student
select * from Teacher

delete from Admin
delete from Student
delete from Teacher

dbcc checkident('Admin',reseed,0)

insert into Admin(UserName,Password) values('admin','admin')

alter table Admin
drop column  Id

alter table Admin
add falto int


alter table Admin
add Password nvarchar(10)

CREATE TABLE Student (
Id INT NOT NULL identity(1,1) PRIMARY KEY,
fullName nvarchar(50) not null,
userName nvarchar(50) not null,
Email nvarchar(50) not null,
Password nvarchar(50) not null,
confirmPassword nvarchar(50) not null
)

CREATE TABLE Teacher (
Id INT NOT NULL identity(1,1) PRIMARY KEY,
fullName nvarchar(50) not null,
userName nvarchar(50) not null,
Email nvarchar(50) not null,
Password nvarchar(50) not null,
confirmPassword nvarchar(50) not null
)


alter table Student add confirmPassword nvarchar(50)

alter table Teacher add confirmPassword nvarchar(50)

update Teacher set confirmPassword='111111' where Id=1

alter table Student add Phone nvarchar(50)
alter table Student add Field nvarchar(50)
alter table Student add Gender nvarchar(50)

alter table Teacher add Phone nvarchar(50)
alter table Teacher add Field nvarchar(50)
alter table Teacher add Gender nvarchar(50)

alter table Teacher drop column Field

USE [master]
GO

/****** Object:  Database [UMS]    Script Date: 1/7/2016 12:44:45 AM ******/
CREATE DATABASE [UMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UMS', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UMS.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UMS_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [UMS] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [UMS] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [UMS] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [UMS] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [UMS] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [UMS] SET ARITHABORT OFF 
GO

ALTER DATABASE [UMS] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [UMS] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [UMS] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [UMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [UMS] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [UMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [UMS] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [UMS] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [UMS] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [UMS] SET  DISABLE_BROKER 
GO

ALTER DATABASE [UMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [UMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [UMS] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [UMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [UMS] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [UMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [UMS] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [UMS] SET RECOVERY FULL 
GO

ALTER DATABASE [UMS] SET  MULTI_USER 
GO

ALTER DATABASE [UMS] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [UMS] SET DB_CHAINING OFF 
GO

ALTER DATABASE [UMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [UMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [UMS] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [UMS] SET  READ_WRITE 
GO

