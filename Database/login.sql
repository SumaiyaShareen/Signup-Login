CREATE DATABASE LOGINSYSTEM

USE LOGINSYSTEM;

CREATE TABLE UserDetail (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NULL,
    Email NVARCHAR(100) NULL UNIQUE,
    PhoneNumber NVARCHAR(15) NULL,
    DateOfBirth DATETIME NULL,
    Address NVARCHAR(255) NULL,
    ProfilePicture NVARCHAR(255) NULL
);
ALTER TABLE UserDetail DROP COLUMN ProfilePicture;

ALTER TABLE UserDetail
ADD ProfilePicture VARBINARY(MAX) NULL;

INSERT INTO UserDetail (
    FullName,
    Email,
    PhoneNumber,
    DateOfBirth,
    Address,
    ProfilePicture
)
VALUES (
    'Ali Khan',
    'ali.khan@example.com',
    '03001234567',
    '1990-05-15 00:00:00',
    'Lahore, Pakistan',
    'profile_ali.jpg'
);

CREATE TABLE UserLogin (
    LoginId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Email NVARCHAR(100) NULL UNIQUE,
    PasswordHash NVARCHAR(255) NULL,
    FOREIGN KEY (UserId) REFERENCES UserDetail(UserId) ON DELETE CASCADE
);

SELECT * from UserDetail;
Delete from UserDetail;
select * from UserLogin;