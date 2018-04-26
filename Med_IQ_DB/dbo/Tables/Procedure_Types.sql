CREATE TABLE [dbo].[Procedure_Types] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [ProcedureName] VARCHAR (200) NOT NULL,
    [ICD10Code]     VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

