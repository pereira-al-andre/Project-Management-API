﻿using Proj.Manager.Core.Enums;

namespace Proj.Manager.Core.Entities
{
    public sealed class Projeto : Entidade
    {

        public Projeto()
        {
            
        }

        public Projeto(
            Guid gerenteId,
            string nome, 
            string descricao, 
            DateTime dataInicio, 
            DateTime dataPrazo)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataInicio = dataInicio;
            this.DataPrazo = dataPrazo;
            this.GerenteId = gerenteId;

            this.Tarefas = new List<Tarefa>();
        }

        public Projeto(
            Guid gerenteId,
            string nome,
            string descricao,
            DateTime dataInicio)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataInicio = dataInicio;
            this.DataPrazo = dataInicio.AddDays(15);
            this.GerenteId = gerenteId;

            this.Tarefas = new List<Tarefa>();
        }

        public Guid GerenteId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrazo { get; set; }
        public DateTime? DataTermino { get; set; } = null;
        public EStatusProjeto Status { get; set; } = EStatusProjeto.NaoIniciado;

        public List<Tarefa> Tarefas { get; set; }
        public Membro Gerente { get; set; } = null!;

        public void Atualizar(
            string nome,
            string descricao,
            DateTime dataPrazo)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataPrazo = dataPrazo;
        }

        public void AdicionarTarefa(Tarefa tarefa) => this.Tarefas.Add(tarefa);

        public void RemoverTarefa(Tarefa tarefa) => this.Tarefas.Remove(tarefa);

        public void Deletar()
        {
            this.Status = EStatusProjeto.Deletada;
            this.DataTermino = DateTime.Now;
        }

        public void Finalizar()
        {
            this.Status = EStatusProjeto.Finalizada;
            this.DataTermino = DateTime.Now;
        }

        public void Cancelar()
        {
            this.Status = EStatusProjeto.Cancelada;
            this.DataTermino = DateTime.Now;
        }

        public void MarcarEmAndamento()
        {
            this.Status = EStatusProjeto.EmAndamento;
        }
    }
}
