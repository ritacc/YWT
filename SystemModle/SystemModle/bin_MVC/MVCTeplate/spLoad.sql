/**********************************************************************/
-- Description:	load data from <#TableName> table
-- Remarks:	
---------------------------------------------------------------------
-- Action		Date			Staff		Version		Remarks
-- Create	 	<#Date>			zcs		1.00.00
/**********************************************************************/
CREATE PROCEDURE spLoad<#ClassName>  
(  
  @<#Key>  BIGINT  
 ,@ResultType INT    OUTPUT  
 ,@ResultMessage NVARCHAR(1000) OUTPUT  
)  
AS  
BEGIN  
 SELECT  
<#Filds>  
 FROM  
  <#TableName>
 WHERE  
  <#Key> = @<#Key>;  
    
 SET @ResultType = 0;  
 SET @ResultMessage = N'SUCCEED';  
   
 RETURN @ResultType;  
END