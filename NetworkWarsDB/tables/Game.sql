CREATE TABLE [dbo].[Game]
(
	[UserId] BIGINT NOT NULL,
	[Status] INT NOT NULL,
	[Turns] INT NOT NULL,
	[Board] VARCHAR(MAX) NULL,
	[Platform] INT NOT NULL,
	[AppVersion] VARCHAR(128) NULL,
)
GO
CREATE NONCLUSTERED INDEX [IX_Game_UserId]
    ON [dbo].[Game]([UserId] ASC);