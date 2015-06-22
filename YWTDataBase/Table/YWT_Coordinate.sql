 

CREATE TABLE YWT_Coordinate(
	[ID] [varchar](36) NOT NULL,
	[longitude] [varchar](20) NOT NULL,
	[latitude] [varchar](20) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[CarID] [varchar](36) NOT NULL,
	[UserID] [varchar](36) NOT NULL,
	[IMEI] [varchar](100) NULL,
	[OS] [varchar](20) NULL,
	[manufacturer] [varchar](50) NULL,
	[gaodeLongitude] [varchar](20) NULL,
	[gaodeLatitude] [varchar](20) NULL,
 CONSTRAINT [PK_YWT_Coordinate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'YWT_Coordinate', @level2type=N'COLUMN',@level2name=N'longitude'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'YWT_Coordinate', @level2type=N'COLUMN',@level2name=N'latitude'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'YWT_Coordinate', @level2type=N'COLUMN',@level2name=N'CreateDateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'车辆编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'YWT_Coordinate', @level2type=N'COLUMN',@level2name=N'CarID'
GO

ALTER TABLE [dbo].[YWT_Coordinate] ADD  CONSTRAINT [DF_YWT_Coordinate_ID]  DEFAULT (newid()) FOR [ID]
GO

ALTER TABLE [dbo].[YWT_Coordinate] ADD  CONSTRAINT [DF_YWT_Coordinate_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO

ALTER TABLE [dbo].[YWT_Coordinate] ADD  CONSTRAINT [DF_YWT_Coordinate_CarID]  DEFAULT ('') FOR [CarID]
GO


