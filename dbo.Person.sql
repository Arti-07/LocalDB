CREATE TABLE [dbo].[Person] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Firstname] NVARCHAR (50)    NULL,
    [Lastname]  NVARCHAR (50)    NULL,
    [Gender]    NVARCHAR (30)    NULL,
    [Birthday]  DATETIME         NULL,
    [IDCompany] UNIQUEIDENTIFIER NULL,
    [Salary]    INT    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Person_ToCompany] FOREIGN KEY ([IDCompany]) REFERENCES [dbo].[Company] ([Id])
);

