using System;
using System.Collections.Generic;
using System.Text;

namespace BCLocaliza.CadastroSeries
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = $@"
                Gênero: {this.Genero}
                Titulo: {this.Titulo}
                Descrição: {this.Descricao}
                Ano de Inínio: {this.Ano}
                Excluído: {this.Excluido}";
            return retorno;
        }
        public string RetornaTitulo()
        {
            return this.Titulo;
        }
        public bool RetornaExcluido()
        {
            return this.Excluido;
        }
        public int RetornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
