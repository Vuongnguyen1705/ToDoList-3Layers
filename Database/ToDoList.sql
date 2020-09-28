USE master
GO 
if exists(select name from sysdatabases where name='TodoList')
	drop Database ToDoList
GO 
CREATE DATABASE ToDoList
GO 
USE ToDoList

GO 
CREATE TABLE Users(
	U_ID INT NOT NULL PRIMARY KEY IDENTITY,
	U_Avatar VARCHAR(255) NOT NULL, 
	U_FullName NVARCHAR(50) NOT NULL,
	U_Phone VARCHAR(11) NOT NULL,
	U_Email NVARCHAR(50) NOT NULL,
	U_Password VARCHAR(30) NOT NULL,
	U_Address NVARCHAR(100),
	U_Birthday DATE,
	U_Gender NCHAR(5),
	U_IsEnable bit NOT NULL,
	U_Role_ID INT 
);

CREATE TABLE Role(
	R_ID INT NOT NULL PRIMARY KEY IDENTITY,
	R_Name NVARCHAR(10) NOT NULL
);

CREATE TABLE Works(
	W_ID INT NOT NULL PRIMARY KEY IDENTITY,
	W_Title NVARCHAR(255) NOT NULL,
	W_StartDate DATETIME,
	W_EndDate DATETIME,
	W_State NCHAR(20) NOT NULL,
	W_Range NCHAR(20) NOT NULL,
	W_CoWorker VARCHAR(50),
	W_Attachments NVARCHAR(255),
	W_User_ID int
);

GO
CREATE TABLE Comments(
	CMT_ID INT NOT NULL PRIMARY KEY IDENTITY,
	CMT_User_ID INT NOT NULL,
	CMT_Work_ID INT NOT NULL,
	CMT_Content NVARCHAR(1000) NOT NULL
);

GO 
ALTER TABLE dbo.Users ADD CONSTRAINT FK_User_Role_ID FOREIGN KEY(U_Role_ID) REFERENCES dbo.Role(R_ID);
ALTER TABLE dbo.Works ADD CONSTRAINT FK_Work_User_ID FOREIGN KEY(W_User_ID) REFERENCES dbo.Users(U_ID);
ALTER TABLE dbo.Comments ADD CONSTRAINT FK_User_ID FOREIGN KEY(CMT_User_ID) REFERENCES dbo.Users(U_ID);
ALTER TABLE dbo.Comments ADD CONSTRAINT FK_Work_ID FOREIGN KEY(CMT_Work_ID) REFERENCES dbo.Works(W_ID);


GO 
--Dữ liệu role
INSERT INTO dbo.Role(R_Name) 
VALUES(N'Admin' -- R_Name - nvarchar(10)
)

INSERT INTO dbo.Role(R_Name) 
VALUES(N'Quản Lý' -- R_Name - nvarchar(10)
)

INSERT INTO dbo.Role(R_Name) 
VALUES(N'Nhân viên' -- R_Name - nvarchar(10)
)


GO 
--Dữ liệu nhân viên
INSERT INTO dbo.Users(U_Avatar, U_FullName, U_Phone, U_Email, U_Password, U_Address, U_Birthday, U_Gender, U_IsEnable, U_Role_ID)
VALUES
(	'/Images/icon-user-default.png',        -- U_Avartar - varchar(255)
	N'Nguyễn Hùng Vương',       			-- U_FullName - nvarchar(50)
    '0785715880',      						-- U_Phone - varchar(11)
    N'vuong@gmail.com',       				-- U_Email - nvarchar(50)
	'vuongnh',       						-- U_Password - varchar(30)
    N'Q6, TPHCM',       					-- U_Address - nvarchar(100)
    '1999-01-01', 							-- U_Birthday - date
    N'Nam',       							-- U_Gender - nchar(5)
    1,       								-- U_IsEnable - bit
    2          								-- U_ID_Role - int
)

INSERT INTO dbo.Users(U_Avatar, U_FullName, U_Phone, U_Email, U_Password, U_Address, U_Birthday, U_Gender, U_IsEnable, U_Role_ID)
VALUES
(	'/Images/icon-user-default.png',        -- U_Avartar - varchar(255)
	N'Tsan Xướng Vấy',       				-- U_FullName - nvarchar(50)
    '0785715880',      						-- U_Phone - varchar(11)
    N'vay@gmail.com',       				-- U_Email - nvarchar(50)
	'vaytx',       							-- U_Password - varchar(30)
    N'Q6, TPHCM',       					-- U_Address - nvarchar(100)
    '1999-01-01', 							-- U_Birthday - date
    N'Nam',       							-- U_Gender - nchar(5)
    1,       								-- U_IsEnable - bit
    2          								-- U_ID_Role - int
)

INSERT INTO dbo.Users(U_Avatar, U_FullName, U_Phone, U_Email, U_Password, U_Address, U_Birthday, U_Gender, U_IsEnable, U_Role_ID)
VALUES
(	'/Images/icon-user-default.png',        -- U_Avartar - varchar(255)
	N'Huỳnh Ngọc Trung',       				-- U_FullName - nvarchar(50)
    '0785715880',      						-- U_Phone - varchar(11)
    N'trunghn@gmail.com',       			-- U_Email - nvarchar(50)
	'trunghn',       						-- U_Password - varchar(30)
    N'Q6, TPHCM',       					-- U_Address - nvarchar(100)
    '1999-01-01', 							-- U_Birthday - date
    N'Nam',       							-- U_Gender - nchar(5)
    1,       								-- U_IsEnable - bit
    2										-- U_ID_Role - int
)

INSERT INTO dbo.Users(U_Avatar, U_FullName, U_Phone, U_Email, U_Password, U_Address, U_Birthday, U_Gender, U_IsEnable, U_Role_ID)
VALUES
(	'/Images/icon-user-default.png',        -- U_Avartar - varchar(255)
	N'Ngô Chí Trung',       				-- U_FullName - nvarchar(50)
    '0785715880',      						-- U_Phone - varchar(11)
    N'trungnc@gmail.com',       			-- U_Email - nvarchar(50)
	'trungnc',       						-- U_Password - varchar(30)
    N'Q6, TPHCM',       					-- U_Address - nvarchar(100)
    '1999-01-01', 							-- U_Birthday - date
    N'Nam',       							-- U_Gender - nchar(5)
    1,       								-- U_IsEnable - bit
    2          								-- U_ID_Role - int
)

INSERT INTO dbo.Users(U_Avatar, U_FullName, U_Phone, U_Email, U_Password, U_Address, U_Birthday, U_Gender, U_IsEnable, U_Role_ID)
VALUES
(	'/Images/icon-user-default.png',        -- U_Avartar - varchar(255)
	N'Hà Thiện Tuấn',						-- U_FullName - nvarchar(50)
    '0785715880',      						-- U_Phone - varchar(11)
    N'tuan@gmail.com',       				-- U_Email - nvarchar(50)
	'tuanht',       						-- U_Password - varchar(30)
    N'Q6, TPHCM',       					-- U_Address - nvarchar(100)
    '1999-01-01', 							-- U_Birthday - date
    N'Nam',       							-- U_Gender - nchar(5)
    1,       								-- U_IsEnable - bit
    2          								-- U_ID_Role - int
)

INSERT INTO dbo.Users(U_Avatar, U_FullName, U_Phone, U_Email, U_Password, U_Address, U_Birthday, U_Gender, U_IsEnable, U_Role_ID)
VALUES
(	'/Images/icon-user-default.png',        -- U_Avartar - varchar(255)
	N'Nhân viên 1',       					-- U_FullName - nvarchar(50)
    '0785715880',      						-- U_Phone - varchar(11)
    N'nv1@gmail.com',       				-- U_Email - nvarchar(50)
	'nhanvien1',       						-- U_Password - varchar(30)
    N'Q6, TPHCM',       					-- U_Address - nvarchar(100)
    '1999-01-01', 							-- U_Birthday - date
    N'Nam',       							-- U_Gender - nchar(5)
    1,       								-- U_IsEnable - bit
    3          								-- U_ID_Role - int
)

INSERT INTO dbo.Users(U_Avatar, U_FullName, U_Phone, U_Email, U_Password, U_Address, U_Birthday, U_Gender, U_IsEnable, U_Role_ID)
VALUES
(	'/Images/icon-user-default.png',        -- U_Avartar - varchar(255)
	N'Nhân viên 2',							-- U_FullName - nvarchar(50)
    '0785715880',      						-- U_Phone - varchar(11)
    N'nv2@gmail.com',       				-- U_Email - nvarchar(50)
	'nhanvien2',       						-- U_Password - varchar(30)
    N'Q6, TPHCM',       					-- U_Address - nvarchar(100)
    '1999-01-01', 							-- U_Birthday - date
    N'Khác',       							-- U_Gender - nchar(5)
    1,       								-- U_IsEnable - bit
    3          								-- U_ID_Role - int
)

INSERT INTO dbo.Users(U_Avatar, U_FullName, U_Phone, U_Email, U_Password, U_Address, U_Birthday, U_Gender, U_IsEnable, U_Role_ID)
VALUES
(	'/Images/icon-user-default.png',        -- U_Avartar - varchar(255)
	N'Nhân viên 3',							-- U_FullName - nvarchar(50)
    '0785715880',							-- U_Phone - varchar(11)
    N'nv3@gmail.com',						-- U_Email - nvarchar(50)
	'nhanvien3',							-- U_Password - varchar(30)
    N'Q6, TPHCM',							-- U_Address - nvarchar(100)
    '1999-01-01',							-- U_Birthday - date
    N'Nữ',									-- U_Gender - nchar(5)
    1,										-- U_IsEnable - bit
    3										-- U_ID_Role - int
)

GO 
--Dữ liệu công việc

INSERT INTO dbo.Works(W_Title, W_StartDate, W_EndDate, W_State, W_Range, W_CoWorker, W_Attachments, W_User_ID)
VALUES
(   N'Công việc 1',       -- W_Title - nvarchar(255)
    '2020-09-20',		  -- W_StartDate - datetime
    '2020-10-20',		  -- W_EndDate - datetime
    N'Đang làm',		  -- W_State - nchar(20)
    N'Public',			  -- W_Range - nchar(20)
    '',					  -- W_CoWorker - varchar(50)
    '',					  -- W_Attachments - nvarchar(255)
    6					  -- W_User_ID - int
)

INSERT INTO dbo.Works(W_Title, W_StartDate, W_EndDate, W_State, W_Range, W_CoWorker, W_Attachments, W_User_ID)
VALUES
(   N'Công việc 2',       -- W_Title - nvarchar(255)
    '2020-09-20',		  -- W_StartDate - datetime
    '2020-09-20',		  -- W_EndDate - datetime
    N'Đã xong',			  -- W_State - nchar(20)
    N'Public',			  -- W_Range - nchar(20)
    '',					  -- W_CoWorker - varchar(50)
    '',					  -- W_Attachments - nvarchar(255)
    7					  -- W_User_ID - int
)

INSERT INTO dbo.Works(W_Title, W_StartDate, W_EndDate, W_State, W_Range, W_CoWorker, W_Attachments, W_User_ID)
VALUES
(   N'Công việc 3',       -- W_Title - nvarchar(255)
    '2020-09-20',		  -- W_StartDate - datetime
    '2020-09-20',		  -- W_EndDate - datetime
    N'Trễ hạn',			  -- W_State - nchar(20)
    N'Private',			  -- W_Range - nchar(20)
    '',					  -- W_CoWorker - varchar(50)
    '',					  -- W_Attachments - nvarchar(255)
    8					  -- W_User_ID - int
)

