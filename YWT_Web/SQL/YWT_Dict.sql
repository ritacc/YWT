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
SET @v = N'����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Type', N'COLUMN', N'Dict_Type_Code'
GO
DECLARE @v sql_variant 
SET @v = N'����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Type', N'COLUMN', N'Dict_Type_Text'
GO
DECLARE @v sql_variant 
SET @v = N'����'
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
SET @v = N'����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Code', N'COLUMN', N'Dict_Type_Code'
GO
DECLARE @v sql_variant 
SET @v = N'�ֵ����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Code', N'COLUMN', N'Dict_Code'
GO
DECLARE @v sql_variant 
SET @v = N'�ֵ�����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Code', N'COLUMN', N'Dict_Text'
GO
DECLARE @v sql_variant 
SET @v = N'�ֵ�����'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'YWT_Dict_Code', N'COLUMN', N'Dict_Desc'
GO
COMMIT
GO
*/
TRUNCATE TABLE YWT_Dict_Type
TRUNCATE TABLE YWT_Dict_Code
DECLARE @Dict_Type_Code NVARCHAR(50)
--�˵�
SET @Dict_Type_Code=N'UserType' 

INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'�û�����',N'',GETDATE(),GETDATE())
--CODE
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'10',N'��ά��',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'20',N'��ά��Ա',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'30',N'��������ά��Ա',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'40',N'����',N'',GETDATE(),GETDATE())


----������֤����
SET @Dict_Type_Code=N'CertifyType' 
INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'��֤����',N'',GETDATE(),GETDATE())

INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'P',N'����',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'E',N'��ҵ',N'',GETDATE(),GETDATE())


--�˵�
SET @Dict_Type_Code=N'orderstatus' 

INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'�˵�״̬',N'',GETDATE(),GETDATE())
--�ڵ�״̬
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'0',N'�µ�',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'1',N'֧��',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'20',N'ָ����ά��Ա',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'21',N'ȷ����ά��Ա',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'30',N'��ʼ��ά',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'90',N'�����ά',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'91',N'������ά��',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'92',N'������ά��Ա',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'99',N'����',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'100',N'����',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'101',N'�ָ�',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'102',N'ɾ��',N'',GETDATE(),GETDATE())

SET @Dict_Type_Code=N'orderFileType'

INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'��ά���ļ�����',N'',GETDATE(),GETDATE())

INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'orderfile',N'�µ��ļ�',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'30',N'����Ŀ�ĵ��ļ�',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'90',N'����ļ�',N'',GETDATE(),GETDATE())

SET @Dict_Type_Code=N'ordertype' 

INSERT INTO YWT_Dict_Type (Dict_Type_Code,Dict_Type_Text,Dict_Type_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'��ά������',N'',GETDATE(),GETDATE())

INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'NetworkEquipment',N'�����豸',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'ServerEquipment',N'�������豸',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'OperatingSystem',N'����ϵͳ',N'',GETDATE(),GETDATE())
INSERT INTO YWT_Dict_Code (Dict_Type_Code,Dict_Code,Dict_Text,Dict_Desc,CreateDate,Last_Modify_Date) VALUES(@Dict_Type_Code,N'BusinessOperations',N'ҵ����ά',N'',GETDATE(),GETDATE())