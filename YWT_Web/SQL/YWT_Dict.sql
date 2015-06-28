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
SET @Dict_Type_Code=N'PersonalCertifyType' 
INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'个人认证类型',N'',GETDATE(),GETDATE())

INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'1',N'身份证-正面',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'2',N'身份证-返面',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'3',N'学历证书',N'',GETDATE(),GETDATE())

  