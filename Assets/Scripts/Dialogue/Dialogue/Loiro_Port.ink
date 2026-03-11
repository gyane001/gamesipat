#portrait:Loiro_Happy #layout:left
   -> IntroPortaria
 

=== IntroPortaria ===
#speaker:Lucas #portrait:Loiro_Happy #layout:left
    Olá seja bem-vindo ao Quiz! 
#portrait:Loiro_Neutro #speaker:Lucas
    Vou fazer algumas perguntas para você!  
    -> Pergunta1Portaria
    
 === Pergunta1Portaria ===
#portrait:Loiro_Neutro
Qual é a principal diferença entre o alarme intermitente e o alarme contínuo? 

+[Intermitente significa 'ficar em alerta', contínuo significa 'evacuar para o ponto de encontro'.]
    -> feedback1
    
+[Intermitente significa que a brigada está a caminho, contínuo significa que ela já chegou.]
Ops! Não é essa opção. Tente de novo. #portrait:Loiro_Sad
    -> Pergunta1Portaria

+[Intermitente é para acidentes pequenos, contínuo é para incêndios.]
    Ops! Não é essa opção. Tente de novo. #portrait:Loiro_Sad
    -> Pergunta1Portaria

+[Não há diferença; ambos exigem que se pare o trabalho.]
   Ops! Não é essa opção. Tente de novo. #portrait:Loiro_Sad
    -> Pergunta1Portaria
    
    === feedback1 ===
        Certa resposta! Vamos para a próxima pergunta. #portrait:Loiro_Happy
 -> Pergunta2Portaria
    
    
    
    === Pergunta2Portaria ===
Sob quais circunstâncias um colaborador deve retornar ao trabalho após um alarme contínuo? #portrait:Loiro_Neutro

+[Após 15 minutos do ponto de encontro.]
    Ops! Não é essa opção. Tente de novo. #portrait:Loiro_Sad
     -> Pergunta2Portaria
    
+[Apenas quando a equipe de brigadistas autorizar.]
    -> feedback2

+[Assim que o alarme parar de tocar.]
    Ops! Não é essa opção. Tente de novo. #portrait:Loiro_Sad
    -> Pergunta2Portaria

+[Quando o líder da sua área autorizar.]
   Ops! Não é essa opção. Tente de novo. #portrait:Loiro_Sad
    -> Pergunta2Portaria
    
    === feedback2 ===
    Uau! Você acertou de novo! #portrait:#portrait:Loiro_Happy
-> fim
    
    
=== fim ===
Você passou na primeira etapa! Siga em frente para continuar!#portrait:Loiro_Happy #win 
-> END
