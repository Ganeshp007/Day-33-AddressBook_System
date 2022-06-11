-- Stored Procedure (SP)  for ado.net  AddressBookDB project to Update records of Address using their name

create procedure [dbo].[SpUpdate_AddressBook_Details]
@FirstName varchar(20),
@LastName varchar(20),
@City varchar(20)
as

update AddressBook
set City = @City
where FirstName=@FirstName and LastName=@LastName

select * from AddressBook