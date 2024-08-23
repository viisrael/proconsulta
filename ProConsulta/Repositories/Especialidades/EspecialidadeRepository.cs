using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Especialidades;

public class EspecialidadeRepository: IEspecialidadeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EspecialidadeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Especialidade>> GetAllAsync()
    {
        return await _dbContext.Especialidades.AsNoTracking().ToListAsync();
    }
}
