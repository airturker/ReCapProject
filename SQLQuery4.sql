CREATE TABLE CarImages(
Id int primary key identity(1,1),
CarId int,
ImagePath nvarchar(37),
Date datetime,
foreign key(CarId) References Cars(CarId),
)

alter table CarImages
alter column Date datetime2;