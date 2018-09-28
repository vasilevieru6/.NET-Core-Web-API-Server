create table [dbo].[Products]
(	
	[Id] bigint not null identity,
	[Name] nvarchar(50) not null,
	[UnitPrice] int check ([UnitPrice] > 0), 
	[Description] nvarchar(3000),
	[PhotoUrl] nvarchar(100) not null,
	[Category] nvarchar(30) not null,
	[Subcategory] nvarchar(50) not null,
    constraint [PK_Products] primary key ([Id]) 
);