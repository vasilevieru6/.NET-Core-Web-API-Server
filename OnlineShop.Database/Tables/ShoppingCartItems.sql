create table [dbo].[ShoppingCartItems]
(
	[Id] bigint not null identity,
	[ProductId] bigint not null,
	[ShoppingCartId] bigint not null,
	constraint [PK_ShoppingCartItems] primary key ([Id],[ProductId],[ShoppingCartId]),
	constraint [FK_ShoppingCartItems_ProductId] foreign key	([ProductId]) references [dbo].[Products]([Id]),
	constraint [FK_ShoppingCartItems_ShoppingCartId] foreign key ([ShoppingCartId]) references [dbo].[ShoppingCarts]([Id])
);