use TesteEF
go

select * from tb_Produto
select * from TB_USUARIO
select * from TB_VENDA
select * from TB_VENDA_ITEM

insert into TB_PRODUTO(NOME_PRODUTO, PRECO_PRODUTO, DATA_VALIDADE, TIPO_PRODUTO)
values ('Leite', 3.99, '2021-01-01 00:00:00', 'Alimento'),
('Açucar', 2.99, '2021-09-25 00:00:00', 'Alimento'),
('Arroz', 11.99, '2021-01-01 00:00:00', 'Alimento'),
('Manteiga', 5.99, '2021-01-01 00:00:00', 'Alimento'),
('Cafe', 10.99, '2021-01-01 00:00:00', 'Alimento')

insert into TB_USUARIO(DSC_USUARIO, DATA_NASCIMENTO)
values ('João', '1999-01-01 00:00:00'),
('Beatriz', '1999-01-01 00:00:00'),
('Sergio', '1999-01-01 00:00:00'),
('Lucas', '1999-01-01 00:00:00'),
('Leila', '1999-01-01 00:00:00')

insert into TB_VENDA(ID_USUARIO, VALOR_TOTAL)
values (1, 50.00),
(2, 75.50),
(3, 80.00),
(4, 100.00),
(5, 120.00)

insert into TB_VENDA_ITEM(ID_VENDA, ID_PRODUTO, QUANTIDADE)
values (2, 1, 4),
(3, 2, 5),
(4, 3, 6),
(5, 4, 7),
(6, 5, 8)