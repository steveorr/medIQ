CREATE TABLE [dbo].[Procedures] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [ProcedureTypeID]   INT          NOT NULL,
    [DoctorID]          INT          NOT NULL,
    [FacilityID]        INT          NOT NULL,
    [InsurerID]         INT          NOT NULL,
    [RecoveryDuration]  INT          NULL,
    [ProcedureDuration] INT          NULL,
    [ProcedureDate]     DATE         NOT NULL,
    [PatientEmail]      VARCHAR (50) NOT NULL,
    [WasSuccess]        BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Procedures_DoctorID] FOREIGN KEY ([DoctorID]) REFERENCES [dbo].[Doctors] ([Id]),
    CONSTRAINT [FK_Procedures_InsurerID] FOREIGN KEY ([InsurerID]) REFERENCES [dbo].[Insurance_Providers] ([Id]),
    CONSTRAINT [FK_Procedures_FacilityID] FOREIGN KEY ([FacilityID]) REFERENCES [dbo].[Medical_Facility] ([Id]),
    CONSTRAINT [FK_Procedures_ProcedureTypeID] FOREIGN KEY ([ProcedureTypeID]) REFERENCES [dbo].[Procedure_Types] ([Id])
);

