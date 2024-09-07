using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Agendamentos;

public class AgendamentoRepository: IAgendamentoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AgendamentoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<Agendamento>> GetAllAsync()
    {
        return await _dbContext.Agendamentos
            .Include(a=> a.Paciente)
            .Include(a => a.Medico)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Agendamento agendamento)
    {
        _dbContext.Agendamentos.Add(agendamento);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var agendamento = await GetByIdAsync(id);
        _dbContext.Agendamentos.Remove(agendamento);

        await  _dbContext.SaveChangesAsync();
    }

    public async Task<Agendamento?> GetByIdAsync(int id)
    {
        return await _dbContext.Agendamentos
            .Include(a => a.Paciente)
            .Include(a => a.Medico)
            .SingleAsync(a => a.Id == id);
    }

    public async Task<List<AgendamentosAnuais>?> GetReportAsync()
    {
        var result = _dbContext.Database.SqlQuery<AgendamentosAnuais>(
            $"SELECT MONTH(DataConsulta) AS Mes, COUNT(*) AS QuantidadeAgendamentos FROM Agendamentos WHERE YEAR(DataConsulta)= {DateTime.Today.Year.ToString()} GROUP BY MONTH(DataConsulta) ORDER BY Mes;");

        return await Task.FromResult(result.ToList());
    }
}
