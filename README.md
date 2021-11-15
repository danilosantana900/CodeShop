A grande magazine CodeShop tem o ambicioso desejo de expandir as operações para o mundo online!

Sua missão será construir uma API segura utilizando os padrões Restful. A primeira API será relacionada a produtos, e deverá atender ao seguintes requisitos:

Criar Produto *
Alterar Produto *
Deletar Produto *
Consultar Produtos com o filtro de nome do produto
Buscar produto por id
** Apenas o usuário com a role “Funcionário” poderá acessar essas APIs seguras

Também será sua responsabilidade criar os métodos para controlar o carrinho de compra. Este carrinho de compras deverá contemplar os seguintes métodos.
Adicionar produto ao carrinho
Deletar item do carrinho
Esvaziar carrinho
Listar todos os produtos
Efetuar checkout * (apresentar o valor total com todos os produtos e suas quantidades)
** Apenas o usuário com a role “Cliente” poderá acessar essas APIs seguras

* Requer autenticação para ser utiliza

artefatos de entrega do projeto
postman > com as chamadas das API
código fonte

pontos importantes:
Criar método de autenticação
Não posso ter produtos repetidos
ao Alterar/Deletar o produto, caso o produto não existir na base de dados, informar ao usuário
Caso filtro de nome do produto para consulta estiver vazio, retornar todos os registros
Apenas podem ser incluídos no carrinho os produtos que existirem na base de dados


