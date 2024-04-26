using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Assurez-vous d'ajouter la directive using pour le logging
using DialogueDeGestion.Controllers; // Remplacez YourAppName par le nom de votre namespace si nécessaire
using DialogueDeGestion.Models; // Assurez-vous que le namespace est correct pour vos modèles

public class DataService
{
    private readonly AppDbContext _context;
    private readonly ILogger<DataService> _logger; // Ajoutez ceci pour le logging

    public DataService(AppDbContext context, ILogger<DataService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Dialogue>> GetAllDialoguesAsync()
    {
        var dialogues = await _context.Dialogue.ToListAsync();
        _logger.LogInformation($"Loaded {dialogues.Count} dialogues."); // Loggez le nombre de dialogues chargés
        return dialogues;
    }

}
