
GO
TRUNCATE TABLE YWT_Inerface
TRUNCATE TABLE YWT_Inerface_PARA
GO
/*
YWT_User.ashx	��ά�û����	
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_User.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'reg','ע��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'ע������:Json��ʽ�ύ')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'login',N'��¼')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�û�ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'����')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'IMEI')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q3',N'OS')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q4',N'Manufacturer:��������')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'alertpwd',N'�޸�����')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�û�ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'������')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'������')

GO
/*
	HL.ashx ������Ϣ
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='HL.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'sl','��ʱ��������')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�û�ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'longitude')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'latitude')




