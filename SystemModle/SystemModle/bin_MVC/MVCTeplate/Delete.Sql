/**********************************************************************/
-- Description:	Delete <#TableName> Info
---------------------------------------------------------------------
-- Action		Date			Staff		Version		Remarks
-- Create	 	<#Date>		zcs		1.00.00
---------------------------------------------------------------------
/**********************************************************************/
CREATE PROCEDURE spDelete<#ClassName>
(
	 @<#Key>				BIGINT
	,@ResultType			INT				OUTPUT
	,@ResultMessage			NVARCHAR(1000)	OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	BEGIN TRY
		
		DECLARE @FKConflictsResult AS BIT;
		EXEC dbo.spCheckFKConflicts 
			@TABLE_NAME = N'<#TableName>'
			,@ID = @<#Key>
			,@Result = @FKConflictsResult OUTPUT;
			
		IF (@FKConflictsResult = 1)
		BEGIN
			SET @ResultType = -1004;
			SET @ResultMessage = N'Foreign key conflicts.';
			RAISERROR (@ResultMessage, 11/* 必须>10才能转到Catch */, 1, 5); /* 抛出异常，并转到 Catch */
		END
		
		DELETE FROM 
			dbo.<#TableName> 
		WHERE 
			dbo.<#TableName>.<#Key> = @<#Key>;
		
		SET @ResultType = 0;
		SET @ResultMessage = N'SUCCEED';
		
		RETURN @ResultType;
		
	END TRY
	BEGIN CATCH
		
		--返回信息
		IF (ISNULL(@ResultType, 0)=0)
			BEGIN
				SET @ResultType = -9999;
				SET @ResultMessage = ERROR_MESSAGE();
			END
				
		RETURN @ResultType;
	END CATCH
	
END