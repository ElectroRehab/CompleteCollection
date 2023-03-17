CREATE TABLE [dbo].[Money] (
    [Id]    INT       IDENTITY (1, 1) NOT NULL,
    [Donation] FLOAT (53) NULL,
    [Savings]  FLOAT (53) NULL,
    [GOKF]     FLOAT (53) NULL,
    [Spending] FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

