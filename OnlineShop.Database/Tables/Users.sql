create table [dbo].[Users]
(
	[Id] BIGINT not null identity,
	[FirstName] nvarchar(30) not null,
	[LastName] nvarchar(30) not null,
	[Phone] char(9),
	[Email] nvarchar(30) not null,
	[Username] nvarchar(30) not null,
	[Password] nvarchar(30) not null,
	[Role] nvarchar(50) null,
	constraint [PK_Users] primary key ([Id])
);