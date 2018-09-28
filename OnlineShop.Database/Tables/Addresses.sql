create table [dbo].[Addresses]
(
	[Id] bigint not null identity,
	[Country] nvarchar(50),
	[City] nvarchar(50) not null,
	[Street] nvarchar(50) not null,
	[PostalCode] nvarchar(15),
	[UserId] bigint not null,
	constraint [PK_Addresses] primary key ([Id]),
	constraint [FK_Addresses_UserId] foreign key ([UserId]) references [dbo].[Users]([Id]) on delete cascade
);