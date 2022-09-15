CREATE DATABASE Bangalir_Khaber
CREATE TABLE Seller_reg
(
Name VARCHAR(30),
mail VARCHAR(30) PRIMARY KEY,
Phone VARCHAR(30),
District VARCHAR(30),
Addres VARCHAR(60),
PASS VARCHAR(30),
PICTURE IMAGE
);
SELECT*FROM seller_reg;
DROP TABLE Seller_reg;





CREATE TABLE Customer_reg
(
Name VARCHAR(30),
mail VARCHAR(30) PRIMARY KEY,
Phone VARCHAR(30),
District VARCHAR(30),
Addres VARCHAR(60),
PASS VARCHAR(30),
PICTURE IMAGE
);

INSERT into Customer_reg (Name,mail,Phone,District,Addres,PASS) 
  values ('Rima','rima@gmail.com','0123456789','gazipur','konabari','4321')
  iNSERT into Customer_reg (Name,mail,Phone,District,Addres,PASS) 
  values ('sima','sima@gmail.com','0123456789','gazipur','konabari','4321')
  iNSERT into Customer_reg (Name,mail,Phone,District,Addres,PASS) 
  values ('sadia','sadia@gmail.com','0123456789','gazipur','konabari','4321')
  iNSERT into Customer_reg (Name,mail,Phone,District,Addres,PASS) 
  values ('sadia','1','0123456789','gazipur','konabari','1')

SELECT*FROM Customer_reg;
DROP TABLE Customer_reg;

DROP TABLE Add_Product
CREATE TABLE Add_Product
(
  NAME VARCHAR(30),
  PICTURE IMAGE,
  CATEGORY  VARCHAR(40),
  QUANTITY VARCHAR(50),
  PRICE VARCHAR(8) ,
  Descr VARCHAR(300),
  mail VARCHAR(30),
  id int IDENTITY(1,1)
  );
  SELECT*FROM Add_Product;




  SELECT*FROM SSSSAAAA;

  INSERT into SSSSAAAA(Name,mail,Phone,District,Addres,PASS) 
  values ('sazzad','sazzad@gmail.com','0123456789','0123456789','konabari','1234')
  INSERT into SSSSAAAA(Name,mail,Phone,District,Addres,PASS) 
  values ('rakib','rakib@gmail.com','258963147','District','Addres','74123')
  INSERT into SSSSAAAA(Name,mail,Phone,District,Addres,PASS) 
  values ('hamid','hamid@gmail.com','258963147','District','Addres','74123')
  INSERT into SSSSAAAA(Name,mail,Phone,District,Addres,PASS) 
  values ('jahid','jahid@gmail.com','0123456789','0123456789','konabari','1234')
  INSERT into SSSSAAAA(Name,mail,Phone,District,Addres,PASS) 
  values ('hasib','hasibb@gmail.com','258963147','District','Addres','74123')
  INSERT into SSSSAAAA(Name,mail,Phone,District,Addres,PASS) 
  values ('mahin','mahin@gmail.com','258963147','District','Addres','74123')
  INSERT into SSSSAAAA(Name,mail,Phone,District,Addres,PASS) 
  values ('mahin','0','258963147','District','Addres','0')




  DROP TABLE ORDERR;
  CREATE TABLE ORDERR
(
id int IDENTITY(1,1),
FullName VARCHAR(30),
Cmail VARCHAR(30),
Phone VARCHAR(30),
Addres VARCHAR(60),
payment VARCHAR(30),
Price VARCHAR(30),
ProductName VARCHAR(30),
Smail VARCHAR(30),
Updat VARCHAR(30),
);
SELECT*FROM ORDERR;
