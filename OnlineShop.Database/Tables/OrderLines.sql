create table [dbo].[OrderLines]
(
	[Id] bigint not null identity,
	[Price] int,
	[Quantity] int,
	[ProductId] bigint not null,
	[OrderId] bigint not null,
	constraint [PK_OrderLines] primary key ([Id],[ProductId]),
	constraint [FK_OrderLines_ProductId] foreign key ([ProductId]) references [dbo].[Products]([Id]) on delete cascade, 
	constraint [FK_OrderLines_OrderId] foreign key ([OrderId]) references [dbo].[Orders]([Id]) on delete cascade
);