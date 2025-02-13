# Open Touryo

## Outline
*Open Touryo* is an application framework based on .NET Framework and .NET Core.  
The programs of Open Touryo are available in the following repositories:
- OpenTouryoTemplates repository
    - Summary  
    The programs in this repository are the *development infrastructure (project template)* of the programs using Open Touryo.  
    And the programs are partitioned into the folders for each version of Visual Studio.
    - Intended User  
    The *application developers* using Open Touryo.
- OpenTouryo repository (*Current repository*)
    - Summary  
    The programs in this repository are the *matrix* of OpenTouryoTemplates repository.  
    (First, the features of Open Touryo are implemented in this repository. And then, the features are introduced into OpenTouryoTemplates repository.)
    - Intended User  
    *Open source developers*.

Therefore, the users who use Open Touryo in a system development project need to use [OpenTouryoTemplates repository](https://github.com/OpenTouryoProject/OpenTouryoTemplates).  
The following contents are the usage of Open Touryo for *open source developers*.

Click [here](Readme.ja.md) for Japanese version of this file.

## Running sample application tasks
You can run the sample application bundled with Open Touryo according to the following steps.

Notation *Optional*:  
Open Touryo supports the following DBMSs and data providers. But the data providers, having the notation *optional*, are not included in the programs of Open Touryo. When using the DBMSs and data providers having the notation *optional*, download the data provider manually, and modify [the data access project of Open Touryo, that is DamXXX.csproj](https://github.com/OpenTouryoProject/OpenTouryo/tree/develop/root/programs/CS/Frameworks/Infrastructure/Public/Db), to refer the data provider.

### Install prerequisites
Install Visual Studio 2015 beforehand.  
If you develop for .NET Standard or .NET Core, install Visual Studio 2017 beforehand.  
see: https://docs.microsoft.com/ja-jp/dotnet/core/windows-prerequisites

Further, when implementing or testing the *data access class*, install the DBMS(s) to be used.  
Open Touryo supports the following DBMSs:
- SQL Server  
(You can use an arbitrary version of SQL Server. And you can use different editions than Express Edition.)
- Oracle Database (including Express Edition)
- IBM DB2 ... optional
- HiRDB ... optional
- MySQL
- PostgreSQL

### Deploy Open Touryo
Copy *root* folder to just under C drive. If not, the build may fail for the Windows maximum path length limitation.

### Obtain and deploy data providers
The correspondence between the DBMSs and the data providers is as follows.

- Oracle
  - Oracle.DataAccess.dll ... optional
  - Oracle.ManagedDataAccess.dll
- IBM DB2
  - IBM.Data.DB2.dll ... optional
- HiRDB
  - x86: pddndp40.dll, pddndpcore40.dll ... optional
  - x64: pddndp40x.dll, pddndpcore40x.dll ... optional
- MySQL
  - MySql.Data.dll
- PostgreSQL
  - Npgsql.dll

### Set up sample database
#### SQL Server  
Sample application requires *Northwind* database.  
So, download the setup script installer of *Northwind* database from the following Microsoft site and install.

  - Download: NorthWind and pubs Sample Databases for SQL Server 2000 - Microsoft Download Center  
    http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=23654

When completing the installation, *SQL Server 2000 Sample Databases* folder is created in C drive.
When using SQL Server 2012 or later, open *instnwnd.sql* file in an editor and comment out the following code.  
**Note**:  
Because *sp_option* system stored procedure does not exist in SQL Server 2012 or later, this step is required.

```sql
exec sp_dboption 'Northwind','trunc. log on chkpt.','true'
exec sp_dboption 'Northwind','select into/bulkcopy','true'
```

Execute the following command at a command prompt.  
**Note**:  
In the following command, the path of the folder that contains *SQLCMD.EXE* changes according to the version of SQL Server. Execute command after confirming the path of folder in your environment. 
```bat
"C:\Program Files\Microsoft SQL Server\100\Tools\Binn\SQLCMD.EXE" -S localhost\SQLExpress -E -i "C:\SQL Server 2000 Sample Databases\instnwnd.sql"
```

#### DBMSs except for SQL Server
- Create an empty database in each DBMSs.
- Create test table in the database by running C:\root\files\resource\Sql\\[DBMS Name]\TestTable.txt.

### Build program
When using Open Touryo, it is necessary to build programs **by running the batch files using MSBuild only at the first time**.  
**Note**:  
Open Touryo Template Base contains two parts:
- Framework (Base class 1 and base class 2)
- Sample application (Subclass)

It is necessary to copy the *deliverables generated by building*, that is, *dll files* to the default folder of Open Touryo.  
Therefore, it is necessary to run the batch files which execute a series of build processes.

The batch files are stored in the following folder:
- C:\root\programs\CS  
- C:\root\programs\VB

By executing `0_ExecAllBat.bat`, you can execute necessary batch files together. Refer to the table below, check the necessary batch to be executed, customize `0_ExecAllBat.bat` as necessary, and execute it.

<table Border="1">
<tr>
<Td style="background-color:#9BC2E6;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;font-weight:bold;" colspan="1" rowspan="2">Batch file name </td>
<Td style="background-color:#9BC2E6;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;font-weight:bold;" colspan="1" rowspan="2">Description</td>
<Td style="background-color:#9BC2E6;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;font-weight:bold;" colspan="2" rowspan="1">Existence</td>
</tr>
<tr>
<Td style="background-color:#9BC2E6;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;font-weight:bold;">C#</td>
<Td style="background-color:#9BC2E6;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;font-weight:bold;">VB</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">0_ExecAllBat.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Perform a batch build using the following files: Customize as needed.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">1_DeleteDir.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Delete (Clean up) the folders that are generated by building.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">1_DeleteFile.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Delete (Clean up) the temporary files. </td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">2_Build_NuGet_net45.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the framework (Base class 1 and library part) to make NuGet package that targets .NET Framework 4.5.2. </td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○*1</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">2_Build_NuGet_net46.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the framework (Base class 1 and library part) to make NuGet package that targets .NET Framework 4.6. </td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○*1</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">2_Build_NuGet_net47.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the framework (Base class 1 and library part) to make NuGet package that targets .NET Framework 4.6. </td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○*1</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">2_Build_NuGet_netstd20.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the framework (Base class 1 and library part) to make NuGet package that targets .NET Standard 2.0. </td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○*1, *3</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">3_Build_Business_net45.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build a framework (base class 2, library part) of Business namespace that targets .NET Framework 4.5.2.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">3_Build_Business_net46.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build a framework (base class 2, library part) of Business namespace that targets .NET Framework 4.6.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">3_Build_Business_net47.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build a framework (base class 2, library part) of Business namespace that targets .NET Framework 4.7.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">3_Build_BusinessRichClient_net45.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build a framework for rich client application (base class 2, library part) of Business namespace that targets .NET Framework 4.5.2.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*2</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">3_Build_BusinessRichClient_net46.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build a framework for rich client application (base class 2, library part) of Business namespace that targets .NET Framework 4.6.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*2</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">3_Build_BusinessRichClient_net47.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build a framework for rich client application (base class 2, library part) of Business namespace that targets .NET Framework 4.7.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*2</td>
</tr>
<tr>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">3_Build_Business_netcore20.bat</td>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build a framework (base class 2, library part) of Business namespace that targets .NET Core 2.0.</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○*3</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">3_Build_Business_netcore30.bat</td>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build a framework (base class 2, library part) of Business namespace that targets .NET Core 3.0.</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○*3</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">4_Build_CopyAssemblies.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Copy the primary output of the above build to the reference folder.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">4_Build_Framework_Tool.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the .NET Framework-based tools bundled with Open Touryo.</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">5_Build_Bat_sample.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the .NET Framework-based sample application. (Batch application)</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*4</td>
</tr>
<tr>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">5_Build_BatCore_sample.bat</td>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the .NET Core-based sample application. (Batch application)</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○*3, *4</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">5_Build_2CS_sample.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the .NET Framework-based sample application. (Two-tier client server application)</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*4</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">6_Build_WSSrv_sample.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the .NET Framework-based sample application. (Web services (Server-side logic))</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*4</td>
</tr>
<tr>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">6_Build_WSSrvCore_sample.bat</td>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the .NET Core-based sample application. (Web services (Server-side logic))</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">7_Build_Framework_WS.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the .NET Framework-based framework. (Service interface)</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*4</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">8_Build_WSClntWin_sample.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the .NET Framework-based sample application. (Web service client (Windows forms)) </td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*4</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">9_Build_WSClntWPF_sample.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the .NET Framework-based sample application. (Web service client (WPF)) </td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*4</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">10_Build_WebApp_sample.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the sample web application. (ASP.NET)</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;" colspan="2" rowspan="1">○*4</td>
</tr>
<tr>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">10_Build_WebAppCore_sample.bat</td>
<Td style="background-color:#F8CBAD;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build the sample web application. (ASP.NET Core)</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○*3, *4</td>
<Td style="background-color:#F8CBAD;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">99_BuildLibsAtOtherRepos.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Batch file for to use the Business namespace of the repository in other repositories. (using OpenTouryoTemplates-master branch)</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">99_BuildLibsAtOtherReposInTimeOfDev.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Batch file for to use the Business namespace of the repository in other repositories. (using OpenTouryo-develop branch)</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">y_Build_TestCode.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Perform batch build and execution of the following test code.</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">y_Build_TestCode_Public.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build and execute the test code of the following Public namespace.</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">y_Build_TestCode_SecCUI.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build and execute the CUI test code of the following Public.Security namespace.</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">y_Build_TestCode_SecCUI.txt</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build and execute the CUI test code of the following Public.Security namespace usin WSL.</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">y_Build_TestCode_SecGUI.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Build and execute the GUI test code of the following Public.Security namespace.</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">z_ChangePackages_net45.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Batch file to switch packages.config when creating NuGet package. (for .NET Framework 4.5.2)</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">z_ChangePackages_net46.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Batch file to switch packages.config when creating NuGet package. (for .NET Framework 4.6)</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">z_ChangePackages_net47.bat</td>
<Td style="background-color:#C6E0B4;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Batch file to switch packages.config when creating NuGet package. (for .NET Framework 4.7)</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#C6E0B4;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">－</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">z_Common.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Common settings (for MSBuild)</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
</tr>
<tr>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">z_Common2.bat</td>
<Td style="background-color:#FFFFFF;text-align:left;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">Common settings (for Visual Studio)</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
<Td style="background-color:#FFFFFF;text-align:center;color:#000000;font-family:'ＭＳ Ｐゴシック';font-size:11pt;">○</td>
</tr>
</table>

<div style="font-size: small">
  <span style="color: red;">*1</span>　Need to run when making NuGet package.<br />
  <span style="color: red;">*2</span>　Need to run when developing rich client application.<br />
  <span style="color: red;">*3</span>　Need to run when developing application that targets .NET Standard or .NET Core.<br />
  <span style="color: red;">*4</span>　Select according to the actual architecture.
</div>

- If necessary, revise the environment variable *BUILDFILEPATH* in z_Common.bat according to the build environment.

- The libraries which are used by Open Touryo Template Base for Visual Studio 2015 are downloaded by NuGet. NuGet libraries might not be downloaded normally under proxy environment. So, when using proxy environment, create environment variable *http_proxy* as follows:
    - Open *C:\root\programs\CS\z_Common.bat* and *C:\root\programs\VB\z_Common.bat* in an editor.
    - By default, the code which creates environment variable *http_proxy* is commented.  
    So, uncomment this code by removing '@rem'.
    - Set your proxy information in environment variable *http_proxy*.

- When the following error occurred at build time, install *Windows SDK for Windows 8*. (Refer to [issue of Open Touryo](https://github.com/OpenTouryoProject/OpenTouryoTemplates/issues/48#issuecomment-241349223).)
```
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\Microsoft.Common.targets(2863,5): error MSB3086: Task could not find "AL.exe" using the SdkToolsPath "" or the registry key "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SDKs\Windows\v8.0A\WinSDK-NetFx40Tools-x86". Make sure the SdkToolsPath is set and the tool exists in the correct processor specific location under the SdkToolsPath and that the Microsoft Windows SDK is installed
```
  
### Start ASP.NET state service
Open a command prompt as an administrator and execute the following commands.
```bat
   sc config aspnet_state start= auto
   net start aspnet_state
```

### Run the sample application
Open the following file.
- Open web.config or app.config (for .NET Core, appsettings.json) and revise the values in *connectionStrings* section according to the actual database environment.
- Run the sample application.  
At the login screen, enter the arbitrary alphanumeric characters. (By default, the password authentication is not executed.)
   
#### Web application:
- ASP.NET Web Forms  
  - C:\root\programs\CS\Samples\WebApp_sample\WebForms_Sample\WebForms_Sample.sln
  - C:\root\programs\VB\Samples\WebApp_sample\WebForms_Sample\WebForms_Sample.sln
- ASP.NET MVC  
  - C:\root\programs\CS\Samples\WebApp_sample\MVC_Sample\MVC_Sample.sln
  - C:\root\programs\VB\Samples\WebApp_sample\MVC_Sample\MVC_Sample.sln
- ASP.NET Core MVC  
  - C:\root\programs\CS\Samples4NetCore\WebApp_sample\MVC_Sample\MVC_Sample.sln

#### Two-tier client server application:
- Windows Forms  
  - C:\root\programs\CS\Samples\2CS_sample\2CSClientWin_sample\2CSClientWin_sample.sln
  - C:\root\programs\VB\Samples\2CS_sample\2CSClientWin_sample\2CSClientWin_sample.sln
- WPF  
  - C:\root\programs\CS\Samples\2CS_sample\2CSClientWPF_sample\2CSClientWPF_sample.sln
  - C:\root\programs\VB\Samples\2CS_sample\2CSClientWPF_sample\2CSClientWPF_sample.sln

#### Three-tier client server application:
- Windows Forms  
  - Windows forms application
    - C:\root\programs\CS\Samples\WS_sample\WSClient_sample\WSClientWin_sample\WSClientWin_sample.sln
    - C:\root\programs\VB\Samples\WS_sample\WSClient_sample\WSClientWin_sample\WSClientWin_sample.sln
  - ClickOnce application  
C:\root\programs\CS\Samples\WS_sample\WSClient_sample\WSClientWinCone_sample\WSClientWinCone_sample.sln
- WPF
  - C:\root\programs\CS\Samples\WS_sample\WSClient_sample\WSClientWPF_sample\WSClientWPF_sample.sln
  - C:\root\programs\VB\Samples\WS_sample\WSClient_sample\WSClientWPF_sample\WSClientWPF_sample.sln

## Other items of note

### Copyright and license
Refer to [License](https://github.com/OpenTouryoProject/OpenTouryo/tree/master/license) directory.

### Bug fix
If you find the bug while you are using Open Touryo, create an new [issue](https://github.com/OpenTouryoProject/OpenTouryo/issues).  
Open Touryo community confirms the issue and takes appropriate actions.  

### How to create NuGet packages
For the method of creating Open Touryo NuGet packages, see [this article](https://github.com/OpenTouryoProject/OpenTouryo/wiki/HowToCreateOpenTouryoNuGetPackages).

### Obtaining libraries, exporting control prodedures, attaching to license
- The libraries that can be obtained from package manager, that is NuGet or npm, are not bundled in Open Touryo. So, you don't have to export the libraries.
- If necessary, you have to obtain and export the other libraries, that is the libraries that can not be obtained from package manager, on your own. In this case, you have to attach the license of the libraries to be used to the license of Open Touryo.

### Reference
The documents in *OpenTouryoDocument repository* are useful when using Open Touryo.  
- [Introduction](https://github.com/OpenTouryoProject/OpenTouryoDocuments/tree/master/documents/0_Introduction)  
You can see the introduction materials, such as PowerPoint slides.
- [User Guide](https://github.com/OpenTouryoProject/OpenTouryoDocuments/tree/master/documents/1_User_Guide)  
You can confirm the structure of Open Touryo and the specification of each feature.
- [Tutorial](https://github.com/OpenTouryoProject/OpenTouryoDocuments/tree/master/documents/2_Tutorial)  
You can see the *first step guide* of Open Touryo.
