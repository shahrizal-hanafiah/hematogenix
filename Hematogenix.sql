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
create procedure spAddNew    
(    
@Username nvarchar(50),    
@FirstName nvarchar(50),    
@LastName nvarchar(50),    
@Role nvarchar(20),    
@Email nvarchar(50),    
@Phone nvarchar(20)
)    
as    
begin    
    insert into [dbo].[User]  (Username,FirstName,LastName,Role,Email,Phone)    
    values(@Username,@FirstName,@LastName,@Role,@Email,@Phone)    
end    
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