# myfinance-web-o4-dotnet
Projeto MyFinanceWeb - Controle de Finanças Pessoais (PUC Minas)

# Descrição

O projeto MyFinanceWeb replica uma gestão financeira dos gastos, com receitas e despesas de quem o opera. É possível realizar as ações de adicionar, editar ou excluir operações financeiras e organizar a gestão, através de transações, categorias e tipos das contas.

## Arquitetura:

-MVC - Model View Controller

## Ferramentas:

-ASP.NET MVC (.NET 7)
-VSCode
-Banco de dados MySQL Server Studio

## Membros do Trabalho:
[@Felipe da Silva Almeida](https://github.com/felipealmeida92)

[@Silas Ribeiro dos Santos](https://github.com/silassantos21)

[@Pablo Rodrigo dos Santos](https://github.com/pablorodrigosan)

## Inicialização
Para realizar a inicialização do projeto, siga os seguintes procedimentos:

1 Clonar o repositório (git clone https://github.com/felipealmeida92/myfinance-web-o4-dotnet.git)

2 Instalar os programas:

- [MySQL Server](https://www.mysql.com/downloads/)
- [Vs code](https://code.visualstudio.com/download)
- [.Net 7](https://dotnet.microsoft.com/pt-br/download)
OBS: Você pode verificar se foi instalado, com o comando ```dotnet --version```, pelo terminal

3 Executar o script de criação do banco de dados no MySql Server Studio (/docs/Mysql.sql);

4 Injetar biblioteca mySQL no arquivo dotnet

(```add package Pomelo.EntityFrameworkCore.MySql```)

5 Injetar biblioteca do Entity no arquivo dotnet

(```add package microsoft.entityframeworkcore.mysql```)

6 Acessar a pasta do projeto
    
```cd myfinance-web-o4-dotnet```

7 Executar o comando

```dotnet build && donet run```

8 Abrir o projeto no navegador, na porta 7024

URL: https://localhost:7024/