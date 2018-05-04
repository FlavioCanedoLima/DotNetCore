using Eventos.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Models
{
    public class Evento : Entity<Evento>
    {
        public Evento(
            string nome, 
            DateTime dataInicio, 
            DateTime dataFim,
            bool  gratuito,
            decimal valor,
            bool online,
            string nomeEmpresa)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
        }

        public string Nome { get; private set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoLonga { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool Gratuito { get; private set; }
        public decimal Valor { get; private set; }
        public bool Online { get; private set; }
        public string NomeEmpresa { get; private set; }
        public Categoria Categoria { get; private set; }
        public ICollection<Tags> Tags { get; private set; }
        public Endereco Endereco { get; private set; }
        public Organizador Organizador { get; private set; }

        

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region -- Validations --

        private void Validar()
        {
            ValidarNome();
            ValidarValor();
            ValidarData();
            ValidarLocal();
            ValidarNomeEmpresa();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(evento => evento.Nome)
                .NotEmpty().WithMessage("O nome do evento precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome de evento precisa ter entre 2 e 150 caracteres");
        }

        private void ValidarValor()
        {   
            if(Gratuito)
                RuleFor(evento => evento.Valor)
                    .ExclusiveBetween(0, 0)
                    .When(evento => evento.Gratuito)
                    .WithMessage("Não deve conter valor para evento gratuito");
            else
                RuleFor(evento => evento.Valor)
                .ExclusiveBetween(1, 50000)
                .When(evento => evento.Gratuito == false)
                .WithMessage("O valor deve estar entre 1.00 e 50.000");
        }

        private void ValidarData()
        {
            RuleFor(evento => evento.DataInicio)
                .GreaterThan(evento => evento.DataFim)
                .WithMessage("A data de ínicio deve ser maior que a data do final do evento");

            RuleFor(evento => evento.DataInicio)
                .LessThan(DateTime.Now)
                .WithMessage("A data de ínicio não deve ser menor que a data atual");
        }

        private void ValidarLocal()
        {
            if (Online)
                RuleFor(evento => evento.Endereco)
                    .Null().When(evento => evento.Online)
                    .WithMessage("O evento não deve possuir endereço se for online");
            else
                RuleFor(evento => evento.Endereco)
                    .NotNull().When(evento => evento.Online == false)
                    .WithMessage("O evento deve possuir endereço");
        }

        private void ValidarNomeEmpresa()
        {
            RuleFor(evento => evento.NomeEmpresa)
                .NotEmpty().WithMessage("O nome do organizador é obrigatório")
                .Length(2, 150).WithMessage("O nome do organizador precisa ter entre 2 e 150 caracteres");
        }

        #endregion
    }
}
