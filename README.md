# HungryPizzaAPI


Você acabou de ser contratado como desenvolvedor sênior da Hungry Pizza. Esta é uma pizzaria muito famosa no bairro, seus donos sempre foram muito reticentes quando o assunto é a venda online, mas diante das atuais circunstâncias eles tiveram de reconsiderar. 

Seu desafio é criar uma API para receber os pedidos feitos a partir do site da pizzaria que atenda aos requisitos abaixo:

- Todo pedido precisa ter um identificador único
- Um pedido pode ter no mínimo uma pizza e no máximo 10.
- Cada pizza pode ter até dois sabores, os sabores disponíveis são:
3 Queijos (R$ 50), Frango com requeijão (R$ 59.99), Mussarela (R$ 42.50), Calabresa (R$ 42.50), Pepperoni (R$ 55), Portuguesa (R$ 45), Veggie (R$ 59.99)
- O preço da pizza com dois sabores (meio a meio) deve ser composto pela metade do valor de cada uma das pizzas.
- O cliente não precisa ter cadastro para fazer um pedido, mas nesse caso precisará informar os dados de endereço de entrega, caso seja um cliente cadastrado ele não precisa informar o endereço de entrega, pois deve constar em seu cadastro.
- Não vamos cobrar frete nessa primeira versão do sistema
- O cliente deve ser capaz de ver seu histórico de pedidos, com os detalhes das pizzas, valor individual e valor total do pedido.

O front-end será desenvolvido por outro time, por isso a criação de testes de unidade e de integração são imprescindíveis. Fique a vontade para testar os cenários que achar mais relevantes.

Fique atento as regras:
- A aplicação deve ser construida com C#
- A api deve rodar em ambiente Linux, por isso é necessário que seja construida com .NET Core
- A definição do banco de dados utilizado fica a critérido do candidato
- Esperamos que você resolva o teste em até 2 dias a contar da data combinada para início. Caso você precise de mais tempo, por favor, avise-nos com até três dias de antecedência a contar do recebimento.
- Ao final do prazo limite ou quando você terminar, o que acontecer primeiro, você deve publicar o código desenvolvido em um repositório aberto no github e, depois, responder a este formulário com o link para o repositório.


SOLUÇÃO:

- Incluir cliente\
\
Método POST\
http://localhost:51600/API/Clientes \
\
Parâmetros
```json
{
    "nome": "Paulo Roberto",
    "login": "proberto",
    "enderecoEntregaId": 2
}
```

- Incluir endereço de entrega\
\
Método POST\
http://localhost:51600/API/EnderecoEntrega \
\
Parâmetros
```json
{
    "Endereco": "Rua Humaita, 109 apto 901",
    "Bairro": "Humaita",
    "Cidade": "Rio de Janeiro",
    "Estado": "RJ",
    "Cep": "22261-000"
}
```

- Incluir pedido de cliente sem cadastro\
\
Método POST\
http://localhost:51600/API/Pedidos/CriarPedido \
\
Parâmetros
```json
{
    "nomeCliente": "Joao",
    "enderecoEntrega": {
        "endereco": "Rua XYZ"
    }
}
```
Aqui ele valida os dados e não deixa inserir sem nome de cliente e sem endereço de entrega.

- Incluir pedido com cliente cadastrado\
\
Método POST (sem parâmetros)\
http://localhost:51600/API/Pedidos/CriarPedido/maria \
\


- Incluir pizza de 1 sabor no pedido atual\
\
Método POST\
http://localhost:51600/API/Pedidos/InserirPizza/6

- Inserir pizza de 2 sabores no pedido atual (meio a meio - a API calcula o valor correto a partir da metade do preço de cada sabor)\
\
Método POST\
http://localhost:51600/API/Pedidos/InserirPizza/4-6
\
Em ambas chamadas acima (incluir pizza), a API valida se já tem 10 itens lançados para o pedido.


- Finalizar pedido\
\
Método POST (sem parâmetros)\
http://localhost:51600/API/Pedidos/24 \
\


- Histórico do cliente\
\
Método GET\
http://localhost:51600/API/Clientes/Historico/proberto


- Testes - ? 
