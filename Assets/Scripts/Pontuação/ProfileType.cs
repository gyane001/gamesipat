using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileCalc : MonoBehaviour
{
    public string DefinirPerfilSeguranca()
{
    int acertos = GameData.totalWins;

    if (acertos <= 2) {
        return "Perfil Vulnerável: Você precisa se atentar mais aos riscos digitais.";
    }
    else if (acertos <= 5) {
        return "Perfil Cauteloso: Você conhece o básico, mas ainda corre alguns riscos.";
    }
    else {
        return "Perfil Especialista: Parabéns! Você demonstra ótimos hábitos de segurança.";
    }
}
}
