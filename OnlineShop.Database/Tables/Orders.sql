create table [dbo].[Orders]
(
	[Id] bigint not null identity,
	[Number] nvarchar(20) not null,
	[OrderDate] datetime not null,
	[TotalAmount] int,
	[Description] nvarchar(1000) null,
	[Status] nvarchar(10) not null,
	[UserId] bigint not null,
	constraint [PK_Orders] primary key ([Id]),
	constraint [FK_Orders_UserId] foreign key ([UserId]) references	[dbo].[Users]([Id]) on delete cascade 
);