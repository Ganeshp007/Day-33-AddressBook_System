-- Stored Procedure (SP)  for ado.net  AddressBookDB project

create proc SpAdd_AddressBook_Details
@FirstName varchar(20),
@LastName varchar(20),
@Address varchar(60),
@City varchar(20),
@State varchar(20),
@MobileNo Bigint,
@EmailId varchar(50)
as

insert into AddressBook values (@FirstName, @LastName, @Address, @City, @State, @MobileNo, @EmailId)

go


select * from AddressBook