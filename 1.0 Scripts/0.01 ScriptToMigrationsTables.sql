IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Cities] (
    [Id] uniqueidentifier NOT NULL,
    [CityName] nvarchar(100) NOT NULL,
    [IsForSOAT] bit NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Policies] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [PolicyNumber] nvarchar(14) NOT NULL,
    [DateOfIssue] datetimeoffset NOT NULL,
    [DateOfStart] datetimeoffset NOT NULL,
    [DateOfExpiration] datetimeoffset NOT NULL,
    [LicencePlate] nvarchar(10) NOT NULL,
    [CityId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Policies] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Policies_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityName', N'IsForSOAT') AND [object_id] = OBJECT_ID(N'[Cities]'))
    SET IDENTITY_INSERT [Cities] ON;
INSERT INTO [Cities] ([Id], [CityName], [IsForSOAT])
VALUES ('5b1c2b4d-48c7-402a-80c3-cc796ad49c6b', N'Bogota', CAST(1 AS bit)),
('d8663e5e-7494-4f81-8739-6e0de1bea7ee', N'Cartagena', CAST(1 AS bit)),
('d173e20d-159e-4127-9ce9-b0ac2564ad97', N'Barranquilla', CAST(0 AS bit)),
('40ff5488-fdab-45b5-bc3a-14302d59869a', N'Medellin', CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityName', N'IsForSOAT') AND [object_id] = OBJECT_ID(N'[Cities]'))
    SET IDENTITY_INSERT [Cities] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'DateOfExpiration', N'DateOfIssue', N'DateOfStart', N'FirstName', N'LastName', N'LicencePlate', N'PolicyNumber') AND [object_id] = OBJECT_ID(N'[Policies]'))
    SET IDENTITY_INSERT [Policies] ON;
INSERT INTO [Policies] ([Id], [CityId], [DateOfExpiration], [DateOfIssue], [DateOfStart], [FirstName], [LastName], [LicencePlate], [PolicyNumber])
VALUES ('d28888e9-2ba9-473a-a40f-e38cb54f9888', '5b1c2b4d-48c7-402a-80c3-cc796ad49c6b', '2022-04-10T00:00:00.0000000-05:00', '2021-04-10T00:00:00.0000000-05:00', '2021-04-11T00:00:00.0000000-05:00', N'Raul', N'Perez', N'ABC547', N'14575000853560'),
('da2fd609-d754-4feb-8acd-c4f9ff13ba96', 'd8663e5e-7494-4f81-8739-6e0de1bea7ee', '2023-05-13T00:00:00.0000000-05:00', '2022-05-13T00:00:00.0000000-05:00', '2022-05-14T00:00:00.0000000-05:00', N'Nancy', N'Garcerant', N'ABC888', N'14579000853599'),
('2902b665-1190-4c70-9915-b9c2d7680450', '40ff5488-fdab-45b5-bc3a-14302d59869a', '2023-06-14T00:00:00.0000000-05:00', '2022-06-14T00:00:00.0000000-05:00', '2022-06-15T00:00:00.0000000-05:00', N'Pedro', N'Pabon', N'ABC999', N'34579000850000'),
('102b566b-ba1f-404c-b2df-e2cde39ade09', '40ff5488-fdab-45b5-bc3a-14302d59869a', '2022-02-15T00:00:00.0000000-05:00', '2021-02-15T00:00:00.0000000-05:00', '2021-02-16T00:00:00.0000000-05:00', N'Arnold', N'Hernandez', N'ABC007', N'88769000850022');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'DateOfExpiration', N'DateOfIssue', N'DateOfStart', N'FirstName', N'LastName', N'LicencePlate', N'PolicyNumber') AND [object_id] = OBJECT_ID(N'[Policies]'))
    SET IDENTITY_INSERT [Policies] OFF;

GO

CREATE INDEX [IX_Policies_CityId] ON [Policies] ([CityId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221110025707_InitialMigration', N'3.0.0');

GO

