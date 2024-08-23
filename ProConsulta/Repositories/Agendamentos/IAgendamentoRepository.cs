﻿using ProConsulta.Models;

namespace ProConsulta.Repositories.Agendamentos;

public interface IAgendamentoRepository
{
    Task<List<Agendamento>> GetAllAsync();
    Task AddAsync(Agendamento agendamento);
    Task DeleteAsync(int id);
    Task<Agendamento?> GetByIdAsync(int id);
}
