use TESTE_IDENTITY
go

select * from AspNetRoleClaims
select * from AspNetRoles
select * from AspNetUserClaims
select * from AspNetUserLogins
select * from AspNetUserRoles
select * from AspNetUsers
select * from AspNetUserTokens

--HABILITAR USUÁRIO PARA ENTRAR NO SISTEMA
UPDATE AspNetUsers
SET EmailConfirmed = 1
WHERE Id = 'ca5baef8-5a43-4ed6-8114-683f0793f4df'

--ATRIBUI ROLE PARA UM USUÁRIO
INSERT INTO AspNetUserRoles(UserId, RoleId)
VALUES ('ca5baef8-5a43-4ed6-8114-683f0793f4df', '738cf3ca-033b-40f3-811d-375873456acc')
