/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF (NOT EXISTS(SELECT * FROM GameStatus))
BEGIN
	INSERT INTO GameStatus VALUES (1, 'Game Started')
	INSERT INTO GameStatus VALUES (2, 'Game Surrendered')
	INSERT INTO GameStatus VALUES (3, 'Game Lost')
	INSERT INTO GameStatus VALUES (4, 'Game Won')
	INSERT INTO GameStatus VALUES (5, 'Debug Game Started')
	insert into GameStatus values (6, 'Debug Game Surrendered')
	insert into GameStatus values (7, 'Debug Game Lost')
	insert into GameStatus values (8, 'Debug Game Won')
	insert into GameStatus values (9, 'AI Game Started')
	insert into GameStatus values (10, 'AI Game Surrendered')
	insert into GameStatus values (11, 'AI Game Lost')
	insert into GameStatus values (12, 'AI Game Won')
END