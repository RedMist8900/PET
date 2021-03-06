-- ******************** SqlDBM: Microsoft SQL Server ********************
-- ** Generated by SqlDBM: S3Eksame, v7 by niko341n@edu.campusvejle.dk **


-- ************************************** [dbo].[Valutas]
CREATE TABLE [dbo].[Valutas]
(
 [Id]   int NOT NULL ,
 [Name] nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_116] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
-- ************************************** [LogIn]
CREATE TABLE [LogIn]
(
 [Id]       int NOT NULL ,
 [UserName] nvarchar(50) NOT NULL ,
 [Password] nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_151] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO



EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Not Implemented', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LogIn';
GO
-- ************************************** [dbo].[Persons]
CREATE TABLE [dbo].[Persons]
(
 [Id]            int NOT NULL ,
 [FirstName]     nvarchar(150) NOT NULL ,
 [NationalityID] int NOT NULL ,
 [LastName]      nvarchar(150) NOT NULL ,
 [Height]        float NOT NULL ,
 [EyeColor]      nvarchar(50) NOT NULL ,
 [HairColor]     nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_49] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Persons_Nationalities] FOREIGN KEY ([NationalityID])  REFERENCES [dbo].[Nationalities]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_112] ON [dbo].[Persons] 
 (
  [NationalityID] ASC
 )

GO
-- ************************************** [dbo].[Nationalities]
CREATE TABLE [dbo].[Nationalities]
(
 [Id]           int NOT NULL ,
 [CprNr]         NOT NULL ,
 [PersonsID]    int NOT NULL ,
 [CountryCode]  int NOT NULL ,
 [ZipCode]      int NOT NULL ,
 [StreetAdress] nvarchar(150) NOT NULL ,


 CONSTRAINT [PK_105] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Persons_Nationalities] FOREIGN KEY ([PersonsID])  REFERENCES [dbo].[Persons]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_109] ON [dbo].[Nationalities] 
 (
  [PersonsID] ASC
 )

GO
-- ************************************** [dbo].[Agents]
CREATE TABLE [dbo].[Agents]
(
 [Id]        int NOT NULL ,
 [PersonsID] int NOT NULL ,
 [LogInID]   int NOT NULL ,


 CONSTRAINT [PK_19] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Agents_Persons] FOREIGN KEY ([PersonsID])  REFERENCES [dbo].[Persons]([Id]),
 CONSTRAINT [FK_LogIn_Agents] FOREIGN KEY ([LogInID])  REFERENCES [LogIn]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_152] ON [dbo].[Agents] 
 (
  [LogInID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_94] ON [dbo].[Agents] 
 (
  [PersonsID] ASC
 )

GO
-- ************************************** [dbo].[Reports]
CREATE TABLE [dbo].[Reports]
(
 [Id]           int NOT NULL ,
 [InformantID]  int NULL ,
 [AgentsID]     int NULL ,
 [Date]         datetime NOT NULL ,
 [ObservantsID] int NOT NULL ,
 [Place]        nvarchar(100) NOT NULL ,
 [Comments]     nvarchar(500) NOT NULL ,


 CONSTRAINT [PK_35] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Agents_Reports] FOREIGN KEY ([AgentsID])  REFERENCES [dbo].[Agents]([Id]),
 CONSTRAINT [FK_Informants_Reports] FOREIGN KEY ([InformantID])  REFERENCES [dbo].[Informants]([Id]),
 CONSTRAINT [FK_Observants] FOREIGN KEY ([ObservantsID])  REFERENCES [dbo].[Observants]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_42] ON [dbo].[Reports] 
 (
  [InformantID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_46] ON [dbo].[Reports] 
 (
  [ObservantsID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_97] ON [dbo].[Reports] 
 (
  [AgentsID] ASC
 )

GO
-- ************************************** [dbo].[Payments]
CREATE TABLE [dbo].[Payments]
(
 [Id]               int NOT NULL ,
 [PreferredPayment] nvarchar(50) NULL ,
 [InformantsID]     int NOT NULL ,
 [ValutaID]         int NOT NULL ,


 CONSTRAINT [PK_64] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Informants_Payments] FOREIGN KEY ([InformantsID])  REFERENCES [dbo].[Informants]([Id]),
 CONSTRAINT [FK_Valuta_Payments] FOREIGN KEY ([ValutaID])  REFERENCES [dbo].[Valutas]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_120] ON [dbo].[Payments] 
 (
  [ValutaID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_123] ON [dbo].[Payments] 
 (
  [InformantsID] ASC
 )

GO
-- ************************************** [Ledelse]
CREATE TABLE [Ledelse]
(
 [Id]           int NOT NULL ,
 [AgentsID]     int NOT NULL ,
 [ObservantsID] int NOT NULL ,
 [InformantsID] int NOT NULL ,
 [LogInID]      int NOT NULL ,


 CONSTRAINT [PK_139] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_137] FOREIGN KEY ([LogInID])  REFERENCES [LogIn]([Id]),
 CONSTRAINT [FK_141] FOREIGN KEY ([AgentsID])  REFERENCES [dbo].[Agents]([Id]),
 CONSTRAINT [FK_144] FOREIGN KEY ([InformantsID])  REFERENCES [dbo].[Informants]([Id]),
 CONSTRAINT [FK_147] FOREIGN KEY ([ObservantsID])  REFERENCES [dbo].[Observants]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_143] ON [Ledelse] 
 (
  [AgentsID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_146] ON [Ledelse] 
 (
  [InformantsID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_149] ON [Ledelse] 
 (
  [ObservantsID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_158] ON [Ledelse] 
 (
  [LogInID] ASC
 )

GO
-- ************************************** [dbo].[Groups]
CREATE TABLE [dbo].[Groups]
(
 [Id]           int NOT NULL ,
 [GroupName]    nvarchar(150) NOT NULL ,
 [ObservantsID] int NOT NULL ,


 CONSTRAINT [PK_78] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Observants_Groups] FOREIGN KEY ([ObservantsID])  REFERENCES [dbo].[Observants]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_126] ON [dbo].[Groups] 
 (
  [ObservantsID] ASC
 )

GO
-- ************************************** [dbo].[Observants]
CREATE TABLE [dbo].[Observants]
(
 [Id]        int NOT NULL ,
 [PersonsID] int NOT NULL ,
 [GroupID]   int NOT NULL ,
 [LogInID]   int NOT NULL ,


 CONSTRAINT [PK_28] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_LogIn_Observants] FOREIGN KEY ([LogInID])  REFERENCES [LogIn]([Id]),
 CONSTRAINT [FK_Observants_Groups] FOREIGN KEY ([GroupID])  REFERENCES [dbo].[Groups]([Id]),
 CONSTRAINT [FK_PersonalFeatures_Observants] FOREIGN KEY ([PersonsID])  REFERENCES [dbo].[Persons]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_156] ON [dbo].[Observants] 
 (
  [LogInID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_55] ON [dbo].[Observants] 
 (
  [PersonsID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_85] ON [dbo].[Observants] 
 (
  [GroupID] ASC
 )

GO
-- ************************************** [dbo].[Logs]
CREATE TABLE [dbo].[Logs]
(
 [Id]        int NOT NULL ,
 [ReportsID] int NOT NULL ,


 CONSTRAINT [PK_88] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Reports_Logs] FOREIGN KEY ([ReportsID])  REFERENCES [dbo].[Reports]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_101] ON [dbo].[Logs] 
 (
  [ReportsID] ASC
 )

GO
-- ************************************** [dbo].[Informants]
CREATE TABLE [dbo].[Informants]
(
 [Id]             int NOT NULL ,
 [PersonsID]      int NOT NULL ,
 [PaymentsInfoID] int NOT NULL ,
 [LogInID]        int NOT NULL ,


 CONSTRAINT [PK_22] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_Informants_Honorings] FOREIGN KEY ([PaymentsInfoID])  REFERENCES [dbo].[Payments]([Id]),
 CONSTRAINT [FK_LogIn_Informants] FOREIGN KEY ([LogInID])  REFERENCES [LogIn]([Id]),
 CONSTRAINT [FK_PersonalFeatures_Informants] FOREIGN KEY ([PersonsID])  REFERENCES [dbo].[Persons]([Id])
);
GO


CREATE NONCLUSTERED INDEX [FK_154] ON [dbo].[Informants] 
 (
  [LogInID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_58] ON [dbo].[Informants] 
 (
  [PersonsID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_69] ON [dbo].[Informants] 
 (
  [PaymentsInfoID] ASC
 )

GO
