using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Medicos;

public class MedicoRepository: IMedicoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MedicoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Medico medico)
    {
        _dbContext.Medicos.Add(medico);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Medico medico)
    {
        _dbContext.Medicos.Update(medico);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Medico>> GetAllAsync()
    {
        return await _dbContext.Medicos
            .AsNoTracking() //não mapeia os objetos para alteração, somente listagem
            .ToListAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var medico = await GetByIdAsync(id);
        _dbContext.Medicos.Remove(medico);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Medico?> GetByIdAsync(int id)
    {
        return await _dbContext.Medicos.SingleOrDefaultAsync(p => p.Id == id);
    }
}
