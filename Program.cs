using System;
using DIO.Filmes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
		//repositorio de séries       
		static FilmeRepositorio armazem = new FilmeRepositorio();
		//Repositorio de filmes
        static void Main(string[] args)
        {					
			string preferencia = Entrada();
			while (preferencia.ToUpper() != "X")
			{
				switch (preferencia)
				{					
					case "1":					
													
						string opcaoFilmes = Filme();
						while (opcaoFilmes.ToUpper() != "V")
						{
							switch (opcaoFilmes)
							{
									case "1":
									ListarFilmes();						
									break;

								case "2":
									InserirFilme();
									break;

								case "3":
									AtualizarFilme();
									break;

								case "4":
									ExcluirFilme();
									break;

								case "5":
									VisualizarFilme();
									break;

								case "C":
									Console.Clear();
									break;

								case "X":
									Console.WriteLine("Obrigado por utilizar nossos serviços."); 
									Console.ReadLine();Environment.Exit(0);
									break;

								default:
									Console.WriteLine("Opção indisponivel", opcaoFilmes);
									Console.ReadLine();
									break;	
							}				
							opcaoFilmes = Filme();							
						}
						break;	

					case "2":
												
						string opcaoUsuario = Serie();
						while (opcaoUsuario.ToUpper() != "V")
						{														
							switch (opcaoUsuario)
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
									VisualizarSerie();
									break;

								case "C":
									Console.Clear();
									break;
										
								case "X": 
									Console.WriteLine("Obrigado por utilizar nossos serviços."); 
									Console.ReadLine();Environment.Exit(0);
									break;
																		
								default:
									Console.WriteLine("Opção indisponivel", opcaoUsuario);
									Console.ReadLine();
									break;
							}
							opcaoUsuario = Serie();							
						}
						break;
											
					default:
						Console.WriteLine("Opção indisponivel", preferencia);
						Console.ReadLine();
						break;				
				}
				preferencia = Entrada();
			}
			Console.WriteLine("Obrigado por utilizar nossos serviços."); 
			Console.ReadLine();Environment.Exit(0);
        }
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}
		private static void ExcluirFilme()
		{			
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			armazem.Exclui(indiceFilme);						
		}
        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}
		private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = armazem.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}
        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da Série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de início: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

		private static void AtualizarFilme()
		{
			Console.Write("Digite o id: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o título: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de início: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			armazem.Atualiza(indiceFilme, atualizaFilme);
		}

        private static void ListarSeries()
		{
			Console.WriteLine("Listar Séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		private static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");
			var lista = armazem.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
				var excluido = filme.retornaExcluido();
							
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
        private static void InserirSerie()
		{
			{
				Console.WriteLine("Inserir Nova série");

				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.Write("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				Console.Write("Digite o título da série: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o ano de início da série: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a descrição da série: ");
				string entradaDescricao = Console.ReadLine();

				Serie novaSerie = new Serie(id: repositorio.ProximoId(),
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											descricao: entradaDescricao);

				repositorio.Insere(novaSerie);
			}
		}
		private static void InserirFilme()
		{
			{
				Console.WriteLine("Inserir Novo Filme");

				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.Write("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				Console.Write("Digite o título do filme: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o ano de início do filme: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a descrição do filme: ");
				string entradaDescricao = Console.ReadLine();

				Filme novoFilme = new Filme(id: armazem.ProximoId(),
											genero: (Genero)entradaGenero,
											titulo: entradaTitulo,
											ano: entradaAno,
											descricao: entradaDescricao);

				armazem.Insere(novoFilme);
			}
		}
		private static string Entrada()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Filmes e Séries a seu dispor!!!");
			Console.WriteLine("Digite sua preferência:");

			Console.WriteLine("1- Filmes");
			Console.WriteLine("2- Séries");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string preferencia = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return preferencia;
		}
		private static string Filme()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar filmes");
			Console.WriteLine("2- Inserir novo filme");
			Console.WriteLine("3- Atualizar filme");
			Console.WriteLine("4- Excluir filme");
			Console.WriteLine("5- Visualizar filme");
			Console.WriteLine("C- Limpar tela");
			Console.WriteLine("V- Voltar tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoFilmes = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoFilmes;
		}
        private static string Serie()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar tela");
			Console.WriteLine("V- Voltar tela");
			Console.WriteLine("X- Sair\n");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}		
    }
}
