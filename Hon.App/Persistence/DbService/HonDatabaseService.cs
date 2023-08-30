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
    public async Task<SampleModel?> GetSample(int sampleId)
    {
        return await _context.Samples.FindAsync(sampleId);
    }
    public async Task AddSample(SampleModel sample)
    {
        _context.Samples.Add(sample);
        await _context.SaveChangesAsync();          
    }
    public async Task UpdateSample(SampleModel sample)
    {
        var sampleToUpdate = await _context.Samples.FindAsync(sample.SampleId);
        if (sampleToUpdate != null)
        {
            sampleToUpdate.SampleName = sample.SampleName;
            await _context.SaveChangesAsync();
        }
    }
    public async Task DeleteSample(int sampleId)
    {
        var sample = await _context.Samples.FindAsync(sampleId);
        if (sample != null)
        {
            _context.Samples.Remove(sample);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Card>> ListCards()
    {
        return await _context.Card
                .Include(c => c.Category)
                .ToListAsync();
    }
    public async Task AddCard(Card card)
    {
        var cardToInsert = new Card()
        {
            CardId = card.CardId,
            CardName = card.CardName,
            CardContent = card.CardContent,
            CategoryId = card.CategoryId
        };
        _context.Card.Add(cardToInsert);
        await _context.SaveChangesAsync();          
    }
}

public interface IDatabaseService
{
    Task<List<SampleModel>> GetSamples();
    Task<SampleModel> GetSample(int sampleId);
    Task AddSample(SampleModel sample);
    Task UpdateSample(SampleModel sample);
    Task DeleteSample(int sampleId);
    Task<List<Card>> ListCards();
    Task AddCard(Card card);
}