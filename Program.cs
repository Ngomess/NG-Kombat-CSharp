using System;

class Program
{
    // mensagem de inicio para mostrar o título do jogo
    static void NG_MostrarTitulo()
    {
        Console.Clear();

        Console.WriteLine("========================================");
        Console.WriteLine("              NG KOMBAT");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("          FIGHT FOR VICTORY!");
        Console.WriteLine();
    }

    //status da luta/batalha
    static void NG_MostrarStatus(
        string NG_nomeInimigo,
        int NG_vidaJogador,
        int NG_vidaInimigo)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("              BATALHA");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Jogador       : " + NG_vidaJogador + " HP");
        Console.WriteLine(NG_nomeInimigo + " : " + NG_vidaInimigo + " HP");
        Console.WriteLine();
    }

    // dano do ataque do jogador
    static int NG_RealizarAtaque(int NG_escolha)
    {
        int NG_dano = 0;

        switch (NG_escolha)
        {
            case 1:
                NG_dano = 100;
                Console.WriteLine();
                Console.WriteLine("Você utilizou SOCO!");
                Console.WriteLine("Dano causado: " + NG_dano);
                break;

            case 2:
                NG_dano = 100;
                Console.WriteLine();
                Console.WriteLine("Você utilizou CHUTE!");
                Console.WriteLine("Dano causado: " + NG_dano);
                break;

            case 3:
                NG_dano = 200;
                Console.WriteLine();
                Console.WriteLine("Você utilizou SPECIAL MOVE!");
                Console.WriteLine("Dano causado: " + NG_dano);
                break;
        }

        return NG_dano;
    }

    // definição do ataque do adversário
    static int NG_AtaqueInimigo(Random NG_random)
    {
        // O computador escolhe aleatoriamente entre 1, 2 e 3 para o inimigo, ele nao tera opçao de defesa

        int NG_ataqueInimigo = NG_random.Next(1, 4);
        int NG_danoInimigo = 0;

        switch (NG_ataqueInimigo)
        {
            case 1:
                NG_danoInimigo = 100;
                Console.WriteLine();
                Console.WriteLine("O adversário utilizou SOCO!");
                break;

            case 2:
                NG_danoInimigo = 100;
                Console.WriteLine();
                Console.WriteLine("O adversário utilizou CHUTE!");
                break;

            case 3:
                NG_danoInimigo = 200;
                Console.WriteLine();
                Console.WriteLine("O adversário utilizou SPECIAL MOVE!");
                break;
        }

        return NG_danoInimigo;
    }

    static void Main()
    {
        // vetor com os nomes dos adversários

        string[] NG_nomes =
        {
            "Johnny Cage",
            "Scorpion",
            "Raiden",
            "Sub-Zero",
            "Shao Kahn"
        };

        // vetor com os HP de cada adversário
        int[] NG_hpInimigos =
        {
            900,
            950,
            1000,
            1050,
            1150
        };

        // Controla se o jogador deseja iniciar uma nova partida
        bool NG_jogarNovamente = true;

        // DO WHILE deixa o jogador jogar novamente
        do
        {
            NG_MostrarTitulo();

            // input do nome do jogador 
            Console.Write("Digite seu nome: ");
            string NG_nomeJogador = Console.ReadLine() ?? "Jogador";

            // vida do jogador (1.000 HP)
            int NG_vidaJogador = 1000;

            // cria o gerador de números aleatórios
            Random NG_random = new Random();

            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao NG KOMBAT, " + NG_nomeJogador + "!");
            Console.WriteLine();
            Console.WriteLine("Seu HP inicial será de 1000 HP.");
            Console.WriteLine();
            Console.WriteLine("Você enfrentará 5 adversários.");
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para começar...");
            Console.ReadLine();

            // mostra se o jogador foi derrotado
            bool NG_derrotado = false;

            // FOR: percorre todas as 5 fases
            for (int NG_fase = 0; NG_fase < NG_nomes.Length; NG_fase++)
            {
                // o jogador começa cada fase com 1000 HP
                NG_vidaJogador = 1000;

                // busca o nome e o HP do inimigo no vetor 
                string NG_nomeInimigo = NG_nomes[NG_fase];
                int NG_vidaInimigo = NG_hpInimigos[NG_fase];

                Console.Clear();

                Console.WriteLine("========================================");
                Console.WriteLine("              FASE " + (NG_fase + 1));
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine("             VOCÊ VS");
                Console.WriteLine();
                Console.WriteLine("           " + NG_nomeInimigo);
                Console.WriteLine("           " + NG_vidaInimigo + " HP");
                Console.WriteLine();
                Console.WriteLine("           SEU HP: 1000");
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para iniciar a luta!");
                Console.ReadLine();

                /* WHILE mantém a luta enquanto os dois estiverem vivos
                explicação: o while mantém a batalha acontecendo enquanto o jogador e o inimigo tiverem HP >0
                */
                while (NG_vidaJogador > 0 && NG_vidaInimigo > 0)
                {
                    Console.Clear();

                    // mostra o status atual
                    NG_MostrarStatus(
                        NG_nomeInimigo,
                        NG_vidaJogador,
                        NG_vidaInimigo
                    );

                    Console.WriteLine("ESCOLHA SEU MOVIMENTO:");
                    Console.WriteLine();
                    Console.WriteLine("1 - Soco          [100 dano]");
                    Console.WriteLine("2 - Chute         [100 dano]");
                    Console.WriteLine("3 - Special Move  [200 dano]");
                    Console.WriteLine("4 - Defesa        [50% do dano]");
                    Console.WriteLine("9 - Sair do jogo");
                    Console.WriteLine();

                    Console.Write("Sua escolha: ");

                    int NG_escolha;

                    // Converte a entrada para número
                    if (!int.TryParse(Console.ReadLine(), out NG_escolha))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine("Digite apenas números.");
                        Console.WriteLine();
                        Console.WriteLine("Pressione ENTER para tentar novamente...");
                        Console.ReadLine();

                        continue;
                    }

                    // confere se a opção está entre 1 e 4 ou é a 9
                    if ((NG_escolha < 1 || NG_escolha > 4) && NG_escolha != 9)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Movimento inválido!");
                        Console.WriteLine("Escolha 1, 2, 3, 4 ou 9.");
                        Console.WriteLine();
                        Console.WriteLine("Pressione ENTER para tentar novamente...");
                        Console.ReadLine();

                        continue;
                    }

                    // opção 9 para encerrar o jogo
                    if (NG_escolha == 9)
                    {
                        Console.Clear();

                        Console.WriteLine("========================================");
                        Console.WriteLine("              NG KOMBAT");
                        Console.WriteLine("========================================");
                        Console.WriteLine();
                        Console.WriteLine("Você escolheu sair do jogo.");
                        Console.WriteLine();
                        Console.WriteLine("Até a próxima, " + NG_nomeJogador + "!");
                        Console.WriteLine();

                        return;
                    }

                    // variável que indica se o jogador está defendendo
                    bool NG_defesa = false;

                    // dano causado pelo jogador
                    int NG_danoJogador = 0;

                    /* SWITCH define a ação escolhida 
                    explicação: o switch verifica a escolha do jogador e define qual ação será realizada
                    */
                    switch (NG_escolha)
                    {
                        case 1:
                            NG_danoJogador = NG_RealizarAtaque(NG_escolha);
                            break;

                        case 2:
                            NG_danoJogador = NG_RealizarAtaque(NG_escolha);
                            break;

                        case 3:
                            NG_danoJogador = NG_RealizarAtaque(NG_escolha);
                            break;

                        case 4:
                            NG_defesa = true;

                            Console.WriteLine();
                            Console.WriteLine("Você escolheu DEFESA!");
                            Console.WriteLine(
                                "O próximo ataque recebido terá 50% do dano."
                            );

                            break;
                    }

                    // se aplica o dano causado pelo jogador
                    if (NG_danoJogador > 0)
                    {
                        NG_vidaInimigo =
                            NG_vidaInimigo - NG_danoJogador;

                        // impede que o HP do inimigo fique <0 após receber dano
                        if (NG_vidaInimigo < 0)
                        {
                            NG_vidaInimigo = 0;
                        }

                        Console.WriteLine();
                        Console.WriteLine(
                            NG_nomeInimigo +
                            " ficou com " +
                            NG_vidaInimigo +
                            " HP."
                        );

                        // verifica a situação do adversário de acordo com seu HP
                        if (NG_vidaInimigo <= 300)
                        {
                            Console.WriteLine(
                                "O adversário está quase derrotado!"
                            );
                        }
                        else if (NG_vidaInimigo <= 600)
                        {
                            Console.WriteLine(
                                "O adversário está ficando enfraquecido!"
                            );
                        }
                        else
                        {
                            Console.WriteLine(
                                "O adversário ainda está com bastante HP!"
                            );
                        }
                    }

                    // confere se o adversário foi derrotado
                    if (NG_vidaInimigo <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("========================================");
                        Console.WriteLine(
                            "       " +
                            NG_nomeInimigo.ToUpper() +
                            " DERROTADO!"
                        );
                        Console.WriteLine("========================================");

                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        "Pressione ENTER para o adversário atacar..."
                    );
                    Console.ReadLine();

                    // o inimigo faz seu ataque
                    int NG_danoInimigo =
                        NG_AtaqueInimigo(NG_random);

                    // se o jogador escolheu defesa, recebe apenas metade do dano
                    if (NG_defesa)
                    {
                        NG_danoInimigo =
                            NG_danoInimigo / 2;

                        Console.WriteLine();
                        Console.WriteLine(
                            "Sua defesa reduziu o dano pela metade!"
                        );
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        "Dano recebido: " +
                        NG_danoInimigo
                    );

                    // diminui o dano da vida do jogador
                    NG_vidaJogador =
                        NG_vidaJogador - NG_danoInimigo;

                    // impede que o HP fique negativo
                    if (NG_vidaJogador < 0)
                    {
                        NG_vidaJogador = 0;
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        "Seu HP agora: " +
                        NG_vidaJogador
                    );

                    // confere se o jogador foi derrotado, mostra o 'GAME OVER' quando o jogador é derrotado e acaba a batalha atual
                    if (NG_vidaJogador <= 0)
                    {
                        NG_derrotado = true;

                        Console.WriteLine();
                        Console.WriteLine("========================================");
                        Console.WriteLine("              GAME OVER");
                        Console.WriteLine("========================================");
                        Console.WriteLine();
                        Console.WriteLine(
                            "Você foi derrotado por " +
                            NG_nomeInimigo +
                            "!"
                        );

                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        "Pressione ENTER para continuar..."
                    );
                    Console.ReadLine();
                }

                /* se o jogador perdeu, encerra o FOR 
                explicação: se o jogador foi derrotado, o 'NG_derrotado' for true, o break encerra o laço 'for' e impede que o jogo avance para a próxima fase */

                if (NG_derrotado)
                {
                    break;
                }

                /* se venceu a fase e ainda existem fases
                apresenta para o jogador quem ele venceu e restaura o hp para a proxima fase 
                */
                if (NG_fase < NG_nomes.Length - 1)
                {
                    Console.Clear();

                    Console.WriteLine("========================================");
                    Console.WriteLine(
                        "        FASE " +
                        (NG_fase + 1) +
                        " CONCLUÍDA!"
                    );
                    Console.WriteLine("========================================");
                    Console.WriteLine();
                    Console.WriteLine(
                        "Você derrotou " +
                        NG_nomeInimigo +
                        "!"
                    );
                    Console.WriteLine();
                    Console.WriteLine(
                        "Seu HP será restaurado para 1000."
                    );
                    Console.WriteLine();
                    Console.WriteLine(
                        "Prepare-se para a próxima batalha!"
                    );
                    Console.WriteLine();
                    Console.WriteLine(
                        "Pressione ENTER para continuar..."
                    );

                    Console.ReadLine();
                }
            }

            /* se o jogador venceu todas as fases
            apresenta os nomes de todos que ele jogou contra 
            */
            if (!NG_derrotado)
            {
                Console.Clear();

                Console.WriteLine("========================================");
                Console.WriteLine("            !!! VITÓRIA !!!");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine(
                    "Parabéns, " +
                    NG_nomeJogador +
                    "!"
                );
                Console.WriteLine();
                Console.WriteLine(
                    "Você derrotou todos os adversários!"
                );
                Console.WriteLine();
                Console.WriteLine("Fases concluídas:");
                Console.WriteLine();
                Console.WriteLine("1 - Johnny Cage");
                Console.WriteLine("2 - Scorpion");
                Console.WriteLine("3 - Raiden");
                Console.WriteLine("4 - Sub-Zero");
                Console.WriteLine("5 - Shao Kahn");
                Console.WriteLine();
                Console.WriteLine(
                    "Você se tornou o campeão do NG KOMBAT!"
                );
            }

            // pergunta se o jogador quer jogar novamente dando opçoes de escolha entre 1 e 2

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("        DESEJA JOGAR NOVAMENTE?");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            Console.WriteLine();
            Console.Write("Escolha: ");

            // converte a resposta do jogador para número
            int NG_resposta = Convert.ToInt32(Console.ReadLine());

            // confere a resposta do jogador (1 e 2)
            if (NG_resposta == 1)
            {
                NG_jogarNovamente = true;
            }
            else if (NG_resposta == 2)
            {
                NG_jogarNovamente = false;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida!");
                Console.WriteLine("O jogo será encerrado.");
                NG_jogarNovamente = false;
            }

        } while (NG_jogarNovamente);

        // caso seja 2
        Console.Clear();

        Console.WriteLine("========================================");
        Console.WriteLine("          NG KOMBAT FINALIZADO");
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("Obrigado por jogar!");
        Console.WriteLine();
        Console.WriteLine("Até a próxima!");
    }
}