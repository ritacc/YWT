
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

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'editselfinfo',N'�޸ĸ������ϣ���������ά��Ա')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'YWTUserInfoOR �µ���ϸ����')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getasupuser',N'��ȡ��Ӧ������һ���û����� ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Ҫ��ѯ������û�ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'����ID')

INSERT INTO SNR_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'userfilecertify','�ύ�û���֤')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO SNR_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��֤�û�ID')
INSERT INTO SNR_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��֤����: P���ˣ��û�����Ϊ��30 ʱʹ�ã�E��ҵ���û�����Ϊ10ʱʹ��')
INSERT INTO SNR_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'����')
INSERT INTO SNR_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q3',N'���֤��')
INSERT INTO SNR_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q4',N'E������֤ʱʹ�ã���˾���ơ�')

INSERT INTO SNR_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getuserfile','��ѯ�û���֤�ļ�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO SNR_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��֤�û�ID')

INSERT INTO SNR_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getauserbyid','����id��ѯ�û���Ϣ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO SNR_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ѯ�û�ID')

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
	YWT_OrderPlatform.ashx �ⵥ��ع���
*/
DECLARE @Inerface_ID	BIGINT		
        ,@IFile			VARCHAR(50)='YWT_OrderPlatform.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'addexternal',N'�ⲿ��ά�� �µ�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json���ݡ�������ά�����ݣ����ϴ��ļ����ݡ� ��ϸ�ֶο��������� ��ά��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:������ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getlistforall',N'�������б�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ʼҳ����0��ʼ ÿ�μ���ʮ��������ˢ��:ˢ��ʱ����+1 ,�����ѯ�ɹ���û������˵���Ѿ�������ɡ���Ҫ��ˢ��')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getlistforsupplier',N'�µ����б�  ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ʼҳ����0��ʼ ÿ�μ���ʮ��������ˢ��:ˢ��ʱ����+1 ,�����ѯ�ɹ���û������˵���Ѿ�������ɡ���Ҫ��ˢ��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'������ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'ywusergetlist',N'��������Ա��ѯ����ɹ���¼��ѯ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ʼҳ����0��ʼ ÿ�μ���ʮ��������ˢ��:ˢ��ʱ����+1 ')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'������ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'applyrecord',N'��������Ա��ѯ�����¼��ѯ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ʼҳ����0��ʼ ÿ�μ���ʮ��������ˢ��:ˢ��ʱ����+1 ')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'������ID')


INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getitem',N'��ѯһ��ƽ̨��ά��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'������ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'applyyw',N'��������ά��Ա������ά��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'json����:{ Order_ID,Apply_UserID,Apply_Content,ContactMan,ContactMobile}')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'������ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'comfirmapplyuser',N'ȷ����������ά��')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'������ά����¼��ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'������ID')



INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'assess',N'����')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��������: 91 ��������ά��Ա 92 ��ά��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'��ά���: ��� δ���')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q3',N'���� 1-5 ������')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q4',N'��������')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q5',N'������ID')


INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getlistapplyusers',N'�������� ���������б�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��СID  ��һ�δ�-1, ��һ�μ��Ժ�ȡ��СID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getitemapplyusers',N'��������ID ��ѯ�����˵���ϸ��Ϣ ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'�������� Platform_Apply_ID')

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

GO

/*
YWT_YWLog.ashx	��ά��־	
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_YWLog.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'addedit','д����ά��־ �����󷢲�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ά��־Json����:{LogID,UserID,Title ,Content,LogStatus} LogStatus:0 ���棬1 ���� ')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��ά��־�ļ������:[{"FileName":"/Upload/....png"},{"FileName":"/Upload/....png"}]') 

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getlist','��ȡ�Լ����б�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'���ڷ�ҳ����һ�δ�-1, ��һ�μ��Ժ�ȡ��СID') 

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getcompanylist','��ѯ�����б�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'���ڷ�ҳ����һ�δ�-1, ��һ�μ��Ժ�ȡ��СID') 

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getitem','��ѯһ����־��ϸ �����ݣ��ļ�������')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��־ID :logid') 

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'logreply','������־')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��־ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'������ID') 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'��������') 

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getitemreply','������־')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��־ID :logid') 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'���ڷ�ҳ��getitem �Ѿ���ѯ�˵�һ�Σ�ȡ��СlogID����') 

GO

/*
YWT_OnlineApproval.ashx	��������	
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_OnlineApproval.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'add','д����')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json���� {"ApplyType":"","ApplyContent":"��������","ApplyUserID":"������"} 
<br/> ApplyType��������<���������������Ա > ')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getlist','���������б�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'���ڷ�ҳ����һ�δ�-1, ��һ�μ��Ժ�ȡ��СID') 

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getitem','��ѯһ����������')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'����ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getcompanylist','��ѯ��Ҫ��ˣ�δ����б�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��ʼҳ����0��ʼ ÿ�μ���ʮ��������ˢ��:ˢ��ʱ����+1') 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'��״̬չʾ  0 δ���  1 �����  -1 ȫ��') 

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'approval','����')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'����ID OnlineApproval_ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'�����ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'1 ͬ��  2 ��ͬ��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q3',N'������� �������д')
GO

/*
YWT_Registration.ashx	�ֻ���	
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_Registration.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'add','�ֻ���')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json���ݣ�<br/>
{UserID":"","latitude":"","longitude":"","Position":"����ת����λ����Ϣ","IMEI":""}')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1','������ID') 

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getlist','��ȡ��Ʒ�б�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��СID����һ��-1')
 
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getcompanylist','��ѯԱ���򿨼�¼')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'ָ����ά��ԱID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'��ѯ���ͣ� day ����   7day 7����  pmonth ����  cmonth ���� 3month')
--INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q3',N'����ʱ��')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q3',N'��СID����һ��-1')
 
GO
/*
YWT_Warehouse.ashx	�ֿ�����
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_Warehouse.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'add','��Ӳ�Ʒ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json���ݣ�<br/>
{"Prodeuct_Name":"��Ʒ����","Product_Brand":"Ʒ��","Prodeuct_Model":"�ͺ�","Number":����,"Unit":"��λ�� ���������ס��ס�̨","Create_User":"��ӡ��޸���ID"}')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'edit','�޸Ĳ�Ʒ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json���ݣ�<br/>
{"Warehouse_ID":0,"Prodeuct_Name":"��Ʒ����","Product_Brand":"Ʒ��","Prodeuct_Model":"�ͺ�","Number":����,"Unit":"��λ�� ���������ס��ס�̨","Create_User":"��ӡ��޸���ID"}')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getlist','��ȡ��Ʒ�б�')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'������ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'��СID����һ��-1')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'getitem','��ѯ��Ʒ��ϸ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'��ƷID')






 
