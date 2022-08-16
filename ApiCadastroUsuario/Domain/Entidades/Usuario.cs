using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entidades
{
    public class Usuario : IEntidadeBase
    {
        [Key]
        public int Id { get; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NumeroContado { get; set; }

        public Endereco Endereco { get; set; }

        public DateTime? DataCadastro { get; protected set; }

        public Usuario()
        {
            DataCadastro = DateTime.Now;
        }

        public Usuario( string nome, string cPF, string email, DateTime dataNascimento, string numeroContado) :
            this()
        {
            Nome = nome;
            CPF = cPF;
            Email = email;
            DataNascimento = dataNascimento;
            NumeroContado = numeroContado;
        }
    }
}
