
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/06/2016 08:35:55
-- Generated from EDMX file: C:\Users\idriss\Documents\Visual Studio 2015\Projects\RoadBetterTogether\RoadBetterTogether\TogetherModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFirst.Together];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_HomeAdress_inherits_AdressesSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdressesSet_HomeAdress] DROP CONSTRAINT [FK_HomeAdress_inherits_AdressesSet];
GO
IF OBJECT_ID(N'[dbo].[FK_TogetherCarsTogetherDrivers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TogetherCarsSet] DROP CONSTRAINT [FK_TogetherCarsTogetherDrivers];
GO
IF OBJECT_ID(N'[dbo].[FK_TogetherCompagnySite]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompagnySiteSet] DROP CONSTRAINT [FK_TogetherCompagnySite];
GO
IF OBJECT_ID(N'[dbo].[FK_TogetherDrivers_inherits_TogetherUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TogetherUsersSet_TogetherDrivers] DROP CONSTRAINT [FK_TogetherDrivers_inherits_TogetherUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_TogetherUsersSetAdressesSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdressesSet] DROP CONSTRAINT [FK_TogetherUsersSetAdressesSet];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkAdress_inherits_AdressesSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdressesSet_WorkAdress] DROP CONSTRAINT [FK_WorkAdress_inherits_AdressesSet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdressesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdressesSet];
GO
IF OBJECT_ID(N'[dbo].[AdressesSet_HomeAdress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdressesSet_HomeAdress];
GO
IF OBJECT_ID(N'[dbo].[AdressesSet_WorkAdress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdressesSet_WorkAdress];
GO
IF OBJECT_ID(N'[dbo].[CompagnySiteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompagnySiteSet];
GO
IF OBJECT_ID(N'[dbo].[HomeAdressSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HomeAdressSet];
GO
IF OBJECT_ID(N'[dbo].[PostSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostSet];
GO
IF OBJECT_ID(N'[dbo].[RoadTeamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoadTeamSet];
GO
IF OBJECT_ID(N'[dbo].[TogetherCarsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TogetherCarsSet];
GO
IF OBJECT_ID(N'[dbo].[TogetherCompagnySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TogetherCompagnySet];
GO
IF OBJECT_ID(N'[dbo].[TogetherUsersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TogetherUsersSet];
GO
IF OBJECT_ID(N'[dbo].[TogetherUsersSet_TogetherDrivers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TogetherUsersSet_TogetherDrivers];
GO
IF OBJECT_ID(N'[dbo].[WorkAdressSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkAdressSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdressesSet'
CREATE TABLE [dbo].[AdressesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [rue] nvarchar(max)  NOT NULL,
    [Batiment] nvarchar(max)  NULL,
    [code_postal] nvarchar(max)  NOT NULL,
    [ville] nvarchar(max)  NOT NULL,
    [numero] int  NOT NULL,
    [TogetherUsersSet_Id] int  NOT NULL
);
GO

-- Creating table 'AdressesSet_HomeAdress'
CREATE TABLE [dbo].[AdressesSet_HomeAdress] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'AdressesSet_WorkAdress'
CREATE TABLE [dbo].[AdressesSet_WorkAdress] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'CompagnySiteSet'
CREATE TABLE [dbo].[CompagnySiteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TogetherCompagnyId] int  NOT NULL,
    [adresse] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HomeAdressSet'
CREATE TABLE [dbo].[HomeAdressSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'PostSet'
CREATE TABLE [dbo].[PostSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'RoadTeamSet'
CREATE TABLE [dbo].[RoadTeamSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TogetherCarsSet'
CREATE TABLE [dbo].[TogetherCarsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [immatriculation] nvarchar(max)  NOT NULL,
    [marque] nvarchar(max)  NOT NULL,
    [annee] nvarchar(max)  NOT NULL,
    [RoadTeamId] int  NULL,
    [places] int  NOT NULL,
    [TogetherDrivers_Id] int  NOT NULL
);
GO

-- Creating table 'TogetherCompagnySet'
CREATE TABLE [dbo].[TogetherCompagnySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TogetherUsersSet'
CREATE TABLE [dbo].[TogetherUsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [age] int  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [goingMode] bit  NOT NULL,
    [TogetherDriversId] int  NOT NULL,
    [login] nvarchar(max)  NULL,
    [password] nvarchar(max)  NOT NULL,
    [actif] bit  NOT NULL
);
GO

-- Creating table 'TogetherUsersSet_TogetherDrivers'
CREATE TABLE [dbo].[TogetherUsersSet_TogetherDrivers] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'WorkAdressSet'
CREATE TABLE [dbo].[WorkAdressSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AdressesSet'
ALTER TABLE [dbo].[AdressesSet]
ADD CONSTRAINT [PK_AdressesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdressesSet_HomeAdress'
ALTER TABLE [dbo].[AdressesSet_HomeAdress]
ADD CONSTRAINT [PK_AdressesSet_HomeAdress]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdressesSet_WorkAdress'
ALTER TABLE [dbo].[AdressesSet_WorkAdress]
ADD CONSTRAINT [PK_AdressesSet_WorkAdress]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompagnySiteSet'
ALTER TABLE [dbo].[CompagnySiteSet]
ADD CONSTRAINT [PK_CompagnySiteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HomeAdressSet'
ALTER TABLE [dbo].[HomeAdressSet]
ADD CONSTRAINT [PK_HomeAdressSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PostSet'
ALTER TABLE [dbo].[PostSet]
ADD CONSTRAINT [PK_PostSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoadTeamSet'
ALTER TABLE [dbo].[RoadTeamSet]
ADD CONSTRAINT [PK_RoadTeamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TogetherCarsSet'
ALTER TABLE [dbo].[TogetherCarsSet]
ADD CONSTRAINT [PK_TogetherCarsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TogetherCompagnySet'
ALTER TABLE [dbo].[TogetherCompagnySet]
ADD CONSTRAINT [PK_TogetherCompagnySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TogetherUsersSet'
ALTER TABLE [dbo].[TogetherUsersSet]
ADD CONSTRAINT [PK_TogetherUsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TogetherUsersSet_TogetherDrivers'
ALTER TABLE [dbo].[TogetherUsersSet_TogetherDrivers]
ADD CONSTRAINT [PK_TogetherUsersSet_TogetherDrivers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkAdressSet'
ALTER TABLE [dbo].[WorkAdressSet]
ADD CONSTRAINT [PK_WorkAdressSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id] in table 'AdressesSet_HomeAdress'
ALTER TABLE [dbo].[AdressesSet_HomeAdress]
ADD CONSTRAINT [FK_HomeAdress_inherits_AdressesSet]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AdressesSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TogetherUsersSet_Id] in table 'AdressesSet'
ALTER TABLE [dbo].[AdressesSet]
ADD CONSTRAINT [FK_TogetherUsersSetAdressesSet]
    FOREIGN KEY ([TogetherUsersSet_Id])
    REFERENCES [dbo].[TogetherUsersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TogetherUsersSetAdressesSet'
CREATE INDEX [IX_FK_TogetherUsersSetAdressesSet]
ON [dbo].[AdressesSet]
    ([TogetherUsersSet_Id]);
GO

-- Creating foreign key on [Id] in table 'AdressesSet_WorkAdress'
ALTER TABLE [dbo].[AdressesSet_WorkAdress]
ADD CONSTRAINT [FK_WorkAdress_inherits_AdressesSet]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AdressesSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TogetherCompagnyId] in table 'CompagnySiteSet'
ALTER TABLE [dbo].[CompagnySiteSet]
ADD CONSTRAINT [FK_TogetherCompagnySite]
    FOREIGN KEY ([TogetherCompagnyId])
    REFERENCES [dbo].[TogetherCompagnySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TogetherCompagnySite'
CREATE INDEX [IX_FK_TogetherCompagnySite]
ON [dbo].[CompagnySiteSet]
    ([TogetherCompagnyId]);
GO

-- Creating foreign key on [TogetherDrivers_Id] in table 'TogetherCarsSet'
ALTER TABLE [dbo].[TogetherCarsSet]
ADD CONSTRAINT [FK_TogetherCarsTogetherDrivers]
    FOREIGN KEY ([TogetherDrivers_Id])
    REFERENCES [dbo].[TogetherUsersSet_TogetherDrivers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TogetherCarsTogetherDrivers'
CREATE INDEX [IX_FK_TogetherCarsTogetherDrivers]
ON [dbo].[TogetherCarsSet]
    ([TogetherDrivers_Id]);
GO

-- Creating foreign key on [Id] in table 'TogetherUsersSet_TogetherDrivers'
ALTER TABLE [dbo].[TogetherUsersSet_TogetherDrivers]
ADD CONSTRAINT [FK_TogetherDrivers_inherits_TogetherUsers]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[TogetherUsersSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------