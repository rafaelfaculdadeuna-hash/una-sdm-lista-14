Entrega das atividades referenta a lista una-sdm-lista-14

1 - Explique no README como uma latência de 2 segundos impactaria um
franqueado tentando fechar um pedido em um tablet na frente do
cliente.

Resposta: Latência de 2 segundos por ação em um tablet de atendimento quebra a fluidez do pedido, aumenta o tempo total de atendimento e gera filas, especialmente em horários de pico. Para o cliente, passa a sensação de sistema lento ou instável; para o franqueado, aumenta a pressão e o risco de erros (como pedidos duplicados). No geral, prejudica a experiência e pode impactar diretamente as vendas.

2 - "Em grandes datas como a Páscoa, a Cacau Show recebe milhares de pedidos
por segundo. Como você evitaria que dois franqueados 'comprassem' o
último lote de Trufas disponível simultaneamente? Pesquise sobre 'Race
Conditions' e como o bloqueio de banco de dados (Locking) resolve isso."

Resposta: Em alta demanda, dois franqueados podem tentar comprar o último item ao mesmo tempo (*race condition*). O uso de *locking* no banco garante que apenas uma transação finalize a compra: no modelo pessimista, o registro é bloqueado; no otimista, o sistema valida na hora de salvar e rejeita conflitos. Isso evita vendas duplicadas e mantém o estoque correto.
