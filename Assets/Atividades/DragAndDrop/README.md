# Drag and Drop
O drag and drop funciona para todas as atividades de clicar e arrastar letras ou palavras, sendo que com poucas mudanças pode-se fazê-lo funcionar para qualquer atividade de clicar e arrastar algo para algum lugar.

# Configuração básica
Para funcionar, é necessário que sua cena tenha um canvas e que os elementos do canvas estejam configurados como a cena de exibição do drag and drop (veja na pasta principal)
Tambem é preciso que seu projeto esteja configurado para Android.

# Scripts e Prefabs
Existem três prefabs básicos: o Letter, que representa o texto arrastável, o InsertField, que é o campo no qual se deve soltar o texto e o Manager, que deixa o ajuste mais automático para o desenvolvedor.

## Letter
O Letter conta com alguns recursos incluindo um script. Nesse script é necessario passar um codigo que serve para comparar ao codigo dos Fields e assim poder saber se a Letter foi arrastada para o Field correto.

## InsertField
Assim como o Letter, o InsertField conta com alguns recursos, bem como com um script com codigo, que tem a mesma funcionalidade do codigo do Letter.

## Manager
O Manager funciona deixando tudo dinâmico para o desenvolvedor. Ele verifica todos os Letters e Fields da cena e ajusta o tamanho dos Fields com relação aos textos de mesmo codigo. Assim uma Letter com texto "ABC" com codigo 1 vai ajustar o Field de codigo um para suportar 3 caracteres.
