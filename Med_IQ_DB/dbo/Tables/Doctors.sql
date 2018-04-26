CREATE TABLE [dbo].[Doctors] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [DoctorName]    VARCHAR (250)  NOT NULL,
    [DoctorAddress] VARCHAR (1000) NOT NULL,
    [DoctorZip]     VARCHAR (10)   NOT NULL,
    [LicenseNo]     VARCHAR (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

