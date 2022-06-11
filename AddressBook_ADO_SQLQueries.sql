-- creating AddressBookDB_Day_33 Database
create database AddressBookDB_Day_33
use AddressBookDB_Day_33

create table AddressBook
(
  PersonId int Not Null Primary Key identity,
  FirstName varchar(20) Not NULL,
  LastName varchar(20) Not NULL,
  Address varchar(60),
  City  varchar(20),
  State  varchar(20),
  MobileNo bigint,
  EmailId  varchar(50)
)
