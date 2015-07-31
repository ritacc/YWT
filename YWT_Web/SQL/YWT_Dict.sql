--DROP  TABLE YWT_Dict_Type
/*
GO
CREATE TABLE YWT_Dict_Type 
(
	Dict_Type_Code	NVARCHAR(50)
	,Dict_Type_Text	NVARCHAR(50)
	,Dict_Type_Desc	NVARCHAR(100)
	,CreateDate				DateTime		NOT NULL
	,Last_Modify_Date		DateTime		NOT NULL
	,CONSTRAINT PK_YWT_Dict_Type PRIMARY KEY CLUSTERED (Dict_Type_Code) ON [PRIMARY]
)
BEGIN TRANSACTION
GO
DECLARE @v sql_variant 
SET @v = N'编码'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Type', N'COLUMN', N'Dict_Type_Code'
GO
DECLARE @v sql_variant 
SET @v = N'名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Type', N'COLUMN', N'Dict_Type_Text'
GO
DECLARE @v sql_variant 
SET @v = N'描述'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Type', N'COLUMN', N'Dict_Type_Desc'
GO
COMMIT
GO
--DROP  TABLE YWT_Dict_Code
GO
CREATE TABLE YWT_Dict_Code
(
	Dict_Type_Code		NVARCHAR(50)
	,Dict_Code			NVARCHAR(50)
	,Dict_Text			NVARCHAR(50)
	,Dict_Desc			NVARCHAR(100)
	,CreateDate					DateTime		NOT NULL
	,Last_Modify_Date			DateTime		NOT NULL
	,CONSTRAINT PK_YWT_Dict_Code PRIMARY KEY CLUSTERED (Dict_Type_Code,Dict_Code) ON [PRIMARY]
	,CONSTRAINT UK_YWT_Dict_Code UNIQUE NONCLUSTERED ([Dict_Type_Code],[Dict_Code])
)
BEGIN TRANSACTION
GO
DECLARE @v sql_variant 
SET @v = N'编码'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Code', N'COLUMN', N'Dict_Type_Code'
GO
DECLARE @v sql_variant 
SET @v = N'字典编码'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Code', N'COLUMN', N'Dict_Code'
GO
DECLARE @v sql_variant 
SET @v = N'字典名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Code', N'COLUMN', N'Dict_Text'
GO
DECLARE @v sql_variant 
SET @v = N'字典描述'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Code', N'COLUMN', N'Dict_Desc'
GO
COMMIT
GO
*/
TRUNCATE TABLE YWT_Dict_Type
TRUNCATE TABLE YWT_Dict_Code
DECLARE @Dict_Type_Code NVARCHAR(50)
--运单
SET @Dict_Type_Code=N'UserType' 

INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'用户类型',N'',GETDATE(),GETDATE())
--CODE
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'10',N'运维商',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'20',N'运维人员',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'30',N'第三方运维人员',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'40',N'调度',N'',GETDATE(),GETDATE())


----个人认证类型
SET @Dict_Type_Code=N'CertifyType' 
INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'认证类型',N'',GETDATE(),GETDATE())

INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'P',N'个人',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'E',N'企业',N'',GETDATE(),GETDATE())


--运单
SET @Dict_Type_Code=N'orderstatus' 

INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'运单状态',N'',GETDATE(),GETDATE())
--内单状态
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'0',N'下单',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'1',N'支付',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'20',N'指派运维人员',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'21',N'确定运维人员',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'30',N'开始运维',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'90',N'完成运维',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'91',N'评价运维商',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'92',N'评价运维人员',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'99',N'评价',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'100',N'作废',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'101',N'恢复',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'102',N'删除',N'',GETDATE(),GETDATE())

SET @Dict_Type_Code=N'orderFileType'

INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'运维单文件类型',N'',GETDATE(),GETDATE())

INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'orderfile',N'下单文件',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'30',N'到达目的地文件',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'90',N'完成文件',N'',GETDATE(),GETDATE())

SET @Dict_Type_Code=N'ordertype' 

INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'运维单类型',N'',GETDATE(),GETDATE())

INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'NetworkEquipment',N'网络设备',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'ServerEquipment',N'服务器设备',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'OperatingSystem',N'操作系统',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'BusinessOperations',N'业务运维',N'',GETDATE(),GETDATE())