using System;

namespace DIO_DevFlix
{
    public class Curso : EntidadeBase
    {
        //Atributos Extras
        private Tema Tema { get; set;}
        private string Titulo { get; set; }
        private string Descricao { get; set; }  
        private string Mentor { get; set; }
		private bool Excluido {get; set; }

        //Métodos
		public Curso(int id, Tema tema, string titulo, string descricao, string mentor)
		{
			this.Id = id;
			this.Tema = tema;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Mentor = mentor;
			this.Excluido = false;
		} 

        public override string ToString()
		{
            string retorno = "";
            retorno += "Tema: " + this.Tema + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Mentor do curso: " + this.Mentor + Environment.NewLine;
			retorno += "Excluído: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}	
		public bool retornaExcluido()
		{
			return this.Excluido;
		}
		public void Exclui()
		{
			this.Excluido = true;
		}
		public Tema retornaTema()
		{
			return this.Tema;
		}
    }
}