# CodeShop - Projeto API Restful

### O QUE É
Construir uma API segura utilizando os padrões Restful.

### A QUEM SE DESTINA / OBJETIVO
A primeira API será relacionada a produtos atendendo ao seguintes requisitos:
Criar Produto
Alterar Produto 
Deletar Produto 
Consultar Produtos com o filtro de nome do produto
Buscar produto por id

De mesma forma, criados os métodos para controlar o carrinho de compra. Este carrinho de compras contempla os seguintes métodos:
Adicionar produto ao carrinho
Deletar item do carrinho
Esvaziar carrinho
Listar todos os produtos
Efetuar checkout (Apresentar o valor total com todos os produtos e suas quantidades)

#### Observações importantes:
- Apenas o usuário com a role “Funcionário” pode acessar essas APIs seguras
- Apenas o usuário com a role “Cliente” pode acessar essas APIs seguras
- Requer autenticação para sua utilização
- Os produtos não podem ser repetidos
- Ao Alterar/Deletar o produto, caso o produto não existir na base de dados, informamos o usuário
- Caso filtro de nome do produto para consulta estiver vazio, este retorna todos os registros
- Apenas podem ser incluídos no carrinho os produtos que existirem na base de dados

### BIBLIOTECAS UTILIZADOS NO PROJETO
- Postman API Platform para construção e utilização de APIs
- Microsoft.AspNetCore.Authentication para autenticação dos dados
- Microsoft.AspNetCore.Authentication.JwtBearer como forma de criptografia dos dados
- Microsoft.EntityFrameworkCore.InMemory como provedor de banco de dados em memória a ser usado para fins de teste

#### SOBRE OS AUTORES/ORGANIZADORES
Todos os contribuintes deste projeto são alunos da formação U.code | Web Full Stack pela Escola Let's Code


----------------------------
#### SE VOCÊ CHEGOU ATÉ AQUI
Muito obrigado pela atenção
