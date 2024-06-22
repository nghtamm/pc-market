# 💻 Phần mềm quản lý chuỗi cửa hàng máy tính PC Market
Bài tập lớn: Lập trình .NET (Học kì 2 - Năm 3 - Học viện Ngân hàng)

## Mục lục
* [Thông tin cơ bản](#thông-tin-cơ-bản)
* [Techstack](#techstack)
* [Yêu cầu](#yêu-cầu)
* [Hướng dẫn sử dụng](#hướng-dẫn-sử-dụng)

## Thông tin cơ bản
Phần mềm quản lý cửa hàng máy tính PC Market với các tính năng chính
- Quản lý thông tin sản phẩm và các danh mục sản phẩm
- Quản lý thông tin nhân viên cửa hàng
- Quản lý thông tin khách hàng
- Quản lý thông tin nhà cung cấp
- Tạo và xuất hóa đơn nhập hàng/ hóa đơn bán hàng (dưới định dạng Excel *.xlsx*)
- Quản lý và tìm kiếm thông tin hóa đơn (nhập hàng/ xuất hàng)
- Tạo báo cáo doanh thu theo ngày cụ thể hoặc theo khoảng thời gian

**Lưu ý**
- Dữ liệu được lưu trên local, import thông qua file *.sql*

**Nhóm tác giả**
- [Nguyễn Hoàng Tâm](https://github.com/nghtamm2003)
- [Nguyễn Huy Phước](https://github.com/DurkYerunz)
- [Bùi Tú Phương](https://github.com/phuong11032002)
- Trần Tiến Thịnh
- Nguyễn Thị Vóc
	
## Techstack
- Ngôn ngữ lập trình C#
- Windows Forms .NET (hay còn gọi là WinForms)
- Docker
- Microsoft SQL Server
	
## Yêu cầu
- Cài đặt [.NET Framework (4.8.1) + .NET Core (8.0)](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)
- Cài đặt [Visual Studio](https://visualstudio.microsoft.com/), [JetBrains Rider](https://www.jetbrains.com/rider/) hoặc bất cứ IDE C# nào khác

## Hướng dẫn sử dụng
### Đối với Microsoft SQL Server được cài đặt trên local
Sử dụng [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16#download-ssms), [DBeaver](https://dbeaver.io/download/) hoặc bất cứ DBMS nào khác có hỗ trợ Microsoft SQL Server, mở đường dẫn
```
pc-market/Database
```
Sau đó, mở file query ***pc-market-script.sql*** và chạy để khởi tạo database
### Đối với Docker
- Cài đặt [Docker Desktop](https://docs.docker.com/desktop/install/windows-install/)
- Mở terminal và tiến hành pull image Microsoft SQL Server
```
docker pull mcr.microsoft.com/mssql/server
```
- Khởi tạo container và cài đặt Microsoft SQL Server
```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name sqlpreview --hostname sqlpreview -d mcr.microsoft.com/mssql/server:latest
```
### Khởi chạy ứng dụng
Khởi chạy solution ***pc-market.sln*** tại đường dẫn trong thư mục gốc của project
```
cd pc-market
```
Trước tiên, khởi tạo một compiler với các thiết đặt
- Windows Application Forms (WinForms App)
- .NET Framework 4.8.1
- .NET Core 8.0

Sau đó, compile file ***Program.cs*** và sử dụng phần mềm