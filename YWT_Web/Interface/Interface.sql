
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
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json���� :���Թ�����Ա���ͣ���ά��Ա 20 ������Ա�� 40
����ֶ�:��Ա���͡��ֻ��š��û������������Ա𡢳������¡����䡢ѧ�����Ƿ����  ����ʾ�ֶΣ�ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'editsupuser',N'�޸Ĺ�Ӧ���û���Ϣ ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json����')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getsupuser',N'��ȡ��Ӧ��������û��û���Ϣ ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'����ID')


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
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��Josn���� {Company ContactMan  Mobile}')
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
	YWT_OrderFile.ashx �ϴ��ļ�
*/
DECLARE @Inerface_ID	BIGINT		
        ,@IFile			VARCHAR(50)='YWT_OrderFile.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'xx','�˽ӿڲ���Ҫaction �ϴ��󷵻��ļ�·���� ���غ����ύ�������ݡ�')
--SET @Inerface_ID=@@IDENTITY 
--INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��ID')
--INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:������ID')
--INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'from',N'��Դ��IOS ��Android')

GO
/*
	YWT_Order.ashx ��ά������߼�
*/
DECLARE @Inerface_ID	BIGINT		
        ,@IFile			VARCHAR(50)='YWT_Order.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'addinternal','����ڵ�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json���ݡ�������ά�����ݣ����ϴ��ļ����ݡ�  ��ϸ�ֶο��������� ��ά��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:������ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'addexternal',N'�ⲿ��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json���ݡ�������ά�����ݣ����ϴ��ļ����ݡ� ��ϸ�ֶο��������� ��ά��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:������ID')


INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getlist',N'��ȡ��ά���б�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ʼҳ����0��ʼ ÿ�μ���ʮ��������ˢ��:ˢ��ʱ����+1 ,�����ѯ�ɹ���û������˵���Ѿ�������ɡ���Ҫ��ˢ��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'�б��Ϊ��ȫ������ά�С�ƽ̨��ά���� (-1 ȫ�� 0 ��ά�� 50 ƽ̨��ά��) ')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getitem',N'��ȡ��ά����ϸ��Ϣ��������ά�������ݣ�ͼƬ������������ά��Ա����ά����')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��ID��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:������ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'saveorderflow',N'���涩������ 30 90 ��״̬ʹ�ô˽ӿ�ֱ�ӽ����ύ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Order_ID,��ά��ID��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'Order_Status: �ύ״̬,30,90��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'Create_User: ����ID��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q3',N'x1 �ύʱ����')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q4',N'y���ύʱ����')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q5',N'x,y����������ϸ��ַ��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q6',N'��ע�������ύһЩ���ݡ�')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q7',N'json�ļ��������ϴ�����ļ�����Ҫ��ʹ���ϴ��ӿڣ����ύ����:[{"FileName":"/Upload/....png"},{"FileName":"/Upload/....png"}]')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'designateuser',N'ָ����ά��Ա')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'json��ѡ�����ά��Ա��:[{"UserID":"800F50A2-6477-4DAE-A6E9-AA445782F789"},{"UserID":"67C3360C-BBB4-4DF1-8372-89A4AB79F907"}]')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'Order_Status: OrderID,��ά��ID ')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'Create_User: ����ID��')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'orderassess',N'��ά������')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'json��{Assess_Type: �ڵ�: 0 �ⵥ��״̬��ͬ Order_ID��YW_Result����ά��ɽ������ɡ�δ��ɣ�Score����ά�÷֣�1-5��AssessContent����������},Create_User: ����ID��')

--�ⵥ
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'orderplatformapply',N'�������� ������ά��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'json��{Order_ID,Apply_UserID,Apply_Content: ��������,ContactMan:��ϵ��,ContactMobile:��ϵ�绰}')


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


GO
/*
VerifyCode.ashx	��ά�û����	
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='VerifyCode.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'sendverifycode','������֤��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�ֻ�����')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'IMEI') 

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'checkverifycode','��֤�Ƿ���ȷ��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�ֻ�����')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'IMEI')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'��֤��')

GO

/*
YWT_Setup.ashx	��ά�û����	
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_Setup.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'setup','��װͳ�ƽӿڣ���Ӱ�װ��¼')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'IMEI')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'OS') 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'Manufacturer') 