# Drag and Drop
O drag and drop funciona para todas as atividades de clicar e arrastar letras, sendo que com poucas mudanças pode-se fazê-lo funcionar para qualquer atividade de clicar e arrastar algo para algum lugar.

# Configuração básica
Para funcionar, é necessário que sua cena tenha um canvas e que os elementos do canvas estejam configurados como a cena de exibição do drag and drop (veja na pasta principal)
Tambem é preciso que seu projeto esteja configurado para Android.

# Scripts e Prefabs
Existem dois prefabs básicos: o Letter, que representa o texto arrastavel e o InsertField, que é o campo no qual se deve soltar o texto.

## Letter
O Letter conta com alguns recursos incluindo um script. Nesse script é necessario passar alguns parametros como a camera, o canvas e um codigo que serve para comparar ao codigo dos Fields e assim poder saber se a Letter foi arrastada para o Field correto.

## InsertField
Assim como o Letter, o InsertField conta com alguns recursos, bem como com um script com os atributos de caracteres, que diz quantos caracteres esse field pode comportar e codigo, que tem a mesma funcionalidade do codigo do Letter.

