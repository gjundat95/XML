select Sach.* from Sach
for xml raw, elements xsinil

declare @Var nvarchar(max)
declare @Var1 nvarchar(max)
set @Var=(select 
*
From Sach 
FOR XML AUTO, ELEMENTS xsinil , ROOT('Sachs')
)
set @temp = (select CONVERT(nvarchar(max),REPLACE(@Var,' xsi:nil="true"','')) )
select CONVERT(xml,REPLACE(@Var1,' xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"','')) 