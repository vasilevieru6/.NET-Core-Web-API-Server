create table [dbo].[ShoppingCarts]
(
	[Id] bigint not null identity,
	[CreatedDate] datetime not null,
	[UserId] bigint not null,
	constraint [PK_ShoppingCarts] primary key ([Id]),
	constraint [FK_ShoppingCarts_UserId] foreign key ([UserId]) references [dbo].[Users]([Id]) on delete cascade 
);