/**********************************************************************/
-- Description:	Save <#TableName> Info(Create/Edit)
---------------------------------------------------------------------
-- Action		Date			Staff		Version		Remarks
-- Create	 	<#Date>			ZCS		1.00.00
---------------------------------------------------------------------
/**********************************************************************/
Create PROCEDURE spSave<#ClassName>
(
<#SavePara>

	,@RecordStatus			NVARCHAR(10)
	,@ResultType			INT				OUTPUT
	,@ResultMessage			NVARCHAR(1000)	OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @CURRENT_DATE DATETIME;
	SET	@CURRENT_DATE = GETDATE();
	
	BEGIN TRY
	
		IF @RecordStatus = N'ADD'
		BEGIN		
			IF EXISTS(SELECT 1 FROM dbo.<#TableName> WHERE <#TableName>.BIN_LOC_CODE = @BIN_LOC_CODE )
			BEGIN
				SET @ResultType = -1001;
				SET @ResultMessage = N'RECORD CONTAINS DUPLICATE DATA';
				RAISERROR (@ResultMessage, 11/* 必须>10才能转到Catch */, 1, 5); /* 抛出异常，并转到 Catch */
			END

			INSERT INTO <#TableName>
			(
<#AddFiles>	
			)
			VALUES
			(
<#AddValues>
			);
			
						
			SET @ResultType = 0;
			SET @ResultMessage = N'Add Succeed';
		END
		ELSE IF @RecordStatus = N'EDIT'
		BEGIN
		
			IF EXISTS(SELECT 1 FROM <#TableName> WHERE <#TableName>.BIN_LOC_CODE = @BIN_LOC_CODE 
			 AND <#TableName>.<#Key> <> @<#Key>)
			BEGIN
				SET @ResultType = -1001;
				SET @ResultMessage = N'RECORD CONTAINS DUPLICATE DATA';
				RAISERROR (@ResultMessage, 11/* 必须>10才能转到Catch */, 1, 5); /* 抛出异常，并转到 Catch */
			END
			
			UPDATE 
				<#TableName>
			SET
<#UpdateFiles>
			WHERE
				<#TableName>.<#Key> = @<#Key>;
				
			SET @ResultType = 0;
			SET @ResultMessage = N'Edit Succeed';
		END

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