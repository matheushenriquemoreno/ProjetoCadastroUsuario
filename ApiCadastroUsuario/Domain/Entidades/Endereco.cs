using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entidades
{
    public class Endereco : IEntidadeBase
    {
        [Key]
        public int Id { get; }

        public string EnderecoRua { get; set; }

        public string Cep { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string SiglaEstado { get; set; }

        public Usuario UsuarioEndereco { get; set; }

        public Endereco(string enderecoRua, string cep, string complemento, string bairro, string cidade, string siglaEstado)
        {
            EnderecoRua = enderecoRua;
            Cep = cep;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            SiglaEstado = siglaEstado;
        }

        public Endereco(string enderecoRua, string cep, string complemento, string bairro, string cidade, string siglaEstado, string numero) 
         : this(enderecoRua, cep, complemento, bairro, cidade, siglaEstado)
        {
            this.Numero = numero;
        }

    }
}
