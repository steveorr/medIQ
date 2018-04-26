CREATE TABLE [dbo].[Insurance_Providers] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [ProviderName]    VARCHAR (250)  NOT NULL,
    [ProviderAddress] VARCHAR (1000) NOT NULL,
    [ProviderZip]     VARCHAR (10)   NOT NULL,
    [ProviderNo]      VARCHAR (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

