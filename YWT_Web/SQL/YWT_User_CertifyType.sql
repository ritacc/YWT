 
	/*
	 drop table YWT_User_CertifyType
	
	Create Table YWT_User_CertifyType
	(
		CertifyType_ID		Bigint IDENTITY(1,1)
		,PE					VARCHAR(1)
		,CertifyTypeCode	VARCHAR(30)
		,CertifyTypeName	VARCHAR(30)
		,IsMust				BIT
		
		,CONSTRAINT PK_YWT_User_CertifyType PRIMARY KEY CLUSTERED (CertifyType_ID) ON [PRIMARY]
	)
	
	 EXECUTE sp_addextendedproperty N'MS_Description', N'P个人，E企业', N'SCHEMA', N'dbo', N'TABLE', N'YWT_User_CertifyType', N'COLUMN', N'PE'
	 EXECUTE sp_addextendedproperty N'MS_Description', N'认证类型code 如：身份证 录入为：sfz', N'SCHEMA', N'dbo', N'TABLE', N'YWT_User_CertifyType', N'COLUMN', N'CertifyTypeCode'
	 EXECUTE sp_addextendedproperty N'MS_Description', N'认证类型名称 如：身份证', N'SCHEMA', N'dbo', N'TABLE', N'YWT_User_CertifyType', N'COLUMN', N'CertifyTypeName'
	 EXECUTE sp_addextendedproperty N'MS_Description', N'是否必须', N'SCHEMA', N'dbo', N'TABLE', N'YWT_User_CertifyType', N'COLUMN', N'IsMust'
	*/
	--个人
	INSERT INTO YWT_User_CertifyType([PE],[CertifyTypeCode],[CertifyTypeName],[IsMust]) VALUES('P','p_sfzzm','身份证-正面',1)
	INSERT INTO YWT_User_CertifyType([PE],[CertifyTypeCode],[CertifyTypeName],[IsMust]) VALUES('P','p_sfzfm','身份证-背面',1)
	
	--企业
	INSERT INTO YWT_User_CertifyType([PE],[CertifyTypeCode],[CertifyTypeName],[IsMust]) VALUES('E','e_fr_sfzzm','企业法人身份证-正面',1)
	INSERT INTO YWT_User_CertifyType([PE],[CertifyTypeCode],[CertifyTypeName],[IsMust]) VALUES('E','e_fr_sfzfm','企业法人身份证-背面',1)
	INSERT INTO YWT_User_CertifyType([PE],[CertifyTypeCode],[CertifyTypeName],[IsMust]) VALUES('E','e_ylzz','营业执照',1)
 
