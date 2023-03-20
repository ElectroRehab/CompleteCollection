CREATE TABLE [dbo].[LongTermSaves]
(
	[Id]       INT        IDENTITY (1, 1) NOT NULL,
    [SaveOne] FLOAT (53) NULL,
	[SaveTwo] FLOAT (53) NULL,
	[SaveThree] FLOAT (53) NULL,
	[SaveFour] FLOAT (53) NULL,
	[SaveFive] FLOAT (53) NULL,
	[SaveSix] FLOAT (53) NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
);