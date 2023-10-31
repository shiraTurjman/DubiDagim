
create table City(
cityId int identity not null,
constraint pk_city primary key (cityId),
cityName varchar(50) not null
)

create table Users(
userId int identity not null,
constraint pk_user primary key (userId),
userName varchar(50) not null,
email varchar(255) not null,
password varchar(10) not null,
cityId int not null,
constraint fk_user_city foreign key (cityId) references City(cityId),
address varchar(50) not null,
phone varchar(10) not null
)

create table Category(
categoryId int identity not null,
constraint pk_category primary key (categoryId),
categoryName varchar(50) not null,
icon varchar not null
)

create table Item(
itemId int identity not null,
constraint pk_item primary key (itemId),
itemName varchar(50) not null,
price float not null,
categoryId int not null,
constraint fk_item_category foreign key (categoryId) references Category (categoryId),
details varchar(1000) null,
averageSize float not null
)

create table ImageDetails
( imgId int identity not null,
 constraint pk_imagedetaild primary key (imgId),
 itemId int not null,
 constraint fk_image_item foreign key (itemId) references Item (itemId),
 fileName nvarchar(100) not null,
 fileData varbinary(max) not null
)

create table Sale(
saleId int identity not null,
constraint pk_sale primary key (saleId),
itemId int not null,
constraint fk_sale_item foreign key (itemId) references Item (itemId),
amount int not null,
newPrice float not null,
percents float not null,
details varchar(1000) null,
)

create table SameItem(
sameItemId int identity not null primary key,
itemAId int not null,
constraint fk_same_itemA foreign key (itemAId) references Item (itemId),
itemBId int not null,
constraint fk_same_itemB foreign key (itemBId) references Item (itemId),
)

create table CuttingShape(
cuttingShapeId int identity not null primary key,
shapeName varchar(50) not null,
details varchar(1000) not null
)

create table CuttingShapePerItem(
cuttingShapePerItemId int identity not null primary key,
cuttingShapeId int not null ,
constraint fk_CuttingShapePerItem_CuttingShape foreign key (cuttingShapeId) references CuttingShape(cuttingShapeId),
itemId int not null,
constraint fk_CuttingShapePerItem_item foreign key (itemId) references Item (itemId)
)

create table Orders(
orderId int identity(2,1) not null primary key,
userId int not null,
constraint fk_order_user foreign key (userId)  references Users(userId),
OrderDate date not null default getdate()
)

create table ShoppingCart(
shoppingCartId int identity not null primary key,
userId int not null,
constraint fk_ShoppingCart_user foreign key (userId) references Users(userId),
itemId int not null,
constraint fk_ShoppingCart_item foreign key (itemId) references Item(itemId),
amount int not null,
cuttingShapeId int not null,
constraint fk_ShoppingCart_cuttingShape foreign key (cuttingShapeId) references CuttingShape(cuttingShapeId),
details varchar(1000) not null,
orderId int not null default 1,
constraint fk_shoppingcart_order foreign key (orderId) references Orders(orderId)
)

