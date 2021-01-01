CREATE TABLE [dbo].[User](    
    [Id] [int] IDENTITY(1,1) NOT NULL,    
    [Username] [nvarchar](50) NOT NULL,    
    [FirstName] [nvarchar](50) NOT NULL,    
    [LastName] [nvarchar](50) NOT NULL,    
    [Role] [nvarchar](20) NOT NULL,    
    [Email] [nvarchar](50) NULL,    
    [Phone] [nvarchar](20) NULL,   
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED     
(    
    [Id] ASC    
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]    
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

CREATE PROCEDURE [dbo].[spGetUserByUsernameOrEmail]
	@Username			nvarchar(50) = '',
	@Email				nvarchar(50) = ''
AS
  BEGIN

  if(@Username = '')
  SET @Username = null

  if(@Email = '')
  SET @Email = null

  

	Select 
		[Id]
	from [dbo].[User] 
	where (@pUsername IS NOT NULL AND [UserName] = @Username)
		  OR (@pEmail IS NOT NULL AND [Email] = @Email)
  END
GO

