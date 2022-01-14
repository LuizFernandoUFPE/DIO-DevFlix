using System;

namespace DIO_DevFlix
{
    class Program
    {
        static CursoRepositorio repositorio = new CursoRepositorio();
        static void Main(string[] args)
        {
			
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarCursos();
						break;
					case "2":
						InserirCurso();
						break;
					case "3":
						AtualizarCurso();
						break;
					case "4":
						ExcluirCurso();
						break;
					case "5":
						VisualizarCurso();
						break;
					case "6":
						VisualizarCursosPorTema();
						break;
					default:
						System.Console.WriteLine("Digite uma opção válida!");
						break;
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.WriteLine();
        }
        private static void ListarCursos()
		{	
			var cursos = repositorio.RetornaCursos();

			if (cursos.Count == 0) 
			{
				Console.WriteLine("Nenhum curso cadastrado.");
				return;
			}

			Console.WriteLine("Lista de Cursos: ");
			System.Console.WriteLine();

			repositorio.ExibirCursos();
		
		}
        private static void InserirCurso()
		{
			Console.WriteLine("Inserir novo Curso: ");
			Console.WriteLine();

			foreach (int i in Enum.GetValues(typeof(Tema)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tema), i));
				Console.WriteLine();
			}
			Console.Write("Digite o Tema do curso que deseja inserir entre as opções acima: ");
			int entradaTema = int.Parse(Console.ReadLine());
			if (entradaTema >0 && entradaTema <7)
			{
				Console.Write("Digite o Título da Curso: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Mentor do Curso: ");
				string entradaMentor = Console.ReadLine();

				Console.Write("Digite a Descrição do Curso: ");
				string entradaDescricao = Console.ReadLine();

				Curso novoCurso = new Curso(id: repositorio.ProximoId(),
											tema: (Tema)entradaTema,
											titulo: entradaTitulo,
											mentor: entradaMentor,
											descricao: entradaDescricao);

				repositorio.Insere(repositorio.ProximoId(),novoCurso);
				Console.WriteLine();
				Console.WriteLine($"Você inseriu com sucesso o curso {entradaTitulo}!");
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine("Digite um tema válido!");
			}
			
		}
        private static void AtualizarCurso()
		{
			var cursos = repositorio.RetornaCursos();

			if (cursos.Count == 0) 
			{
				Console.WriteLine("Nenhum curso cadastrado.");
				return;
			}
			
			Console.Write("Digite o ID do Curso ");
			int indiceCurso = int.Parse(Console.ReadLine());

			if(!repositorio.VerificarExistenciaPorId(indiceCurso))
			{
				Console.WriteLine();
				Console.WriteLine("Esse ID de curso não existe");
			}
			else
			{
				System.Console.WriteLine();
				foreach (int i in Enum.GetValues(typeof(Tema)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tema), i));
					Console.WriteLine();
				}
					
				Console.Write("Digite o Tema entre as opções acima: ");
				int entradaTema = int.Parse(Console.ReadLine());

				if (entradaTema >0 && entradaTema <7)
				{
					Console.Write("Digite o Título do Curso: ");
					string entradaTitulo = Console.ReadLine();

					Console.Write("Digite o Mentor do Curso: ");
					string entradaMentor = (Console.ReadLine());

					Console.Write("Digite a Descrição do Curso: ");
					string entradaDescricao = Console.ReadLine();

					Curso atualizaCurso = new Curso(id: indiceCurso,
												tema: (Tema)entradaTema,
												titulo: entradaTitulo,
												mentor: entradaMentor,
												descricao: entradaDescricao);

					repositorio.Atualiza(indiceCurso, atualizaCurso);

					System.Console.WriteLine();
					System.Console.WriteLine($"Você atualizou com sucesso o curso com a #ID: {indiceCurso}!");
				}
				else
				{
					System.Console.WriteLine("Escolha um tema válido!");
				}
			}
		}
        private static void ExcluirCurso()
		{
			var cursos = repositorio.RetornaCursos();			
			if (cursos.Count == 0) 
			{
				Console.WriteLine("Nenhum curso cadastrado.");
				return;
			}
			
			Console.WriteLine("Digite o ID do Curso: ");
			int indiceCurso= int.Parse(Console.ReadLine());

			repositorio.VerificarExistenciaPorId(indiceCurso);

			if(!repositorio.VerificarExistenciaPorId(indiceCurso))
			{
				Console.WriteLine();
				Console.WriteLine("Esse ID de curso não existe!");
			}

			else
			{

				Console.WriteLine();
				Console.WriteLine("Tem certeza que deseja excluir esse Curso? S - Sim, N - Não ");

				string confirmacao = Console.ReadLine();

				switch(confirmacao.ToUpper())
				{
					case "S":
					
						repositorio.Excluir(indiceCurso);
						Console.WriteLine();
						Console.WriteLine("Curso excluído com sucesso!");
						break;
					case "N":
						Console.WriteLine();
						Console.WriteLine("Curso não excluído!");
						break;
					
					default:
						Console.WriteLine();
						Console.WriteLine("Digite uma opção válida!");
						break;
				}
			}		
		}
        private static void VisualizarCurso()
		{
			var cursos = repositorio.RetornaCursos();
			if (cursos.Count == 0) 
			{
				Console.WriteLine("Nenhum curso cadastrado.");
				return;
			}
			
			Console.Write("Digite o ID do Curso: ");
			int indiceCurso = int.Parse(Console.ReadLine());

			repositorio.VerificarExistenciaPorId(indiceCurso);

			if(!repositorio.VerificarExistenciaPorId(indiceCurso))
			{
				Console.WriteLine();
				Console.WriteLine("Esse ID de curso não existe");
			}
			else
			{
				Console.WriteLine();
				repositorio.VisualizarUmCurso(indiceCurso);
			}
		}
		private static void VisualizarCursosPorTema()
		{
			var cursos = repositorio.RetornaCursos();
			if (cursos.Count == 0) 
			{
				Console.WriteLine("Nenhum curso cadastrado.");
				return;
			}
			
			foreach (int i in Enum.GetValues(typeof(Tema)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tema), i));
				Console.WriteLine();
			}
			
			Console.Write("Digite o Tema do curso entre as opções acima: ");
			
			
			int idTema = int.Parse(Console.ReadLine());
			
			if (idTema>0 && idTema<7)
			{
				repositorio.VisualizarOsCursosPorTema(idTema);
			}
			else
			{
				Console.WriteLine("Digite um tema válido!");
			}
		}
        private static string ObterOpcaoUsuario()
            {
				Console.WriteLine();
                Console.WriteLine("DIO: DevFlix");
                Console.WriteLine("Informe a opção desejada:");
				Console.WriteLine();

                Console.WriteLine("1- Listar Cursos");
                Console.WriteLine("2- Inserir novo Curso");
                Console.WriteLine("3- Atualizar Curso");
                Console.WriteLine("4- Excluir Curso");
                Console.WriteLine("5- Visualizar Curso");
				Console.WriteLine("6- Visualizar Cursos por Tema");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }
    }
}
