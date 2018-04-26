CREATE TABLE [dbo].[Users] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [UserName] VARCHAR (20) NOT NULL,
    [Password] VARCHAR (20) NOT NULL,
    [RoleType] INT          NOT NULL,
    [ChildID]  INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

