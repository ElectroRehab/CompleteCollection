CREATE TABLE [dbo].[LongTermSaves]
(
	[Id]       INT        IDENTITY (1, 1) NOT NULL,
    [SaveOne] CHAR(25) NULL,
	[SaveTwo] CHAR(25) NULL,
	[SaveThree] CHAR(25) NULL,
	[SaveFour] CHAR(25) NULL,
	[SaveFive] CHAR(25) NULL,
	[SaveSix] CHAR(25) NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
);