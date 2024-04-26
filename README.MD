# Projeto de Desenvolvimento BackEnd estagio Just-IT

## Projeto desenvolvido utilizando as tecnologias
- .NET 6
- Postgres
- docker

## Como instalar:
Primeiro copie o projeto utilizando o comando:
```bash
git clone https://github.com/gabriell3103/ProjetoJUST-IT
```
Em seguida um banco de dados Postgres utilizando o docker, para isso utilize o comando a seguir no terminal:
```bash
docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 postgres:16.2-alpine3.19
```
### Caso queira uma senha diferente altere o argumento "POSTGRES_PASSWORD" e coloque a senha que desejar.

Em seguida o projeto pode ser inicializado por qualquer IDE que desejar, por exemplo, Visual Studio ou Rider. Outra opção é executando o projeto via terminal, acessando a pasta do projeto e executando com os comandos a seguir:
```bash
#Acessa a pasta do projeto
cd ./ProjetoJUST-IT

#Builda e inicializa o projeto
dotnet run --project ProjetoJUST.Api
``` 
## Rotas
Todas as rotas podem ser vistas na documentação feita pelo Swagger na rota **localhost:7085/swagger**

# IMPORTANTE!!!!
Para testar a rota *localhost:7085/api/Usuario/token* rode o seguinte comando dentro do banco de dados.
```sql
INSERT INTO  usuario(email, senha) VALUES('teste@gmail.com', '1234')

INSERT INTO PERMISSAOUSUARIO (IDUSUARIO,IDPERMISSAO) VALUES(1,1);
```
Após isso será possível realizar o POST da rota para ter acesso ao token JWT podendo assim acessar as outras rotas.
Com o token você pode coloca-lo no botão Authorize da seguinte forma **Bearer 'seu token'** sem as aspas.