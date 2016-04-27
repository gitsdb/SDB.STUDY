%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe E:\ProjectTest\SDB.STUDY\Study.WindowsServiceTest\bin\Debug\Study.WindowsServiceTest.exe
Net Start QuartzService7
sc config QuartzService7 start= auto
pause