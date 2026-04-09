    -> SituacaoPF_1_1

 === SituacaoPF_1_1 ===
Durante o trajeto até o seu local de trabalho você chega a um cruzamento interno onde circulam alguns veículos. Há faixa de pedestre sinalizada no local. O que você faz? #portrait:default

*[Aguardo a parada dos veículos, mantendo contato visual com o motorista e atravesso na faixa de pedestres.] #win #portrait: PF_SITU_11
Ótima escolha! Utilizar a faixa, manter contato visual e aguardar a parada total garante que você foi visto.
Segurança no deslocamento depende da atenção de todos.
    -> SituacaoPF_1_2
    
*[Atravesso na faixa sem aguardar, pois, tenho prioridade.]
Perigoso! Mesmo estando na faixa, é essencial fazer contato visual e garantir a parada total do veículo. Contamos com você!.] #portrait:PF_SITU_12
    -> SituacaoPF_1_2
    
*[Atravesso fora da faixa para, chegar mais rápido.] 
Perigoso! Atravessar fora da faixa reduz a visibilidade e aumenta o risco de atropelamento. Aguarde a parada dos veículos, mantenha contato visual com o motorista e atravesse na faixa de pedestres. #portrait:PF_SITU_13
    -> SituacaoPF_1_2
 
 
=== SituacaoPF_1_2 ===
Seu celular toca enquanto você caminha em direção ao seu local de trabalho. Qual sua atitude? #portrait:default

*[Paro em local seguro para atender.] 
O deslocamento exige atenção total ao ambiente.#win
Parar ou ignorar a chamada reduz o risco de quedas e colisões.
 -> SituacaoPF_1_3

*[Ignoro e sigo o trajeto.]
O deslocamento exige atenção total ao ambiente. #win
Parar ou ignorar a chamada reduz o risco de quedas e colisões.
 -> SituacaoPF_1_3

*[Atendo e permaneço andando.]
O uso do celular durante o deslocamento compromete sua percepção de obstáculos e veículos.
 -> SituacaoPF_1_3
 
 === SituacaoPF_1_3 ===
Você está chegando ao seu local de trabalho e uma obra está obstruindo a rota de circulação, mas está devidamente sinalizada.
Como você se comporta?
 #portrait:default

*[Desvio pelo caminho seguro/sinalizado.]
Respeitar as rotas seguras reduz o risco de eventos indesejados como quedas e lesões.
Segurança também é manter o fluxo organizado.
-> fim

*[Avalio a situação e se não perceber riscos, eu passo pelo obstáculo e continuo o percurso.]
Obra sinalizada é área de risco. Nunca avance, mesmo que pareça seguro
-> fim

*[Desconsidero o local seguro/sinalizado e passo por qualquer local.]
Ignorar a área segura expõe você a riscos invisíveis. Queremos você seguro. Siga a sinalização.
-> fim

#portrait:default
=== fim ===
-> DONE