Create Table CarImages(
	CarImageId int PRIMARY KEY IDENTITY(1,1),
	CarId int,
	ImagePath nvarchar(MAX),
	CarImageDate datetime,
	FOREIGN KEY (CarId) REFERENCES Cars(CarId)
)