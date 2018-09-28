create table [dbo].[ProductCharacteristics]
(
	[Id] bigint not null identity,
	[Key] nvarchar(20) not null,
	[Value] nvarchar(30) not null,
	[ProductId] bigint not null,
	constraint [PK_ProductCharacteristics] primary key ([Id]),
	constraint [FK_ProductCharacteristics_ProductId] foreign key ([ProductId]) references [dbo].[Products]([Id])
);