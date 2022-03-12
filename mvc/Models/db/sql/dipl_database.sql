CREATE DATABASE dipl_database collate utf8mb4_general_ci;
use dipl_database;
/*
drop table recipes;
select * from recipes;
*/
create table recipes(
id int not null auto_increment,
recipename varchar(100),
price decimal not null,
calories int not null,
vegan boolean default false, 
vegetarian boolean default false, 
duration int not null, 
occasion tinyint null, 
regional boolean default false,
origin tinyint null,
instruction varchar(10000),
ingredients varchar(1000),
dateadded date,

constraint id_PK primary key(id)
)engine=InnoDB;
 
 create table users(
 userId int not null auto_increment,
 firstname varchar(100) not null,
 lastname varchar(100) not null,
 age int not null,
 gender tinyint null,
 birthdate date not null,
 email varchar(100) not null,
 passwrd varchar(100) not null,
 username varchar(100) not null,
isAdmin boolean default false,
 
 constraint userId_PK primary key(userId)
 )engine=InnoDB;
 
 insert into users values(null, "Admin", "User", 18, null, date("2000-12-09"), "fabian@gmail.com", sha1("fabian00!"),"fabian", true);
  insert into users values(null, "Admin", "User", 18, null, date("1999-10-26"), "yannic@gmail.com", sha1("yannic!"),"yannic", true);
   insert into users values(null, "Admin", "User", 18, null, date("2000-12-18"), "maxi@gmail.com", sha1("maxi!"),"maxi", true);

/*
select * from users;
select * from recipes order by dateadded desc;
SELECT * FROM recipes ORDER BY id DESC LIMIT 3;
select * from recipes where origin = 1;
select * from recipes where id = 0  ;
select * from recipes where recipename = "sphagetti";

drop table recipes;
*/
insert into recipes values(null, "ABC", 1000, false, false, 10, 30, null, true,null,  "fafdfasdfjk djfsajfs fjlsöadfjsla fjdslökfjsa jfklsadfjsaflö kjfls
 fdsajfasldkjöl  flkdajfa öjf klöfjsfl jaöslfj salkfjsdfk jaslföa fjkasdfjö lajfkl djsfalösfj dslökfjsaflkajfsaöfjaölfdjs jdflöasfjslöfjsadfölkasf", "2 Eier, 150ml Milch, 500g Mehl",  date("2020-01-14"));
insert into recipes values(null, "CAB", 800, false, false, 20, 50, null, true,null, "fafdfasdfjk djfsajfs fjlsöadfjsla fjdslökfjsa jfklsadfjsaflö kjfls djaslfkj fjasdlöfkj fsajkflöajdf 
 fdlsöakfjaöl fjdklsa öadjf fjlsafjasl öfdfajföadlk kd fjaslö jkfkldasfj salköfj lköfdjsaflökjas fkasdlfj alökfj askf ajlö jkfaskfjd lö", "500g Steak, 250g Brocoli, Sazl, Peffer",  date("2020-01-18"));  
 insert into recipes values(null, "Sphagetti", 800, false, false, 20, 50, null, true,null, "fafdfasdfjk djfsajfs fjlsöadfjsla fjdslökfjsa jfklsadfjsaflö kjfls djaslfkj fjasdlöfkj fsajkflöajdf 
 fdlsöakfjaöl fjdklsa öadjf fjlsafjasl öfdfajföadlk kd fjaslö jkfkldasfj salköfj lköfdjsaflökjas fkasdlfj alökfj askf ajlö jkfaskfjd lö", "500g Steak, 250g Brocoli, Sazl, Peffer",  date("2020-01-18"));  
 insert into recipes values(null, "Sphagetti Carbonara", 800, false, false, 20, 50, null, true,null, "fafdfasdfjk djfsajfs fjlsöadfjsla fjdslökfjsa jfklsadfjsaflö kjfls djaslfkj fjasdlöfkj fsajkflöajdf 
 fdlsöakfjaöl fjdklsa öadjf fjlsafjasl öfdfajföadlk kd fjaslö jkfkldasfj salköfj lköfdjsaflökjas fkasdlfj alökfj askf ajlö jkfaskfjd lö", "500g Steak, 250g Brocoli, Sazl, Peffer",  date("2020-01-18"));  


select * from users;