Desafio Técnico - Sistema Caixa de Banco da 
Vindi 
Antes de começar 
Por favor, leia atentamente todo este documento e procure seguir as instruções com o 
máximo de cuidado: 
1. Crie um repositório no seu GitHub sem menções ao desafio da Vindi; 
2. Envie o link do seu repositório para o email do recrutador responsável; 
3. Sinta-se à vontade para esclarecer qualquer dúvida com os recrutadores técnicos. 
Requisitos Técnicos: 
1. Linguagem: C# 
2. Framework: .NET 
3. Banco de Dados: O qual você achar mais adequado 
Objetivo 
Desenvolver a API do Sistema de Caixa de Banco da Vindi, permitindo o cadastro de contas 
e a transferência de valores. 
Entregáveis 
Implementar a API do Sistema de Caixa de Banco da Vindi, possibilitando o cadastro de 
contas e a realização de transferências de valores. 
Segurança 
A segurança do sistema será garantida pela restrição física de acesso à máquina onde o 
sistema será executado. Não será necessária a implementação de mecanismos adicionais 
de autenticação e autorização. 
Etapas: 
----
1. Cadastro de Contas Bancárias 
1. Descrição: 
Como gestor do sistema, desejo cadastrar novas contas bancárias para os 
clientes da Vindi. 
2. Critérios de Aceitação: 
a. O nome e o documento do cliente são campos obrigatórios. 
b. Não é permitido cadastrar mais de uma conta para o mesmo documento. 
c. Todas as contas devem começar com um saldo inicial de R$1000 como 
bonificação. 
d. A data de abertura da conta deve ser registrada automaticamente no 
momento do cadastro. 
----
2. Consulta de Contas Cadastradas 
1. Descrição: 
Como gestor do sistema, desejo consultar contas cadastradas, filtrando por 
nome ou documento. 
2. Critérios de Aceitação: 
a. A listagem deve retornar as contas cadastradas, com os seguintes dados: 
i. 
Nome do cliente 
ii. 
Documento do cliente 
iii. Saldo atual 
iv. Data de abertura da conta 
v. Status da conta (ativa ou inativa) 
b. Deve ser possível filtrar as contas por nome (parcial ou completo) ou 
documento. 
----
3. Inativação de Conta 
3. Descrição: 
Como gestor do sistema, desejo desativar uma conta bancária com base no 
número do documento do titular. 
4. Critérios de Aceitação: 
a. O sistema deve receber como parâmetro o número do documento do titular 
da conta. 
b. Caso a conta seja encontrada e esteja ativa, o sistema deve alterar seu 
status para "inativa". 
c. Após a desativação, o sistema deve registrar a ação realizada, incluindo o 
número do documento, a data/hora da desativação e o usuário responsável 
pela ação. 
d. A desativação da conta não deve excluir os dados históricos da conta, como 
transações. 
----
4. Transferência entre Contas 
1. Descrição: 
Como gestor do sistema, desejo realizar transferências entre contas 
bancárias, garantindo que as contas envolvidas estejam ativas e que a conta 
de origem tenha saldo suficiente. 
2. Critérios de Aceitação: 
a. A conta de origem e a conta de destino devem ser válidas e estarem com o 
status "ativa". 
b. A conta de origem deve ter saldo suficiente para cobrir o valor da 
transferência. 
c. O saldo da conta de origem deve ser debitado, e o saldo da conta de destino 
deve ser creditado com o valor da transferência. 

----
O que será avaliado 
● Arquitetura do projeto: estruturação e escolha adequada das ferramentas e 
padrões utilizados. 
● Organização e legibilidade do código: clareza, modularidade e boas práticas de 
desenvolvimento. 
● Organização e legibilidade dos testes: cobertura e facilidade de compreensão dos 
testes implementados. 
● Documentação para consumo da API: clareza e completude das instruções para 
integração com a API. 
● Documentação para execução do projeto: detalhamento dos passos necessários 
para configurar e rodar o projeto localmente.
