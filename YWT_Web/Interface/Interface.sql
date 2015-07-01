
GO
TRUNCATE TABLE YWT_Inerface
TRUNCATE TABLE YWT_Inerface_PARA
GO
/*
YWT_User.ashx	运维用户相关	
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_User.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'reg','注册')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'注册数据:Json格式提交')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'login',N'登录')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'用户ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'密码')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'IMEI')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q3',N'OS')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q4',N'Manufacturer:生产厂家')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'alertpwd',N'修改密码')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'用户ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'旧密码')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'新密码')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'edit',N'修改用户基本信息')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'修改用户数据:Json格式提交')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'edit',N'修改用户基本信息')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'修改用户数据:Json格式提交')

--运维商用户管理
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'addsupuser',N'添加供应商用户')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json数据 :可以管理人员类型：运维人员 10 调度人员： 40
添加字段:人员类型、手机号、用户名、姓名、性别、出生年月、邮箱、学历、是否可用  不显示字段：ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'addsupuser',N'修改供应商用户信息 ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'Json数据')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getsupuser',N'获取供应商下面的用户用户信息 ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'操作ID')


INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getasupuser',N'获取供应商下面一个用户数据 ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'要查询下面的用户ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'操作ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getcertifyfile',N'查询谁已经上传的文件或需要上传的文件 ')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'用户ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'认证类型 p 个人 e 企业')
GO



/*
	YWT_Supplier 运维商信息
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_Supplier.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'addupdate','注册时保存运维商数据，注册后保存运维商数据。')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'运维商Josn数据')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:当前操作人ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'get','查询运维商数据。')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'运维商ID')


GO
/*
	HL.ashx 坐标信息
*/
DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='HL.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'sl','定时保存坐标')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'用户ID UserID和UserAutoID 都可以，但是最好用UserAutoID节约上传流量')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'longitude')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q2',N'latitude')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,N'getsubxy',N'查询运维商下面所有运维人员位置')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'当前登录ID')



GO
/*
	YWT_UPFile.ashx 上传文件
*/
DECLARE @Inerface_ID	BIGINT		
        ,@IFile			VARCHAR(50)='YWT_UPFile.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'userimg','上传用户头像文件。 ****将这个接口换到下YWT_UPUserFile.ashx')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'用户ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:操作人ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'from',N'来源：IOS 或Android')



GO
/*
	YWT_UPUserFile.ashx 上传文件 主要用于用户认证及 userimg 用户头像
*/
DECLARE @Inerface_ID	BIGINT		
        ,@IFile			VARCHAR(50)='YWT_UPUserFile.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'userimg 或 action=getcertifyfile中所定义 ','用户认证及上传用户头像文件。')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'用户ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:操作人ID')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'from',N'来源：IOS 或Android')
 


GO
/*
	YWT_UserInfo.ashx 运维人员 详细信息
*/

DECLARE @Inerface_ID	BIGINT		
		,@IFile			VARCHAR(50)='YWT_UserInfo.ashx'
INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'addupdate','修改用户数据 ,第二步提交：姓名，性别，出生年月、邮箱。完成注册。到个人资料里再完善就可以了。')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'运维人员 Josn 数据')
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:当前操作人ID')

INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'get','根据ID查询一个运维人员用据。用于修改，查看。')
SET @Inerface_ID=@@IDENTITY 
INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'运维ID')
