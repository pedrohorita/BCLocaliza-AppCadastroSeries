using System;

namespace BCLocaliza.CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcUsuario = ObterOpcUsuario();

            while (opcUsuario != "X")
            {
                switch (opcUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizerSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcUsuario = ObterOpcUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Série");

            ListarSeries();

            Console.WriteLine("Digite a Série entre as opções acima: ");
            int id = int.Parse(Console.ReadLine());

            repositorio.Atuliza(id, PreecherSerie(id));
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir Série");

            ListarSeries();

            Console.WriteLine("Digite a Série entre as opções acima: ");
            int id = int.Parse(Console.ReadLine());
            Serie s = repositorio.RetornaPorId(id);
            Console.WriteLine("Deseja mesmo excluir a série {0}-{1}? ", s.RetornaId(), s.RetornaTitulo());
            Console.WriteLine(@"
            1- SIM
            2- NÃO ");
            if (int.Parse(Console.ReadLine())== 1 )
            {
                repositorio.Exclui(id);
                Console.WriteLine("Série excluída.");
            }
            else
            {
                Console.WriteLine("Exclusão cancelada.");
            }
           
        }

        private static void VisualizerSerie()
        {
            Console.WriteLine("Visualizar Série");

            ListarSeries();

            Console.WriteLine("Digite a Série entre as opções acima: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(repositorio.RetornaPorId(id));
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Série");

            repositorio.Insere(PreecherSerie());
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            
            if(lista.Count ==0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (serie.RetornaExcluido() ? "*Excluído*" : ""));
            }
        }

        private static Serie PreecherSerie(int id = -1)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de Início da Série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string descricao = Console.ReadLine();
            if(id == -1)
            {
                id = repositorio.ProximoId();
            }
            Serie novaSerie = new Serie(id: id,
                                        genero: (Genero)genero,
                                        titulo: titulo,
                                        ano: ano,
                                        descricao: descricao);
            return novaSerie;
        }

        private static string ObterOpcUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo a Loc Series!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcUsuario;
        }
    }
}
