CREATE TABLE [dbo].[Medical_Facility] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [FacilityName]    VARCHAR (250)  NOT NULL,
    [FacilityAddress] VARCHAR (1000) NOT NULL,
    [FacilityZip]     VARCHAR (10)   NOT NULL,
    [FacilityNo]      VARCHAR (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

