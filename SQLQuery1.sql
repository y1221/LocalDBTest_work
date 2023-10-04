SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer] (
    [Id]   INT           NOT NULL,
    [Name] NVARCHAR (50) NULL,
    [Age]  INT           NULL,
    [Mail] NVARCHAR (50) NULL
);


INSERT INTO Customer VALUES (1, 'yuto', 24, 'yuto@icloud.com')
INSERT INTO Customer VALUES (2, 'taro', 18, 'taro@gmail.com')
INSERT INTO Customer VALUES (3, 'satoshi', 35, 'satoshi@me.com')
