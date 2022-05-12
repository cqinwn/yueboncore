color B

del  .PublishFiles\*.*   /s /q

dotnet restore

dotnet build

cd Yuebon.WebApi

dotnet publish -o ..\Yuebon.WebApi\bin\Debug\net6.0\

md ..\.PublishFiles

xcopy ..\Yuebon.WebApi\bin\Debug\net6.0\*.* ..\.PublishFiles\ /s /e 

echo "Successfully!!!! ^ please see the file .PublishFiles"

cmd