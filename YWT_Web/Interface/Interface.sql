
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

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'edit',N'�޸��û�������Ϣ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�޸��û�����:Json��ʽ�ύ')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'edit',N'�޸��û�������Ϣ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�޸��û�����:Json��ʽ�ύ')

--��ά���û�����
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'addsupuser',N'��ӹ�Ӧ���û�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json���� :���Թ�����Ա���ͣ���ά��Ա 10 ������Ա�� 40
����ֶ�:��Ա���͡��ֻ��š��û������������Ա𡢳������¡����䡢ѧ�����Ƿ����  ����ʾ�ֶΣ�ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'addsupuser',N'�޸Ĺ�Ӧ���û���Ϣ ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json����')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getsupuser',N'��ȡ��Ӧ��������û��û���Ϣ ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'����ID')


INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getasupuser',N'��ȡ��Ӧ������һ���û����� ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Ҫ��ѯ������û�ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'����ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getcertifyfile',N'��ѯ˭�Ѿ��ϴ����ļ�����Ҫ�ϴ����ļ� ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�û�ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��֤���� p ���� e ��ҵ')
GO



/*
	YWT_Supplier ��ά����Ϣ
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_Supplier.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'addupdate','ע��ʱ������ά�����ݣ�ע��󱣴���ά�����ݡ�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��Josn����')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:��ǰ������ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'get','��ѯ��ά�����ݡ�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��ID')


GO
/*
	HL.ashx ������Ϣ
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='HL.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'sl','��ʱ��������')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�û�ID UserID��UserAutoID �����ԣ����������UserAutoID��Լ�ϴ�����')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'longitude')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'latitude')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getsubxy',N'��ѯ��ά������������ά��Աλ��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ǰ��¼ID')



GO
/*
	YWT_UPFile.ashx �ϴ��ļ�
*/
DECLARE @Inerface_ID	BIGINT		
        ,@IFile			VARCHAR(50)='YWT_UPFile.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'userimg','�ϴ��û�ͷ���ļ��� ****������ӿڻ�����YWT_UPUserFile.ashx')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�û�ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'from',N'��Դ��IOS ��Android')



GO
/*
	YWT_UPUserFile.ashx �ϴ��ļ� ��Ҫ�����û���֤�� userimg �û�ͷ��
*/
DECLARE @Inerface_ID	BIGINT		
        ,@IFile			VARCHAR(50)='YWT_UPUserFile.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'userimg �� action=getcertifyfile�������� ','�û���֤���ϴ��û�ͷ���ļ���')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�û�ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'from',N'��Դ��IOS ��Android')
 


GO
/*
	YWT_UserInfo.ashx ��ά��Ա ��ϸ��Ϣ
*/

DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_UserInfo.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'addupdate','�޸��û����� ,�ڶ����ύ���������Ա𣬳������¡����䡣���ע�ᡣ�����������������ƾͿ����ˡ�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��Ա Josn ����')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:��ǰ������ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'get','����ID��ѯһ����ά��Ա�þݡ������޸ģ��鿴��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��άID')
