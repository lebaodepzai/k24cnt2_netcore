-- ============================================================================
-- CƠ SỞ DỮ LIỆU VÀ CẤU TRÚC BẢNG DÀNH CHO MYSQL / MYSQL WORKBENCH / PHPMYADMIN
-- Sinh viên thực hiện: Lê Gia Bảo (lgb)
-- Mã sinh viên: 2410900009
-- File SQL MySQL: LgbEmployee_2410900009_Db_MySQL.sql
-- ============================================================================

-- 1. Tạo Cơ Sở Dữ Liệu
CREATE DATABASE IF NOT EXISTS `Lgb2410900009_Db`
    DEFAULT CHARACTER SET utf8mb4 
    COLLATE utf8mb4_unicode_ci;

USE `Lgb2410900009_Db`;

-- 2. Tạo Bảng LgbEmployee
DROP TABLE IF EXISTS `LgbEmployee`;

CREATE TABLE `LgbEmployee` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `LgbName` VARCHAR(100) NOT NULL,
    `LgbGender` VARCHAR(10) NULL,
    `LgbBirthDay` DATE NULL,
    `LgbEmail` VARCHAR(100) NULL,
    `LgbPhone` VARCHAR(20) NULL,
    `LgbActive` TINYINT(1) NOT NULL DEFAULT 1,
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 3. Tạo Bảng LgbStudent
DROP TABLE IF EXISTS `LgbStudent`;

CREATE TABLE `LgbStudent` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `LgbName` VARCHAR(100) NOT NULL,
    `LgbGender` VARCHAR(10) NULL,
    `LgbBirthDay` DATE NULL,
    `LgbEmail` VARCHAR(100) NULL,
    `LgbPhone` VARCHAR(20) NULL,
    `LgbAddress` VARCHAR(200) NULL,
    `LgbActive` TINYINT(1) NOT NULL DEFAULT 1,
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 4. Chèn Dữ Liệu Mẫu Cho Bảng LgbEmployee
INSERT INTO `LgbEmployee` (`LgbName`, `LgbGender`, `LgbBirthDay`, `LgbEmail`, `LgbPhone`, `LgbActive`) VALUES
('Lê Gia Bảo', 'Nam', '2004-05-15', 'lebaogiang@gmail.com', '0912345678', 1),
('Nguyễn Thị Bảo', 'Nữ', '2004-08-20', 'nguyenthibao@gmail.com', '0987654321', 1),
('Trần Văn An', 'Nam', '2003-12-10', 'tranvanan@gmail.com', '0933445566', 0),
('Phạm Minh Cường', 'Nam', '2004-02-28', 'phamminhcuong@gmail.com', '0977889900', 1);

-- 5. Chèn Dữ Liệu Mẫu Cho Bảng LgbStudent
INSERT INTO `LgbStudent` (`LgbName`, `LgbGender`, `LgbBirthDay`, `LgbEmail`, `LgbPhone`, `LgbAddress`, `LgbActive`) VALUES
('Lê Bảo Giang', 'Nam', '2004-05-15', 'lgb2410900009@student.edu.vn', '0912345678', 'Hà Nội', 1),
('Nguyễn Văn Bình', 'Nam', '2004-09-12', 'nguyenvanbinh@gmail.com', '0981112233', 'Hải Phòng', 1),
('Hoàng Thảo My', 'Nữ', '2004-11-05', 'hoangthaomy@gmail.com', '0965554433', 'Nam Định', 1),
('Vũ Đức Anh', 'Nam', '2003-07-22', 'vuducanh@gmail.com', '0944332211', 'Bắc Ninh', 0);

-- 6. Truy Vấn Kiểm Tra Dữ Liệu
SELECT * FROM `LgbEmployee`;
SELECT * FROM `LgbStudent`;
