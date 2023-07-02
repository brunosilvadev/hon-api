using Hon.Model;

namespace Hon.Persistence;

public class HonDatabaseService : IDatabaseService
{
    private readonly HonDbContext _context;
    public HonDatabaseService(HonDbContext context)
    {
        _context = context;
    }
    public async Task<List<SampleModel>> GetSamples()
    {
        return await _context.Samples.ToListAsync();
    }
    public async Task AddSample(SampleModel sample)
    {
        throw new NotImplementedException();            
    }
}

public interface IDatabaseService
{
    Task<List<SampleModel>> GetSamples();
    Task AddSample(SampleModel sample);
}