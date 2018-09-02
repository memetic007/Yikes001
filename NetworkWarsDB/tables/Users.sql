CREATE TABLE [dbo].[Users]
(
	[Id] BIGINT NOT NULL Identity(1,1) PRIMARY KEY,
	[Name] VARCHAR(128) NOT NULL,
	[TotalGamesPlayed] BIGINT,
	[Created] DATETIME NOT NULL DEFAULT(GETUTCDATE()),
	[LastUpdated] datetime NOT NULL default(GETUTCDATE())
)
