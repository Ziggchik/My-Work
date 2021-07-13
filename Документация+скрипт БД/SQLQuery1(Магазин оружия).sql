--drop database [Weapon_Store]
--go

set ansi_padding on
go
set quoted_identifier on
go
set ansi_nulls on
go

create database [Weapon_Store]
go
use [Weapon_Store]
go

create table [dbo].[Authorization]
(
	[ID_Authorization] [int] not null identity(1,1),
	[Login] [varchar] (30) not null,
	[Password] [varchar] (30) not null,
	[ID_Role][int] not null 
	constraint [PK_Authorization] primary key clustered ([ID_Authorization] ASC) on [PRIMARY],
	constraint [UQ_Login] unique ([Login]),
	constraint [CH_Password_Number] check ([Password] like '%[0-9]%'),
	constraint [CH_Password_Latter] check ([Password] like '%[A-Z]%'),
	constraint [CH_Password_Symbole] check ([Password] like '%[!@#$%^&*()_+=]%'),
	constraint [CH_Login] check (len([Login]) >= 8),
	constraint [CH_Password] check (len([Password]) >= 8)
)
go

create procedure [dbo].[Authorization_select]                                             
as
   select * from [dbo].[Authorization] 
go

insert into [dbo].[Authorization] ([Login], [Password])
values ('Ivanov_P_S','QwertY_01'),
('Olegova_E_E','QwertY_02'),
('Petrov_O_P','QwertY_03'),
('Mihailova_O_N','QwertY_04'),
('Dmitrov_A_A','QwertY_05'),
('Zaharova_A_R','QwertY_06'),
('Pavlov_E_A','QwertY_07'),
('Egorov_D_K','QwertY_08'),
('Vasinkov_N_A','QwertY_09'),
('Sergeev_A_S','QwertY_10'),
('Rinatova_J_K','QwertY_11'),
('Andreeva_L_A','QwertY_12')
go

create procedure [dbo].[Authorization_update]                                             
@ID_Authorization [int], @Login [varchar] (30), @Password [varchar] (30),@ID_Role[int]
as
   update [dbo].[Authorization] set
   [Login] = @Login,
   [Password] = @Password,
   [ID_Role] = @ID_Role
   where
        [ID_Authorization] = @ID_Authorization
go

create procedure [dbo].[Authorization_insert]
@Login [varchar] (30), @Password [varchar] (30),@ID_Role[int]
as
   insert into [dbo].[Authorization] ([Login], [Password],[ID_Role])
   values (@Login, @Password,@ID_Role)
go

create procedure [dbo].[Authorization_delete]
@ID_Authorization [int]
as
   delete from [dbo].[Authorization]
   where
        [ID_Authorization] = @ID_Authorization
go

create table [dbo].[License]
(
	[ID_License] [int] identity(1,1) not null,
	[License_Number] [varchar] (30) not null,
	constraint [PK_License] primary key clustered ([ID_License] ASC) on [PRIMARY],
)
go 

create procedure [dbo].[License_select]                                             
as
   select * from [dbo].[License] 
go

create procedure [dbo].[License_update]                                             
@ID_License [int], @License_Number [varchar] (30)
as
   update [dbo].[License] set
   [License_Number] = @License_Number
   where
        [ID_License] = @ID_License
go

create procedure [dbo].[License_insert]
@License_Number [varchar] (30)
as
   insert into [dbo].[License] ([License_Number])
   values (@License_Number)
go

create procedure [dbo].[License_delete]
@ID_License [int]
as
   delete from [dbo].[License]
   where
        [ID_License] = @ID_License
go

create table [dbo].[Klient]
(
	[ID_Authorization] [int] not null,
	[First_Name_Klient] [varchar] (30) not null,
	[Name_Klient] [varchar] (30) not null,
	[Middle_Name_Klient] [varchar] (30) null default('No data'),
	[Phone_Number] [varchar] (16) not null,
	[License_ID] [int] not null,
	constraint [FK_Klient] foreign key ([ID_Authorization]) references [dbo].[Authorization] ([ID_Authorization]),
	constraint [PK_Klient] primary key clustered ([ID_Authorization] ASC) on [PRIMARY],
	constraint [UQ_Phone_Number] unique ([Phone_Number]),
	constraint [FK_License_Klient] foreign key ([License_ID]) references [dbo].[License] ([ID_License])
)
go

create procedure [dbo].[Klient_select]                                             
as
   select * from [dbo].[Klient] 
go


insert into [dbo].[Klient] ([First_Name_Klient], [Name_Klient], [Middle_Name_Klient], [Phone_Number],[License_ID],[ID_Authorization])
values ('Иванов','Пётр','Сергеевич','8-999-999-99-99','1'),
('Олегова','Екатерина','Евгеньевна','8-888-888-88-88','2'),
('Петров','Олег','Павлович','8-777-777-77-77','3'),
('Михайлова','Ольга','Николаевна','8-666-666-66-66','4'),
('Дмитров','Андрей','Александрович','8-555-555-55-55','5'),
('Захарова','Анастасия','Руслановна','8-444-444-44-44','6')
go

create procedure [dbo].[Klient_update]                                             
@ID_Authorization [int], @First_Name_Klient [varchar] (30), @Name_Klient [varchar] (30), @Middle_Name_Klient [varchar] (30), @Phone_Number [varchar] (16), @License_ID [int]
as
   update [dbo].[Klient] set
   [First_Name_Klient] = @First_Name_Klient,
   [Name_Klient] = @Name_Klient,
   [Middle_Name_Klient] = @Middle_Name_Klient,
   [Phone_Number] = @Phone_Number,
   [License_ID] = @License_ID
   where
        [ID_Authorization] = @ID_Authorization
go

create procedure [dbo].[Klient_insert]
@ID_Authorization [int], @First_Name_Klient [varchar] (30), @Name_Klient [varchar] (30), @Middle_Name_Klient [varchar] (30), @Phone_Number [char] (19), @License_ID [int]
as
   insert into [dbo].[Klient] ([ID_Authorization],[First_Name_Klient], [Name_Klient], [Middle_Name_Klient], [Phone_Number], [License_ID])
   values (@ID_Authorization, @First_Name_Klient, @Name_Klient, @Middle_Name_Klient, @Phone_Number, @License_ID)
go

create procedure [dbo].[Klient_delete]
@ID_Authorization [int]
as
   delete from [dbo].[Klient]
   where
        [ID_Authorization] = @ID_Authorization
go

create table [dbo].[Issued_License]
(
	[ID_Issued_License] [int] not null identity(1,1),
	[Issued_License_Number] [varchar] (10) not null,
	[Date_of_Issued_License] [varchar] (10) not null,
	[Time_of_Issued_License] [varchar] (8) not null,
	[Klient_ID] [int] not null,
	constraint [PK_Check] primary key clustered 
	([ID_Issued_License] ASC) on [PRIMARY],
	constraint [UQ_Check_Number] unique ([Issued_License_Number]),
	constraint [CH_Check_Number] check ([Issued_License_Number] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	constraint [FK_Klient_Issued_License] foreign key ([Klient_ID])
	references [dbo].[Klient]([ID_Authorization]),
)
go

create table [dbo].[Position]
(
	[ID_Position] [int] identity(1,1) not null,
	[Name_Position] [varchar] (20) not null,
	[Salary] [varchar] (20) not null,
	constraint [PK_Position] primary key clustered ([ID_Position] ASC) on [PRIMARY],
)
go

create procedure [dbo].[Position_select]                                             
as
   select * from [dbo].[Position] 
go

create procedure [dbo].[Position_update]                                             
@ID_Position [int], @Name_Position [varchar] (20), @Salary [varchar] (20) 
as
   update [dbo].[Position] set
   [Name_Position] = @Name_Position,
   [Salary] = @Salary
   where
        [ID_Position] = @ID_Position
go

create procedure [dbo].[Position_insert]
@Name_Position [varchar] (20), @Salary [varchar] (20) 
as
   insert into [dbo].[Position] ([Name_Position], [Salary])
   values (@Name_Position, @Salary)
go

create procedure [dbo].[Position_delete]
@ID_Position [int]
as
   delete from [dbo].[Position]
   where
        [ID_Position] = @ID_Position
go

create table [dbo].[Employee]
(
	[ID_Authorization] [int] not null,
	[First_Name_Employee] [varchar] (30) not null,
	[Name_Employee] [varchar] (30) not null,
	[Middle_Name_Employee] [varchar] (30) null default('No data'),
	[Job_Experience] [varchar] (10) not null,
	[Employment_Data] [varchar](10) not null,
	[Position_ID] [int] not null,
	constraint [PK_Employee] primary key clustered ([ID_Authorization] ASC) on [PRIMARY],
	constraint [FK_Employee] foreign key ([ID_Authorization]) references [dbo].[Authorization] ([ID_Authorization]),
	constraint [FK_Position_Employee] foreign key ([Position_ID]) 
	references [dbo].[Position] ([ID_Position])
)
go

create procedure [dbo].[Employee_select]                                             
as
   select * from [dbo].[Employee] 
go

create procedure [dbo].[Employee_update]                                             
@ID_Authorization [int], @First_Name_Employee [varchar] (30), @Name_Employee [varchar] (30), @Middle_Name_Employee [varchar] (30), @Job_Experience [varchar] (10), @Employment_Data [varchar] (10), @Position_ID [int]
as
   update [dbo].[Employee] set
   [First_Name_Employee] = @First_Name_Employee,
   [Name_Employee] = @Name_Employee,
   [Middle_Name_Employee] = @Middle_Name_Employee,
   [Job_Experience] = @Job_Experience,
   [Employment_Data] = @Employment_Data,
   [Position_ID] = @Position_ID
   where
        [ID_Authorization] = @ID_Authorization
go

create procedure [dbo].[Employee_insert]
@ID_Authorization [int],@First_Name_Employee [varchar] (30), @Name_Employee [varchar] (30), @Middle_Name_Employee [varchar] (30), @Job_Experience [varchar] (10), @Employment_Data [varchar] (10), @Position_ID [int]
as
   insert into [dbo].[Employee] ([ID_Authorization],[First_Name_Employee], [Name_Employee], [Middle_Name_Employee], [Job_Experience], [Employment_Data], [Position_ID])
   values (@ID_Authorization,@First_Name_Employee, @Name_Employee, @Middle_Name_Employee, @Job_Experience, @Employment_Data, @Position_ID)
go

create procedure [dbo].[Employee_delete]
@ID_Authorization [int]
as
   delete from [dbo].[Employee]
   where
        [ID_Authorization] = @ID_Authorization
go

create table [dbo].[Type_Weapon]
(
	[ID_Type_Weapon] [int] identity(1,1) not null,
	[Name_Type_Weapon] [varchar] (30) not null,
	constraint [PK_Type_Weapon] primary key clustered ([ID_Type_Weapon] ASC) on [PRIMARY],
)
go

create procedure [dbo].[Type_Weapon_select]                                             
as
   select * from [dbo].[Type_Weapon] 
go

create procedure [dbo].[Type_Weapon_update]                                             
@ID_Type_Weapon [int], @Name_Type_Weapon [varchar] (30)
as
   update [dbo].[Type_Weapon] set
   [Name_Type_Weapon] = @Name_Type_Weapon
   where
        [ID_Type_Weapon] = @ID_Type_Weapon
go

create procedure [dbo].[Type_Weapon_insert]
@Name_Type_Weapon [varchar] (30)
as
   insert into [dbo].[Type_Weapon] ([Name_Type_Weapon])
   values (@Name_Type_Weapon)
go

create procedure [dbo].[Type_Weapon_delete]
@ID_Type_Weapon [int]
as
   delete from [dbo].[Type_Weapon]
   where
        [ID_Type_Weapon] = @ID_Type_Weapon
go

create table [dbo].[Weapon]
(
	[ID_Weapon] [int] not null identity(1,1),
	[Name_Weapon] [varchar] (30) not null,
	[Accuracy] [varchar] (30) not null,
	[Fire_Rate] [varchar] (30) not null,
	[Shells_In_Store] [varchar] (30) not null,
	[Ammount_Weapon] [int] not null,
	[Cost] [varchar] (20) not null,
	[Type_Weapon_ID] [int] not null,
	constraint [PK_Weapon] primary key clustered ([ID_Weapon] ASC) on [PRIMARY],
	constraint [FK_Type_Weapon_Weapon] foreign key ([Type_Weapon_ID]) 
	references [dbo].[Type_Weapon] ([ID_Type_Weapon]),
)
go

create procedure [dbo].[Weapon_select]                                             
as
   select * from [dbo].[Weapon] 
go

create procedure [dbo].[Weapon_update]                                             
@ID_Weapon [int],@Name_Weapon [varchar] (30),@Accuracy [varchar] (30),@Fire_Rate [varchar] (30),@Shells_In_Store [varchar] (30),@Ammount_Weapon [int],@Cost [varchar] (20),@Type_Weapon_ID [int]
as
   update [dbo].[Weapon] set
   [Name_Weapon] = @Name_Weapon,
   [Accuracy]=@Accuracy,
   [Fire_Rate]=@Fire_Rate,
   [Shells_In_Store]=@Shells_In_Store,
   [Ammount_Weapon]=@Ammount_Weapon,
   [Cost]=@Cost,
   [Type_Weapon_ID]=@Type_Weapon_ID
   where
        [ID_Weapon] = @ID_Weapon
go

create procedure [dbo].[Weapon_insert]
@Name_Weapon [varchar] (30),@Accuracy [varchar] (30),@Fire_Rate [varchar] (30),@Shells_In_Store [varchar] (30),@Ammount_Weapon [int],@Cost [varchar] (20),@Type_Weapon_ID [int]
as
   insert into [dbo].[Weapon] ([Name_Weapon],[Accuracy],[Fire_Rate],[Shells_In_Store],[Ammount_Weapon],[Cost],[Type_Weapon_ID])
   values (@Name_Weapon,@Accuracy,@Fire_Rate,@Shells_In_Store,@Ammount_Weapon, @Cost,@Type_Weapon_ID)
go



create procedure [dbo].[Weapon_delete]
@ID_Weapon [int]
as
   delete from [dbo].[Weapon]
   where
        [ID_Weapon] = @ID_Weapon
go

create view [dbo].[Weapon_select_view]
as
	select ID_Weapon, ([Name_Weapon] +' '+ [Name_Type_Weapon]) as WeaponInfo, Accuracy, Fire_Rate,Shells_In_Store, Ammount_Weapon,Cost from Weapon 
	inner join Type_Weapon on Type_Weapon.ID_Type_Weapon  = Weapon.Type_Weapon_ID
go

create procedure [dbo].[Weapon_select_detail]                                             
as
   select * from [dbo].[Weapon_select_view] 
go

create table [dbo].[Supplier]
(
	[ID_Supplier] [int] identity(1,1) not null,
	[Name_Organization] [varchar] (30) not null,
	constraint [PK_Supplier] primary key clustered ([ID_Supplier] ASC) on [PRIMARY],
)
go

create procedure [dbo].[Supplier_select]                                             
as
   select * from [dbo].[Supplier] 
go

create procedure [dbo].[Supplier_update]                                             
@ID_Supplier [int], @Name_Organization [varchar] (30)
as
   update [dbo].[Supplier] set
   [Name_Organization] = @Name_Organization
   where
        [ID_Supplier] = @ID_Supplier
go

create procedure [dbo].[Supplier_insert]
@Name_Organization [varchar] (30)
as
   insert into [dbo].[Supplier] ([Name_Organization])
   values (@Name_Organization)
go

create procedure [dbo].[Supplier_delete]
@ID_Supplier [int]
as
   delete from [dbo].[Supplier]
   where
        [ID_Supplier] = @ID_Supplier
go

create table [dbo].[Dogovor]
(
	[ID_Dogovor] [int] identity(1,1) not null,
	[Number_Dogovor] [varchar] (30) not null,
	constraint [PK_Dogovor] primary key clustered ([ID_Dogovor] ASC) on [PRIMARY],
)
go

create procedure [dbo].[Dogovor_select]                                             
as
   select * from [dbo].[Dogovor] 
go

create procedure [dbo].[Dogovor_update]                                             
@ID_Dogovor [int], @Number_Dogovor [varchar] (30)
as
   update [dbo].[Dogovor] set
   [Number_Dogovor] = @Number_Dogovor
   where
        [ID_Dogovor] = @ID_Dogovor
go

create procedure [dbo].[Dogovor_insert]
@Number_Dogovor [varchar] (30)
as
   insert into [dbo].[Dogovor] ([Number_Dogovor])
   values (@Number_Dogovor)
go

create procedure [dbo].[Dogovor_delete]
@ID_Dogovor [int]
as
   delete from [dbo].[Dogovor]
   where
        [ID_Dogovor] = @ID_Dogovor
go

create table [dbo].[Supply]
(
	[ID_Supply] [int] identity(1,1) not null,
	[Date] [varchar] (10) not null,
	[Ammount_Accepted_Weapon][int] not null,
	[Ammount_Accepted_Modifications][int] not null,
	[Ammount_Accepted_Ammo][int] not null,
	[Supplier_ID] [int] not null,
	[Dogovor_ID] [int] not null,
	constraint [PK_Supply] primary key clustered ([ID_Supply] ASC) on [PRIMARY],
	constraint [FK_Supplier_Supply] foreign key ([Supplier_ID]) 
	references [dbo].[Supplier] ([ID_Supplier]),
	constraint [FK_Dogovor_Supply] foreign key ([Dogovor_ID]) 
	references [dbo].[Dogovor] ([ID_Dogovor])
)
go

create procedure [dbo].[Supply_select]                                             
as
   select * from [dbo].[Supply] 
go

create procedure [dbo].[Supply_update]                                             
@ID_Supply [int], @Date [varchar] (10),@Ammount_Accepted_Weapon[int],@Ammount_Accepted_Modifications[int],@Ammount_Accepted_Ammo[int],@Supplier_ID [int], @Dogovor_ID [int]
as
   update [dbo].[Supply] set
   [Date]=@Date,
   [Ammount_Accepted_Weapon]=@Ammount_Accepted_Weapon,
   [Ammount_Accepted_Modifications]=@Ammount_Accepted_Modifications,
   [Ammount_Accepted_Ammo]=@Ammount_Accepted_Ammo,
   [Supplier_ID]=@Supplier_ID,
   [Dogovor_ID] =@Dogovor_ID
   where
        [ID_Supply] = @ID_Supply
go

create procedure [dbo].[Supply_insert]
@Date [varchar] (10),@Ammount_Accepted_Weapon[int],@Ammount_Accepted_Modifications[int],@Ammount_Accepted_Ammo[int],@Supplier_ID [int], @Dogovor_ID [int]
as
   insert into [dbo].[Supply] ([Date],[Ammount_Accepted_Weapon],[Ammount_Accepted_Modifications],[Ammount_Accepted_Ammo],[Supplier_ID],[Dogovor_ID])
   values (@Date,@Ammount_Accepted_Weapon,@Ammount_Accepted_Modifications,@Ammount_Accepted_Ammo,@Supplier_ID,@Dogovor_ID)
go

create procedure [dbo].[Supply_delete]
@ID_Supply [int]
as
   delete from [dbo].[Supply]
   where
        [ID_Supply] = @ID_Supply
go

create table [dbo].[Nakladnaya]
(
	[ID_Nakladnaya] [int] identity(1,1) not null,
	[Number_Nakladnaya] [varchar] (30) not null,
	[Supply_ID] [int] not null,
	constraint [PK_Nakladnaya] primary key clustered ([ID_Nakladnaya] ASC) on [PRIMARY],
	constraint [FK_Supply_Nakladnaya] foreign key ([Supply_ID]) 
	references [dbo].[Supply] ([ID_Supply])
)
go

create procedure [dbo].[Nakladnaya_select]                                             
as
   select * from [dbo].[Nakladnaya] 
go

create procedure [dbo].[Nakladnaya_update]                                             
@ID_Nakladnaya [int], @Number_Nakladnaya [varchar] (30),@Supply_ID [int]
as
   update [dbo].[Nakladnaya] set
   [Number_Nakladnaya]=@Number_Nakladnaya,
   [Supply_ID]= @Supply_ID
   where
        [ID_Nakladnaya] = @ID_Nakladnaya
go

create procedure [dbo].[Nakladnaya_insert]
@Number_Nakladnaya [varchar] (30),@Supply_ID [int]as
   insert into [dbo].[Nakladnaya] ([Number_Nakladnaya],[Supply_ID])
   values (@Number_Nakladnaya,@Supply_ID)
go

create procedure [dbo].[Nakladnaya_delete]
@ID_Nakladnaya [int]
as
   delete from [dbo].[Nakladnaya]
   where
        [ID_Nakladnaya] = @ID_Nakladnaya
go


create table [dbo].[Ammo]
(
	[ID_Ammo] [int] not null identity(1,1),
    [Type_Ammo] [varchar] (30) not null,
	[Ammount_Ammo] [int] not null,
	[Cost] [varchar] (30) not null,
	constraint [PK_Ammo] primary key clustered ([ID_Ammo] ASC) on [PRIMARY]
)
go

create procedure [dbo].[Ammo_select]                                             
as
   select * from [dbo].[Ammo] 
go

create procedure [dbo].[Ammo_update]                                             
@ID_Ammo [int],@Type_Ammo [varchar] (30), @Ammount_Ammo [int], @Cost [varchar] (30)
as
   update [dbo].[Ammo] set
   [Type_Ammo] = @Type_Ammo,
   [Ammount_Ammo]=@Ammount_Ammo,
   [Cost] = @Cost
   where
        [ID_Ammo] = @ID_Ammo
go

create procedure [dbo].[Ammo_insert]
@Type_Ammo [varchar] (30), @Ammount_Ammo [int], @Cost [varchar] (30)
as
   insert into [dbo].[Ammo] ([Type_Ammo],[Ammount_Ammo],[Cost])
   values (@Type_Ammo,@Ammount_Ammo,@Cost)
go

create procedure [dbo].[Ammo_delete]
@ID_Ammo [int]
as
   delete from [dbo].[Ammo]
   where
        [ID_Ammo] = @ID_Ammo
go

create table [dbo].[Modifications]
(
	[ID_Modification] [int] not null identity(1,1),
    [Name_Modification] [varchar] (30) not null,
	[Ammount_Modifications] [int] not null,
	[Cost] [varchar] (30) not null,
	constraint [PK_Modification] primary key clustered ([ID_Modification] ASC) on [PRIMARY]
)
go

create procedure [dbo].[Modifications_select]                                             
as
   select * from [dbo].[Modifications] 
go


create procedure [dbo].[Modifications_update]                                             
@ID_Modification [int], @Name_Modification [varchar] (30), @Ammount_Modifications [int], @Cost [varchar] (30)
as
   update [dbo].[Modifications] set
   [Name_Modification] = @Name_Modification,
   [Ammount_Modifications]=@Ammount_Modifications,
   [Cost] = @Cost
   where
        [ID_Modification] = @ID_Modification
go

create procedure [dbo].[Modifications_insert]
 @Name_Modification [varchar] (30), @Ammount_Modifications [int], @Cost [varchar] (30)
as
   insert into [dbo].[Modifications] ([Name_Modification],[Ammount_Modifications],[Cost])
   values (@Name_Modification,@Ammount_Modifications,@Cost)
go

create procedure [dbo].[Modifications_delete]
@ID_Modification [int]
as
   delete from [dbo].[Modifications]
   where
        [ID_Modification] = @ID_Modification
go

create table [dbo].[Role]
(
    [ID_Role] [int] not null identity(1,1),
    [Title_Role] [varchar] (30) not null,
    [Klient] [int] not null,
    [Employee] [int] not null,
	[Admin] [int] not null,
    constraint [PK_Role] primary key clustered ([ID_Role] ASC) on [PRIMARY]
)
go

insert into [dbo].[Role] ([Title_Role]  ,[Add_client] ,[Add_Weapon] ,[Add_Ammo],[Add_Modifications],[Goods_purchase],[Lock_client] ,[Accounting_goods] )
values 
('Клиент',0,0,0,0,1,0,0),
('Продавец-консультант',1,0,0,0,1,1,1),
('Кладовщик',0,0,0,1,0,0,1),
('Администратор',1,1,1,1,0,1,1)
go

create procedure [dbo].[Role_select]
   @ID_ROLE [int]
as
    IF(@ID_ROLE IS NULL OR @ID_ROLE = '')
        select * from [dbo].[Role] 
        ELSE
        select * from [dbo].[Role] where [ID_Role] = @ID_Role
go

create procedure [dbo].[Role_update]
@ID_Role [int], @Title_Role [int], @Klient [int], @Employee [int], @Admin [int]
as
   update [dbo].[Role] set
   [Title_Role] = @Title_Role, 
   [Klient] = @Klient, 
   [Employee] = @Employee, 
   [Admin]=@Admin
   where
        [ID_Role] = @ID_Role
go

create procedure [dbo].[Role_insert]
@Title_Role [int],  @Title_Role [int], @Klient [int], @Employee [int], @Admin [int]
as
   insert into [dbo].[Role] ([Title_Role], [Klient], [Employee],[Admin])
   values (@Title_Role, @Klient, @Employee, @Admin)
go

create procedure [dbo].[Role_delete]
@ID_Role [int]
as
   delete from [dbo].[Role]
   where
        [ID_Role] = @ID_Role
go

create table [dbo].[Composition_of_the_Issued_License]
(
	[ID_Composition_of_the_Check] [int] not null identity(1,1),
	[Issued_License_ID] [int] not null,
	[Ammount_of_Product] [int] not null,
	[Weapon_ID] [int] not null,
	[Modifications_ID] [int] not null,
	[Ammo_ID] [int] not null,
	constraint [PK_Composition_of_the_Check] primary key clustered
	([ID_Composition_of_the_Check] ASC) on [PRIMARY],
	constraint [CH_Ammount_of_Product] check ([Ammount_of_Product] >=0),
	constraint [FK_Issued_License_Composition_of_the_Issued_License] foreign key ([Issued_License_ID])
	references [dbo].[Issued_License] ([ID_Issued_License]),
	constraint [FK_Weapon_Composition_of_the_Check] foreign key ([Weapon_ID])
	references [dbo].[Weapon] ([ID_Weapon]),
	constraint [FK_Modifications_Composition_of_the_Check] foreign key ([Modifications_ID])
	references [dbo].[Modifications] ([ID_Modification]),
	constraint [FK_ID_Ammo_Composition_of_the_Check] foreign key ([Ammo_ID])
	references [dbo].[Ammo] ([ID_Ammo])
)
go

create procedure [dbo].[Klient_select_detail]                                             
as
   select * from [dbo].[klient_select_view] 
go

create view [dbo].[Klient_select_view]
as
select ID_Authorization, ([First_Name_Klient] +' '+ [Name_Klient]+' '+ [Middle_Name_Klient]+' '+[Phone_Number]) as KlientInfo, License.License_Number as NumberLicense from Klient 
inner join License on License.ID_License = Klient.License_ID
go

Alter database [Weapon_Store] set enable_broker with rollback immediate
go