CREATE TABLE [dbo].[People] (
    [Id]    INT       IDENTITY (1, 1) NOT NULL,
    [First] CHAR (30) NULL,
    [Last]  CHAR (30) NULL,
	[Email] CHAR (50) NULL,
	[Address1] CHAR (50) NULL,
	[Address2] CHAR (50) NULL,
	[City] CHAR (50) NULL,
	[State] CHAR (2) NULL,
	[Zip] CHAR (10) NULL,    
	PRIMARY KEY CLUSTERED ([Id] ASC)
);

