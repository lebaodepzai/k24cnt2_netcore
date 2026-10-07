-- =============================================
-- Lesson 10: EF Database First
-- Sinh viên: Lê Gia Bảo - MSSV: 2410900009
-- CSDL: Lgb2410900009Lesson10EFDb (SQL Server LocalDB)
-- =============================================

-- 1. Tạo cơ sở dữ liệu
IF DB_ID('Lgb2410900009Lesson10EFDb') IS NULL
    CREATE DATABASE Lgb2410900009Lesson10EFDb;
GO
USE Lgb2410900009Lesson10EFDb;
GO

-- 2. Tạo bảng LgbMember
IF OBJECT_ID('dbo.LgbMember', 'U') IS NOT NULL
    DROP TABLE dbo.LgbMember;
GO
CREATE TABLE dbo.LgbMember (
    Id           BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    LgbUserName  VARCHAR(20)  NULL,
    LgbPassword  VARCHAR(50)  NULL,
    LgbFullName  NVARCHAR(50) NULL,
    LgbEmail     VARCHAR(50)  NULL,
    LgbPhone     VARCHAR(12)  NULL,
    LgbStatus    BIT          NULL
);
GO

-- 3. Chèn dữ liệu mẫu
INSERT INTO dbo.LgbMember (LgbUserName, LgbPassword, LgbFullName, LgbEmail, LgbPhone, LgbStatus) VALUES
('lgb2410900009', '123456', N'Lê Gia Bảo', 'lgb2410900009@student.edu.vn', '0912345678', 1),
('admin', 'admin', N'Quản trị viên', 'admin@k24cntt2.edu.vn', '0987654321', 1),
('nguyenvanan', '123456', N'Nguyễn Văn An', 'nguyenvanan@gmail.com', '0933445566', 0);
GO

-- 4. Truy vấn kiểm tra
SELECT * FROM dbo.LgbMember;
GO
