set serviceName=MzghApi
set serviceFilePath=D:\lijun\github\Mzgh\CoreApi\bin\Release\netcoreapp3.1\publish\CoreApi.exe
set serviceDescription=门诊挂号系统服务

sc create %serviceName%  BinPath= %serviceFilePath%
sc config %serviceName%    start= auto
sc description %serviceName%  %serviceDescription%
sc start  %serviceName%
pause