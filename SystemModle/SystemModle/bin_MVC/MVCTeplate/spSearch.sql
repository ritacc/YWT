/**********************************************************************/
-- Description:	Search data from <#TableName> table for list
-- Remarks:	
---------------------------------------------------------------------
-- Action		Date			Staff		Version		Remarks
-- Create	 	<#Date>			ZCS		1.00.00
/**********************************************************************/
CREATE PROCEDURE spSearch<#ClassName>
(
	 @ResultType	INT				OUTPUT
	,@ResultMessage	NVARCHAR(1000)	OUTPUT
)
AS
BEGIN
	SELECT
<#Filds>
		
		,UPDATE_USER.USER_NAME AS LAST_UPDATED_BY_NAME,
		CREATE_USER.USER_NAME AS CREATED_BY_NAME
	FROM <#TableName>
	LEFT JOIN SY_USER AS CREATE_USER ON <#TableName>.CREATED_BY = CREATE_USER.USER_ID
	LEFT JOIN SY_USER AS UPDATE_USER ON <#TableName>.LAST_UPDATED_BY = UPDATE_USER.USER_ID	
--	WHERE (@GODOWN_CODE = N'')
		

	SET @ResultType = 0;
	SET @ResultMessage = N'Search Succeed.';
	
	RETURN @ResultType;
END