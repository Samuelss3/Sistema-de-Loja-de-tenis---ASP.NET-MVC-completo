
drop database BD_PROJETOASP;
create database BD_PROJETOASP;
use BD_PROJETOASP;

create table tipoUsuario(
	IDtipoUsuario int primary key auto_increment,
    tipoUsuario varchar(20)
);
insert into tipoUsuario 
values(default, 'Cliente'),(default, 'Funcionario');

create table CadastroLogin(
	IDusuario int primary key auto_increment,
    nome varchar(50) not null,
    sobrenome varchar(50) not null,
    datanasc date not null,
    cpf char (14) not null,
    cep char(9) not null,
    nm_log varchar(50) not null,
    no_log varchar(5) not null,
    ds_complemento varchar(100) null,
    bairro varchar(50) not null,
    UF char(2) not null,
    Email varchar(50) not null ,
    senha varchar(100) not null,
    IDtipoUsuario int,
	foreign key (IDtipoUsuario) references tipoUsuario(idTipoUsuario)
);

create table telefonecli(
	codTelefonecli int primary key auto_increment,
    telefoneCliente varchar (15) not null, 
    IDusuario int,
    foreign key (IDusuario) references CadastroLogin(IDusuario)
);

create table Categoria(
	IDcategoria int primary key auto_increment,
    nm_categoria varchar(50) not null
);

Insert into Categoria (nm_categoria) values ('feminino');
Insert into Categoria (nm_categoria) values ('Masculino');
Insert into Categoria (nm_categoria) values ('Infantil');
update Categoria set nm_categoria = 'feminino ' where IDcategoria = 2;
select * from categoria;

create table tamanho(
	IDtamanho int primary key auto_increment,
    sg_tamanho varchar(50) not null
);

insert into tamanho values(default, 35);

create table fornecedor(
	IDfornecedor int primary key auto_increment,
    Nome varchar(50) not null, 
    telefone  varchar (15) not null,
    cnpj varchar(20) not null,
	nm_log varchar(50) not null,
    no_log varchar(5) not null,
    ds_complemento varchar(100) null,
    bairro varchar(50) not null,
    UF char(2) not null
);

insert into fornecedor values (default, 'Nike','1','1','AO','1','','AA','SP');

create table Produto(
	IDproduto int primary key auto_increment,
    nomeprod varchar(50),
    imgProd varchar(200),
    imgProd2 varchar(200),
	imgProd3 varchar(200),
    imgProd4 varchar(200),
	imgProd5 varchar(200),
    imgProd6 varchar(200),
	imgProd7 varchar(200),
    preco decimal (10,2),
    estoque int,
    descricao varchar (1000),
    IDcategoria int,
    IDfornecedor int,
    foreign key (IDcategoria) references Categoria(IDcategoria),
    foreign key (IDfornecedor) references Fornecedor(IDfornecedor)
);

create table Venda(
IDVenda int primary key auto_increment,
IDusuario int,
datavenda varchar(10),
horavenda varchar(10),
valorFinal varchar(50),
foreign key (IDusuario) references CadastroLogin(IDusuario)
);

create table itemVenda(
IDitemVenda int primary key auto_increment,
IDVenda int, 
IDproduto int,
qtdeVendas int,
valorParcial varchar(50),
foreign key (IDvenda) references Venda(IDvenda),
foreign key (IDproduto) references Produto(IDproduto)
);

select * from venda;

create table pagamento(
	IDpagamento int primary key auto_increment,
    nomecompleto varchar(50),
    nm_log varchar(50),
    cep varchar(9),
	cidade varchar(50),
	ds_complemento varchar(100) null,
    no_card varchar(50),
    expira varchar(10),
    cd_cartao varchar(4)
    -- IDvenda int,
    -- foreign key (IDvenda) references Venda(IDvenda)
);

/* -----------------------------------------------------------procedure de insert, update e delete-----------------------------------------------------------*/
 -- drop procedure insertUsuario;
delimiter $$
	create procedure insertUsuario(
		in vNome varchar(50),
        in vSobrenome varchar(50),
        in vdatanasc date,
        in vcpf char (14),
        in vcep char (9),
        in vnm_log varchar(50),
        in vno_log varchar(5),
        in vds_complemento varchar(100),
        in vBairro varchar (50),
        in vUF char(2),
		in vEmail varchar(50),
        in vSenha varchar(100),
        in vIdtipoUsuario varchar(1),
        in vTelefoneCliente varchar (15)
    )
    
    begin 
		insert into CadastroLogin(Nome, Sobrenome, datanasc, cpf, cep, nm_log, no_log, ds_complemento, Bairro, UF, Email, Senha, IdtipoUsuario) values(vNome, vSobrenome, vdatanasc, vcpf, vcep, vnm_log, vno_log, vds_complemento, vBairro, vUF, vEmail, vSenha ,vIdtipoUsuario);
        insert into telefonecli(telefoneCliente, IDusuario) values (vTelefoneCliente, last_insert_id());
	end $$
delimiter ;


 -- drop procedure UpdateUsuario;
delimiter $$
	create procedure UpdateUsuario(
		in vNome varchar(50),
        in vSobrenome varchar(50),
        in vdatanasc date,
        in vcpf char (14),
        in vcep char (9),
        in vnm_log varchar(50),
        in vno_log varchar(5),
        in vds_complemento varchar(100),
        in vBairro varchar (50),
        in vUF char(2),
		in vEmail varchar(50),
        in vSenha varchar(100),
        in vIdtipoUsuario int,
        in vTelefoneCliente varchar (15),
        in vIDusuario int,
        in vcodTelefonecli int
    )
    
    begin 
		update cadastroLogin set Nome = vNome, sobrenome = vSobrenome, datanasc= vdatanasc, cpf = vcpf, cep = vcep, nm_log = vnm_log, no_log = vno_log, ds_complemento = vds_complemento, Bairro = vBairro, UF = vUF, Email = vEmail, Senha = vSenha, IdtipoUsuario = vIdtipoUsuario
        where IDusuario = vIDusuario;
        update TelefoneCli set telefonecliente = vTelefoneCliente where IDusuario = vIDusuario;
	end $$
delimiter ;

-- drop procedure deleteUsuario;
delimiter $$
	create procedure deleteUsuario(
        in vIDusuario int
    )
    
    begin 
		delete from telefoneCLi where IDusuario = vIDusuario;
		delete from cadastrologin where IDusuario = vIDusuario;
	end $$
delimiter ;

/* -----------------------------------------------------------procedure de insert, update e delete-----------------------------------------------------------*/


/* --------------------procedure para o login--------------------*/
delimiter $$
create procedure SelectLogin(in vEmail varchar(50))
Begin
select Email from Cadastrologin where Email = vEmail;
End $$
delimiter ;


delimiter $$
create procedure SelectUsuario(in vEmail varchar(50))
Begin
select * from Cadastrologin where Email = vEmail;
End $$
desc tipoUsuario;
delimiter ;
/* --------------------procedure para o login--------------------*/


/* --------------------Chamadas--------------------*/
call insertUsuario('ADM', 'ADM', '2003-10-22', '12345678901', '05273000', 'Rua tra', '49', 'casa1', 'paineiras', 'SP', 'Admin@adm.com','12345678', '2', '12345678902');
call insertUsuario('Samuel', 'Souza', '2003-10-22', '12345678901', '05273000', 'Rua tra', '49', 'casa1', 'paineiras', 'SP', 'samueelsouzasilva@', '12345', '2', '12345678902');
call insertUsuario('Samuel', 'Souza', '2003-10-22', '12345678901', '05273000', 'Rua tra', '49', 'casa1', 'paineiras', 'SP', 'samueelsouzasilva4', '123123', '1', '12345678902');
-- call updateUsuario('Mariiaaaaaaia','José','1999-04-14', '000.000.000-00', '11111-111', 'São sebastiao','G12','','vila ans','AM','meajudaa','147147147', 3 ,'1109999999', 4,last_insert_id());

/* --------------------Chamadas--------------------*/


/* --------------------Select--------------------*/
select * from Cadastrologin inner join telefonecli where Cadastrologin.IDusuario = telefonecli.IDusuario;
select * from cadastroLogin inner join telefoneCli where cadastroLogin.IDUsuario = TelefoneCLi.IDUsuario and idTipoUsuario = 3;
select * from cadastroLogin inner join telefoneCli where cadastroLogin.IDUsuario = TelefoneCLi.IDUsuario and idTipoUsuario = 2;
select * from cadastroLogin inner join telefoneCli where cadastroLogin.IDUsuario = TelefoneCLi.IDUsuario and idTipoUsuario = 1;
select * from CadastroLogin where nome = IDusuario;
select * from cadastroLogin inner join telefoneCli where cadastroLogin.IDUsuario = TelefoneCLi.codtelefonecli;
select * from tipoUsuario;
select * from Produto;
select * from categoria; 
select nm_categoria from categoria;
/* --------------------Select--------------------*/