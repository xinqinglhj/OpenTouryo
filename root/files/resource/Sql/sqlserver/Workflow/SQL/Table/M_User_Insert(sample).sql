USE [Workflow]
GO

INSERT INTO [dbo].[M_User]([Id], [Section], [Name], [PositionTitlesId])
    VALUES
	(1   , '代理店'  , '御中'    , 1 ),
	(2   , 'SMD'     , '御中'    , 1 ),
	(3   , 'XEL'     , '御中'    , 1 ),
	(4   , 'MITO DD' , '御中'    , 1 ),
	(5   , 'GBA'     , '御中'    , 1 ),
	(6   , 'ED'      , '御中'    , 1 ),
	(2999, 'SMD'     , 'SMD1'    , 1 ),
	(2998, 'SMD'     , 'SMD2'    , 1 ),
	(2997, 'SMD'     , 'SMD3'    , 1 ),
	(4999, 'MITO DD' , 'MITO DD1', 1 ),
	(5999, 'GBA'     , 'GBA1'    , 1 ),
	(6999, 'ED'      , 'ED1'     , 1 ),
	(6998, 'ED'      , 'ED2'     , 1 ),
	(6997, 'ED'      , 'ED3'     , 1 )

GO


