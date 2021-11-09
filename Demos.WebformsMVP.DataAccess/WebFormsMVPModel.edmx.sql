
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/09/2021 19:52:58
-- Generated from EDMX file: C:\Users\matfal\source\repos\GitHub\Halligalli72\Demos.WebformsMVP\Demos.WebformsMVP.DataAccess\WebFormsMVPModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WebformsMVPDemo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Activity_ActivityType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activity] DROP CONSTRAINT [FK_Activity_ActivityType];
GO
IF OBJECT_ID(N'[dbo].[FK_Activity_UserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activity] DROP CONSTRAINT [FK_Activity_UserProfile];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Activity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activity];
GO
IF OBJECT_ID(N'[dbo].[ActivityType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActivityType];
GO
IF OBJECT_ID(N'[dbo].[UserProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfile];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Activity'
CREATE TABLE [dbo].[Activity] (
    [UserProfileId] int  NOT NULL,
    [ActivityTypeId] int  NOT NULL,
    [OtherActivity] varchar(50)  NOT NULL,
    [ActivityDate] datetime  NOT NULL,
    [Duration] int  NOT NULL,
    [Score] int  NOT NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL
);
GO

-- Creating table 'ActivityType'
CREATE TABLE [dbo].[ActivityType] (
    [ActivityTypeId] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [StepValue] int  NOT NULL,
    [IsActivated] bit  NOT NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL
);
GO

-- Creating table 'UserProfile'
CREATE TABLE [dbo].[UserProfile] (
    [UserProfileId] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Team] varchar(50)  NOT NULL,
    [Department] varchar(50)  NOT NULL,
    [IsAdmin] bit  NOT NULL,
    [IsPublic] bit  NOT NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserProfileId], [ActivityTypeId], [ActivityDate] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [PK_Activity]
    PRIMARY KEY CLUSTERED ([UserProfileId], [ActivityTypeId], [ActivityDate] ASC);
GO

-- Creating primary key on [ActivityTypeId] in table 'ActivityType'
ALTER TABLE [dbo].[ActivityType]
ADD CONSTRAINT [PK_ActivityType]
    PRIMARY KEY CLUSTERED ([ActivityTypeId] ASC);
GO

-- Creating primary key on [UserProfileId] in table 'UserProfile'
ALTER TABLE [dbo].[UserProfile]
ADD CONSTRAINT [PK_UserProfile]
    PRIMARY KEY CLUSTERED ([UserProfileId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ActivityTypeId] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [FK_Activity_ActivityType]
    FOREIGN KEY ([ActivityTypeId])
    REFERENCES [dbo].[ActivityType]
        ([ActivityTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Activity_ActivityType'
CREATE INDEX [IX_FK_Activity_ActivityType]
ON [dbo].[Activity]
    ([ActivityTypeId]);
GO

-- Creating foreign key on [UserProfileId] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [FK_Activity_UserProfile]
    FOREIGN KEY ([UserProfileId])
    REFERENCES [dbo].[UserProfile]
        ([UserProfileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------