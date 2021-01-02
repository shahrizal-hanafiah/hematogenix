CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	CONSTRAINT UC_User UNIQUE (Username),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]   
GO    
/* TO GET ALL USER AND GET USER BY ID*/    
create procedure spGetUsers    
as    
begin     
select * from [dbo].[User]    
end     
/* TO CREATE NEW USER*/    
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCreateUser]
@Username nvarchar(50),    
@FirstName nvarchar(50),    
@LastName nvarchar(50),    
@Role nvarchar(20),    
@Email nvarchar(50),    
@Phone nvarchar(20)
AS
  BEGIN
	insert into [dbo].[User]  (Username,FirstName,LastName,Role,Email,Phone)    
    values(@Username,@FirstName,@LastName,@Role,@Email,@Phone) 

	Select  * from [dbo].[User] where Id = CAST(SCOPE_IDENTITY() AS INT) 
  END
GO

/* TO UPDATE USER*/    
create procedure spUpdateUser    
(    
@Id int,
@Username nvarchar(50),    
@FirstName nvarchar(50),    
@LastName nvarchar(50),    
@Role nvarchar(20),    
@Email nvarchar(50),    
@Phone nvarchar(20)  
)    
as    
begin    
    update [dbo].[User]       
    set Username=@Username,FirstName=@FirstName,LastName=@LastName,Role=@Role,Email=@Email,Phone=@Phone  
    where Id=@Id    
end    
/* TO DELETE USER*/    
create procedure spDeleteUser   
(    
@Id int    
)    
as    
begin    
    delete from [dbo].[User]   where Id=@Id    
end 

/*TO GET USER BY USERNAME OR EMAIL */
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUserByUsername]
	@Username			nvarchar(50) = ''
AS
  BEGIN

  if(@Username = '')
  SET @Username = null

  

	Select 
		[Id]
	from [dbo].[User] 
	where (@Username IS NOT NULL AND [UserName] = @Username)
  END
GO

/*ADD USERS*/
GO

INSERT INTO [dbo].[User] VALUES ('Kelly1564','Cedric','Kelly','General User','kelly@gmail.com','01029387165')
INSERT INTO [dbo].[User] VALUES ('Stevens3213','Cara','Stevens','General User','stevens3213@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Brenden314','Brenden','Wagner','General User','Brenden@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Bradley6456','Bradley','Greer','General User','Bradley@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Ashton4324','Ashton','Cox','General User','Ashton@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Angelica8875','Angelica','Ramos','General User','Angelica@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Airi565','Airi','Satou','General User','Airi@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Gavin342','Gavin','Joyce','General User','Gavin@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Garrett765','Garrett','Winters','General User','Garrett@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Fiona680','Fiona','Green','General User','Fiona@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Finn524','Finn','Camacho','Super User','Finn@gmail.com','01487326541')
INSERT INTO [dbo].[User] VALUES ('Doris346','Doris','Wilder','General User','Doris@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Donna778','Donna','Snider','General User','Donna@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Dai632','Dai','Rios','General User','Dai@gmail.com','')
INSERT INTO [dbo].[User] VALUES ('Colleen2357','Colleen','Hurst','Super User','Colleen@gmail.com','01029387165')
GO