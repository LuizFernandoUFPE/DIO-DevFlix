using System;
using System.Collections.Generic;

namespace DIO_DevFlix
{
    public class CursoRepositorio
    {
        Dictionary<int, Curso> dicionarioCursos = new Dictionary<int, Curso>();
        public void Insere(int id,Curso objeto)
        {
            dicionarioCursos.Add(id,objeto);
        }
        public void Excluir(int id)
        {
            dicionarioCursos[id].Exclui();    
        }
        public void Atualiza(int id, Curso objeto)
        {
            dicionarioCursos[id] = objeto;
        }
        public bool VerificarExistenciaPorId(int id)
        {
            if (dicionarioCursos.ContainsKey(id))
            {
                return true;    
            }
            return false;      
        }
        public Dictionary<int, Curso> RetornaCursos()
        {
            return dicionarioCursos;
        }     
        public void VisualizarUmCurso(int id)
        {
            Console.WriteLine(dicionarioCursos[id]);
			Console.WriteLine();	
        }     
        public void ExibirCursos()
        {
            foreach (var item in dicionarioCursos)
            {
            
                Console.WriteLine("#ID: {0}, Título: {1} {2}", item.Key, item.Value.retornaTitulo(), (item.Value.retornaExcluido() ? "*Excluído*" : ""));
            }
        }   
        public int ProximoId()
        {
            return dicionarioCursos.Count;
        }
        public Curso RetornaPorId(int id)
        {
            return dicionarioCursos[id];
        }
        public void VisualizarOsCursosPorTema(int idTema)
        {
            List<Curso> cursosPorTema = new List<Curso>();

            foreach (var item in dicionarioCursos)
            {
                if(item.Value.retornaTema() == (Tema)idTema)
                {
                    cursosPorTema.Add(item.Value);
                    
                }
            }
            if(cursosPorTema.Count == 0)
            {
                Console.WriteLine();
                System.Console.WriteLine("Não contém cursos com esse Tema");
               
            }
            else
            {
                for (int i = 0;i <cursosPorTema.Count; i++)
			    {
                    Console.WriteLine();
				    Console.WriteLine(dicionarioCursos[i]); 
                    
			    }
            }
        
        }
    }
}