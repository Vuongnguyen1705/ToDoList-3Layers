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
VALUES(N'Admin'),
	(N'Quản Lý'),
	(N'Nhân viên');

GO 
--Dữ liệu nhân viên
INSERT INTO dbo.Users VALUES 
('/Images/icon-user-default.png', N'Admin', '0785715880', N'admin@gmail.com', 'GU8NJHAqP3c=', N'Q8, TPHCM', '1990-01-04', N'Nam', 1, 1),
('/Images/icon-user-default.png', N'Nguyễn Hùng Vương', '0785715880', N'vuong@gmail.com', 'CVJuIRIHoFQ=', N'Q6, TPHCM', '1999-01-01', N'Nam', 1, 2),
('/Images/icon-user-default.png', N'Tsan Xướng Vấy', '0785715880', N'vay@gmail.com',  'CVJuIRIHoFQ=',  N'Q6, TPHCM', '1999-01-01', N'Nam',1, 2 ),
('/Images/icon-user-default.png', N'Huỳnh Ngọc Trung', '0785715880', N'trunghn@gmail.com',  'CVJuIRIHoFQ=',  N'Q Tân Phú, TPHCM', '1999-06-05', N'Nam',1, 2 ),
('/Images/icon-user-default.png', N'Ngô Chí Trung', '0785715880', N'trungnc@gmail.com',  'CVJuIRIHoFQ=',  N'Q10, TPHCM', '1999-04-03', N'Nam',1, 2 ),
('/Images/icon-user-default.png', N'Hà Thiện Tuấn', '0785715880', N'tuan@gmail.com',  'CVJuIRIHoFQ=',  N'Q6, TPHCM', '1999-01-06', N'Nam',1, 2 ),
('/Images/icon-user-default.png', N'Nhân viên 1', '0785715880', N'nv1@gmail.com',  'CVJuIRIHoFQ=',  N'Q6, TPHCM', '1999-05-01', N'Nam',1, 3),
('/Images/icon-user-default.png', N'Nhân viên 2', '0785715880', N'nv2@gmail.com',  'CVJuIRIHoFQ=',  N'Q6, TPHCM', '1997-01-01', N'Nam',1, 3),
('/Images/icon-user-default.png',  N'Nhân viên 3',	'0785715880',	N'nv3@gmail.com',	'CVJuIRIHoFQ=',	N'Q6, TPHCM','1999-01-01',N'Nữ',1,3);

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
    '6,8',					  -- W_CoWorker - varchar(50)
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
    '6,7',					  -- W_CoWorker - varchar(50)
    '',					  -- W_Attachments - nvarchar(255)
    8					  -- W_User_ID - int
)

Select * from [Works]