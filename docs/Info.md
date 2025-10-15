----
Conta(Nome, Documento, Saldo, DataAbertura)
DesativacaoConta(Documento, Data, Responsavel)
Movimentação (DocumentoDebitado, DocumentoCreditado, Valor, DataOperação)

> Cadastro
    Regras:
        RN1: Nome e documento são obrigatórios
        RN2: Não é permitida mais de uma conta para um mesmo documento
        RN3: Conta deve ter saldo inicial igual a 1000
        RN4: Data de abertura alimentada pelo sistema
> Listagem com filtro (Nome e documento)
    - Nome do Cliente
    - Documento do Cliente
    - Saldo
    - Data de abertura da conta
    - Status
> Inativação
    Recebe como parametro o documento do titular
    Regras: 
        RN1: Caso a conta esteja ativa o sistema deve alterar seu status para "inativa"
        RN2: A desativação da conta não deve excluir os dados históricos da conta
> Transferencia entre contas
    Regras:
        RN1: Conta de origem e de destino devem ser validas e ativas.
        RN2: A conta de origem deve ter saldo suficiente
        RN3: O saldo da conta de Origem deve ser debitado e a conta de destino deve ser creditado

 

