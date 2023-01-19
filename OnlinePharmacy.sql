use OnlinePharmacy
create table Medicine(
medID int identity(1,1) primary key not null,
medCode nvarchar(100) not null,
medName nvarchar(100) not null,
medPrice int not null,
medStock int not null,
medExpDate date not null,
categoryId int not null,
constraint fk_CategoryID foreign key (categoryId) references Category (categoryId)
)
create table Category(
categoryId int primary key identity (100,1),
CategoryName nvarchar(100) not null
)
create table Seller(
sellerId int primary key,
sellerName nvarchar(100) not null,
sellerEmail nvarchar(100) not null,
sellerPas nvarchar(100) not null,
sellerDOB date not null,
sellerGender nvarchar(10) not null,
sellerAddress nvarchar(200) not null,
)
create table Billing(
billId int primary key identity,
billDate date not null,
sellerId int not null,
Amount int not null,
constraint fk_SellerID foreign key (sellerId) references Seller (sellerId)
)

select * from Medicine

insert into Seller values ()

select * from Seller 

update Medicine set medCode=@medCode,medName=@medName,medPrice=@medPrice,medStock=@medStock,medExpDate=@medExpDater,categoryId=@categoryId where medCode = @medCode

medCode nvarchar(100) primary key not null,
medName nvarchar(100) not null,
medPrice int not null,
medStock int not null,
medExpDate date not null,
categoryId int not null,